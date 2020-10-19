using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using h1.Helpers;
using h1.Models;

namespace h1.Data.Impl
{
    public class UserServiceImpl : IUserService
    {
        private IPersistenceService persistence;
        private List<User> users = new List<User>();
        private readonly string usersPath = "users.json";

        public UserServiceImpl()
        {
            ActionLog.Log("Data.UserServiceImpl Invoke");
            persistence = new JSONPersistenceService(usersPath);
        }

        public async Task DBSync()
        {
            // Check if the file "families.json" is created
            if (!File.Exists(persistence.Path))
                await persistence.CreateFile();
            
            users = await persistence.ReadList<User>();
            
            if (users.Count == 0)
            {
                users = new List<User>(GetPlaceholderUsers());
                await persistence.WriteList(users);
            }
        }

        private List<User> GetPlaceholderUsers()
        {
            return new[]
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