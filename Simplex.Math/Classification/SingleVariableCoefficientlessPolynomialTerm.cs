using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a term of a polynomial with no coefficient and is only dependent on one variable.
    /// </summary>
    /// <remarks>
    /// x,      x^2,       x^3,     ...
    /// </remarks>
    public class SingleVariableCoefficientlessPolynomialTerm : CoefficientlessPolynomialTerm
    {
        public SingleVariableCoefficientlessPolynomialTerm(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }

        /// <summary>
        /// The degree of this polynomial term.
        /// </summary>
        public override int Degree
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
    }
}