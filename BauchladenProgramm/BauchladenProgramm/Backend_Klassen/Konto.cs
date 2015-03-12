using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm
{
    public class Konto
    {
        private _Double kontostand;

        //Konstruktoren---------------------------------------
        public Konto()
        {
            this.kontostand = new _Double();
        }

        //Setter / Getter-------------------------------------
        public _Double Kontostand
        {
            get { return kontostand; }
        }

        //Ander Methoden-------------------------------------
    }
}

