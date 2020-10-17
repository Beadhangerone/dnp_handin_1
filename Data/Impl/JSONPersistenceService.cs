using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace h1.Data.Impl
{
    public class JSONPersistenceService : IPersistenceService
    {
        private string Path { get; set; }

        public JSONPersistenceService(string path)
        {
            Path = path;
            if (!File.Exists(Path))
            {
                using (FileStream fs = File.Create(Path))
                {
                    JsonSerializer.SerializeAsync(fs, new List<String>());
                }
            }
            else
            {
                
            }
        }

        public async Task WriteList<T>(List<T> list)
        {
            if (File.Exists(Path))
            {
                using (FileStream fs = File.Create(Path))
                {
                    await JsonSerializer.SerializeAsync(fs, list);
                }
            }
            else
            {
                throw new Exception("file not found!");
            }
        }

        public List<T> ReadList<T>()
        {
            if (File.Exists(Path))
            {
                List<T> items = new List<T>();
                using (StreamReader r = new StreamReader(Path))
                {
                    string json = r.ReadToEnd();
                    items = JsonSerializer.Deserialize<List<T>>(json);
                    return items;
                }
            }

            throw new Exception("File " + Path + " not found!");
        }

        private int GetNextId()
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();
                return JsonSerializer.Deserialize<List<object>>(json).Count;
            }
        }
    }
}