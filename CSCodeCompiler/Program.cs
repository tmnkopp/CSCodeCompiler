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
            CSCodeCompiler.Projects.Sandbox.Run(new string[] { });
        } 
    } 
}
//git rm --cached CSCodeCompiler/App.config
