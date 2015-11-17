using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents an expression that contains logarithms
    /// </summary>
    public class LogarithmicExpression : ClosedFormExpression
    {
        public LogarithmicExpression(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
    }
}