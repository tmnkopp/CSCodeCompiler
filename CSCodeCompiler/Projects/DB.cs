using CSCodeCompiler.Strategies;
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
namespace CSCodeCompiler.Projects
{
    class DB
    { 
        public static void Run(string[] args)
        {
            DBUtils db = new DBUtils();
            string data = db.DBLookup("select QT.CODE + '\n' from fsma_QuestionTypes QT ");
            TextConsole tw = new TextConsole();
            tw.Write(data);
        } 
    } 
}
