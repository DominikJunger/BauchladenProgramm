using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BauchladenProgramm.Backend_Klassen
{
    public class Produkt
    {
        private int id;
        private string name; 
        private double preis;
        private int anzahl;

        public Produkt(string id, string name, string preis, int anzahl)
        {
            this.id = Int32.Parse(id);
            this.name = name;
            this.preis = Double.Parse(preis);
            this.anzahl = anzahl;
        }

        public Produkt(int id, string name, double preis)
        {
            this.id = id;
            this.name = name;
            this.preis = preis;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Preis
        {
            get { return preis; }
            set { preis = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Anzahl
        {
            get { return anzahl; }
            set { anzahl = value; }
        }
    }
}
