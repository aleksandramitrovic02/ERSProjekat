using BazaPodataka;
using Comon.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testiranje
{
    [TestFixture]
    public class Test
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
            Audit a1= new Audit(new DateTime(2022, 10, 10), "prvi", "ashjdkk", 10);
            Audit a2 = new Audit(new DateTime(2021, 8, 9), "drugi", "ashdkk", 9);

            dataBase.InsertAudit(a1);
            dataBase.InsertAudit(a2);

            
            List<Audit> audits = dataBase.GetAudit();
            Assert.That(audits, Is.True, "The result should be true");
            


        }

        [Test]
        void stagod()
        {

        }
    }
}
