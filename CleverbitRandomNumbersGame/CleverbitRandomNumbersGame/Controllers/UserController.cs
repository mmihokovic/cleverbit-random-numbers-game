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
  [RoutePrefix("api/user")]
  public class UserController : ApiController
  {
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
      this.userService = userService;
    }

    [HttpGet]
    [Route("get-user")]
    public User GetUser(string username)
    {
      return userService.GetUserByUsername(username);
    }

    [HttpPost]
    [Route("register")]
    public User Register(User user)
    {
      userService.AddUser(user.Username, user.Password);
      return GetUser(user.Username);
    }

  }
}
