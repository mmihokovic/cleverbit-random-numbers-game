using CleverbitRandomNumbersGame.Domain.Models;
using CleverbitRandomNumbersGame.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CleverbitRandomNumbersGame.Controllers
{
  [RoutePrefix("api/match")]
  public class MatchController : ApiController
  {
    private readonly IMatchService matchService;

    public MatchController(IMatchService matchService)
    {
      this.matchService = matchService;
    }

    [HttpGet]
    [Route("get-active-match")]
    [Authorize]
    public Match GetActiveMatch()
    {
      return matchService.GetActiveMatch();
    }

    [HttpGet]
    [Route("get-player-match")]
    [Authorize]
    public Match GetPlayerMatch(string username)
    {
      return matchService.GetPlayerMatch(username);
    }

    [HttpPost]
    [Route("play-active-match")]
    [Authorize]
    public int PlayActiveMatch(string username)
    {
      return matchService.PlayActiveMatch(username);
    }

    [HttpGet]
    [Route("get-all-matches")]
    public List<Match> GetAllMatches()
    {
      return matchService.GetAllMatches();
    }
  }
}
