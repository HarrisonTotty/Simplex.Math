using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Operands;
using Simplex.Math.Logic;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents the symbolic exponentiation of a particular base to a particular exponent.
    /// </summary>
    public class Exponentiation : ElementaryOperation
    {
        /// <summary>
        /// Creates a new exponentiation expression from a given base and exponent.
        /// </summary>
        /// <param name="Base">The base of this exponentiation</param>
        /// <param name="Exponent">The exponent of this exponentiation</param>
        public Exponentiation(Expression Base, Expression Exponent) : base(Base, Exponent, false, false, false)
        {
            
        }


        /// <summary>
        /// The base expression of this exponentiation.
        /// </summary>
        public Expression Base
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
        /// The exponent expression of this exponentiation.
        /// </summary>
        public Expression Exponent
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
        /// Exponentiates an expression by a power given by another expression.
        /// </summary>
        /// <param name="Base">The base of the exponentiation</param>
        /// <param name="Exponent">The exponent of the exponentiation</param>
        public static Expression Exponentiate(Expression Base, Expression Exponent)
        {
            //If we can't figure out what to do:
            return new Exponentiation(Base, Exponent);
        }

        public bool IsIntegerExponent()
        {
            return (this.Exponent is Integer);
        }

        public bool IsPositiveIntegerExponent()
        {
            return this.IsIntegerExponent() && ((this.Exponent as Integer) > 0);
        }

        public bool IsNegativeIntegerExponent()
        {
            return this.IsIntegerExponent() && ((this.Exponent as Integer) < 0);
        }

        public bool IsZeroIntegerExponent()
        {
            return this.IsIntegerExponent() && ((this.Exponent as Integer) == 0);
        }
    }
}
