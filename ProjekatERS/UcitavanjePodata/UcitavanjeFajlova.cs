﻿using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcitavanjePodata
{
    public abstract class UcitavanjeFajlova
    {
        public IEvidencija Proxy;
        public abstract void ProlazakKrozFajlove(string putanja);
        public bool ProveraImenaFajla(string imeFajla, out string tipFajla, out DateTime datum)
        {
            tipFajla = "";
            datum = DateTime.MinValue;

            string[] deloviImena = imeFajla.Split('_');

            if (deloviImena.Length != 4)
            {
                Console.WriteLine($"Fajl nije validnog formata: {imeFajla}");
                return false;
            }

            tipFajla = deloviImena[0];

            string datumString = $"{deloviImena[1]}_{deloviImena[2]}_{deloviImena[3]}";

            if (!DateTime.TryParseExact(datumString, "yyyy_MM_dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out datum))
            {
                Console.WriteLine($"Nevalidan format datuma: {datumString}");
                return false;
            }

            return true;
        }
        public abstract bool PrebacitiUValidanSadrzaj(string putanja, out int brojRedova);
        public abstract void ObradaIspravnihPodataka(string putanja, string tipFajla, DateTime datum);
        public void ProveraNevalidnihFajlova(string imeFajla, string putanja, int brojRedova)
        {
            DateTime vremeUcitavanja = DateTime.Now;


            Audit auditZapis = new Audit(vremeUcitavanja, imeFajla, putanja, brojRedova);


            Console.WriteLine($"Nevalidan fajl: {imeFajla}, Lokacija: {putanja}, Broj redova: {brojRedova}");
            UpisivanjeAuditaUBazu(auditZapis);
        }
        public  void UpisivanjePotrosnjeUBazu(Potrosnja potrosnja)
        {
            Proxy.PrognoziranaIPotrosena(potrosnja);
        }
        public  void UpisivanjeAuditaUBazu(Audit audit)
        {
            Proxy.Audit(audit);
        }
    }
}
