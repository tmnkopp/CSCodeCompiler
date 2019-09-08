﻿using CSCodeCompiler.IO;
using CSCodeCompiler.Procedures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace CSCodeCompiler.Procedures
{
    public class PathCompile : IProcedure
    {  
        public string Execute(string compileme)
        {
            StringBuilder result = new StringBuilder();
            string[] lines = compileme.Split('\n'); 
            foreach (var line in lines)
            {
                string pattern = "\\[\\w:.+\\]";
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    string filename = match.Value.Replace("[","").Replace("]", "");
                    FileReader r = new FileReader(filename); 
                    result.AppendFormat("{0}", line.Replace(match.Value, r.Read()));
                }   else  {
                    result.AppendFormat("{0}\n", line);
                } 
            }
            return result.ToString();       
        }
        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}
