using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CleverbitRandomNumbersGame.OAuth
{
  public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
  {
    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    {
      context.Validated();
    }


    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
      // CORS a
      //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

      Service<User> Users = new Service<User>();
      var service_Result = Users.GetAll();

      if (service_Result.Any(x => x.Username == context.UserName && x.Password == context.Password))
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
