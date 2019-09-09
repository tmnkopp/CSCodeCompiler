using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCodeCompiler.Procedures;
using CSCodeCompiler.IO;
using CSCodeCompiler.Macros;
using System.Configuration;

namespace CSCodeCompiler.Macros
{ 
    public class CacheEditMacro : BaseMacro 
    {  
        public override void Execute(IProcedure procedure)
        {
            string result = procedure.Execute(Cache.Read());
            Cache.Write(result);
            Cache.CacheEdit();
            Console.WriteLine("{0}",procedure.GetType()); 
            Console.ReadKey();
        } 
    }
    public class ParseMacro : BaseMacro
    {
        StringBuilder result = new StringBuilder();
        public override void Execute(IProcedure procedure)
        {
            FileReader r = new FileReader(AppSettings.CompileSource);
            result.AppendFormat("{0}\n\n", procedure.Execute(r.Read()));
            Cache.Write(result.ToString());
        }
    }
    public class Macro : BaseMacro 
    {
        public override void Execute(IProcedure procedure)
        {
            string result = procedure.Execute(Cache.Read());
            Cache.Write(result);  
        }
    }
}
