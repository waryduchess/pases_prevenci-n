using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PASE.Modelos
{
    public class ConfigurarSQLite
    {
        public static void ConfigurarRuta()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string architecture = Environment.Is64BitProcess ? "x64" : "x86";
            string path = Path.Combine(basePath, architecture);

            string currentPath = Environment.GetEnvironmentVariable("PATH");
            if (!currentPath.Contains(path))
            {
                Environment.SetEnvironmentVariable("PATH", path + ";" + currentPath);
            }
        }
    }
}

