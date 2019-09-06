using CSCodeCompiler.Strategies;
using CSCodeCompiler.Macros;
using CSCodeCompiler.Data;
using CSCodeCompiler.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
 


namespace CSCodeCompiler.Projects
{
    class Reflection
    {
        public static void Run(string[] args)
        {
 
            string cmdin = "IndexCompile -10 -0 -'[INDEX]'"; 
            string[] commands = cmdin.Split(new string[] { " -" }, StringSplitOptions.None); 

            Type type = Type.GetType($"CSCodeCompiler.Strategies.{commands[0]}"); 
            ConstructorInfo ctor = type.GetConstructors()[0];
            ParameterInfo[] PI = ctor.GetParameters();

            object[] typeParams = new object[PI.Count()];
            int i = 0;
            foreach (ParameterInfo parm in PI)
            {
                if (parm.ParameterType == typeof(int)) 
                    typeParams[i] = Convert.ToInt32(commands[i + 1]);
                 else  
                    typeParams[i] = commands[i + 1]; 
                i++;
            }  

            object obj = ctor.Invoke(typeParams);
            Console.WriteLine("{0} ", obj.ToString()); 
            Console.Read();


        }  
    }
}
