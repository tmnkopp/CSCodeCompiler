using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.CompilerFormulas
{
    public class SimpleCompile: ICompileFormula
    { 
        public string Compile(string compileme)
        { 
            return compileme.Replace("[compileme]","compiled"); 
        }
    }
}
