using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CleverbitRandomNumbersGame.OAuth
{
  public class AuthenticationStartup
  {
    public void Configuration(IAppBuilder app)
    {
      var myProvider = new SimpleAuthorizationServerProvider();
      OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
      {
        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        Provider = myProvider
      };
      app.UseOAuthAuthorizationServer(options);
      app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
      HttpConfiguration config = new HttpConfiguration();
      WebApiConfig.Register(config);
    }
  }
}
