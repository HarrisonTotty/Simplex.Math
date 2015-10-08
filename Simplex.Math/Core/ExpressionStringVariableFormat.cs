using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simplex.Math.Core
{
    /// <summary>
    /// Represents the possible string formats for variables in a mathematical expression.
    /// </summary>
    public enum ExpressionStringVariableFormat
    {
        /// <summary>
        /// The default representation of a variable (see remarks).
        /// </summary>
        /// <remarks>
        /// In the default representation, the symbol of the variable is first used as the string unless
        /// it is not found. In such a case, the name is then used and so on.
        /// Example: m  OR  "Mass" if the variable didn't have a symbol associated with it.
        /// </remarks>
        Default,

        /// <summary>
        /// Associates the string representation of the variable to its symbol (or "UNKNOWN" if the symbol doesn't exist).
        /// </summary>
        /// <remarks>
        /// (1/2)mv^2
        /// </remarks>
        Symbol,

        /// <summary>
        /// Associates the string representation of the variable to its name in quotes (or "UNKNOWN" if the name doesn't exist).
        /// </summary>
        /// <remarks>
        /// Example: (1/2) * "Mass" * "Velocity"^2
        /// </remarks>
        Name,

        /// <summary>
        /// Associates the string representation of the variable to the first five digits of its ID followed by "..." within brackets and quotes.
        /// </summary>
        /// <remarks>
        /// Example: 2 + "[Af7cB...]" - 4"[Ru23q...]"
        /// Note that when parsing a string from from this format, we first try to match the first 5 digits
        /// to a previously existing ID. If none is found, we create a new variable with an ID that
        /// begins with the specified digits.
        /// </remarks>
        ID_Short,

        /// <summary>
        /// Associates the string representation of the variable to the entire ID of the variable.
        /// </summary>
        /// <remarks>
        /// Example: 25 / "[XXXXXYYYYYZZZZZ12345XXXXXYYYYYZZZZZ12345XXXXXYYYYYZZZZZ12345XXXXXYYYYYZZZZZ12345]"
        /// </remarks>
        ID_Long,
    }
}