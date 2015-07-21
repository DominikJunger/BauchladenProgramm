using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Backend_Klassen
{
    public class Produkt
    {
        private string id;
        private string name; 
        private decimal preis;

        public Produkt(string id, string name, decimal preis)
        {
            this.id = id;
            this.name = name;
            this.preis = preis;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public decimal Preis
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
