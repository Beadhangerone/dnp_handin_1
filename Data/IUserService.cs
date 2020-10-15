using h1.Models;

namespace h1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}