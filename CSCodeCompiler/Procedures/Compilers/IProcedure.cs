using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Procedures
{
    public interface IProcedure
    {
         string Execute(string content);
    } 
}
