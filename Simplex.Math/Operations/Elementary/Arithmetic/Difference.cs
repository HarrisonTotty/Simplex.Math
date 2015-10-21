using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents the subtraction of two expressions.
    /// </summary>
    public class Difference : ArithmeticOperation
    {
        /// <summary>
        /// Creates a new difference between two different mathematical expressions
        /// </summary>
        /// <param name="LeftExpression">The expression to the left side of this operator</param>
        /// <param name="RightExpression">The expression to the right side of this operator</param>
        public Difference(Expression LeftExpression, Expression RightExpression) : base(LeftExpression, RightExpression, false, true, false)
        {

        }

        /// <summary>
        /// The mathematical expression corresponding to the left side of this difference.
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
        /// The mathematical expression corresponding to the right side of this difference.
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
        /// Computes the symbolic subtraction between two expressions.
        /// </summary>
        /// <param name="E1">The first expression</param>
        /// <param name="E2">The second expression</param>
        public static Expression Subtract(Expression E1, Expression E2)
        {
            //If we can't combine anything, just create a new object
            return new Difference(E1, E2);
        }

        /// <summary>
        /// Makes a copy of this operation.
        /// </summary>
        public override Expression Copy()
        {
            return new Difference(this.LeftExpression.Copy(), this.RightExpression.Copy());
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            return this.LeftExpression.ToString(Format, VariableFormat, ConstantFormat) + " - " + this.RightExpression.ToString(Format, VariableFormat, ConstantFormat);
        }
    }
}
