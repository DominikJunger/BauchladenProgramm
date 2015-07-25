using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Backend_Klassen
{
    public class Einkauf
    {
        private Produkt pr;
        private int anzahl;
        private DateTime date;

        public Einkauf(Produkt pr,int anzahl, DateTime date)
        {
            this.Pr = pr;
            this.Date = date;
            this.Anzahl = anzahl;
        }

        public Produkt Pr
        {
            get { return pr; }
            set { pr = value; }
        }
             
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Anzahl
        {
            get { return anzahl; }
            set { anzahl = value; }
        }
    }
}
