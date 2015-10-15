using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Core;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a mathematical statement that communicates one or more facts.
    /// Propositions may be true or false.
    /// </summary>
    /// <remarks>
    /// Propositions are essentially a wrapper for lambda expressions in C#
    /// </remarks>
    public class Proposition
    {
        /// <summary>
        /// Evaluates the proposition with the given mathematical expression(s).
        /// This will return "true" if the given mathematical expression(s) pass the proposition statement.
        /// </summary>
        /// <param name="Input">The mathematical expression(s) to evaluate the proposition under</param>
        public virtual bool Evaluate(params Expression[] Input)
        {
            return false;
        }

        /// <summary>
        /// Obtains the C# name of the variable in the lambda expression used as the condition for this proposition.
        /// </summary>
        public virtual string ConditionVariableName()
        {
            throw new Exceptions.SimplexMathException("Unable to obtain variable name for proposition.");
        }
    }

    /// <summary>
    /// Represents a mathematical statement that communicates one or more facts.
    /// Propositions may be true or false.
    /// </summary>
    /// <typeparam name="T">The type of mathematical expression that this proposition accepts</typeparam>
    public class Proposition<T> : Proposition where T : Expression
    {
        /// <summary>
        /// Creates a new proposition with a particular condition as a lambda expression.
        /// </summary>
        /// <remarks>
        /// See the remarks for property "Condition" below for more information as to why we use a System.Linq.Expressions.Expression object.
        /// </remarks>
        /// <param name="Condition">The lambda expression used to evaluate this proposition</param>
        public Proposition(System.Linq.Expressions.Expression<Predicate<T>> Condition)
        {
            this.Condition = Condition;
        }

        /// <summary>
        /// The lambda expression used to evaluate this proposition.
        /// </summary>
        /// <remarks>
        /// We use a System.Linq.Expressions.Expression object instead of just a Predicate object so that we can access members for printing.
        /// </remarks>
        public System.Linq.Expressions.Expression<Predicate<T>> Condition
        {
            get;
            set;
        }

        /// <summary>
        /// Evaluates the proposition with the given mathematical expression(s).
        /// This will return "true" if the given mathematical expression(s) pass the proposition statement.
        /// </summary>
        /// <param name="Input">The mathematical expression(s) to evaluate the proposition under</param>
        public override bool Evaluate(params Expression[] Input)
        {
            if (!(Input[0] is T)) return false;
            return Condition.Compile()(Input[0] as T);
        }

        public override string ToString()
        {
            //Convert the predicate lambda statement to a string
            string PredicateString = this.Condition.ToString();

            //Remove the part before "=>"
            PredicateString = PredicateString.Substring(PredicateString.IndexOf("=>") + 2);

            //If the expression doesn't contain && or ||, remove unneccessary parenthesis
            if (!PredicateString.Contains("AndAlso") && !PredicateString.Contains("OrElse"))
                PredicateString = PredicateString.Replace("(", string.Empty).Replace(")", string.Empty);

            //Replace "AndAlso" with "∧" and "OrElse" with "∨"
            PredicateString = PredicateString.Replace("AndAlso", "∧");
            PredicateString = PredicateString.Replace("OrElse", "∨");
            PredicateString = PredicateString.Replace("Not", "¬");
            PredicateString = PredicateString.Replace("==", "=");
            PredicateString = PredicateString.Replace("!=", "≠");

            //Return the predicate string (but trim off extra spaces first)
            return PredicateString.Trim();
        }

        /// <summary>
        /// Obtains the C# name of the variable in the lambda expression used as the condition for this proposition.
        /// </summary>
        public override string ConditionVariableName()
        {
            return this.Condition.Parameters[0].ToString();
        }
    }


    /// <summary>
    /// Represents a mathematical statement that communicates one or more facts.
    /// Propositions may be true or false.
    /// </summary>
    /// <typeparam name="T1">The first type of mathematical expression that this proposition accepts</typeparam>
    /// <typeparam name="T2">The second type of mathematical expression that this proposition accepts</typeparam>
    public class Proposition<T1, T2> : Proposition where T1 : Expression where T2 : Expression
    {
        /// <summary>
        /// The generic delegate format for evaluating two input expressions.
        /// </summary>
        /// <param name="E1">The first expression to evaluate the delegate with</param>
        /// <param name="E2">The second expression to evaluate the delegate with</param>
        public delegate bool CD(T1 E1, T2 E2);

        /// <summary>
        /// Creates a new proposition with a single lambda expression between two variables.
        /// </summary>
        /// <param name="Condition">The lambda expression used to evaluate this proposition</param>
        public Proposition(System.Linq.Expressions.Expression<CD> Condition)
        {
            this.Condition = Condition;
        }


        /// <summary>
        /// The lambda expression used to evaluate this proposition.
        /// </summary>
        /// <remarks>
        /// We use a System.Linq.Expressions.Expression object instead of just a Predicate object so that we can access members for printing.
        /// </remarks>
        public System.Linq.Expressions.Expression<CD> Condition
        {
            get;
            set;
        }


        public override bool Evaluate(params Expression[] Input)
        {
            if (Input.Length < 2) return false;
            if (!(Input[0] is T1)) return false;
            if (!(Input[1] is T2)) return false;
            return Condition.Compile()(Input[0] as T1, Input[1] as T2);
        }
    }
}
