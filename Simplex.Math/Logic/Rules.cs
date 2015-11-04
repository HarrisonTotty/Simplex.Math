using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Operands;
using Simplex.Math.Core;
using Simplex.Math.Sets;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a static collection of commonly used rules and arrays of rules.
    /// </summary>
    public static class Rules
    {

        /// <summary>
        /// The pre-built sequence of rules that are used during form classification.
        /// </summary>
        public static readonly Rule[] ExpressionForm = new Rule[]
        {   
            // x -> x
            new Rule(Propositions.IsVariable, Transforms.ReturnExpression),
            // 5 -> C   OR   3CK -> C   OR   (2 - C) -> C      
            new Rule(Propositions.IsCoefficient, Transforms.ToGenericConstant)
        };


        /// <summary>
        /// The pre-built sequence of rules that we will use to calculate sums.
        /// </summary>
        public static readonly Rule[] Sum = new Rule[]
        {   
            // This is not necessary because (Propositions.FirstZero -> Transforms.ReturnSecondExpression) does it for us.
            //new Rule(Propositions.BothZero, Transforms.ToZero),
            // 2 + 3 = 5
            new Rule(Propositions.AreValues, Transforms.ValueAdd),
            // x + x = 2x
            new Rule(Propositions.AreEqual, Transforms.DoubleExpression),
            // x + -x = 0
            new Rule(Propositions.AreOpposite, Transforms.ToZero),
            // 0 + x = x
            new Rule(Propositions.FirstZero, Transforms.ReturnSecondExpression),
            // x + 0 = x
            new Rule(Propositions.SecondZero, Transforms.ReturnFirstExpression),
            // 3x + 4x = 7x
            new Rule(Propositions.AreMultiplesOfSameExpression, Transforms.AddMultiples),
            // Inf + x = Inf
            new Rule(Propositions.EitherInfinity, Transforms.ToInfinity),
            // (x + 3) + (y - 2) = x + y + 1
            new Rule(Propositions.EitherSumsOrDifferences, Transforms.AddViaCSOConversion),
            // -(x + 3) + (y - 2) = -x + y -5
            new Rule(Propositions.EitherNegationOfSumOrDifference, Transforms.AddViaCSOConversion),
            // 3x^2 + 2x^2 = 5x^2
            //new Rule(Propositions.ArePolynomials, Transforms.PolynomialAdd)
        };

        /// <summary>
        /// The pre-built sequence of rules that we will use to calculate differences.
        /// </summary>
        public static readonly Rule[] Difference = new Rule[]
        {   
            // This is not necessary because (Propositions.FirstZero -> Transforms.ReturnSecondExpression) does it for us.
            new Rule(Propositions.BothZero, Transforms.ToZero),
            // 2 - 3 = -1
            new Rule(Propositions.AreValues, Transforms.ValueSubtract),
            // x - x = 0
            new Rule(Propositions.AreEqual, Transforms.ToZero),
            // x - -x = 2x
            new Rule(Propositions.AreOpposite, Transforms.DoubleExpression),
            // 0 - x = -x
            new Rule(Propositions.FirstZero, Transforms.NegateSecondExpression),
            // x - 0 = x
            new Rule(Propositions.SecondZero, Transforms.ReturnFirstExpression),
            // 3x - 4x = -x
            new Rule(Propositions.AreMultiplesOfSameExpression, Transforms.SubtractMultiples),
            // Inf - x = Inf
            new Rule(Propositions.FirstInfinity, Transforms.ToInfinity),
            // x - Inf = -Inf
            new Rule(Propositions.SecondInfinity, Transforms.ToNegativeInfinity),
            // (x + 3) - (y - 2) = x - y + 4
            new Rule(Propositions.EitherSumsOrDifferences, Transforms.SubtractViaCSOConversion),
            // -(x + 3) - (y - 2) = -x - y - 1
            new Rule(Propositions.EitherNegationOfSumOrDifference, Transforms.SubtractViaCSOConversion),
        };

        /// <summary>
        /// The pre-built sequence of rules that we will use to calculate products.
        /// </summary>
        public static readonly Rule[] Product = new Rule[]
        {   
            // 2 * 3 = 6
            new Rule(Propositions.AreValues, Transforms.ValueMultiply),
            // x * x = x^2
            new Rule(Propositions.AreEqual, Transforms.SquareExpression),
            // x * (1 / x) = 1
            new Rule(Propositions.AreReciprocals, Transforms.ToOne),
            // 1 * x = x
            new Rule(Propositions.FirstOne, Transforms.ReturnSecondExpression),
            // x * 1 = x
            new Rule(Propositions.SecondOne, Transforms.ReturnFirstExpression),
            // 0 * x = 0
            new Rule(Propositions.FirstZero, Transforms.ToZero),
            // x * 0 = 0
            new Rule(Propositions.SecondZero, Transforms.ToZero),
            // Inf * x = Inf
            new Rule(Propositions.EitherInfinity, Transforms.ToInfinity),
            // 3 * (x + 5) = 3x + 15
            new Rule(Propositions.EitherSumsOrDifferences, Transforms.DistributeMultiply),
            // x^2 * x = x^3     AND     x^2 * x^3 = x^5
            new Rule(Propositions.EitherExponentiations, Transforms.MultiplyExponentiations),
            // (x * 3) * (y * 2) = 6 * x * y
            new Rule(Propositions.EitherProductOrQuotient, Transforms.MultiplyViaCPOConversion),
            // (x * 3)^-1 * (y * 2) = (2 / 3) * (x / y)
            new Rule(Propositions.EitherNegativeOneExponentiationOfProductOrQuotient, Transforms.MultiplyViaCPOConversion),
        };

        /// <summary>
        /// The pre-built sequence of rules that we will use to calculate quotients.
        /// </summary>
        public static readonly Rule[] Quotient = new Rule[]
        {   
            // 1 / 0 = Inf      VERY IMPORTANT THAT THIS IS FIRST!
            new Rule(Propositions.SecondZero, Transforms.ToInfinity),
            // 2 / 3 = 0.333333
            new Rule(Propositions.AreValues, Transforms.ValueDivide),
            // x / x = 1
            new Rule(Propositions.AreEqual, Transforms.ToOne),
            // x / (1 / x) = x^2
            new Rule(Propositions.AreReciprocals, Transforms.SquareExpression),
            // x / 1 = x
            new Rule(Propositions.SecondOne, Transforms.ReturnFirstExpression),
            // 0 / x = 0
            new Rule(Propositions.FirstZero, Transforms.ToZero),
            // x / Inf = 0
            new Rule(Propositions.SecondInfinity, Transforms.ToZero),
            // x^2 / x = x     AND     x^2 / x^3 = 1 / x
            new Rule(Propositions.EitherExponentiations, Transforms.DivideExponentiations),
            // (x * 3) / (y * 2) = (3 / 2) * (x / y)
            new Rule(Propositions.EitherProductOrQuotient, Transforms.DivideViaCPOConversion),
            // (x * 3)^-1 / (y * 2) = 
            new Rule(Propositions.EitherNegativeOneExponentiationOfProductOrQuotient, Transforms.DivideViaCPOConversion),
        };

        /// <summary>
        /// The pre-built sequence of rules that we will use to calculate exponents.
        /// </summary>
        public static readonly Rule[] Exponentiation = new Rule[]
        {   
            // 2 ^ 3 = 8
            new Rule(Propositions.AreValues, Transforms.ValueExponentiate),
            // x ^ 1 = x
            new Rule(Propositions.SecondOne, Transforms.ReturnFirstExpression),
            // x ^ -1 = 1 / x
            new Rule(Propositions.SecondNegativeOne, Transforms.InvertExpression),
            // 0 ^ x = 0
            new Rule(Propositions.FirstZero, Transforms.ToZero),
            // x ^ 0 = 0
            new Rule(Propositions.SecondZero, Transforms.ToZero),
            // x ^ Inf = 0
            new Rule(Propositions.SecondInfinity, Transforms.ToInfinity),
        };

        /// <summary>
        /// The pre-built sequence of rules that we will use to calculate absolute values.
        /// </summary>
        public static readonly Rule[] AbsoluteValue = new Rule[]
        {   
            // |-x| = x
            new Rule(Propositions.IsNegation, Transforms.NegateExpression),

        };
    }
}
