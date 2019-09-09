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
            strat.Add(new BlockExtractor("widgetZone2", "@await", "})")); 
            //strat.Add(new SqlKeyValCompile("[dir]data.sql")); 
            macro.Execute(strat);
            macro.Commit();
        }

    }
}
