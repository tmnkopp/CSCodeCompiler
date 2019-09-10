using CSCodeCompiler.Data;
using CSCodeCompiler.IO;
using CSCodeCompiler.Procedures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSCodeCompiler.Procedures
{
    public class CodeMustNotHaveVerifier : IProcedure
    { 
        public Dictionary<string, string> Dict { get; set; }
        StringBuilder result = new StringBuilder();    
        public string Execute(string verifythis)
        {
            foreach (var item in Dict) {
                if (verifythis.Contains(item.ToString()))
                {
                    result.AppendFormat("CONTAINS: {0}\n", item.ToString());
                }
            } 
            return result.ToString();        
        }
        public override string ToString()
        {
            return $"{base.ToString()} -{Dict.ToString()}";
        }
    } 
}
