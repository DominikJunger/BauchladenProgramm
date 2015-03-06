using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm
{
    public class Person
    {
        private string nachname;
        private DateTime geburtsdatum;  
        private string wohnort;
        private string vorname;

      
        public Person(string vorname, string nachname, DateTime geburtsdatum, string wohnort)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.geburtsdatum = geburtsdatum;
            this.wohnort = wohnort;
        }


        public string Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }
        public string Nachname
        {
            get { return nachname; }
            set { nachname = value; }
        }
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set { geburtsdatum = value; }
        }

        public string Wohnort
        {
            get { return wohnort; }
            set { wohnort = value; }
        }
    }
}
