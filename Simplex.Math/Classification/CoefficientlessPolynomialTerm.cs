using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a term of a polynomial with no coefficient (see remarks).
    /// </summary>
    /// <remarks>
    /// Example: x^2,  x,  OR  yz
    /// 
    /// The terms 3x^2 or 3Cx (where C is a constant) WOULD NOT be considered coefficientless polynomial terms
    /// </remarks>
    public class CoefficientlessPolynomialTerm : PolynomialTerm
    {
        public CoefficientlessPolynomialTerm(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }

        /// <summary>
        /// The individual variable terms contained within this term.
        /// </summary>
        public List<SingleVariableCoefficientlessPolynomialTerm> SingleVariableTerms
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}