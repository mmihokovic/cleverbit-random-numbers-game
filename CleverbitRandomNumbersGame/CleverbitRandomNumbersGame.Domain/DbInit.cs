using CleverbitRandomNumbersGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverbitRandomNumbersGame.Domain
{
    public class DbInit : DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            var user1 = new User();
            user1.Username = "player1";
            user1.Password = "pass";
            context.Users.Add(user1);

            var user2 = new User();
            user2.Username = "player1";
            user2.Password = "pass";
            context.Users.Add(user2);

            base.Seed(context);
        }

            
    }
}
