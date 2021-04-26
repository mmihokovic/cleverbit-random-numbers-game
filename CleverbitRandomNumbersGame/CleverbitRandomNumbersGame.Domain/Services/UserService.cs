using CleverbitRandomNumbersGame.Domain.Models;
using System.Linq;

namespace CleverbitRandomNumbersGame.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly EFContext context;

        public UserService(EFContext context)
        {
            this.context = context;
        }

        public bool CheckUsernameAndPassword(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
            return user != null;
        }

        public User GetUserByUsername(string username)
        {
            return context.Users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public User AddUser(string username, string password)
        {
            context.Users.Add(new User() { Username = username, Password = password });
            context.SaveChanges();
            return GetUserByUsername(username);
        }
    }
}
