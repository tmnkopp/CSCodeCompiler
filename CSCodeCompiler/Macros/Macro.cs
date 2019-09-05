using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCodeCompiler.Strategies;
using CSCodeCompiler.IO;
using CSCodeCompiler.Macros;

namespace CSCodeCompiler.Macros
{ 
    public class Macro : IMacro
    {
        private StringBuilder _result = new StringBuilder();
        public Macro()
        { 
        }
        public Macro(string PathToTemplate)
        {
            CompileSource( new FileReader(PathToTemplate));
        }
        public void CompileSource(IReader reader)
        {
            _result.Append(reader.Read());
        } 
        public void Execute(List<IStrategy> strategyCollection)
        {
            string result = "";
            foreach (var strategy in strategyCollection)
            {
                result = strategy.Execute(_result.ToString());
                _result.Clear();
                _result.Append(result);
            } 
        }
        public void ExecuteAndView(List<IStrategy> strategyCollection)
        {
            this.Execute(strategyCollection); 
            CompileDest(new TextConsole());
        }
        public void CompileDest(IWriter writer)
        {
            writer.Write(_result.ToString());
        }
    }
}
