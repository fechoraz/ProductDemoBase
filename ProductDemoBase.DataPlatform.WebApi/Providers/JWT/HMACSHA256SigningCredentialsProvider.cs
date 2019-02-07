using Microsoft.IdentityModel.Tokens;
using ProductDemoBase.DataPlatform.WebApi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProductDemoBase.DataPlatform.WebApi.Providers.JWT
{
    // Following articles:
    //http://bitoftech.net/2014/10/27/json-web-token-asp-net-web-api-2-jwt-owin-authorization-server/
    //http://odetocode.com/blogs/scott/archive/2015/01/15/using-json-web-tokens-with-katana-and-webapi.aspx
    /// <summary>
    /// The HMAC SHA 256 signing credentials provider.
    /// </summary>
    public class HMACSHA256SigningCredentialsProvider : ISigningCredentialsProvider
    {
        private readonly ISecurityConfiguration _configuration;
        private const string SignatureAlgorithm = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";
        private const string DigestAlgorithm = "http://www.w3.org/2001/04/xmlenc#sha256";

        /// <summary>
        /// Constructor for the HMAC SHA 256 signing credentials provider.
        /// </summary>
        /// <param name="appSettings">The app settings provider</param>
        public HMACSHA256SigningCredentialsProvider(ISecurityConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets a SigningCredentials object configured with the HMAC SHA 256 algorithm.
        /// </summary>
        /// <returns>SigningCredentials</returns>
        public SigningCredentials GetSigningCredentials()
        {
           
            var hmacKey = _configuration.HmacSecretKey;
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(hmacKey));

            return new SigningCredentials(symmetricSecurityKey, SignatureAlgorithm, DigestAlgorithm);
        }
    }
}