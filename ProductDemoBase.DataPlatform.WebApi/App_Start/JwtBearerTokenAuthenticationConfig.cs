using Owin;
using ProductDemoBase.DataPlatform.WebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
//using Microsoft.Owin.Security.Jwt;

namespace ProductDemoBase.DataPlatform.WebApi
{
    public class JwtBearerTokenAuthenticationConfig
    {
        private readonly IApplicationSettingProvider _applicationSettingProvider;

        public JwtBearerTokenAuthenticationConfig(IApplicationSettingProvider applicationSettingProvider)
        {
            _applicationSettingProvider = applicationSettingProvider;
        }

        public void Config(IAppBuilder app)
        {
            var issuer = _applicationSettingProvider.GetValue("JWT.Issuer");
            var audience = _applicationSettingProvider.GetValue("JWT.Audience");
            var key = Encoding.UTF8.GetBytes(_applicationSettingProvider.GetValue("JWT.HmacSecretKey"));

            app.UseOAuthBearerAuthentication(new Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationOptions 
                
            {  
                //AllowedAudiences = new[] { audience },
                //IssuerSecurityTokenProviders = new[] { new SymmetricKeyIssuerSecurityTokenProvider(issuer, key) },
                //TokenValidationParameters = new TokenValidationParameters
                //{

                //}
            });

        }
    }
}