using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;

namespace Simplex.Math.Arrays
{
    /// <summary>
    /// Represents a n*m matrix of discrete or symbolic expressions.
    /// </summary>
    public class Matrix : Tensor
    {
        /// <summary>
        /// Creates a new blank 2x2 matrix.
        /// </summary>
        public Matrix() : base(2, 2)
        {
            
        }

        /// <summary>
        /// Creates a new blank matrix with a particular number of rows and columns.
        /// </summary>
        /// <param name="NumberRows">The number of rows in this matrix</param>
        /// <param name="NumberColumns">The number of columns in this matrix</param>
        public Matrix(int NumberRows, int NumberColumns) : base(NumberRows, NumberColumns)
        {
            
        }

        /// <summary>
        /// The number of rows in this matrix.
        /// </summary>
        public int NumberRows
        {
            get
            {
                return base.UnderlyingDimensionalities[0];
            }
        }

        /// <summary>
        /// The number of columns in this matrix.
        /// </summary>
        public int NumberColumns
        {
            get
            {
                return base.UnderlyingDimensionalities[1];
            }
        }

        /// <summary>
        /// Gets/sets an element in this matrix at the specified row and column index.
        /// </summary>
        /// <param name="RowIndex">The row index of the element to access</param>
        /// <param name="ColumnIndex">The column index of the element to access</param>
        public Expression this[int RowIndex, int ColumnIndex]
        {
            get
            {
                return base[RowIndex, ColumnIndex];
            }
            set
            {
                base[RowIndex, ColumnIndex] = value;
            }
        }
    }
}
