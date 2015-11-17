using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simplex.Math
{
    /// <summary>
    /// Represents the types of rules and assumptions to apply to general form conversions.
    /// </summary>
    public enum GeneralFormType
    {
        /// <summary>
        /// All coefficients are replaced with the generic constant "C" with a few exceptions like "pi", "e", and "Infinity" (See Remarks).
        /// Exponents and log bases remain untouched.
        /// </summary>
        /// <remarks>
        /// Coefficients/Constants that aren't replaced:
        /// Infinty
        /// Pi
        /// e (Euler's number)
        /// i (the imaginay number)
        /// </remarks>
        Default,

        /// <summary>
        /// All coefficients are replaced with the generic constant "C" with no exceptions.
        /// Exponents and log bases remain untouched.
        /// </summary>
        Complete,
    }
}