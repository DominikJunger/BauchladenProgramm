using System;

namespace BauchladenProgramm
{
    public class Teilnehmer: Person
    {
        private int id;
        private Konto konto;

        private static int naechsteId = 1;

//Konstruktoren--------------------------------------- 
        public Teilnehmer(string vorname, string nachname, DateTime geburtsdatum, string wohnort):base (vorname, nachname,geburtsdatum, wohnort)
        {
            this.id = naechsteId;
            naechsteId++;
            konto = new Konto();           
        }
        
//Setter / Getter-------------------------------------   
        public int Id
        {
            get { return id; }
        }

        public double Kontostand
        {
            get { return konto.Kontostand.Zahl; }
        }

//Andere Methoden-------------------------------------
        public override bool Equals(object obj)
        {
            if(!(obj.GetType() == typeof (Teilnehmer)))
                return false;
            Teilnehmer t = (Teilnehmer)obj;
            if (this.id == t.id)
                return true;
            else
                return false;
        }
    }
}
