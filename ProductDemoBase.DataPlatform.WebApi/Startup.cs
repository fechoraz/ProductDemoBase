using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProductDemoBase.DataPlatform.WebApi.ExtensionMethods;
using SimpleInjector.Integration.WebApi;

namespace ProductDemoBase.DataPlatform.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable IoC
            var ioCConfig = new IoCConfig();
            var container = ioCConfig.GetInitializedContainer();

            app.UseOwinContextInjector(container);

            //Configure Authorization Server
            var authorizationServerConfig = container.GetInstance<JwtAuthorizationServerConfig>();
            authorizationServerConfig.Configure(app);

            //Configure Bearer Token Authentication 
            //var tokenBearerAuthenticationConfig = container.GetInstance<JwtBearerTokenAuthenticationConfig>();
            //tokenBearerAuthenticationConfig.Config(app);

            // Enable WebApi with IoC
            var httpConfiguration = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };

            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }
}
