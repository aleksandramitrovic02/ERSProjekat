using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Comon.Model
{
   
    public class GeografskaOblast
    {
        public String Ime { get; set; }

        public string Sifra { get; set; }

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
