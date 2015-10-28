using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Operands
{
    /// <summary>
    /// A particular type of value that represents a whole number.
    /// </summary>
    public class Integer : Value
    {
        //The following operators are for automatic conversion of integers and doubles to values
        public static explicit operator Integer(double D) { return new Integer((long)D); }
        public static implicit operator Integer(int I) { return new Integer(I); }
        public static implicit operator Integer(long I) { return new Integer(I); }
        public static explicit operator int (Integer I) { return (int)I.InnerValue; }
        public static explicit operator long (Integer I) { return I.InnerValue; }
        public static explicit operator double (Integer I) { return I.InnerValue; }

        /// <summary>
        /// Creates a new integer with a particular value.
        /// </summary>
        /// <param name="InnerValue">The value to set this integer to</param>
        public Integer(long InnerValue)
        {
            this.InnerValue = InnerValue;
        }

        /// <summary>
        /// Creates a new integer object with the inner value of 0.
        /// </summary>
        public Integer()
        {
            this.InnerValue = 0;
        }


        public new long InnerValue
        {
            get
            {
                return (long)base.InnerValue;
            }
            set
            {
                base.InnerValue = value;
            }
        }

        /// <summary>
        /// Whether the type of number this value represents is an integer.
        /// </summary>
        /// <remarks>
        /// Note that since this.Val is stored as a double, we will see if casting it to an int returns the same value!
        /// </remarks>
        public override bool IsInteger()
        {
            return true;
        }
    }
}