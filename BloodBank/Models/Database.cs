using System;
using MySql.Data.MySqlClient;
using BloodBankApp.Models;

namespace BloodBankApp.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
