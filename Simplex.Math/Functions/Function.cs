using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;
using Simplex.Math.Operations.Elementary;
using Simplex.Math.Irreducibles;

namespace Simplex.Math.Functions
{
    /// <summary>
    /// Represents a mathematical function of one or more variables.
    /// </summary>
    /// <remarks>
    /// var f = new Function(x + y + z, x, y);
    /// f[1, 2] => 3 + z
    /// 
    /// The above is accomplished by substitution and then reevalutation.
    /// </remarks>
    public class Function : Expression
    {
        /// <summary>
        /// Creates a new empty-bodied function "f" with respect to a particular set of input variables.
        /// </summary>
        /// <param name="Variables">The input variables</param>
        public Function(params Variable[] Variables)
        {
            this.Variables = Variables.ToList();
            this.Variables.TrimExcess();
            this.Symbol = "f";
            this.ID = Random.AlphaNumeric(100);
        }

        /// <summary>
        /// Creates a new function "f" with respect to a particular set of input variables.
        /// </summary>
        /// <param name="Body">The body of the function</param>
        /// <param name="Variables">The input variables</param>
        public Function(Expression Body, params Variable[] Variables) : base(1)
        {
            this.Variables = Variables.ToList();
            this.Variables.TrimExcess();
            this.Body = Body;
            this.Symbol = "f";
            this.ID = Random.AlphaNumeric(100);
        }

        /// <summary>
        /// Creates a new function with respect to a particular set of input variables.
        /// </summary>
        /// <param name="Symbol">The symbol of this function</param>
        /// <param name="Body">The body of the function</param>
        /// <param name="Variables">The input variables</param>
        public Function(string Symbol, Expression Body, params Variable[] Variables) : base(1)
        {
            this.Variables = Variables.ToList();
            this.Variables.TrimExcess();
            this.Body = Body;
            this.Symbol = Symbol;
            this.ID = Random.AlphaNumeric(100);
        }

        /// <summary>
        /// Creates a new function with respect to a particular set of input variables.
        /// </summary>
        /// <param name="Symbol">The symbol of this function</param>
        /// <param name="Subscript">The subscript of this function</param>
        /// <param name="Body">The body of the function</param>
        /// <param name="Variables">The input variables</param>
        public Function(string Symbol, string Subscript, Expression Body, params Variable[] Variables) : base(1)
        {
            this.Variables = Variables.ToList();
            this.Variables.TrimExcess();
            this.Body = Body;
            this.Symbol = Symbol;
            this.Subscript = Subscript;
            this.ID = Random.AlphaNumeric(100);
        }

        /// <summary>
        /// The body expression of this function.
        /// </summary>
        public Expression Body
        {
            get
            {
                return this.ChildExpressions[0];
            }
            set
            {
                this.ChildExpressions[0] = value;
            }
        }

        /// <summary>
        /// The collection of variables this function accepts (in order).
        /// </summary>
        public List<Variable> Variables
        {
            get;
            set;
        }

        /// <summary>
        /// Returns this function evaluated with the input expressions as arguments.
        /// </summary>
        /// <param name="Expressions">The expressions to evaluate this function under</param>
        public Expression this[params Expression[] Expressions]
        {
            get
            {
                if (Expressions == null) throw new Exceptions.CalculationException("Unable to evaluate function - Null arguments");
                if (Expressions.Length < 1) throw new Exceptions.CalculationException("Unable to evaluate function - No arguments");
                if (this.GetArgumentCount() < 1) throw new Exceptions.CalculationException("Unable to evaluate function - Function takes no arguments");


                Expression Result = Body.Substitute(Variables[0], Expressions[0]);

                if (Variables.Count > 1 && Variables.Count <= Expressions.Length)
                {
                    for (int i = 1; i < Variables.Count; i++)
                    {
                        Result = Result.Substitute(Variables[i], Expressions[i], SubstitutionType.Identical);
                    }
                }
                else if (Expressions.Length > 1 && Expressions.Length <= Variables.Count)
                {
                    for (int i = 1; i < Expressions.Length; i++)
                    {
                        Result = Result.Substitute(Variables[i], Expressions[i], SubstitutionType.Identical);
                    }
                }

                //Simplify the result -- Old method
                //if (Result is Operations.Operation) if ((Result as Operations.Operation).CanTransform()) Result = (Result as Operations.Operation).Apply(true);

                //Simplify and return return the result
                return Math.Simplify(Result);
            }
        }

        /// <summary>
        /// The name associated with this function (for example, "Function 1").
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A description associated with this function (for example, "Takes an input value and squares it").
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// The symbol associated with printing this function (for example, "f").
        /// </summary>
        public string Symbol
        {
            get;
            set;
        }

        /// <summary>
        /// The unique identifier associated with this function.
        /// </summary>
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        /// A subscript (if any) associated with this function (for example, a function "f" with subscript "1" would be printed as "f_{1}" in LaTeX).
        /// </summary>
        public string Subscript
        {
            get;
            set;
        }

        /// <summary>
        /// Returns whether this function has a body.
        /// </summary>
        public bool HasBody()
        {
            return (this.Body != null);
        }

        /// <summary>
        /// Returns the number of arguments accepted by this function.
        /// </summary>
        public int GetArgumentCount()
        {
            if (this.Variables != null) return this.Variables.Count;
            return 0;
        }

        /// <summary>
        /// Obtains the string representation of this function.
        /// </summary>
        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            string N = this.Symbol; //FINISH ME - We need to get names right!
            string A = String.Join(", ", this.Variables.ConvertAll(x => x.ToString(Format, VariableFormat, ConstantFormat)));
            if (Format == ExpressionStringFormat.Default)
            {
                return N + "(" + A + ")";
            }
            else if (Format == ExpressionStringFormat.LaTeX)
            {
                return N + "(" + A + ")";
            }
            else if (Format == ExpressionStringFormat.ParseFriendly)
            {
                return N + "[" + A + "]";
            }
            else
            {
                throw new Exceptions.ExpressionParsingException("Unable to convert function to string - Invalid ExpressionStringFormat");
            }
        }

        /// <summary>
        /// Converts this function into a regular symbolic expression by returning the body expression with all non-arguments cast to constants.
        /// </summary>
        public Expression ToExpression()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates a new function from a given expression, assuming each variable in the expression as an argument.
        /// </summary>
        /// <param name="Body">The expression to create a function from</param>
        public static Function FromExpression(Expression Body)
        {
            throw new System.NotImplementedException();
        }
    }
}