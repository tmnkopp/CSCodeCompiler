using CSCodeCompiler.Strategies;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Data;
using CSCodeCompiler.IO; 
using System;   
using System.Threading.Tasks; 
namespace CSCodeCompiler
{
    class Program
    { 
        static void Main(string[] args)
        {
            CSCodeCompiler.Projects.Parser.Run(new string[] { });
        } 
    } 
}
