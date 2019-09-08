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
    public abstract class DataLookup<T>
    { 
        public SqlDataReader oReader { get; set; }
        public virtual void ExecuteSql(string sSql)
        {
            var con = ConfigurationManager.ConnectionStrings["Cyberscope123"].ToString();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                SqlCommand oCmd = new SqlCommand(sSql, myConnection);
                myConnection.Open();
                using (oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        LoadReader();
                    }
                    myConnection.Close();
                }
            }
        }
        public abstract void LoadReader();
        public abstract T GetData();
    }

    public class KeyValLookup : DataLookup<Dictionary<string, string>>
    {
        private Dictionary<string, string> data = new Dictionary<string, string>();
        public KeyValLookup(string sSql)
        {
            base.ExecuteSql(sSql);
        }
        public KeyValLookup(string key, string value, string table)
        {
            base.ExecuteSql($" SELECT DISTINCT CONVERT(nvarchar, {key}) as ID, CONVERT(nvarchar, {value}) as VAL FROM {table}");
        }
        public KeyValLookup(string key, string value, string table, string where)
        {
            base.ExecuteSql($" SELECT DISTINCT CONVERT(nvarchar, {key}) as ID, CONVERT(nvarchar, {value}) as VAL FROM {table} WHERE 1=1 AND {where}");
        }
        public override void LoadReader()
        {
            try  {
                data.Add(base.oReader[0].ToString(), base.oReader[1].ToString());
            }   catch (Exception)  {
                //just skip dupes
            }
        }
        public override Dictionary<string, string> GetData()
        {
            return data;
        }
    }
}
 
