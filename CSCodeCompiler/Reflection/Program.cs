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
            
        //ARgum

            Type type = Type.GetType("CSCodeCompiler.Strategies.IndexCompile");
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(int), typeof(int), typeof(string) });
            object obj = ctor.Invoke(new object[] { 1, 10, "[index]"});

             Macro macro = new Macro();
            List<IStrategy> strat = new List<IStrategy>();
            strat.Add((IStrategy)obj);
            //strat.Add(new IndexCompile(1, 0, "[SORTORDER]")); 
            //strat.Add(new IndexCompile(1000, 0, "[indexpk]"));
            macro.Execute(strat);
            macro.Commit();


            //MethodInfo methodInfo = type.GetMethod("DBLookup");
            //object val = methodInfo.Invoke(obj, new object[] { " SELECT CODE + '\n' From fsma_QuestionTypes " });

            //Console.WriteLine("{0}", val);
        }
    }
}
