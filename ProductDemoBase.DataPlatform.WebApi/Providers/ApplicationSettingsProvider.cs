using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProductDemoBase.DataPlatform.WebApi.Providers
{
    public interface IApplicationSettingProvider
    {
        string GetValue(string key);
        string GetConnectionString(string name);
    }

    public class ApplicationSettingProvider : IApplicationSettingProvider
    {
        public string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}