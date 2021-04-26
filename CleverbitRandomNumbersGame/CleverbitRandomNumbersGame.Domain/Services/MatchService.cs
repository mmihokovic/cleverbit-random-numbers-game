using CleverbitRandomNumbersGame.Domain.Exceptions;
using CleverbitRandomNumbersGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverbitRandomNumbersGame.Domain.Services
{
    public class MatchService : IMatchService
    {
        private readonly EFContext context;

        public MatchService(EFContext context)
        {
            this.context = context;
        }

        public Match GetActiveMatch()
        {
            return context.Matches.FirstOrDefault(m => m.EndDateTime > DateTime.Now && m.StartDateTime <= DateTime.Now);
        }

        public List<Match> GetAllMatches()
        {
            return this.context.Matches.OrderBy(m => m.StartDateTime).ToList();
        }

        public PlayerMatch GetPlayerMatch(string username)
        {
            return context.PlayerMatches.FirstOrDefault(pm => pm.Player.Username == username);
        }

        public int PlayActiveMatch(string username)
        {
            var activeMatch = GetActiveMatch();
            if (activeMatch == null)
            {
                var newMatch = new Match();
                newMatch.Seed = Guid.NewGuid().GetHashCode();
                newMatch.PlayerMatches = new List<PlayerMatch>();
                newMatch.StartDateTime = DateTime.Now;
                newMatch.EndDateTime = newMatch.StartDateTime.AddMinutes(5);

                context.Matches.Add(newMatch);
                context.SaveChanges();
                activeMatch = newMatch;
            }

            var user = context.Users.FirstOrDefault(u => u.Username == username);
            if(activeMatch.PlayerMatches.Any(pm => pm.Player.Username == user.Username))
            {
                throw new MatchException("Player already played the game");
            }

            var random = new Random(activeMatch.Seed);
            for(var skipNumbers = 0; skipNumbers < activeMatch.PlayerMatches.Count; skipNumbers++)
            {
                random.Next();
            }

            var playerMatch = new PlayerMatch();
            playerMatch.Number = random.Next();
            playerMatch.Player = user;
            activeMatch.PlayerMatches.Add(playerMatch);
            context.SaveChanges();
            return playerMatch.Number;

        }
    }
}
