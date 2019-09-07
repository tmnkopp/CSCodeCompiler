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
        public Dictionary<string, string> DictLookup(string key, string value, string table) {
            string result = KeyValueLookup(  key,   value,   table);
            return JsonConvert
                .DeserializeObject<Dictionary<string, string>>("{" + result.ToString() + "}");
        }
        public string KeyValueLookup(string key, string value, string table) {
            var con = ConfigurationManager.ConnectionStrings["Cyberscope123"].ToString();
            StringBuilder result = new StringBuilder();
            string sSql = $" SELECT  + STUFF((Select  ',\"' + CONVERT(nvarchar, {key}) + '\":\"' + CONVERT(nvarchar, {value}) + '\"' From {table} FOR XML PATH('')),1,1,'')  ";
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
    }
}
