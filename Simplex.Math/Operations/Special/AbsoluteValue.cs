using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Logic;

namespace Simplex.Math.Operations.Special
{
    /// <summary>
    /// Represents the absolute value of an expression.
    /// </summary>
    public class AbsoluteValue : UnaryOperation
    {
        /// <summary>
        /// The rule set associated with absolute values.
        /// </summary>
        public static RuleSet Rules = new RuleSet(Logic.Rules.AbsoluteValue);

        /// <summary>
        /// Creates a new absolute value object with a particular inner expression.
        /// </summary>
        /// <param name="InnerExpression">The expression to take the absolute value of</param>
        public AbsoluteValue(Expression InnerExpression) : base(InnerExpression, true)
        {
            
        }

        /// <summary>
        /// The inner expression inside of this absolute value object.
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

        /// <summary>
        /// Computes the absolute value of a particular input expression.
        /// </summary>
        /// <param name="Input">The input expression to compute the absolute value of</param>
        public static Expression Abs(Expression Input)
        {
            //If we qualify for transform via our ruleset:
            if (AbsoluteValue.Rules.CanTransform(Input))
            {
                //Apply our rules to the input
                return AbsoluteValue.Rules.Apply(Input);
            }

            //If we can't combine anything, just create a new object
            return new AbsoluteValue(Input);
        }
    }
}
