﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Classification;
using Simplex.Math.Core;

namespace Simplex.Math.Operands
{
    /// <summary>
    /// A type of mathematical constant that has a descrete value.
    /// </summary>
    public class Value : Operand
    {
        //The following operators are for automatic conversion of integers and doubles to values
        public static implicit operator Value(double D) { return new Value(D); }
        public static implicit operator Value(int I) { return new Value(I); }
        public static explicit operator int (Value V) { return (int)V.InnerValue; }
        public static explicit operator double (Value V) { return (double)V.InnerValue; }

        //Inequality Operators associated with values
        public static bool operator >(Value V, int I) { return (V.InnerValue > I); }
        public static bool operator >=(Value V, int I) { return (V.InnerValue >= I); }
        public static bool operator <(Value V, int I) { return (V.InnerValue < I); }
        public static bool operator <=(Value V, int I) { return (V.InnerValue <= I); }
        public static bool operator >(Value V, double D) { return (V.InnerValue > D); }
        public static bool operator >=(Value V, double D) { return (V.InnerValue >= D); }
        public static bool operator <(Value V, double D) { return (V.InnerValue < D); }
        public static bool operator <=(Value V, double D) { return (V.InnerValue <= D); }
        public static bool operator >(int I, Value V) { return (I > V.InnerValue); }
        public static bool operator >=(int I, Value V) { return (I >= V.InnerValue); }
        public static bool operator <(int I, Value V) { return (I < V.InnerValue); }
        public static bool operator <=(int I, Value V) { return (I <= V.InnerValue); }
        public static bool operator >(double D, Value V) { return (D > V.InnerValue); }
        public static bool operator >=(double D, Value V) { return (D >= V.InnerValue); }
        public static bool operator <(double D, Value V) { return (D < V.InnerValue); }
        public static bool operator <=(double D, Value V) { return (D <= V.InnerValue); }
        public static bool operator >(Value V1, Value V2) { return (V1.InnerValue > V2.InnerValue); }
        public static bool operator >=(Value V1, Value V2) { return (V1.InnerValue >= V2.InnerValue); }
        public static bool operator <(Value V1, Value V2) { return (V1.InnerValue < V2.InnerValue); }
        public static bool operator <=(Value V1, Value V2) { return (V1.InnerValue <= V2.InnerValue); }

        //Equality operators associated with values
        public static bool operator ==(Value V, int I) { return (V.InnerValue == I); }
        public static bool operator ==(Value V, double D) { return (V.InnerValue == D); }
        public static bool operator !=(Value V, int I) { return (V.InnerValue != I); }
        public static bool operator !=(Value V, double D) { return (V.InnerValue != D); }
        public static bool operator ==(int I, Value V) { return (I == V.InnerValue); }
        public static bool operator ==(double D, Value V) { return (D == V.InnerValue); }
        public static bool operator !=(int I, Value V) { return (I != V.InnerValue); }
        public static bool operator !=(double D, Value V) { return (D != V.InnerValue); }

        public double InnerValue
        {
            get;
            set;
        }

        /// <summary>
        /// Classifying a variable, constant, or value will always return at least an intrinsic irriducible
        /// </summary>
        public override ClassifiedExpression[] Classify()
        {
            if (this.InnerValue < 0) return new ClassifiedExpression[] { new PolynomialTerm(-this) { IsNegated = true }, new DescreteValue(-this) { IsNegated = true } };
            return new ClassifiedExpression[] { new PolynomialTerm(this), new DescreteValue(this) };
        }

        public override bool IsEqualTo(Expression Comparison)
        {
            //If the comparison is a value, then it makes our job easier:
            if (Comparison is Value)
            {
                //If they have the same innder values, then they are equal
                if ((Comparison as Value).InnerValue == this.InnerValue) return true;
                return false;
            }

            //If the comparison is a constant with a particular value, the same applies:
            if (Comparison is Constant)
            {
                //If they have the same innder values, then they are equal
                if ((Comparison as Constant).HasDescreteValue) if ((Comparison as Constant).Value == this) return true;
                return false;
            }

            return base.IsEqualTo(Comparison);
        }

        /// <summary>
        /// Creates a new value object with a particular inner value.
        /// </summary>
        /// <param name="InnerValue">The actual value of the object</param>
        public Value(double InnerValue)
        {
            this.InnerValue = InnerValue;
        }

        /// <summary>
        /// Creates a new value object with the inner value of 0.
        /// </summary>
        public Value()
        {
            this.InnerValue = 0;
        }
    }
}
