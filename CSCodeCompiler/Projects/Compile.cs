using CSCodeCompiler.Data;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Procedures;
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
            List<IProcedure> strat = new List<IProcedure>();
            strat.Add(new PathCompile());  
            strat.Add(new RepeaterCompile(1, 5));
            strat.Add(new IndexCompile(10, 0, "[index2]"));
            strat.Add(new IndexCompile(10, 0, "[index1]"));
            strat.Add(new KeyValCompile(Dictionaries.SysCodes()));
            macro.Execute(strat);
            macro.Commit();
        }

    }
}
