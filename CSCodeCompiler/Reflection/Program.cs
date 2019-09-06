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

            Type[] ctorSignature = Reflection.GetCtorArgs(new object[] {1,2,"hello"});
            return;
            //Macro macro = new Macro();
            //List<IStrategy> strat = new List<IStrategy>();
            //strat.Add((IStrategy)obj);
            //strat.Add(new IndexCompile(1, 0, "[SORTORDER]")); 
            //strat.Add(new IndexCompile(1000, 0, "[indexpk]"));
            //macro.Execute(strat);
            //macro.Commit();


            //MethodInfo methodInfo = type.GetMethod("DBLookup");
            //object val = methodInfo.Invoke(obj, new object[] { " SELECT CODE + '\n' From fsma_QuestionTypes " });

            //Console.WriteLine("{0}", val);
        }
        public static Type[] GetCtorArgs( object[] args) { 
            Type[] ctorargs = new Type[5];
            for (int i = 0; i < args.Length; i++)
            {
                ctorargs[i] = args[i].GetType();
                Console.WriteLine("{0}", ctorargs[i]);
            }   
            return ctorargs;
        }
        public void InstantiateType() {
            Type type = Type.GetType("CSCodeCompiler.Strategies.IndexCompile");
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(int), typeof(int), typeof(string) });
            object obj = ctor.Invoke(new object[] { 1, 10, "[index]" });
            Console.WriteLine("{0}$1-10-[index]", obj.GetHashCode().ToString());
            Console.Read();
        }
    }
}
