using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Operands;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents the natural logarithm of a particular mathematical expression.
    /// </summary>
    class NaturalLogarithm : Logarithm
    {
        /// <summary>
        /// Creates a new natural logarithm with a particular inner expression.
        /// </summary>
        /// <param name="LogExpression">The inner expression to take the natural logarithm of</param>
        public NaturalLogarithm(Expression LogExpression) : base(Constant.e, LogExpression)
        {

        }

        /// <summary>
        /// Computes the natural logarithm of an input expression.
        /// </summary>
        /// <param name="LogExpression">The expression to take the log of</param>
        public static Expression Log(Expression LogExpression)
        {
            //If we don't know what to do:
            return new NaturalLogarithm(LogExpression);
        }


    }
}
