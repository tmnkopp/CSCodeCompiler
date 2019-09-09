using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler 
{
    public static class AppSettings
    {
        public static string ProcAssembly = ConfigurationManager.AppSettings["ProcAssembly"].ToString();
        public static string BasePath = ConfigurationManager.AppSettings["BasePath"].ToString();
        public static string Extention = ConfigurationManager.AppSettings["Extention"].ToString();
        public static string CompileSource = ConfigurationManager.AppSettings["CompileSource"].ToString();
        public static string CompileDest = ConfigurationManager.AppSettings["CompileDest"].ToString();
    }
    public static class Placeholders
    {
        public static string Dir = "[dir]";
        public static string Index = "[index]";
        public static string eXT = "[ext]";
    }
}
