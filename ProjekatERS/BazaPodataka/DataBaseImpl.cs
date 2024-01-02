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
                connectionString = "Server=localhost;Database=Projekat;Trusted_Connection=True;";
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



    }
}



       






    

