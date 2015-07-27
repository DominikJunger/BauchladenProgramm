using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Backend_Klassen
{
    public class Teilnehmer
    {
        private int id;    
        private string vorName;      
        private string nachName;
        private double kontostand;
        private bool inatkiv;

        public Teilnehmer(string id, string vorName, string nachName, decimal kontostand, bool inaktiv)
        {
            this.id = int.Parse(id);
            this.vorName = vorName;
            this.nachName = nachName;
            this.Kontostand = Double.Parse(kontostand.ToString());
            this.inatkiv = inaktiv;
        }

        public Teilnehmer(int id, string vorName, string nachName, decimal kontostand, bool inaktiv)
        {
            this.id = id;
            this.vorName = vorName;
            this.nachName = nachName;
            this.Kontostand = Double.Parse(kontostand.ToString());
            this.inatkiv = inaktiv;
        }
        public Teilnehmer(string vorName, string nachName)
        {
            this.vorName = vorName;
            this.nachName = nachName;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool Inatkiv
        {
            get { return inatkiv; }
            set { inatkiv = value; }
        }
        public string VorName
        {
            get { return vorName; }
            set { vorName = value; }
        }
        public string NachName
        {
            get { return nachName; }
            set { nachName = value; }
        }

        public double Kontostand
        {
            get { return kontostand; }
            set { kontostand = value; }
        }
    }
}
