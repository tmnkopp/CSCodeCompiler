using CSCodeCompiler.CompilerFormulas;
using CSCodeCompiler.Compilers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Compilers
{
    public class JSONCompiler: ICompiler
    {
        public void Execute(ICompileFormula compileFormula)
        {
            string _dir = @"c:\temp\in";
            string path = $"{_dir}\\config.json";
            string _json = "";
            using (TextReader tr = File.OpenText(path)) 
                _json = tr.ReadToEnd();
    
            Dictionary<string, object> dictx = JsonConvert.DeserializeObject<Dictionary<string, object>>(_json);
            foreach (var item_x in dictx)
            {
                Dictionary<string, string> dict_y = JsonConvert.DeserializeObject<Dictionary<string, string>>(item_x.Value.ToString());
                foreach (var item_y in dict_y)
                {
                    Console.WriteLine($"{item_y.Key} -- {item_y.Value}");
                }
            }
            Console.ReadLine();
        }
    }

}
