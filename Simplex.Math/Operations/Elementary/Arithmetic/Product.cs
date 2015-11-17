using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Logic;
using Simplex.Math.Irreducibles;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents the multiplication of two expressions.
    /// </summary>
    public class Product : ArithmeticOperation
    {
        /// <summary>
        /// Creates a new product from a given left and right expression.
        /// </summary>
        /// <param name="LeftExpression">The expression associated with the left side of the operation</param>
        /// <param name="RightExpression">The expression associated with the right side of the operation</param>
        public Product(Expression LeftExpression, Expression RightExpression) : base(Logic.Rules.ProductRules, LeftExpression, RightExpression, true, false, true)
        {
            
        }

        /// <summary>
        /// The mathematical expression corresponding to the left side of this product.
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
        /// The mathematical expression corresponding to the right side of this product.
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
        /// Computes the symbolic multiplication between two expressions.
        /// </summary>
        /// <param name="E1">The first expression</param>
        /// <param name="E2">The second expression</param>
        public static Expression Multiply(Expression E1, Expression E2)
        {
            var O = new Product(E1, E2);
            if (O.CanTransform()) return O.Apply(true);
            else return O;
        }

        /// <summary>
        /// Makes a copy of this operation.
        /// </summary>
        public override Expression Copy()
        {
            return new Product(this.LeftExpression.Copy(), this.RightExpression.Copy());
        }

        /// <summary>
        /// Whether this product represents a negation.
        /// </summary>
        public bool IsNegation()
        {
            return (this.LeftExpression == -1 || this.RightExpression == -1);
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {

            string LS = this.LeftExpression.ToString(Format, VariableFormat, ConstantFormat);
            string RS = this.RightExpression.ToString(Format, VariableFormat, ConstantFormat);

            if (Format == ExpressionStringFormat.Default)
            {
                //Special Formats
                if ((this.LeftExpression is Value) && (this.LeftExpression as Value).InnerValue == -1) return "-" + RS;
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).InnerValue == -1) return "-" + LS;
                else if ((this.LeftExpression is Value) && (this.LeftExpression as Value).IsInteger() && (this.RightExpression is Constant)) return LS + RS;
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).IsInteger() && (this.LeftExpression is Constant)) return RS + LS;
                else if ((this.LeftExpression is Value) && (this.LeftExpression as Value).IsInteger() && (this.RightExpression is Exponentiation)) return LS + RS;
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).IsInteger() && (this.LeftExpression is Exponentiation)) return RS + LS;
                else if ((this.LeftExpression is Value) && (this.LeftExpression as Value).IsInteger() && (this.RightExpression is Sum)) return LS + "(" + RS + ")";
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).IsInteger() && (this.LeftExpression is Sum)) return RS + "(" + LS + ")";
                else if ((this.LeftExpression is Value) && (this.LeftExpression as Value).IsInteger() && (this.RightExpression is Difference)) return LS + "(" + RS + ")";
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).IsInteger() && (this.LeftExpression is Difference)) return RS + "(" + LS + ")";
                else if ((this.LeftExpression is Value) && (this.LeftExpression as Value).IsInteger() && !(this.RightExpression is Value)) return LS + RS;
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).IsInteger() && !(this.LeftExpression is Value)) return RS + LS;
                //else if (!(this.LeftExpression is Value) && !(this.RightExpression is Value)) return LS + RS;

                //Otherwise, just return the default:
                return LS + " * " + RS;
            }
            else if (Format == ExpressionStringFormat.LaTeX)
            {
                //Special Formats
                if ((this.LeftExpression is Value) && (this.LeftExpression as Value).InnerValue == -1) return "-" + RS;
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).InnerValue == -1) return "-" + LS;
                else if ((this.LeftExpression is Value) && (this.LeftExpression as Value).IsInteger() && (this.RightExpression is Variable)) return LS + RS;
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).IsInteger() && (this.LeftExpression is Variable)) return RS + LS;
                else if ((this.LeftExpression is Value) && (this.LeftExpression as Value).IsInteger() && (this.RightExpression is Constant)) return LS + RS;
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).IsInteger() && (this.LeftExpression is Constant)) return RS + LS;
                else if ((this.LeftExpression is Value) && (this.LeftExpression as Value).IsInteger() && (this.RightExpression is Exponentiation)) return LS + RS;
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).IsInteger() && (this.LeftExpression is Exponentiation)) return RS + LS;

                //Otherwise, just return the default:
                return LS + @" \times " + RS;
            }
            else if (Format == ExpressionStringFormat.ParseFriendly)
            {
                if ((this.LeftExpression is Value) && (this.LeftExpression as Value).InnerValue == -1) return "-(" + RS + ")";
                else if ((this.RightExpression is Value) && (this.RightExpression as Value).InnerValue == -1) return "-(" + LS + ")";
                return "(" + LS + " * " + RS + ")";
            }
            else
            {
                throw new Exceptions.ExpressionParsingException("Unable to convert product to string - Invalid ExpressionStringConstantFormat");
            }
        }
    }
}
