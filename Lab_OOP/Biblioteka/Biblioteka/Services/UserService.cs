using Biblioteka.Models;

namespace Biblioteka.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>();

        public void RegisterUser(User user)
        {
            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
        }

        public void EditUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public User GetUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public List<User> GetUsers()
        {
            return _users;
        }
    }

}
