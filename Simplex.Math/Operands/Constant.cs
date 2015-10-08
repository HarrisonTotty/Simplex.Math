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
        public static readonly Constant e = new Constant("e", "Euler's Number", "A common mathematical constant that forms the base of the natural logarithm", "", 2.71828182845904523536028747135266249775724709369995);

        /// <summary>
        /// Represents the mathematical constant associated with Pi.
        /// </summary>
        public static readonly Constant pi = new Constant("π", "Pi", "The ratio of a circle's circumference to its diameter", "", 3.1415926535897932384626433832795028842);

        /// <summary>
        /// Creates a new mathematical constant (which will have "C" as the default symbol).
        /// </summary>
        public Constant()
        {
            this.Symbol = "C";
            this.ID = Core.Random.AlphaNumeric(100);
        }

        /// <summary>
        /// Creates a new mathematical constant with a particular symbol.
        /// </summary>
        /// <param name="Symbol">The symbol to associate with the mathematical constant</param>
        public Constant(string Symbol)
        {
            this.Symbol = Symbol;
            this.ID = Core.Random.AlphaNumeric(100);
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
        /// <remarks>
        /// This is now generated using GUID.
        /// </remarks>
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
                return (this.Value != null);
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


        public override bool IsEqualTo(Expression Comparison)
        {
            if (Comparison is Constant)
            {
                
            }
            return base.IsEqualTo(Comparison);
        }

        public override Expression ToGenericForm()
        {
            return base.ToGenericForm();
        }
    }
}
