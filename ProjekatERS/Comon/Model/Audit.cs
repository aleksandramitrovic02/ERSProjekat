using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Model
{
    [DataContract]
    public class Audit
    {
        public Audit(DateTime vremeUcitavanja, string imeFajla, string lokacija, int brojRedova)
        {
            VremeUcitavanja = vremeUcitavanja;
            ImeFajla = imeFajla;
            Lokacija = lokacija;
            BrojRedova = brojRedova;
        }

        public Audit() { }

        public override string ToString()
        {
            return $"{VremeUcitavanja},{ImeFajla},{Lokacija},{BrojRedova}";
        }

        [DataMember]
        public DateTime VremeUcitavanja { get; set; }

        [DataMember]
        public String ImeFajla { get; set; }

        [DataMember]
        public String Lokacija { get; set; }

        [DataMember]
        public int BrojRedova { get; set; }
    }
}
