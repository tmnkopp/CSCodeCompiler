using CSCodeCompiler.Macros;
using CSCodeCompiler.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Projects
{
    public class Compile
    {
        public static void Run(string[] args)
        {
            Macro macro = new Macro();
            List<IStrategy> strat = new List<IStrategy>();
            strat.Add(new RepeaterCompile(1, 10)); 
            strat.Add(new IndexCompile (10, 0, "[index1]"));
            strat.Add(new IndexCompile (1000,1005, "[index2]"));  
            macro.Execute(strat);
        }

    }
}
