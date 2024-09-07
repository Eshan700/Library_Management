using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Library_Management
{
    class Database
    {
        MySqlConnection con;
       
       
        public static MySqlConnection ConnectDB()
        {
            try
            {
              String constring = "server=localhost;uid=root;pwd=password;database=library;SslMode=none";
                MySqlConnection connection = new MySqlConnection(constring);
                return connection;
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
       
    }
}
