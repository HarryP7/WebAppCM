using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppCM.DAO
{
    public class DAO
    {
        private const string ConnectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=Cadastral_Management;" +
            "Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        public SqlConnection Connection { get; set; }
        public void Connect()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        public void Disconnect()
        {
            Connection.Close();
        }
    }
}