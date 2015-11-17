using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a particular classification of non-factorial arithmetic expressions that represent a single variable or value.
    /// </summary>
    public class IntrinsicIrreducible : NonFactorialArithmeticExpression
    {
        public IntrinsicIrreducible(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
    }
}