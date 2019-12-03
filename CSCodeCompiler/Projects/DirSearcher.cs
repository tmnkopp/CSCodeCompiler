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
            StringBuilder sb = new StringBuilder();
            string root = @"D:\dev\CyberScope\CyberScopeBranch\CSwebdev\database\sprocs\";
            // string root = @"D:\dev\CyberScope\CyberScopeBranch\CSwebdev\";
            // string root = @"D:\dev\CyberBalance\trunk\projects"; 
            string find = "RMAMetricsDisplay";
            Cache.Write(""); 
            CodeLookup(root, find, "*.*");
            Cache.CacheEdit();
   
        }
        private static void CodeLookup(string root, string find, string pattern) {

            FileReader r = new FileReader();
            DirectoryInfo DI = new DirectoryInfo($"{root}");
            StringBuilder sb = new StringBuilder();
            StringBuilder fileNames = new StringBuilder();
            sb.Append(Cache.Read());
            int cnt = 0; 
            foreach (var file in DI.GetFiles(pattern, SearchOption.AllDirectories))
            {
                bool getContent = true;
                string[] exclude = { "v15", "\\bin", "\\obj" }; 
                foreach (string item  in exclude) 
                    if (file.FullName.Contains(item)) 
                        getContent = false;  
             
                if (getContent) {
                    r = new FileReader(file.FullName);
                    string content = r.Read().Replace("\t", "").Replace("  ", " ");
                    if (content.Contains(find))
                    {
                        IProcedure procContextTerse = new ContextExtractor(find, 0, 125); 
                        IProcedure procContextVerbose = new ContextExtractor(find, 125, 450);
                     
                        sb.AppendFormat("{1}\n{0}\n{2}\n{4}\n{3}\n", 
                            file.FullName,
                            new String('#', 225),
                            procContextTerse.Execute(content).Replace("\n"," "),
                            procContextVerbose.Execute(content),
                             new String('_', 225)

                        );
                        cnt++;
                        fileNames.Append($"{cnt.ToString()} : {file.FullName}\n");
                        Console.WriteLine($"FOUND: {file.FullName}");
                    }
                }
            }
            Cache.Write(fileNames.ToString() + "\n\n" + sb.ToString());
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


