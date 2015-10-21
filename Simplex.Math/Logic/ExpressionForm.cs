using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;
using Simplex.Math.Sets;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a test for a form of an expression.
    /// </summary>
    /// <remarks>
    /// new ExpressionForm((c, n, x) => c * (x ^ n), (c, n, x) => (c is Value) && (x is Variable) && (n is Value))
    /// </remarks>
    public class ExpressionForm
    {
        /// <summary>
        /// Checks to see if a particular expression matches this form definition.
        /// </summary>
        /// <param name="Input">The expression to check</param>
        public bool Evaluate(Expression Input)
        {
            throw new System.NotImplementedException();
        }

        //The different forms an expression form can be declaired
        public delegate Expression EFDelegate1(Expression E);
        public delegate Expression EFDelegate2(Expression E1, Expression E2);
        public delegate Expression EFDelegate3(Expression E1, Expression E2, Expression E3);
        public delegate Expression EFDelegate4(Expression E1, Expression E2, Expression E3, Expression E4);
        public delegate Expression EFDelegate5(Expression E1, Expression E2, Expression E3, Expression E4, Expression E5);
        //------------------------------------------

        /// <summary>
        /// The proposition that defines the relationship between all of the input components
        /// </summary>
        public Proposition RelationshipProposition
        {
            get;
            private set;
        }

        /// <summary>
        /// The example expression used for this
        /// </summary>
        public System.Linq.Expressions.Expression FormExpression
        {
            get;
            private set;
        }
    }
}