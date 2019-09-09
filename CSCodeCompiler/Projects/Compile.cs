using CSCodeCompiler.Data;
using CSCodeCompiler.IO;
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
            FileReader r = new FileReader(); 
            BlockExtractor extractor = new BlockExtractor("PK_Question=", "<!-- 13a -->", "<!-- GLOSSARY -->");
            string extraction = extractor.Execute(r.Read());
            FileWriter w = new FileWriter();
            w.Write(extraction);

            //   ParseMacro macro = new ParseMacro();
            //   List<IProcedure> strat = new List<IProcedure>();
            //   strat.Add(new BlockExtractor("widgetZone3", "@await", "})"));
            //   strat.Add(new BlockExtractor("widgetZone2", "@await", "})")); 
            //   //strat.Add(new SqlKeyValCompile("[dir]data.sql")); 
            //   macro.Execute(strat);
            //   macro.Commit();
        }

    }
}
