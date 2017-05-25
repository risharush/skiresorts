using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ski_Resorts
{
    class Log
    {
        public static void Logir(string l)
        {
            using (var filelog = File.AppendText("../../log.txt"))
            {
                filelog.WriteLine(l);
            }
        }
    }
}
