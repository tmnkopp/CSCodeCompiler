using CSCodeCompiler.Procedures;
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
using System.Configuration;
using System.Data.SqlClient; 
namespace CSCodeCompiler.Projects
{
    class DB
    { 
        public static void Run(string[] args)
        {
            KeyValDBReader dbreader = new KeyValDBReader("SELECT DISTINCT TOP 3  CODE, Description  FROM fsma_QuestionTypes");
            dbreader.ExecuteRead();
            Dictionary<string, string> dict = dbreader.Data;
            dict.Add("~~","~~");

        } 
    } 
}
