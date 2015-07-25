using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BauchladenProgrammServer.Backend_Klassen;

namespace BauchladenProgrammServer.Klassen
{
    public class CSV_Reader
    {
        public List<Teilnehmer> ReadCSV(string filename)
        {
            List<Teilnehmer> teilnehmer = new List<Teilnehmer>();
            StreamReader fs = new StreamReader(new FileStream(filename,FileMode.Open),System.Text.Encoding.Default);

            string strLine;
            string[] strArray;

            while (!fs.EndOfStream)
            {
                strLine = fs.ReadLine();
                strArray = strLine.Split(';');
                if ((strArray[1] != "") || (strArray[2] != ""))
                {
                      teilnehmer.Add(new Teilnehmer(strArray[0],strArray[1]));
                }
            }
            return teilnehmer;
        }
    }
}
