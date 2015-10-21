using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;
using Simplex.Math.Logic;
using Simplex.Math.Operands;

namespace Simplex.Math.Sets
{
    /// <summary>
    /// Represents the mathematical set (a well-defined collection of elements).
    /// </summary>
    public class Set : Expression //This HAS to be an expression because sets can contain sets!
    {
        //The following are the implicit operator overloads for sets:
        public static implicit operator Set(Expression[] S) { return new Set(S); }
        public static implicit operator Set(List<Expression> S) { return new Set(S); }

        /// <summary>
        /// Represents the empty (or null) set.
        /// </summary>
        public static readonly Set Empty = new Set();

        /// <summary>
        /// Represents the set of all natural numbers, with zero.
        /// </summary>
        /// <remarks>
        /// 0, 1, 2, 3, 4...
        /// </remarks>
        public static readonly Set NaturalNumbers_WithZero = new Set(new Proposition(x => (x is Value) && (x as Value).IsInteger() && (x as Value) >= 0));

        /// <summary>
        /// Represents the set of all natural numbers.
        /// </summary>
        /// <remarks>
        /// 1, 2, 3, 4...
        /// </remarks>
        public static readonly Set NaturalNumbers = new Set(new Proposition(x => (x is Value) && (x as Value).IsInteger() && (x as Value) > 0));

        /// <summary>
        /// Represents the set of all integers.
        /// </summary>
        /// <remarks>
        /// ...-3, -2, -1, 0, 1, 2, 3...
        /// </remarks>
        public static readonly Set Integers = new Set(new Proposition(x => (x is Value) && (x as Value).IsInteger()));

        /// <summary>
        /// Represents the set of all positive integers (same as the set of natural numbers).
        /// </summary>
        /// <remarks>
        /// 1, 2, 3...
        /// </remarks>
        public static readonly Set PositiveIntegers = Set.NaturalNumbers;

        /// <summary>
        /// Represents the set of all negative integers.
        /// </summary>
        /// <remarks>
        /// ...-3, -2, -1
        /// </remarks>
        public static readonly Set NegativeIntegers = new Set(new Proposition(x => (x is Value) && (x as Value).IsInteger() && (x as Value) < 0));

        /// <summary>
        /// Represents the set of all integers, except zero.
        /// </summary>
        /// <remarks>
        /// ...-3, -2, -1, 1, 2, 3...
        /// </remarks>
        public static readonly Set NonZeroIntegers = new Set(new Proposition(x => (x is Value) && (x as Value).IsInteger() && (x as Value) != 0));

        /// <summary>
        /// Represents the set of all rational numbers.
        /// </summary>
        public static readonly Set RationalNumbers = new Set(new Proposition(x => (x is Value) && (x as Value).IsValueType<double>()));

        /// <summary>
        /// Represents the set of all positive rational numbers.
        /// </summary>
        public static readonly Set PositiveRationalNumbers = new Set(new Proposition(x => (x is Value) && (x as Value).IsValueType<double>() && (x as Value) > 0));

        /// <summary>
        /// Represents the set of all negative rational numbers.
        /// </summary>
        public static readonly Set NegativeRationalNumbers = new Set(new Proposition(x => (x is Value) && (x as Value).IsValueType<double>() && (x as Value) < 0));

        /// <summary>
        /// Represents the set of all rational numbers, except zero.
        /// </summary>
        public static readonly Set NonZeroRationalNumbers = new Set(new Proposition(x => (x is Value) && (x as Value).IsValueType<double>() && (x as Value) != 0));

        /// <summary>
        /// Represents the set of all real numbers.
        /// </summary>
        public static readonly Set RealNumbers = new Set(new Proposition(x => (x is Value)));

        /// <summary>
        /// Represents the set of all positive real numbers.
        /// </summary>
        public static readonly Set PositiveRealNumbers = new Set(new Proposition(x => (x is Value) && (x as Value) > 0));

        /// <summary>
        /// Represents the set of all negative real numbers.
        /// </summary>
        public static readonly Set NegativeRealNumbers = new Set(new Proposition(x => (x is Value) && (x as Value) < 0));

        /// <summary>
        /// Represents the set of all real numbers, except zero.
        /// </summary>
        public static readonly Set NonZeroRealNumbers = new Set(new Proposition(x => (x is Value) && (x as Value) != 0));

        /// <summary>
        /// Represents the set of all complex numbers.
        /// </summary>
        public static readonly Set ComplexNumbers = new Set(new Proposition(x => (x is Classification.NonFactorialArithmeticExpression) && x.ContainsExpression(ImaginaryUnit.i)));

        /// <summary>
        /// Represents the set of all complex numbers, except zero.
        /// </summary>
        public static readonly Set NonZeroComplexNumbers =  new Set(new Proposition(x => ComplexNumbers.ContainsExpression(x) && x != 0));

        /// <summary>
        /// Creates a new set with a particular proposition which must be valid for an element to be considered in the set.
        /// </summary>
        /// <param name="Condition">The proposition for which an element must return true in order to be considered in the set</param>
        public Set(Proposition Condition)
        {
            this.Condition = Condition;
        }

        /// <summary>
        /// Creates a new empty set.
        /// </summary>
        public Set()
        {

        }

        /// <summary>
        /// Creates a new set with the given descrete values.
        /// </summary>
        /// <param name="Values">The values to incorperate into this set</param>
        public Set(params Expression[] Values)
        {
            this.DescreteValues = Values.ToList();
        }

        /// <summary>
        /// Creates a new set with the given descrete values.
        /// </summary>
        /// <param name="Values">The values to incorperate into this set</param>
        public Set(List<Expression> Values)
        {
            this.DescreteValues = Values;
        }

        /// <summary>
        /// The proposition which must be valid for an element to be considered in the set.
        /// </summary>
        public Proposition Condition
        {
            get;
            set;
        }

        /// <summary>
        /// The descrete values which this set contains.
        /// </summary>
        /// <remarks>
        /// This is just another wrapper for the child expressions
        /// </remarks>
        public List<Expression> DescreteValues
        {
            get
            {
                return this.ChildExpressions;
            }
            set
            {
                this.ChildExpressions = value;
            }
        }

        /// <summary>
        /// Returns whether this set is considered a normal set, aka one that doesn't contain itself as an element.
        /// </summary>
        /// <remarks>
        /// "The set of all dogs" would be considered a normal set because obvously the set itself is not a dog.
        /// "The set of all things not dogs" however, would be a non-normal set because the set itself isn't a dog.
        /// </remarks>
        public bool IsNormal()
        {
            return !this.ContainsExpression(this);
        }

        /// <summary>
        /// Determines if this set contains the given expression (or other set) as an element.
        /// </summary>
        /// <param name="Element">The expression to test</param>
        public override bool ContainsExpression(Expression Element)
        {
            //Firstly, if we have a proposition, lets check it
            if (this.Condition != null)
            {
                if (this.Condition.Evaluate(Element)) return true;
            }

            //If we ARE the comparison, then we need to make sure we don't contain ourselves (because the base will mess this up)
            if (this == Element)
            {
                if (this.DescreteValues != null && this.DescreteValues.Count > 0)
                {
                    foreach (Expression E in this.DescreteValues)
                    {
                        if (Element == E) return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }

            //Otherwise send it to the base
            return base.ContainsExpression(Element);
        }

        /// <summary>
        /// Returns the element at a specific index in the set.
        /// </summary>
        /// <param name="Index">The 0-based index to check</param>
        public virtual Expression this[int Index]
        {
            get
            {
                if (this.DescreteValues == null || this.DescreteValues.Count < 0)
                {
                    throw new Exceptions.SimplexMathException("Cannot retrieve element in set at index - Set doesn't contain descrete values");
                }
                else
                {
                    return this.DescreteValues[Index];
                }
            }
            set
            {
                if (this.DescreteValues == null || this.DescreteValues.Count < 0)
                {
                    throw new Exceptions.SimplexMathException("Cannot set element in set at index - Set doesn't contain descrete values");
                }
                else
                {
                    this.DescreteValues[Index] = value;
                }
            }
        }

        public static Set Union(Set A, Set B)
        {
            throw new System.NotImplementedException();
        }

        public static Set Intersection(Set A, Set B)
        {
            throw new System.NotImplementedException();
        }

        public static Set Difference(Set A, Set B)
        {
            throw new System.NotImplementedException();
        }

        public static Set Complement(Set A, Set B)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            if (this == Set.Empty) return "Ø";
            if (this == Set.NaturalNumbers) return "{|N}";
            if (this == Set.NaturalNumbers_WithZero) return "{|N*}";
            if (this == Set.Integers) return "{|Z}";
            if (this == Set.PositiveIntegers) return "{|Z+}";
            if (this == Set.NegativeIntegers) return "{|Z-}";
            if (this == Set.NonZeroIntegers) return "{|Z*}";
            if (this == Set.RealNumbers) return "{|R}";
            if (this == Set.PositiveRealNumbers) return "{|R+}";
            if (this == Set.NegativeRealNumbers) return "{|R-}";
            if (this == Set.NonZeroRealNumbers) return "{|R*}";
            if (this == Set.ComplexNumbers) return "{|C}";
            if (this == Set.NonZeroComplexNumbers) return "{|C*}";

            //If we have conditions:
            //if (this.Conditions != null && this.Conditions.Length > 0)
            //{
            //    string VarName = this.Conditions[0].ConditionVariableName();

            //    //If we just have one condition:
            //    if (this.Conditions.Length == 1)
            //    {
            //        return "{" + VarName + "|" + this.Conditions[0].ToString() + "}";
            //    }
            //    else //Otherwise if we have more than one condition:
            //    {
            //        return "{" + VarName + "|" + this.Conditions[0].ToString() + ", ...}";
            //    }
            //}

            //If we have discrete values:
            if (this.DescreteValues != null && this.DescreteValues.Count > 0)
            {
                //If the descerete values converted to a string is more than 50 characters
                string ValueString = string.Empty;
                foreach (Expression E in this.DescreteValues)
                {
                    ValueString += E.ToString() + ", ";
                }
                ValueString = ValueString.Remove(ValueString.LastIndexOf(","));
                if (ValueString.Length > 25)
                {
                    return "{" + ValueString.Remove(20) + "...}";
                }
                else
                {
                    return "{" + ValueString + "}";
                }
            }

            //Otherwise we must be the null set:
            return "Ø";
        }
    }
}