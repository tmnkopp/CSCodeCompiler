using CSCodeCompiler.Strategies;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Data;
using CSCodeCompiler.IO; 
using System;   
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;

namespace CSCodeCompiler
{
    class Program
    { 
        static void Main(string[] args)
        {

            Program.Reflection();

            List<IStrategy> strats = new List<IStrategy>();
            strats.Add(new RepeaterCompile(1, 10));
            strats.Add(new IndexCompile(10, 0, "[index1]"));
            strats.Add(new IndexCompile(1000, 1005, "[index2]"));
            strats.Add(new IndexCompile(10, 0, "[index3]"));
            strats.Add(new IndexCompile(1000, 1005, "[index4]"));
            foreach (var strategy in strats)
            {   
                Console.WriteLine("index num: ");
                string line = Console.ReadLine();
                strategy.Execute(line);
                int i = Console.CursorLeft;

            }

            //CSCodeCompiler.Projects.Compile.Run(new string[] { });
        }
        static void Reflection() {
            Type type = Type.GetType("CSCodeCompiler.Data.DBUtils");
            ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
            object obj = ctor.Invoke(new object[] { });

            MethodInfo mi = type.GetMethod("DBLookup");
            object val = mi.Invoke(obj, new object[] { " select CODE + '\n' From fsma_QuestionTypes " });
 
            Console.WriteLine("{0}", val);
        }
    } 
}
//git rm --cached CSCodeCompiler/App.config



