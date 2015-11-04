using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Operands;
using Simplex.Math.Operations;

namespace Simplex.Math.Core
{
    /// <summary>
    /// The interface definition for the reflection class that is constructed when parsing mathematical expressions.
    /// </summary>
    public interface ExpressionParser_Template
    {
        /// <summary>
        /// Builds the expression, returning the corresponding expression object.
        /// </summary>
        Expression BuildExpression();
    }
}

//E X A M P L E
// -------------
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Simplex.Math.Operands;
//using Simplex.Math.Operations;

//namespace Simplex.Math.Core
//{
//    public class BUILDEXPRESSION : ExpressionParser_Template
//    {
//        public Simplex.Math.Core.Expression BuildExpression()
//        {
//            return (EXPRESSIONHERE);
//        }
//    }
//}
