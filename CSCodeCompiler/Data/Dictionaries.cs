using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Data
{
    public static class Dictionaries
    {
        public static Dictionary<string, string> SysCodes(){
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("[date]", System.DateTime.Now.ToShortDateString());
            result.Add("[guid]", Guid.NewGuid().ToString());
            return result;
        }
    }
}
