using System;
using System.Data.SQLite;
using System.IO;

namespace CampusManagementSystem2
{
    public class DatabaseHelper
    {
        private string connectionString =
            @"Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "campus.db") + ";Version=3;BusyTimeout=5000;";

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}