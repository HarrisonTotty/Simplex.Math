using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// A particular classification of analytical expressions containing only:
    /// Algebraic expressions, irrational expressions, logarithms, trigonometic (and inverse trigonometic) expressions, and hyperbolic (and inverse hyperbolic) expressions
    /// </summary>
    public class ClosedFormExpression : AnalyticalExpression
    {
        public ClosedFormExpression(Expression UnderlyingExpression) : base (UnderlyingExpression)
        {
            
        }
    }
}