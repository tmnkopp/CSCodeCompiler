using CSCodeCompiler.Macros;
using CSCodeCompiler.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler
{
    public class RMAFormCreator
    {
        public static void Run()
        {
            CacheEditMacro parse = new CacheEditMacro();
            List<IProcedure> strat = new List<IProcedure>();
            strat.Add(new RepeaterCompile(1, 4));
            strat.Add(new IndexCompile(1, 0, "[form-number]")); 
            parse.Execute(strat);
            parse.Commit();
        }
    }
}
