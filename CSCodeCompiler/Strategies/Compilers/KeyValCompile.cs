using CSCodeCompiler.Strategies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSCodeCompiler.Strategies
{
    public class KeyValCompile : IStrategy
    {
        private Dictionary<string, string> _dict;
        public KeyValCompile(Dictionary<string, string> Dict)
        {
            _dict = Dict;
        }
        public string Execute(string compileme)
        {
            foreach (var item in _dict)
                compileme = compileme.Replace(item.Key,item.Value);
            return compileme;        
        }
    }
}
