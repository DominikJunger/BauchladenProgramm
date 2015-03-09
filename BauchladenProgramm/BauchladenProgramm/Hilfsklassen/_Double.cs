using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm
{
    public class _Double
    {

        private Double zahl;

        public Double Zahl
        {
            get { return zahl; }
            set
            {
                this.zahl = value;
                string zahlString=this.zahl.ToString();
                if (zahlString.Contains(','))
                {
                    string s = zahlString.Substring(zahlString.IndexOf(',')+1);
                    if (!((s.Length) <= 2))
                    {
                        throw new Exception("Zahl mit zu vielen Nachkommastellen");
                    }
                }
            }
        }

        public _Double(double zahl)
        {
            this.Zahl = zahl;
        }

        public _Double()
        {
            this.Zahl = 0.00;
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType() == typeof(_Double)))
                return false;
            _Double t = (_Double)obj;
            if (this.zahl == t.zahl)
                return true;
            else
                return false;
        }
    }
}
