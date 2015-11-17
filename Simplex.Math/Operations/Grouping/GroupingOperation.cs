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
    /// Represents a special class of unary operations who return equivalent expressions to the input expression based on grouping principles.
    /// </summary>
    /// <remarks>
    /// Examples: Simplify, Expand, Reduce, Factor, etc.
    /// All grouping operations are idempotent
    /// </remarks>
    public class GroupingOperation : UnaryOperation
    {
        /// <summary>
        /// Creates a new grouping operation with a particular rule set and inner expression.
        /// </summary>
        /// <param name="Rules">The rule set associated with this grouping operation</param>
        /// <param name="Expression">The inner expression associated with this grouping operation</param>
        public GroupingOperation(RuleSet Rules, Expression Expression) : base(Rules, Expression, true)
        {
            
        }

        /// <summary>
        /// Gets/sets the inner expression of this grouping operation.
        /// </summary>
        public Expression InnerExpression
        {
            get
            {
                return this.Operands[0];
            }

            set
            {
                this.Operands[0] = value;
            }
        }
    }
}
