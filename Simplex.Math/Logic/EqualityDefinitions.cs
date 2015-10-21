using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Operands;
using Simplex.Math.Operations.Elementary;
using Simplex.Math.Core;
using Simplex.Math.Sets;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a static collection of equality definitions for various expression types.
    /// </summary>
    public static class EqualityDefinitions
    {
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
        }.ToList();
    }
}
