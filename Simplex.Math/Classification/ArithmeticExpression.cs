using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a particular classification of polynomial expressions containing only:
    /// Constants, variables, arithmetic operations (addition, subtraction, multiplication, and division), and factorials
    /// </summary>
    public class ArithmeticExpression : Polynomial
    {
        public ArithmeticExpression(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }
        //Allow explicit casting in order for the "is" keyword to work:

    }
}