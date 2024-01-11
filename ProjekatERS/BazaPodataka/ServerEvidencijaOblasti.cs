using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public class ServerEvidencijaOblasti : IEvidencijaOblasti
    {
        DataBaseImpl baza = DataBaseImpl.getBase();
        public List<GeografskaOblast> evidencija(string Ime, int Sifra)
        {
            return baza.GetGeografskaOblast();
        }
    }
}
