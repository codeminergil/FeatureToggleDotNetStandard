using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TheConfigStandard;
using TheConfigStandard.JsonConfiguration;
using TheConfigStandard.JsonProviders;

namespace TheConfigCore.TestModels
{
    [ExcludeFromCodeCoverage]
    public static class CoreStaticToggle
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("app.config.json")
                .Build();
            return config;
        }

        public static IConfiguration configuration = InitConfiguration();
        private static readonly ToggleFactory Factory = new ToggleFactory(new AppConfigurationProvider(configuration), new AppConfigDataProvider(configuration));

        public static bool IsEnabled
        {
            get
            {
                Toggle toggle = Factory.Get<StrongToggleId>();

                // OR:
                // Toggle toggle = Factory.Get("StaticToggle");

                return toggle.IsEnabled;
            }
        }
    }
}
