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
namespace CSCodeCompiler
{
     class Program
    {
        static void Main(string[] args)
        {
            //DateTime localDate = DateTime.Now;
            //Console.Write($"  ...  {localDate.ToLongTimeString()} .. .  .");
            //Console.Read();
            CSCodeCompiler.FFCIOCompiler.Run(new string[] { });
            // CSCodeCompiler.Bootstrapper.Run();
            // CSCodeCompiler.DirSearcher.Run(new string[] { });
            // CSCodeCompiler.JiraTicketService.Run(new string[] { });
            // CSCodeCompiler.RMAFormCreator.Run();


            return; 
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


