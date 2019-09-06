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

            CSCodeCompiler.Projects.Reflection.Run(new string[] { });

            return;
            PauseMacro macro = new PauseMacro();
            List<IStrategy> strat = new List<IStrategy>();
            strat.Add(new RepeaterCompile(1, 10));
            //strat.Add(new IndexCompile(1, 0, "[SORTORDER]")); 
            //strat.Add(new IndexCompile(1000, 0, "[indexpk]"));
            macro.Execute(strat);
            macro.Commit();

            //
            //string line = Console.ReadLine();
        }
    } 
}
//git rm --cached CSCodeCompiler/App.config



