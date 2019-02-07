using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProductDemoBase.DataPlatform.WebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDemoBase.DataPlatform.WebApi
{
    public class JwtAuthorizationServerConfig
    {
        private readonly IApplicationSettingProvider _applicationSettingProvider;
        //private readonly ITokenFormatProvider _tokenFormatProvider;
        private readonly IOAuthAuthorizationServerProvider _oAuthAuthorizationServerProvider;

        public JwtAuthorizationServerConfig(IApplicationSettingProvider applicationSettingProvider,
                                            //ITokenFormatProvider tokenFormatProvider,
                                            IOAuthAuthorizationServerProvider oAuthAuthorizationServerProvider)
        {
            _applicationSettingProvider = applicationSettingProvider;
            //_tokenFormatProvider = tokenFormatProvider;
            _oAuthAuthorizationServerProvider = oAuthAuthorizationServerProvider;
        }


        public void Configure(IAppBuilder app)
        {
            var expiresInMinutes = Convert.ToInt32(_applicationSettingProvider.GetValue("JWT.Expires"));

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/jwt/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(expiresInMinutes),
                //AccessTokenFormat = _tokenFormatProvider,
                Provider = _oAuthAuthorizationServerProvider,

#if DEBUG
                AllowInsecureHttp = true
#endif

            });
        }
    }
}