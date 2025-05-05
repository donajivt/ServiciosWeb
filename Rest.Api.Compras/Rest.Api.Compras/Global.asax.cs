using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Rest.Api.Compras
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            HttpConfiguration http = GlobalConfiguration.Configuration;

            http
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .ContractResolver = new JsonLowerCaseResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
        }

    }
    public class JsonLowerCaseResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName
            (string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
