using Microsoft.Owin.Security.OAuth;
using ProductDemoBase.DataPlatform.WebApi.Providers;
using ProductDemoBase.DataPlatform.WebApi.Providers.JWT;
using ProductDemoBase.DataPlatform.WebApi.Security;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace ProductDemoBase.DataPlatform.WebApi
{
    public class IoCConfig
    {
        public Container GetInitializedContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterDependencies(container);

            return container;
        }

        private static void RegisterDependencies(Container container)
        {
            // Register services by convention:
            // I.E.: container.Register<IStudentService, StudentService>();
            RegisterServicesByConvention(container);

            //Register Generic/Base Service
            //container.Register(typeof(IGenericEntityService<>), typeof(GenericEntityService<>));

            // Register Database dependencies.
            //container.Register<DatabaseContext, DatabaseContext>(Lifestyle.Scoped);

            // Register Providers.
            container.Register<IApplicationSettingProvider, ApplicationSettingProvider>();
            container.Register<ISecurityConfiguration, SecurityConfiguration>();

            ////Register Colllection
            //RegisterCollections(container);

            container.Register<JwtAuthorizationServerConfig>();
            //container.Register<JwtBearerTokenAuthenticationConfig>();

            container.Register<ISigningCredentialsProvider, HMACSHA256SigningCredentialsProvider>();

            //if (ConfigurationManager.AppSettings["JWT.UseRsa"].ToLower() == "true")
            //    container.Register<ISigningCredentialsProvider, RSASigningCredentialsProvider>();
            //else
            //    container.Register<ISigningCredentialsProvider, HMACSHA256SigningCredentialsProvider>();

            //container.Register<ITokenFormatProvider, JwtTokenFormatProvider>();
            //container.Register<IOAuthAuthorizationServerProvider, DefaultOAuthAuthorizationServerProvider>();

            //container.Register<IPasswordHashProvider, PasswordHashSha256Salt>();
        }

        private static void RegisterServicesByConvention(Container container)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            var servicesToRegister = (
                from interfaceType in types.Where(t => t.Name.StartsWith("I") && t.Name.EndsWith("Service"))
                from serviceType in types.Where(t => t.Name == interfaceType.Name.Substring(1) && t.Namespace == interfaceType.Namespace)
                select new
                {
                    InterfaceType = interfaceType,
                    ServiceType = serviceType
                }
            );

            foreach (var pair in servicesToRegister)
                container.Register(pair.InterfaceType, pair.ServiceType);
        }

        private static void RegisterCollections(Container container)
        {
            var assembly = Assembly.GetExecutingAssembly();
            //container.Collection.Register<IScheduledAlert>(assembly);
        }
    }
}