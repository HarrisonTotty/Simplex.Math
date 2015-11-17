using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a pre-classified mathematical expression.
    /// Examples of classified expressions include polynomials, closed-form expressions, and algebraic expressions.
    /// </summary>
    public class ClassifiedExpression : Expression
    {
        /// <summary>
        /// Creates a new classified expression from a given underlying expression.
        /// Note that this constructor WILL NOT actually classify the expression, just create and link the object.
        /// </summary>
        /// <param name="UnderlyingExpression">The underlying expression associated with this classification</param>
        public ClassifiedExpression(Expression UnderlyingExpression)
        {
            this.UnderlyingExpression = UnderlyingExpression;
            this.IsNegated = false;
        }

        /// <summary>
        /// The underlying expression associated with this classification.
        /// </summary>
        public Expression UnderlyingExpression
        {
            get;
            set;
        }

        /// <summary>
        /// An integer value corresponding to a particular level of classification.
        /// Larger values correspond to a more specific level of classification.
        /// </summary>
        /// <remarks>
        /// Expected Classification Values:
        /// ClassifiedExpression - 0
        /// AnalyticalExpression - 1
        /// ClosedFormExpression - 2
        /// ...
        /// ElementarySumSequence - 7
        /// </remarks>
        public int ClassificationLevel
        {
            get
            {
                //Obtain the type of the object we inherit
                var inheritedtype = this.GetType().BaseType;

                //If this object is not a form of classified expression, then we must be a classified expression
                if (!inheritedtype.IsAssignableFrom(typeof(ClassifiedExpression))) return 0;

                //Otherwise, we need to recursively count our way to the top
                return 1 + (int)Convert.ChangeType(this, inheritedtype).GetType().InvokeMember("GetClassificationLevel", System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public, null, null, null);
            }
        }

        /// <summary>
        /// An integer value corresponding to the overall complexity of the expression. Typically decreases as the classification level increases.
        /// Two expressions may have the same classification level but different complexities (see remarks).
        /// </summary>
        /// <remarks>
        /// Example: 2x^3 + 4   and     14x - 6     are both polynomials but have different complexities.
        /// </remarks>
        public int Complexity
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// Classifies this expression into a particular category of expressions.
        /// </summary>
        /// <remarks>
        /// Although we are already a classified expression, we may have been 
        /// incorrectly classified - so we run it again on our innner expression.
        /// </remarks>
        public override ClassifiedExpression[] Classify()
        {
            if (this.IsNegated) return (-this.UnderlyingExpression).Classify();
            return this.UnderlyingExpression.Classify();
        }

        /// <summary>
        /// Whether this expression is truely negated or not
        /// </summary>
        /// <remarks>
        /// This makes it easier to compare expressions.
        /// </remarks>
        public bool IsNegated
        {
            get;
            set;
        }
    }
}