using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCodeCompiler.Reflection
{
    public static class TypeUtils
    {
        public static bool IsInt(object arg) {
            try  {
                int i = Convert.ToInt32(arg);
                return true; 
            }
            catch (Exception)   {

                return false;
            }
        }
    }
}
