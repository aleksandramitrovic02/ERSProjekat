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
        [DataMember]
        public int Sifra { get; set; }

        public GeografskaOblast(string ime, int sifra)
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
