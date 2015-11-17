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
    /// Represents the division of two expressions.
    /// </summary>
    public class Quotient : ArithmeticOperation
    {
        /// <summary>
        /// Creates a new quotient from a given numerator and denominator.
        /// </summary>
        /// <param name="Numerator">The expression associated with the numerator of the operation</param>
        /// <param name="Denominator">The expression associated with the denominator of the operation</param>
        public Quotient(Expression Numerator, Expression Denominator) : base(Logic.Rules.QuotientRules, Numerator, Denominator, false, false, false)
        {
            
        }

        /// <summary>
        /// The mathematical expression corresponding to the numerator of this quotient.
        /// </summary>
        public Expression Numerator
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
        /// The mathematical expression corresponding to the denominator of this quotient.
        /// </summary>
        public Expression Denominator
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
        /// Computes the symbolic division between two expressions.
        /// </summary>
        /// <param name="Numerator">The numerator expression</param>
        /// <param name="Denominator">The denominator expression</param>
        public static Expression Divide(Expression Numerator, Expression Denominator)
        {
            var O = new Quotient(Numerator, Denominator);
            if (O.CanTransform()) return O.Apply(true);
            else return O;
        }

        /// <summary>
        /// Makes a copy of this operation.
        /// </summary>
        public override Expression Copy()
        {
            return new Quotient(this.Numerator.Copy(), this.Denominator.Copy());
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            string N = this.Numerator.ToString(Format, VariableFormat, ConstantFormat);
            string D = this.Denominator.ToString(Format, VariableFormat, ConstantFormat);

            if (Format == ExpressionStringFormat.Default)
            {
                return N + " / " + D;
            }
            else if (Format == ExpressionStringFormat.LaTeX)
            {
                return @"\frac{" + N + "}{" + D + "}";
            }
            else if (Format == ExpressionStringFormat.ParseFriendly)
            {
                return "(" + N + " / " + D + ")";
            }
            else
            {
                throw new Exceptions.ExpressionParsingException("Unable to convert product to string - Invalid ExpressionStringConstantFormat");
            }
        }
    }
}
