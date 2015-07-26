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
        private bool verfügbar;
        private bool bücherT;

        public Produkt(string name, decimal preis)
        {
            this.name = name;
            this.preis = preis;
        }

        public Produkt(string id, string name, decimal preis)
        {
            this.id = id;
            this.name = name;
            this.preis = preis;
        }

        public Produkt(string id, string name, decimal preis, bool verfügbar, bool bücherT)
        {
            this.id = id;
            this.name = name;
            this.preis = preis;
            this.verfügbar = verfügbar;
            this.bücherT = bücherT;
        }

        public bool BücherT
        {
            get { return bücherT; }
            set { bücherT = value; }
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

        public bool Verfügbar
        {
            get { return verfügbar; }
            set { verfügbar = value; }
        }
    }
}
