using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Data
{
    public class DBUtils
    {
        public string DBLookup(string sSql) {
            var con = ConfigurationManager.ConnectionStrings["Cyberscope123"].ToString();
            StringBuilder result = new StringBuilder();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                SqlCommand oCmd = new SqlCommand(sSql, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        result.Append(oReader[0].ToString());   
                    }
                    myConnection.Close();
                }
            }
            return result.ToString();
        }
        public Dictionary<string, string> KeyValueLookup(string key, string value, string table) {
            var con = ConfigurationManager.ConnectionStrings["Cyberscope123"].ToString();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string sSql = $" SELECT DISTINCT CONVERT(nvarchar, {key}) as ID, CONVERT(nvarchar, {value}) as VAL FROM {table}  ";
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                SqlCommand oCmd = new SqlCommand(sSql, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        try  {
                            dict.Add(oReader[0].ToString(), oReader[1].ToString());
                        }   catch ()  {
                            //just skip dupes
                        } 
                    }
                    myConnection.Close();
                }
            }
            return dict; 
        }
    }
}
