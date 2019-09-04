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
    public class ConsoleWriter : IWriter
    {
        public void Write(string writeme)
        {
            Console.Write(writeme);
            Console.ReadLine();
        }
    }
    public class FileWriter : IWriter
    {
        private string _path = @"c:\temp\_output.txt";
        public FileWriter( ) {
        }
        public FileWriter(string Path)
        {
            _path = Path;
        }
        public void Write(string writeme)
        {
            File.WriteAllText($"{_path}", writeme);
        }
    }    
    
    public class TextConsole : IWriter
    {
        private string _path = @"c:\temp\_output.txt";
        public TextConsole()
        {
        }
        public TextConsole(string Path)
        {
            _path = Path;
        }
        public void Write(string writeme)
        {
            File.WriteAllText($"{_path}", writeme);
            Process p = new Process();
            p.StartInfo.FileName = ConfigurationManager.AppSettings["CodeViewer"].ToString();
            p.StartInfo.Arguments = _path;
            p.Start();
        }
    }

}
