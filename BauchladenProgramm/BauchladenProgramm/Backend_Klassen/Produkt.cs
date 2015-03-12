using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgramm
{
    public class Produkt
    {
        private string name;
        private string beschreibung;
        private _Double preis;
        private int id;
        private static int naechsteId = 1;
        
//Konstruktoren--------------------------------------- 
        public Produkt(string name, double preis)
        {
            this.name = name;
            this.Preis = new _Double(preis);
            this.id = naechsteId;
            naechsteId++;
        }
        public Produkt(string name, string beschreibung, double preis): this(name, preis)
        {
            this.Beschreibung = beschreibung;
        }

//Setter / Getter-------------------------------------        
        public string Name
        {
            get { return name; }
        }

        public string Beschreibung
        {
            get { return beschreibung; }
            set { beschreibung = value; }
        }

        public _Double Preis
        {
            get { return preis; }
            set { preis = value; }
        }
        
//Andere Methoden-------------------------------------
    }
}
