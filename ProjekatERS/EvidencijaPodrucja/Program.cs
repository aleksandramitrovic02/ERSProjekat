using Comon;
<<<<<<< HEAD
using Comon.Model;
=======
>>>>>>> 0ef284351df4a79a14c4edaa229fe0ef7a36aa5d
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

<<<<<<< HEAD


            Meni meni = new Meni(proxy);
            meni.meni();

            Console.ReadLine();
=======
            /*Meni meni = new Meni(proxy);
            meni.meni();*/

            Console.ReadLine();
            
>>>>>>> 0ef284351df4a79a14c4edaa229fe0ef7a36aa5d
        }
    }
}
