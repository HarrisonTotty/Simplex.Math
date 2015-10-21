using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Operands;
using Simplex.Math.Operations.Elementary;
using Simplex.Math.Classification;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a static collection of commonly used transforms.
    /// </summary>
    public static class Transforms
    {
        /// <summary>
        /// Returns the descrete value associated with the input expression (if the input is a value or constant).
        /// If the input doesn't have a descrete value, the value "0" is returned.
        /// </summary>
        public static readonly Transform ToDescreteValue = new Transform(x => ToDescreteValue_Body(x));
        private static Expression ToDescreteValue_Body(Expression Input)
        {
            if (Input is Value) return (Input as Value);
            if (Input is Constant) if ((Input as Constant).HasDescreteValue) return (Input as Constant).Value;
            return 0;
        }

        /// <summary>
        /// Returns the value "0" independent of the input expression.
        /// </summary>
        public static readonly Transform ToZero = new Transform(x => 0);

        /// <summary>
        /// Returns the value "1" independent of the input expression.
        /// </summary>
        public static readonly Transform ToOne = new Transform(x => 1);

        /// <summary>
        /// Returns the value "-1" independent of the input expression.
        /// </summary>
        public static readonly Transform ToNegativeOne = new Transform(x => -1);

        /// <summary>
        /// Returns the generic constant "C" independent of the input expression.
        /// </summary>
        public static readonly Transform ToGenericConstant = new Transform(x => Constant.C);

        /// <summary>
        /// Returns Euler's number "e" independent of the input expression.
        /// </summary>
        public static readonly Transform ToEulersNumber = new Transform(x => Constant.e);

        /// <summary>
        /// Returns "infinity" independent of the input expression.
        /// </summary>
        public static readonly Transform ToInfinity = new Transform(x => Constant.Infinity);

        /// <summary>
        /// Returns "negative infinity" independent of the input expression.
        /// </summary>
        public static readonly Transform ToNegativeInfinity = new Transform(x => -Constant.Infinity);

        /// <summary>
        /// Returns "i" independent of the input expression.
        /// </summary>
        public static readonly Transform ToImaginaryUnit = new Transform(x => ImaginaryUnit.i);

        /// <summary>
        /// Returns the addition of two input expressions.
        /// </summary>
        public static readonly Transform Add = new Transform((x, y) => x + y);

        /// <summary>
        /// Returns the addition of two input expressions cast as values.
        /// </summary>
        public static readonly Transform ValueAdd = new Transform((x, y) => (x as Value).InnerValue + (y as Value).InnerValue);

        /// <summary>
        /// Returns the addition of two input expressions cast as polynomials.
        /// </summary>
        public static readonly Transform PolynomialAdd = new Transform((x, y) => Polynomial.Add(x as Polynomial, y as Polynomial));

        /// <summary>
        /// Returns the subtraction of two input expressions.
        /// </summary>
        public static readonly Transform Subtract = new Transform((x, y) => x - y);

        /// <summary>
        /// Returns the subtraction of two input expressions cast as values.
        /// </summary>
        public static readonly Transform ValueSubtract = new Transform((x, y) => (x as Value).InnerValue - (y as Value).InnerValue);

        /// <summary>
        /// Returns the multiplication of two input expressions.
        /// </summary>
        public static readonly Transform Multiply = new Transform((x, y) => x * y);

        /// <summary>
        /// Returns the multiplication of two input expressions cast as values.
        /// </summary>
        public static readonly Transform ValueMultiply = new Transform((x, y) => (x as Value).InnerValue * (y as Value).InnerValue);

        /// <summary>
        /// Returns the division of two input expressions.
        /// </summary>
        public static readonly Transform Divide = new Transform((x, y) => x / y);

        /// <summary>
        /// Returns the division of two input expressions cast as values.
        /// </summary>
        public static readonly Transform ValueDivide = new Transform((x, y) => (x as Value).InnerValue / (y as Value).InnerValue);

        /// <summary>
        /// Returns a input expression without a transformation.
        /// </summary>
        public static readonly Transform ReturnExpression = new Transform(x => x);

        /// <summary>
        /// Returns the first expression of a pair of expressions.
        /// Same as Transforms.ReturnExpression.
        /// </summary>
        public static readonly Transform ReturnFirstExpression = new Transform((x, y) => x);

        /// <summary>
        /// Returns the second expression of a pair of expressions.
        /// </summary>
        public static readonly Transform ReturnSecondExpression = new Transform((x, y) => y);

        /// <summary>
        /// Returns double the value of a single input expression (2x).
        /// </summary>
        public static readonly Transform DoubleExpression = new Transform(x => 2 * x);

        /// <summary>
        /// Returns half the value of a single input expression (x/2).
        /// </summary>
        public static readonly Transform HalfExpression = new Transform(x => x / 2);

        /// <summary>
        /// Returns the input expression raised to the 2nd power.
        /// </summary>
        public static readonly Transform SquareExpression = new Transform(x => x ^ 2);

        /// <summary>
        /// Returns the input expression multiplied by -1.
        /// </summary>
        public static readonly Transform NegateExpression = new Transform(x => -x);

        /// <summary>
        /// Returns the second input expression multiplied by -1.
        /// </summary>
        public static readonly Transform NegateSecondExpression = new Transform((x, y) => -y);
    }
}
