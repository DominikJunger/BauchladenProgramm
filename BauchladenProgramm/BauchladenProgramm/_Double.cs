using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BauchladenProgramm
{
    public class _Double
    {
       
        private Double zahl;

        public _Double(double zahl)
        {
            this.zahl = zahl;
            if (!((this.zahl.ToString().Substring(this.zahl.ToString().IndexOf('.')).Length) <= 2))
                throw new Exception("Zahl mit zu vielen Nachkommastellen");
        }
    }
}
