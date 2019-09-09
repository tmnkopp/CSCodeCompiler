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
    public class CacheEditMacro : BaseMacro, IMacro
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
    public class  Macro : BaseMacro, IMacro
    {
        public override void Execute(IProcedure procedure)
        {
            string result = procedure.Execute(Cache.Read());
            Cache.Write(result);  
        }
    }
}
