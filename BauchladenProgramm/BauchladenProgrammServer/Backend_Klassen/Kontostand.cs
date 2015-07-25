using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Backend_Klassen
{
    public class Kontostand
    {
        private decimal kstand;
        private string datum;

        public Kontostand(decimal kontostand, string datum)
        {
            this.kstand = kontostand;
            this.datum = datum;
        }

        public decimal Kstand
        {
            get { return kstand; }
        }

        public string Datum
        {
            get { return datum; }
            set { datum = value; }
        }
    }
}
