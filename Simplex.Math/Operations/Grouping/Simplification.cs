using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Logic;

namespace Simplex.Math.Operations.Grouping
{
    /// <summary>
    /// Represents the simplification of an expression.
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class Simplification : GroupingOperation
    {
        /// <summary>
        /// Creates a new unapplied simplification operation with a particular inner expression.
        /// </summary>
        /// <param name="Expression">The inner expression of this simplification</param>
        public Simplification(Expression Expression) : base(Logic.Rules.SimplificationRules, Expression)
        {
            
        }

        /// <summary>
        /// Applies simplification rules to an input expression.
        /// </summary>
        /// <param name="Expression">The expression to simplify</param>
        public static Expression Simplify(Expression Expression)
        {
            var O = new Simplification(Expression);
            if (O.CanTransform()) return O.Apply(true);
            else return Expression;
        }
    }
}
