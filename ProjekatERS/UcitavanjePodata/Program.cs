using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UcitavanjePodata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IEvidencija> channel = new ChannelFactory<IEvidencija>("ServiceName");

            IEvidencija proxy = channel.CreateChannel();
            /*

            Audit a = new Audit(new DateTime(2022, 10, 10), "ahsdjkas1", "jkhakjshdjkhkahsd", 25);
            Audit a1 = new Audit(new DateTime(2022, 11, 10), "ahsdjkas2", "jkhakjshdjkhkahsd", 25);
            Audit a2 = new Audit(new DateTime(2022, 12, 10), "ahsdjkas3", "jkhakjshdjkhkahsd", 25);

            proxy.Audit(a);
            proxy.Audit(a1);
            proxy.Audit(a2);


            Potrosnja p = new Potrosnja(new DateTime(2022, 10, 10), "GEO", new DateTime(2022, 10, 10), 10.0, 20.0, 10);

            proxy.PrognoziranaIPotrosena(p);

            */
            Console.ReadLine();
            
        }

      


    }
}
