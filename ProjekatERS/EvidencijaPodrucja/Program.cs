using Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaPodrucja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IEvidencijaOblasti> channel = new ChannelFactory<IEvidencijaOblasti>("Server");
            IEvidencijaOblasti proxy = channel.CreateChannel();

            
        }
    }
}
