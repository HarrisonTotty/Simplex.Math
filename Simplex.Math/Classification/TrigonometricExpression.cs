using Simplex.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simplex.Math.Classification
{
    public class TrigonometricExpression : ClosedFormExpression
    {
        public TrigonometricExpression(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
    }
}