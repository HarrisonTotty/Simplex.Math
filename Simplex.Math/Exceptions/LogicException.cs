using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;

namespace Simplex.Math.Exceptions
{
    /// <summary>
    /// Represents a mathematical exception that is thrown when an error arises when trying to initialize/execute methematical logical operations such as propositions, transforms, or rules.
    /// </summary>
    public class LogicException : SimplexMathException
    {
        /// <summary>
        /// Creates a new logic exception with a particular message.
        /// </summary>
        /// <param name="Message">The message associated with this exception</param>
        public LogicException(string Message) : base(Message)
        {

        }
    }
}
