using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm
{
    public class Einkauf
    {
        private _Double gesamtPreis;
        private DateTime datum;
        private List<Produkt> produkte;

        public List<Produkt> Produkte
        {
            get { return produkte; } 
        }

        public Einkauf(_Double gesamtPreis, DateTime datum)
        {
            this.GesamtPreis = gesamtPreis;
            this.Datum = datum;
            produkte = new List<Produkt>();
        }

        public _Double GesamtPreis
        {
            get { return gesamtPreis; }
            set { gesamtPreis = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

    }
}
