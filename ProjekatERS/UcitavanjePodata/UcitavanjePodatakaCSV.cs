using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UcitavanjePodata
{
    public class UcitavanjePodatakaCSV : UcitavanjeFajlova
    {
        public UcitavanjePodatakaCSV(IEvidencija proxy)
        {
            Proxy = proxy;
        }
        public override void ObradaIspravnihPodataka(string putanja, string tipFajla, DateTime datum)
        {
            string[] linije = File.ReadAllLines(putanja);


            for (int i = 1; i < linije.Length; i++)
            {

                string[] delovi = linije[i].Split(',');

                if (delovi.Length != 3)
                {

                    continue;
                }

                int sat;
                float potrosnja;

                if (!int.TryParse(delovi[0], out sat) || !float.TryParse(delovi[1], out potrosnja))
                {

                    continue;
                }

                List<string> lista = Proxy.GeoPodr();
                if (!lista.Contains(delovi[2]))
                {
                    GeografskaOblast geo = new GeografskaOblast();
                    geo.Sifra = delovi[2];
                    geo.Ime = delovi[2];
                    Proxy.upisiOblast(geo);
                }

                string geografskaOblast = delovi[2];

                float prognoziranaP = 0;
                float ostvarenaP = 0;

                if (tipFajla == "prog")
                {
                    prognoziranaP = potrosnja;
                }
                else if (tipFajla == "ostv")
                {
                    ostvarenaP = potrosnja;
                }

                Potrosnja novaPotrosnja = new Potrosnja(datum, geografskaOblast, sat, prognoziranaP, ostvarenaP, 0);
                Console.WriteLine(novaPotrosnja);

                UpisivanjePotrosnjeUBazu(novaPotrosnja);
            }
        }

        public override bool PrebacitiUValidanSadrzaj(string putanja, out int brojRedova)
        {
            XDocument xmlDokument = XDocument.Load(putanja);
            brojRedova = 0;
            bool povratna = true;

            var sveOblasti = xmlDokument.Descendants("OBLAST").Select(o => o.Value).Distinct().ToList();

            foreach (var oblast in sveOblasti)
            {

                var redoviZaOblast = xmlDokument.Descendants("STAVKA").Where(s => s.Element("OBLAST").Value == oblast).ToList();
                brojRedova += redoviZaOblast.Count();
                if (redoviZaOblast.Count != 24 && redoviZaOblast.Count != 23 && redoviZaOblast.Count != 25)
                {

                    povratna = false;
                }


            }

            return povratna;
        }


        public override void ProlazakKrozFajlove(string putanja)
        {
            Console.WriteLine($"Obrada CSV fajla na putanji: {putanja}");
            string imeFajla = Path.GetFileNameWithoutExtension(putanja);
            string tipFajla;
            DateTime datum;

            if (!ProveraImenaFajla(imeFajla, out tipFajla, out datum))
            {
                return;
            }

            Console.WriteLine($"Tip Fajla: {tipFajla}, Datum: {datum}");
            int brojRedova = 0;

            if (!PrebacitiUValidanSadrzaj(putanja, out brojRedova))
            {
                Console.WriteLine($"Nevalidan sadržaj CSV fajla: {imeFajla}");
                ProveraNevalidnihFajlova(imeFajla, putanja, brojRedova);
                return;
            }

            ObradaIspravnihPodataka(putanja, tipFajla, datum);
        }


    }
}

