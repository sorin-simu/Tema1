using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(String username, String password);
        string GetMd5Hash(string input);
        User GetUserByName(String name);
        void UpdatePassword(String password,String username);
        void Createuser(User newUser);
        List<User> GetAllUsers();
    }
}
