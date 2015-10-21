using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Operands;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// A simple system to equate one expression matching a proposition to another expression matching a proposition.
    /// </summary>
    /// <remarks>
    /// Qualifying Proposition1, QP 2, relation proposition
    /// </remarks>
    public class EqualityDefinition
    {
        /// <summary>
        /// Creates a new equality definition with a single qualifying proposition and relation proposition.
        /// </summary>
        /// <param name="QualifyingProposition">The proposition both expressions must match in order to qualify for equality</param>
        /// <param name="RelationProposition">The proposition two qualifying expressions must pass in order for the overall equality definition to pass</param>
        public EqualityDefinition(SingleParameterProposition QualifyingProposition, DoubleParameterProposition RelationProposition)
        {
            this.FirstQualifyingProposition = QualifyingProposition;
            this.SecondQualifyingProposition = QualifyingProposition;
            this.RelationProposition = RelationProposition;
        }

        /// <summary>
        /// Creates a new equality definition with a single qualifying proposition and relation proposition.
        /// </summary>
        /// <param name="FirstQualifyingProposition">The proposition one of two expressions must match in order to qualify for equality</param>
        /// <param name="SecondQualifyingProposition">The proposition THE OTHER expression must match in order to qualify for equality</param>
        /// <param name="RelationProposition">The proposition two qualifying expressions must pass in order for the overall equality definition to pass</param>
        public EqualityDefinition(SingleParameterProposition FirstQualifyingProposition, SingleParameterProposition SecondQualifyingProposition, DoubleParameterProposition RelationProposition)
        {
            this.FirstQualifyingProposition = FirstQualifyingProposition;
            this.SecondQualifyingProposition = SecondQualifyingProposition;
            this.RelationProposition = RelationProposition;
        }

        /// <summary>
        /// The proposition one of two expressions must match in order to qualify for equality.
        /// </summary>
        public SingleParameterProposition FirstQualifyingProposition
        {
            get;
            set;
        }

        /// <summary>
        /// The proposition the OTHER expression must match in order to qualify for equality.
        /// </summary>
        public SingleParameterProposition SecondQualifyingProposition
        {
            get;
            set;
        }

        /// <summary>
        /// The proposition two qualifying expressions must pass in order for the overall equality definition to pass.
        /// </summary>
        public DoubleParameterProposition RelationProposition
        {
            get;
            set;
        }

        /// <summary>
        /// Whether two expressions qualify for testing via this equality definition.
        /// </summary>
        /// <param name="E1">The first expression to check</param>
        /// <param name="E2">The second expression to check</param>
        public bool Qualifies(Expression E1, Expression E2)
        {
            if (this.FirstQualifyingProposition.Evaluate(E1) && this.SecondQualifyingProposition.Evaluate(E2)) return true;
            if (this.FirstQualifyingProposition.Evaluate(E2) && this.SecondQualifyingProposition.Evaluate(E1)) return true;
            return false;
        }

        /// <summary>
        /// Evaluates the equality of two expressions according to this equality definition.
        /// </summary>
        /// <param name="E1">The first expression to check</param>
        /// <param name="E2">The second expression to check</param>
        public bool Evaluate(Expression E1, Expression E2)
        {
            if (this.FirstQualifyingProposition.Evaluate(E1) && this.SecondQualifyingProposition.Evaluate(E2)) return RelationProposition.Evaluate(E1, E2);
            if (this.FirstQualifyingProposition.Evaluate(E2) && this.SecondQualifyingProposition.Evaluate(E1)) return RelationProposition.Evaluate(E2, E1);
            return false;
        }
    }
}
