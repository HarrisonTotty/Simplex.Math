using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// A particular classification of arithmetic expressions that don't contain factorials.
    /// </summary>
    public class NonFactorialArithmeticExpression : ArithmeticExpression
    {
        public NonFactorialArithmeticExpression(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
    }
}