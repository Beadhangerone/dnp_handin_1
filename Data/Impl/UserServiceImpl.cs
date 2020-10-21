using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using h1.Helpers;
using h1.Entities;
using Microsoft.AspNetCore.Identity;

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

        public async Task<IdentityResult> CreateAsync(string email, string password)
        {
            ActionLog.Log("A new user was created");
            //_context.Users.Add(new User { Email = email, Password = password });

            return IdentityResult.Success;
        }

        private List<User> GetPlaceholderUsers()
        {
            return new[]
            {
                new User
                {
                    Email = "hoho@hoho.com",
                    Password = "1234"
                }
            }.ToList();
        }

        public User ValidateUser(string userName, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}