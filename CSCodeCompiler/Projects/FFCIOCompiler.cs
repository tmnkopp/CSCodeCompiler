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
            GenerateNewControlTemplate();
            GenerateNewForms();
        
        }


        private static void GenerateNewForms(){
            string root = @"C:\temp\templates\CIO2020";
            string dest = @"D:\dev\CyberScope\CS-7-19\CSwebdev\code\CyberScope\FismaForms\2020";
            string content = "";
            DirectoryInfo DI = new DirectoryInfo($"{root}"); 
            
            foreach (var file in DI.GetFiles("2019_Q4_CIO_*", SearchOption.AllDirectories))
            { 
                content = new FileReader(file.FullName).Read().ToString(); 
                content = new SqlKeyValCompile(@"C:\temp\CIOCompileKV.sql").Execute(content);

                FileWriter fw = new FileWriter($"{dest}\\{GetFileName(file.Name)}");
                fw.Write(content);
                 
               // Cache.Append( "\n" + GetFileName(file.Name) );
            }
            //Cache.CacheEdit();
        }
        
        private static void GenerateNewControlTemplate( )
        {
            StringBuilder sb = new StringBuilder();
            string content, template;
            template = new FileReader(@"C:\temp\templates\CBNumeric.txt").Read().ToString();
            for (int i = 30; i < 38; i++)
            {
                sb.Append(template.Replace("[CBNID1]", i.ToString()));
            }  
            content = sb.ToString();
            content = new IndexCompile(50, 0, "[CB_ID_1]").Execute(content);   
            content = new IndexCompile(5, 0, "[PKQ]").Execute(content);
          
            //Cache.Append(content);
            //Cache.CacheEdit();
            FileWriter fw = new FileWriter($"C:\\temp\\templates\\CIO2020Q11-3-5.txt");
            fw.Write(content);

        }

        private static void Process_DB_Update()
        { 
            string root = @"D:\dev\CyberScope\CS-7-19\CSwebdev\database\DB_Update7.19_CIOQ120.sql";
            string ext, content; 
            content = new FileReader(root).Read().ToString();
            content = new SqlKeyValCompile(@"C:\temp\DB_UPDATE_CompileKV.sql").Execute(content); 
            FileWriter fw = new FileWriter($"C:\\temp\\pub\\DB_Update7.19_CIOQ120.sql");
            fw.Write(content); 
        } 
        private static string GetFileName(string fname) {
            fname = fname.Replace("2019", "2020");
            fname = fname.Replace("Q4", "Q1");
            return fname;    
        }
    }
}
