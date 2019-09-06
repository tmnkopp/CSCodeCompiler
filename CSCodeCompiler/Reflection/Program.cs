using CSCodeCompiler.Strategies;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Data;
using CSCodeCompiler.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CSCodeCompiler.Projects
{
    class Reflection
    {
        public static void Run(string[] args)
        {
            Type type = Type.GetType("CSCodeCompiler.Data.DBUtils");
            ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
            object obj = ctor.Invoke(new object[] { });

            MethodInfo methodInfo = type.GetMethod("DBLookup");
            object val = methodInfo.Invoke(obj, new object[] { " SELECT CODE + '\n' From fsma_QuestionTypes " });

            Console.WriteLine("{0}", val);
        }
    }
}
