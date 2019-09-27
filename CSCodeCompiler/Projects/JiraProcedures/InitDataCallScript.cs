using CSCodeCompiler.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Projects.JiraProcedures
{
    public class InitDataCallScript 
    {
        DataCallTicket _ticket;
        StringBuilder result = new StringBuilder(); 
        public InitDataCallScript(DataCallTicket ticket)
        {
            _ticket = ticket;
        }
        public string Execute()
        {
            foreach (var metric in _ticket.Metrics)
            {
                string qgroup = _ticket.Section;
                string idtext = metric.IDText;
                string met = metric.MetricText;
                result.AppendFormat("{0}","");
            }
            return result.ToString();
        }
    }
}
