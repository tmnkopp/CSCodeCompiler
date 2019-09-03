using System;
using System.Collections.Generic;
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
    public class ConsoleWriter : IWriter
    {
        public void Write(string writeme)
        {
            Console.Write(writeme);
        }
    }
    public class FileWriter : IWriter
    {
        private string _path = @"c:\temp\_output.txt";
        public FileWriter(string Path)
        {
            _path = Path;
        }
        public void Write(string writeme)
        {
            File.WriteAllText($"{_path}", writeme);
        }
    }
}
