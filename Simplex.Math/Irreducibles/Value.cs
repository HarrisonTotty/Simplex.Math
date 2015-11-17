using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Classification;
using Simplex.Math;

namespace Simplex.Math.Irreducibles
{
    /// <summary>
    /// A type of mathematical constant that has a descrete value.
    /// </summary>
    public class Value : Irreducible
    {
        //The following operators are for automatic conversion of integers and doubles to values
        public static implicit operator Value(double D) { return new Value(D); }
        public static implicit operator Value(int I) { return new Integer(I); }
        public static implicit operator Value(long I) { return new Integer(I); }
        public static explicit operator int (Value V) { return (int)V.InnerValue; }
        public static explicit operator long (Value V) { return (long)V.InnerValue; }
        public static explicit operator double (Value V) { return V.InnerValue; }

        //Inequality Operators associated with values
        public static bool operator >(Value V, int I) { return (V.InnerValue > I); }
        public static bool operator >=(Value V, int I) { return (V.InnerValue >= I); }
        public static bool operator <(Value V, int I) { return (V.InnerValue < I); }
        public static bool operator <=(Value V, int I) { return (V.InnerValue <= I); }
        public static bool operator >(Value V, double D) { return (V.InnerValue > D); }
        public static bool operator >=(Value V, double D) { return (V.InnerValue >= D); }
        public static bool operator <(Value V, double D) { return (V.InnerValue < D); }
        public static bool operator <=(Value V, double D) { return (V.InnerValue <= D); }
        public static bool operator >(int I, Value V) { return (I > V.InnerValue); }
        public static bool operator >=(int I, Value V) { return (I >= V.InnerValue); }
        public static bool operator <(int I, Value V) { return (I < V.InnerValue); }
        public static bool operator <=(int I, Value V) { return (I <= V.InnerValue); }
        public static bool operator >(double D, Value V) { return (D > V.InnerValue); }
        public static bool operator >=(double D, Value V) { return (D >= V.InnerValue); }
        public static bool operator <(double D, Value V) { return (D < V.InnerValue); }
        public static bool operator <=(double D, Value V) { return (D <= V.InnerValue); }
        public static bool operator >(Value V1, Value V2) { return (V1.InnerValue > V2.InnerValue); }
        public static bool operator >=(Value V1, Value V2) { return (V1.InnerValue >= V2.InnerValue); }
        public static bool operator <(Value V1, Value V2) { return (V1.InnerValue < V2.InnerValue); }
        public static bool operator <=(Value V1, Value V2) { return (V1.InnerValue <= V2.InnerValue); }

        //Equality operators associated with values
        //public static bool operator ==(Value V, int I) { return (V.InnerValue == I); }
        //public static bool operator ==(Value V, double D) { return (V.InnerValue == D); }
        //public static bool operator !=(Value V, int I) { return (V.InnerValue != I); }
        //public static bool operator !=(Value V, double D) { return (V.InnerValue != D); }
        //public static bool operator ==(int I, Value V) { return (I == V.InnerValue); }
        //public static bool operator ==(double D, Value V) { return (D == V.InnerValue); }
        //public static bool operator !=(int I, Value V) { return (I != V.InnerValue); }
        //public static bool operator !=(double D, Value V) { return (D != V.InnerValue); }

        public virtual double InnerValue
        {
            get;
            set;
        }

        /// <summary>
        /// Classifying a variable, constant, or value will always return at least an intrinsic irriducible
        /// </summary>
        public override ClassifiedExpression[] Classify()
        {
            if (this.InnerValue < 0) return new ClassifiedExpression[] { new PolynomialTerm(-this) { IsNegated = true }, new DescreteValue(-this) { IsNegated = true } };
            return new ClassifiedExpression[] { new PolynomialTerm(this), new DescreteValue(this) };
        }

        /// <summary>
        /// Creates a new value object with a particular inner value.
        /// </summary>
        /// <param name="InnerValue">The actual value of the object</param>
        public Value(double InnerValue)
        {
            this.InnerValue = InnerValue;
        }

        /// <summary>
        /// Creates a new value object with the inner value of 0.
        /// </summary>
        public Value()
        {
            this.InnerValue = 0;
        }

        /// <summary>
        /// Obtains the string representation of this mathematical expression with specific formatting options.
        /// </summary>
        /// <param name="Format">The general format to use for the output</param>
        /// <param name="VariableFormat">The format to use for variables in the output</param>
        /// <param name="ConstantFormat">The format to use for constants and values in the output</param>
        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            if (Format == ExpressionStringFormat.Default)
            {
                //Check for common fractions:
                if (this.InnerValue == (1.0 / 2)) return "(1/2)";
                if (this.InnerValue == (1.0 / 3)) return "(1/3)";
                if (this.InnerValue == (2.0 / 3)) return "(2/3)";
                if (this.InnerValue == (1.0 / 4)) return "(1/4)";
                if (this.InnerValue == (3.0 / 4)) return "(3/4)";
                if (this.InnerValue == (1.0 / 5)) return "(1/5)";
                if (this.InnerValue == (2.0 / 5)) return "(2/5)";
                if (this.InnerValue == (3.0 / 5)) return "(3/5)";
                if (this.InnerValue == (4.0 / 5)) return "(4/5)";
                return this.InnerValue.ToString();
            }
            else if (Format == ExpressionStringFormat.LaTeX)
            {
                //Check for common fractions:
                if (this.InnerValue == (1.0 / 2)) return @"\frac{1}{2}";
                if (this.InnerValue == (1.0 / 3)) return @"\frac{1}{3}";
                if (this.InnerValue == (2.0 / 3)) return @"\frac{2}{3}";
                if (this.InnerValue == (1.0 / 4)) return @"\frac{1}{4}";
                if (this.InnerValue == (3.0 / 4)) return @"\frac{3}{4}";
                if (this.InnerValue == (1.0 / 5)) return @"\frac{1}{5}";
                if (this.InnerValue == (2.0 / 5)) return @"\frac{2}{5}";
                if (this.InnerValue == (3.0 / 5)) return @"\frac{3}{5}";
                if (this.InnerValue == (4.0 / 5)) return @"\frac{4}{5}";
                return this.InnerValue.ToString();
            }
            else if (Format == ExpressionStringFormat.ParseFriendly)
            {
                return this.InnerValue.ToString();
            }
            else
            {
                throw new Exceptions.ExpressionParsingException("");
            }
        }

        /// <summary>
        /// Returns whether the value is of a particular type (int, double, etc).
        /// If the inner value for example is "3.00", then IsType called with the typeparam of "int" will return true.
        /// The same value called with the typeparam "double" will return false.
        /// </summary>
        /// <remarks>
        /// Note that while the number "3.00" is stored as a double, to us it is NOT a double, but rather an integer.
        /// </remarks>
        /// <typeparam name="T">The type to test</typeparam>
        public bool IsValueType<T>()
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long)) return this.IsInteger();
            if (typeof(T) == typeof(double)) return !this.IsInteger();
            //if (typeof(T) == typeof(Fraction)) return (this is Fraction);
            return (this.InnerValue is T);
        }

        /// <summary>
        /// Whether the type of number this value represents is an integer.
        /// </summary>
        /// <remarks>
        /// Note that since this.Val is stored as a double, we will see if casting it to an int returns the same value!
        /// </remarks>
        public virtual bool IsInteger()
        {
            return (this.InnerValue == (long)this.InnerValue);
        }

        public override Expression Copy()
        {
            return new Value(this.InnerValue);
        }
    }
}
