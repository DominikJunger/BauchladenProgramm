using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Klassen
{
    public class Log
    {
        private StreamWriter sw;

        public Log(string path)
        {
            if (path != null && path != "")
            {
                sw = new StreamWriter(path,true);
            }
        }

        public void write(string text)
        {
            if(text!=null && text!="" && sw!= null)
            sw.WriteLine(DateTime.Now +": "+text);
        }
        public void close()
        {
            if (sw != null)
            {
                sw.Close();
            }
        }
    }
}
