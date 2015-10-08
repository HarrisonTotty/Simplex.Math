using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;
using Simplex.Math.Operands;

namespace Simplex.Math.Classification
{
    /// <summary>
    /// Represents a particular classification of non-factorial arithmetic expressions containing only an elementary seqence of sums and/or differences.
    /// </summary>
    /// <remarks>
    /// Example: 3 + 4 + y + x - C + a
    /// 
    /// The sequence  3 + 4x + y  WOULD NOT be considered an elementary sum sequence because it contains products!
    /// </remarks>
    public class ElementarySumSequence : NonFactorialArithmeticExpression
    {
        public ElementarySumSequence(Expression UnderlyingExpression) : base(UnderlyingExpression)
        {
            
        }

        /// <summary>
        /// The list of terms contained within this sequence as tuples of the expression and whether it is positive.
        /// </summary>
        public List<IntrinsicIrreducible> Terms
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public static Expression Simplify(ElementarySumSequence Input)
        {
            //We start by creating a new list of terms for our result (which will hold the same number of items at most)
            List<Expression> NewTerms = new List<Expression>(Input.Terms.Count);

            //Add the first item to the list
            if (Input.Terms[0].IsNegated) NewTerms.Add(-Input.Terms[0].UnderlyingExpression);
            else NewTerms.Add(Input.Terms[0].UnderlyingExpression);

            //Now we add one item to the list at a time. We will compute the addition between items that are similar.
            for (int i = 1; i < Input.Terms.Count; i++)
            {
                //For each item in our new list
                bool foundmatch = false;
                for (int j = 0; j < NewTerms.Count; j++)
                {
                    //See if we have a match if we are a variable:
                    if (Input.Terms[i].UnderlyingExpression is Variable)
                    {
                        if (NewTerms[j].ContainsExpression(Input.Terms[i].UnderlyingExpression as Variable))
                        {
                            if (Input.Terms[i].IsNegated)
                            {
                                NewTerms[j] -= Input.Terms[i].UnderlyingExpression;
                            }
                            else
                            {
                                NewTerms[j] += Input.Terms[i].UnderlyingExpression;
                            }
                            foundmatch = true;
                            break;
                        }
                        continue;
                    }

                    //See if we have a match if we are a constant:
                    if (Input.Terms[i].UnderlyingExpression is Constant)
                    {
                        if (NewTerms[j].ContainsExpression(Input.Terms[i].UnderlyingExpression as Constant))
                        {
                            if (Input.Terms[i].IsNegated)
                            {
                                NewTerms[j] -= Input.Terms[i].UnderlyingExpression;
                            }
                            else
                            {
                                NewTerms[j] += Input.Terms[i].UnderlyingExpression;
                            }
                            foundmatch = true;
                            break;
                        }
                        continue;
                    }

                    //See if we have a match if we are a value:
                    if (Input.Terms[i].UnderlyingExpression is Value)
                    {
                        if (NewTerms[j] is Value)
                        {
                            if (Input.Terms[i].IsNegated)
                            {
                                NewTerms[j] -= Input.Terms[i].UnderlyingExpression;
                            }
                            else
                            {
                                NewTerms[j] += Input.Terms[i].UnderlyingExpression;
                            }
                            foundmatch = true;
                            break;
                        }
                        continue;
                    }
                }

                //If we couldn't find a match, just add it to the list.
                if (!foundmatch)
                {
                    if (Input.Terms[i].IsNegated) NewTerms.Add(-Input.Terms[i].UnderlyingExpression);
                    else NewTerms.Add(Input.Terms[i].UnderlyingExpression);
                }
            }

            //Once we have attempted to match everything, we clean up the output by simply returning the sum of all elements:
            NewTerms.Capacity = NewTerms.Count;
            Expression Output = 0;
            foreach (Expression E in NewTerms)
            {
                Output += E;
            }

            //Return our answer
            return Output;
        }
    }
}