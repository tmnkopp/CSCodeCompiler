using CSCodeCompiler.CompileFormulas;
using CSCodeCompiler.CompilerFormulas;
using CSCodeCompiler.Compilers;
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
            string _json = "{\"key1\":\"val1\",\"key2\":\"val2\"}";
            HashCompile HashComp = new HashCompile(_json);
            string result = HashComp.Compile("key1   key2");

            NotepadViewer viewer = new NotepadViewer();
            viewer.View(result);

        } 
    } 
}
