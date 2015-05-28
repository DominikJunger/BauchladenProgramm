using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgramm.Backend_Klassen
{
    public class Teilnehmer
    {
        private int id;    
        private string vorName;      
        private string nachName;       

        public Teilnehmer(int id, string vorName, string nachName)
        {
            this.id = id;
            this.vorName = vorName;
            this.nachName = nachName;
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
