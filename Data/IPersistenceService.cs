using System.Collections.Generic;
using System.Threading.Tasks;

namespace h1.Data
{
    public interface IPersistenceService
    {
        string Path { get; }

        Task CreateFile();
        // Task Init(string tableName);
        Task WriteList<T>(List<T> list);
        Task<List<T>> ReadList<T>();
    }
}