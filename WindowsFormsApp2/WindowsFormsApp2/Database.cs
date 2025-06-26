using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Database
    {
        MySqlConnection conenection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;pasword=;database=test");


        public void openConnection()
        {
            if (conenection.State == System.Data.ConnectionState.Closed) 
                conenection.Open();
        }
        public void closeConnection()
        {
            if (conenection.State == System.Data.ConnectionState.Open)
                conenection.Close();
        }
        public MySqlConnection GetConnection() {  return conenection; }
            
    }
}
