using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Irreducibles;
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
        public Exponentiation(Expression Base, Expression Exponent) : base(Logic.Rules.ExponentiationRules, Base, Exponent, false, false, false)
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
            var O = new Exponentiation(Base, Exponent);
            if (O.CanTransform()) return O.Apply(true);
            else return O;
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

        public bool IsInverse()
        {
            return this.IsIntegerExponent() && ((this.Exponent as Integer) == -1);
        }

        public bool IsZeroIntegerExponent()
        {
            return this.IsIntegerExponent() && ((this.Exponent as Integer) == 0);
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            string B = this.Base.ToString(Format, VariableFormat, ConstantFormat);
            string E = this.Exponent.ToString(Format, VariableFormat, ConstantFormat);

            if (Format == ExpressionStringFormat.Default)
            {
                return B + "^" + E;
            }
            else if (Format == ExpressionStringFormat.LaTeX)
            {
                return B + "^{" + E + "}";
            }
            else if (Format == ExpressionStringFormat.ParseFriendly)
            {
                return "(" + B + " ^ " + E + ")";
            }
            else
            {
                throw new Exceptions.ExpressionParsingException("Unable to convert exponentiation to string - Invalid ExpressionStringFormat");
            }
        }

        public override Expression Copy()
        {
            return new Exponentiation(this.Base.Copy(), this.Exponent.Copy());
        }
    }
}
