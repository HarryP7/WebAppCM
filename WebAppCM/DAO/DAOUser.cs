using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppCM.Models;

namespace WebAppCM.DAO
{
    public class DAOUser : DAO
    {
        public List<User> getAllUsers()
        {
            Connect();
            List<User> usList = new List<User>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM User", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User us = new User();
                    us.Id = Convert.ToInt32(reader["Id"]);
                    us.surnameName = Convert.ToString(reader["surnameName"]);
                    us.name = Convert.ToString(reader["name"]);
                    us.patronimic = Convert.ToString(reader["patronimic"]);
                    us.phone = Convert.ToString(reader["phone"]);
                    us.email = Convert.ToString(reader["email"]);
                    usList.Add(us);
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
            return usList;
        }
        public User getUser(int id)
        {
            Connect();
            User us = new User();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM User WHERE Id=@id", Connection);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    us.Id = Convert.ToInt32(reader["Id"]);
                    us.surnameName = Convert.ToString(reader["surnameName"]);
                    us.name = Convert.ToString(reader["name"]);
                    us.patronimic = Convert.ToString(reader["patronimic"]);
                    us.phone = Convert.ToString(reader["phone"]);
                    us.email = Convert.ToString(reader["email"]);
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
            return us;
        }   
        public bool AddUser(User us)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO User (Id, surnameName, name, patronimic, phone, email) " +
                    "VALUES (@Id, @surnameName, @name, @patronimic, @phone, @email)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Id", us.Id));
                cmd.Parameters.Add(new SqlParameter("@surnameName", us.surnameName));
                cmd.Parameters.Add(new SqlParameter("@name", us.name));
                cmd.Parameters.Add(new SqlParameter("@patronimic", us.patronimic));
                cmd.Parameters.Add(new SqlParameter("@phone", us.phone));
                cmd.Parameters.Add(new SqlParameter("@email", us.email));
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
        //public bool EditRecord(User records, int idn)
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
                SqlCommand cmd = new SqlCommand("DELETE FROM User WHERE ID=@idn", Connection);
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