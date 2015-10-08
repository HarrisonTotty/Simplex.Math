using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;

namespace Simplex.Math.Operations.Elementary
{
    public class Quotient : ArithmeticOperation
    {
        /// <summary>
        /// Creates a new quotient from a given left and right expression.
        /// </summary>
        /// <param name="Numerator">The expression associated with the left side of the operation</param>
        /// <param name="Denominator">The expression associated with the right side of the operation</param>
        public Quotient(Expression Numerator, Expression Denominator)
        {
            throw new System.NotImplementedException();
        }

        public int Numerator
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int Denominator
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public static Expression Divide(Expression Numerator, Expression Denominator)
        {
            throw new System.NotImplementedException();
        }
    }
}
