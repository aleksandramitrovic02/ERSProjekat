using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public class Server : IEvidencija
    {
        public static DataBaseImpl Baza = DataBaseImpl.getBase();
        public void Audit(Audit a)
        {
            Baza.InsertAudit(a);
        }

        public List<string> GeoPodr()
        {
            List<GeografskaOblast> lista = Baza.GetGeografskaOblast();
            List<string> povratna = new List<string>();
            foreach(var item in lista)
            {
                if (!povratna.Contains(item.Sifra))
                {
                    povratna.Add(item.Sifra);
                }
            }
            return povratna;
        }

        public void PrognoziranaIPotrosena(Potrosnja p)
        {
            Baza.InsertPotrosnja(p);
        }

        public void upisiOblast(GeografskaOblast geo)
        {
            Baza.InsertGeorafskaOblast(geo);
        }
    }
}
