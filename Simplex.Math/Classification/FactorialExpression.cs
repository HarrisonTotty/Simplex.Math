using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Classification
{
    public class FactorialExpression : ArithmeticExpression
    {
        public FactorialExpression(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
    }
}