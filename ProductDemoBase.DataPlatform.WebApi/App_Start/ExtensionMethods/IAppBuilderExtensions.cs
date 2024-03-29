﻿using Owin;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace ProductDemoBase.DataPlatform.WebApi.ExtensionMethods
{
    public static class AppBuilderExtensions
    {
        public static void UseOwinContextInjector(this IAppBuilder app, Container container)
        {
            // Create an OWIN middleware to create an execution context scope
            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(container))
                {
                    await next();
                }
            });
        }
    }
}