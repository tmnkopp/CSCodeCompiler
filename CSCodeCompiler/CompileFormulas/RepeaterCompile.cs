using CSCodeCompiler.CompilerFormulas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSCodeCompiler.CompileFormulas
{
    public class RepeaterCompile : ICompileFormula
    {
        private int _from = 0;
        private int _to = 1;
        public RepeaterCompile(int From, int To)
        {
            _from = From;
            _to = To;
        }
        public string Compile(string compileme)
        {
            if (_from >= _to)
                throw new InvalidOperationException(); 
            StringBuilder result = new StringBuilder(); 
            for (int index = _from; index <= _to; index++)
            {
                result.AppendFormat("{0}\n", compileme.Replace("[index]", index.ToString())); 
            } 
            return result.ToString();
        } 
    }
}
