using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Login2.Credentials
{
    public class AutorizacionCredencialesToken : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var acceso = ((context.UserName == "vania" && context.Password == "777") || (context.UserName == "donaji" && context.Password == "222"));
            if(acceso == false)
            {
                context.SetError("Sin acceso", "Usuario o Password incorrectos");
            }
            else
            {
                ClaimsIdentity identidad = new ClaimsIdentity(context.Options.AuthenticationType);
                identidad.AddClaim(new Claim(ClaimTypes.Name, context.Password));
                if((context.UserName == "vania" && context.Password == "777"))
                {
                    identidad.AddClaim(new Claim(ClaimTypes.Role, "Administrador"));
                    context.Validated(identidad);
                }
                if ((context.UserName == "donaji" && context.Password == "222"))
                {
                    identidad.AddClaim(new Claim(ClaimTypes.Role, "Usuario"));
                    context.Validated(identidad);
                }
            }
        }
    }
}