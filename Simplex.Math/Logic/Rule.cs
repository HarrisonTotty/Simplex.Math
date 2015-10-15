using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a particular rule that modifies an expression given to it (see remarks).
    /// </summary>
    /// <remarks>
    /// Rules have two parts:
    /// The Proposition - Which an input expression must match in order continue    - Example: "the expression has the form A(B + C)"
    /// The Transform   - What do we return if the input matches the proposition?   - Example: "return AB + AC"
    /// </remarks>
    public class Rule
    {
        /// <summary>
        /// The proposition an input expression must match in order to qualify for this rule.
        /// </summary>
        public Proposition QualifyingProposition
        {
            get;
            set;
        }
    }
}