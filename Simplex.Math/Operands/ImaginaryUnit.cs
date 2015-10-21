using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Core;

namespace Simplex.Math.Operands
{
    /// <summary>
    /// Represents the imaginary unit that forms the basis of the complex number system.
    /// </summary>
    public class ImaginaryUnit : Operand
    {
        /// <summary>
        /// The imaginary number
        /// </summary>
        public static readonly ImaginaryUnit i = new ImaginaryUnit();

        /// <summary>
        /// Creates a new imaginary unit (in most cases it is more practical to use the pre-initialized "ImaginaryUnit.i").
        /// </summary>
        public ImaginaryUnit()
        {
            
        }

        public override string ToString(ExpressionStringFormat Format, ExpressionStringVariableFormat VariableFormat, ExpressionStringConstantFormat ConstantFormat)
        {
            return "i";
        }
    }
}