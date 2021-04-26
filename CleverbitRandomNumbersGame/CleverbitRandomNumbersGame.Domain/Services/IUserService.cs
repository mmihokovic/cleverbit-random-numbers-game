using CleverbitRandomNumbersGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverbitRandomNumbersGame.Domain.Services
{
    public interface IUserService
    {
        User GetUserByUsername(string username);

        bool CheckUsernameAndPassword(string username, string password);

        User AddUser(string username, string password);
    }
}
