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
        private Dictionary<string, string> _dict;
        public HashCompile(Dictionary<string, string> Dict)
        {
            _dict = Dict;
        }
        public string Compile(string compileme)
        {
            foreach (var item in _dict)
                compileme = compileme.Replace(item.Key,item.Value);
            return compileme;        
        }
    }
}
