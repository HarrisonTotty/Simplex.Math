using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simplex.Math
{
    /// <summary>
    /// Represents assumptions and rules used when performing substitutions.
    /// </summary>
    public enum SubstitutionType
    {
        /// <summary>
        /// Only parts of an expression that are symbolically equal to the given new expression will be substituted.
        /// </summary>
        Default,

        /// <summary>
        /// Only parts of an expression that are symbolically similar (have the same general form) to the given new expression will be substituted.
        /// </summary>
        Similar,

        /// <summary>
        /// Only parts of an expression that are symbolically identical to the given new expression will be substituted.
        /// </summary>
        Identical,
    }
}