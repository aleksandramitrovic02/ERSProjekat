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




            MeniHandler m = new MeniHandler(proxy);
            m.meni();
            


            Console.ReadLine();
            
        }

      


    }
}
