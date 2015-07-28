using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm.Backend_Klassen
{
    public class Teilnehmer
    {
        private int id;    
        private string vorName;      
        private string nachName;
        private bool inaktiv;

        public Teilnehmer(int id, string vorName, string nachName,bool inaktiv)
        {
            this.id = id;
            this.vorName = vorName;
            this.nachName = nachName;
            this.inaktiv = inaktiv;
        }

        public bool Inaktiv
        {
            get { return inaktiv; }
            set { inaktiv = value; }
        }

        public int Id
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
    }
}
