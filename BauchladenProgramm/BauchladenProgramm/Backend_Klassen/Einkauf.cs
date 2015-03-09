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

//Konstruktoren---------------------------------------
        public Einkauf(DateTime datum)
        {
            this.Datum = datum;
            produkte = new List<Produkt>();
        }

//Setter / Getter-------------------------------------
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

        public List<Produkt> Produkte
        {
            get { return produkte; }
        }

//Ander Methoden-------------------------------------

    }
}
