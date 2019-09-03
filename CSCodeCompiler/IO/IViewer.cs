using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.IO
{
    public interface IViewer
    {
        void View(string viewme);
    }
    public class ConsoleViewer : IViewer
    {
        public void View(string writeme)
        {
            Console.Write(writeme);
        }
    }
    public class NotepadViewer : IViewer
    {
        private string _path = @"c:\temp\_output.txt";
        public NotepadViewer()
        {
        }
        public NotepadViewer(string Path)
        {
            _path = Path;
        }
        public void View(string writeme)
        {
            File.WriteAllText($"{_path}", writeme); 
            Process p = new Process();
            p.StartInfo.FileName = "notepad.exe";
            p.StartInfo.Arguments = _path;
            p.Start(); 
        }
    }
}
