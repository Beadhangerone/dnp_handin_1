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
        private List<User> users = new List<User>();
        private readonly string users_path = "users.json";

        public UserServiceImpl()
        {
            // TODO Fix double call
            DBSync();
        }

        private async void DBSync()
        {
            initFile(users_path);
            users = readJSONToList<User>(users_path);
            
            if (users.Count == 0)
            {
                fillUsers();
                await writeListToJSON(users_path, users);
            }
        }

        private async Task initFile(string path)
        {
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    await JsonSerializer.SerializeAsync(fs, new List<String>());
                }
            }
        }

        private List<T> readJSONToList<T>(string path)
        {
            if (File.Exists(path))
            {
                List<T> items = new List<T>();
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    items = JsonSerializer.Deserialize<List<T>>(json);
                    return items;
                }
            }

            throw new Exception("File " + path + " not found!");
        }

        private async Task writeListToJSON<T>(string path, List<T> list)
        {
            if (File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    await JsonSerializer.SerializeAsync(fs, list);
                }
            }
            else
            {
                throw new Exception("file not found!");
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