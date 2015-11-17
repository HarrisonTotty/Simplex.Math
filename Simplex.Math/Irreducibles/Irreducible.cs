using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Classification;

namespace Simplex.Math.Irreducibles
{
    /// <summary>
    /// Represents a particular type of mathematical expression that is not an operation and cannot be simplified further.
    /// Includes variables and values.
    /// </summary>
    /// <remarks>
    /// Note that although math operations contain "operands", the operands of a math operation can be another math operation
    /// </remarks>
    public abstract class Irreducible : Expression
    {
        /// <summary>
        /// Creates a new blank operand.
        /// </summary>
        public Irreducible()
        {
            
        }

        /// <summary>
        /// Creates an operand with a particular scope.
        /// </summary>
        /// <param name="Scope">The scope associated with this Irreducible</param>
        public Irreducible(Scope Scope) : base(Scope)
        {
            
        }

        /// <summary>
        /// Classifying a variable, constant, or value will always return at least an intrinsic irriducible
        /// </summary>
        public override ClassifiedExpression[] Classify()
        {
            return new ClassifiedExpression[] { new IntrinsicIrreducible(this), new PolynomialTerm(this) };
        }
    }
}
