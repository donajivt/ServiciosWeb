using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Login2.Startup))]

namespace Login2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigurarOauth(app);
            app.UseWebApi(config);
        }
        public void ConfigurarOauth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions opcionesAutorizacion =
                new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/recuperartoken"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromHours(7),
                    Provider = new Credentials.AutorizacionCredencialesToken()
                };
            app.UseOAuthAuthorizationServer(opcionesAutorizacion);
            OAuthBearerAuthenticationOptions opcionesoauth =
            new OAuthBearerAuthenticationOptions()
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            };
            app.UseOAuthBearerAuthentication(opcionesoauth);
        }
    }
}
