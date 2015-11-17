using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Exceptions
{
    /// <summary>
    /// Represents a mathematical exception that is thrown when an error arises when trying to parse the string an expression.
    /// </summary>
    public class ExpressionParsingException : SimplexMathException
    {
        /// <summary>
        /// Creates a new parsing exception with a particular message.
        /// </summary>
        /// <param name="Message">The message associated with this exception</param>
        public ExpressionParsingException(string Message) : base(Message)
        {

        }
    }
}