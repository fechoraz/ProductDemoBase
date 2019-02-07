using ProductDemoBase.DataPlatform.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDemoBase.DataPlatform.WebApi.Services
{
    public class LoginService
    {
        public UserModel ValidateUser(string email, string password, string targetApplication = null)
        {
            return new UserModel
            {
                Id = 1,
                OriginalUserName = "admin"
            };
        }
    }
}