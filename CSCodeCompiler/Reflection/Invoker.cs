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

            Type type = Type.GetType($"{Constants.ProcAssembly}{commands[0]}");
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
                    string stringParam = commands[i + 1];
                    if (stringParam.StartsWith("#"))// we have a hash
                    {
                        stringParam = stringParam.Replace("#","");
                        Type Tdict = Type.GetType($"CSCodeCompiler.Data.Dictionaries");
                        MethodInfo MI = Tdict.GetMethod("SysCodes");
                        Dictionary<string, string> 
                            dict = (Dictionary<string, string>)MI.Invoke(null, new object[] { });
                        typeParams[i] = dict; 
                    }
                    else // we have a simple string
                    {
                        typeParams[i] = stringParam.RemoveAsChars("'");
                    }
                    
                }
                i++;
            } 
            object procedure = ctor.Invoke(typeParams);
            return procedure; 
        } 
    }
}
