using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BauchladenProgramm.Backend_Klassen;

namespace BauchladenProgrammServer.Klassen
{
    class CSV_Reader
    {
        public List<Teilnehmer> ReadCSV(string filename)
        {
            List<Teilnehmer> teilnehmer = new List<Teilnehmer>();
            StreamReader fs = new StreamReader(new FileStream(filename,FileMode.Open));

            string strLine;
            string[] strArray;

            while (!fs.EndOfStream)
            {
                strLine = fs.ReadLine();
                strArray = strLine.Split(',');
                if ((strArray[1]!="") || (strArray[2]!=""))
                    teilnehmer.Add(new Teilnehmer(strArray[1], strArray[2], new DateTime(new DateTime().Day,new DateTime().Month,new DateTime().Year).Date, strArray[4]));
            }
            
            return teilnehmer;
        }
    }
}
