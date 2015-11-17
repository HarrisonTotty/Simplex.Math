using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Irreducibles;
using Simplex.Math.Logic;

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
        /// <param name="Rules">The set of rules that govern the application of this operation</param>
        /// <param name="Operand1">The first (or "left") operand</param>
        /// <param name="Operand2">The second (or "right") operand</param>
        /// <param name="IsCommutative">Whether this operation is commutative</param>
        /// <param name="IsAnticommutative">Whether this operation is anticommutative</param>
        /// <param name="IsAssociative">Whether this operation is associative</param>
        public ArithmeticOperation(RuleSet Rules, Expression Operand1, Expression Operand2, bool IsCommutative, bool IsAnticommutative, bool IsAssociative) : base(Rules, Operand1, Operand2, IsCommutative, IsAnticommutative, IsAssociative)
        {

        }

        /// <summary>
        /// Returns whether this expression represents a coefficient (see remarks).
        /// </summary>
        /// <remarks>
        /// 3
        /// C
        /// 3C
        /// 3CK
        /// 3/(Ck)
        /// (3 + C)
        /// Are all coefficients
        /// </remarks>
        public bool IsCoefficient()
        {
            //Constants and values
            if (this.Operands[0] is Constant && this.Operands[1] is Constant) return true;
            if (this.Operands[0] is Constant && this.Operands[1] is Value) return true;
            if (this.Operands[0] is Value && this.Operands[1] is Constant) return true;
            if (this.Operands[0] is Value && this.Operands[1] is Value) return true;
            //Arithmetic Operations and constants/values
            if (this.Operands[0] is Constant && (this.Operands[1] is ArithmeticOperation && (this.Operands[1] as ArithmeticOperation).IsCoefficient())) return true;
            if (this.Operands[0] is Value && (this.Operands[1] is ArithmeticOperation && (this.Operands[1] as ArithmeticOperation).IsCoefficient())) return true;
            if ((this.Operands[0] is ArithmeticOperation && (this.Operands[0] as ArithmeticOperation).IsCoefficient()) && this.Operands[1] is Constant) return true;
            if ((this.Operands[0] is ArithmeticOperation && (this.Operands[0] as ArithmeticOperation).IsCoefficient()) && this.Operands[1] is Value) return true;
            //Arithmetic Operations and arithmetic operations
            if ((this.Operands[0] is ArithmeticOperation && (this.Operands[0] as ArithmeticOperation).IsCoefficient()) && (this.Operands[1] is ArithmeticOperation && (this.Operands[1] as ArithmeticOperation).IsCoefficient())) return true;

            return false;
        }
    }
}
