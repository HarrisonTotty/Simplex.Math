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
    /// 
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
            this.Expressions = new List<Expression>();
            this.Variables = new Dictionary<string, Variable>();
        }

        /// <summary>
        /// The list of all expressions created within this scope.
        /// </summary>
        public List<Expression> Expressions
        {
            get;
            private set;
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
    }
}
