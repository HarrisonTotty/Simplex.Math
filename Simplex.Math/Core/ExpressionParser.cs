using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using Simplex.Math.Logic;
using Simplex.Math.Operands;
using Simplex.Math.Operations;
using System.Text.RegularExpressions;

namespace Simplex.Math.Core
{
    /// <summary>
    /// Contains static methods for parsing expressions via reflection.
    /// </summary>
    public static class ExpressionParser
    {
        /// <summary>
        /// A link to the C# compiler used for dynamic compilation of expressions.
        /// </summary>
        public static readonly CSharpCodeProvider CSProvider = new CSharpCodeProvider();

        /// <summary>
        /// A link to the C# compiler parameters
        /// </summary>
        public static readonly CompilerParameters Parameters = new CompilerParameters() { GenerateInMemory = true, GenerateExecutable = false, IncludeDebugInformation = false };

        /// <summary>
        /// Parses an expression from source code and returns a new instantiated expression object (assuming the global scope).
        /// </summary>
        /// <param name="ExpressionString">The string of the expression to parse</param>
        /// <remarks>
        /// Firstly, we try to see if any part of the string matches any of the objects in our global scope.
        /// If not, then we create new objects.
        /// </remarks>
        public static Expression Parse(string ExpressionString)
        {
            //Add all of the neccessary assemblies
            Parameters.ReferencedAssemblies.Clear();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Parameters.ReferencedAssemblies.Add(executingAssembly.Location);
            foreach (AssemblyName assemblyName in executingAssembly.GetReferencedAssemblies())
            {
                Parameters.ReferencedAssemblies.Add(Assembly.Load(assemblyName).Location);
            }

            //Go through the expression string and replace common math definitions:
            //Example: "Sin(" -> "Simplex.Math.Core.Math.Sin("
            

            string CodeString = "";


            //Compile the code into a compiler results object
            CompilerResults Results = CSProvider.CompileAssemblyFromSource(Parameters, CodeString);

            //If our code has errors:
            if (Results.Errors.HasErrors)
            {
                throw new Exceptions.ExpressionParsingException("Unable to parse expression");
            }

            //Obtain the assembly from the compiler results
            Assembly ScriptAssembly = Results.CompiledAssembly;

            //Obtain the object
            Type ScriptType = ScriptAssembly.GetType("Simplex.Math.Core.BUILDEXPRESSION");

            //Create an instance of the script type and return it
            return ((ExpressionParser_Template)Activator.CreateInstance(ScriptType)).BuildExpression();
        }

        /// <summary>
        /// Compiles a script of any type from source code and returns the compiler results
        /// </summary>
        /// <param name="Code">The string of code to compile</param>
        public static CompilerResults TestCompile_FromSource(string Code)
        {
            //Add all of the neccessary assemblies
            Parameters.ReferencedAssemblies.Clear();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Parameters.ReferencedAssemblies.Add(executingAssembly.Location);
            foreach (AssemblyName assemblyName in executingAssembly.GetReferencedAssemblies())
            {
                Parameters.ReferencedAssemblies.Add(Assembly.Load(assemblyName).Location);
            }

            //Compile the code into a compiler results object
            return CSProvider.CompileAssemblyFromSource(Parameters, Code);
        }

        /// <summary>
        /// Extracts a list of words (or alphanumeric symbols) from an expression string
        /// </summary>
        /// <remarks>
        /// We will use regular expressions to accomplish this.
        /// HOWEVER: We also need to make sure that a word:
        /// Is not a pure number such as "3423423"
        /// Does not have "." immediately in front of it
        /// Does not have ".", "(", or  immediately behind it
        /// </remarks>
        /// <param name="Input">The string to extract from</param>
        public static List<string> ExtractWordsFromString(string Input)
        {
            //The regex we use is:   \w(?<!\d)[\w]*
            //You can test this regex at http://refiddle.com/
            string Pattern = @"\w(?<!\d)[\w]*";
            MatchCollection matchlist = Regex.Matches(Input, Pattern);
            return matchlist.Cast<Match>().Select(match => match.Value).ToList();
        }
    }
}
