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
            //GenerateNewControlTemplate();
            // GenerateNewForms();
            Process_FRMVAL();


        }
        private static void Process_FRMVAL()
        {
            string root = @"C:\temp\CIO20\template.sql";
            //string dest = @"D:\dev\CyberScope\CyberScopeBranch\CSwebdev\database\Sprocs\frmVal_2020Q1CIO.sql";
            string dest = @"C:\temp\CIO20\frmVal_2020Q1CIO.sql";

            string content;
            content = new FileReader(root).Read().ToString();
            content = new SqlKeyValCompile(@"C:\temp\CIO20\transform.sql").Execute(content);

            string template135 = new FileReader(@"C:\temp\CIO20\template_compare_block.sql").Read().ToString();
            content = content.Replace("--CIO2020-1.3.5", template135);

            string template_appendix_header = new FileReader(@"C:\temp\CIO20\template_appendix_header.sql").Read().ToString();
            content = content.Replace("--template_appendix_header.sql", template_appendix_header);
            

            StringBuilder result = new StringBuilder();
            string[] lines = content.Split('\n');
            foreach (var line in lines)
            {                
                if (!line.Contains("--[rmline]")) 
                    result.AppendFormat("{0}\n", line);
                
            }
            content = result.ToString();

            FileWriter fw = new FileWriter(dest);
            fw.Write(content);
        }

        private static void GenerateNewForms(){
            string root = @"C:\temp\templates\CIO2020";
            string dest = @"D:\dev\CyberScope\CS-7-19\CSwebdev\code\CyberScope\FismaForms\2020";
            string content = "";
            DirectoryInfo DI = new DirectoryInfo($"{root}");
            StringBuilder result = new StringBuilder();
            foreach (var file in DI.GetFiles("2019_Q4_CIO_*", SearchOption.AllDirectories))
            { 
                content = new FileReader(file.FullName).Read().ToString(); 
                content = new SqlKeyValCompile(@"C:\temp\CIOCompileKV.sql").Execute(content);
                 
                FileWriter fw = new FileWriter($"{dest}\\{GetFileName(file.Name)}");
                fw.Write(content);
                  
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


        private static string GetFileName(string fname) {
            fname = fname.Replace("2019", "2020");
            fname = fname.Replace("Q4", "Q1");
            return fname;    
        }
    }
}
