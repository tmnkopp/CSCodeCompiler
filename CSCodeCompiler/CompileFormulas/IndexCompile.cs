using CSCodeCompiler.CompilerFormulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.CompileFormulas
{
    public class IndexCompile : ICompileFormula
    {
        private int _seed = 0;
        private int _reset = 1;
        public IndexCompile(int Seed, int Reset)
        {
            _seed = Seed-1;
            _reset = Reset;
        }
        public string Compile(string compileme)
        {
            StringBuilder result = new StringBuilder();
            string[] lines = compileme.Split('\n');
            int index = _seed; 
            foreach (var line in lines) {
                if (line.Contains("[index]"))
                    index++; 
                result.AppendFormat("{0}\n",line.Replace("[index]", ReSetter(index).ToString()));
            }
            return result.ToString();
        }
        private int ReSetter(int index) {
            if (_reset <= 1)
                return index;
            return index % _reset;
        }
    }
}
