using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSCodeCompiler.Procedures 
{
    public class JiraDescriptionParse : IProcedure
    {
        public string Execute(string content)
        {
            StringBuilder result = new StringBuilder();
            string IDTEXT = @"<p>\d+\w+\.</p>";
            string detail = "<p>.{45,500}</p>?";
            string[] statements = content.Split('\n');
            foreach (var statement in statements)  {
                //if (statement.Contains("PK_Question=")) {
                    Regex regex = new Regex("PK_Question=\"\\d+\"");
                    Match match = regex.Match(statement);
                    if (match.Success)
                    {
                        result.AppendFormat("{1}{0}{2}", match.Value,"< ",">");
                        //Console.WriteLine("MATCH VALUE: " + );
                    }
                //}
            }
            return result.ToString();
        }
    }
}
