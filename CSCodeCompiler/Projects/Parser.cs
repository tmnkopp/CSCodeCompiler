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
    class Parser
    { 
        public static void Run(string[] args)
        {
            Macro macro = new Macro(@"c:\temp\input.txt");
            List<IStrategy> strat = new List<IStrategy>();
            strat.Add(new CustomParse());
            macro.ExecuteAndView(strat);
        } 
    } 
}
