using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simplex.Math.Core
{
    /// <summary>
    /// Represents a symbolic mathematical expression.
    /// </summary>
    /// <remarks>
    /// MathExpressions can represent anything from:
    /// Descrete values such as "2", "3.4", or "1/2"
    /// Variables such as "x" or "mass"
    /// Mathematical operations such as "2 + 2" or "Sin(x)"
    /// Array types such as vectors and tensors
    /// </remarks>
    public abstract class Expression
    {
        /// <summary>
        /// Obtains the string representation of this mathematical expression.
        /// </summary>
        /// <remarks>
        /// Note that this converts the expression to a "nice" string, not a C# equivalent.
        /// For example:
        /// (((2 * y) + x) + 4)
        /// Will be returned as:
        /// 2y + x + 4
        /// </remarks>
        public override abstract string ToString();

        /// <summary>
        /// Converts the string representation of an expression into an expression.
        /// </summary>
        /// <param name="Input">The string to parse</param>
        public static Expression Parse(string Input)
        {
            throw new System.NotImplementedException();
        }
    }
}
