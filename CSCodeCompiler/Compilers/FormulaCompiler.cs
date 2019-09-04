using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSCodeCompiler.CompilerFormulas;
using CSCodeCompiler.IO; 
namespace CSCodeCompiler.Compilers
{
    public class FormulaCompiler : ICompiler
    {
        private StringBuilder _content = new StringBuilder(); 
        public void CompileSource(IReader reader)
        {
            _content.Append(reader.Read());
        } 
        public void Execute(ICompileFormula compileFormula)
        {
            string result = compileFormula.Compile(_content.ToString());
            _content.Clear();
            _content.Append(result);
        }
        public void CompileDest(IWriter writer)
        {
            writer.Write(_content.ToString());
        }
    }
}
