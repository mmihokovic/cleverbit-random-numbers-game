using CleverbitRandomNumbersGame.Domain.Services;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace CleverbitRandomNumbersGame
{
  public static class UnityConfig
  {
    public static void RegisterComponents()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();

      container.RegisterType<DbContext>(new HierarchicalLifetimeManager());

      container.RegisterType<IUserService, UserService>();
      container.RegisterType<IMatchService, MatchService>();

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}
