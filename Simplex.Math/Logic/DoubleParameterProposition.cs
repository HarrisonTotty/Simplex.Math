using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a particular type of proposition restricted to only two parameters.
    /// </summary>
    public class DoubleParameterProposition : Proposition
    {
        
        /// <summary>
        /// Creates a new double-parameter proposition with a particular lambda condition.
        /// </summary>
        /// <param name="Condition">The lambda expression used to evaluate this proposition</param>
        public DoubleParameterProposition(System.Linq.Expressions.Expression<ConditionDelegate2> Condition) : base (Condition)
        {

        }
    }
}
