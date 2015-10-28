using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents the negation of an expression (an expression multiplied by -1).
    /// </summary>
    /// <remarks>
    /// This is technically either a unary operation OR a binary operation depending on how you look at it,
    /// but it makes more sense to store it under a product so that it can inherit everything a product
    /// can do.
    /// </remarks>
    public class Negation : Product
    {
        
        /// <summary>
        /// Creates a new negation expression with a particular inner expression.
        /// </summary>
        /// <param name="InnerExpression">The expression that is negated</param>
        public Negation(Expression InnerExpression) : base(-1, InnerExpression)
        {
            
        }

        /// <summary>
        /// The expression that is being negated.
        /// </summary>
        public Expression InnerExpression
        {
            get
            {
                return this.Operands[1];
            }

            set
            {
                this.Operands[1] = value;
            }
        }
    }
}