using System.Threading.Tasks;
using h1.Models;

namespace h1.Data
{
    public interface IUserService
    {
        Task DBSync();
        User ValidateUser(string userName, string password);
    }
}