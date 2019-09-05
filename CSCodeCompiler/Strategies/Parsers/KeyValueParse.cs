using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Strategies.Parsers
{
    public class KeyValueParse : IStrategy
    {
        private Dictionary<string, string> _dict;
        public KeyValueParse(Dictionary<string, string> Dict)
        {
            _dict = Dict;
        }
        public string Execute(string content)
        {
            StringBuilder result = new StringBuilder();
            string[] statements = content.Split('\n');
            foreach (var statement in statements)  {
                //find in statement 
                //found
                //add to format
                // if no result
                //find 
                //found
                //add to format
            }
            return result.ToString();
        }
    }
}
