using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Helper
{
    public class Util
    {
        public MySqlConnection SetupConnection()
        {
            try
            {
                //MYSQL
                MySqlConnection conn;
                string myConnectionString = "server=localhost;uid=tester;" + "pwd=tester;database=testDB";
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;

                return conn;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

                return new MySqlConnection();
            }
        }
    }
}
