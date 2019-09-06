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
    public class PauseMacro : IMacro
    {
        private StringBuilder _result = new StringBuilder();
        public PauseMacro()
        {
            Prepare();
        }
        public void Prepare()
        {
            string _filename = ConfigurationManager.AppSettings["DefaultSource"].ToString();
            IReader reader = new FileReader(_filename);
            _result.Append(reader.Read());
        }
        public void Prepare(IReader reader)
        { 
            _result.Append(reader.Read());
        } 
        public void Execute(IStrategy strategy)
        {
            string result = strategy.Execute(_result.ToString());
            _result.Clear();
            _result.Append(result);
            Cache.Write(_result.ToString());
            Cache.CacheEdit();
            Console.Write("tk:>" + strategy.GetType().ToString());
            Console.ReadLine();
            _result.Clear();
            _result.Append(Cache.Read()); 
        }
        public void Execute(List<IStrategy> strategyCollection)
        { 
            foreach (var strategy in strategyCollection)
            {
                Execute(strategy);   
            } 
        } 
        public void Commit()
        {
            IWriter writer = new FileWriter();
            writer.Write(_result.ToString());
        }
    }
}
