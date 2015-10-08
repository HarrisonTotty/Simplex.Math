using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Classification
{
    public class GenericConstant : IntrinsicIrreducible
    {
        public GenericConstant(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
    }
}