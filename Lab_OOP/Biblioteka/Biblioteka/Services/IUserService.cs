using Biblioteka.Models;

namespace Biblioteka.Services
{
    public interface IUserService
    {
        void RegisterUser(User user);
        void EditUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        List<User> GetUsers();
    }
}
