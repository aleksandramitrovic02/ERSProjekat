using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaPodrucja
{
    public class Meni
    {
        IGeo Proxy {  get; set; }
        

        public Meni(IGeo proxy)
        {
            Proxy=proxy;
        }


            public void meni()
            {
                while (true)
                {
                    Console.WriteLine("1.Izlistati geografske oblasti.");
                    Console.WriteLine("2.Ubaciti geografsku oblast");
                    int unos = Int32.Parse(Console.ReadLine());

                    switch (unos)
                    {
                        case 1:
                            {
                            IzlistajOblasti();
                                break;
                            }
                        case 2: { return; }
                        default: { break; }
                    }
                }
            }


            void IzlistajOblasti()
            {
            List<GeografskaOblast> lista = Proxy.evidencija();

            Console.WriteLine("*********Evidencija geografskih oblasti*********");
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }


        void Unos()
        {
            //unos svihpodataka za geo oblast
            GeografskaOblast geo=new GeografskaOblast();

            Console.WriteLine("Unesite sifru geografske oblasti: ");
           geo.Sifra= Console.ReadLine();


            Console.WriteLine("Unesite ime geografske oblasti: ");
            geo.Ime=Console.ReadLine();


            //
            Proxy.ubaci(geo);

        }
        
    }
}

