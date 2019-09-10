﻿using CSCodeCompiler.Procedures;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Data;
using CSCodeCompiler.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using CSCodeCompiler.Reflection;
using CSCodeCompiler.Extentions;
namespace CSCodeCompiler.Projects
{
    class Reflection
    {
        public static void Run(string[] args)
        {
         
            ProcedureInvoker PI = new ProcedureInvoker();  
            ParseMacro macro = new ParseMacro();
            List<IProcedure> strat = new List<IProcedure>();
            strat.Add(new BlockExtractor("1","/~","~/"));
            //List<string> Commands = new List<string>();
            //Commands.Add(".BlockExtractor -'1' -'/~' -'~/'");
            //
            //foreach (string command in Commands)
            //{
            //    object procedure = PI.Invoke(command);
            //    strat.Add((IProcedure)procedure);
            //}  
            macro.Execute(strat);
            macro.Commit();


        }  
    }
}
