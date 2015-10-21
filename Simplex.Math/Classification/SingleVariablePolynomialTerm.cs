using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;
using Simplex.Math.Operands;
using Simplex.Math.Logic;
using Simplex.Math.Operations.Elementary;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a term of a polynomial that only relies on a single variable.
    /// </summary>
    public class SingleVariablePolynomialTerm : PolynomialTerm
    {
        public SingleVariablePolynomialTerm(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }

        /// <summary>
        /// The variable associated with this single-variable polynomial term.
        /// </summary>
        public Variable Variable
        {
            get
            {
                return (UnderlyingExpression.Extract(new Proposition(x => x is Variable))[0] as Variable);
            }
        }

        /// <summary>
        /// The degree of the variable in this single-variable polynomial term.
        /// </summary>
        public new int Degree
        {
            get;
        }


        public static Expression Add(SingleVariablePolynomialTerm E1, SingleVariablePolynomialTerm E2)
        {
            if (E1.Degree == E2.Degree && E1.Variable == E2.Variable)
            {
                return (E1.Coefficient + E2.Coefficient) * (E1.Variable ^ E1.Degree);
            }

            return new Sum(E1, E2);
        }

        public static Expression Subtract(SingleVariablePolynomialTerm E1, SingleVariablePolynomialTerm E2)
        {
            if (E1.Degree == E2.Degree && E1.Variable == E2.Variable)
            {
                return (E1.Coefficient - E2.Coefficient) * (E1.Variable ^ E1.Degree);
            }

            return new Difference(E1, E2);
        }

        public static Expression Multiply(SingleVariablePolynomialTerm E1, SingleVariablePolynomialTerm E2)
        {
            if (E1.Variable == E2.Variable)
            {
                return (E1.Coefficient * E2.Coefficient) * (E1.Variable ^ (E1.Degree + E2.Degree));
            }
            else
            {
                return (E1.Coefficient * E2.Coefficient) * (E1.Variable ^ E1.Degree) * (E2.Variable ^ E2.Degree);
            }
        }

        public static Expression Divide(SingleVariablePolynomialTerm E1, SingleVariablePolynomialTerm E2)
        {
            if (E1.Variable == E2.Variable)
            {
                return (E1.Coefficient / E2.Coefficient) * (E1.Variable ^ (E1.Degree - E2.Degree));
            }
            else
            {
                return (E1.Coefficient / E2.Coefficient) / (E1.Variable ^ E1.Degree) / (E2.Variable ^ E2.Degree);
            }
        }
    }
}