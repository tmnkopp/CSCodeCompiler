using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler 
{
    public static class Constants
    { 
        public static string ProcAssembly = ConfigurationManager.AppSettings["ProcAssembly"].ToString();

    }
}
