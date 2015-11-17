using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Irreducibles;
using Simplex.Math.Operations;
using Simplex.Math.Operations.Elementary;
using Simplex.Math;
using Simplex.Math.Sets;
using Simplex.Math.Classification;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a static collection of equality definitions for various expression types.
    /// Also contains a few static methods for testing equality
    /// </summary>
    public static class EqualityDefinitions
    {
        /// <summary>
        /// Tests a pair of expressions for equality using the equality definitions defined in this class.
        /// </summary>
        /// <param name="E1">The first expression to test</param>
        /// <param name="E2">The second expression to test</param>
        public static bool TestEquality(Expression E1, Expression E2)
        {
            //Test for "null" arguments
            if ((E1 as object) == null && (E2 as object) == null) return true;
            if ((E1 as object) == null || (E2 as object) == null) return false;

            //If E1 maps to E2
            if (E1.MapsTo(E2)) return true;

            //Fast tests amoungst operands
            if ((E1 is Irreducible) && (E2 is Irreducible)) return TestEquality_FastTests_Operands(E1, E2);

            //Test for equality amoungst operands - OLD
            //if (((E1 is Irreducible) || (E1 is IntrinsicIrreducible)) && ((E2 is Irreducible) || (E2 is IntrinsicIrreducible))) return TestEquality(E1, E2, Operands);

            //Test for equality amoungst binary operations
            if (((E1 is Operation) && (E1 as Operation).Arity == 2) && ((E2 is Operation) && (E2 as Operation).Arity == 2)) if (TestEquality(E1, E2, BinaryOperations)) return true;

            //Test for equality via grouping operations
            //if (TestEquality(E1, E2, Groupings)) return true;

            //If we couldn't determine that they are equal:
            return false;
        }

        /// <summary>
        /// Tests a pair of expressions for identicality using the equality definitions defined in this class.
        /// </summary>
        /// <param name="E1">The first expression to test</param>
        /// <param name="E2">The second expression to test</param>
        public static bool TestIdenticality(Expression E1, Expression E2)
        {
            //Test for "null" arguments
            if ((E1 as object) == null && (E2 as object) == null) return true;
            if ((E1 as object) == null || (E2 as object) == null) return false;

            //To be identical, they must have the same type
            if (E1.GetType() != E2.GetType()) return false;

            //If E1 maps to E2
            if (E1.MapsTo(E2)) return true;

            //Fast tests amoungst operands
            if ((E1 is Irreducible) && (E2 is Irreducible)) return TestIdenticality_FastTests_Operands(E1, E2);

            //Test for identicality amoungst binary operations
            if (((E1 is Operation) && (E1 as Operation).Arity == 2) && ((E2 is Operation) && (E2 as Operation).Arity == 2)) return TestEquality(E1, E2, BinaryOperations);

            //If we couldn't determine that they are equal:
            return false;
        }

        /// <summary>
        /// Tests a pair of expressions for equality using a particular test list.
        /// </summary>
        /// <param name="E1">The first expression to test</param>
        /// <param name="E2">The second expression to test</param>
        /// <param name="TestList">The list of equality definitions to try</param>
        public static bool TestEquality(Expression E1, Expression E2, List<EqualityDefinition> TestList)
        {
            //Make sure the list isn't null or empty
            if (TestList == null || TestList.Count < 1) return false;

            //Trim excess capacity.
            if (TestList.Count != TestList.Capacity) TestList.TrimExcess();

            //Check each equality definition in the list against our two expressions
            for (int i = 0; i < TestList.Count; i++)
            {
                if (TestList[i].Evaluate(E1, E2)) return true; 
            }

            //If we couldn't determine that they are equal:
            return false;
        }

        /// <summary>
        /// Performs the easiest comparison operations between operands without utilizing the EqualityDefinition system.
        /// </summary>
        /// <remarks>
        /// This makes computation faster
        /// </remarks>
        private static bool TestEquality_FastTests_Operands(Expression E1, Expression E2)
        {
            if ((E1 is Variable) && (E2 is Variable))
            {
                // x = x
                if ((E1 as Variable).ID == (E2 as Variable).ID) return true;
            }
            else if ((E1 is Value) && (E2 is Value))
            {
                // 3 = 3
                if ((E1 as Value).InnerValue == (E2 as Value).InnerValue) return true;
            }
            else if ((E1 is Constant) && (E2 is Constant))
            {
                // C = C    AND     C(3.14) = Pi
                if ((E1 as Constant).ID == (E2 as Constant).ID) return true;
                if ((E1 as Constant).HasDescreteValue && (E2 as Constant).HasDescreteValue)
                {
                    if ((E1 as Constant).Value.InnerValue == (E2 as Constant).Value.InnerValue) return true;
                }
            }
            else if ((E1 is Value) && (E2 is Constant))
            {
                if ((E2 as Constant).HasDescreteValue)
                {
                    // 3.14 = Pi
                    if ((E2 as Constant).Value.InnerValue == (E1 as Value).InnerValue) return true;
                }
            }
            else if ((E1 is Constant) && (E2 is Value))
            {
                if ((E1 as Constant).HasDescreteValue)
                {
                    // Pi = 3.14
                    if ((E1 as Constant).Value.InnerValue == (E2 as Value).InnerValue) return true;
                }
            }
            else if ((E1 is ImaginaryUnit) && (E2 is ImaginaryUnit))
            {
                // i = i
                return true;
            }

            return false;
        }


        /// <summary>
        /// Performs the easiest comparison operations between operands without utilizing the EqualityDefinition system.
        /// </summary>
        /// <remarks>
        /// This makes computation faster
        /// </remarks>
        private static bool TestIdenticality_FastTests_Operands(Expression E1, Expression E2)
        {
            if ((E1 is Variable) && (E2 is Variable))
            {
                // x = x
                if ((E1 as Variable).ID == (E2 as Variable).ID) return true;
            }
            else if ((E1 is Value) && (E2 is Value))
            {
                // 3 = 3
                if ((E1 as Value).InnerValue == (E2 as Value).InnerValue) return true;
            }
            else if ((E1 is Constant) && (E2 is Constant))
            {
                // C = C    AND     C(3.14) = Pi
                if ((E1 as Constant).ID == (E2 as Constant).ID) return true;
                if ((E1 as Constant).HasDescreteValue && (E2 as Constant).HasDescreteValue)
                {
                    if ((E1 as Constant).Value.InnerValue == (E2 as Constant).Value.InnerValue) return true;
                }
            }
            else if ((E1 is ImaginaryUnit) && (E2 is ImaginaryUnit))
            {
                //i = i
                return true;
            }

            return false;
        }

        /// <summary>
        /// A collection of equality definitions amoungst variables, values, and constants.
        /// </summary>
        public static readonly List<EqualityDefinition> Operands = new EqualityDefinition[] 
        {
            // x = x
            new EqualityDefinition(Propositions.IsVariable, Propositions.HaveSameID),
            // C = C
            new EqualityDefinition(Propositions.IsConstant, Propositions.HaveSameID),
            // 3 = 3
            new EqualityDefinition(Propositions.IsValue, Propositions.HaveSameStrictValue),
            // Pi = 3.14...
            new EqualityDefinition(Propositions.HasDescreteValue, Propositions.HaveSameDescreteValue),
            // i = i
            new EqualityDefinition(Propositions.IsImaginaryUnit, Propositions.BinaryTRUE)

        }.ToList();

        /// <summary>
        /// A collection of equality definitions amoungst sums, differences, products, and other binary operations.
        /// </summary>
        public static readonly List<EqualityDefinition> BinaryOperations = new EqualityDefinition[]
        {
            // (x + y) = (x + y)    AND     (x + y) = (y + x)
            new EqualityDefinition(Propositions.IsSum, Propositions.HaveEqualChildExpressions_Commutative),
            // (x * y) = (x * y)    AND     (x * y) = (y * x)
            new EqualityDefinition(Propositions.IsProduct, Propositions.HaveEqualChildExpressions_Commutative),
            // (x - y) = (x - y)
            new EqualityDefinition(Propositions.IsDifference, Propositions.HaveEqualChildExpressions),
            // (x / y) = (x / y)
            new EqualityDefinition(Propositions.IsQuotient, Propositions.HaveEqualChildExpressions),
            // x^2 = x^2
            new EqualityDefinition(Propositions.IsExponentiation, Propositions.HaveEqualChildExpressions),
            // (x + -y) = (x - y)
            new EqualityDefinition(Propositions.IsSum, Propositions.IsDifference, Propositions.OperationsHaveEqualFirstOppositeSecondOperands),
            // (x * (1 / y)) = (x / y)
            new EqualityDefinition(Propositions.IsProduct, Propositions.IsQuotient, Propositions.OperationsHaveEqualFirstInverseSecondOperands),
            // (1 / x) = x^-1
            new EqualityDefinition(Propositions.IsQuotient, Propositions.IsExponentiation, Propositions.QuotientExponentiationEquality),
            // Equates very complex sum/difference trees
            new EqualityDefinition(Propositions.QualifiesForCSO, Propositions.EqualityTestViaCSO),
            // Equates very complex product/quotient trees
            new EqualityDefinition(Propositions.QualifiesForCPO, Propositions.EqualityTestViaCPO),

        }.ToList();


        /// <summary>
        /// A collection of equality definitions utilizing the application of grouping operations.
        /// </summary>
        public static readonly List<EqualityDefinition> Groupings = new EqualityDefinition[]
        {
            // 3(x + 2) = 3x + 6
            new EqualityDefinition(Propositions.TRUE, Propositions.XSimplifiesToY),
            // 3x = x + x + x
            new EqualityDefinition(Propositions.TRUE, Propositions.XExpandsToY),
            // 3x + 6 = 3(x + 2)
            //new EqualityDefinition(Propositions.TRUE, Propositions.XContractsToY),

        }.ToList();
    }
}
