using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Infrastructure
{
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies(){
            return new Assembly[]{
                Assembly.Load("myfinance_web_netcore"),
            };
        }
    }
}