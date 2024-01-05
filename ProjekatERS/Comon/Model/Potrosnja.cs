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
        public int Sat { get; set; }

        [DataMember]
        public float PrognoziranaP { get; set; }

        [DataMember]
        public float OstvarenaP { get; set; }

        [DataMember]
        public float Odstupanje { get; set; }

        public Potrosnja(DateTime datum, string geografskaOblast, int sat, float prognoziranaP, float ostvarenaP, float odstupanje)
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
