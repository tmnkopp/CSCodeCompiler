using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.IO
{
    public interface IWriter
    {
        void Write(string writeme);
    } 
    public class FileWriter :  IWriter
    {
        private string _path = ConfigurationManager.AppSettings["CompileDest"].ToString();
        private string _basepath = ConfigurationManager.AppSettings["BasePath"].ToString();
        public FileWriter()
        {
        }
        public FileWriter(string Path)
        {
            _path = Path;
        }
        public void Write(string writeme)
        {
            _path = String.Format("{0}", _path.Replace("~", _basepath));
            File.WriteAllText($"{_path}", writeme);
        }
    }
}
