using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simplex.Math.Core
{
    /// <summary>
    /// Represents the possible string representations a mathematical expression can have.
    /// </summary>
    public enum ExpressionStringFormat
    {
        /// <summary>
        /// The default "pretty" expression format.
        /// </summary>
        /// <remarks>
        /// Example: 2x^2 + 3xy - Sin(x)
        /// </remarks>
        Default,

        /// <summary>
        /// A format designed to be compatable with C# expression parsing.
        /// </summary>
        /// <remarks>
        /// Example: (2 * (x ^ 2)) + (3 * (x * y))
        /// </remarks>
        ParseFriendly,

        /// <summary>
        /// A LaTeX interpretation of the expression.
        /// </summary>
        /// <remarks>
        /// Example: e^{3x} + 4y + \frac{a}{b}
        /// </remarks>
        LaTeX
    }
}