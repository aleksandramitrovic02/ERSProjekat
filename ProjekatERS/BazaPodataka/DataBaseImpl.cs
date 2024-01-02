using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comon.Model;

namespace BazaPodataka
{
    public class DataBaseImpl:IDataBase
    {


        private static SqlConnection connection;
        private static string connectionString;
        private static DataBaseImpl instance=null;



       public static DataBaseImpl getBase()
        {
            if(instance == null)
            {
                instance= new DataBaseImpl();
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



       






    }
}
