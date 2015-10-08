using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;

namespace Simplex.Math.Operations.Elementary
{
    public class Difference : ArithmeticOperation
    {
        /// <summary>
        /// Creates a new difference from a given left and right expression.
        /// </summary>
        /// <param name="LeftExpression">The expression associated with the left side of the operation</param>
        /// <param name="RightExpression">The expression associated with the right side of the operation</param>
        public Difference(Expression LeftExpression, Expression RightExpression)
        {
            throw new System.NotImplementedException();
        }

        public Expression LeftExpression
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Expression RightExpression
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public static Expression Subtract(Expression E1, Expression E2)
        {
            throw new System.NotImplementedException();
        }
    }
}
