﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents a classical binary arithmetic operation such as addition, subtraction, multiplication, division, log, or exponentiation.
    /// </summary>
    public abstract class ElementaryOperation : BinaryOperation
    {
        /// <summary>
        /// Creates a new elementary operation with a pair of operands.
        /// </summary>
        /// <param name="Operand1">The first (or "left") operand</param>
        /// <param name="Operand2">The second (or "right") operand</param>
        /// <param name="IsCommutative">Whether this operation is commutative</param>
        /// <param name="IsAnticommutative">Whether this operation is anticommutative</param>
        /// <param name="IsAssociative">Whether this operation is associative</param>
        public ElementaryOperation(Expression Operand1, Expression Operand2, bool IsCommutative, bool IsAnticommutative, bool IsAssociative) : base(Operand1, Operand2, IsCommutative, IsAnticommutative, false, IsAssociative)
        {
            
        }
    }
}
