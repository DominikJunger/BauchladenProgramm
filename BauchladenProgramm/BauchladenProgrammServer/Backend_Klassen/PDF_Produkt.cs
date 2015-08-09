using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Backend_Klassen
{
    public class PDF_Produkt : Produkt
    {
        private int anzahl;
        
        public PDF_Produkt(string name, decimal preis,int anzahl): base(name,preis)
        {
            this.anzahl = anzahl;
        }

        public int Anzahl
        {
            get { return anzahl; }
            set { anzahl = value; }
        }
    }
}
