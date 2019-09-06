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
            PauseMacro macro = new PauseMacro();
            List<IStrategy> strat = new List<IStrategy>();
            strat.Add(new RepeaterCompile(500, 505));
            strat.Add(new IndexCompile(1000, 0, "[index2]"));
            macro.Execute(strat);
            macro.Commit();

            //CSCodeCompiler.Projects.Compile.Run(new string[] { });
            //string line = Console.ReadLine();
        }
    } 
}
//git rm --cached CSCodeCompiler/App.config



