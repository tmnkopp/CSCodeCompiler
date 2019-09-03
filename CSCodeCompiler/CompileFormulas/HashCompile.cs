using CSCodeCompiler.CompilerFormulas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSCodeCompiler.CompileFormulas
{
    public class HashCompile : ICompileFormula
    {
        private string _json = "";
        public HashCompile(string json)
        {
            _json = json;
        }
        public string Compile(string compileme)
        {
            if (_json == "")
                return "";
            Dictionary<string, string> dict =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(_json);
            foreach (var item in dict)
                compileme = compileme.Replace($"{item.Key}",item.Value);
            return compileme;        
        }
    }
}
