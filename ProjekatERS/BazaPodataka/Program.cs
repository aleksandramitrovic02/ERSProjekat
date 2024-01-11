using Comon;
using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace BazaPodataka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DataBaseImpl baza=DataBaseImpl.getBase();

            //Audit a = new Audit(new DateTime(2022,10,10),"akjhsd","ashjdkk",10);

            /* using (ServiceHost host = new ServiceHost(typeof(Server)))
             {
                 host.Open();
                 Console.WriteLine("Servis je uspesno pokrenut");
                 Console.ReadKey();
             }*/

            ServiceHost host = new ServiceHost(typeof(Server));

            host.AddServiceEndpoint(typeof(IEvidencija),
                 new NetTcpBinding(),
               new Uri("net.tcp://localhost:4000/IEvidencija"));
            host.Open();
            Console.WriteLine("Servis1 je uspesno pokrenut");


            ServiceHost host1 = new ServiceHost(typeof(ServisIspis));

            host1.AddServiceEndpoint(typeof(IIspis),
             new NetTcpBinding(),
           new Uri("net.tcp://localhost:4001/IIspis"));

            host1.Open();
            Console.WriteLine("Servis2 je uspesno pokrenut");
            Console.ReadKey();

            ServiceHost host2 = new ServiceHost(typeof(ServerEvidencijaOblasti));

            host2.AddServiceEndpoint(typeof(IEvidencijaOblasti),
             new NetTcpBinding(),
           new Uri("net.tcp://localhost:4001/IEvidencijaOblasti"));

            host2.Open();
            Console.WriteLine("Servis3 je uspesno pokrenut");
            Console.ReadKey();


            Console.Read();


          

        }
    }
}
