using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Backend_Klassen
{
    public class Teilnehmer
    {
        private string id;    
        private string vorName;      
        private string nachName;
        private double kontostand;
 

        public Teilnehmer(string id, string vorName, string nachName, double kontostand)
        {
            this.id = id;
            this.vorName = vorName;
            this.nachName = nachName;
            this.Kontostand = kontostand;
         
        }    

        public string Id
        {
            get { return id; }
            set { id = value; }
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
