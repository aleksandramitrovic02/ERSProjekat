using BazaPodataka;
using Comon.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestiranjeBaze
{
    [TestFixture]
    public class TestBaze
    {
        private DataBaseImpl dataBase;

        [SetUp]
        public void SetUp()
        {


            var dataBaseI = new Mock<DataBaseImpl>();
            dataBase = dataBaseI.Object;



        }


        [Test]
        public void TestGenerisiPodatke()
        {

            dataBase.DeleteAllAudit();
           
            Audit a1 = new Audit(new DateTime(2022, 10, 10), "prvi", "kk", 10);
            Audit a2 = new Audit(new DateTime(2021, 8, 9), "drugi", "ka", 9);
          

            dataBase.InsertAudit(a1);
            dataBase.InsertAudit(a2);

            //    dataBase.DeleteAudit();


            List<Audit> audits = new List<Audit>();
            audits = dataBase.GetAudit();
            Assert.That(audits.Count==2, Is.True, "The result should be true");

            

           
            
        }
        [Test]
        public void TestGeo()
        {
            dataBase.DeleteAllGeografskaOblast();
            GeografskaOblast g1 = new GeografskaOblast("geo", "123s");
            GeografskaOblast g2 = new GeografskaOblast("go", "123");

            dataBase.InsertGeorafskaOblast(g1);
            dataBase.InsertGeorafskaOblast(g2);

            //dataBase.DeleteAllGeografskaOblast();
            //dataBase.DeleteAllGeografskaOblast();

            List<GeografskaOblast> geos = dataBase.GetGeografskaOblast();
            Assert.That(geos.Count == 2, Is.True, "The result shold be true");

           
        }
        [Test]
       public void TestPotrosnja()
        {
            dataBase.DeleteAllPotrosnja();

            Potrosnja p1 = new Potrosnja(new DateTime(2022, 10, 19), "geo", 12, 2.0f, 10.0f, 8.0f);
            dataBase.InsertPotrosnja(p1);

            List<Potrosnja> po = dataBase.GetPotrosnja();
            Assert.That(po.Count == 1, Is.True, "The result shold be true");
        }

    }
}
