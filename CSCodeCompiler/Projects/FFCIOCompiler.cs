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
            //PreparePKEYSql();
            ProcessFiles();
            //Process_DB_Update();
        }


        private static void ProcessFiles(){
            string root = @"D:\dev\CyberScope\CyberScopeBranch\CSwebdev\code\CyberScope\FismaForms\2019";
            string ext = "";
            DirectoryInfo DI = new DirectoryInfo($"{root}"); 
            
            foreach (var file in DI.GetFiles("2019_Q4_CIO_*", SearchOption.AllDirectories))
            { 
                string content = new FileReader(file.FullName).Read().ToString();

                ext = new BlockExtractor("c1", "width: 65%; text-align: left", "<%--", "--%>").Execute(content);
                if (ext != "")
                    content = content.Replace(ext, "<%-- [DATE] --%>");

                content = new SqlKeyValCompile(@"C:\temp\CIOCompileKV.sql").Execute(content);   
                
                FileWriter fw = new FileWriter($"C:\\temp\\pub\\{GetFileName(file.Name)}");
                fw.Write(content);
                 
                //Cache.Append( "\n" + GetFileName(file.Name) );
            }
           
        }
        private static void PreparePKEYSql()
        {
            string content, template;
  
            content = new FileReader().Read();
            template = new PathCompile().Execute(content); 
             
            content = new RepeaterCompile(1, 25).Execute(template);
            content = new IndexCompile(1350, 0, "[index1]").Execute(content);
            content = new IndexCompile(1600, 0, "[index2]").Execute(content);
            Cache.Append(content);
             
            content = new RepeaterCompile(1, 250).Execute(template);
            content = new IndexCompile(16099, 0, "[index1]").Execute(content);
            content = new IndexCompile(17420, 0, "[index2]").Execute(content);
            Cache.Append(content);
  
            Cache.CacheEdit();

            //string template_insert = new FileReader($"C:\\temp\\templates\\SQLKVTEMPLATE.txt").Read().ToString();
            //template_insert = template_insert.Replace("[INSERTS]", Cache.Read());
            //FileWriter fw = new FileWriter($"C:\\temp\\SQLKVTEMPLATE.sql");
            //fw.Write(template_insert);
        }
        private static void Process_DB_Update()
        {
            //
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
