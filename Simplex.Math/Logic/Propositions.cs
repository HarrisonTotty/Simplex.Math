using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;
using Simplex.Math.Irreducibles;
using Simplex.Math.Operations;
using Simplex.Math.Operations.Special;
using Simplex.Math.Operations.Elementary;
using Simplex.Math.Classification;
using Simplex.Math.Sets;
using Simplex.Math.Arrays;
using Simplex.Math.Functions;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a static collection of commonly used propositions.
    /// </summary>
    public static class Propositions
    {
        /// <summary>
        /// A proposition that always returns true reguardless of any input expression.
        /// </summary>
        public static readonly SingleParameterProposition TRUE = new SingleParameterProposition(x => true);

        /// <summary>
        /// A proposition that always returns true reguardless of any input expressions.
        /// </summary>
        public static readonly DoubleParameterProposition BinaryTRUE = new DoubleParameterProposition((x, y) => true);

        /// <summary>
        /// A proposition that always returns false reguardless of any input expression.
        /// </summary>
        public static readonly SingleParameterProposition FALSE = new SingleParameterProposition(x => false);

        /// <summary>
        /// A proposition that always returns false reguardless of any input expressions.
        /// </summary>
        public static readonly DoubleParameterProposition BinaryFALSE = new DoubleParameterProposition((x, y) => false);

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
        public static readonly SingleParameterProposition HasDescreteValue = new SingleParameterProposition(x => (x is Value) || ((x is Constant) && (x as Constant).HasDescreteValue));

        /// <summary>
        /// Whether a pair of values/constants have descrete values (see remarks).
        /// </summary>
        /// <remarks>
        /// The pair (Pi, 3) both have descrete values, but the pair (Pi, C) do not.
        /// </remarks>
        public static readonly DoubleParameterProposition HaveDescreteValues = new DoubleParameterProposition((x, y) => ((x is Value) || ((x is Constant) && (x as Constant).HasDescreteValue)) && ((y is Value) || ((y is Constant) && (y as Constant).HasDescreteValue)));

        /// <summary>
        /// Whether one value/constant has the same descrete value as another value/constant (see remarks).
        /// </summary>
        /// <remarks>
        /// Examples: 2 = 2, Pi = 3.14...
        /// </remarks>
        public static readonly DoubleParameterProposition HaveSameDescreteValue = new DoubleParameterProposition((x, y) => HaveSameDescreteValue_Body(x, y));
        private static bool HaveSameDescreteValue_Body(Expression E1, Expression E2)
        {
            double E1V = double.NaN;
            double E2V = double.NaN;

            if (E1 is Value) E1V = (E1 as Value).InnerValue;
            if (E2 is Value) E2V = (E2 as Value).InnerValue;
            if (E1 is Constant) if ((E1 as Constant).HasDescreteValue) E1V = (E1 as Constant).Value.InnerValue;
            if (E2 is Constant) if ((E2 as Constant).HasDescreteValue) E2V = (E2 as Constant).Value.InnerValue;

            if (E1V == double.NaN || E2V == double.NaN) return false;
            if (E1V == E2V) return true;

            return false;
        }

        /// <summary>
        /// Whether two value objects represent the same value.
        /// </summary>
        public static readonly DoubleParameterProposition HaveSameStrictValue = new DoubleParameterProposition((x, y) => ((x is Value) && (y is Value)) && ((x as Value).InnerValue == (y as Value).InnerValue));

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
        public static readonly DoubleParameterProposition AreOperations = new DoubleParameterProposition((x, y) => (x is Operation) && (y is Operation));

        /// <summary>
        /// Whether an expression is a unary operation (an operation that accepts 1 parameter).
        /// </summary>
        /// <remarks>
        /// Note that we will not assume that the class for the operation inherits the UnaryOperation class.
        /// </remarks>
        public static readonly SingleParameterProposition IsUnaryOperation = new SingleParameterProposition(x => (x is Operation) && (x as Operation).Arity == 1);

        /// <summary>
        /// Whether an expression is a binary operation (an operation that accepts 2 parameters).
        /// </summary>
        /// <remarks>
        /// Note that we will not assume that the class for the operation inherits the BinaryOperation class.
        /// </remarks>
        public static readonly SingleParameterProposition IsBinaryOperation = new SingleParameterProposition(x => (x is Operation) && (x as Operation).Arity == 2);

        /// <summary>
        /// Whether an expression is a trinary operation (an operation that accepts 3 parameters).
        /// </summary>
        /// <remarks>
        /// Note that we will not assume that the class for the operation inherits the TrinaryOperation class.
        /// </remarks>
        public static readonly SingleParameterProposition IsTrinaryOperation = new SingleParameterProposition(x => (x is Operation) && (x as Operation).Arity == 3);

        /// <summary>
        /// Whether a pair of expressions have one or more child expressions.
        /// </summary>
        public static readonly DoubleParameterProposition HaveChildExpressions = new DoubleParameterProposition((x, y) => x.HasChildren() && y.HasChildren());

        /// <summary>
        /// Whether two expressions have equal child expressions (non-commutative) (see remarks).
        /// </summary>
        /// <remarks>
        /// The sets of children {x, y} and {x, y} would pass this test, however {x, y} and {y, x} would not.
        /// </remarks>
        public static readonly DoubleParameterProposition HaveEqualChildExpressions = new DoubleParameterProposition((x, y) => (x.HasChildren() && y.HasChildren()) && HaveEqualChildExpressions_Body(x, y));
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
        public static readonly DoubleParameterProposition HaveEqualChildExpressions_Commutative = new DoubleParameterProposition((x, y) => (x.HasChildren() && y.HasChildren()) && HaveEqualChildExpressions_Commutative_Body(x, y));
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
        /// Whether two expressions have equal child expressions, respecting associative rules (see remarks).
        /// Requires for both of these expressions to be associative binary properties.
        /// </summary>
        /// <remarks>
        /// The associative property states that a sequence of two or more operations of this same type will yeild 
        /// the same result reguarless of the order that the operations are performed so long as the sequence of
        /// the operands is not changed.
        /// Addition is associative because (2 + 3) + 4 = 2 + (3 + 4) = 9
        /// </remarks>
        //public static readonly DoubleParameterProposition HaveEqualChildExpressions_Associative = new DoubleParameterProposition((x, y) => AreAssociativeOperations[x, y] && HaveEqualChildExpressions_Associative_Body(x, y));
        //private static bool HaveEqualChildExpressions_Associative_Body(Expression E1, Expression E2)
        //{
        //    //First, lets make sure both expressions have the same number of base children
        //    if (E1.ChildExpressions.Count != E2.ChildExpressions.Count) return false;

        //    //We will group our inputs as either product/quotient pairs or sum/difference pairs

        //    //If everything passes, then we return true
        //    return true;
        //}


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
        public static readonly SingleParameterProposition IsDescreteConstant = new SingleParameterProposition(x => (x is Constant) && (x as Constant).HasDescreteValue);

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
        public static readonly DoubleParameterProposition AreCoefficients = new DoubleParameterProposition((x, y) => ((x is Constant) || (x is Value) || (x is ArithmeticOperation && (x as ArithmeticOperation).IsCoefficient())) && ((y is Constant) || (y is Value) || (y is ArithmeticOperation && (y as ArithmeticOperation).IsCoefficient())));

        /// <summary>
        /// Whether two expressions are both values.
        /// </summary>
        public static readonly DoubleParameterProposition AreValues = new DoubleParameterProposition((x, y) => (x is Value) && (y is Value));

        /// <summary>
        /// Whether two expressions both contain values.
        /// </summary>
        public static readonly DoubleParameterProposition ContainValues = new DoubleParameterProposition((x, y) => x.ContainsExpressionType<Value>() && y.ContainsExpressionType<Value>());

        /// <summary>
        /// Whether two expressions are both variables.
        /// </summary>
        public static readonly DoubleParameterProposition AreVariables = new DoubleParameterProposition((x, y) => (x is Variable) && (y is Variable));

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
        public static readonly DoubleParameterProposition AreConstants = new DoubleParameterProposition((x, y) => (x is Constant) && (y is Constant));

        /// <summary>
        /// Whether two variable/constant expressions have the same ID (by casting to the appropriate type).
        /// </summary>
        public static readonly DoubleParameterProposition HaveSameID = new DoubleParameterProposition((x, y) => (((x is Variable) && (y is Variable)) && ((x as Variable).ID == (y as Variable).ID)) || (((x is Constant) && (y is Constant)) && ((x as Constant).ID == (y as Constant).ID)));

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
        public static readonly DoubleParameterProposition AreOpposite = new DoubleParameterProposition((x, y) => x == -y);

        /// <summary>
        /// Whether two expressions are reciprocals.
        /// </summary>
        public static readonly DoubleParameterProposition AreReciprocals = new DoubleParameterProposition((x, y) => (AreValues[x, y] && (x as Value).InnerValue == 1 / (y as Value).InnerValue) || (x == new Quotient(1, y)) || (x == new Exponentiation(y, -1)));
        
        /// <summary>
        /// Whether two expressions are opposite reciprocals.
        /// </summary>
        public static readonly DoubleParameterProposition AreOppositeReciprocals = new DoubleParameterProposition((x, y) => (AreValues[x, y] && (x as Value).InnerValue == -(1 / (y as Value).InnerValue)) || (x == -new Quotient(1, y)) || (x == -new Exponentiation(y, -1)));

        /// <summary>
        /// Whether a single input expression is equal to "0".
        /// </summary>
        public static readonly SingleParameterProposition IsZero = new SingleParameterProposition(x => ((x is Value) && (x as Value).InnerValue == 0) || (!(x is Value) && x == 0));

        /// <summary>
        /// Whether a single input expression is equal to "1".
        /// </summary>
        public static readonly SingleParameterProposition IsOne = new SingleParameterProposition(x => ((x is Value) && (x as Value).InnerValue == 1) || (!(x is Value) && x == 1));

        /// <summary>
        /// Whether a single input expression is equal to "-1".
        /// </summary>
        public static readonly SingleParameterProposition IsNegativeOne = new SingleParameterProposition(x => ((x is Value) && (x as Value).InnerValue == -1) || (!(x is Value) && x == -1));


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
        /// Whether the second expression of a pair is equal to "-1".
        /// </summary>
        public static readonly DoubleParameterProposition SecondNegativeOne = new DoubleParameterProposition((x, y) => IsNegativeOne[y]);

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
        public static readonly DoubleParameterProposition FirstInfinity = new DoubleParameterProposition((x, y) => x == Constant.PositiveInfinity);

        /// <summary>
        /// Whether the second expression of a pair is equal to "Infinity".
        /// </summary>
        public static readonly DoubleParameterProposition SecondInfinity = new DoubleParameterProposition((x, y) => y == Constant.NegativeInfinity);

        /// <summary>
        /// Whether either expression of a pair is equal to "Infinity".
        /// </summary>
        public static readonly DoubleParameterProposition EitherInfinity = new DoubleParameterProposition((x, y) => (x == Constant.PositiveInfinity) || (y == Constant.PositiveInfinity));

        /// <summary>
        /// Whether both expressions of a pair are equal to "Infinity".
        /// </summary>
        public static readonly DoubleParameterProposition BothInfinity = new DoubleParameterProposition((x, y) => (x == Constant.PositiveInfinity) && (y == Constant.PositiveInfinity));

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
        public static readonly DoubleParameterProposition AreIntegers = new DoubleParameterProposition((x, y) => ((x is Value) && (x as Value).IsInteger()) && ((y is Value) && (y as Value).IsInteger()));

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
        public static readonly SingleParameterProposition IsSumOrDifference = new SingleParameterProposition(x => (x is Sum) || (x is Difference));

        /// <summary>
        /// Whether two expressions are sums.
        /// </summary>
        public static readonly DoubleParameterProposition AreSums = new DoubleParameterProposition((x, y) => (x is Sum) && (y is Sum));

        /// <summary>
        /// Whether both of two expressions are sums and/or differences.
        /// </summary>
        public static readonly DoubleParameterProposition AreSumsOrDifferences = new DoubleParameterProposition((x, y) => ((x is Sum) || (x is Difference)) && ((y is Sum) || (y is Difference)));

        /// <summary>
        /// Whether either of two expressions are sums.
        /// </summary>
        public static readonly DoubleParameterProposition EitherSums = new DoubleParameterProposition((x, y) => (x is Sum) || (y is Sum));

        /// <summary>
        /// Whether either of two expressions are sums and/or differences.
        /// </summary>
        public static readonly DoubleParameterProposition EitherSumsOrDifferences = new DoubleParameterProposition((x, y) => ((x is Sum) || (x is Difference)) || ((y is Sum) || (y is Difference)));

        /// <summary>
        /// Whether this expression represents a negation (see remarks).
        /// </summary>
        /// <remarks>
        /// Examples: -1, -x, -(-4)
        /// Technically, "3" is a "negation" of "-3", but here we only care about items STORED as a negation.
        /// </remarks>
        public static readonly SingleParameterProposition IsNegation = new SingleParameterProposition(x => (x is Negation) || ((x is Value) && (x as Value) < 0) || ((x is Product) && (x as Product).IsNegation()));

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
        public static readonly DoubleParameterProposition HaveAllNegatedChildren = new DoubleParameterProposition((x, y) => x.ChildrenPassProposition(IsNegation) && y.ChildrenPassProposition(IsNegation));

        /// <summary>
        /// Whether this expression is the imaginary unit (i).
        /// </summary>
        public static readonly SingleParameterProposition IsImaginaryUnit = new SingleParameterProposition(x => (x is ImaginaryUnit));

        /// <summary>
        /// Whether this expression is an operand (intrinsic irreducible).
        /// </summary
        public static readonly SingleParameterProposition IsIntrinsicIrreducible = new SingleParameterProposition(x => (x is Irreducible) || (x is IntrinsicIrreducible));

        /// <summary>
        /// Whether a pair of expressions are intrinsic irreducibles (operands).
        /// </summary>
        public static readonly DoubleParameterProposition AreIntrinsicIrreducibles = new DoubleParameterProposition((x, y) => ((x is Irreducible) || (x is IntrinsicIrreducible)) && ((y is Irreducible) || (y is IntrinsicIrreducible)));

        /// <summary>
        /// Whether a pair of expressions are binary operations.
        /// </summary>
        public static readonly DoubleParameterProposition AreBinaryOperations = new DoubleParameterProposition((x, y) => ((x is Operation) && (x as Operation).Arity == 2) && ((y is Operation) && (y as Operation).Arity == 2));

        /// <summary>
        /// Whether this expression represents an associative operation (see remarks).
        /// </summary>
        /// <remarks>
        /// The associative property states that a sequence of two or more operations of this same type will yeild 
        /// the same result reguarless of the order that the operations are performed so long as the sequence of
        /// the operands is not changed.
        /// Addition is associative because (2 + 3) + 4 = 2 + (3 + 4) = 9
        /// </remarks>
        public static readonly SingleParameterProposition IsAssociativeOperation = new SingleParameterProposition(x => (x is BinaryOperation) && (x as BinaryOperation).IsAssociative);

        /// <summary>
        /// Whether this expression represents a commutative operation (see remarks).
        /// </summary>
        /// <remarks>
        /// Whether switching the order of the operands of this operation produces the same result.
        /// Addition and multiplication are commutative since "a + b" is equal to "b + a" etc.
        /// Subtraction and division are not commutative since "a - b" is not equal to "b - a" etc.
        /// </remarks>
        public static readonly SingleParameterProposition IsCommutativeOperation = new SingleParameterProposition(x => (x is BinaryOperation) && (x as BinaryOperation).IsCommutative);

        /// <summary>
        /// Whether this expression represents an anticommutative operation (see remarks).
        /// </summary>
        /// <remarks>
        /// Whether switching the order of the operands of this operation negates the result.
        /// Addition, multiplication, division, etc. are not anticommutative since "a + b" = "b + a" etc.
        /// Subtraction is anticommutative since "a - b" = "-(b - a)".
        /// </remarks>
        public static readonly SingleParameterProposition IsAnticommutativeOperation = new SingleParameterProposition(x => (x is BinaryOperation) && (x as BinaryOperation).IsAnticommutative);

        /// <summary>
        /// Whether two expressions are associative operations (see Propositions.IsAssociativeOperation).
        /// </summary>
        public static readonly DoubleParameterProposition AreAssociativeOperations = new DoubleParameterProposition((x, y) => IsAssociativeOperation[x] && IsAssociativeOperation[y]);

        /// <summary>
        /// Whether this expression is the negation of a sum or difference.
        /// </summary>
        public static readonly SingleParameterProposition IsNegationOfSumOrDifference = new SingleParameterProposition(x => (x is Product) && (x as Product).IsNegation() && (IsSumOrDifference[(x as Product).RightExpression] || IsSumOrDifference[(x as Product).LeftExpression]));

        /// <summary>
        /// Whether two expressions both represent the negation of a sum or difference.
        /// </summary>
        public static readonly DoubleParameterProposition AreNegationOfSumOrDifference = new DoubleParameterProposition((x, y) => IsNegationOfSumOrDifference[x] && IsNegationOfSumOrDifference[y]);

        /// <summary>
        /// Whether either of two expressions represent the negation of a sum or difference.
        /// </summary>
        public static readonly DoubleParameterProposition EitherNegationOfSumOrDifference = new DoubleParameterProposition((x, y) => IsNegationOfSumOrDifference[x] || IsNegationOfSumOrDifference[y]);

        /// <summary>
        /// Whether this expression qualifies for conversion into a collapsed sum operation (used for evaluating associative properties).
        /// </summary>
        public static readonly SingleParameterProposition QualifiesForCSO = new SingleParameterProposition(x => QualifiesForCSO_Body(x));
        private static bool QualifiesForCSO_Body(Expression x)
        {
            //In order to qualify for collapse, this expression must have a sum or difference as a child

            //If this is a negation (product)
            if ((x is Product) && (x as Product).IsNegation() && (IsSumOrDifference[(x as Product).RightExpression] || IsSumOrDifference[(x as Product).LeftExpression]))
            {
                //Try again with the inner term
                if ((x as Product).LeftExpression == -1) return QualifiesForCSO_Body((x as Product).RightExpression);
                else return QualifiesForCSO_Body((x as Product).LeftExpression);
            }

            //If this is a sum
            if (x is Sum)
            {
                if (IsSumOrDifference[(x as Sum).LeftExpression] || IsNegationOfSumOrDifference[(x as Sum).LeftExpression]) return true;
                if (IsSumOrDifference[(x as Sum).RightExpression] || IsNegationOfSumOrDifference[(x as Sum).RightExpression]) return true;
            }

            //If this is a difference
            if (x is Difference)
            {
                if (IsSumOrDifference[(x as Difference).LeftExpression] || IsNegationOfSumOrDifference[(x as Difference).LeftExpression]) return true;
                if (IsSumOrDifference[(x as Difference).RightExpression] || IsNegationOfSumOrDifference[(x as Difference).RightExpression]) return true;
            }

            //If nothing works
            return false;
        }

        /// <summary>
        /// Whether this expression qualifies for conversion into a collapsed product operation (used for evaluating associative properties).
        /// </summary>
        public static readonly SingleParameterProposition QualifiesForCPO = new SingleParameterProposition(x => QualifiesForCPO_Body(x));
        private static bool QualifiesForCPO_Body(Expression x)
        {
            //In order to qualify for collapse, this expression must have a product or quotient as a child

            //If this is a -1th exponentiation
            if ((x is Exponentiation) && ((x as Exponentiation).Exponent == -1) && IsProductOrQuotient[(x as Exponentiation).Base])
            {
                //Try again with the inner term
                return QualifiesForCPO_Body((x as Exponentiation).Base);
            }

            //If this is a product
            if (x is Product)
            {
                if (IsProductOrQuotient[(x as Product).LeftExpression] || IsNegativeOneExponentiationOfProductOrQuotient[(x as Product).LeftExpression]) return true;
                if (IsProductOrQuotient[(x as Product).RightExpression] || IsNegativeOneExponentiationOfProductOrQuotient[(x as Product).RightExpression]) return true;
            }

            //If this is a quotient
            if (x is Quotient)
            {
                if (IsProductOrQuotient[(x as Quotient).Numerator] || IsNegativeOneExponentiationOfProductOrQuotient[(x as Quotient).Numerator]) return true;
                if (IsProductOrQuotient[(x as Quotient).Denominator] || IsNegativeOneExponentiationOfProductOrQuotient[(x as Quotient).Denominator]) return true;
            }

            //If nothing works
            return false;
        }

        /// <summary>
        /// Whether two expressions both qualify for conversion into collapsed sum objects.
        /// </summary>
        public static readonly DoubleParameterProposition QualifyForCSO = new DoubleParameterProposition((x, y) => QualifiesForCSO_Body(x) && QualifiesForCSO_Body(y));

        /// <summary>
        /// Whether two expressions both qualify for conversion into collapsed product objects.
        /// </summary>
        public static readonly DoubleParameterProposition QualifyForCPO = new DoubleParameterProposition((x, y) => QualifiesForCPO_Body(x) && QualifiesForCPO_Body(y));

        /// <summary>
        /// Whether two CSO-candidate expressions are equal by converting each into a collapsed sum object.
        /// </summary>
        public static readonly DoubleParameterProposition EqualityTestViaCSO = new DoubleParameterProposition((x, y) => CollapsedSumOperation.Create(x) == CollapsedSumOperation.Create(y));

        /// <summary>
        /// Whether two CPO-candidate expressions are equal by converting each into a collapsed product object.
        /// </summary>
        public static readonly DoubleParameterProposition EqualityTestViaCPO = new DoubleParameterProposition((x, y) => CollapsedProductOperation.Create(x) == CollapsedProductOperation.Create(y));

        /// <summary>
        /// Whether two expressions are multiples of the same expression.
        /// </summary>
        public static readonly DoubleParameterProposition AreMultiplesOfSameExpression = new DoubleParameterProposition((x, y) => AreMultiplesOfSameExpression_Body(x, y));
        private static bool AreMultiplesOfSameExpression_Body(Expression x, Expression y)
        {
            if (x is Product)
            {
                //Direct multiples (3x compared to x)
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
                else return false;

                if (xother == y) return true;


                //Indirect multiples (6x compared to 3x)
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
                    else return false;

                    if (xother == yother) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Whether an input expression is an integer multiple of another expression.
        /// </summary>
        /// <remarks>
        /// Example: 3x is an integer multiple of x
        /// </remarks>
        public static readonly DoubleParameterProposition IsIntegerMultipleOfExpression = new DoubleParameterProposition((x, y) => IsIntegerMultipleOfExpression_Body(x, y));
        private static bool IsIntegerMultipleOfExpression_Body(Expression x, Expression y)
        {
            if (x is Product)
            {
                //Direct multiples (3x compared to x)
                var xp = x as Product;
                Value xval;
                Expression xother;

                if ((xp.LeftExpression is Value) && (xp.LeftExpression as Value).IsInteger())
                {
                    if (xp.RightExpression == y) return true;
                    xval = xp.LeftExpression as Value;
                    xother = xp.RightExpression;
                }
                else if ((xp.RightExpression is Value) && (xp.RightExpression as Value).IsInteger())
                {
                    if (xp.LeftExpression == y) return true;
                    xval = xp.RightExpression as Value;
                    xother = xp.LeftExpression;
                }
                else return false;

                
                //Indirect multiples (6x compared to 3x)
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
                    else return false;

                    if (xother == yother)
                    {
                        if (xval.InnerValue % yval.InnerValue == 0) return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Whether a particular input expression is equivalent to the -1th exponentiation of a product or quotient.
        /// </summary>
        public static readonly SingleParameterProposition IsNegativeOneExponentiationOfProductOrQuotient = new SingleParameterProposition(x => (x is Exponentiation) && ((x as Exponentiation).Exponent == -1) && (((x as Exponentiation).Base is Product) || ((x as Exponentiation).Base is Quotient)));

        /// <summary>
        /// Whether a pair of input expressions are both equivalent to the -1th exponentiation of a product or quotient.
        /// </summary>
        public static readonly DoubleParameterProposition AreNegativeOneExponentiationOfProductOrQuotient = new DoubleParameterProposition((x, y) => IsNegativeOneExponentiationOfProductOrQuotient[x] && IsNegativeOneExponentiationOfProductOrQuotient[y]);

        /// <summary>
        /// Whether either of a pair of input expressions are equivalent to the -1th exponentiation of a product or quotient.
        /// </summary>
        public static readonly DoubleParameterProposition EitherNegativeOneExponentiationOfProductOrQuotient = new DoubleParameterProposition((x, y) => IsNegativeOneExponentiationOfProductOrQuotient[x] || IsNegativeOneExponentiationOfProductOrQuotient[y]);

        /// <summary>
        /// Whether an input expression is either a product or quotient.
        /// </summary>
        public static readonly SingleParameterProposition IsProductOrQuotient = new SingleParameterProposition(x => (x is Product) || (x is Quotient));

        /// <summary>
        /// Whether a pair of input expressions are both either products or quotients.
        /// </summary>
        public static readonly DoubleParameterProposition AreProductOrQuotient = new DoubleParameterProposition((x, y) => ((x is Product) || (x is Quotient)) && ((y is Product) || (y is Quotient)));

        /// <summary>
        /// Whether either of a pair of input expressions are either products or quotients.
        /// </summary>
        public static readonly DoubleParameterProposition EitherProductOrQuotient = new DoubleParameterProposition((x, y) => ((x is Product) || (x is Quotient)) || ((y is Product) || (y is Quotient)));

        /// <summary>
        /// Whether an input expression is a tensor.
        /// </summary>
        public static readonly SingleParameterProposition IsTensor = new SingleParameterProposition(x => x is Tensor);

        /// <summary>
        /// Whether an input expression is an inverse (see remarks).
        /// </summary>
        /// <remarks>
        /// Examples: 1/3   OR      1/x    OR      x^-1
        /// </remarks>
        public static readonly SingleParameterProposition IsInverse = new SingleParameterProposition(x => ((x is Value) && ((x as Value) < 1) && ((x as Value) > -1)) || ((x is Exponentiation) && (x as Exponentiation).Exponent == -1) || ((x is Quotient) && (x as Quotient).Numerator == 1));

        /// <summary>
        /// Whether an input expression is an inverse (not including values) (see remarks).
        /// </summary>
        /// <remarks>
        /// Examples: 1/x   OR      x^-1
        /// </remarks>
        public static readonly SingleParameterProposition IsNonValueInverse = new SingleParameterProposition(x => ((x is Exponentiation) && (x as Exponentiation).Exponent == -1) || ((x is Quotient) && (x as Quotient).Numerator == 1));

        /// <summary>
        /// Whether two binary operations have equal first operands and opposite second operands.
        /// </summary>
        public static readonly DoubleParameterProposition OperationsHaveEqualFirstOppositeSecondOperands = new DoubleParameterProposition((x, y) => AreBinaryOperations[x, y] && (x.ChildExpressions[0] == y.ChildExpressions[0]) && (x.ChildExpressions[1] == -y.ChildExpressions[1]));

        /// <summary>
        /// Whether two binary operations have equal first operands and inverted second operands.
        /// </summary>
        public static readonly DoubleParameterProposition OperationsHaveEqualFirstInverseSecondOperands = new DoubleParameterProposition((x, y) => AreBinaryOperations[x, y] && (x.ChildExpressions[0] == y.ChildExpressions[0]) && AreReciprocals[x.ChildExpressions[1], y.ChildExpressions[1]]);

        /// <summary>
        /// Whether an input expression is an exponentiation (a base expression raised to a particular exponent).
        /// </summary>
        public static readonly SingleParameterProposition IsExponentiation = new SingleParameterProposition(x => x is Exponentiation);

        /// <summary>
        /// Whether an input expression is a function.
        /// </summary>
        public static readonly SingleParameterProposition IsFunction = new SingleParameterProposition(x => x is Function);

        /// <summary>
        /// Whether both input expressions are functions.
        /// </summary>
        public static readonly DoubleParameterProposition AreFunctions = new DoubleParameterProposition((x, y) => x is Function && y is Function);

        /// <summary>
        /// Whether two expressions are both exponentiations.
        /// </summary>
        public static readonly DoubleParameterProposition BothExponentiations = new DoubleParameterProposition((x, y) => (x is Exponentiation) && (y is Exponentiation));

        /// <summary>
        /// Whether either of two expressions are exponentiations.
        /// </summary>
        public static readonly DoubleParameterProposition EitherExponentiations = new DoubleParameterProposition((x, y) => (x is Exponentiation) || (y is Exponentiation));

        /// <summary>
        /// Determines the equality between a quotient and an exponentiation.
        /// </summary>
        public static readonly DoubleParameterProposition QuotientExponentiationEquality = new DoubleParameterProposition((x, y) => QuotientExponentiationEquality_Body(x, y));
        private static bool QuotientExponentiationEquality_Body(Expression x, Expression y)
        {
            if ((x is Quotient) && (y is Exponentiation))
            {
                Quotient Q = x as Quotient;
                Exponentiation E = y as Exponentiation;
                if (Q.Numerator == 1 && E.Exponent == -1 && Q.Denominator == E.Base) return true;
            }
            else if ((x is Exponentiation) && (y is Quotient))
            {
                Quotient Q = y as Quotient;
                Exponentiation E = x as Exponentiation;
                if (Q.Numerator == 1 && E.Exponent == -1 && Q.Denominator == E.Base) return true;
            }

            return false;
        }

        /// <summary>
        /// Whether an input expression is a transformable operation.
        /// </summary>
        public static readonly SingleParameterProposition IsTransformableOperation = new SingleParameterProposition(x => x is Operation && (x as Operation).CanTransform());

        /// <summary>
        /// Whether a pair of input expressions are transformable operations
        /// </summary>
        public static readonly DoubleParameterProposition AreTransformableOperations = new DoubleParameterProposition((x, y) => (x is Operation && (x as Operation).CanTransform()) && (y is Operation && (y as Operation).CanTransform()));

        /// <summary>
        /// Whether the first input expression simplifies to the second input expression
        /// </summary>
        public static readonly DoubleParameterProposition XSimplifiesToY = new DoubleParameterProposition((x, y) => Math.Simplify(x).IsIdenticalTo(y));

        /// <summary>
        /// Whether the first input expression expands to the second input expression
        /// </summary>
        public static readonly DoubleParameterProposition XExpandsToY = new DoubleParameterProposition((x, y) => Math.Expand(x).IsIdenticalTo(y));

        /// <summary>
        /// Whether the first input expression contracts to the second input expression
        /// </summary>
        public static readonly DoubleParameterProposition XContractsToY = new DoubleParameterProposition((x, y) => Math.Contract(x).IsIdenticalTo(y));
    }
}