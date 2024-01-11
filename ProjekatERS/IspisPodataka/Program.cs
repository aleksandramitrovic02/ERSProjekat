using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IspisPodataka
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IIspis> channel = new ChannelFactory<IIspis>("Servis");
            IIspis proxy = channel.CreateChannel();
            

        }

        void meni(IIspis proxy)
        {
            while (true)
            {
                Console.WriteLine("1.Racunanje odstupanja.");
                Console.WriteLine("2.Izlaz.");
                int unos = Int32.Parse(Console.ReadLine());

                switch (unos)
                {
                    case 1:
                        {
                            UnesiDatumGeo(proxy);
                            break;
                        }
                    case 2: { return; }
                    default: { break; }
                }
            }

        }

        public static void UnesiDatumGeo(IIspis proxy)
        {
            DateTime datum;
            string geo;

            Console.WriteLine("Unesite datum u formatu godina,mesec,dan,sat,minuta,sekunda");
            string unos = Console.ReadLine();

            string[] parts = unos.Split(',');
            datum = new DateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]), Convert.ToInt32(parts[4]), Convert.ToInt32(parts[5]));
            Console.WriteLine("Unesite geografsku oblast");
            geo = Console.ReadLine();

            PrikaziOdstupanja(datum, geo, proxy);
        }

        public static void PrikaziOdstupanja(DateTime datum, string geo, IIspis proxy)
        {
            List<List<Potrosnja>> lista = proxy.Izracunaj(datum, geo);


            List<Potrosnja> izracunato = new List<Potrosnja>();


            for (int i = 0; i < lista[0].Count; i++)
            {
                Potrosnja p = new Potrosnja();

                float odstupanje = (Math.Abs(lista[0][i].OstvarenaP - lista[1][i].PrognoziranaP) / lista[0][i].OstvarenaP) * 100.0f;

                p.PrognoziranaP = lista[1][i].PrognoziranaP;
                p.OstvarenaP = lista[0][i].OstvarenaP;
                p.Odstupanje = odstupanje;
                p.GeografskaOblast = lista[1][i].GeografskaOblast;
                p.Sat = lista[1][i].Sat;
                p.Datum = lista[0][i].Datum;
                izracunato.Add(p);

            }


            foreach (var item in izracunato)
            {
                Console.WriteLine(item);
            }
        }
    }
}

