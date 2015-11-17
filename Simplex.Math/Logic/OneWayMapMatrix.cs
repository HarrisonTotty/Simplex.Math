using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math;

namespace Simplex.Math.Logic
{
    public class OneWayMapMatrix : MapMatrix
    {
        /// <summary>
        /// Gets or sets a particular mapping of one expression to another (see remarks).
        /// </summary>
        /// <remarks>
        /// For a one-way map matrix, things change a bit
        /// EXAMPLES
        /// MapMatrix[x^2] = y      maps x^2 to y
        /// z = MapMatrix[y]        returns y
        /// z = MapMatrix[x^2]      sets z to y
        /// </remarks>
        /// <param name="Key">The expression in question</param>
        public override Expression this[Expression Key]
        {
            get
            {
                if (this.InnerMatrix.Keys.Contains(Key))
                {
                    return InnerMatrix[Key];
                }
                else
                {
                    return Key;
                }
            }
            set
            {
                if (InnerMatrix.Keys.Contains(Key))
                {
                    InnerMatrix[Key] = value;
                }
                else
                {
                    InnerMatrix.Add(Key, value);
                }
            }
        }

        /// <summary>
        /// Removes the mapping between two expressions.
        /// </summary>
        /// <remarks>
        /// Since this is one-way, we DO NOT go backwards.
        /// </remarks>
        /// <param name="A">The first expression</param>
        /// <param name="B">The second expression</param>
        public override void RemoveMap(Expression A, Expression B)
        {
            if (this[A].Equals(B)) this.InnerMatrix.Remove(A);
        }
    }
}