using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;

namespace Simplex.Math.Operations
{
    /// <summary>
    /// Represents a mathematical operation that contains two operands
    /// </summary>
    public abstract class BinaryOperation : Operation
    {
        /// <summary>
        /// Creates a new binary operation with a pair of operands.
        /// </summary>
        /// <param name="Operand1">The first (or "left") operand</param>
        /// <param name="Operand2">The second (or "right") operand</param>
        /// <param name="IsCommutative">Whether this operation is commutative</param>
        /// <param name="IsAnticommutative">Whether this operation is anticommutative</param>
        /// <param name="IsIdempotent">Whether this operation is idempotent</param>
        /// <param name="IsAssociative">Whether this operation is associative</param>
        public BinaryOperation(Expression Operand1, Expression Operand2, bool IsCommutative, bool IsAnticommutative, bool IsIdempotent, bool IsAssociative) : base(2, IsIdempotent)
        {
            this.Operands[0] = Operand1;
            this.Operands[1] = Operand2;
            this.IsCommutative = IsCommutative;
            this.IsAnticommutative = IsAnticommutative;
            this.IsAssociative = IsAssociative;
        }

        /// <summary>
        /// Whether this binary operation is commutative (whether switching the order of the operands of this operation produces the same result).
        /// </summary>
        /// <remarks>
        /// Addition and multiplication are commutative since "a + b" is equal to "b + a" etc.
        /// Subtraction and division are not commutative since "a - b" is not equal to "b - a" etc.
        /// </remarks>
        public bool IsCommutative
        {
            get;
            set;
        }

        /// <summary>
        /// Whether this binary operation is anticommutative (whether switching the order of the operands of this operation negates the result).
        /// </summary>
        /// <remarks>
        /// Addition, multiplication, division, etc. are not anticommutative since "a + b" = "b + a" etc.
        /// Subtraction is anticommutative since "a - b" = "-(b - a)".
        /// </remarks>
        public bool IsAnticommutative
        {
            get;
            set;
        }

        /// <summary>
        /// Whether this binary operation is associative 
        /// (whether a sequence of two or more operations of this same type will yeild the same result reguarless of the order that the operations are performed so long as the sequence of the operands is not changed) (see remarks).
        /// </summary>
        /// <remarks>
        /// Addition is associative because (2 + 3) + 4 = 2 + (3 + 4) = 9
        /// Subtraction is not associative because (2 - 3) - 4 = -5, which does not equal 2 - (3 - 4) = 3
        /// </remarks>
        public bool IsAssociative
        {
            get;
            set;
        }
    }
}
