using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math;
using Simplex.Math.Irreducibles;

namespace Simplex.Math.Arrays
{
    /// <summary>
    /// Represents a Euclidian vector of a particular number of dimensions (components).
    /// </summary>
    public class Vector : Matrix
    {
        /// <summary>
        /// Creates a new blank 2-dimensional vector. 
        /// </summary>
        public Vector() : base(1, 2)
        {
            
        }

        /// <summary>
        /// Creates a new blank vector of a particular number of dimensions. 
        /// </summary>
        /// <param name="Dimensionality">The number of dimensions stored in this vector (the number of components that make up this vector)</param>
        public Vector(int Dimensionality) : base(1, Dimensionality)
        {
            
        }


        /// <summary>
        /// Gets/sets a component of this vector at the specified index.
        /// </summary>
        /// <param name="Index">The index of the element to access</param>
        public Expression this[int Index]
        {
            get
            {
                return base[Index];
            }
            set
            {
                base[Index] = value;
            }
        }

        /// <summary>
        /// Gets/sets the magnitude (or length/norm) of this vector.
        /// </summary>
        public Expression Magnitude
        {
            get
            {
                return Simplex.Math.Math.Root(Simplex.Math.Math.SquareSum(this.ChildExpressions.ToArray()));
            }

            set
            {
                //Get the current direction of this vector
                Vector MyDirection = this.Direction;

                //Set this vector's components to the current direction multiplied by the new value
                for (int i = 0; i < this.Dimensionality; i++)
                {
                    this[i] = MyDirection[i] * value;
                }
            }
        }

        /// <summary>
        /// Get/sets the direction of this vector (the unit vector associated with normalizing this vector).
        /// </summary>
        public Vector Direction
        {
            get
            {
                Vector DirectionVector = new Vector(this.Dimensionality);

                //Get the magnitude
                Expression MyMag = Simplex.Math.Math.Root(Simplex.Math.Math.SquareSum(this.ChildExpressions.ToArray()));

                //Get the direction
                for (int i = 0; i < this.Dimensionality; i++)
                {
                    DirectionVector[i] = this[i] / MyMag;
                }
                return DirectionVector;
            }

            set
            {

            }
        }

        /// <summary>
        /// The number of dimensions of this vector (the number of components that make up this vector).
        /// </summary>
        public int Dimensionality
        {
            get
            {
                return this.ChildExpressions.Count;
            }

            set
            {
            }
        }
    }
}
