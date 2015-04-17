using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Backend_Klassen
{
    class Produkt
    {
        private int id;
        private string name; 
        private double preis;

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
    }
}
