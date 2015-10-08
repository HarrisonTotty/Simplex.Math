using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Operands;
using Simplex.Math.Operations;
using Simplex.Math.Operations.Elementary;

namespace Simplex.Math.Core
{
    /// <summary>
    /// Represents a symbolic mathematical expression.
    /// </summary>
    /// <remarks>
    /// Expressions can represent anything from:
    /// Descrete values such as "2", "3.4", or "1/2"
    /// Variables such as "x" or "mass"
    /// Mathematical operations such as "2 + 2" or "Sin(x)"
    /// Array types such as vectors and tensors
    /// </remarks>
    public abstract class Expression
    {
        //The following operators are overloaded between a math expression and a number
        public static Expression operator +(Expression I1, double I2) { return Sum.Add(I1, new Value(I2)); }
        public static Expression operator -(Expression I1, double I2) { return Difference.Subtract(I1, new Value(I2)); }
        public static Expression operator *(Expression I1, double I2) { return Product.Multiply(I1, new Value(I2)); }
        public static Expression operator /(Expression I1, double I2) { return Quotient.Divide(I1, new Value(I2)); }
        public static Expression operator ^(Expression I1, double I2) { return Exponentiation.Exponentiate(I1, new Value(I2)); }
        public static Expression operator +(Expression I1, int I2) { return Sum.Add(I1, new Value(I2)); }
        public static Expression operator -(Expression I1, int I2) { return Difference.Subtract(I1, new Value(I2)); }
        public static Expression operator *(Expression I1, int I2) { return Product.Multiply(I1, new Value(I2)); }
        public static Expression operator /(Expression I1, int I2) { return Quotient.Divide(I1, new Value(I2)); }
        public static Expression operator ^(Expression I1, int I2) { return Exponentiation.Exponentiate(I1, new Value(I2)); }
        public static Expression operator +(double I1, Expression I2) { return Sum.Add(new Value(I1), I2); }
        public static Expression operator -(double I1, Expression I2) { return Difference.Subtract(new Value(I1), I2); }
        public static Expression operator *(double I1, Expression I2) { return Product.Multiply(new Value(I1), I2); }
        public static Expression operator /(double I1, Expression I2) { return Quotient.Divide(new Value(I1), I2); }
        public static Expression operator ^(double I1, Expression I2) { return Exponentiation.Exponentiate(new Value(I1), I2); }
        public static Expression operator +(int I1, Expression I2) { return Sum.Add(new Value(I1), I2); }
        public static Expression operator -(int I1, Expression I2) { return Difference.Subtract(new Value(I1), I2); }
        public static Expression operator *(int I1, Expression I2) { return Product.Multiply(new Value(I1), I2); }
        public static Expression operator /(int I1, Expression I2) { return Quotient.Divide(new Value(I1), I2); }
        public static Expression operator ^(int I1, Expression I2) { return Exponentiation.Exponentiate(new Value(I1), I2); }
        public static bool operator ==(Expression I1, int I2) { return (I1 == (new Value(I2))); }
        public static bool operator !=(Expression I1, int I2) { return (I1 != (new Value(I2))); }
        public static bool operator ==(Expression I1, double I2) { return (I1 == (new Value(I2))); }
        public static bool operator !=(Expression I1, double I2) { return (I1 != (new Value(I2))); }
        public static bool operator ==(int I1, Expression I2) { return ((new Value(I1)) == I2); }
        public static bool operator !=(int I1, Expression I2) { return ((new Value(I1)) != I2); }
        public static bool operator ==(double I1, Expression I2) { return ((new Value(I1)) == I2); }
        public static bool operator !=(double I1, Expression I2) { return ((new Value(I1)) != I2); }


        //The following operators allow you to make statements such as "Value x = 10;"
        public static implicit operator Expression(double D) { return new Value(D); }
        public static implicit operator Expression(int I) { return new Value(I); }


        //The following operators allow a mathematical expression to be cast to a "int" or "double"
        public static explicit operator int (Expression E)
        {
            if (E is Value) return (int)(E as Value);
            else if (E is Constant) return (int)(E as Constant);

            throw new Exception("Cannot explicitly cast mathematical expression to type \"int\"!");
        }
        public static explicit operator double (Expression E)
        {
            if (E is Value) return (double)(E as Value);
            else if (E is Constant) return (double)(E as Constant);

            throw new Exception("Cannot explicitly cast mathematical expression to type \"double\"!");
        }


        //The following operators are overloaded between math expressions:
        /// <summary>
        /// Negates a mathematical operation (multiplies by -1).
        /// </summary>
        public static Expression operator -(Expression I1) { return Product.Multiply(new Value(-1), I1); }
        /// <summary>
        /// Computes the symbolic addition between two mathematical expressions.
        /// </summary>
        public static Expression operator +(Expression I1, Expression I2) { return Sum.Add(I1, I2); }
        /// <summary>
        /// Computes the symbolic subtraction between two mathematical expressions.
        /// </summary>
        public static Expression operator -(Expression I1, Expression I2) { return Difference.Subtract(I1, I2); }
        /// <summary>
        /// Computes the symbolic multiplication between two mathematical expressions.
        /// </summary>
        public static Expression operator *(Expression I1, Expression I2) { return Product.Multiply(I1, I2); }
        /// <summary>
        /// Computes the symbolic division between two mathematical expressions.
        /// </summary>
        public static Expression operator /(Expression I1, Expression I2) { return Quotient.Divide(I1, I2); }
        /// <summary>
        /// Computes the symbolic exponentiation between two mathematical expressions.
        /// </summary>
        public static Expression operator ^(Expression I1, Expression I2) { return Exponentiation.Exponentiate(I1, I2); }

        /// <summary>
        /// Evalutates whether two mathematical expressions are symbolically different (without evalutating variables).
        /// </summary>
        /// <param name="I1">The first expression</param>
        /// <param name="I2">The second expression</param>
        public static bool operator !=(Expression I1, Expression I2) { return !(I1 == I2); }

        /// <summary>
        /// Evalutates whether two mathematical expressions are symbolically equal (without evalutating variables).
        /// </summary>
        /// <param name="I1">The first expression</param>
        /// <param name="I2">The second expression</param>
        public static bool operator ==(Expression I1, Expression I2)
        {
            if ((I1 as object) == null && (I2 as object) == null) return true;
            if ((I1 as object) == null || (I2 as object) == null) return false;

            return (I1.IsEqualTo(I2));
        }

        /// <summary>
        /// Converts an expression into its generic form (see "Expression.ToGenericForm()" method)
        /// </summary>
        /// <param name="E">The expression to convert to generic form</param>
        public static Expression operator ~(Expression E)
        {
            if (E == null) throw new Exceptions.SimplificationException("Unable to convert expression to generic form - input expression is null");
            return E.ToGenericForm();
        }

        /// <summary>
        /// Obtains the default string representation of this mathematical expression.
        /// </summary>
        /// <remarks>
        /// Note that this converts the expression to a "nice" string, not a C# equivalent.
        /// For example:
        /// (((2 * y) + x) + 4)
        /// Will be returned as:
        /// 2y + x + 4
        /// </remarks>
        public override string ToString() { return this.ToString(ExpressionStringFormat.Default); }

        /// <summary>
        /// Obtains the string representation of this mathematical expression with a particular output format.
        /// </summary>
        /// <param name="Format">The general format to use for the output</param>
        public virtual string ToString(ExpressionStringFormat Format) { return this.ToString(Format, ExpressionStringVariableFormat.Default, ExpressionStringConstantFormat.Default); }

        /// <summary>
        /// Obtains the string representation of this mathematical expression with specific formatting options.
        /// </summary>
        /// <param name="Format">The general format to use for the output</param>
        /// <param name="VariableFormat">The format to use for variables in the output</param>
        /// <param name="ConstantFormat">The format to use for constants and values in the output</param>
        public virtual string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat) { return "UNKNOWN EXPRESSION REPRESENTATION"; }

        /// <summary>
        /// Converts the string representation of an expression into an expression assuming the default expression string format.
        /// </summary>
        /// <param name="Input">The string to parse</param>
        public static Expression Parse(string Input)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines if two expressions are symbolically equivalent.
        /// </summary>
        /// <remarks>
        /// For Example:
        /// 3 + 3  and  6  are equal
        /// 3(x + y)  and  3x + 3y  are equal
        /// </remarks>
        /// <param name="Comparison">The expression to compare to this expression</param>
        public virtual bool IsEqualTo(Expression Comparison)
        {
            return false;
        }

        /// <summary>
        /// Determines if this expression is identical to another expression.
        /// </summary>
        /// <remarks>
        /// Here the expressions have to be absolutely identical (tree representations may vary slightly).
        /// For Example: 
        /// 3(x + y)  and  3x + 3y  ARE NOT "identical"
        /// ((3 * x) + (3 * y)) + 4  and  (3 * x) + ((3 * y) + 4)  ARE identitcal
        /// </remarks>
        /// <param name="Comparison">The expression to compare to this expression</param>
        public virtual bool IsIdenticalTo(Expression Comparison)
        {
            return false;
        }

        /// <summary>
        /// Determines if this expression contains another expression.
        /// </summary>
        /// <param name="Comparison">The expression to search for</param>
        public virtual bool ContainsExpression(Expression Comparison)
        {
            return false;
        }

        /// <summary>
        /// Determines if this expression contains another type of expression.
        /// </summary>
        /// <typeparam name="T">The type of expression to search for</typeparam>
        public virtual bool ContainsExpressionType<T>() where T : Expression
        {
            if (this.IsExactExpressionType<T>()) return true;
            if (typeof(T) == typeof(Classification.ClassifiedExpression)) return true;

            //If they hand us some kind of classified expression:
            if (typeof(T).IsAssignableFrom(typeof(Classification.ClassifiedExpression)))
            {
                //If one of our classifications matches the given type, then we are golden
                var myclassification = this.Classify();
                if (myclassification.Length < 1) return false;
                foreach (Classification.ClassifiedExpression C in myclassification)
                {
                    if (typeof(T).IsAssignableFrom(C.GetType())) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Classifies this expression into a particular category of expressions.
        /// </summary>
        public virtual Classification.ClassifiedExpression[] Classify() { return new Classification.ClassifiedExpression[] { new Classification.ClassifiedExpression(this) }; }

        /// <summary>
        /// Determines if this expression is similar to another expression.
        /// Expressions are similar if they generate equal expressions when all coefficients
        /// are substituted for a single generic constant. (note that exponents are untouched)
        /// </summary>
        /// <param name="Comparison">The expression to compare to</param>
        public virtual bool IsSimilarTo(Expression Comparison)
        {
            return false;
        }

        /// <summary>
        /// Determine if this expression is opposite to (negation of) another expression.
        /// </summary>
        /// <param name="Comparison">The expression to compare to</param>
        public virtual bool IsOppositeOf(Expression Comparison)
        {
            return (this == -Comparison);
        }

        /// <summary>
        /// Determine if this expression is EXACTLY another type of expression type (see remarks).
        /// </summary>
        /// <remarks>
        /// Remember that the "is" operator in C# will return true if a particular class is OR INHERITS the given type.
        /// This allows us to absolultely guarentee that it is a particular type.
        /// </remarks>
        /// <typeparam name="T">The type to copmpare to</typeparam>
        public virtual bool IsExactExpressionType<T>() where T : Expression
        {
            return (typeof(T) == this.GetType());
        }

        /// <summary>
        /// Determine if this expression is the reciprocal (inverse) of another expression.
        /// </summary>
        /// <param name="Comparison">The expression to compare to</param>
        public virtual bool IsReciprocalOf(Expression Comparison)
        {
            return (this == (1 / Comparison));
        }

        /// <summary>
        /// Converts this expression into its generic form.
        /// All coefficients are replaced with the generic constant "C" with a few exceptions.
        /// Exponents are untouched.
        /// </summary>
        /// <remarks>
        /// EXAMPLE CONVERSIONS:
        /// 3x^2 + 4y - (3/2)x  ->  Cx^2 + Cy - Cx
        /// 12x^2 + 8y - 6x     ->  Cx^2 + Cy - Cx
        /// </remarks>
        public virtual Expression ToGenericForm()
        {
            throw new Exceptions.SimplificationException("Unable to convert expression to generic form");
        }
    }
}
