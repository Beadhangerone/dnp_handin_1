using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using h1.Helpers;

namespace h1.Data.Impl
{
    public class JSONPersistenceService : IPersistenceService
    {
        public string Path { get; }
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions();

        public JSONPersistenceService(string path)
        {
            Path = path;
        }

        public async Task CreateFile()
        {
            await using var fs = File.Create(Path);
            await JsonSerializer.SerializeAsync(fs, new List<string>());
            fs.Close();
            ActionLog.Log($"/Database/{Path} file created");
        }

        public async Task WriteList<T>(List<T> list)
        {
            if (!File.Exists(Path))
                throw new FileNotFoundException($"File {Path} not found");

            await using StreamWriter streamWriter = File.CreateText(Path);
            await streamWriter.WriteAsync(JsonSerializer.Serialize(list));
            streamWriter.Close();
            
            ActionLog.Log($"/Database/{Path} accessed");
        }

        public async Task<List<T>> ReadList<T>()
        {
            if (!File.Exists(Path))
                throw new FileNotFoundException($"File {Path} not found");
            
            await using FileStream sourceStream = File.Open(Path, FileMode.Open);
            // result = new byte[sourceStream.Length];
            // await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
            List<T> items = await JsonSerializer.DeserializeAsync<List<T>>(sourceStream, _jsonSerializerOptions);
            sourceStream.Close();
            
            return items;
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