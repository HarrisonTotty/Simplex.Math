using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="IsIdempotent">Whether this mathematical operation is idempotent</param>
        public TrinaryOperation(bool IsIdempotent) : base(3, IsIdempotent)
        {

        }
    }
}
