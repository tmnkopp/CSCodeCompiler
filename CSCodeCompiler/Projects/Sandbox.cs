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
namespace CSCodeCompiler.Projects
{
    class Sandbox
    { 
        public static void Run(string[] args)
        {
            PauseMacro macro = new PauseMacro( );
            List<IStrategy> strat = new List<IStrategy>();
            strat.Add(new RepeaterCompile(500, 505));
            strat.Add(new IndexCompile(1000, 0, "[index2]"));
            macro.Execute(strat);
            macro.Commit();
        } 
    } 
}
