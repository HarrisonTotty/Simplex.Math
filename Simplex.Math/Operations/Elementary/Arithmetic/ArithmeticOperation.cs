using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents one of the four classic arithmetic operations: Addition, Subtraction, Multiplication, and Division.
    /// </summary>
    public abstract class ArithmeticOperation : ElementaryOperation
    {
        /// <summary>
        /// Creates a new arithmetic operation with a pair of operands.
        /// </summary>
        /// <param name="Operand1">The first (or "left") operand</param>
        /// <param name="Operand2">The second (or "right") operand</param>
        /// <param name="IsCommutative">Whether this operation is commutative</param>
        /// <param name="IsAnticommutative">Whether this operation is anticommutative</param>
        /// <param name="IsAssociative">Whether this operation is associative</param>
        public ArithmeticOperation(Expression Operand1, Expression Operand2, bool IsCommutative, bool IsAnticommutative, bool IsAssociative) : base(Operand1, Operand2, IsCommutative, IsAnticommutative, IsAssociative)
        {

        }
    }
}
