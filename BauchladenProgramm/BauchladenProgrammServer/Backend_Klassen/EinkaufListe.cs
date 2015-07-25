using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Backend_Klassen
{
    public class EinkaufListe
    {
        private List<Einkauf> el;
        private Teilnehmer tn;

        public EinkaufListe()
        {
            el=new List<Einkauf>();
        }

        public List<Einkauf> El
        {
            get { return el; }
            set { el = value; }
        }

        public Teilnehmer Tn
        {
            get { return tn; }
            set { tn = value; }
        }
 
    }
}
