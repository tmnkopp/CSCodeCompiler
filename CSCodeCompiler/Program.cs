using CSCodeCompiler.CompileFormulas;
using CSCodeCompiler.CompilerFormulas;
using CSCodeCompiler.Compilers;
using CSCodeCompiler.Data;
using CSCodeCompiler.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace CSCodeCompiler
{
    class Program
    { 
        static void Main(string[] args)
        {

            //DBUtils db = new DBUtils();
            //string data = db.DBLookup("select QT.CODE + '\n' from fsma_QuestionTypes QT ");
            //string data = db.KeyValueLookup("CODE", "description", "fsma_QuestionTypes");
            //string regex = @"\\d\\w\\.";
              Dictionary<string, string> dict 
            = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
             
            FormulaCompiler compiler = new FormulaCompiler();
            compiler.CompileSource(new FileReader(@"c:\temp\input.txt"));
            compiler.Execute(new HashCompile(dict));
            //compiler.Execute(new IndexCompile(67890,0));
            compiler.CompileDest(new TextConsole());
        } 
    } 
}
