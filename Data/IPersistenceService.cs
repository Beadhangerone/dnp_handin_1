using System.Collections.Generic;
using System.Threading.Tasks;

namespace h1.Data
{
    public interface IPersistenceService
    {
        // Task Init(string tableName);
        Task WriteList<T>(List<T> list);
        List<T> ReadList<T>();
        
    }
}