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
    /// An alternative tree representation for a sequence of elements attached by a common product operation (see remarks).
    /// </summary>
    /// <remarks>
    /// A collapsed product operation will also automatically convert quotients to products.
    /// Example: (x / y) will be converted to (x * y^-1)
    /// </remarks>
    public class CollapsedProductOperation : CollapsedBinaryOperation
    {
        /// <summary>
        /// Creates a new collapsed product operation from a sequence of operands.
        /// </summary>
        /// <param name="Operands">The expressions contained within this collapsed product</param>
        public CollapsedProductOperation(params Expression[] Operands) : base(Operands)
        {

        }

        /// <summary>
        /// Creates a new collapsed product operation from a given expression.
        /// Requires the input expression to be either a product or quotient.
        /// </summary>
        /// <param name="Input">The product/quotient expression to collapse</param>
        public static CollapsedProductOperation Create(Expression Input)
        {
            //Make sure that we are something we can collapse
            if (!(Propositions.IsProductOrQuotient[Input] || Propositions.IsNegativeOneExponentiationOfProductOrQuotient[Input])) throw new Exceptions.SimplexMathException("Cannot create collapsed product operation - input is not a product, quotient, or a -1th exponentiation of either");
            return CollapseExpression(Input);
        }

        /// <summary>
        /// Recursively collapses an expression into a CPO.
        /// </summary>
        /// <param name="Input">The expression to collapse</param>
        private static CollapsedProductOperation CollapseExpression(Expression Input)
        {
            //If the input is a product between two expressions:
            if (Input is Product)
            {
                //Just collapse both halves of the expression and return them merged
                var CPO1 = CollapseExpression((Input as Product).LeftExpression);
                var CPO2 = CollapseExpression((Input as Product).RightExpression);
                return Merge(CPO1, CPO2);
            }

            //If the input is a quotient between two expressions:
            if (Input is Quotient)
            {
                //Collapse both halves of the expression, invert the second CPO, and return them merged
                var CPO1 = CollapseExpression((Input as Quotient).Numerator);
                var CPO2 = CollapseExpression((Input as Quotient).Denominator).InvertTerms();
                return Merge(CPO1, CPO2);
            }

            //If the input is a negative exponentiation of a product or quotient between two expressions:
            if (Propositions.IsNegativeOneExponentiationOfProductOrQuotient[Input])
            {
                //Pull out the inner expression of the exponentiation, recursively collapse it, and then return the inverse of the collapsed CPO
                return CollapseExpression((Input as Exponentiation).Base).InvertTerms();
            }

            //If the input is none of the above, just create a new CPO with the input as an expression
            return new CollapsedProductOperation(Input);
        }

        /// <summary>
        /// Merges two collapsed product operations together into a single collapsed product operation.
        /// </summary>
        /// <param name="CPO1">The first collapsed product operation to merge</param>
        /// <param name="CPO2">The second collapsed product operation to merge</param>
        public static CollapsedProductOperation Merge(CollapsedProductOperation CPO1, CollapsedProductOperation CPO2)
        {
            return new CollapsedProductOperation(CPO1.ChildExpressions.Concat(CPO2.ChildExpressions).ToArray());
        }

        /// <summary>
        /// Returns a new collapsed product operation equivalent to the source CPO with all of its terms inverted by raising to the -1th power.
        /// </summary>
        /// <remarks>
        /// (x + y) => (x + y)^-1
        /// Because "x / y" is the same as "x * y^-1"
        /// </remarks>
        public CollapsedProductOperation InvertTerms()
        {
            List<Expression> NewChildren = new List<Expression>(this.ChildExpressions.Count);
            for (int i = 0; i < this.ChildExpressions.Count; i++)
            {
                NewChildren.Add(new Exponentiation(this.ChildExpressions[i], -1));
            }
            NewChildren.Capacity = NewChildren.Count;
            return new CollapsedProductOperation(NewChildren.ToArray());
        }

        /// <summary>
        /// Returns a new collapsed product operation equivalent to the source CPO with appropriate terms combined.
        /// </summary>
        public CollapsedProductOperation Reduce()
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
                    //Multiply the terms together
                    var mul = this.ChildExpressions[i] * NewChildren[j];

                    //If we find a match (AKA multiplying them together makes something OTHER than returning their new product):
                    if (!mul.IsIdenticalTo(new Product(this.ChildExpressions[i], NewChildren[j])))
                    {
                        NewChildren[j] = mul;
                        foundmatch = true;
                        break;
                    }
                }

                //If we couldn't find a match, add it to the list
                if (!foundmatch) NewChildren.Add(this.ChildExpressions[i]);
            }

            //Return the new list of expressions
            NewChildren.Capacity = NewChildren.Count;
            return new CollapsedProductOperation(NewChildren.ToArray());
        }

        /// <summary>
        /// Tests the equality between two CPOs. Assumes associative and commutative rules.
        /// </summary>
        /// <param name="CPO1">The first CPO to test</param>
        /// <param name="CPO2">The second CPO to test</param>
        public static bool TestEquality(CollapsedProductOperation CPO1, CollapsedProductOperation CPO2)
        {
            //First, lets make sure our CPO's have the same number of terms (we will assume our CPOs are NOT reduced)
            if (CPO1.Arity != CPO2.Arity)
            {
                //If reducing our CPOs makes them have the same number of terms, test the reduced CPOs
                var CPO1r = CPO1.Reduce();
                var CPO2r = CPO2.Reduce();
                if (CPO1r.Arity == CPO2r.Arity) return TestEquality(CPO1r, CPO2r);
                else return false;
            }

            //We will use a dictionary object to store our records of matches (since product operations can contain multiples of the same expression)
            //This makes it so that the test for {x, y, x, 1} == {x, y, z, 1} would not pass.
            Dictionary<int, int> IndexMatches = new Dictionary<int, int>(CPO1.ChildExpressions.Count);

            //For each item in the first CPO:
            for (int i = 0; i < CPO1.ChildExpressions.Count; i++)
            {
                //For each item in the second CPO:
                for (int j = 0; j < CPO2.ChildExpressions.Count; j++)
                {
                    //If these two expressions are equal:
                    if (CPO1.ChildExpressions[i] == CPO2.ChildExpressions[j])
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
        /// Converts this collapsed product operation into a normal mathematical expression.
        /// </summary>
        public Expression ToExpression()
        {
            //If we have zero or less terms, we have no idea what the hell is going on
            if (this.Arity <= 0) throw new Exceptions.SimplexMathException("Unable to convert collapsed product operation to expression - invalid arity");

            //If we only have one term, just return that term
            if (this.Arity == 1) return this.ChildExpressions[0];

            //If we only have two terms, just return the product of those two terms
            if (this.Arity == 2)
            {
                if (!Propositions.IsNonValueInverse[this.ChildExpressions[0]] && Propositions.IsNonValueInverse[this.ChildExpressions[1]]) return (this.ChildExpressions[0] / (1 / this.ChildExpressions[1]));
                if (Propositions.IsNonValueInverse[this.ChildExpressions[0]] && !Propositions.IsNonValueInverse[this.ChildExpressions[1]]) return (this.ChildExpressions[1] / (1 / this.ChildExpressions[0]));
                if (Propositions.IsNonValueInverse[this.ChildExpressions[0]] && Propositions.IsNonValueInverse[this.ChildExpressions[1]]) return 1 / ((1 / this.ChildExpressions[0]) * (1 / this.ChildExpressions[1]));
                return (this.ChildExpressions[0] * this.ChildExpressions[1]);
            }

            //Otherwise, if we have more than two terms, we will return a new product of the first term
            //and the rest of the terms cast to a CPO which are converted back to an expression.
            var FirstTerm = this.ChildExpressions[0];
            var SecondTerm = new CollapsedProductOperation(this.ChildExpressions.GetRange(1, this.ChildExpressions.Count - 1).ToArray()).ToExpression();
            if (!Propositions.IsNonValueInverse[FirstTerm] && Propositions.IsNonValueInverse[SecondTerm]) return (FirstTerm / (1 / SecondTerm));
            if (Propositions.IsNonValueInverse[FirstTerm] && !Propositions.IsNonValueInverse[SecondTerm]) return (SecondTerm / (1 / FirstTerm));
            if (Propositions.IsNonValueInverse[FirstTerm] && Propositions.IsNonValueInverse[SecondTerm]) return 1 / ((1 / FirstTerm) * (1 / SecondTerm));
            return new Product(FirstTerm, SecondTerm);
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            string BuildString = "(" + this.ChildExpressions[0].ToString(Format, VariableFormat, ConstantFormat);
            for (int i = 1; i < this.ChildExpressions.Count; i++)
            {
                BuildString += " * " + this.ChildExpressions[i].ToString(Format, VariableFormat, ConstantFormat);
            }
            return BuildString + ")";
        }
    }
}
