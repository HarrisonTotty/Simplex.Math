using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Operands;
using Simplex.Math.Core;
using Simplex.Math.Logic;
using Simplex.Math.Operations.Elementary;

namespace Simplex.Math.Operations.Special
{
    /// <summary>
    /// An alternative tree representation for a sequence of elements attached by a common sum operation (see remarks).
    /// </summary>
    /// <remarks>
    /// A collapsed sum operation will also automatically convert differences to sums.
    /// Example: (x - y) will be converted to (x + -y)
    /// </remarks>
    public class CollapsedSumOperation : CollapsedBinaryOperation
    {
        /// <summary>
        /// Creates a new collapsed sum operation from a sequence of operands.
        /// </summary>
        /// <param name="Operands">The expressions contained within this collapsed sum</param>
        public CollapsedSumOperation(params Expression[] Operands) : base(Operands)
        {
            
        }

        /// <summary>
        /// Creates a new collapsed sum operation from a given expression.
        /// Requires the input expression to be either a sum, difference, or some negation of the two.
        /// </summary>
        /// <param name="Input">The sum/difference expression to collapse</param>
        public static CollapsedSumOperation Create(Expression Input)
        {
            //Make sure that we are something we can collapse
            if (!(Propositions.IsSumOrDifference[Input] || Propositions.IsNegationOfSumOrDifference[Input])) throw new Exceptions.SimplexMathException("Cannot create collapsed sum operation - input is not a sum, difference, or a negation of either");
            return CollapseExpression(Input);
        }

        /// <summary>
        /// Recursively collapses an expression into a CSO.
        /// </summary>
        /// <param name="Input">The expression to collapse</param>
        private static CollapsedSumOperation CollapseExpression(Expression Input)
        {
            //If the input is a sum between two expressions:
            if (Input is Sum)
            {
                //Just collapse both halves of the expression and return them merged
                var CSO1 = CollapseExpression((Input as Sum).LeftExpression);
                var CSO2 = CollapseExpression((Input as Sum).RightExpression);
                return Merge(CSO1, CSO2);
            }

            //If the input is a difference between two expressions:
            if (Input is Difference)
            {
                //Collapse both halves of the expression, negate the second CSO, and return them merged
                var CSO1 = CollapseExpression((Input as Difference).LeftExpression);
                var CSO2 = CollapseExpression((Input as Difference).RightExpression).NegateTerms();
                return Merge(CSO1, CSO2);
            }

            //If the input is a negation of a sum or difference between two expressions:
            if (Propositions.IsNegationOfSumOrDifference[Input])
            {
                //Pull out the inner expression of the negation, recursively collapse it, and then return the negation of the collapsed CSO
                CollapsedSumOperation CSO;
                if ((Input as Product).LeftExpression == -1) CSO = CollapseExpression((Input as Product).RightExpression);
                else CSO = CollapseExpression((Input as Product).LeftExpression);
                return CSO.NegateTerms();
            }

            //If the input is none of the above, just create a new CSO with the input as an expression
            return new CollapsedSumOperation(Input);
        }

        /// <summary>
        /// Merges two collapsed sum operations together into a single collapsed sum operation.
        /// </summary>
        /// <param name="CSO1">The first collapsed sum operation to merge</param>
        /// <param name="CSO2">The second collapsed sum operation to merge</param>
        public static CollapsedSumOperation Merge(CollapsedSumOperation CSO1, CollapsedSumOperation CSO2)
        {
            return new CollapsedSumOperation(CSO1.ChildExpressions.Concat(CSO2.ChildExpressions).ToArray());
        }

        /// <summary>
        /// Returns a new collapsed sum operation equivalent to the source CSO with all of its terms negated.
        /// </summary>
        public CollapsedSumOperation NegateTerms()
        {
            List<Expression> NewChildren = new List<Expression>(this.ChildExpressions.Count);
            for(int i = 0; i < this.ChildExpressions.Count; i++)
            {
                NewChildren.Add(-this.ChildExpressions[i]);
            }
            NewChildren.Capacity = NewChildren.Count;
            return new CollapsedSumOperation(NewChildren.ToArray());
        }

        /// <summary>
        /// Tests the equality between two CSOs. Assumes associative and commutative rules.
        /// </summary>
        /// <param name="CSO1">The first CSO to test</param>
        /// <param name="CSO2">The second CSO to test</param>
        public static bool TestEquality(CollapsedSumOperation CSO1, CollapsedSumOperation CSO2)
        {
            //First, lets make sure our CSO's have the same number of terms (we will assume our CSOs are NOT reduced)
            if (CSO1.Arity != CSO2.Arity)
            {
                //If reducing our CSOs makes them have the same number of terms, test the reduced CSOs
                var CSO1r = CSO1.Reduce();
                var CSO2r = CSO2.Reduce();
                if (CSO1r.Arity == CSO2r.Arity) return TestEquality(CSO1r, CSO2r);
                else return false;
            }

            //We will use a dictionary object to store our records of matches (since sum operations can contain multiples of the same expression)
            //This makes it so that the test for {x, y, x, 1} == {x, y, z, 1} would not pass.
            Dictionary<int, int> IndexMatches = new Dictionary<int, int>(CSO1.ChildExpressions.Count);
            
            //For each item in the first CSO:
            for (int i = 0; i < CSO1.ChildExpressions.Count; i++)
            {
                //For each item in the second CSO:
                for (int j = 0; j < CSO2.ChildExpressions.Count; j++)
                {
                    //If these two expressions are equal:
                    if (CSO1.ChildExpressions[i] == CSO2.ChildExpressions[j])
                    {
                        //If the index of the expression in CSO2 has not been matched to something in CSO1 AND this index hasn't been matched to anything yet:
                        if (!IndexMatches.ContainsValue(j) && !IndexMatches.ContainsKey(i)) IndexMatches.Add(i, j);
                    }
                }

                //When we are done going through CSO2, if we didn't find a unique match, then return false
                if (!IndexMatches.ContainsKey(i)) return false;
            }

            //If we didn't find any conflicts, return true
            return true;
        }

        /// <summary>
        /// Returns a new collapsed sum operation equivalent to the source CSO with appropriate terms combined.
        /// </summary>
        public CollapsedSumOperation Reduce()
        {
            //Create a new list of expressions for our new terms
            List<Expression> NewChildren = new List<Expression>();

            //For each of our children:
            for (int i = 0; i < this.ChildExpressions.Count; i++)
            {
                //If this is the first item, just add it to the list:
                if (NewChildren.Count == 0)
                {
                    NewChildren.Add(this.ChildExpressions[i]);
                    continue;
                }

                //Othwerwise, search through the new list and see if we can combine with anything:
                bool foundmatch = false;
                for (int j = 0; j < NewChildren.Count; j++)
                {
                    //Add the terms together
                    var added = this.ChildExpressions[i] + NewChildren[j];
                    
                    //If we find a match (AKA adding them together makes something OTHER than returning their new sum):
                    if (added != new Sum(this.ChildExpressions[i], NewChildren[j]))
                    {
                        NewChildren[j] = added;
                        foundmatch = true;
                        break;
                    }
                }

                //If we couldn't find a match, add it to the list
                if (!foundmatch) NewChildren.Add(this.ChildExpressions[i]);
            }

            //Return the new list of expressions
            NewChildren.Capacity = NewChildren.Count;
            return new CollapsedSumOperation(NewChildren.ToArray());
        }

        /// <summary>
        /// Converts this collapsed sum operation into a normal mathematical expression.
        /// </summary>
        public Expression ToExpression()
        {
            //If we have zero or less terms, we have no idea what the hell is going on
            if (this.Arity <= 0) throw new Exceptions.SimplexMathException("Unable to convert collapsed sum operation to expression - invalid arity");

            //If we only have one term, just return that term
            if (this.Arity == 1) return this.ChildExpressions[0];

            //If we only have two terms, just return the sum of those two terms, unless the child is negated
            if (this.Arity == 2)
            {
                if (!Propositions.IsNegation[this.ChildExpressions[0]] && Propositions.IsNegation[this.ChildExpressions[1]]) return new Difference(this.ChildExpressions[0], -this.ChildExpressions[1]);
                if (Propositions.IsNegation[this.ChildExpressions[0]] && !Propositions.IsNegation[this.ChildExpressions[1]]) return new Difference(this.ChildExpressions[1], -this.ChildExpressions[0]);
                if (Propositions.IsNegation[this.ChildExpressions[0]] && Propositions.IsNegation[this.ChildExpressions[1]]) return new Negation(new Sum(-this.ChildExpressions[0], -this.ChildExpressions[1]));
                return new Sum(this.ChildExpressions[0], this.ChildExpressions[1]);
            }

            //Otherwise, if we have more than two terms, we will return a new sum of the first term
            //and the rest of the terms cast to a CSO which are converted back to an expression.
            var FirstTerm = this.ChildExpressions[0];
            var SecondTerm = new CollapsedSumOperation(this.ChildExpressions.GetRange(1, this.ChildExpressions.Count - 1).ToArray()).ToExpression();
            if (!Propositions.IsNegation[FirstTerm] && Propositions.IsNegation[SecondTerm]) return new Difference(FirstTerm, -SecondTerm);
            if (Propositions.IsNegation[FirstTerm] && !Propositions.IsNegation[SecondTerm]) return new Difference(SecondTerm, -FirstTerm);
            if (Propositions.IsNegation[FirstTerm] && Propositions.IsNegation[SecondTerm]) return new Negation(new Sum(-FirstTerm, -SecondTerm));
            return new Sum(FirstTerm, SecondTerm);
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            string BuildString = "(" + this.ChildExpressions[0].ToString(Format, VariableFormat, ConstantFormat);
            for (int i = 1; i < this.ChildExpressions.Count; i++)
            {
                BuildString += " + " + this.ChildExpressions[i].ToString(Format, VariableFormat, ConstantFormat);
            }
            return BuildString + ")";
        }
    }
}
