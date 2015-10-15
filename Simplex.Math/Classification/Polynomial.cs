using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

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
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// The degree (highest degree) of this polynomial.
        /// </summary>
        public virtual int Degree
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// The lowest degree of this polynomial.
        /// </summary>
        public int LowestDegree
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