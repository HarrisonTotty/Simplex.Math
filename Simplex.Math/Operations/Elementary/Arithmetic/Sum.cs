using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;

namespace Simplex.Math.Operations.Elementary
{
    public class Sum : ArithmeticOperation
    {
        /// <summary>
        /// Creates a new sum from a given left and right expression.
        /// </summary>
        /// <param name="LeftExpression">The expression associated with the left side of the operation</param>
        /// <param name="RightExpression">The expression associated with the right side of the operation</param>
        public Sum(Expression LeftExpression, Expression RightExpression)
        {
            throw new System.NotImplementedException();
        }

        public int LeftExpression
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int RightExpression
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public static Expression Add(Expression E1, Expression E2)
        {
            //Do some stuff

            //If we can't combine anything, just create a new object
            return new Sum(E1, E2);
        }
    }
}
