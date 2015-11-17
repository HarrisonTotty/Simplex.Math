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
    /// Represents a mathematical operation that contains three operands
    /// </summary>
    public abstract class TrinaryOperation : Operation
    {
        /// <summary>
        /// Creates a new trinary operation
        /// </summary>
        /// <param name="Rules">The set of rules that govern the application of this operation</param>
        /// <param name="IsIdempotent">Whether this mathematical operation is idempotent</param>
        public TrinaryOperation(RuleSet Rules, bool IsIdempotent) : base(Rules, 3, IsIdempotent)
        {

        }
    }
}
