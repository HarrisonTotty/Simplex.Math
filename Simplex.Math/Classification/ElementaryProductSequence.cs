using Simplex.Math.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a particular classification of non-factorial arithmetic expressions containing only an elementary seqence of products and/or quotients.
    /// </summary>
    /// <remarks>
    /// Example: 4xy/a
    /// 
    /// The sequence  4xy + 5  WOULD NOT be considered an elementary product sequence because it contains sums!
    /// </remarks>
    public class ElementaryProductSequence : NonFactorialArithmeticExpression
    {
        public ElementaryProductSequence(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {

        }

        /// <summary>
        /// The list of terms contained within this sequence as tuples of the expression and whether it is positive.
        /// </summary>
        public List<IntrinsicIrreducible> ProductTerms
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