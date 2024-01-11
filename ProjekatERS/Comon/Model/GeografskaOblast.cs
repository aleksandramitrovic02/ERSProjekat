using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Model
{
    [DataContract]
    public class GeografskaOblast
    {
        [DataMember]
        public String Ime { get; set; }
<<<<<<< HEAD

        public string Sifra { get; set; }
=======
        [DataMember]
        public int Sifra { get; set; }
>>>>>>> 0ef284351df4a79a14c4edaa229fe0ef7a36aa5d

        public GeografskaOblast(string ime, string sifra)
        {
            Ime = ime;
            Sifra = sifra;
        }

        public GeografskaOblast() { }

        public override string ToString()
        {
            return $"{Ime},{Sifra}";
        }
    }
}
