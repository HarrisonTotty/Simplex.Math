using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Logic;

namespace Simplex.Math.Operations
{
    /// <summary>
    /// Represents a mathematical operation of a particular arity (EX: Addition)
    /// </summary>
    public abstract class Operation : Expression
    {

        /// <summary>
        /// Creates a new mathematical operation of a particular number of possible operands.
        /// </summary>
        /// <param name="Arity">The number of operands this operation contains</param>
        /// <param name="IsIdempotent">Whether this mathematical operation is idempotent</param>
        public Operation(int Arity, bool IsIdempotent) : base(Arity)
        {
            if (Arity < 0) throw new Exceptions.SimplexMathException("Trying to create a new mathematical operation with an arity less than zero? You must be mad!");
            this.IsIdempotent = IsIdempotent;
        }


        /// <summary>
        /// The arity of this particular operation (the number of operands required for this operation).
        /// </summary>
        public int Arity
        {
            get
            {
                return this.Operands.Capacity;
            }
            set
            {
                if (value > this.Operands.Capacity)
                {
                    int numbertoadd = value - this.Operands.Capacity;
                    for (int i = 0; i < numbertoadd; i++)
                    {
                        this.Operands.Add(null);
                    }
                }
                else if (value < this.Operands.Capacity)
                {
                    int numbertoremove = value - this.Operands.Capacity;
                    for (int i = 0; i < numbertoremove; i++)
                    {
                        this.Operands.RemoveAt(this.Operands.Capacity - 1);
                    }
                }
            }
        }

        /// <summary>
        /// The different operands of this operation. This is the same as "this.ChildExpressions".
        /// For example, the operands of "2 + x" are "2" and "x"
        /// </summary>
        public List<Expression> Operands
        {
            get
            {
                return this.ChildExpressions;
            }

            set
            {
                this.ChildExpressions = value;
            }
        }

        /// <summary>
        /// Whether this mathematical operation is idempotent (see remarks or wikipedia article on Idempotence).
        /// </summary>
        /// <remarks>
        /// A unary operation is idempotent if, whenever it is applied twice to any value, it gives the same result as if it were applied once. (EX: ((x + 2)) = (x + 2))
        /// A binary operation is idempotent if, whenever it is applied to two equal values, it gives that value as the result. (EX: maximum(x, x) = x)
        /// </remarks>
        public bool IsIdempotent
        {
            get;
            set;
        }
    }
}
