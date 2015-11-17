using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;

namespace Simplex.Math.Arrays
{
    /// <summary>
    /// Represents a tensor of a particular order/degree/rank and underlying dimenionality (if consistent).
    /// </summary>
    /// <remarks>
    /// Note that all of these examples have a consistent underlying dimensionality of 4!
    /// 
    /// A rank 1 tensor only has one "dimension" of data, and resembles a Vector:
    /// [6] [4] [8] [5]
    /// 
    /// A rank 2 tensor has two dimensions of data, resembling a Matrix:
    /// [6] [4] [8] [5]
    /// [2] [1] [9] [7]
    /// [1] [3] [5] [8]
    /// [5] [9] [0] [2]
    /// 
    /// A rank 3 tensor has three dimensions of data, resembling a "cube array":
    ///     Layer 1                 Layer 2                 Layer 3                 Layer 4
    /// [6] [4] [8] [5]         [1] [6] [4] [3]         [1] [3] [5] [8]         [1] [8] [9] [4]
    /// [2] [1] [9] [7]         [2] [0] [9] [8]         [1] [5] [7] [9]         [7] [2] [0] [2]
    /// [1] [3] [5] [8]         [5] [7] [5] [9]         [3] [6] [8] [0]         [6] [5] [0] [2]
    /// [5] [9] [0] [2]         [1] [1] [7] [4]         [8] [2] [1] [3]         [5] [9] [0] [3]
    /// 
    /// See https://en.wikipedia.org/wiki/Tensor for more info.
    /// </remarks>
    public class Tensor : Expression
    {
        /// <summary>
        /// Creates a new tensor of a specific order/rank/degree and underlying dimensionality of 2.
        /// </summary>
        /// <param name="Order">The order/rank/degree of the tensor</param>
        public Tensor(int Order) : base(DetermineFlatLength(Order, 2))
        {
            InitializeTensor(0);
        }

        /// <summary>
        /// Creates a new blank tensor of a particular set of underlying dimensionalities.
        /// </summary>
        /// <remarks>
        /// The "order" is not required because it is equal to the length of underlying dimensionalities.
        /// </remarks>
        /// <param name="UnderlyingDimensionalities">The number of components in each dimension of this tensor</param>
        public Tensor(params int[] UnderlyingDimensionalities) : base(DetermineFlatLength(TrimUnderlyingDimensionalities(UnderlyingDimensionalities)))
        {
            this.UnderlyingDimensionalities = TrimUnderlyingDimensionalities(UnderlyingDimensionalities);
            InitializeTensor(0);
        }

        /// <summary>
        /// The order/rank/degree of this tensor (the dimensionality of the array needed to represent this tensor) (see remarks).
        /// </summary>
        /// <remarks>
        /// From Wikipedia:
        /// The order (also degree) of a tensor is the dimensionality of the array needed to represent it, or equivalently, the number of indices needed to label a component of that array. 
        /// For example, a linear map is represented by a matrix (a 2-dimensional array) in a basis, and therefore is a 2nd-order tensor.
        /// A vector is represented as a 1-dimensional array in a basis, and is a 1st-order tensor.
        /// Scalars are single numbers and are thus 0th-order tensors.
        /// </remarks>
        public int Order
        {
            get
            {
                return this.UnderlyingDimensionalities.Length;
            }
        }

        /// <summary>
        /// The number of components in each dimension of order in this tensor.
        /// </summary>
        public int[] UnderlyingDimensionalities
        {
            get;
            set;
        }

        /// <summary>
        /// Removes all 1's (and lower) from an array of underlying dimensionalities to ensure order is calculated correctly.
        /// </summary>
        /// <param name="UnderlyingDimensionalities">The array of underlying dimensionalities to trim</param>
        private static int[] TrimUnderlyingDimensionalities(int[] UnderlyingDimensionalities)
        {
            try
            {
                return UnderlyingDimensionalities.Where(x => x > 1).ToArray();
            }
            catch (Exception)
            {
                return new int[] { 1 };
            }
        }


        /// <summary>
        /// Determines the necessary flat array length for a tensor with a particular set of underlying dimensionalities.
        /// </summary>
        /// <remarks>
        /// This is calculated by multiplying each integer value in the set of underlying dimensionalities.
        /// </remarks>
        /// <param name="UnderlyingDimensionalities">The number of components in each dimension of a tensor</param>
        public static int DetermineFlatLength(int[] UnderlyingDimensionalities)
        {
            if (UnderlyingDimensionalities == null || UnderlyingDimensionalities.Length < 1) return 0;
            int ReturnInt = UnderlyingDimensionalities[0];
            if (UnderlyingDimensionalities.Length > 1)
            {
                for (int i = 1; i < UnderlyingDimensionalities.Length; i++)
                {
                    ReturnInt *= UnderlyingDimensionalities[i];
                }
            }
            return ReturnInt;
        }

        /// <summary>
        /// Determines the necessary flat array length for a tensor of a particular order and consistent underlying dimensionality.
        /// </summary>
        /// <param name="Order">The order/rank/degree of a tensor</param>
        /// <param name="UnderlyingDimensionalities">The number of components in each dimension of a tensor</param>
        public static int DetermineFlatLength(int Order, int UnderlyingDimensionality)
        {
            return (int)System.Math.Pow(UnderlyingDimensionality, Order);
        }

        /// <summary>
        /// Gets/sets an element of the tensor at the specified index.
        /// </summary>
        /// <param name="Indicies">The indicies to pull an item from</param>
        public Expression this[params int[] Indicies]
        {
            get
            {
                if (Indicies.Length > this.Order) throw new Exceptions.SimplexMathException("Unable to get element of tensor - inavlid number of indicies");
                else if (Indicies.Length == this.Order)
                {
                    return this.ChildExpressions[this.IndiciesToFlatIndex(Indicies)];
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
            set
            {
                if (Indicies.Length > this.Order) throw new Exceptions.SimplexMathException("Unable to get element of tensor - inavlid number of indicies");
                else if (Indicies.Length == this.Order)
                {
                    this.ChildExpressions[this.IndiciesToFlatIndex(Indicies)] = value;
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Initializes this tensor with a particular expression at all indicies.
        /// </summary>
        /// <param name="CommonValue">The expression to propigate</param>
        private void InitializeTensor(Expression CommonValue)
        {
            if (this.ChildExpressions.Count > 0)
            {
                for (int i = 0; i < this.ChildExpressions.Count; i++)
                {
                    this.ChildExpressions[i] = CommonValue;
                }
            }
        }

        /// <summary>
        /// Retrieves a sub-tensor at the specified indicies.
        /// </summary>
        /// <param name="Indicies">The indicies to extract the sub-tensor from</param>
        public Tensor SubTensor(params int[] Indicies)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Takes a set of n-d indicies of an expression in this tensor and converts it to the corresponding flat index for the expression (see remarks).
        /// </summary>
        /// <remarks>
        /// This returns the index of the expression in this.ChildExpressions
        /// </remarks>
        /// <param name="Indicies">The indicies of the expression in this tensor</param>
        public int IndiciesToFlatIndex(params int[] Indicies)
        {
            if (Indicies.Length != this.Order) throw new Exceptions.SimplexMathException("Nope...");
            int ReturnInt = Indicies[0];
            if (Indicies.Length > 1)
            {
                ReturnInt *= this.UnderlyingDimensionalities[1];
                for (int i = 1; i < Indicies.Length; i++)
                {
                    if (i + 1 >= this.UnderlyingDimensionalities.Length) ReturnInt += Indicies[i];
                    else ReturnInt += Indicies[i] * this.UnderlyingDimensionalities[i + 1];
                }
            }

            return ReturnInt;
        }

        /// <summary>
        /// Takes the flat index of an expression in this tensor and converts it to its corresponding n-d indicies.
        /// </summary>
        /// <param name="FlatIndex">The flat index corresponding to an expression in this tensor</param>
        public int[] FlatIndexToIndicies(int FlatIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}
