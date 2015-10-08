using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;
using Simplex.Math.Classification;

namespace Simplex.Math.Operands
{
    /// <summary>
    /// Represents an unknown mathematical variable (such as "mass", "x", etc.)
    /// </summary>
    public class Variable : Operand
    {
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Symbol
        {
            get;
            set;
        }

        public string ID
        {
            get;
            set;
        }

        /// <summary>
        /// Classifying a variable, constant, or value will always return at least an intrinsic irriducible
        /// </summary>
        public override ClassifiedExpression[] Classify()
        {
            return new ClassifiedExpression[] { new Indeterminate(this) , new SingleVariableCoefficientlessPolynomialTerm(this) };
        }

        /// <summary>
        /// Determine if this variable is equivalent to another expression.
        /// </summary>
        /// <param name="Comparison">The expression to compare this variable to</param>
        public override bool IsEqualTo(Expression Comparison)
        {
            //If the comparison is a variable, then it makes our job easier
            if (Comparison is Variable)
            {
                //If they have the same IDs, then they are equal
                if ((Comparison as Variable).ID == this.ID) return true;
                else return false;
            }

            return base.IsEqualTo(Comparison);
        }

        /// <summary>
        /// Determine if this variable is similar to another expression.
        /// </summary>
        /// <param name="Comparison">The expression to compare this variable to</param>
        public override bool IsSimilarTo(Expression Comparison)
        {
            if (Comparison is Variable) return this.IsEqualTo(Comparison);
            return base.IsSimilarTo(Comparison);
        }

        /// <summary>
        /// Determine if this variable is identical to another expression.
        /// </summary>
        /// <param name="Comparison">The expression to compare this variable to</param>
        public override bool IsIdenticalTo(Expression Comparison)
        {
            if (Comparison is Variable) return this.IsEqualTo(Comparison);
            return false;
        }

        public override bool ContainsExpressionType<T>()
        {
            //The base method contains all of the code we need since this is irreducible.
            return base.ContainsExpressionType<T>();
        }
    }
}
