using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a particular classification of closed-form expressions containing only:
    /// Polynomials, nth roots, and rational exponentials
    /// </summary>
    public class AlgebraicExpression : ClosedFormExpression
    {
        public AlgebraicExpression(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
    }
}