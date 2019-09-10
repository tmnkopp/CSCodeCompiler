using CSCodeCompiler.Procedures;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Data;
using CSCodeCompiler.IO; 
using System;   
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace CSCodeCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            CSCodeCompiler.Bootstrapper.Run();
            //CSCodeCompiler.Projects.Compile.Run(new string[] { });
        }  
    } 
}
 



