using CSCodeCompiler.Data;
using CSCodeCompiler.IO;
using CSCodeCompiler.Procedures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSCodeCompiler.Procedures
{
    public abstract class KeyValCompile : IProcedure
    { 
        public Dictionary<string, string> Dict { get; set; }
        public string Execute(string compileme)
        {
            foreach (var item in Dict)
                compileme = compileme.Replace(item.Key,item.Value);
            return compileme;        
        }
        public override string ToString()
        {
            return $"{base.ToString()}-#{Dict.ToString()}";
        }
    }
    public class SqlKeyValCompile : KeyValCompile, IProcedure  { 
        public SqlKeyValCompile(string sqlFile)
        {
            IReader r = new FileReader(sqlFile);
            KeyValDBReader dbreader = new KeyValDBReader(r.Read()); 
            dbreader.ExecuteRead(); 
            base.Dict = dbreader.Data;
        }
    }
    public class DictCompile : KeyValCompile, IProcedure
    { 
        public DictCompile(Dictionary<string, string> Dict)
        {
            base.Dict = Dict;
        } 
    }
}
