using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
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
        /// <param name="Rules">The set of rules that govern the application of this operation</param>
        /// <param name="Arity">The number of operands this operation contains</param>
        /// <param name="IsIdempotent">Whether this mathematical operation is idempotent</param>
        public Operation(RuleSet Rules, int Arity, bool IsIdempotent) : base(Arity)
        {
            if (Arity < 0) throw new Exceptions.SimplexMathException("Trying to create a new mathematical operation with an arity less than zero? You must be mad!");
            this.IsIdempotent = IsIdempotent;
            this.Rules = Rules;
        }


        /// <summary>
        /// The arity of this particular operation (the number of operands required for this operation).
        /// </summary>
        public int Arity
        {
            get
            {
                return this.Operands.Count;
            }
            //set
            //{
            //    if (value > this.Operands.Capacity)
            //    {
            //        int numbertoadd = value - this.Operands.Capacity;
            //        for (int i = 0; i < numbertoadd; i++)
            //        {
            //            this.Operands.Add(null);
            //        }
            //    }
            //    else if (value < this.Operands.Capacity)
            //    {
            //        int numbertoremove = value - this.Operands.Capacity;
            //        for (int i = 0; i < numbertoremove; i++)
            //        {
            //            this.Operands.RemoveAt(this.Operands.Capacity - 1);
            //        }
            //    }
            //}
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

        /// <summary>
        /// The set of rules that this particular operation instance adheres to.
        /// </summary>
        public RuleSet Rules
        {
            get;
            protected set;
        }

        /// <summary>
        /// Recursively applies this operation to its operands (and each operation inside of this one to its own operands). Returns the operation as-is if no transform is available.
        /// </summary>
        public Expression Apply()
        {
            return this.Apply(false);
        }

        /// <summary>
        /// Applies this operation to its operands. Returns the operation as-is if no transform is available.
        /// </summary>
        /// <param name="SkipTransformTest">Whether to skip checking to see if the operands match a rule's qualifying proposition</param>
        public Expression Apply(bool SkipTransformTest)
        {
            //If this is an idempotent unary operation with the same expression as a child:
            if (this.Arity == 1 && this.IsIdempotent && this.Operands[0] is Operation && this.Operands[0].GetType() == this.GetType()) return (this.Operands[0] as Operation).Apply(SkipTransformTest);

            //Extract all of our operands into an array
            Expression[] O = this.Operands.ToArray();

            //Iterate through each operation in the array and see if it transforms
            for (int i = 0; i < O.Length; i++)
            {
                if (O[i] is Operation) if ((O[i] as Operation).CanTransform()) O[i] = (O[i] as Operation).Apply(true);
            }

            //If we skip the test to see if we can transform:
            if (SkipTransformTest)
            {
                return this.Rules.Apply(O);
            }
            else //Otherwise make sure we can transform:
            {
                //If this operation can transform:
                if (this.Rules.CanTransform(O))
                {
                    //Apply our rules to the input
                    return this.Rules.Apply(O);
                }
            }

            //If we can't combine anything, just return ourselves.
            return this;
        }

        /// <summary>
        /// Determines if this operation creates something other than its definition when applied to its operands (see remarks).
        /// </summary>
        /// <remarks>
        /// x + y => False
        /// x + x => True
        /// </remarks>
        public bool CanTransform()
        {
            //Extract all of our operands into an array
            Expression[] O = this.Operands.ToArray();

            //Iterate through each operation in the array and see if it transforms
            for (int i = 0; i < O.Length; i++)
            {
                if (O[i] is Operation) if ((O[i] as Operation).CanTransform()) return true;
            }

            //If none of our operands transform, do we transform?
            return this.Rules.CanTransform(O);
        }
    }
}
