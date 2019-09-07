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
using CSCodeCompiler.Strategies.Parsers;

namespace CSCodeCompiler.Projects
{
    class Parse
    { 
        public static void Run(string[] args)
        {
            Macro macro = new Macro();
            List<IStrategy> strat = new List<IStrategy>();
            strat.Add(new CustomParse());
            macro.Execute(strat);
            macro.Commit();
        } 
    } 
}
