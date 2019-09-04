using CSCodeCompiler.CompilerFormulas;
using CSCodeCompiler.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Compilers
{
    public interface ICompiler
    { 
        void CompileSource(IReader reader);
        void Execute(ICompileFormula compileFormula); 
        void CompileDest(IWriter writer);
    } 
}
