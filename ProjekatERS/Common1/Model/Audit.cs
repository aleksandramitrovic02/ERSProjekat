using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common1.Model
{
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

        public DateTime VremeUcitavanja { get; set; }

        public String ImeFajla { get; set; }

        public String Lokacija { get; set; }

        public int BrojRedova { get; set; }
    }
}
