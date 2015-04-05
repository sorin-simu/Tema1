using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using DataAccess.Models;
using DataAccess.Interfaces;
using System.Security.Cryptography;

namespace DataAccess
{
    public class UserRepository :IUserRepository
    {
        private string connectionString;
        private MySqlConnection conn;
        public UserRepository()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "loginapp");
            conn = new MySqlConnection(connectionString);            
        }

        public string GetMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.  
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }




        public User GetUser(String username, String password)
        {
            User u = null;

            String sql = "SELECT * FROM users WHERE username='" + username + "' AND password='" + password + "'";
            
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    u = new User((int)reader["id"],reader["username"].ToString(),reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
                    u.Password = GetMd5Hash(u.Password);
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


        public User GetUserByName(string name)
        {
            User u = null;

            String sql = "SELECT * FROM users WHERE name='" + name + "'";

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    u = new User(reader.GetInt32("id"), reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
                    u.Password = GetMd5Hash(u.Password);
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


        public void UpdatePassword(string password,string username)
        {
            String sql = "UPDATE users SET password='" + password +"'"+ " WHERE name='"+username+"'";
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

        public void Createuser(User newUser)
        {
            String sql = "INSERT INTO `loginapp`.`users` (`Username`, `Password`, `Name`, `Role`) VALUES ('" +newUser.Username +"'"+",'"+newUser.Password+"'"+",'"+newUser.Name+"'"+",'"+newUser.Role+"');";
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

        public List<User> GetAllUsers()         
        {
            var a = new List<User>();

            String sql = "SELECT * FROM users;";

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
                        var user = new User(reader.GetInt32("id"), reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
                        a.Add(user);
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
    }
}
