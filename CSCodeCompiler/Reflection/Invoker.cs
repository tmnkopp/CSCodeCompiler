using CSCodeCompiler.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSCodeCompiler.Extentions;
namespace CSCodeCompiler.Reflection
{
    public interface Invoker {
        object Invoke(string InvocationCommand);
    }
    public class ProcedureInvoker : Invoker
    {
        public object Invoke(string InvocationCommand)
        {
            string[] commands = InvocationCommand.Split(new string[] { " -" }, StringSplitOptions.None);

            Type type = Type.GetType($"{AppSettings.ProcAssembly}{commands[0]}");
            ConstructorInfo ctor = type.GetConstructors()[0];
            ParameterInfo[] PI = ctor.GetParameters(); 
            object[] typeParams = new object[PI.Count()];
            int i = 0;
            foreach (ParameterInfo parm in PI)
            {
                if (parm.ParameterType == typeof(int))
                {
                    typeParams[i] = Convert.ToInt32(commands[i + 1]);
                }
                else
                {
                    typeParams[i] = commands[i + 1].RemoveAsChars("'");   
                }
                i++;
            } 
            object procedure = ctor.Invoke(typeParams);
            return procedure; 
        } 
    }
}
