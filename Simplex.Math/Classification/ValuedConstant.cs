using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Classification
{
    public class ValuedConstant : GenericConstant
    {
        public ValuedConstant(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
    }
}