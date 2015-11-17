using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Operations.Elementary;

namespace Simplex.Math.Irreducibles
{
    /// <summary>
    /// Represents a particular type of value represented as a fraction or ratio between two integer values.
    /// </summary>
    public class Fraction : Value
    {
        private long Numerator_Field = 0;
        private long Denominator_Field = 0;

        /// <summary>
        /// Creates a new blank fraction.
        /// </summary>
        public Fraction()
        {
            this.Numerator = 0;
            this.Denominator = 0;
            this.Negated = false;
        }

        /// <summary>
        /// Creates a new fraction object with a particular numerator and denominator.
        /// </summary>
        /// <param name="Numerator">The numerator of the new fraction</param>
        /// <param name="Denominator">The denominator of the new fraction</param>
        public Fraction(long Numerator, long Denominator)
        {
            if (Numerator < 0 && Denominator >= 0)
            {
                this.Numerator = -Numerator;
                this.Denominator = Denominator;
                this.Negated = true;
            }
            else if (Numerator >= 0 && Denominator < 0)
            {
                this.Numerator = Numerator;
                this.Denominator = -Denominator;
                this.Negated = true;
            }
            else
            {
                this.Numerator = Numerator;
                this.Denominator = Denominator;
                this.Negated = false;
            }
        }

        /// <summary>
        /// The numerator of this fraction.
        /// </summary>
        public long Numerator
        {
            get
            {
                return this.Numerator_Field;
            }
            set
            {
                if (this.Negated)
                {
                    if (value < 0)
                    {
                        this.Negated = false;
                        this.Numerator_Field = -value;
                    }
                    else
                    {
                        this.Negated = true;
                        this.Numerator_Field = value;
                    }
                }
                else
                {
                    if (value < 0)
                    {
                        this.Negated = true;
                        this.Numerator_Field = -value;
                    }
                    else
                    {
                        this.Negated = false;
                        this.Numerator_Field = value;
                    }
                }
            }
        }

        /// <summary>
        /// The denominator of this fraction.
        /// </summary>
        public long Denominator
        {
            get
            {
                return this.Denominator_Field;
            }
            set
            {
                if (this.Negated)
                {
                    if (value < 0)
                    {
                        this.Negated = false;
                        this.Denominator_Field = -value;
                    }
                    else
                    {
                        this.Negated = true;
                        this.Denominator_Field = value;
                    }
                }
                else
                {
                    if (value < 0)
                    {
                        this.Negated = true;
                        this.Denominator_Field = -value;
                    }
                    else
                    {
                        this.Negated = false;
                        this.Denominator_Field = value;
                    }
                }
            }
        }

        /// <summary>
        /// The inner (decimal) value of this fraction.
        /// </summary>
        public new double InnerValue
        {
            get
            {
                if (this.Denominator == 0 && !this.Negated) return double.PositiveInfinity;
                if (this.Denominator == 0 && this.Negated) return double.NegativeInfinity;

                if (this.Negated) return -((double)this.Numerator / (double)this.Denominator);
                return (double)this.Numerator / (double)this.Denominator;
            }

            set
            {
                if (value == double.PositiveInfinity)
                {
                    this.Numerator = 1;
                    this.Denominator = 0;
                    this.Negated = false;
                }
                else if (value == double.NegativeInfinity)
                {
                    this.Numerator = 1;
                    this.Denominator = 0;
                    this.Negated = true;
                }
                else
                {

                }
            }
        }

        /// <summary>
        /// Whether this fraction is negated.
        /// </summary>
        public bool Negated
        {
            get;
            set;
        }

        /// <summary>
        /// Converts this fraction into a quotient object.
        /// </summary>
        public Quotient ToQuotient()
        {
            if (this.Negated)
            {
                return new Quotient(-this.Numerator, this.Denominator);
            }
            else
            {
                return new Quotient(this.Numerator, this.Denominator);
            }
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            //if (this.Val == (1.0 / 2.0)) return "½";
            //if (this.Val == (1.0 / 3.0)) return "⅓";
            //if (this.Val == (1.0 / 4.0)) return "¼";
            //if (this.Val == (1.0 / 8.0)) return "⅛";
            //if (this.Val == (2.0 / 3.0)) return "⅔";
            //if (this.Val == (3.0 / 4.0)) return "¾";
            //if (this.Val == (3.0 / 8.0)) return "⅜";
            //if (this.Val == (5.0 / 8.0)) return "⅝";
            //if (this.Val == (7.0 / 8.0)) return "⅞";

            if (Format == ExpressionStringFormat.Default)
            {
                string buildstring = "";
                if (this.Negated) buildstring += "-";
                if (this.InnerValue == (1.0 / 2)) return buildstring + "½";
                if (this.InnerValue == (1.0 / 3)) return buildstring + "⅓";
                if (this.InnerValue == (2.0 / 3)) return buildstring + "⅔";
                if (this.InnerValue == (1.0 / 4)) return buildstring + "¼";
                if (this.InnerValue == (3.0 / 4)) return buildstring + "¾";
                return buildstring + "(" + this.Numerator + "/" + this.Denominator + ")";
            }
            else
            {
                string buildstring = "";
                if (this.Negated) buildstring += "-";
                return buildstring + @"\frac{" + this.Numerator + "}{" + this.Denominator + "}";
            }
        }

        /// <summary>
        /// Creates a new fraction with a particular numerator and denominator (automatically reduces).
        /// </summary>
        /// <param name="Numerator">The numerator of the new fraction</param>
        /// <param name="Denominator">The denominator of the new fraction</param>
        public static Fraction Create(long Numerator, long Denominator)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates a new fraction from a decimal value (automatically reduces).
        /// </summary>
        /// <param name="DecimalValue">The value of the fraction</param>
        public static Fraction Create(decimal DecimalValue)
        {
            //Determine if this fraction is negated or not
            bool Negated = (DecimalValue < 0);

            //Seperate the fraction between its integer and decimal parts
            int IntegerPart = (int)System.Math.Abs(DecimalValue); //1.25 => 1  OR  -1.25 => 1  OR  0.25 => 0
            decimal DecimalPart = System.Math.Abs(DecimalValue) - IntegerPart; //1.25 - 1 => 0.25

            //Count the number of decimal places in the decimal part
            int DecimalPlaces = BitConverter.GetBytes(decimal.GetBits(DecimalPart)[3])[2];

            throw new System.NotImplementedException();
        }
    }
}
