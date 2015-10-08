using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a single term in a polynomial such as 3x^2, 7y, or -3
    /// </summary>
    public class PolynomialTerm : Polynomial
    {
        public PolynomialTerm(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }

        /// <summary>
        /// The coefficient associated with this polynomial term.
        /// </summary>
        public Expression Coefficient
        {
            get
            {
                if (this is CoefficientlessPolynomialTerm) return 1;
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// The remaining inner term that is left from removing the coefficient.
        /// </summary>
        public CoefficientlessPolynomialTerm InnerTerm
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