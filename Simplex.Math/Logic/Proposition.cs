using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Irreducibles;

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
        //The different forms a proposition can have
        public delegate bool ConditionDelegate1(Expression E);
        public delegate bool ConditionDelegate2(Expression E1, Expression E2);
        public delegate bool ConditionDelegate3(Expression E1, Expression E2, Expression E3);
        public delegate bool ConditionDelegate4(Expression E1, Expression E2, Expression E3, Expression E4);
        public delegate bool ConditionDelegate5(Expression E1, Expression E2, Expression E3, Expression E4, Expression E5);
        //------------------------------------------

        /// <summary>
        /// Creates a new proposition with a single-parameter lambda expression.
        /// </summary>
        /// <param name="Condition">The lambda expression used to evaluate this proposition</param>
        public Proposition(System.Linq.Expressions.Expression<ConditionDelegate1> Condition)
        {
            this.Condition = Condition;
            this.NumberParameters = 1;
            CompileCondition();
        }

        /// <summary>
        /// Creates a new proposition with a 2-parameter lambda expression.
        /// </summary>
        /// <param name="Condition">The lambda expression used to evaluate this proposition</param>
        public Proposition(System.Linq.Expressions.Expression<ConditionDelegate2> Condition)
        {
            this.Condition = Condition;
            this.NumberParameters = 2;
            CompileCondition();
        }

        /// <summary>
        /// Creates a new proposition with a 3-parameter lambda expression.
        /// </summary>
        /// <param name="Condition">The lambda expression used to evaluate this proposition</param>
        public Proposition(System.Linq.Expressions.Expression<ConditionDelegate3> Condition)
        {
            this.Condition = Condition;
            this.NumberParameters = 3;
            CompileCondition();
        }

        /// <summary>
        /// Creates a new proposition with a 4-parameter lambda expression.
        /// </summary>
        /// <param name="Condition">The lambda expression used to evaluate this proposition</param>
        public Proposition(System.Linq.Expressions.Expression<ConditionDelegate4> Condition)
        {
            this.Condition = Condition;
            this.NumberParameters = 4;
            CompileCondition();
        }

        /// <summary>
        /// Creates a new proposition with a 5-parameter lambda expression.
        /// </summary>
        /// <param name="Condition">The lambda expression used to evaluate this proposition</param>
        public Proposition(System.Linq.Expressions.Expression<ConditionDelegate5> Condition)
        {
            this.Condition = Condition;
            this.NumberParameters = 5;
            CompileCondition();
        }

        /// <summary>
        /// Evaluates the proposition with the given mathematical expression(s).
        /// This will return "true" if the given mathematical expression(s) pass the proposition statement.
        /// </summary>
        /// <param name="Input">The mathematical expression(s) to evaluate the proposition under</param>
        public virtual bool Evaluate(params Expression[] Input)
        {
            //If we are given enough expressions to evaluate this proposition:
            if (Input.Length >= this.NumberParameters)
            {
                //Evaluate the proposition with the necessary number of parameters
                //try
                {
                    //string DEBUGSTRING = this.ToString();
                    if (this.NumberParameters == 1) return (Condition_Compiled as ConditionDelegate1)(Input[0]);
                    if (this.NumberParameters == 2) return (Condition_Compiled as ConditionDelegate2)(Input[0], Input[1]);
                    if (this.NumberParameters == 3) return (Condition_Compiled as ConditionDelegate3)(Input[0], Input[1], Input[2]);
                    if (this.NumberParameters == 4) return (Condition_Compiled as ConditionDelegate4)(Input[0], Input[1], Input[2], Input[3]);
                    if (this.NumberParameters == 5) return (Condition_Compiled as ConditionDelegate5)(Input[0], Input[1], Input[2], Input[3], Input[4]);
                }
                //catch (Exception ex)
                {
                    //throw new Exceptions.SimplexMathException("Unable to evalute proposition: {" + this.ToString() + "} (\"" + ex.Message + "\")...");
                }
            }

            //Otherwise, just return false
            return false;
        }

        /// <summary>
        /// Evaluates the proposition with the given mathematical expression(s).
        /// This will return "true" if the given mathematical expression(s) pass the proposition statement.
        /// </summary>
        /// <remarks>
        /// This is "prettier" than Proposition.Evaluate()
        /// </remarks>
        /// <param name="Input">The mathematical expression(s) to evaluate the proposition under</param>
        public virtual bool this[params Expression[] Input]
        {
            get
            {
                return this.Evaluate(Input);
            }
        }

        /// <summary>
        /// The lambda expression used to evaluate this proposition.
        /// </summary>
        private System.Linq.Expressions.Expression Condition
        {
            get;
            set;
        }

        private void CompileCondition()
        {
            try
            {
                if (this.NumberParameters == 1) Condition_Compiled = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate1>).Compile();
                if (this.NumberParameters == 2) Condition_Compiled = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate2>).Compile();
                if (this.NumberParameters == 3) Condition_Compiled = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate3>).Compile();
                if (this.NumberParameters == 4) Condition_Compiled = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate4>).Compile();
                if (this.NumberParameters == 5) Condition_Compiled = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate5>).Compile();
            }
            catch (Exception ex)
            {
                throw new Exceptions.LogicException("Unable to compile proposition statement - " + ex.Message);
            }
        }

        /// <summary>
        /// The pre-compiled varient of the condition lambda expression for evaluating this proposition.
        /// </summary>
        private Delegate Condition_Compiled
        {
            get;
            set;
        }

        /// <summary>
        /// Obtains the C# names of the variables in the lambda expression used as the condition for this proposition.
        /// </summary>
        public virtual List<string> ConditionVariableNames()
        {
            List<string> RL = new List<string>(this.NumberParameters);
            //foreach (var P in this.Condition.) RL.Add(P.ToString());
            return RL;
        }

        public override string ToString()
        {
            //Convert the predicate lambda statement to a string
            string PredicateString = "";
            if (this.NumberParameters == 1) PredicateString = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate1>).ToString();
            if (this.NumberParameters == 2) PredicateString = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate2>).ToString();
            if (this.NumberParameters == 3) PredicateString = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate3>).ToString();
            if (this.NumberParameters == 4) PredicateString = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate4>).ToString();
            if (this.NumberParameters == 5) PredicateString = (this.Condition as System.Linq.Expressions.Expression<ConditionDelegate5>).ToString();

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
        /// The number of operands/parameters that this proposition accepts
        /// </summary>
        public int NumberParameters
        {
            get;
            private set;
        }
    }
}
