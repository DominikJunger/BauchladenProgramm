using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgramm
{
    public class Produkt
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string beschreibung;

        public string Beschreibung
        {
            get { return beschreibung; }
            set { beschreibung = value; }
        }
        _Double preis;

        public _Double Preis
        {
            get { return preis; }
            set { preis = value; }
        }

        public Produkt(string name, string beschreibung, _Double preis) 
        {
            this.Name = name;
            this.Beschreibung = beschreibung;
            this.Preis = preis;
        }

        public Produkt(string name, _Double preis)
        {
            this.Name = name;          
            this.Preis = preis;
        }


    }
}
