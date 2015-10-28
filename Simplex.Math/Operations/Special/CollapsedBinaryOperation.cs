using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Logic;
using Simplex.Math.Operations.Elementary;

namespace Simplex.Math.Operations.Special
{
    /// <summary>
    /// An alternative tree representation for a sequence of elements attached by a common binary operation (see remarks).
    /// </summary>
    /// <remarks>
    /// This is crucial for the testing of associative properties.
    /// For example, the sequence of sums: "x + y + z" can be represented by {x, y, z} bound by a sum.
    /// </remarks>
    public class CollapsedBinaryOperation : Operation
    {
        /// <summary>
        /// Creates a new collapsed binary operation with a particular set of operands.
        /// </summary>
        /// <param name="Operands">The operands associated with this collapsed binary operation</param>
        public CollapsedBinaryOperation(params Expression[] Operands) : base(Operands.Length, false)
        {
            for (int i = 0; i < Operands.Length; i++)
            {
                this.Operands[i] = Operands[i];
            }
        }
    }
}
