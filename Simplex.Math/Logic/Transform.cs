using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;
using Simplex.Math.Sets;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents an object that takes an expression or expressions and converts it/them into a new expression.
    /// </summary>
    public class Transform
    {
        //The different forms a transform can have
        public delegate Expression TransformDelegate1(Expression E);
        public delegate Expression TransformDelegate2(Expression E1, Expression E2);
        public delegate Expression TransformDelegate3(Expression E1, Expression E2, Expression E3);
        public delegate Expression TransformDelegate4(Expression E1, Expression E2, Expression E3, Expression E4);
        public delegate Expression TransformDelegate5(Expression E1, Expression E2, Expression E3, Expression E4, Expression E5);
        //------------------------------------------

        /// <summary>
        /// Creates a new transform with a particular transform expression.
        /// </summary>
        /// <param name="TransformExpression">The lambda expression corresponding to the expression that is returned</param>
        public Transform(System.Linq.Expressions.Expression<TransformDelegate1> TransformExpression)
        {
            this.TransformExpression = TransformExpression;
            this.NumberParameters = 1;
            CompileTransformExpression();
        }

        /// <summary>
        /// Creates a new transform with a particular transform expression.
        /// </summary>
        /// <param name="TransformExpression">The lambda expression corresponding to the expression that is returned</param>
        public Transform(System.Linq.Expressions.Expression<TransformDelegate2> TransformExpression)
        {
            this.TransformExpression = TransformExpression;
            this.NumberParameters = 2;
            CompileTransformExpression();
        }

        /// <summary>
        /// Creates a new transform with a particular transform expression.
        /// </summary>
        /// <param name="TransformExpression">The lambda expression corresponding to the expression that is returned</param>
        public Transform(System.Linq.Expressions.Expression<TransformDelegate3> TransformExpression)
        {
            this.TransformExpression = TransformExpression;
            this.NumberParameters = 3;
            CompileTransformExpression();
        }

        /// <summary>
        /// Creates a new transform with a particular transform expression.
        /// </summary>
        /// <param name="TransformExpression">The lambda expression corresponding to the expression that is returned</param>
        public Transform(System.Linq.Expressions.Expression<TransformDelegate4> TransformExpression)
        {
            this.TransformExpression = TransformExpression;
            this.NumberParameters = 4;
            CompileTransformExpression();
        }

        /// <summary>
        /// Creates a new transform with a particular transform expression.
        /// </summary>
        /// <param name="TransformExpression">The lambda expression corresponding to the expression that is returned</param>
        public Transform(System.Linq.Expressions.Expression<TransformDelegate5> TransformExpression)
        {
            this.TransformExpression = TransformExpression;
            this.NumberParameters = 5;
            CompileTransformExpression();
        }


        /// <summary>
        /// The lambda expression used to evaluate this transform.
        /// </summary>
        public System.Linq.Expressions.Expression TransformExpression
        {
            get;
            set;
        }

        private void CompileTransformExpression()
        {
            try
            {
                if (this.NumberParameters == 1) TransformExpression_Compiled = (this.TransformExpression as System.Linq.Expressions.Expression<TransformDelegate1>).Compile();
                if (this.NumberParameters == 2) TransformExpression_Compiled = (this.TransformExpression as System.Linq.Expressions.Expression<TransformDelegate2>).Compile();
                if (this.NumberParameters == 3) TransformExpression_Compiled = (this.TransformExpression as System.Linq.Expressions.Expression<TransformDelegate3>).Compile();
                if (this.NumberParameters == 4) TransformExpression_Compiled = (this.TransformExpression as System.Linq.Expressions.Expression<TransformDelegate4>).Compile();
                if (this.NumberParameters == 5) TransformExpression_Compiled = (this.TransformExpression as System.Linq.Expressions.Expression<TransformDelegate5>).Compile();
            }
            catch (Exception ex)
            {
                throw new Exceptions.LogicException("Unable to compile transform statement - " + ex.Message);
            }
        }

        /// <summary>
        /// The compiled version of the transform expression
        /// </summary>
        public Delegate TransformExpression_Compiled
        {
            get;
            private set;
        }


        /// <summary>
        /// The number of operands/parameters that this transfrom accepts
        /// </summary>
        public int NumberParameters
        {
            get;
            private set;
        }

        /// <summary>
        /// Applies this transformation to an expression or expressions.
        /// </summary>
        /// <param name="Input">The expression(s) to transform</param>
        public virtual Expression Apply(params Expression[] Input)
        {
            //If we are given enough expressions to evaluate this transform:
            if (Input.Length >= this.NumberParameters)
            {
                //Evaluate the transform with the necessary number of parameters
                if (this.NumberParameters == 1) return (TransformExpression_Compiled as TransformDelegate1)(Input[0]);
                if (this.NumberParameters == 2) return (TransformExpression_Compiled as TransformDelegate2)(Input[0], Input[1]);
                if (this.NumberParameters == 3) return (TransformExpression_Compiled as TransformDelegate3)(Input[0], Input[1], Input[2]);
                if (this.NumberParameters == 4) return (TransformExpression_Compiled as TransformDelegate4)(Input[0], Input[1], Input[2], Input[3]);
                if (this.NumberParameters == 5) return (TransformExpression_Compiled as TransformDelegate5)(Input[0], Input[1], Input[2], Input[3], Input[4]);
            }

            //Otherwise, just return false
            if (Input.Length == 1) return Input[0];
            return new Set(Input);
        }

        /// <summary>
        /// Applies this transformation to an expression or expressions.
        /// </summary>
        /// <remarks>
        /// "Prettier" notation.
        /// </remarks>
        /// <param name="Input">The expression(s) to transform</param>
        public virtual Expression this[params Expression[] Input]
        {
            get
            {
                return this.Apply(Input);
            }
        }
    }
}