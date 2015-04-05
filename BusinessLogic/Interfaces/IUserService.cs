using System.Collections.Generic;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        User GetUser(string username, string password);
        User GetUserByName(string name);
        string GetMd5Hash(string input);
        string ForgotPassword(string username);
        void ChangePassword(string username,string password);
        void CreateUser(string username, string password, string name, string role);
        List<User> GetAllUsers();
    }
}
