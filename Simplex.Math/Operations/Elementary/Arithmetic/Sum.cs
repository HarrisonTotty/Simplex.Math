using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Classification;
using Simplex.Math.Core;
using Simplex.Math.Logic;
using Simplex.Math.Operands;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents the addition of two expressions.
    /// </summary>
    public class Sum : ArithmeticOperation
    {
        /// <summary>
        /// The rule set associated with sums.
        /// </summary>
        public static RuleSet Rules = new RuleSet(Logic.Rules.Sum);

        /// <summary>
        /// Creates a new sum from a given left and right expression.
        /// </summary>
        /// <param name="LeftExpression">The expression associated with the left side of the operation</param>
        /// <param name="RightExpression">The expression associated with the right side of the operation</param>
        public Sum(Expression LeftExpression, Expression RightExpression) : base(LeftExpression, RightExpression, true, false, true)
        {
            
        }

        /// <summary>
        /// The mathematical expression corresponding to the left side of this sum.
        /// </summary>
        public Expression LeftExpression
        {
            get
            {
                return this.Operands[0];
            }

            set
            {
                this.Operands[0] = value;
            }
        }

        /// <summary>
        /// The mathematical expression corresponding to the right side of this sum.
        /// </summary>
        public Expression RightExpression
        {
            get
            {
                return this.Operands[1];
            }

            set
            {
                this.Operands[1] = value;
            }
        }

        /// <summary>
        /// Computes the symbolic addition between two expressions.
        /// </summary>
        /// <param name="E1">The first expression</param>
        /// <param name="E2">The second expression</param>
        public static Expression Add(Expression E1, Expression E2)
        {
            //If we qualify for transform via our ruleset:
            if (Sum.Rules.CanTransform(E1, E2))
            {
                //Apply our rules to the input
                return Sum.Rules.Apply(E1, E2);
            }

            //If we can't combine anything, just create a new object
            return new Sum(E1, E2);
        }

        /// <summary>
        /// Computes the addition of an array of expressions by combining like terms.
        /// </summary>
        /// <param name="Expressions">The expressions to add</param>
        public static Expression SelectionAdd(params Expression[] Expressions)
        {
            Expression NE = 0;
            //If we can't combine anything, just add them all up
            foreach(Expression E in Expressions)
            {
                NE += E;
            }
            return NE;
        }

        /// <summary>
        /// Makes a copy of this operation.
        /// </summary>
        public override Expression Copy()
        {
            return new Sum(this.LeftExpression.Copy(), this.RightExpression.Copy());
        }

        /// <summary>
        /// Classifies this expression into a particular category of expressions.
        /// </summary>
        public override ClassifiedExpression[] Classify()
        {
            
            return base.Classify();
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            string L = this.LeftExpression.ToString(Format, VariableFormat, ConstantFormat);
            string R = this.RightExpression.ToString(Format, VariableFormat, ConstantFormat);
            if (Format == ExpressionStringFormat.ParseFriendly) return "(" + L + " + " + R + ")";
            return L + " + " + R;
        }
    }
}
