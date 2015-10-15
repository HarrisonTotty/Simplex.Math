using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents the logarithm of a particular mathematical expression with respect to a particular base expression.
    /// </summary>
    public class Logarithm : ElementaryOperation
    {
        /// <summary>
        /// Creates a new logarithm of an input expression with respect to a particular base
        /// </summary>
        /// <param name="Base">The base expression of this logarithm</param>
        /// <param name="LogExpression">The expression to take the log of</param>
        public Logarithm(Expression Base, Expression LogExpression) : base(Base, LogExpression, false, false, false)
        {

        }

        /// <summary>
        /// The base of this logarithm.
        /// </summary>
        public Expression Base
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
        /// The inner expression of this logarithm.
        /// </summary>
        public Expression LogExpression
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

        /// <summary>
        /// Computes the logarithm of an input expression with respect to a particular base
        /// </summary>
        /// <param name="Base">The base expression of this logarithm</param>
        /// <param name="LogExpression">The expression to take the log of</param>
        public static Expression Log(Expression Base, Expression LogExpression)
        {
            //If we don't know what to do:
            return new Logarithm(Base, LogExpression);
        }
    }
}
