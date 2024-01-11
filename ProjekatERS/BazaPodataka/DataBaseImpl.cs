using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comon.Model;

namespace BazaPodataka
{
    public class DataBaseImpl : IDataBase
    {


        private static SqlConnection connection;
        private static string connectionString;
        private static DataBaseImpl instance = null;



        public static DataBaseImpl getBase()
        {
            if (instance == null)
            {
                instance = new DataBaseImpl();
            }
            return instance;
        }


        public DataBaseImpl()
        {

            try
            {
                connectionString = "Server=localhost;Database=ERS;Trusted_Connection=True;";
                connection = new SqlConnection(connectionString);
                connection.Open();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void InsertAudit(Audit audit)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO Audit(ImeFajla, VremeUcitavanja, Lokacija, BrojRedova) VALUES(@ImeFajla, @VremeUcitavanja, @Lokacija, @BrojRedova)";

                command.Parameters.AddWithValue("@ImeFajla", audit.ImeFajla);
                command.Parameters.AddWithValue("@VremeUcitavanja", audit.VremeUcitavanja);
                command.Parameters.AddWithValue("@Lokacija", audit.Lokacija);
                command.Parameters.AddWithValue("@BrojRedova", audit.BrojRedova);


                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }


        }


        public void UpdateAudit(Audit audit)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE audit SET ImeFajla=@ImeFajla,VremeUcitavanja=@VremeUcitavanja,Lokacija=@Lokacija,BrojRedova=@BrojRedova WHERE ImeFajla = @ImeFajla";
                command.Parameters.AddWithValue("@ImeFajla", audit.ImeFajla);
                command.Parameters.AddWithValue("@VremeUcitavanja", audit.VremeUcitavanja);
                command.Parameters.AddWithValue("@Lokacija", audit.Lokacija);
                command.Parameters.AddWithValue("@BrojRedova", audit.BrojRedova);

                command.ExecuteNonQuery();
            }
        }
        public void DeleteAudit(string ImeFajla)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM audit WHERE ImeFajla = @ImeFajla";
                command.Parameters.AddWithValue("@ImeFajla", ImeFajla);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAllAudit()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM audit";
                command.ExecuteNonQuery();
            }
        }
        public List<Audit> GetAudit()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Audit> audits = new List<Audit>();
                command.Connection = connection;
                command.CommandText = "SELECT all FROM audit";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Audit audit = new Audit(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                        audits.Add(audit);
                    }
                    return audits;
                }

            }

        }

        public void InsertGeorafskaOblast(GeografskaOblast GOblast)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO GeografskaOblast(sifra,ime) VALUES(@sifra, @ime)";

                command.Parameters.AddWithValue("@sifra", GOblast.Sifra);
                command.Parameters.AddWithValue("@ime", GOblast.Ime);
               

                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }


        }

        public void UpdateGeografskaOblast(GeografskaOblast GOblast)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE audit SET sifra=@sifra,ime=@ime WHERE sifra = @sifra";
                command.Parameters.AddWithValue("@sifra", GOblast.Sifra);
                command.Parameters.AddWithValue("@ime", GOblast.Ime);
                

                command.ExecuteNonQuery();
            }
        }

        public void DeleteGeografskaOblast(int sifra)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM GeografskaOblast WHERE sifra = @sifra";
                command.Parameters.AddWithValue("@sifra", sifra);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAllGeografskaOblast()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM GeografskaOblast";
                command.ExecuteNonQuery();
            }
        }

        public List<GeografskaOblast> GetGeografskaOblast()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<GeografskaOblast> oblasti = new List<GeografskaOblast>();
                command.Connection = connection;
                command.CommandText = "SELECT all FROM GeografskaOblast";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GeografskaOblast GOblast = new GeografskaOblast(reader.GetString(0), reader.GetInt32(1));
                        oblasti.Add(GOblast);
                    }
                    return oblasti;
                }  

            }
           

        }




        public void InsertPotrosnja(Potrosnja potrosnja)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO Potrosnja1(GeografskaOblast,Datum,Sat,PrognoziranaPotrosnja, OstvarenaPotrosnja, Odstupanja) VALUES(@GeografskaOblast, @Datum, @Sat, @PrognoziranaPotrosnja, @OstvarenaPotrosnja, @Odstupanja)";

                Console.WriteLine($"{potrosnja.Datum}  ${potrosnja.Sat}");
                command.Parameters.AddWithValue("@GeografskaOblast", potrosnja.GeografskaOblast);
                command.Parameters.AddWithValue("@Datum", potrosnja.Datum);
                command.Parameters.AddWithValue("@Sat", potrosnja.Sat);
                command.Parameters.AddWithValue("@PrognoziranaPotrosnja", potrosnja.PrognoziranaP);
                command.Parameters.AddWithValue("@OstvarenaPotrosnja", potrosnja.OstvarenaP);
                command.Parameters.AddWithValue("@Odstupanja", potrosnja.Odstupanje);




                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }


        }

        public void UpdatePotrosnja(Potrosnja potrosnja)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE potrosnja1 SET GeografskaOblast=@GeografskaOblast,Datum=@Datum, Sat=@Sat, PrognoziranaP=@PrognoziranaP, OstvarenaP=@OstvarenaP, Odstupanje=@Odstupanje WHERE GeografskaOblast = @GeografskaOblast";
                command.Parameters.AddWithValue("@GeografskaOblast", potrosnja.GeografskaOblast);
                command.Parameters.AddWithValue("@Datum", potrosnja.Datum);
                command.Parameters.AddWithValue("@Sat", potrosnja.Sat);
                command.Parameters.AddWithValue("@PrognoziranaP", potrosnja.PrognoziranaP);
                command.Parameters.AddWithValue("@OstvarenaP", potrosnja.OstvarenaP);
                command.Parameters.AddWithValue("@Odstupanje", potrosnja.Odstupanje);


                command.ExecuteNonQuery();
            }
        }

        public void DeletePotrosnja(string GeografskaOblast)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM Potrosnja1 WHERE GeografskaOblast = @GeografskaOblast";
                command.Parameters.AddWithValue("@GeografskaOblast", GeografskaOblast);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAllPotrosnja()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM Potrosnja1";
                command.ExecuteNonQuery();
            }
        }
        public List<Potrosnja> GetPotrosnja()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Potrosnja> potrosnje = new List<Potrosnja>();
                command.Connection = connection;
                command.CommandText = "SELECT all FROM Potrosnja1";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Potrosnja potrosnja = new Potrosnja(reader.GetDateTime(0), reader.GetString(1), reader.GetInt32(2), reader.GetFloat(3), reader.GetFloat(4), reader.GetFloat(5));
                        potrosnje.Add(potrosnja);
                    }
                    return potrosnje;
                }

            }


        }

        public List<Potrosnja> ProgGeoPodrucje(DateTime datum, string geoOblast)
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Potrosnja> potrosnje = new List<Potrosnja>();
                command.Connection = connection;
                command.CommandText = "SELECT Sat, PrognoziranaP FROM Potrosnja where Datum = @datum and GeografskaOblast = @GeografskaOblast and OstvarenaP = 0";
                command.Parameters.AddWithValue("@datum", datum);
                command.Parameters.AddWithValue("@GeografskaOblast", geoOblast);

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        int Sat = reader.GetInt32(0);
                        float PrognoziranaP = (float)reader.GetDouble(1);

                        Potrosnja p = new Potrosnja();
                        p.Sat = Sat;
                        p.PrognoziranaP = PrognoziranaP;
                        p.GeografskaOblast = geoOblast;
                        p.Datum = datum;
                        p.OstvarenaP = 0;
                        p.Odstupanje = 0;
                        potrosnje.Add(p);
                    }
                    return potrosnje;
                }

            }
        }

        public List<Potrosnja> OstvGeoPodrucje(DateTime datum, string geoOblast)
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Potrosnja> potrosnje = new List<Potrosnja>();
                command.Connection = connection;
                command.CommandText = "SELECT Sat, OstvarenaP FROM Potrosnja where Datum = @datum and GeografskaOblast = @GeografskaOblast and PrognoziranaP = 0";
                command.Parameters.AddWithValue("@datum", datum);
                command.Parameters.AddWithValue("@GeografskaOblast", geoOblast);

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        int Sat = reader.GetInt32(0);
                        float OstvarenaP = (float)reader.GetDouble(1);

                        Potrosnja p = new Potrosnja();
                        p.Sat = Sat;
                        p.OstvarenaP = OstvarenaP;
                        p.GeografskaOblast = geoOblast;
                        p.Datum = datum;
                        p.PrognoziranaP = 0;
                        p.Odstupanje = 0;
                        potrosnje.Add(p);
                    }
                    return potrosnje;
                }

            }
        }

        public List<GeografskaOblast> evidencijaGeoPodrucja(string Ime, int Sirina)
        {
            using (SqlCommand command = new SqlCommand())
            {
                List<GeografskaOblast> oblasti = new List<GeografskaOblast>();
                command.Connection = connection;
                command.CommandText = "SELECT all FROM GeografskaOblast";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GeografskaOblast Oblast = new GeografskaOblast(reader.GetString(0), reader.GetInt32(1));
                        oblasti.Add(Oblast);
                    }
                    return oblasti;
                }

            }
        }



    }
}



       






    

