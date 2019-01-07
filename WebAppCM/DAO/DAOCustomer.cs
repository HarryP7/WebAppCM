using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppCM.Models;

namespace WebAppCM.DAO
{
    public class DAOCustomer : DAO
    {
        public List<Customer> GetAllCustomers()
        {
            Connect();
            List<Customer> csList = new List<Customer>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Customer", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer cs = new Customer();
                    cs.Idc = Convert.ToInt32(reader["Id"]);
                    cs.placeWork = Convert.ToString(reader["placeWork"]);
                    cs.applications = Convert.ToString(reader["applications"]);
                    csList.Add(cs);
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
            return csList;
        }
        public bool AddCustomer(Customer records)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Customer (Id, placeWork, applications) " +
                                                "VALUES (@Id, @placeWork, @applications)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Title", records.Idc));
                cmd.Parameters.Add(new SqlParameter("@Text", records.placeWork));
                cmd.Parameters.Add(new SqlParameter("@ArticleRating", records.applications));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
        //public Customer DetailsCustomer(int idn)
        //{
        //    Connect();
        //    Customer record = new Customer();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM Knowledge WHERE ID=@idn", Connection);
        //        cmd.Parameters.Add(new SqlParameter("@idn", idn));
        //        cmd.ExecuteNonQuery();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            record.ID = Convert.ToInt32(reader["Id"]);
        //            record.TITLE = Convert.ToString(reader["Title"]);
        //            record.TEXT = Convert.ToString(reader["Text"]);
        //            record.ARTICLERATING = Convert.ToInt32(reader["ArticleRating"]);
        //            record.AUTHOR = Convert.ToString(reader["Author"]);
        //            record.DATE = Convert.ToDateTime(reader["Date"]);

        //        }
        //        reader.Close();
        //    }
        //    catch (SqlException ex) // поймать исключение по соединению
        //    {
        //        Console.WriteLine("Ошибка при установлении соединения: ", ex.Message);
        //        Console.ReadKey();
        //    }
        //    finally
        //    {
        //        Disconnect();
        //    }
        //    return record;
        //}
        //public bool EditRecord(Knowledge records, int idn)
        //{
        //    bool result = true;
        //    Connect();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("UPDATE Knowledge SET TITLE=@Title, TEXT=@Text, ARTICLERATING=@ArticleRating, AUTHOR=@Author, DATE=@Date WHERE ID=@idn", Connection);
        //        cmd.Parameters.Add(new SqlParameter("@idn", idn));
        //        cmd.Parameters.Add(new SqlParameter("@Title", records.TITLE));
        //        cmd.Parameters.Add(new SqlParameter("@Text", records.TEXT));
        //        cmd.Parameters.Add(new SqlParameter("@ArticleRating", records.ARTICLERATING));
        //        cmd.Parameters.Add(new SqlParameter("@Author", records.AUTHOR));
        //        cmd.Parameters.Add(new SqlParameter("@Date", records.DATE));
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        result = false;
        //    }
        //    finally
        //    {
        //        Disconnect();
        //    }
        //    return result;
        //}
        public bool DeleteRecord(int idn)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE ID=@idn", Connection);
                cmd.Parameters.Add(new SqlParameter("@idn", idn));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
    }
}