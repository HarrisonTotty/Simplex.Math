using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Logic;
using Simplex.Math.Operands;

namespace Simplex.Math.Operations.Elementary
{
    /// <summary>
    /// Represents the multiplication of two expressions.
    /// </summary>
    public class Product : ArithmeticOperation
    {
        /// <summary>
        /// The pre-built sequence of rules that we will use to calculate products.
        /// </summary>
        private static Rule[] RuleArray = new Rule[]
        {   
            // 2 * 3 = 6
            new Rule(Propositions.AreValues, Transforms.ValueMultiply),
            // x * x = x^2
            new Rule(Propositions.AreEqual, Transforms.SquareExpression),
            // x * (1 / x) = 1
            new Rule(Propositions.AreReciprocals, Transforms.ToOne),
            // 1 * x = x
            new Rule(Propositions.FirstOne, Transforms.ReturnSecondExpression),
            // x * 1 = x
            new Rule(Propositions.SecondOne, Transforms.ReturnFirstExpression),
            // 0 * x = 0
            new Rule(Propositions.FirstZero, Transforms.ToZero),
            // x * 0 = 0
            new Rule(Propositions.SecondZero, Transforms.ToZero),
            //Inf * x = Inf
            new Rule(Propositions.EitherInfinity, Transforms.ToInfinity),

        };

        /// <summary>
        /// The rule set associated with products.
        /// </summary>
        public static RuleSet Rules = new RuleSet(RuleArray);


        /// <summary>
        /// Creates a new product from a given left and right expression.
        /// </summary>
        /// <param name="LeftExpression">The expression associated with the left side of the operation</param>
        /// <param name="RightExpression">The expression associated with the right side of the operation</param>
        public Product(Expression LeftExpression, Expression RightExpression) : base(LeftExpression, RightExpression, true, false, true)
        {
            
        }

        /// <summary>
        /// The mathematical expression corresponding to the left side of this product.
        /// </summary>
        public Expression LeftExpression
        {
            get
            {
                return this.Operands[0];
            }

            set
            {
                this.Operands[0] = value;
            }
        }

        /// <summary>
        /// The mathematical expression corresponding to the right side of this product.
        /// </summary>
        public Expression RightExpression
        {
            get
            {
                return this.Operands[1];
            }

            set
            {
                this.Operands[1] = value;
            }
        }

        /// <summary>
        /// Computes the symbolic multiplication between two expressions.
        /// </summary>
        /// <param name="E1">The first expression</param>
        /// <param name="E2">The second expression</param>
        public static Expression Multiply(Expression E1, Expression E2)
        {
            //If we qualify for transform via our ruleset:
            if (Product.Rules.CanTransform(E1, E2))
            {
                //Apply our rules to the input
                return Product.Rules.Apply(E1, E2);
            }

            //If we can't combine anything, just create a new object
            return new Product(E1, E2);
        }

        /// <summary>
        /// Makes a copy of this operation.
        /// </summary>
        public override Expression Copy()
        {
            return new Product(this.LeftExpression.Copy(), this.RightExpression.Copy());
        }

        /// <summary>
        /// Whether this product represents a negation.
        /// </summary>
        public bool IsNegation()
        {
            return (this.LeftExpression == -1 || this.RightExpression == -1);
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            return this.LeftExpression.ToString(Format, VariableFormat, ConstantFormat) + " * " + this.RightExpression.ToString(Format, VariableFormat, ConstantFormat);
        }
    }
}
