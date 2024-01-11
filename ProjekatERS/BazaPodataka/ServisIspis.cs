using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public class ServisIspis : IIspis
    {
        DataBaseImpl baza = DataBaseImpl.getBase();
        public List<List<Potrosnja>> Izracunaj(DateTime datum, string GeoPodrucje)
        {
            List<Potrosnja> ostvarene = baza.OstvGeoPodrucje(datum, GeoPodrucje);
            List<Potrosnja> prognozirne = baza.ProgGeoPodrucje(datum, GeoPodrucje);

            List<List<Potrosnja>> povratna = new List<List<Potrosnja>>();
            povratna.Add(ostvarene);
            povratna.Add(prognozirne);


            return povratna;
        }
    }
}
