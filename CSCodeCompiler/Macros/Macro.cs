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
        private StringBuilder _result = new StringBuilder();
        public Macro()
        {
            string _filename = ConfigurationManager.AppSettings["DefaultSource"].ToString();
            CompileSource(new FileReader(_filename));
        }
        public Macro(string PathToTemplate)
        {
            CompileSource( new FileReader(PathToTemplate));
        }
        public void CompileSource(IReader reader)
        {
            _result.Append(reader.Read());
        }
        public void Execute(IStrategy strategy)
        {
            string result = "";       
            result = strategy.Execute(_result.ToString());
            _result.Clear();
            _result.Append(result); 
        }
        public void Execute(List<IStrategy> strategyCollection)
        { 
            foreach (var strategy in strategyCollection)
            {
                Execute(strategy); 
                CompileDest(new TextConsole());
            } 
        }
        public void ExecuteAndView(List<IStrategy> strategyCollection)
        {
            this.Execute(strategyCollection); 
            
        }
        public void CompileDest(IWriter writer)
        {
            writer.Write(_result.ToString());
        }
    }
}
