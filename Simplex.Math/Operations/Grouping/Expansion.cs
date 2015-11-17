using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;

namespace Simplex.Math.Operations.Grouping
{
    /// <summary>
    /// Represents the expansion of an expression.
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class Expansion : GroupingOperation
    {
        /// <summary>
        /// Creates a new unapplied simplification operation with a particular inner expression.
        /// </summary>
        /// <param name="Expression">The inner expression of this simplification</param>
        public Expansion(Expression Expression) : base(Logic.Rules.ExpansionRules, Expression)
        {
            
        }

        /// <summary>
        /// Applies expansion rules to an input expression.
        /// </summary>
        /// <param name="Expression">The expression to expand</param>
        public static Expression Expand(Expression Expression)
        {
            var O = new Expansion(Expression);
            if (O.CanTransform()) return O.Apply(true);
            else return Expression;
        }
    }
}
