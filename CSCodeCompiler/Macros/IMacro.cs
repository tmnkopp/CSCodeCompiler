using CSCodeCompiler.Procedures;
using CSCodeCompiler.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace CSCodeCompiler.Macros
{
    public interface IMacro
    { 
        void Prepare();
        void Execute(List<IProcedure> procedureCollection); 
        void Commit();
    }
   
}
