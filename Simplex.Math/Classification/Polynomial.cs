using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a particular classification of algebraic expressions containing only:
    /// Arithmeitc expressions and integer-based exponentials
    /// </summary>
    public class Polynomial : AlgebraicExpression
    {

        public Polynomial(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }

        /// <summary>
        /// The list of terms contained in this polynomial.
        /// </summary>
        public virtual List<PolynomialTerm> Terms
        {
            get;
            private set;
        }

        /// <summary>
        /// The degree (highest degree) of this polynomial.
        /// </summary>
        public virtual int Degree
        {
            get;
            private set;
        }

        /// <summary>
        /// The lowest degree of this polynomial.
        /// </summary>
        public int LowestDegree
        {
            get;
            private set;
        }

        /// <summary>
        /// Computes the addition of two or more polynomials
        /// </summary>
        /// <param name="Polynomials">The polynomials to add</param>
        public static Expression Add(params Polynomial[] Polynomials)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Computes the addition of two or more polynomials
        /// </summary>
        /// <param name="Polynomials">The polynomials to add</param>
        public void Subtract(params Polynomial[] Polynomials)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Computes the addition of two or more polynomials
        /// </summary>
        /// <param name="Polynomials">The polynomials to add</param>
        public void Multiply(params Polynomial[] Polynomials)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Computes the addition of two or more polynomials
        /// </summary>
        /// <param name="Polynomials">The polynomials to add</param>
        public void Divide(params Polynomial[] Polynomials)
        {
            throw new System.NotImplementedException();
        }
    }
}