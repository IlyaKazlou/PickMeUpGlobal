using System;

using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Owin;
using System.Web.Http;

using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;

using PickMeAppGlobal.Providers;

[assembly: OwinStartup(typeof(PickMeAppGlobal.Startup))]
namespace PickMeAppGlobal
{
  public class Startup
  {
    public static FacebookAuthenticationOptions FacebookAuthOptions { get; private set; }

    public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

    public void Configuration(IAppBuilder app)
    {
      HttpConfiguration config = new HttpConfiguration();

      this.ConfigureOAuth(app);

      WebApiConfig.Register(config);
      app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
      app.UseWebApi(config);
    }

    public void ConfigureOAuth(IAppBuilder app)
    {
      //use a cookie to temporarily store information about a user logging in with a third party login provider
      app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
      OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

      OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
      {

        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
        Provider = new OAuthAuthorizationServerProvider(),
        RefreshTokenProvider = new AuthenticationTokenProvider()
      };

      // Token Generation
      app.UseOAuthAuthorizationServer(OAuthServerOptions);
      app.UseOAuthBearerAuthentication(OAuthBearerOptions);

      //Configure Facebook External Login
      FacebookAuthOptions = new FacebookAuthenticationOptions()
      {
        AppId = "841670309262660",
        AppSecret = "8b4eba3df30d4aa95427fa9c90372462",
        Provider = new FacebookAuthProvider(),
      };

      app.UseFacebookAuthentication(FacebookAuthOptions);
    }
  }
}