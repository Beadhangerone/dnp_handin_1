using System.Threading.Tasks;
using h1.Models;
using Microsoft.AspNetCore.Identity;

namespace h1.Data
{
    public interface IUserService
    {
        Task DBSync();
        // TODO add fields such as: first and last names, date of birth
        Task<IdentityResult> CreateAsync(string email, string password);
        //User ValidateUser(string userName, string password);
    }
}