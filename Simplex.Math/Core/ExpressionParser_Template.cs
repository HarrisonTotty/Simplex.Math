using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Irreducibles;
using Simplex.Math.Operations;

namespace Simplex.Math
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
//using Simplex.Math.Irreducibles;
//using Simplex.Math.Operations;

//namespace Simplex.Math
//{
//    public class BUILDEXPRESSION : ExpressionParser_Template
//    {
//        public Simplex.Math.Expression BuildExpression()
//        {
//            return (EXPRESSIONHERE);
//        }
//    }
//}
