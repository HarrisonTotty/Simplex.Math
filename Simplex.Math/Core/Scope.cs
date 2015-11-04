using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Math.Operands;
using Simplex.Math.Logic;

namespace Simplex.Math.Core
{
    /// <summary>
    /// Represents a particular "mathematical universe" in which mathematical expressions and mappings reside (see remarks).
    /// </summary>
    /// <remarks>
    /// These are important because it allows us to save our work 
    /// as well as create maps between variables and other expressions without unwanted consequences.
    /// </remarks>
    public class Scope
    {
        /// <summary>
        /// The global scope into which all expressions are created by default.
        /// </summary>
        public static readonly Scope Global = new Scope();

        /// <summary>
        /// Creates a new empty scope.
        /// </summary>
        public Scope()
        {
            this.Constants = new Dictionary<string, Constant>();
            this.ExpressionMappings = new MapMatrix();
            this.Variables = new Dictionary<string, Variable>();
        }

        /// <summary>
        /// A registry of all created variables, stored by ID.
        /// </summary>
        public Dictionary<string, Variable> Variables
        {
            get;
            private set;
        }

        /// <summary>
        /// A registry of all created constants, stored by ID.
        /// </summary>
        public Dictionary<string, Constant> Constants
        {
            get;
            private set;
        }

        /// <summary>
        /// A collection of all expression maps within this scope.
        /// </summary>
        public MapMatrix ExpressionMappings
        {
            get;
            set;
        }

        /// <summary>
        /// Registeres a variable with this particular scope.
        /// Overrides any previously existing variables with the same ID as the one provided.
        /// </summary>
        /// <param name="V">The variable to register</param>
        public void Register(Variable V)
        {
            if (!this.Variables.ContainsKey(V.ID)) this.Variables.Add(V.ID, V);
            else this.Variables[V.ID] = V;
        }

        /// <summary>
        /// Registeres a constant with this particular scope.
        /// Overrides any previously existing constants with the same ID as the one provided.
        /// </summary>
        /// <param name="C">The constant to register</param>
        public void Register(Constant C)
        {
            if (!this.Constants.ContainsKey(C.ID)) this.Constants.Add(C.ID, C);
            else this.Constants[C.ID] = C;
        }

        /// <summary>
        /// Converts all objects in this scope to their string representations.
        /// </summary>
        public override string ToString()
        {
            string ReturnString = "";
            string NL = Environment.NewLine;

            ReturnString += "VARIABLES:" + NL;
            ReturnString += "----------" + NL;
            foreach (var key in this.Variables.Keys)
            {
                ReturnString += key.ToString() + " -> " + this.Variables[key.ToString()].ToString() + NL;
            }
            ReturnString += NL;
            ReturnString += "CONSTANTS:" + NL;
            ReturnString += "----------" + NL;
            foreach (var key in this.Constants.Keys)
            {
                ReturnString += key.ToString() + " -> " + this.Constants[key.ToString()].ToString() + NL;
            }


            return ReturnString;
        }

        /// <summary>
        /// Gets an operand (variable/constant) defined in this scope by its matching string representation.
        /// Returns first match and null if no operand was found.
        /// </summary>
        /// <param name="MatchString">The string an operand's string must match to be selected</param>
        /// <param name="VF">The string format variables are converted to for comparison</param>
        /// <param name="CF">The string format constants are converted to for comparison</param>
        public Operand Get(string MatchString, ExpressionStringVariableFormat VF, ExpressionStringConstantFormat CF)
        {
            //Firstly, lets check for the default variables and constants
            if (MatchString == "x") return Variable.x;
            if (MatchString == "y") return Variable.y;
            if (MatchString == "z") return Variable.z;
            if (MatchString == "C") return Constant.C;
            if (MatchString == "K") return Constant.K;
            if (MatchString == "pi") return Constant.pi;
            if (MatchString == "e") return Constant.e;
            if (MatchString == "Infinity" || MatchString == "PositiveInfinity") return Constant.PositiveInfinity;
            if (MatchString == "NegativeInfinity") return Constant.NegativeInfinity;
            if (MatchString == "i") return ImaginaryUnit.i;

            //Lets combine our variables and constants into one list
            List<Operand> CheckList = new List<Operand>();
            if (this.Variables != null && this.Variables.Count > 0) CheckList.AddRange(this.Variables.Values);
            if (this.Constants != null && this.Constants.Count > 0) CheckList.AddRange(this.Constants.Values);
            CheckList.TrimExcess();

            //Now lets search through everything for matches via default representation
            if (CheckList.Count < 1) return null;
            for (int i = 0; i < CheckList.Count; i++)
            {
                if (CheckList[i].ToString(ExpressionStringFormat.ParseFriendly, VF, CF) == MatchString) return CheckList[i];
            }

            //If we couldn't find anything
            return null;
        }


        /// <summary>
        /// Gets an operand (variable/constant) defined in this scope by its matching string representation (assumes the default string representations).
        /// Returns first match and null if no operand was found.
        /// </summary>
        /// <param name="MatchString">The string an operand's string must match to be selected</param>
        public Operand Get(string MatchString)
        {
            return this.Get(MatchString, ExpressionStringVariableFormat.Default, ExpressionStringConstantFormat.Default);
        }


        /// <summary>
        /// Gets an operand (variable/constant) defined in this scope by its matching string representation (assumes the default string representations).
        /// Returns first match and null if no operand was found.
        /// </summary>
        /// <param name="MatchString">The string an operand's string must match to be selected</param>
        public Operand this[string MatchString]
        {
            get
            {
                return this.Get(MatchString);
            }
        }
    }
}
