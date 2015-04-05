using System;
using System.Collections.Generic;
using DataAccess.Interfaces;
using DataAccess.Models;
using MySql.Data.MySqlClient;

namespace DataAccess.Repository
{
    public class AdvertismentRepository : IAdvertismentRepository
    {
        private string connectionString;
        private MySqlConnection conn;

        public AdvertismentRepository()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "loginapp");
            conn = new MySqlConnection(connectionString);            
        }

        public void CreateAdvertisment(Advertisment advertisment)
        {
            String sql = "INSERT INTO `loginapp`.`advertisment` (`UserId`, `Title`, `Description`, `Picture`, `Type`, `ExtraFields`) VALUES ('" + advertisment.UserId + "','" + advertisment.Title + "'" + ",'" + advertisment.Description + "'" + ",'" + advertisment.Picture + "'" + ",'" + advertisment.Type + "'" + ",'" + advertisment.ExtraFields + "');";
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();

            }
        }

        public void DeleteAdvertisment(int advertismentId)
        {
            String sql = "DELETE FROM advertisment WHERE id = '"+advertismentId+"'";
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();

            }
        }

        public void EditAdvertisment(Advertisment advertisment)
        {
            String sql = "UPDATE advertisment SET `Title`='" + advertisment.Title + "',`Description`='" + advertisment.Description + "',`Picture`='" + advertisment.Picture + "' WHERE id='" + advertisment.Id + "'";
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();

            }
        }

        public List<Advertisment> GetAllAdvertisments()
        {
            var a = new List<Advertisment>();

            String sql = "SELECT * FROM advertisment;";

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    while (reader.HasRows)
                    {
                        var newAdvertisment = new Advertisment(reader.GetInt32("userid"),
                            reader["title"].ToString(), reader["description"].ToString(), reader["picture"].ToString(),
                            (int) reader["type"], reader["extrafields"].ToString());
                        a.Add(newAdvertisment);
                        reader.NextResult();
                    }
                }
                else
                {
                    a = null;
                }
                conn.Close();
            }

            catch (MySqlException e)
            {

                Console.WriteLine(e.Message);

                conn.Close();

                return null;

            }

            return a;
        }

        public List<Advertisment> GetAdvertismentByUserId(int userId)
        {
           var a = new List<Advertisment>();

            String sql = "SELECT * FROM advertisment WHERE userid='" + userId + "'";

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    while (reader.HasRows)
                    {
                        var newAdvertisment = new Advertisment(reader.GetInt32("userid"),
                            reader["title"].ToString(), reader["description"].ToString(), reader["picture"].ToString(),
                            (int) reader["type"], reader["extrafields"].ToString());
                        a.Add(newAdvertisment);
                        reader.NextResult();
                    }
                }
                else
                {
                    a = null;
                }
                conn.Close();
            }

            catch (MySqlException e)
            {

                Console.WriteLine(e.Message);

                conn.Close();

                return null;

            }

            return a;
        }

        public Advertisment GetAdvertismentByTitle(string title)
        {
            Advertisment u = null;

            String sql = "SELECT * FROM advertisment WHERE title='" + title + "'";

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    u = new Advertisment(reader.GetInt32("id"),reader.GetInt32("userid"),
                            reader["title"].ToString(), reader["description"].ToString(), reader["picture"].ToString(),
                            (int)reader["type"], reader["extrafields"].ToString());
                }
                else
                {
                    u = null;
                }
                conn.Close();
            }

            catch (MySqlException e)
            {

                Console.WriteLine(e.Message);

                conn.Close();

                return null;

            }

            return u;
        }
    }
}
