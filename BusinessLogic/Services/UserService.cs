using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using System.Security.Cryptography;
using DataAccess;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();

        }

        public User GetUserByName(string name)
        {
            var currentUser = _userRepository.GetUserByName(name);
            return currentUser;
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


        public DataAccess.Models.User GetUser(string username, string password)
        {
            var encryptPassword = GetMd5Hash(password);
            var currentUser = _userRepository.GetUser(username, encryptPassword);
            return currentUser;
        }



        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }


        public string ForgotPassword(string username)
        {
            string newPassword = RandomString(4);
            _userRepository.UpdatePassword(GetMd5Hash(newPassword), username);
            return newPassword;
        }

        public void ChangePassword(string username, string newPassword)
        {
            _userRepository.UpdatePassword(GetMd5Hash(newPassword),username);
        }

        public void CreateUser(string username, string password, string name, string role)
        {
            var newUser = new User(username, GetMd5Hash(password), name, role);
            _userRepository.Createuser(newUser);
        }

        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users;
        }
    }
}
