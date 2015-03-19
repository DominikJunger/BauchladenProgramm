using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BauchladenProgramm;
using BauchladenProgramm.Backend_Klassen;

namespace BauchladenProgrammUnitTests
{
    class ProduktVerwaltung
    {
        private List<Produkt> produkte;
        
//Konstruktoren--------------------------------------- 
        public ProduktVerwaltung()
        {
            this.produkte = new List<Produkt>(10);
        }

//Setter / Getter------------------------------------- 

//Andere Methoden-------------------------------------
        public void produktHinzufuegen(string name, string beschreibung, double preis)
        {
            if(name==null || name.Length<=2)
            {
                throw new Exception("Der Produktname muss mehr als zwei Zeichen enthalten");
            }
            if (preis <= 0)
            {
                throw new Exception("Der Produktpreis muss größer als 0 Euro sein");
            }

            if (beschreibung != null)
            {
                this.produkte.Add(new Produkt(name, beschreibung, preis));
            }
            else
            {
                this.produkte.Add(new Produkt(name, preis));
            }
        }

        public void produktHinzufuegen(string name, double preis)
        {
            this.produktHinzufuegen(name,null,preis);
        }

        public int anzahlProdukte()
        {
            return this.produkte.Count;
        }

        //public Produkt produktMitIdSuchen()
        //{
            //return BauchladenProgramm.SearchLinear<Produkt>.search(produkte, (x, y) => { return x.getID() == y.getID(); },);
        //}
        public void produktbeschreibungAendern(int id, string neueBeschreibung)
        {

        }
    }
}
