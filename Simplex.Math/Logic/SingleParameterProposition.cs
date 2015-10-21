using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Operands;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a particular type of proposition restricted to only one parameter.
    /// </summary>
    public class SingleParameterProposition : Proposition
    {
        /// <summary>
        /// Creates a new single-parameter proposition with a particular lambda condition.
        /// </summary>
        /// <param name="Condition">The lambda expression used to evaluate this proposition</param>
        public SingleParameterProposition(System.Linq.Expressions.Expression<ConditionDelegate1> Condition) : base (Condition)
        {
            
        }
    }
}
