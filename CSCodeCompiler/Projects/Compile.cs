using CSCodeCompiler.Data;
using CSCodeCompiler.IO;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Procedures;
using CSCodeCompiler.Reflection;
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
            // ProcedureInvoker PI = new ProcedureInvoker(); 
            ParseMacro parse = new ParseMacro();
            List < IProcedure > strat = new List<IProcedure>(); 
            strat.Add(new BlockExtractor("1", "/~", "~/") { ID = "1" });
            strat.Add(new BlockExtractor("2", "/~", "~/") { ID = "2" });
            strat.Add(new BlockExtractor("3", "/~", "~/") { ID = "3" });
            strat.Add(new BlockExtractor("4", "/~", "~/") { ID = "4" });
            parse.Execute(strat);
            parse.Commit();


            //  CacheEditMacro cachemac = new CacheEditMacro();
            //  strat = new List<IProcedure>();
            //  strat.Add(new PathCompile());
            //  cachemac.Execute(strat);
            //  cachemac.Commit();

            //   ParseMacro macro = new ParseMacro();
            //   List<IProcedure> strat = new List<IProcedure>();
            //   strat.Add(new BlockExtractor("widgetZone3", "@await", "})"));
            //   strat.Add(new BlockExtractor("widgetZone2", "@await", "})")); 
            //   //strat.Add(new SqlKeyValCompile("[dir]data.sql"));
        }

    }
}
