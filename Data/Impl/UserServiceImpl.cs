using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using h1.Models;

namespace h1.Data.Impl
{
    public class UserServiceImpl : IUserService
    {
        private IPersistenceService persistence = new JSONPersistenceService();
        private List<User> users = new List<User>();
        private readonly string users_path = "users.json";

        public UserServiceImpl()
        {
            // TODO Fix double call
            DBSync();
        }

        private async void DBSync()
        {
            await persistence.Init(users_path);
            users = persistence.ReadList<User>();
            if (users.Count == 0)
            {
                fillUsers();
                await persistence.WriteList(users);
            }
        }

        private void fillUsers()
        {
            users = new[]
            {
                new User
                {
                    UserName = "Troels",
                    Password = "1234",
                    SecurityLevel = 3
                }
            }.ToList();
        }

        public User ValidateUser(string userName, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}