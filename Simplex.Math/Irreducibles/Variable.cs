using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Irreducibles;
using Simplex.Math.Classification;

namespace Simplex.Math
{
    /// <summary>
    /// Represents an unknown mathematical variable (such as "mass", "x", etc.)
    /// </summary>
    public class Variable : Irreducible
    {
        /// <summary>
        /// The commonly used variable "x".
        /// </summary>
        public static readonly Variable x = new Variable("x", "", "x", "A commonly used variable");

        /// <summary>
        /// The commonly used variable "y".
        /// </summary>
        public static readonly Variable y = new Variable("y", "", "y", "A commonly used variable");

        /// <summary>
        /// The commonly used variable "z".
        /// </summary>
        public static readonly Variable z = new Variable("z", "", "z", "A commonly used variable");

        /// <summary>
        /// Creates a new "anonymous" variable with only an ID.
        /// </summary>
        public Variable()
        {
            this.ID = Simplex.Math.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new variable with a particular symbol.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with this variable</param>
        public Variable(string Symbol)
        {
            this.Symbol = Symbol;
            this.ID = Simplex.Math.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new variable with a particular symbol and subscript.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with this variable</param>
        /// <param name="Subscript">The subscript to associate with this variable</param>
        public Variable(string Symbol, string Subscript)
        {
            this.Symbol = Symbol;
            this.Subscript = Subscript;
            this.ID = Simplex.Math.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new variable with a particular symbol, subscript, name, and description.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with this variable</param>
        /// <param name="Subscript">The subscript to associate with this variable</param>
        /// <param name="Name">The name to associate with this variable</param>
        /// <param name="Description">The description to associate with this variable</param>
        public Variable(string Symbol, string Subscript, string Name, string Description)
        {
            this.Symbol = Symbol;
            this.Subscript = Subscript;
            this.Name = Name;
            this.Description = Description;
            this.ID = Simplex.Math.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new variable with a particular symbol, subscript, name, and description.
        /// </summary>
        /// <param name="Scope">The scope associated with this particular variable</param>
        /// <param name="ID">The ID to assign to this variable</param>
        /// <param name="Symbol">The symbol to associate with this variable</param>
        /// <param name="Subscript">The subscript to associate with this variable</param>
        /// <param name="Name">The name to associate with this variable</param>
        /// <param name="Description">The description to associate with this variable</param>
        public Variable(Scope Scope, string ID, string Symbol, string Subscript, string Name, string Description) : base(Scope)
        {
            this.Symbol = Symbol;
            this.Subscript = Subscript;
            this.Name = Name;
            this.Description = Description;
            this.ID = ID;
            this.Scope.Register(this);
        }

        /// <summary>
        /// The name associated with this variable (for example, "Velocity").
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A description associated with this variable (for example, "The velocity of the first ball").
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// The symbol associated with printing this variable (for example, "v").
        /// </summary>
        public string Symbol
        {
            get;
            set;
        }

        /// <summary>
        /// The unique identifier associated with this variable.
        /// </summary>
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        /// A subscript (if any) associated with this variable (for example, a variable "x" with subscript "1" would be printed as "x_{1}" in LaTeX).
        /// </summary>
        public string Subscript
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

        public override bool ContainsExpressionType<T>()
        {
            //The base method contains all of the code we need since this is irreducible.
            return base.ContainsExpressionType<T>();
        }

        /// <summary>
        /// Obtains the string representation of this mathematical expression with specific formatting options.
        /// </summary>
        /// <param name="Format">The general format to use for the output</param>
        /// <param name="VariableFormat">The format to use for variables in the output</param>
        /// <param name="ConstantFormat">The format to use for constants and values in the output</param>
        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            if (VariableFormat == ExpressionStringVariableFormat.Default)
            {
                if (Format == ExpressionStringFormat.Default || Format == ExpressionStringFormat.ParseFriendly)
                {
                    if (this.Symbol != null && this.Symbol != string.Empty)
                    {
                        if (this.Subscript != null && this.Subscript != string.Empty)
                        {
                            return this.Symbol + "_[" + this.Subscript + "]";
                        }
                        else
                        {
                            return this.Symbol;
                        }
                    }
                    else if (this.Name != null && this.Name != string.Empty)
                    {
                        if (this.Name.Length == 1)
                        {
                            return this.Name;
                        }
                        else if (this.Name.Length > 1 && this.Name.Length <= 15)
                        {
                            return "\"" + this.Name + "\"";
                        }
                        else
                        {
                            return "\"" + this.Name.Substring(0, 5) + "...\"";
                        }
                    }
                    else if (this.ID != null && this.ID != string.Empty)
                    {
                        return "\"[" + this.ID.Substring(0, 5) + "...]\"";
                    }
                    else
                    {
                        throw new Exceptions.ExpressionParsingException("Unable to convert variable to string - No data in variable");
                    }
                }
                else if (Format == ExpressionStringFormat.LaTeX)
                {
                    if (this.Symbol != null && this.Symbol != string.Empty)
                    {
                        if (this.Subscript != null && this.Subscript != string.Empty)
                        {
                            return this.Symbol + "_{" + this.Subscript + "}";
                        }
                        else
                        {
                            return this.Symbol;
                        }
                    }
                    else if (this.Name != null && this.Name != string.Empty)
                    {
                        if (this.Name.Length == 1)
                        {
                            return this.Name;
                        }
                        else if (this.Name.Length > 1 && this.Name.Length <= 15)
                        {
                            return "\"" + this.Name + "\"";
                        }
                        else
                        {
                            return "\"" + this.Name.Substring(0, 5) + "...\"";
                        }
                    }
                    else if (this.ID != null && this.ID != string.Empty)
                    {
                        return "\"[" + this.ID.Substring(0, 5) + "...]\"";
                    }
                    else
                    {
                        throw new Exceptions.ExpressionParsingException("Unable to convert variable to string - No data in variable");
                    }
                }
                else
                {
                    throw new Exceptions.ExpressionParsingException("Unable to convert variable to string - Invalid ExpressionStringFormat");
                }
            }
            else if (VariableFormat == ExpressionStringVariableFormat.Symbol)
            {
                if (Format == ExpressionStringFormat.Default || Format == ExpressionStringFormat.ParseFriendly)
                {
                    if (this.Symbol != null && this.Symbol != string.Empty)
                    {
                        if (this.Subscript != null && this.Subscript != string.Empty)
                        {
                            return this.Symbol + "_[" + this.Subscript + "]";
                        }
                        else
                        {
                            return this.Symbol;
                        }
                    }
                    else
                    {
                        return "\"[UNKNOWN VARIABLE]\"";
                    }
                }
                else if (Format == ExpressionStringFormat.LaTeX)
                {
                    if (this.Symbol != null && this.Symbol != string.Empty)
                    {
                        if (this.Subscript != null && this.Subscript != string.Empty)
                        {
                            return this.Symbol + "_{" + this.Subscript + "}";
                        }
                        else
                        {
                            return this.Symbol;
                        }
                    }
                    else
                    {
                        return "\"[UNKNOWN VARIABLE]\"";
                    }
                }
                else
                {
                    throw new Exceptions.ExpressionParsingException("Unable to convert variable to string - Invalid ExpressionStringFormat");
                }
            }
            else if (VariableFormat == ExpressionStringVariableFormat.Name)
            {
                if (Format == ExpressionStringFormat.Default || Format == ExpressionStringFormat.ParseFriendly)
                {
                    if (this.Name != null && this.Name != string.Empty)
                    {
                        if (this.Name.Length == 1)
                        {
                            return this.Name;
                        }
                        else if (this.Name.Length > 1 && this.Name.Length <= 15)
                        {
                            return "\"" + this.Name + "\"";
                        }
                        else
                        {
                            return "\"" + this.Name.Substring(0, 5) + "...\"";
                        }
                    }
                    else
                    {
                        return "\"[UNKNOWN VARIABLE]\"";
                    }
                }
                else if (Format == ExpressionStringFormat.LaTeX)
                {
                    if (this.Name != null && this.Name != string.Empty)
                    {
                        if (this.Name.Length == 1)
                        {
                            return this.Name;
                        }
                        else if (this.Name.Length > 1 && this.Name.Length <= 15)
                        {
                            return "\"" + this.Name + "\"";
                        }
                        else
                        {
                            return "\"" + this.Name.Substring(0, 5) + "...\"";
                        }
                    }
                    else
                    {
                        return "\"[UNKNOWN VARIABLE]\"";
                    }
                }
                else
                {
                    throw new Exceptions.ExpressionParsingException("Unable to convert variable to string - Invalid ExpressionStringFormat");
                }
            }
            else if (VariableFormat == ExpressionStringVariableFormat.ID_Short)
            {
                if (Format == ExpressionStringFormat.Default || Format == ExpressionStringFormat.ParseFriendly)
                {
                    if (this.ID != null && this.ID != string.Empty)
                    {
                        return "\"[" + this.ID.Substring(0, 5) + "...]\"";
                    }
                    else
                    {
                        return "\"[UNKNOWN VARIABLE]\"";
                    }
                }
                else if (Format == ExpressionStringFormat.LaTeX)
                {
                    if (this.ID != null && this.ID != string.Empty)
                    {
                        return "\"[" + this.ID.Substring(0, 5) + "...]\"";
                    }
                    else
                    {
                        return "\"[UNKNOWN VARIABLE]\"";
                    }
                }
                else
                {
                    throw new Exceptions.ExpressionParsingException("Unable to convert variable to string - Invalid ExpressionStringFormat");
                }
            }
            else if (VariableFormat == ExpressionStringVariableFormat.ID_Long)
            {
                if (Format == ExpressionStringFormat.Default || Format == ExpressionStringFormat.ParseFriendly)
                {
                    if (this.ID != null && this.ID != string.Empty)
                    {
                        return "\"[" + this.ID + "]\"";
                    }
                    else
                    {
                        return "\"[UNKNOWN VARIABLE]\"";
                    }
                }
                else if (Format == ExpressionStringFormat.LaTeX)
                {
                    if (this.ID != null && this.ID != string.Empty)
                    {
                        return "\"[" + this.ID + "]\"";
                    }
                    else
                    {
                        return "\"[UNKNOWN VARIABLE]\"";
                    }
                }
                else
                {
                    throw new Exceptions.ExpressionParsingException("Unable to convert variable to string - Invalid ExpressionStringFormat");
                }
            }
            else
            {
                throw new Exceptions.ExpressionParsingException("Unable to convert variable to string - Invalid ExpressionStringVariableFormat");
            }
        }

        /// <summary>
        /// Converts this variable into a constant with all of the same identifying information.
        /// </summary>
        public Constant ToConstant()
        {
            return new Constant(this.Scope, this.ID, this.Symbol, this.Name, this.Description, this.Subscript, null);
        }

        /// <summary>
        /// Returns an identical copy of this variable.
        /// </summary>
        public override Expression Copy()
        {
            return new Variable(this.Scope, this.ID, this.Symbol, this.Subscript, this.Name, this.Description);
        }
    }
}
