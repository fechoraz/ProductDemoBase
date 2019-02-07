using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDemoBase.DataPlatform.WebApi.Providers.JWT
{
    public interface ISigningCredentialsProvider
    {
        SigningCredentials GetSigningCredentials();
    }
}