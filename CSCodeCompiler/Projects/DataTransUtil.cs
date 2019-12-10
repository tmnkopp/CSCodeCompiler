using CSCodeCompiler.IO;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Procedures;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler
{
    public class DataTransUtil
    {
        public static void Run()
        {
            StringBuilder sb = new StringBuilder();
            var con = ConfigurationManager.ConnectionStrings["Cyberscope123"].ToString();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                SqlCommand oCmd = new SqlCommand("SELECT TOP 25 * FROM RMAIncidents_IMPORT", myConnection);
                myConnection.Open(); 
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                { 
                    var columns = Enumerable.Range(0, oReader.FieldCount).Select(oReader.GetName).ToList();
                    foreach (var col in columns)
                    {
                        sb.AppendFormat(  "{0} \t", col.ToString()   );
                    } 
                    sb.AppendFormat("{0}", "\n -- \n");
                    while (oReader.Read())
                    {
                        foreach (var col in columns)
                        {
                            string index = String.Format("{0}", col.ToString());
                            string val = oReader[index].ToString();
                            string typ = oReader[index].GetType().ToString(); 
                            if (typ.Contains("String"))
                                sb.AppendFormat("'{0}', \t", val);
                            else
                                sb.AppendFormat("{0}, \t", val); 
                        }
                        sb.AppendFormat("{0}", "\n");
                    } 
                }
                myConnection.Close();
            }
            Cache.Write(sb.ToString());
            Cache.CacheEdit();
            //FileWriter fw = new FileWriter($"C:\\temp\\templates\\RMA_INSERT.txt");
           // fw.Write(content);
        }

        private static void RMAInsertGen() {
            StringBuilder sb = new StringBuilder();
            string content, template;
            template = new FileReader(@"C:\temp\templates\RMA_INSERT.txt").Read().ToString();

            SqlKeyValCompile sqlKeyValCompile = new SqlKeyValCompile(@"C:\temp\RMA_INSERT.sql");
            // sqlKeyValCompile.Dict
            foreach (KeyValuePair<string, string> entry in sqlKeyValCompile.Dict)
            {
                sb.AppendFormat(template.Replace("-Incidents_Vector-", entry.Value) + "\n\n");
                sb.AppendFormat("\n\nUNION\n\n");
                // do something with entry.Value or entry.Key
            }

            Cache.Write(sb.ToString());
            Cache.CacheEdit();
            //FileWriter fw = new FileWriter($"C:\\temp\\templates\\RMA_INSERT.txt");
            // fw.Write(content);
        }
    }
}
