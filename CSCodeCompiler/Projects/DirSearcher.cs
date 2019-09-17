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
using System.Text;

namespace CSCodeCompiler
{
    public class DirSearcher
    {
        public static void Run(string[] args)
        {
            //HVAIn
            string dbroot = @"D:\dev\CyberScope\CyberScopeBranch\CSwebdev\database\";
            string coderoot = @"D:\dev\CyberScope\CyberScopeBranch\CSwebdev\code\CyberScope";
            string root = coderoot;
            string find = "Agency Contacts";
            StringBuilder sb = new StringBuilder();
            FileReader r = new FileReader();
            DirectoryInfo DI = new DirectoryInfo($"{root}");
            foreach (var file in DI.GetFiles("cq_*.sql", SearchOption.AllDirectories)) {
                r = new FileReader(file.FullName);
                string content = r.Read(); 
                if (content.Contains(find))
                { 
                    IProcedure proc = new ContextExtractor(find, 155, 155);
                    string result = proc.Execute(content);
                    sb.AppendFormat("\n{2}\n{0}\n{1}\n", file.FullName, result, new String('!', 125)); 
                }  
            }
            Cache.Write(sb.ToString());
            Cache.CacheEdit();
        }  
    } 
}

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


