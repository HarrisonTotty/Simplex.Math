using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Exceptions
{
    /// <summary>
    /// A generic mathematical exception error.
    /// </summary>
    public class SimplexMathException : Exception
    {
        /// <summary>
        /// Creates a new mathematical exception with a particular message.
        /// </summary>
        /// <param name="Message">The message associated with this exception</param>
        public SimplexMathException(string Message) : base(Message)
        {
            
        }
    }
}