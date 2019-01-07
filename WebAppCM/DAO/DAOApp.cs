using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebAppCM.Models;

namespace WebAppCM.DAO
{
    public class DAOApp : DAO
    {
        private CMEntities db = new CMEntities();
        public List<Application> GetAllApp()
        {
            Connect();
            List<Application> appList = new List<Application>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT Application.Id, surnameName, name, date, tHCOname, tCWname, description, sName "+ 
"FROM Status INNER JOIN ((HandBookOfCOTypes INNER JOIN CadastralObject ON HandBookOfCOTypes.Id = CadastralObject.fk_tipeCO) INNER JOIN (TypeCW INNER JOIN ([User] INNER JOIN Application ON [User].Id = Application.fk_customer) ON TypeCW.Id = Application.fk_typeCW) ON CadastralObject.Id = Application.fk_cadastralObject) ON Status.Id = Application.fk_status", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Application app = new Application();
                    app.Id = Convert.ToInt32(reader["Id"]);
                    app.customerFI = Convert.ToString(reader["surnameName"]);
                    app.customerFI = app.customerFI+ " " +Convert.ToString(reader["name"]);
                    app.date = Convert.ToDateTime(reader["date"]);
                    app.cadastralObject = Convert.ToString(reader["tHCOname"]);
                    app.typeCW = Convert.ToString(reader["tCWname"]);
                    app.description = Convert.ToString(reader["description"]);
                    app.status = Convert.ToString(reader["sName"]);
                    appList.Add(app);
                }
                reader.Close();
            }
            catch (SqlException ex) // поймать исключение по соединению
            {
                Console.WriteLine("Ошибка при установлении соединения: ", ex.Message);
                Console.ReadKey();
            }
            finally
            {
                Disconnect();
            }
            return appList;
        }
    }
}