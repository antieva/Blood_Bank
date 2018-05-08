using System;
using MySql.Data.MySqlClient;
using BloodBank.Models;

namespace BloodBank.Models
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
