using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProductDemoBase.DataPlatform.WebApi.Security
{
    public interface ISecurityConfiguration
    {
        string Audience { get; }

        int Expires { get; }

        string HmacSecretKey { get; }

        string Issuer { get; }

        string RsaJsonFileName { get; }

        string Salt { get; }
    }

    public class SecurityConfiguration : ISecurityConfiguration
    {
        public string Audience => ConfigurationManager.AppSettings["Jwt.Audience"];

        public int Expires
        {
            get
            {
                var expires = ConfigurationManager.AppSettings["JWT.Expires"];
                return expires == null ? 0 : Convert.ToInt32(expires);
            }
        }

        public string Issuer => ConfigurationManager.AppSettings["Jwt.Issuer"];

        public string HmacSecretKey => ConfigurationManager.AppSettings["Jwt.HmacSecretKey"];

        public string RsaJsonFileName => ConfigurationManager.AppSettings["Jwt.RsaJsonFileName"];

        public string Salt => ConfigurationManager.AppSettings["Password.Salt"];
    }
}