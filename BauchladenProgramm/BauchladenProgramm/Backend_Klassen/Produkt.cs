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
        string beschreibung;
        _Double preis;
        
//Konstruktoren--------------------------------------- 
        public Produkt(string name, string beschreibung, _Double preis) 
        {
            this.name = name;
            this.Beschreibung = beschreibung;
            this.Preis = preis;
        }

        public Produkt(string name, _Double preis)
        {
            this.name = name;          
            this.Preis = preis;
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
        
//Ander Methoden-------------------------------------
    }
}
