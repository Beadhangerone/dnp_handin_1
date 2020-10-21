using System.Threading.Tasks;
using h1.Models;

namespace h1.Data
{
    public interface IUserService
    {
        Task DBSync();
        // TODO add fields such as: first and last names, date of birth
        Task CreateAsync(string email, string firstName, string lastName, string password);
        User ValidateUser(string userName, string password);
    }
}