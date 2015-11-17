using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// A particular classification of mathematical expressions that don't contain:
    /// Formal power series, limits, differentials, or integrals
    /// </summary>
    public class AnalyticalExpression : ClassifiedExpression
    {
        public AnalyticalExpression(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
    }
}