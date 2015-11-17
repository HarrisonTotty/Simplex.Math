using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Exceptions
{
    /// <summary>
    /// Represents a mathematical exception that is thrown when an error arises when trying to simplify, expand, or contract an expression.
    /// </summary>
    public class SimplificationException : SimplexMathException
    {
        /// <summary>
        /// Creates a new simplification exception with a particular message.
        /// </summary>
        /// <param name="Message">The message associated with this exception</param>
        public SimplificationException(string Message) : base(Message)
        {

        }
    }
}