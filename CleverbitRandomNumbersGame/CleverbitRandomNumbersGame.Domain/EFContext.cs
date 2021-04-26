using CleverbitRandomNumbersGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverbitRandomNumbersGame.Domain
{
    public class EFContext : DbContext
    {
        public EFContext() : base("name = Cleverbit_Entities")
        {
            //Database.SetInitializer<EFContext>(new DbInit());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Match> Matches { get; set; }

        public DbSet<PlayerMatch> PlayerMatches { get; set; }
    }
}
