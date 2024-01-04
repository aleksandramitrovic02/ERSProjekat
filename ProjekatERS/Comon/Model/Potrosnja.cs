using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Model
{
    [DataContract]
    public class Potrosnja
    {
        [DataMember]
        public DateTime Datum { get; set; }

        [DataMember]
        public String GeografskaOblast { get; set; }

        [DataMember]
        public DateTime Sat { get; set; }

        [DataMember]
        public double PrognoziranaP { get; set; }

        [DataMember]
        public double OstvarenaP { get; set; }

        [DataMember]
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
