using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.IO
{
    public interface IReader
    {
        string Read();
    }
    public class FileReader : IReader
    {
        private string _filename = ConfigurationManager.AppSettings["DefaultSource"].ToString();
        public FileReader(string filename)
        {
            _filename = filename;   
        }
        public string Read()
        {
            using (TextReader tr = File.OpenText(_filename))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
