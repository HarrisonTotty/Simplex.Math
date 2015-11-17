using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;
using Simplex.Math.Classification;

namespace Simplex.Math.Exceptions
{
    /// <summary>
    /// Represents a mathematical exception that is thrown when an error arises when trying to classify an expression.
    /// </summary>
    public class ClassificationException : SimplexMathException
    {
        /// <summary>
        /// Creates a new classification exception with a particular message.
        /// </summary>
        /// <param name="Message">The message associated with this exception</param>
        public ClassificationException(string Message) : base(Message)
        {
            
        }
    }
}