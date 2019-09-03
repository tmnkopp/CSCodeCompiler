using CSCodeCompiler.CompilerFormulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Compilers
{
    public interface ICompiler
    { 
        //compile what 
        void Execute(ICompileFormula compileFormula);//compile how
        //compile to    
    }

}
