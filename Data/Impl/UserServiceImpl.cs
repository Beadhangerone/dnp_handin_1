using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using h1.Models;

namespace h1.Data.Impl
{
    public class UserServiceImpl : IUserService
    {
        private List<User> users;
        private readonly string users_path = "users.json";
        
        public UserServiceImpl()
        {
            Console.WriteLine("I'm here!");
            readJSONToList(users_path, users);
        }

        private async Task readJSONToList<T>(string path, List<T> list)
        {
            if (File.Exists(path))
            {
                List<T> items = new List<T>();
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    items = JsonSerializer.Deserialize<List<T>>(json);
                }
                list = items;
            }
            else
            {
                using (FileStream fs = File.Create(path))
                {
                    await JsonSerializer.SerializeAsync(fs, new List<String>());
                }
            }
        }

        public User ValidateUser(string userName, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}