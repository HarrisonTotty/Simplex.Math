using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;
using Simplex.Math.Operands;
using Simplex.Math.Operations;
using Simplex.Math.Operations.Elementary;
using Simplex.Math.Classification;
using Simplex.Math.Sets;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a static collection of commonly used propositions.
    /// </summary>
    public static class Propositions
    {
        /// <summary>
        /// Whether a single input expression is a value.
        /// </summary>
        public static readonly SingleParameterProposition IsValue = new SingleParameterProposition(x => (x is Value));

        /// <summary>
        /// Whether one value/constant has a descrete value (see remarks).
        /// </summary>
        /// <remarks>
        /// "Pi" and "3" have descete values, while "C" does not.
        /// </remarks>
        public static readonly SingleParameterProposition HasDescreteValue = new SingleParameterProposition(x => IsValue[x] || IsDescreteConstant[x]);

        /// <summary>
        /// Whether a pair of values/constants have descrete values (see remarks).
        /// </summary>
        /// <remarks>
        /// The pair (Pi, 3) both have descrete values, but the pair (Pi, C) do not.
        /// </remarks>
        public static readonly DoubleParameterProposition HaveDescreteValues = new DoubleParameterProposition((x, y) => HasDescreteValue[x] && HasDescreteValue[y]);

        /// <summary>
        /// Whether one value/constant has the same descrete value as another value/constant (see remarks).
        /// </summary>
        /// <remarks>
        /// Examples: 2 = 2, Pi = 3.14...
        /// </remarks>
        public static readonly DoubleParameterProposition HaveSameDescreteValue = new DoubleParameterProposition((x, y) => (HasDescreteValue[x] && HasDescreteValue[y]) && (Transforms.ToDescreteValue[x] == Transforms.ToDescreteValue[y]));

        /// <summary>
        /// Whether two value objects represent the same value.
        /// </summary>
        public static readonly DoubleParameterProposition HaveSameStrictValue = new DoubleParameterProposition((x, y) => AreValues[x, y] && ((x as Value).InnerValue == (y as Value).InnerValue));

        /// <summary>
        /// Whether an expression has one or more child expressions.
        /// </summary>
        public static readonly SingleParameterProposition HasChildExpressions = new SingleParameterProposition(x => x.HasChildren());

        /// <summary>
        /// Whether an expression is an operation.
        /// </summary>
        public static readonly SingleParameterProposition IsOperation = new SingleParameterProposition(x => (x is Operation));

        /// <summary>
        /// Whether a pair of input expressions are operations.
        /// </summary>
        public static readonly DoubleParameterProposition AreOperations = new DoubleParameterProposition((x, y) => IsOperation[x] && IsOperation[y]);

        /// <summary>
        /// Whether an expression is a unary operation (an operation that accepts 1 parameter).
        /// </summary>
        /// <remarks>
        /// Note that we will not assume that the class for the operation inherits the UnaryOperation class.
        /// </remarks>
        public static readonly SingleParameterProposition IsUnaryOperation = new SingleParameterProposition(x => IsOperation[x] && (x as Operation).Arity == 1);

        /// <summary>
        /// Whether an expression is a binary operation (an operation that accepts 2 parameters).
        /// </summary>
        /// <remarks>
        /// Note that we will not assume that the class for the operation inherits the BinaryOperation class.
        /// </remarks>
        public static readonly SingleParameterProposition IsBinaryOperation = new SingleParameterProposition(x => IsOperation[x] && (x as Operation).Arity == 2);

        /// <summary>
        /// Whether an expression is a trinary operation (an operation that accepts 3 parameters).
        /// </summary>
        /// <remarks>
        /// Note that we will not assume that the class for the operation inherits the TrinaryOperation class.
        /// </remarks>
        public static readonly SingleParameterProposition IsTrinaryOperation = new SingleParameterProposition(x => IsOperation[x] && (x as Operation).Arity == 3);

        /// <summary>
        /// Whether a pair of expressions have one or more child expressions.
        /// </summary>
        public static readonly DoubleParameterProposition HaveChildExpressions = new DoubleParameterProposition((x, y) => HasChildExpressions[x] && HasChildExpressions[y]);

        /// <summary>
        /// Whether two expressions have equal child expressions (non-commutative) (see remarks).
        /// </summary>
        /// <remarks>
        /// The sets of children {x, y} and {x, y} would pass this test, however {x, y} and {y, x} would not.
        /// </remarks>
        public static readonly DoubleParameterProposition HaveEqualChildExpressions = new DoubleParameterProposition((x, y) => HaveChildExpressions[x, y] && HaveEqualChildExpressions_Body(x, y));
        private static bool HaveEqualChildExpressions_Body(Expression E1, Expression E2)
        {
            if (E1.ChildExpressions.Count != E2.ChildExpressions.Count) return false;
            for (int i = 0; i < E1.ChildExpressions.Count; i++)
            {
                if (E1.ChildExpressions[i] != E2.ChildExpressions[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Whether two expressions have equal child expressions, respecting commutative rules (see remarks).
        /// </summary>
        /// <remarks>
        /// Both the sets of children {x, y} and {x, y}, as well as {x, y} and {y, x}, would pass this test.
        /// </remarks>
        public static readonly DoubleParameterProposition HaveEqualChildExpressions_Commutative = new DoubleParameterProposition((x, y) => HaveChildExpressions[x, y] && HaveEqualChildExpressions_Commutative_Body(x, y));
        private static bool HaveEqualChildExpressions_Commutative_Body(Expression E1, Expression E2)
        {
            if (E1.ChildExpressions.Count != E2.ChildExpressions.Count) return false;
            for (int i = 0; i < E1.ChildExpressions.Count; i++)
            {
                bool foundmatch = false;
                for (int j = 0; j < E2.ChildExpressions.Count; j++)
                {
                    if (E1.ChildExpressions[i] == E2.ChildExpressions[j])
                    {
                        foundmatch = true;
                        break;
                    }
                }
                if (!foundmatch) return false;
            }
            return true;
        }


        /// <summary>
        /// Whether a single input expression is a variable.
        /// </summary>
        public static readonly SingleParameterProposition IsVariable = new SingleParameterProposition(x => (x is Variable));

        /// <summary>
        /// Whether a single input expression is a constant.
        /// </summary>
        public static readonly SingleParameterProposition IsConstant = new SingleParameterProposition(x => (x is Constant));

        /// <summary>
        /// Whether a single input expression is a constant with a descrete value (like Pi).
        /// </summary>
        public static readonly SingleParameterProposition IsDescreteConstant = new SingleParameterProposition(x => IsConstant[x] && (x as Constant).HasDescreteValue);

        /// <summary>
        /// Whether a single input expression is a coefficient (see remarks).
        /// </summary>
        /// <remarks>
        /// 3, C, 3C, 3/(CK), and (3 + C) are all coefficients
        /// </remarks>
        public static readonly SingleParameterProposition IsCoefficient = new SingleParameterProposition(x => (x is Constant) || (x is Value) || (x is ArithmeticOperation && (x as ArithmeticOperation).IsCoefficient()));

        /// <summary>
        /// Whether a pair of input expressions are coefficients (see remarks).
        /// </summary>
        /// <remarks>
        /// 3, C, 3C, 3/(CK), and (3 + C) are all coefficients
        /// </remarks>
        public static readonly DoubleParameterProposition AreCoefficients = new DoubleParameterProposition((x, y) => IsCoefficient[x] && IsCoefficient[y]);

        /// <summary>
        /// Whether two expressions are both values.
        /// </summary>
        public static readonly DoubleParameterProposition AreValues = new DoubleParameterProposition((x, y) => IsValue[x] && IsValue[y]);

        /// <summary>
        /// Whether two expressions both contain values.
        /// </summary>
        public static readonly DoubleParameterProposition ContainValues = new DoubleParameterProposition((x, y) => x.ContainsExpressionType<Value>() && y.ContainsExpressionType<Value>());

        /// <summary>
        /// Whether two expressions are both variables.
        /// </summary>
        public static readonly DoubleParameterProposition AreVariables = new DoubleParameterProposition((x, y) => IsVariable[x] && IsVariable[y]);

        /// <summary>
        /// Whether two expressions are both contain variables.
        /// </summary>
        public static readonly DoubleParameterProposition ContainVariables = new DoubleParameterProposition((x, y) => x.ContainsExpressionType<Variable>() && y.ContainsExpressionType<Variable>());

        /// <summary>
        /// Whether two expressions represent a variable and a value.
        /// </summary>
        public static readonly DoubleParameterProposition VariableValuePair = new DoubleParameterProposition((x, y) => ((x is Variable) && (y is Value)) || ((y is Variable) && (x is Value)));

        /// <summary>
        /// Whether two expressions are the same root type of expression.
        /// </summary>
        public static readonly DoubleParameterProposition AreSameRootType = new DoubleParameterProposition((x, y) => (x.GetType() == y.GetType()));

        /// <summary>
        /// Whether two expressions are both constants.
        /// </summary>
        public static readonly DoubleParameterProposition AreConstants = new DoubleParameterProposition((x, y) => IsConstant[x] && IsConstant[y]);

        /// <summary>
        /// Whether two variable/constant expressions have the same ID (by casting to the appropriate type).
        /// </summary>
        public static readonly DoubleParameterProposition HaveSameID = new DoubleParameterProposition((x, y) => (AreVariables[x, y] && ((x as Variable).ID == (y as Variable).ID)) || (AreConstants[x, y] && ((x as Constant).ID == (y as Constant).ID)));

        /// <summary>
        /// Whether two expressions are equal.
        /// </summary>
        public static readonly DoubleParameterProposition AreEqual = new DoubleParameterProposition((x, y) => x == y);

        /// <summary>
        /// Whether two expressions are similar.
        /// </summary>
        public static readonly DoubleParameterProposition AreSimilar = new DoubleParameterProposition((x, y) => x.IsSimilarTo(y));

        /// <summary>
        /// Whether two expressions are identical.
        /// </summary>
        public static readonly DoubleParameterProposition AreIdentical = new DoubleParameterProposition((x, y) => x.IsIdenticalTo(y));

        /// <summary>
        /// Whether two expressions are opposite.
        /// </summary>
        public static readonly DoubleParameterProposition AreOpposite = new DoubleParameterProposition((x, y) => x.IsOppositeOf(y));

        /// <summary>
        /// Whether two expressions are reciprocals.
        /// </summary>
        public static readonly DoubleParameterProposition AreReciprocals = new DoubleParameterProposition((x, y) => x.IsReciprocalOf(y));
        
        /// <summary>
        /// Whether two expressions are opposite reciprocals.
        /// </summary>
        public static readonly DoubleParameterProposition AreOppositeReciprocals = new DoubleParameterProposition((x, y) => x.IsReciprocalOf(-y));

        /// <summary>
        /// Whether a single input expression is equal to "0".
        /// </summary>
        public static readonly SingleParameterProposition IsZero = new SingleParameterProposition(x => x == 0);

        /// <summary>
        /// Whether a single input expression is equal to "1".
        /// </summary>
        public static readonly SingleParameterProposition IsOne = new SingleParameterProposition(x => x == 1);

        /// <summary>
        /// Whether the first expression of a pair is equal to "0". (Same as Propositions.IsZero)
        /// </summary>
        public static readonly DoubleParameterProposition FirstZero = new DoubleParameterProposition((x, y) => IsZero[x]);

        /// <summary>
        /// Whether the second expression of a pair is equal to "0".
        /// </summary>
        public static readonly DoubleParameterProposition SecondZero = new DoubleParameterProposition((x, y) => IsZero[y]);

        /// <summary>
        /// Whether either expression of a pair is equal to "0".
        /// </summary>
        public static readonly DoubleParameterProposition EitherZero = new DoubleParameterProposition((x, y) => IsZero[x] || IsZero[y]);

        /// <summary>
        /// Whether both expressions of a pair are equal to "0".
        /// </summary>
        public static readonly DoubleParameterProposition BothZero = new DoubleParameterProposition((x, y) => IsZero[x] && IsZero[y]);

        /// <summary>
        /// Whether the first expression of a pair is equal to "1". (Same as Propositions.IsOne)
        /// </summary>
        public static readonly DoubleParameterProposition FirstOne = new DoubleParameterProposition((x, y) => IsOne[x]);

        /// <summary>
        /// Whether the second expression of a pair is equal to "1".
        /// </summary>
        public static readonly DoubleParameterProposition SecondOne = new DoubleParameterProposition((x, y) => IsOne[y]);

        /// <summary>
        /// Whether either expression of a pair is equal to "1".
        /// </summary>
        public static readonly DoubleParameterProposition EitherOne = new DoubleParameterProposition((x, y) => IsOne[x] || IsOne[y]);

        /// <summary>
        /// Whether both expressions of a pair are equal to "1".
        /// </summary>
        public static readonly DoubleParameterProposition BothOne = new DoubleParameterProposition((x, y) => IsOne[x] && IsOne[y]);

        /// <summary>
        /// Whether the first expression of a pair is equal to "Infinity".
        /// </summary>
        public static readonly DoubleParameterProposition FirstInfinity = new DoubleParameterProposition((x, y) => x == Constant.Infinity);

        /// <summary>
        /// Whether the second expression of a pair is equal to "Infinity".
        /// </summary>
        public static readonly DoubleParameterProposition SecondInfinity = new DoubleParameterProposition((x, y) => y == Constant.Infinity);

        /// <summary>
        /// Whether either expression of a pair is equal to "Infinity".
        /// </summary>
        public static readonly DoubleParameterProposition EitherInfinity = new DoubleParameterProposition((x, y) => (x == Constant.Infinity) || (y == Constant.Infinity));

        /// <summary>
        /// Whether both expressions of a pair are equal to "Infinity".
        /// </summary>
        public static readonly DoubleParameterProposition BothInfinity = new DoubleParameterProposition((x, y) => (x == Constant.Infinity) && (y == Constant.Infinity));

        /// <summary>
        /// Whether both expressions of a pair are polynomials.
        /// </summary>
        public static readonly DoubleParameterProposition ArePolynomials = new DoubleParameterProposition((x, y) => (x is Polynomial) && (y is Polynomial));

        /// <summary>
        /// Whether an expressions is an integer.
        /// </summary>
        public static readonly SingleParameterProposition IsInteger = new SingleParameterProposition(x => (x is Value) && (x as Value).IsInteger());

        /// <summary>
        /// Whether an expression is an exponentiation of an expression by an integer power.
        /// </summary>
        public static readonly SingleParameterProposition IsIntegerPower = new SingleParameterProposition(x => (x is Exponentiation) && (x as Exponentiation).IsIntegerExponent());

        /// <summary>
        /// Whether an expression is an exponentiation of an expression by a positive integer power.
        /// </summary>
        public static readonly SingleParameterProposition IsPositiveIntegerPower = new SingleParameterProposition(x => (x is Exponentiation) && (x as Exponentiation).IsPositiveIntegerExponent());

        /// <summary>
        /// Whether an expression is an exponentiation of an expression by a positive integer power.
        /// </summary>
        public static readonly SingleParameterProposition IsNegativeIntegerPower = new SingleParameterProposition(x => (x is Exponentiation) && (x as Exponentiation).IsNegativeIntegerExponent());

        /// <summary>
        /// Whether two expressions are integers.
        /// </summary>
        public static readonly DoubleParameterProposition AreIntegers = new DoubleParameterProposition((x, y) => IsInteger[x] && IsInteger[y]);

        /// <summary>
        /// Whether an expression is a sum.
        /// </summary>
        public static readonly SingleParameterProposition IsSum = new SingleParameterProposition(x => (x is Sum));

        /// <summary>
        /// Whether an expression is a product.
        /// </summary>
        public static readonly SingleParameterProposition IsProduct = new SingleParameterProposition(x => (x is Product));

        /// <summary>
        /// Whether an expression is a quotient.
        /// </summary>
        public static readonly SingleParameterProposition IsQuotient = new SingleParameterProposition(x => (x is Quotient));

        /// <summary>
        /// Whether an expression is a difference.
        /// </summary>
        public static readonly SingleParameterProposition IsDifference = new SingleParameterProposition(x => (x is Difference));

        /// <summary>
        /// Whether an expression is a sum or difference.
        /// </summary>
        public static readonly SingleParameterProposition IsSumOrDifference = new SingleParameterProposition(x => IsSum[x] || IsDifference[x]);

        /// <summary>
        /// Whether two expressions are sums.
        /// </summary>
        public static readonly DoubleParameterProposition AreSums = new DoubleParameterProposition((x, y) => IsSum[x] && IsSum[y]);

        /// <summary>
        /// Whether both of two expressions are sums and/or differences.
        /// </summary>
        public static readonly DoubleParameterProposition AreSumsOrDifferences = new DoubleParameterProposition((x, y) => IsSumOrDifference[x] && IsSumOrDifference[y]);

        /// <summary>
        /// Whether either of two expressions are sums.
        /// </summary>
        public static readonly DoubleParameterProposition EitherSums = new DoubleParameterProposition((x, y) => IsSum[x] || IsSum[y]);

        /// <summary>
        /// Whether either of two expressions are sums and/or differences.
        /// </summary>
        public static readonly DoubleParameterProposition EitherSumsOrDifferences = new DoubleParameterProposition((x, y) => IsSumOrDifference[x] || IsSumOrDifference[y]);

        /// <summary>
        /// Whether this expression represents a negation (see remarks).
        /// </summary>
        /// <remarks>
        /// Examples: -1, -x, -(-4)
        /// Technically, "3" is a "negation" of "-3", but here we only care about items STORED as a negation.
        /// </remarks>
        public static readonly SingleParameterProposition IsNegation = new SingleParameterProposition(x => (x is Negation) || (IsValue[x] && (x as Value) < 0) || (IsProduct[x] && (x as Product).IsNegation()));

        /// <summary>
        /// Whether all of the children of an expression are negations (see remarks).
        /// </summary>
        /// <remarks>
        /// Example: {-1, -x} 
        /// Technically, "3" is a "negation" of "-3", but here we only care about items STORED as a negation.
        /// </remarks>
        public static readonly SingleParameterProposition HasAllNegatedChildren = new SingleParameterProposition(x => x.ChildrenPassProposition(IsNegation));

        /// <summary>
        /// Whether two expressions have all negated children (see Propositions.HasAllNegatedChildren).
        /// </summary>
        public static readonly DoubleParameterProposition HaveAllNegatedChildren = new DoubleParameterProposition((x, y) => HasAllNegatedChildren[x] && HasAllNegatedChildren[y]);
    }
}