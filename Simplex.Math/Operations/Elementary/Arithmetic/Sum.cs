using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Classification;
using Simplex.Math.Core;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents the addition of two expressions.
    /// </summary>
    public class Sum : ArithmeticOperation
    {
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
            //Do some stuff

            //If we can't combine anything, just create a new object
            return new Sum(E1, E2);
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
    }
}
