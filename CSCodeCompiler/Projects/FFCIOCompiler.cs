using CSCodeCompiler.IO;
using CSCodeCompiler.Procedures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler 
{
    public class FFCIOCompiler
    {
       
        public static void Run(string[] args)
        {
            Cache.Write("");
            //
            //CompileQGroups();
            ProcessFiles();
        }
        private static void CompileQGroups()
        {
            IProcedure proc;
            string content;
            // 
            content = new FileReader().Read();
            proc = new RepeaterCompile(1, 25);
            content = proc.Execute(content);
            proc = new IndexCompile(1350, 0, "[index1]");
            content = proc.Execute(content);
            proc = new IndexCompile(1701, 0, "[index2]");
            content = proc.Execute(content);
            Cache.Append(content);
            // 
            content = new FileReader().Read();
            proc = new RepeaterCompile(1, 15);
            content = proc.Execute(content);
            proc = new IndexCompile(16100, 0, "[index1]");
            content = proc.Execute(content); 
            proc = new IndexCompile(18100, 0, "[index2]");
            content = proc.Execute(content);
            Cache.Append(content) ;
            Cache.CacheEdit();
        }
         private static void ProcessFiles(){
            string root = @"D:\dev\CyberScope\CyberScopeBranch\CSwebdev\code\CyberScope\FismaForms\2019"; 
            DirectoryInfo DI = new DirectoryInfo($"{root}"); 
            
            foreach (var file in DI.GetFiles("2019_Q4_CIO_*", SearchOption.AllDirectories))
            { 
                string content = new FileReader(file.FullName).Read().ToString();

                IProcedure proc = new SqlKeyValCompile(@"C:\temp\CIOCompileKV.sql");
                content = proc.Execute(content);
                 
                FileWriter fw = new FileWriter($"C:\\temp\\pub\\{GetFileName(file.Name)}");
                fw.Write(content);
                Cache.Write(Cache.Read() + "\n" + content + "\n");
            } 
        }
        
        private static string GetFileName(string fname) {
            fname = fname.Replace("2019", "2020");
            fname = fname.Replace("Q4", "Q1");
            return fname;    
        }
    }
}
