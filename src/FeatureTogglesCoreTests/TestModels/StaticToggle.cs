﻿using TheConfigStandard.JsonProviders;

namespace FeatureTogglesCoreTests.JsonTests.TestModels
{
    using Microsoft.Extensions.Configuration;
    using System.Diagnostics.CodeAnalysis;
    //using FeatureTogglesIConfiguration;
    //using FeatureTogglesIConfiguration.JsonConfiguration;
    //using FeatureTogglesIConfiguration.JsonProviders;
    using FeatureToggles;
    using FeatureToggles.Configuration.AppConfig.Providers;
    using FeatureToggles.Providers;
    using FeatureToggles.Configuration.AppSettings.Providers;

    [ExcludeFromCodeCoverage]
    public static class StaticToggle
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("app.config.json")
                .Build();
            return config;
        }

        public static IConfiguration configuration = InitConfiguration();
        private static readonly ToggleFactory Factory = new ToggleFactory(new AppSettingsConfigurationProvider(configuration), new AppSettingsDataProvider(configuration));

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
