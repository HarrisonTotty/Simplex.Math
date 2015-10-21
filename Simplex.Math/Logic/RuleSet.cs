using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;
using Simplex.Math.Sets;

namespace Simplex.Math.Logic
{
    /// <summary>
    /// Represents a collection of rules for which (an) expression(s) can be passed through.
    /// </summary>
    public class RuleSet
    {
        /// <summary>
        /// Creates a new blank rule set with no qualifying proposition.
        /// </summary>
        public RuleSet()
        {
            
        }

        /// <summary>
        /// Creates a new rule set with no qualifying proposition.
        /// </summary>
        /// <param name="Rules">The rules to include in this rule set</param>
        public RuleSet(params Rule[] Rules)
        {
            this.Rules = Rules.ToList();
        }

        /// <summary>
        /// Creates a new rule set with a global qualifying proposition
        /// </summary>
        /// <param name="QualifyingProposition">The proposition an input expression must match in order to qualify for this set of rules</param>
        /// <param name="Rules">The rules to include in this rule set</param>
        public RuleSet(Proposition QualifyingProposition, params Rule[] Rules)
        {
            this.QualifyingProposition = QualifyingProposition;
            this.Rules = Rules.ToList();
        }

        /// <summary>
        /// The rules associated with this rule set.
        /// </summary>
        public List<Rule> Rules
        {
            get;
            set;
        }

        /// <summary>
        /// The proposition an input expression must match in order to qualify for this set of rules.
        /// </summary>
        public Proposition QualifyingProposition
        {
            get;
            set;
        }

        /// <summary>
        /// Applies this rule set to an expression or list of expressions.
        /// In this case, the first qualifying transform will be executed.
        /// </summary>
        /// <param name="Input">The expression(s) to apply to</param>
        public Expression Apply(params Expression[] Input)
        {
            //If we have no rules, return the input
            if (this.Rules == null || this.Rules.Count < 1)
            {
                if (Input.Length > 1) return new Set(Input);
                return Input[0];
            }
            else //Otherwise, if we have rules:
            {
                //If we have a qualifying proposition:
                if (this.QualifyingProposition != null)
                {
                    //...and the input doesn't pass it:
                    if (!this.QualifyingProposition.Evaluate(Input))
                    {
                        //Return the input
                        if (Input.Length > 1) return new Set(Input);
                        return Input[0];
                    }
                }

                //Now lets check every rule
                foreach(Rule R in this.Rules)
                {
                    if (R.Qualifies(Input)) return R.Apply(Input);
                }

                //If no rules work
                if (Input.Length > 1) return new Set(Input);
                return Input[0];
            }
        }

        /// <summary>
        /// Applies this rule set to an expression or list of expressions.
        /// In this case, all qualifying transforms will be returned as a list of expressions.
        /// </summary>
        /// <param name="Input">The expression(s) to apply to</param>
        public List<Expression> ApplyAll(params Expression[] Input)
        {
            //If we have no rules, return the input
            if (this.Rules == null || this.Rules.Count < 1)
            {
                if (Input.Length > 1) return new Expression[] { new Set(Input) }.ToList();
                return new Expression[] { Input[0] }.ToList();
            }
            else //Otherwise, if we have rules:
            {
                //If we have a qualifying proposition:
                if (this.QualifyingProposition != null)
                {
                    //...and the input doesn't pass it:
                    if (!this.QualifyingProposition.Evaluate(Input))
                    {
                        //Return the input
                        if (Input.Length > 1) return new Expression[] { new Set(Input) }.ToList();
                        return new Expression[] { Input[0] }.ToList();
                    }
                }

                //Now lets check every rule
                List<Expression> ReturnList = new List<Expression>();
                foreach (Rule R in this.Rules)
                {
                    if (R.Qualifies(Input)) ReturnList.Add(R.Apply(Input));
                }

                ReturnList.Capacity = ReturnList.Count;
                return ReturnList;
            }
        }

        /// <summary>
        /// Returns whether an expression or list of expressions qualify for this rule set.
        /// NOTE: This does not mean that an input expression will be transformed!
        /// </summary>
        /// <param name="Input">The expression(s) to test</param>
        public bool Qualifies(params Expression[] Input)
        {
            if (this.QualifyingProposition == null) return true;
            return (this.QualifyingProposition.Evaluate(Input));
        }

        /// <summary>
        /// Returns whether an expression or list of expressions qualify for this rule set and can be transformed.
        /// </summary>
        /// <param name="Input">The expression(s) to test</param>
        public bool CanTransform(params Expression[] Input)
        {
            if (!this.Qualifies(Input)) return false;

            if (this.Rules != null && this.Rules.Count > 0)
            {
                foreach (Rule R in this.Rules)
                {
                    if (R.Qualifies(Input)) return true;
                }
            }

            return false;
        }
    }
}