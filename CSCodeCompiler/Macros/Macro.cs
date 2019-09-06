using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCodeCompiler.Strategies;
using CSCodeCompiler.IO;
using CSCodeCompiler.Macros;
using System.Configuration;

namespace CSCodeCompiler.Macros
{ 
    public class Macro : IMacro
    { 
        public Macro()
        { 
            Prepare();
        } 
        public void Execute(IStrategy strategy)
        {
            string result = strategy.Execute(Cache.Read());
            Cache.Write(result);
            Cache.CacheEdit();
            Console.WriteLine("{0}",strategy.GetType()); 
            Console.ReadLine();
        }
        public void Execute(List<IStrategy> strategyCollection)
        {
            int index = 0;
            foreach (var strategy in strategyCollection)
            {
                Execute(strategy);
                FileWriter f = new FileWriter($"c:\\temp\\_{index++.ToString()}${strategy.ToString()}.tk");
                f.Write(Cache.Read());
            }
        }
        public void Prepare()
        { 
            IReader reader = new FileReader();
            Cache.Write(reader.Read());
        }
        public void Commit()
        {
            IWriter writer = new FileWriter();
            writer.Write(Cache.Read());
        }
    }
}
