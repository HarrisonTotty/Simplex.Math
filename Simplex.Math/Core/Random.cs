using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simplex.Math.Irreducibles;
using Simplex.Math.Operations;

namespace Simplex.Math
{
    /// <summary>
    /// Provides various static methods for the generation of random numbers, expressions, and other data.
    /// </summary>
    public static class Random
    {
        /// <summary>
        /// General purpose pseudo-random generator.
        /// </summary>
        private static readonly System.Random RandomGen = new System.Random();

        /// <summary>
        /// Used to prevent parallel threads from accidentally generating the same random number.
        /// </summary>
        /// <remarks>
        /// See https://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number for more details.
        /// </remarks>
        private static readonly object GenSyncLock = new object();

        /// <summary>
        /// Generates a random integer value.
        /// </summary>
        /// <param name="Lowerbound">The lowerbound of the generated number (inclusive)</param>
        /// <param name="Upperbound">The upperbound of the generated number (inclusive)</param>
        public static int Integer(int Lowerbound, int Upperbound)
        {
            int ReturnInt = 0;
            lock (GenSyncLock)
            {
                ReturnInt = RandomGen.Next(Lowerbound, Upperbound + 1);
            }
            return ReturnInt;
        }

        /// <summary>
        /// Returns a random double value between two double values.
        /// </summary>
        /// <param name="Lowerbound">The lowerbound value</param>
        /// <param name="Upperbound">The upperbound value</param>
        public static double Double(double Lowerbound, double Upperbound)
        {
            lock (GenSyncLock)
            {
                return RandomGen.NextDouble() * (Upperbound - Lowerbound) + Lowerbound;
            }
        }

        /// <summary>
        /// Generates a random fraction between zero and one.
        /// </summary>
        public static void Fraction()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Generates a single-variable random polynomial in standard form with the specified minimum and maximum degree.
        /// </summary>
        /// <param name="MinDegree">The minimum degree for the resulting polynomial</param>
        /// <param name="MaxDegree">The maximum degree for the resulting polynomial</param>
        /// <param name="Variable">The variable to utilize in the creation of this polynomial</param>
        /// <remarks>
        /// Setting the maximum degree to 3 (for example) and the minimum to 0 (for example) DOES NOT guarentee that a component for all degrees 
        /// from zero to three will be generated. For example, the resulting polynomials could be:
        /// 3x^3                    OR
        /// 12                      OR
        /// 2x^2 + 4                OR
        /// 9x^3 + x^2 - 2x + 6
        /// </remarks>
        public static void Polynomial(int MinDegree, int MaxDegree, Variable Variable)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Returns a random boolean value.
        /// </summary>
        public static bool Boolean()
        {
            bool ReturnBool;
            lock (GenSyncLock)
            {
                ReturnBool = (RandomGen.Next(0, 2) == 1);
            }
            return ReturnBool;
        }


        /// <summary>
        /// Generates a new random alphanumeric string of a particular length.
        /// </summary>
        /// <param name="Length">The number of characters to generate</param>
        public static string AlphaNumeric(int Length)
        {
            string PickString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

            string ReturnString = "";

            lock (GenSyncLock)
            {
                for (int i = 0; i < Length; i++)
                {
                    ReturnString += PickString[RandomGen.Next(0, PickString.Length)];
                }
            }

            return ReturnString;
        }
    }
}
