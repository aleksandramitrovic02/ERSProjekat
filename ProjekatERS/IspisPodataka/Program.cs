using Comon;
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
    }
}
