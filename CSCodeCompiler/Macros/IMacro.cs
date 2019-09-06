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
        void Prepare();
        void Execute(List<IStrategy> strategyCollection); 
        void Commit();
    } 
}
