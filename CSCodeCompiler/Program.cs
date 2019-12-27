using CSCodeCompiler.Procedures;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Data;
using CSCodeCompiler.IO; 
using System;   
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using CSCodeCompiler.Reflection;
using HtmlAgilityPack;
using System.Data.OleDb;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace CSCodeCompiler
{
     class Program
     {
        static void Main(string[] args)
        {
            //CSCodeCompiler.FFCIOCompiler.Run( new string[] { });
            //  CSCodeCompiler.Bootstrapper.Run();
            CSCodeCompiler.DirSearcher.Run( new string[] { }); 
            //  CSCodeCompiler.DataTransUtil.Run();  
            //  PrepareImport();

            return; 
        }

        private static void PrepareImport() {
            SqlDataReader oReader;
            var con = ConfigurationManager.ConnectionStrings["Cyberscope123"].ToString();
            StringBuilder sb = new StringBuilder();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                SqlCommand oCmd = new SqlCommand("SELECT * FROM RMAIncidents_IMPORT", myConnection);
                myConnection.Open();
                using (oReader = oCmd.ExecuteReader())
                {
                    var columns = Enumerable.Range(0, oReader.FieldCount).Select(oReader.GetName).ToList();
                    while (oReader.Read())
                    {
                        foreach (var col in columns)
                        {
                            sb.AppendFormat("{0}", col);
                            Console.WriteLine(col + '\n');
                        }
                       
                    }
                    myConnection.Close();
                }
            }
        }

   

        private static void PreparePKEYSql()
        {
            string content, template; 
            content = new FileReader().Read();
            template = new PathCompile().Execute(content);

            content = new RepeaterCompile(1, 25).Execute(template);
            content = new IndexCompile(16099, 0, "[index1]").Execute(content);
            content = new IndexCompile(17500, 0, "[index2]").Execute(content); 
            Cache.Append(content);
            Cache.CacheEdit();

            //string template_insert = new FileReader($"C:\\temp\\templates\\SQLKVTEMPLATE.txt").Read().ToString();
            //template_insert = template_insert.Replace("[INSERTS]", Cache.Read());
            //FileWriter fw = new FileWriter($"C:\\temp\\SQLKVTEMPLATE.sql");
            //fw.Write(template_insert);
        }
     } 
}


//Macro macro = new Macro();
//List<IProcedure> proc = new List<IProcedure>();
//proc.Add();
//macro.Execute(proc);
//macro.Commit();

//ProcedureInvoker PI = new ProcedureInvoker();
//List<IProcedure> procs = new List<IProcedure>();
//List<string> commands = new List<string>();
//
//procs.Clear();
//commands.Clear();
//ParseMacro macro = new ParseMacro(); 
//commands.Add(".BlockExtractor -'ISSUE:' -'<description>' -'</description>'");
////commands.Add(".BlockExtractor -'2' -'/#' -'#/'");
//foreach (string command in commands)
//{
//   object procedure = PI.Invoke(command);
//    procs.Add((IProcedure)procedure);
//}  
//macro.Execute(procs); 
//macro.Commit();
/*
 
            ParseMacro parse = new ParseMacro();
            List<IProcedure> strat = new List<IProcedure>(); 
            strat.Add(new JiraDescriptionParse() {});
            parse.Execute(strat);
            parse.Commit();



            // ProcedureInvoker PI = new ProcedureInvoker(); 
            ParseMacro parse = new ParseMacro();
            List < IProcedure > strat = new List<IProcedure>(); 
            strat.Add(new BlockExtractor("1", "/~", "~/") { ID = "1" });
            strat.Add(new BlockExtractor("2", "/~", "~/") { ID = "2" });
            strat.Add(new BlockExtractor("3", "/~", "~/") { ID = "3" });
            strat.Add(new BlockExtractor("4", "/~", "~/") { ID = "4" });
            parse.Execute(strat);
            parse.Commit();


            //  CacheEditMacro cachemac = new CacheEditMacro();
            //  strat = new List<IProcedure>();
            //  strat.Add(new PathCompile());
            //  cachemac.Execute(strat);
            //  cachemac.Commit();

            //   ParseMacro macro = new ParseMacro();
            //   List<IProcedure> strat = new List<IProcedure>();
            //   strat.Add(new BlockExtractor("widgetZone3", "@await", "})"));
            //   strat.Add(new BlockExtractor("widgetZone2", "@await", "})")); 
            //   //strat.Add(new SqlKeyValCompile("[dir]data.sql"));     
     
*/


