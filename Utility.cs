using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TransportExercise
{
    public class Utility
    {
        public static string GetConnString(string name)
        {
            var connstr = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return connstr;
        }

        public static string GetStProcName(string key)
        {
            var stproc = ConfigurationManager.AppSettings[key];
            return stproc;
        }
    }
}
