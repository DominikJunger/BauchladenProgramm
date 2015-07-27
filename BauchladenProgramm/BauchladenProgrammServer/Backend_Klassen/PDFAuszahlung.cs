using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Backend_Klassen
{
    public class PDFAuszahlung
    {
        private EinkaufListe el;
        private List<Kontostand> auszahlung;
        private List<Kontostand> einzahlung;
        private List<Kontostand> auflistung;

        public PDFAuszahlung(EinkaufListe el, List<Kontostand> auszahlung, List<Kontostand> einzahlung, List<Kontostand> auflistung)
        {
            this.el = el;
            this.auszahlung = auszahlung;
            this.einzahlung = einzahlung;
            this.auflistung = auflistung;
        }

        public EinkaufListe El
        {
            get { return el; }
            set { el = value; }
        }

        public List<Kontostand> Einzahlung
        {
            get { return einzahlung; }
            set { einzahlung = value; }
        }


        public List<Kontostand> Auszahlung
        {
            get { return auszahlung; }
            set { auszahlung = value; }
        }

        public List<Kontostand> Auflistung
        {
            get { return auflistung; }
            set { auflistung = value; }
        }
    }
}
