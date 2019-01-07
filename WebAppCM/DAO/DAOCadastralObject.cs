using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebAppCM.Models;

namespace WebAppCM.DAO
{
    public class DAOCadastralObject : DAO
    {
        public List<CadastralObject> GetAllCO()
        {
            Connect();
            List<CadastralObject> coList = new List<CadastralObject>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT CadastralObject.Id, HandBookOfCOTypes.tHCOname, CadastralObject.cadastralNumber, CadastralObject.dateOfEntry, " +
"CadastralObject.dateOfEntry, CadastralObject.legalStatus, CadastralObject.address, CadastralObject.square, "+
"CadastralObject.cost FROM HandBookOfCOTypes INNER JOIN CadastralObject ON "+
"HandBookOfCOTypes.Id = CadastralObject.fk_tipeCO", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CadastralObject co = new CadastralObject();
                    co.Id = Convert.ToInt32(reader["Id"]);
                    co.type = Convert.ToString(reader["tHCOname"]);
                    co.cadastralNumber = Convert.ToString(reader["cadastralNumber"]);
                    co.dateOfEntry = Convert.ToDateTime(reader["dateOfEntry"]);
                    co.legalStatus = Convert.ToString(reader["legalStatus"]);
                    co.address = Convert.ToString(reader["address"]);
                    co.square = Convert.ToDouble(reader["square"]);
                    co.cost = Convert.ToDecimal(reader["cost"]);
                    coList.Add(co);
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
            return coList;
        }
    }
}