using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Operands;
using Simplex.Math.Operations.Elementary;
using Simplex.Math.Operations.Trigonometric;
using Simplex.Math.Operations.Special;

namespace Simplex.Math.Core
{
    /// <summary>
    /// Contains various static methods for common mathematical operations.
    /// </summary>
    /// <remarks>
    /// This is essentially a re-write of System.Math with support for our libraries
    /// </remarks>
    public static class Math
    {
        /// <summary>
        /// Computes the absolute value of a particular input expression.
        /// </summary>
        /// <param name="Input">The input expression to compute the absolute value of</param>
        public static Expression Abs(Expression Input)
        {
            return AbsoluteValue.Abs(Input);
        }

        /// <summary>
        /// Returns the sine of a particular expression.
        /// </summary>
        public static void Sin()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the cosine of a particular expression.
        /// </summary>
        public static void Cos()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the tangent of a particular expression.
        /// </summary>
        public static void Tan()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the secant of a particular expression.
        /// </summary>
        public static void Sec()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the cosecant of a particular expression.
        /// </summary>
        public static void Csc()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the cotangent of a particular expression.
        /// </summary>
        public static void Cot()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the arcsine of a particular expression.
        /// </summary>
        public static void ASin()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the arccosine of a particular expression.
        /// </summary>
        public static void ACos()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the arctangent of a particular expression.
        /// </summary>
        public static void ATan()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the arcsecant of a particular expression.
        /// </summary>
        public static void ASec()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the arccosecant of a particular expression.
        /// </summary>
        public static void ACsc()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the arccotangent of a particular expression.
        /// </summary>
        public static void ACot()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the ceiling (rounds up) of a particular expression.
        /// </summary>
        public static void Ceil()
        {
            throw new System.NotImplementedException();
        }

        public static void Floor()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Rounds the expression to the nearest integer value (or the highest degree part if the expression is a polynomial).
        /// </summary>
        /// <remarks>
        /// If given an expression like "3x^2 + 2x + 12", this method will return "3x^2"
        /// </remarks>
        public static void Round()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Raises the given expression by the power given by another expression.
        /// </summary>
        /// <remarks>
        /// This method can be used for regular integer powers as well as whole expressions as powers.
        /// </remarks>
        /// <param name="Base">The expression to use as the base of the resulting power</param>
        /// <param name="Exponent">The expression to use as the exponent of the resulting power</param>
        public static Expression Pow(Expression Base, Expression Exponent)
        {
            return Base ^ Exponent;
        }

        /// <summary>
        /// Returns the exponential function of a particular expression.
        /// </summary>
        /// <remarks>
        /// This raises "e" to a particular expression.
        /// </remarks>
        /// <param name="Input">The input expression</param>
        public static Expression Exp(Expression Input)
        {
            return Constant.e ^ Input;
        }

        /// <summary>
        /// Takes the square root of a particular expression.
        /// </summary>
        /// <remarks>
        /// Remember to create an overload with two inputs that takes the nth root of an expression.
        /// </remarks>
        /// <param name="Input">The expression to take the square root of</param>
        public static Expression Root(Expression Input)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the smallest expression in a set of expressions.
        /// </summary>
        /// <remarks>
        /// If the set contains objects that are not descrete values, the lowest exponential will be selected.
        /// EXAMPLE: Giving {2x^2, x^3, 7x + 2} will return "7x + 2"
        /// </remarks>
        public static void Min()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the largest expression in a set of expressions.
        /// </summary>
        /// <remarks>
        /// If the set contains objects that are not descrete values, the highest exponential will be selected.
        /// EXAMPLE: Giving {2x^2, x^3, 7x + 2} will return "x^3"
        /// </remarks>
        public static void Max()
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// Returns the mean (average) expression in a set of expressions.
        /// </summary>
        /// <remarks>
        /// Even if the set doesn't contain descrete values, it is calculated the same way a mean is typically calculated.
        /// </remarks>
        public static void Mean()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the median of a particular set of expressions.
        /// </summary>
        public static void Median()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns the mode of a particular set of expressions.
        /// </summary>
        public static void Mode()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Simplifies a given mathematical expression by canceling like terms and re-writing it into expanded form.
        /// </summary>
        /// <remarks>
        /// Example: (3x + y) + (2x + 4)  ->  5x + y + 4
        /// </remarks>
        public static void Simplify()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Re-forms a given expression into an expanded form.
        /// </summary>
        /// <remarks>
        /// Example: 3(x + y)  ->  3x + 3y
        /// </remarks>
        public static void Expand()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Solves a given mathematical expression for a particular variable or constant.
        /// </summary>
        public static void Solve()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Re-forms a given expression into a contracted form.
        /// </summary>
        /// <remarks>
        /// Example: 3x + 3y  ->  3(x + y)
        /// </remarks>
        public static void Contract()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Computes the natural logarithm of an input expression.
        /// </summary>
        /// <param name="LogExpression">The expression to take the log of</param>
        public static Expression Log(Expression LogExpression)
        {
            return NaturalLogarithm.Log(LogExpression);
        }

        /// <summary>
        /// Computes the logarithm of an input expression with respect to a particular base
        /// </summary>
        /// <param name="Base">The base expression of this logarithm</param>
        /// <param name="LogExpression">The expression to take the log of</param>
        public static Expression Log(Expression Base, Expression LogExpression)
        {
            return Logarithm.Log(Base, LogExpression);
        }

        /// <summary>
        /// Computes the sum of two or more input expressions.
        /// </summary>
        /// <param name="Expressions">The expressions to sum</param>
        public static Expression Sum(params Expression[] Expressions)
        {
            if (Expressions == null || Expressions.Length < 1) throw new Exceptions.CalculationException("Cannot calculate summation of expressions - input array is null or empty");
            if (Expressions.Length == 1) return Expressions[0];
            if (Expressions.Length == 2) return Expressions[0] + Expressions[1];

            return new CollapsedSumOperation(Expressions).Reduce().ToExpression();
        }

        /// <summary>
        /// Computes the sum of the squares of two or more input expressions.
        /// </summary>
        /// <param name="Expressions">The expressions to sum</param>
        public static Expression SquareSum(params Expression[] Expressions)
        {
            if (Expressions == null || Expressions.Length < 1) throw new Exceptions.CalculationException("Cannot calculate summation of expressions - input array is null or empty");
            if (Expressions.Length == 1) return Expressions[0] ^ 2;
            if (Expressions.Length == 2) return (Expressions[0] ^ 2) + (Expressions[1] ^ 2);

            return new CollapsedSumOperation(Expressions.Select(x => x ^ 2).ToArray()).Reduce().ToExpression();
        }

        public static void Differentiate()
        {
            throw new System.NotImplementedException();
        }

        public static void PartialDifferentiate()
        {
            throw new System.NotImplementedException();
        }

        public static void Limit()
        {
            throw new System.NotImplementedException();
        }

        public static void Integrate()
        {
            throw new System.NotImplementedException();
        }
    }
}
