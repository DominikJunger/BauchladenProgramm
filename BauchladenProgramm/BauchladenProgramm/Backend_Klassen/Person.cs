using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm.Backend_Klassen
{
    public class Person
    {
        private string nachname;
        private DateTime geburtsdatum;  
        private string wohnort;
        private string vorname;

//Konstruktoren---------------------------------------      
        public Person(string vorname, string nachname, DateTime geburtsdatum, string wohnort)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.geburtsdatum = geburtsdatum;
            this.wohnort = wohnort;
        }

//Setter / Getter-------------------------------------
        public string Vorname
        {
            get { return vorname; }
        }
        public string Nachname
        {
            get { return nachname; }
            set { this.nachname = value; }
        }
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
        }

        public string Wohnort
        {
            get { return wohnort; }
        }

//Ander Methoden-------------------------------------
    }
}
