using Comon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    internal class Program
    {
        static void Main(string[] args)
        {
           DataBaseImpl baza=DataBaseImpl.getBase();

            Audit a = new Audit(new DateTime(2022,10,10),"akjhsd","ashjdkk",10);



            Console.Read();

        }
    }
}
