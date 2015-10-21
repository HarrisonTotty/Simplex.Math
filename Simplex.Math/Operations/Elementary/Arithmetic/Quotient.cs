using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Operands;

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
        public Quotient(Expression Numerator, Expression Denominator) : base(Numerator, Denominator, false, false, false)
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
            //If we can't combine anything, just create a new object
            return new Quotient(Numerator, Denominator);
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
            return this.Numerator.ToString(Format, VariableFormat, ConstantFormat) + " / " + this.Denominator.ToString(Format, VariableFormat, ConstantFormat);
        }

        /// <summary>
        /// Returns whether this expression represents a coefficient (see remarks).
        /// </summary>
        /// <remarks>
        /// 3
        /// C
        /// 3C
        /// 3CK
        /// 3/(Ck)
        /// Are all coefficients
        /// </remarks>
        public bool IsCoefficient()
        {
            //Constants and values
            if (this.Operands[0] is Constant && this.Operands[1] is Constant) return true;
            if (this.Operands[0] is Constant && this.Operands[1] is Value) return true;
            if (this.Operands[0] is Value && this.Operands[1] is Constant) return true;
            if (this.Operands[0] is Value && this.Operands[1] is Value) return true;
            //Products and constants/values
            if (this.Operands[0] is Constant && (this.Operands[1] is Product && (this.Operands[1] as Product).IsCoefficient())) return true;
            if (this.Operands[0] is Value && (this.Operands[1] is Product && (this.Operands[1] as Product).IsCoefficient())) return true;
            if ((this.Operands[0] is Product && (this.Operands[0] as Product).IsCoefficient()) && this.Operands[1] is Constant) return true;
            if ((this.Operands[0] is Product && (this.Operands[0] as Product).IsCoefficient()) && this.Operands[1] is Value) return true;
            if ((this.Operands[0] is Product && (this.Operands[0] as Product).IsCoefficient()) && (this.Operands[1] is Product && (this.Operands[1] as Product).IsCoefficient())) return true;
            //Quotients and constants/values
            if (this.Operands[0] is Constant && (this.Operands[1] is Quotient && (this.Operands[1] as Quotient).IsCoefficient())) return true;
            if (this.Operands[0] is Value && (this.Operands[1] is Quotient && (this.Operands[1] as Quotient).IsCoefficient())) return true;
            if ((this.Operands[0] is Quotient && (this.Operands[0] as Quotient).IsCoefficient()) && this.Operands[1] is Constant) return true;
            if ((this.Operands[0] is Quotient && (this.Operands[0] as Quotient).IsCoefficient()) && this.Operands[1] is Value) return true;
            if ((this.Operands[0] is Quotient && (this.Operands[0] as Quotient).IsCoefficient()) && (this.Operands[1] is Quotient && (this.Operands[1] as Quotient).IsCoefficient())) return true;
            //Quotients and products
            if ((this.Operands[0] is Quotient && (this.Operands[0] as Quotient).IsCoefficient()) && (this.Operands[1] is Product && (this.Operands[1] as Product).IsCoefficient())) return true;
            if ((this.Operands[0] is Product && (this.Operands[0] as Product).IsCoefficient()) && (this.Operands[1] is Quotient && (this.Operands[1] as Quotient).IsCoefficient())) return true;

            return false;
        }
    }
}
