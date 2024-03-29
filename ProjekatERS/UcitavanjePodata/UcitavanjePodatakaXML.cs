﻿using Comon;
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
    public class UcitavanjePodatakaXML : UcitavanjeFajlova
    {
        public UcitavanjePodatakaXML(IEvidencija proxy)
        {
            Proxy = proxy;
        }
        public override void ObradaIspravnihPodataka(string putanja, string tipFajla, DateTime datum)
        {
            XDocument xmlDokument = XDocument.Load(putanja);
            var sviRedovi = xmlDokument.Descendants("STAVKA").ToList();

            foreach (var red in sviRedovi)
            {
                int sat = int.Parse(red.Element("SAT").Value);
                float potrosnja = float.Parse(red.Element("LOAD").Value);
                string geografskaOblast = red.Element("OBLAST").Value;

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
                List<string> lista = Proxy.GeoPodr();
                if (!lista.Contains(geografskaOblast))
                {
                    GeografskaOblast geo = new GeografskaOblast();
                    geo.Sifra = geografskaOblast;
                    geo.Ime = geografskaOblast;
                    Proxy.upisiOblast(geo);
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
        Console.WriteLine($"Obrada XML fajla na putanji: {putanja}");
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
            Console.WriteLine($"Nevalidan sadržaj XML fajla: {imeFajla}");
            ProveraNevalidnihFajlova(imeFajla, putanja, brojRedova);
            return;
        }

        ObradaIspravnihPodataka(putanja, tipFajla, datum);
    }

    }
}
