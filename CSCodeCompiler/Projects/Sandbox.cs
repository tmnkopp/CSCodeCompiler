﻿using CSCodeCompiler.CompileFormulas;
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
namespace CSCodeCompiler.Projects
{
    class Sandbox
    { 
        public static void Run(string[] args)
        {
            DBUtils db = new DBUtils();
            //string data = db.DBLookup("SELECT CODE + '\n' FROM fsma_QuestionTypes");
            string data = db.KeyValueLookup("CODE", "description", "fsma_QuestionTypes");
            //string regex = @"\\d\\w\\.";
            //Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            TextConsole fw = new TextConsole();
            fw.Write(data);
            //FormulaCompiler compiler = new FormulaCompiler(@"c:\temp\input.txt"); 
            //compiler.ExecuteAndView(new RepeaterCompile(500,505));  
        } 
    } 
}
