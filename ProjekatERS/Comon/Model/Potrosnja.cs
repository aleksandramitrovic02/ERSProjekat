using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Model
{
    public class Potrosnja
    {
        public DateTime Datum { get; set; }
        public String GeografskaOblast { get; set; }
        public DateTime Sat { get; set; }
        public double PrognoziranaP { get; set; }
        public double OstvarenaP { get; set; }
        public double Odstupanje { get; set; }

        public Potrosnja(DateTime datum, string geografskaOblast, DateTime sat, double prognoziranaP, double ostvarenaP, double odstupanje)
        {
            Datum = datum;
            GeografskaOblast = geografskaOblast;
            Sat = sat;
            PrognoziranaP = prognoziranaP;
            OstvarenaP = ostvarenaP;
            Odstupanje = odstupanje;
        }

        public Potrosnja()
        {
        }

        public override string ToString()
        {
            return $"{Datum},{GeografskaOblast},{Sat},{PrognoziranaP},{OstvarenaP},{Odstupanje}";
        }
    }
}
