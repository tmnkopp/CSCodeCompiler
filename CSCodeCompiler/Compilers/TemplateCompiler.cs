using CSCodeCompiler.CompilerFormulas;
using CSCodeCompiler.Compilers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Compilers
{
    public class DirCompiler: ICompiler
    {
        private string _sourceDir = @"c:\temp\in";
        private string _destDir = @"c:\temp\in";

        public DirCompiler(string SourceDir, string DestDir)
        {
            _sourceDir = SourceDir;
            _destDir = DestDir;
        }
        public void Execute(ICompileFormula compileFormula)
        {
            DirectoryInfo dir = new DirectoryInfo(_sourceDir);
            FileInfo[] compilerTemplates = dir.GetFiles("*.txt");  
            foreach (var template in compilerTemplates)
            {
                StringBuilder sb = new StringBuilder();
                using (TextReader tr = File.OpenText(template.FullName))
                {
                    string line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        sb.Append($"{compileFormula.Compile(line)}\r\n");
                    }
                }
                File.WriteAllText($"{_destDir}\\_{template.Name}", sb.ToString());
            }
        }
    }
}
