
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using CleverbitRandomNumbersGame.Domain.Services;

namespace CleverbitRandomNumbersGame.OAuth
{
  public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
  {
    private readonly IUserService userService;

    public SimpleAuthorizationServerProvider()
    {
      this.userService = new UserService(new Domain.EFContext());
    }

    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
    }

    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {

      if (userService.CheckUsernameAndPassword(context.UserName, context.Password))
      {
        var identity = new ClaimsIdentity(context.Options.AuthenticationType);

        identity.AddClaim(new Claim("sub", context.UserName));
        identity.AddClaim(new Claim("role", "user"));

        context.Validated(identity);
      }
      else
      {
        context.SetError("invalid_grant", "Provided username and password is incorrect");
      }
    }
  }
}
