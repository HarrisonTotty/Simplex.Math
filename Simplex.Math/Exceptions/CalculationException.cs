using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Exceptions
{
    /// <summary>
    /// Represents a mathematical exception that is thrown when an error arises when trying to calculate a value.
    /// </summary>
    public class CalculationException : SimplexMathException
    {
        /// <summary>
        /// Creates a new calculation exception with a particular message.
        /// </summary>
        /// <param name="Message">The message associated with this exception</param>
        public CalculationException(string Message) : base(Message)
        {

        }
    }
}