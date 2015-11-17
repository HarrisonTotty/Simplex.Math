using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simplex.Math
{
    /// <summary>
    /// Represents the possible string formats for constants and values in a mathematical expression.
    /// </summary>
    public enum ExpressionStringConstantFormat
    {
        /// <summary>
        /// The default string format for constants and values (expresses a constant as its value unless it has a symbol).
        /// </summary>
        /// <remarks>
        /// Example: e     ,      7
        /// </remarks>
        Default,

        /// <summary>
        /// Only expresses constants in terms of symbols (all values without symbols with be replaced with "C").
        /// </summary>
        /// <remarks>
        /// Example: e     ,      C
        /// </remarks>
        Symbolic,

        /// <summary>
        /// Only expresses constants in terms of numerical values unless it doesn't have one.
        /// </summary>
        /// <remarks>
        /// Example: 2.71828     ,      7
        /// </remarks>
        Numeric,
    }
}