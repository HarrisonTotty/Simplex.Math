using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Logic;

namespace Simplex.Math.Operations
{
    /// <summary>
    /// Represents a mathematical operation that contains a single operand
    /// </summary>
    public abstract class UnaryOperation : Operation
    {
        /// <summary>
        /// Creates a new unary operation with a particular operand.
        /// </summary>
        /// <param name="Rules">The set of rules that govern the application of this operation</param>
        /// <param name="Operand">The operand of this operation</param>
        /// <param name="IsIdempotent">Whether this unary operation is idempotent (see MathOperation class or Wikipedia on idempotence)</param>
        public UnaryOperation(RuleSet Rules, Expression Operand, bool IsIdempotent) : base(Rules, 1, IsIdempotent)
        {
            this.Operands[0] = Operand;
        }
    }
}
