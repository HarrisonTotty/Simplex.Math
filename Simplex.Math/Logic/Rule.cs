using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;
using Simplex.Math.Sets;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a particular rule that modifies (an) expression(s) given to it (see remarks).
    /// </summary>
    /// <remarks>
    /// Rules have two parts:
    /// The Proposition - Which input expressions must match in order continue    - Example: "(x, y) => x == y"
    /// The Transform   - What do we return if the input matches the proposition? - Example: "(x, y) => 2x"
    /// </remarks>
    public class Rule
    {
        /// <summary>
        /// Creates a new rule from a given qualifying proposition and transform expression.
        /// </summary>
        /// <param name="QualifyingProposition">The proposition an input expression must match in order to qualify for this rule</param>
        /// <param name="TransformExpression">The transform applied to the input expression</param>
        public Rule(Proposition QualifyingProposition, Transform TransformExpression)
        {
            this.QualifyingProposition = QualifyingProposition;
            this.TransformExpression = TransformExpression;
        }

        /// <summary>
        /// The proposition an input expression must match in order to qualify for this rule.
        /// </summary>
        public Proposition QualifyingProposition
        {
            get;
            set;
        }

        /// <summary>
        /// The lambda expression used to evaluate this rule.
        /// </summary>
        /// <remarks>
        /// We use a System.Linq.Expressions.Expression object instead of just a Predicate object so that we can access members for printing.
        /// </remarks>
        public Transform TransformExpression
        {
            get;
            set;
        }

        /// <summary>
        /// Evaluates this rule on a given expression or list of expressions.
        /// </summary>
        /// <remarks>
        /// In most cases this will only return one expression, but it can return a Set.
        /// </remarks>
        /// <param name="Input">The expression(s) to evaluate</param>
        public virtual Expression Apply(params Expression[] Input)
        {
            if (this.QualifyingProposition.Evaluate(Input)) return TransformExpression.Apply(Input);
            if (Input.Length == 1) return Input[0];
            return new Set(Input);
        }

        /// <summary>
        /// Returns whether an expression or list of expressions qualify for this rule.
        /// </summary>
        /// <param name="Input">The expression(s) to test</param>
        public virtual bool Qualifies(params Expression[] Input)
        {
            return this.QualifyingProposition.Evaluate(Input);
        }
    }
}