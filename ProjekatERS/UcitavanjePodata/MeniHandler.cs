using Comon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcitavanjePodata
{
    public class MeniHandler
    {
        public static UcitavanjePodatakaCSV obradaCsv;
        public static UcitavanjeFajlovaTXT obradaTxt;
        public static UcitavanjePodatakaXML obradaXML;

        public MeniHandler(IEvidencija proxy)
        {
            obradaCsv = new UcitavanjePodatakaCSV(proxy);
            obradaTxt = new UcitavanjeFajlovaTXT(proxy);
            obradaXML = new UcitavanjePodatakaXML(proxy);
        }
        public void meni()
        {
            while (true)
            {


                Console.WriteLine("Izaberite opciju:");
                Console.WriteLine("1. Unos putanje za učitavanje");
                Console.WriteLine("2. Izlaz");
                Console.Write("\nVaš izbor: ");


                string unos = Console.ReadLine();


                switch (unos)
                {
                    case "1":
                        UnosPutanje();
                        break;
                    case "2":
                        Console.WriteLine("Izlazak iz aplikacije.");
                        return;
                    default:
                        Console.WriteLine("Neispravan unos. Molimo izaberite ponovo.");
                        break;
                }


                Console.WriteLine("\nPritisnite bilo koju tipku za povratak na glavni meni.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void UnosPutanje()
        {
            Console.Write("Unesite putanju do foldera sa fajlovima za učitavanje: ");
            string putanjaDoFoldera = Console.ReadLine();


            if (!Directory.Exists(putanjaDoFoldera))
            {
                Console.WriteLine("Unesena putanja ne postoji!");
                return;
            }


            ObradiFajloveIzFoldera(putanjaDoFoldera);
        }
        static void ObradiFajloveIzFoldera(string folderPutanja)
        {

            string[] fajlovi = Directory.GetFiles(folderPutanja);


            foreach (string fajl in fajlovi)
            {
                string ekstenzija = Path.GetExtension(fajl).ToLower();


                switch (ekstenzija)
                {
                    case ".xml":
                        obradaXML.ProlazakKrozFajlove(fajl);
                        break;
                    case ".csv":
                        obradaCsv.ProlazakKrozFajlove(fajl);
                        break;
                    case ".txt":
                        obradaTxt.ProlazakKrozFajlove(fajl);
                        break;
                    default:
                        Console.WriteLine($"Nepodržana ekstenzija fajla: {ekstenzija}");
                        break;
                }
            }
        }
    }
}
