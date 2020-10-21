using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async Task CreateAsync(string email, string firstName, string lastName, string password)
        {
            ActionLog.Log("A new user was created");
            try
            {
                var isUnique = CheckIfUniqueEmail(email);

                if (isUnique)
                {
                    users.Add(new User { Email = email, FirstName = firstName, LastName = lastName, UserName = email, Password = password });
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null mens");
            }
            
            await SaveData();
            //_context.Users.Add(new User { Email = email, Password = password });
        }

        private List<User> GetPlaceholderUsers()
        {
            return new[]
            {
                new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "hoho@hoho.com",
                    Email = "hoho@hoho.com",
                    Password = "1234"
                }
            }.ToList();
        }

        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }

        private bool CheckIfUniqueEmail(string email)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email.Equals(email))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task SaveData()
        {
            await persistence.WriteList(users);
        }
    }
}