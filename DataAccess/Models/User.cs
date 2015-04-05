using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public User(int id,string Username, string Password, string Name, string Role)
        {
            Id = id;
            this.Username = Username;
            this.Password = Password;
            this.Name = Name;
            this.Role = Role;
        }

        public User(string username, string password, string name, string role)
        {
            Username = username;
            Password = password;
            Name = name;
            Role = role;
        }
    }
}
