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
    internal class Programs
    {
        static void Main(string[] args)
        {
            ChannelFactory<IGeo> channel = new ChannelFactory<IGeo>("Server");
            IGeo proxy = channel.CreateChannel();



            Meni meni = new Meni(proxy);
            meni.meni();

            Console.ReadLine();
        }
    }
}
