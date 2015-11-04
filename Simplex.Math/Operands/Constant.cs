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
    /// Represents a mathematical constant which may or may not hold a value.
    /// </summary>
    public class Constant : Operand
    {
        /// <summary>
        /// Represents the mathematical constant associated with Euler's Number.
        /// </summary>
        public static readonly Constant e = new Constant("e", "Euler's Number", "A common mathematical constant that forms the base of the natural logarithm", "", System.Math.E);

        /// <summary>
        /// Represents the mathematical constant associated with Pi.
        /// </summary>
        public static readonly Constant pi = new Constant("π", "Pi", "The ratio of a circle's circumference to its diameter", "", System.Math.PI);

        /// <summary>
        /// Represents the mathematical constant associated with infinity.
        /// </summary>
        public static readonly Constant PositiveInfinity = new Constant("∞", "Infinity", "The mathematical constant associated with positive infinity", "", double.PositiveInfinity);

        /// <summary>
        /// Represents the mathematical constant associated with infinity.
        /// </summary>
        public static readonly Constant NegativeInfinity = new Constant("-∞", "Infinity", "The mathematical constant associated with negaive infinity", "", double.NegativeInfinity);

        /// <summary>
        /// The generic notion of a constant labled as "C".
        /// </summary>
        public static readonly Constant C = new Constant("C", "Generic Constant", "The generic notion of a constant labled 'C'.", "");

        /// <summary>
        /// The generic notion of a constant labled as "K".
        /// </summary>
        public static readonly Constant K = new Constant("K", "Generic Constant", "The generic notion of a constant labled 'K'.", "");


        /// <summary>
        /// Creates a new mathematical constant (which will have "C" as the default symbol).
        /// </summary>
        public Constant()
        {
            this.Symbol = "C";
            this.ID = Core.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new mathematical constant with a particular symbol.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with the mathematical constant</param>
        public Constant(string Symbol)
        {
            this.Symbol = Symbol;
            this.ID = Core.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new mathematical constant with a particular symbol and value.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with the mathematical constant</param>
        /// <param name="Value">The value to associate with the mathematical constant</param>
        public Constant(string Symbol, Value Value)
        {
            this.Symbol = Symbol;
            this.Value = Value;
            this.ID = Core.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new mathematical constant with a particular symbol and name.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with the mathematical constant</param>
        /// <param name="Name">The name to associate with the mathematical constant</param>
        public Constant(string Symbol, string Name)
        {
            this.Symbol = Symbol;
            this.Name = Name;
            this.ID = Core.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new mathematical constant with a particular symbol, name, and value.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with the mathematical constant</param>
        /// <param name="Name">The name to associate with the mathematical constant</param>
        /// <param name="Value">The value to associate with the mathematical constant</param>
        public Constant(string Symbol, string Name, Value Value)
        {
            this.Symbol = Symbol;
            this.Name = Name;
            this.Value = Value;
            this.ID = Core.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new mathematical constant with a particular symbol, name, description, and subscript.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with the mathematical constant</param>
        /// <param name="Name">The name to associate with the mathematical constant</param>
        /// <param name="Description">The description to associate with the mathematical constant</param>
        /// <param name="Subscript">The subscript to associate with the mathematical constant</param>
        public Constant(string Symbol, string Name, string Description, string Subscript)
        {
            this.Symbol = Symbol;
            this.Name = Name;
            this.Description = Description;
            this.Subscript = Subscript;
            this.ID = Core.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// Creates a new mathematical constant with a particular symbol, name, description, subscript and value.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with the mathematical constant</param>
        /// <param name="Name">The name to associate with the mathematical constant</param>
        /// <param name="Description">The description to associate with the mathematical constant</param>
        /// <param name="Subscript">The subscript to associate with the mathematical constant</param>
        /// <param name="Value">The value to associate with the mathematical constant</param>
        public Constant(string Symbol, string Name, string Description, string Subscript, Value Value)
        {
            this.Symbol = Symbol;
            this.Name = Name;
            this.Description = Description;
            this.Subscript = Subscript;
            this.Value = Value;
            this.ID = Core.Random.AlphaNumeric(100);
            this.Scope.Register(this);
        }

        /// <summary>
        /// The name associated with this constant (for example, "Pi").
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A description associated with this constant (for example, "The ratio of a circle's circumference to its diameter").
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// The symbol associated with printing this constant (for example, "π").
        /// </summary>
        public string Symbol
        {
            get;
            set;
        }

        /// <summary>
        /// The unique identifier associated with this constant.
        /// </summary>
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        /// The value (if any) associated with this constant (for example, "3.14...").
        /// </summary>
        public Value Value
        {
            get;
            set;
        }

        public bool HasDescreteValue
        {
            get
            {
                return ((this.Value as object) != null);
            }
        }

        /// <summary>
        /// A subscript (if any) associated with this constant (for example, a constant "C" with subscript "1" would be printed as "C_{1}" in LaTeX).
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
            if (this.HasDescreteValue)
            {
                return new ClassifiedExpression[] { new PolynomialTerm(this), new ValuedConstant(this) };
            }
            else
            {
                return new ClassifiedExpression[] { new PolynomialTerm(this), new GenericConstant(this) };
            }
        }


        /// <summary>
        /// Converts this constant to a generic form.
        /// Some constants such as infinity and "e" will not be converted.
        /// </summary>
        public override Expression ToGenericForm()
        {
            if (this == PositiveInfinity || this == e || this == pi) return this;
            return C;
        }

        /// <summary>
        /// Obtains the string representation of this mathematical expression with specific formatting options.
        /// </summary>
        /// <param name="Format">The general format to use for the output</param>
        /// <param name="VariableFormat">The format to use for variables in the output</param>
        /// <param name="ConstantFormat">The format to use for constants and values in the output</param>
        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            if (ConstantFormat == ExpressionStringConstantFormat.Default)
            {
                if (this.Symbol != string.Empty)
                {
                    if (this.Subscript != string.Empty)
                    {
                        if (Format == ExpressionStringFormat.Default || Format == ExpressionStringFormat.ParseFriendly)
                        {
                            return this.Symbol + "_[" + this.Subscript + "]";
                        }
                        else if (Format == ExpressionStringFormat.LaTeX)
                        {
                            return this.Symbol + "_{" + this.Subscript + "}";
                        }
                        else
                        {
                            throw new Exceptions.ExpressionParsingException("Unable to convert constant to string - Invalid ExpressionStringFormat");
                        }
                    }
                    else
                    {
                        return this.Symbol;
                    }
                }
                else
                {
                    if (this.HasDescreteValue)
                    {
                        return this.Value.ToString(Format, VariableFormat, ConstantFormat);
                    }
                    else
                    {
                        return "\"[UNKNOWN CONSTANT]\"";
                    }
                }
            }
            else if (ConstantFormat == ExpressionStringConstantFormat.Numeric)
            {
                if (this.HasDescreteValue)
                {
                    return this.Value.ToString(Format, VariableFormat, ConstantFormat);
                }
                else
                {
                    if (this.Symbol != string.Empty)
                    {
                        if (this.Subscript != string.Empty)
                        {
                            if (Format == ExpressionStringFormat.Default || Format == ExpressionStringFormat.ParseFriendly)
                            {
                                return this.Symbol + "_[" + this.Subscript + "]";
                            }
                            else if (Format == ExpressionStringFormat.LaTeX)
                            {
                                return this.Symbol + "_{" + this.Subscript + "}";
                            }
                            else
                            {
                                throw new Exceptions.ExpressionParsingException("Unable to convert constant to string - Invalid ExpressionStringFormat");
                            }
                        }
                        else
                        {
                            return this.Symbol;
                        }
                    }
                    else
                    {
                        return "\"[UNKNOWN CONSTANT]\"";
                    }
                }
            }
            else if (ConstantFormat == ExpressionStringConstantFormat.Symbolic)
            {
                if (this.Symbol != string.Empty)
                {
                    if (this.Subscript != string.Empty)
                    {
                        if (Format == ExpressionStringFormat.Default || Format == ExpressionStringFormat.ParseFriendly)
                        {
                            return this.Symbol + "_[" + this.Subscript + "]";
                        }
                        else if (Format == ExpressionStringFormat.LaTeX)
                        {
                            return this.Symbol + "_{" + this.Subscript + "}";
                        }
                        else
                        {
                            throw new Exceptions.ExpressionParsingException("Unable to convert constant to string - Invalid ExpressionStringFormat");
                        }
                    }
                    else
                    {
                        return this.Symbol;
                    }
                }
                else
                {
                    return "C";
                }
            }
            else
            {
                throw new Exceptions.ExpressionParsingException("Unable to convert constant to string - Invalid ExpressionStringConstantFormat");
            }
        }
    }
}
