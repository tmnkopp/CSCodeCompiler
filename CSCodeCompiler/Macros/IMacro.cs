using CSCodeCompiler.Procedures;
using CSCodeCompiler.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Macros
{
    public interface IMacro
    { 
        void Prepare();
        void Execute(List<IProcedure> procedureCollection); 
        void Commit();
    }
    public abstract class BaseMacro : IMacro
    {
        Dictionary<string, string> dictExecutionPlan = new Dictionary<string, string>();
        public BaseMacro()
        {
             Prepare();
        } 
        public virtual void Execute(IProcedure procedure)
        {
            string result = procedure.Execute(Cache.Read());
            Cache.Write(result); 
        }
        public virtual void Execute(List<IProcedure> procedureCollection)
        {
            int index = 0;
            foreach (var procedure in procedureCollection)
            {
                Execute(procedure);
                FileWriter f = new FileWriter($"c:\\temp\\${index++.ToString()}${procedure.ToString().Replace("CSCodeCompiler.Procedures.", "")}.{AppSettings.Extention}");
                f.Write(Cache.Read());
                dictExecutionPlan.Add(index.ToString(), procedure.ToString());
            }
        }
        public virtual void Commit()
        {
            IWriter writer = new FileWriter();
            writer.Write(Cache.Read());

           StringBuilder result = new StringBuilder();
           foreach (KeyValuePair<string, string> item in dictExecutionPlan)
                result.AppendFormat("${0}${1}\n", item.Key, item.Value.Replace("\"", "\\\""));
            writer = new FileWriter($"c:\\temp\\executionplan.config");
            writer.Write(result.ToString()); 

        }
        public virtual void Prepare()
        {
            IReader reader = new FileReader();
            Cache.Write(reader.Read());
        }
    }
}
