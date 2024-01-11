using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace BazaPodataka
{
    internal class Program
    {
        static void Main(string[] args)
        {
  //          < system.serviceModel >

  //      < services >
  //  < service name = "BazaPodataka.Server" >
  //    < endpoint address = "IEvidencija" binding = "netTcpBinding" contract = "Comon.IEvidencija" />
  //    < host >
  //      < baseAddresses >
  //        < add baseAddress = "net.tcp://localhost:4000" />
  //      </ baseAddresses >
  //    </ host >
  //  </ service >
  //</ services >

  //  </ system.serviceModel >

            ServiceHost host = new ServiceHost(typeof(Server));

            host.AddServiceEndpoint(typeof(IEvidencija),
                 new NetTcpBinding(),
               new Uri("net.tcp://localhost:4000/IEvidencija"));
            host.Open();
            Console.WriteLine("Servis1 je uspesno pokrenut");


            ServiceHost host1 = new ServiceHost(typeof(ServisIspis));

            host1.AddServiceEndpoint(typeof(Comon.IIspis),
             new NetTcpBinding(),
           new Uri("net.tcp://localhost:4001/IIspis"));

            host1.Open();
            Console.WriteLine("Servis2 je uspesno pokrenut");

            ServiceHost host2 = new ServiceHost(typeof(ServisObl));

            host2.AddServiceEndpoint(typeof(IGeo),
             new NetTcpBinding(),
<<<<<<< HEAD
           new Uri("net.tcp://localhost:4002/IGeo"));

            host2.Open();
            Console.WriteLine("Servis3 je uspesno pokrenut");

        
=======
           new Uri("net.tcp://localhost:4002/IEvidencijaOblasti"));

            host2.Open();
            Console.WriteLine("Servis3 je uspesno pokrenut");
            Console.ReadKey();

>>>>>>> 0ef284351df4a79a14c4edaa229fe0ef7a36aa5d

            Console.Read();


          

        }
    }
}
