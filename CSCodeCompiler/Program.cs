using CSCodeCompiler.Strategies;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Data;
using CSCodeCompiler.IO; 
using System;   
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;

namespace CSCodeCompiler
{
    class Program
    { 
        static void Main(string[] args)
        {

             CSCodeCompiler.Projects.Compile.Run(new string[] { });
        } 
    } 
}
//git rm --cached CSCodeCompiler/App.config



