﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Irreducibles;
using Simplex.Math.Operations.Elementary;
using Simplex.Math.Classification;
using Simplex.Math.Operations;
using Simplex.Math.Operations.Special;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a static collection of commonly used transforms.
    /// </summary>
    public static class Transforms
    {
        /// <summary>
        /// Returns the descrete value (as double) associated with the input expression (if the input is a value or constant).
        /// If the input doesn't have a descrete value, the input is returned.
        /// </summary>
        public static readonly Transform ToDescreteValue = new Transform(x => ToDescreteValue_Body(x));
        private static Expression ToDescreteValue_Body(Expression Input)
        {
            if (Input is Value) return Input;
            if (Input is Constant) if ((Input as Constant).HasDescreteValue) return (Input as Constant).Value;
            return Input;
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
        public static readonly Transform ToInfinity = new Transform(x => Constant.PositiveInfinity);

        /// <summary>
        /// Returns "negative infinity" independent of the input expression.
        /// </summary>
        public static readonly Transform ToNegativeInfinity = new Transform(x => Constant.NegativeInfinity);

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
        /// Returns the exponentiation of two input expressions cast as values.
        /// </summary>
        public static readonly Transform ValueExponentiate = new Transform((x, y) => System.Math.Pow((x as Value).InnerValue, (y as Value).InnerValue));

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
        /// Returns the inverse of a single input expression.
        /// </summary>
        public static readonly Transform InvertExpression = new Transform(x => 1 / x);

        /// <summary>
        /// Returns the application of an expression cast as an operation (skips transformability test).
        /// </summary>
        public static readonly Transform ApplyOperation = new Transform(x => (x as Operation).Apply(true));

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

        /// <summary>
        /// Returns the addition of two expressions by creating a new collapsed sum object from a new sum object between the two inputs, reducing the result, and then converting it back into a normal symbolic mathematical expression.
        /// </summary>
        public static readonly Transform AddViaCSOConversion = new Transform((x, y) => CollapsedSumOperation.Create(new Sum(x, y)).Reduce().ToExpression());

        /// <summary>
        /// Returns the multiplication of two expressions by creating a new collapsed product object from a new product object between the two inputs, reducing the result, and then converting it back into a normal symbolic mathematical expression.
        /// </summary>
        public static readonly Transform MultiplyViaCPOConversion = new Transform((x, y) => CollapsedProductOperation.Create(new Product(x, y)).Reduce().ToExpression());

        /// <summary>
        /// Returns the division of two expressions by creating a new collapsed product object from a new quotient object between the two inputs, reducing the result, and then converting it back into a normal symbolic mathematical expression.
        /// </summary>
        public static readonly Transform DivideViaCPOConversion = new Transform((x, y) => CollapsedProductOperation.Create(new Quotient(x, y)).Reduce().ToExpression());

        /// <summary>
        /// Returns the subtraction of two expressions by creating a new collapsed sum object from a new difference object between the two inputs, reducing the result, and then converting it back into a normal symbolic mathematical expression.
        /// </summary>
        public static readonly Transform SubtractViaCSOConversion = new Transform((x, y) => CollapsedSumOperation.Create(new Difference(x, y)).Reduce().ToExpression());

        /// <summary>
        /// Computes the addition between multiples of expressions.
        /// </summary>
        /// <remarks>
        /// Examples: (3x + x) OR (4x + 7x)
        /// </remarks>
        public static readonly Transform AddMultiples = new Transform((x, y) => AddMultiples_Body(x, y));
        private static Expression AddMultiples_Body(Expression x, Expression y)
        {
            if (x is Product)
            {
                //Direct multiples (3x + x)
                var xp = x as Product;
                Value xval;
                Expression xother;

                if ((xp.LeftExpression is Value) && (xp.LeftExpression as Value).IsInteger())
                {
                    xval = xp.LeftExpression as Value;
                    xother = xp.RightExpression;
                }
                else if ((xp.RightExpression is Value) && (xp.RightExpression as Value).IsInteger())
                {
                    xval = xp.RightExpression as Value;
                    xother = xp.LeftExpression;
                }
                else return new Sum(x, y);

                if (xother == y) return new Product(xval + 1, xother);

                //Indirect multiples (6x + 3x)
                if (y is Product)
                {
                    var yp = y as Product;
                    Value yval;
                    Expression yother;

                    if ((yp.LeftExpression is Value) && (yp.LeftExpression as Value).IsInteger())
                    {
                        yval = yp.LeftExpression as Value;
                        yother = yp.RightExpression;
                    }
                    else if ((yp.RightExpression is Value) && (yp.RightExpression as Value).IsInteger())
                    {
                        yval = yp.RightExpression as Value;
                        yother = yp.LeftExpression;
                    }
                    else return new Sum(x, y);

                    if (xother == yother)
                    {
                        return new Product(xval + yval, xother);
                    }
                }
            }

            //Otherwise it didn't work
            return new Sum(x, y);
        }

        /// <summary>
        /// Computes the subtraction between multiples of expressions.
        /// </summary>
        /// <remarks>
        /// Examples: (3x - x) OR (4x - 7x)
        /// </remarks>
        public static readonly Transform SubtractMultiples = new Transform((x, y) => SubtractMultiples_Body(x, y));
        private static Expression SubtractMultiples_Body(Expression x, Expression y)
        {
            if (x is Product)
            {
                //Direct multiples (3x - x)
                var xp = x as Product;
                Value xval;
                Expression xother;

                if ((xp.LeftExpression is Value) && (xp.LeftExpression as Value).IsInteger())
                {
                    xval = xp.LeftExpression as Value;
                    xother = xp.RightExpression;
                }
                else if ((xp.RightExpression is Value) && (xp.RightExpression as Value).IsInteger())
                {
                    xval = xp.RightExpression as Value;
                    xother = xp.LeftExpression;
                }
                else return new Difference(x, y);

                if (xother == y) return new Product(xval - 1, xother);

                //Indirect multiples (6x - 3x)
                if (y is Product)
                {
                    var yp = y as Product;
                    Value yval;
                    Expression yother;

                    if ((yp.LeftExpression is Value) && (yp.LeftExpression as Value).IsInteger())
                    {
                        yval = yp.LeftExpression as Value;
                        yother = yp.RightExpression;
                    }
                    else if ((yp.RightExpression is Value) && (yp.RightExpression as Value).IsInteger())
                    {
                        yval = yp.RightExpression as Value;
                        yother = yp.LeftExpression;
                    }
                    else return new Difference(x, y);

                    if (xother == yother)
                    {
                        return new Product(xval - yval, xother);
                    }
                }
            }

            //Otherwise it didn't work
            return new Difference(x, y);
        }

        /// <summary>
        /// Computes the multiplication between two sums/differences (or an operand and a sum/difference) by FOILing.
        /// </summary>
        public static readonly Transform DistributeMultiply = new Transform((x, y) => DistributeMultiply_Body(x, y));
        private static Expression DistributeMultiply_Body(Expression x, Expression y)
        {
            List<Expression> LeftExpressions = new List<Expression>(1) { 0 };
            List<Expression> RightExpressions = new List<Expression>(1) { 0 };

            if (x is Irreducible) LeftExpressions = new List<Expression>(1) { x };
            else if (Propositions.QualifiesForCSO[x])
            {
                CollapsedSumOperation CSO = CollapsedSumOperation.Create(x);
                LeftExpressions = CSO.ChildExpressions;
            }
            else if (x is Sum) LeftExpressions = new List<Expression>(2) { (x as Sum).LeftExpression, (x as Sum).RightExpression };
            else if (x is Difference) LeftExpressions = new List<Expression>(2) { (x as Difference).LeftExpression, -(x as Difference).RightExpression };
            

            if (y is Irreducible) RightExpressions = new List<Expression>(1) { y };
            else if (Propositions.QualifiesForCSO[y])
            {
                CollapsedSumOperation CSO = CollapsedSumOperation.Create(y);
                RightExpressions = CSO.ChildExpressions;
            }
            else if (y is Sum) RightExpressions = new List<Expression>(2) { (y as Sum).LeftExpression, (y as Sum).RightExpression };
            else if (y is Difference) RightExpressions = new List<Expression>(2) { (y as Difference).LeftExpression, -(y as Difference).RightExpression };

            LeftExpressions.TrimExcess();
            RightExpressions.TrimExcess();

            List<Expression> ResultExpressions = new List<Expression>();
            for (int i = 0; i < LeftExpressions.Count; i++)
            {
                for (int j = 0; j < RightExpressions.Count; j++)
                {
                    ResultExpressions.Add(LeftExpressions[i] * RightExpressions[j]);
                }
            }

            ResultExpressions.TrimExcess();
            if (ResultExpressions.Count == 1) return ResultExpressions[0];
            if (ResultExpressions.Count == 2) return (ResultExpressions[0] + ResultExpressions[1]);
            return new CollapsedSumOperation(ResultExpressions.ToArray()).Reduce().ToExpression();
        }

        /// <summary>
        /// Computes the multiplication between an exponentiation and an expression or between two exponentiations.
        /// </summary>
        public static readonly Transform MultiplyExponentiations = new Transform((x, y) => MultiplyExponentiations_Body_ClassifyStep(x, y));
        private static Expression MultiplyExponentiations_Body_ClassifyStep(Expression x, Expression y)
        {
            //Send them to the correct sub-method
            if ((x is Exponentiation) && (y is Exponentiation)) return MultiplyExponentiations_Body(x as Exponentiation, y as Exponentiation);
            if ((x is Exponentiation) && !(y is Exponentiation)) return MultiplyExponentiations_Body(x as Exponentiation, y);
            if (!(x is Exponentiation) && (y is Exponentiation)) return MultiplyExponentiations_Body(y as Exponentiation, x);
            
            //If neither are powers, return a new product between them
            return new Product(x, y);
        }
        private static Expression MultiplyExponentiations_Body(Exponentiation x, Expression y)
        {
            //If the bases are equal
            if (x.Base == y) return x.Base ^ (x.Exponent + 1);

            //If the bases are not equal
            return new Product(x, y);
        }
        private static Expression MultiplyExponentiations_Body(Exponentiation x, Exponentiation y)
        {
            //If the bases are equal
            if (x.Base == y.Base) return x.Base ^ (x.Exponent + y.Exponent);

            //If the bases are not equal
            return new Product(x, y);
        }


        /// <summary>
        /// Computes the division between an exponentiation and an expression or between two exponentiations.
        /// </summary>
        public static readonly Transform DivideExponentiations = new Transform((x, y) => DivideExponentiations_Body_ClassifyStep(x, y));
        private static Expression DivideExponentiations_Body_ClassifyStep(Expression x, Expression y)
        {
            //Send them to the correct sub-method
            if ((x is Exponentiation) && (y is Exponentiation)) return DivideExponentiations_Body(x as Exponentiation, y as Exponentiation);
            if ((x is Exponentiation) && !(y is Exponentiation)) return DivideExponentiations_Body(x as Exponentiation, y);
            if (!(x is Exponentiation) && (y is Exponentiation)) return DivideExponentiations_Body(y as Exponentiation, x);

            //If neither are powers, return a new quotient between them
            return new Quotient(x, y);
        }
        private static Expression DivideExponentiations_Body(Exponentiation x, Expression y)
        {
            //If the bases are equal
            if (x.Base == y) return x.Base ^ (x.Exponent - 1);

            //If the bases are not equal
            return new Quotient(x, y);
        }
        private static Expression DivideExponentiations_Body(Exponentiation x, Exponentiation y)
        {
            //If the bases are equal
            if (x.Base == y.Base) return x.Base ^ (x.Exponent - y.Exponent);

            //If the bases are not equal
            return new Quotient(x, y);
        }

        /// <summary>
        /// Seperates a product between an integer value and another expression into sums of that expression. 
        /// </summary>
        public static readonly Transform SeperateIntegerProduct = new Transform(x => SeperateIntegerProduct_Body(x as Product));
        private static Expression SeperateIntegerProduct_Body(Product x)
        {
            //Seperate the integer and expression:
            Value I = 0;
            Expression E = 0;
            if (x.LeftExpression is Value)
            {
                I = x.LeftExpression as Value;
                E = x.RightExpression;
            }
            else if (x.RightExpression is Value)
            {
                I = x.RightExpression as Value;
                E = x.LeftExpression;
            }
            else throw new Exceptions.LogicException("Cannot transform expression - input expression is not a seperable integer product");

            //If our integer product is negative, send it back through with the expression inverted
            if (I < -1)
            {
                return SeperateIntegerProduct_Body(new Product(-I, new Negation(E)));
            }

            //If our integer product is -1
            if (I == -1) return new Difference(0, E);

            //If the integer value is 0, return 0
            if (I == 0) return 0;

            //If the integer value is 1, return the other expression by itself
            if (I == 1) return E;

            //If the integer value is greater than 1
            Expression Result = new Sum(E, E);

            for (int i = 2; i < I; i++)
            {
                Result = new Sum(Result, E);
            }

            return Result;
        }
    }
}
