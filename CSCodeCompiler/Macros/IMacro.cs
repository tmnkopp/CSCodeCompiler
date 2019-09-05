using CSCodeCompiler.Strategies;
using CSCodeCompiler.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Macros
{
    public interface IMacro
    { 
        void CompileSource(IReader reader);
        void Execute(List<IStrategy> strategyCollection); 
        void CompileDest(IWriter writer);
    } 
}
