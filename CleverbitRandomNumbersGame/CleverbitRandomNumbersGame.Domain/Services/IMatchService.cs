using CleverbitRandomNumbersGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverbitRandomNumbersGame.Domain.Services
{
    public interface IMatchService
    {
        Match GetActiveMatch();
        int PlayActiveMatch(string username);
        List<Match> GetAllMatches();
        PlayerMatch GetPlayerMatch(string username);
    }
}
