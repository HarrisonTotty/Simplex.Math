using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a logic matrix in which a particular expression is mapped to another expression.
    /// The generic form of map matrix goes in both directions.
    /// </summary>
    public class MapMatrix
    {

        /// <summary>
        /// Creates a new blank map matrix.
        /// </summary>
        public MapMatrix()
        {
            this.InnerMatrix = new Dictionary<Expression, Expression>();
        }

        /// <summary>
        /// Creates a new map matrix between two arrays of expressions.
        /// Arrays must be the same length.
        /// </summary>
        /// <param name="ExpressionList1">The first array of expressions</param>
        /// <param name="ExpressionList2">The second array of expressions</param>
        public MapMatrix(Expression[] ExpressionList1, Expression[] ExpressionList2)
        {
            if (ExpressionList1 == null || ExpressionList2 == null) throw new Exceptions.SimplexMathException("Unable to construct map matrix - Null input expression array(s)");
            if (ExpressionList1.Length == 0 || ExpressionList2.Length == 0) throw new Exceptions.SimplexMathException("Unable to construct map matrix - Empty input expression array(s)");
            if (ExpressionList1.Length != ExpressionList2.Length) throw new Exceptions.SimplexMathException("Unable to construct map matrix - Input expressions have different lengths");

            this.InnerMatrix = new Dictionary<Expression, Expression>();
            for (int i = 0; i < ExpressionList1.Length; i++)
            {
                this[ExpressionList1[i]] = ExpressionList2[i];
            }
        }

        /// <summary>
        /// Creates a new map matrix between two arrays of expressions by mapping expressions according to which pairs pass a qualifying proposition (see remarks).
        /// Arrays don't have to be the same size.
        /// </summary>
        /// <remarks>
        /// If given the following two arrays and proposition
        /// {0, 1, 2, 3, 4, 5, 6, 7}
        /// {4, 4, 3, 3, 2, 2, 1, 1}
        /// (x, y) => x > y
        /// Would yeild the following map (if we aren't doing a 1-way matrix):
        /// {4 -> 2, 2 -> 5, 5 -> 2, 6 -> 1, 1 -> 7, 7 -> 1}
        /// </remarks>
        /// <param name="ExpressionList1">The first array of expressions</param>
        /// <param name="ExpressionList2">The second array of expressions</param>
        /// <param name="QualifyingProposition">The qualifying proposition that a pair of expressions must pass in order to be mapped</param>
        public MapMatrix(Expression[] ExpressionList1, Expression[] ExpressionList2, Proposition QualifyingProposition)
        {
            if (QualifyingProposition.NumberParameters != 2) throw new Exceptions.SimplexMathException("Unable to construct map matrix - Qualifying proposition must have 2 parameters");
            if (ExpressionList1 == null || ExpressionList2 == null) throw new Exceptions.SimplexMathException("Unable to construct map matrix - Null input expression array(s)");
            if (ExpressionList1.Length == 0 || ExpressionList2.Length == 0) throw new Exceptions.SimplexMathException("Unable to construct map matrix - Empty input expression array(s)");

            this.InnerMatrix = new Dictionary<Expression, Expression>();
            for (int i = 0; i < ExpressionList1.Length; i++)
            {
                for (int j = 0; j < ExpressionList2.Length; j++)
                {
                    if (QualifyingProposition.Evaluate(ExpressionList1[i], ExpressionList2[j]))
                    {
                        this[ExpressionList1[i]] = ExpressionList2[j];
                    }
                }
            }
        }



        /// <summary>
        /// Gets or sets a particular mapping of one expression to another (see remarks).
        /// </summary>
        /// <remarks>
        /// EXAMPLES
        /// MapMatrix[x^2] = y      maps x^2 to y
        /// z = MapMatrix[y]        sets z to x^2
        /// z = MapMatrix[x^2]      sets z to y
        /// </remarks>
        /// <param name="Key">The expression in question</param>
        public virtual Expression this[Expression Key]
        {
            get
            {
                if (this.InnerMatrix.Keys.Contains(Key))
                {
                    return InnerMatrix[Key];
                }
                else
                {
                    return Key;
                }
            }
            set
            {
                if (InnerMatrix.Keys.Contains(Key))
                {
                    InnerMatrix[Key] = value;
                }
                else
                {
                    InnerMatrix.Add(Key, value);
                }

                if (InnerMatrix.Keys.Contains(value))
                {
                    InnerMatrix[value] = Key;
                }
                else
                {
                    InnerMatrix.Add(value, Key);
                }
            }
        }

        /// <summary>
        /// Gets or sets the mapping for an array of key expressions that match a qualifying proposition (see remarks).
        /// </summary>
        ///<remarks>
        /// EXAMPLE:
        /// For a map matrix with the following maps:
        /// M = {x -> y, a -> b, m -> n}
        /// The following proposition:
        /// M["key is a letter after c"] would return {y, n}
        /// 
        /// FOR SETTING:
        /// Note that we are setting it equal to AN ARRAY. In this array, the following algorithm is used:
        /// Each match gets a new member of the set array until we run out of members (at which the assignment restarts)
        /// 
        /// 
        /// EXAMPLE:
        /// For a map matrix with the following maps:
        /// M = {x -> y, a -> b, c -> d, m -> n, o -> p}
        /// The following statement:
        /// M["key is a letter after c"] = { 0 }
        /// Would result in:
        /// M = {x -> 0, a -> b, c -> d, m -> 0, o -> 0}
        /// 
        /// The following statement:
        /// M["key is a letter after c"] = { 0, 1, 2 }
        /// Would result in:
        /// M = {x -> 0, a -> b, c -> d, m -> 1, o -> 2}
        /// 
        /// The following statement:
        /// M["key is a letter after c"] = { 0, 1 }
        /// Would result in:
        /// M = {x -> 0, a -> b, c -> d, m -> 1, o -> 0}
        /// </remarks>
        /// <param name="QualifyingProposition">The qualifying proposition</param>
        public virtual List<Expression> this[Proposition QualifyingProposition]
        {
            get
            {
                List<Expression> OutputList = new List<Expression>();
                foreach (var key in this.InnerMatrix.Keys)
                {
                    if (QualifyingProposition.Evaluate(key)) OutputList.Add(this[key]);
                }

                OutputList.Capacity = OutputList.Count;
                return OutputList;
            }
            set
            {
                int SetIndex = 0;
                foreach (var key in this.InnerMatrix.Keys)
                {
                    if (QualifyingProposition.Evaluate(key))
                    {
                        this[key] = value[SetIndex];
                        if (SetIndex == value.Count - 1) SetIndex = 0;
                        else SetIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the mapping for an array of key expressions that match a qualifying proposition for both the keys and their respective maps (see remarks).
        /// </summary>
        /// <param name="KeyQualifyingProposition">The qualifying proposition a key must pass in order to be considered for a get/set</param>
        /// <param name="ValueQualifyingProposition">The qualifying proposition the map of a passing key must pass in order to be get/set</param>
        public virtual List<Expression> this[Proposition KeyQualifyingProposition, Proposition ValueQualifyingProposition]
        {
            get
            {
                List<Expression> OutputList = new List<Expression>();
                foreach (var key in this.InnerMatrix.Keys)
                {
                    if (KeyQualifyingProposition.Evaluate(key)) if (ValueQualifyingProposition.Evaluate(this[key])) OutputList.Add(this[key]);
                }

                OutputList.Capacity = OutputList.Count;
                return OutputList;
            }
            set
            {
                int SetIndex = 0;
                foreach (var key in this.InnerMatrix.Keys)
                {
                    if (KeyQualifyingProposition.Evaluate(key))
                    {
                        if (ValueQualifyingProposition.Evaluate(this[key]))
                        {
                            this[key] = value[SetIndex];
                            if (SetIndex == value.Count - 1) SetIndex = 0;
                            else SetIndex++;
                        }
                    }
                }
            }
        }

        protected Dictionary<Expression, Expression> InnerMatrix
        {
            get;
            set;
        }

        /// <summary>
        /// Determines if this map matrix has a particular expression mapped.
        /// </summary>
        /// <param name="Input">The expression to check</param>
        public bool ContainsMap(Expression Input)
        {
            return (this.InnerMatrix.Keys.Contains(Input));
        }

        /// <summary>
        /// Determines if this map matrix has a particular expression mapped that matches a given proposition.
        /// </summary>
        /// <param name="Input">The qualifying proposition</param>
        public bool ContainsMap(Proposition QualifyingProposition)
        {
            foreach (var key in this.InnerMatrix.Keys)
            {
                if (QualifyingProposition.Evaluate(key)) return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the mapping between two expressions.
        /// </summary>
        /// <param name="A">The first expression</param>
        /// <param name="B">The second expression</param>
        public virtual void RemoveMap(Expression A, Expression B)
        {
            if (this[A].Equals(B)) this.InnerMatrix.Remove(A);
            if (this[B].Equals(A)) this.InnerMatrix.Remove(B);
        }
    }
}