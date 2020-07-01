
namespace FeatureTogglesCoreTests.JsonTests
{
    using Microsoft.Extensions.Configuration;
    using NUnit.Framework;
 //   using FeatureTogglesIConfiguration.JsonConfiguration;
 //   using NUnit.Framework.Internal;
    using FeatureToggles.Configuration.AppConfig;

    [TestFixture]
    public class ConfigurationTests
    {

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                // .AddJsonFile("app.config.json")
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [Test]
        public void TestLoadConfig()
        {
            IConfiguration configuration = InitConfiguration();

            ToggleConfigurationSection config = configuration.GetSection("ToggleConfiguration").Get<ToggleConfigurationSection>();

            Assert.NotNull(config);
        }

        [Test]
        public void ValidateSettingsTest()
        {
            IConfiguration configuration = InitConfiguration();

            ToggleConfigurationSection config = configuration.GetSection("ToggleConfiguration").Get<ToggleConfigurationSection>();

            ToggleElement toggle = config.Toggles[0];

            Assert.IsNotNull(toggle);

            Assert.AreEqual("CacheInheritableDatasource", toggle.Name);
            Assert.IsTrue(toggle.Users.Count > 0);
            Assert.IsTrue(toggle.Roles.Count > 0);
            Assert.IsTrue(toggle.IpAddresses.Count > 0);
        }

        [Test]
        public void ValidateUsersTest()
        {
            IConfiguration configuration = InitConfiguration();

            ToggleConfigurationSection config = configuration.GetSection("ToggleConfiguration").Get<ToggleConfigurationSection>();

            ToggleElement toggle = config.Toggles[0];

            Assert.IsNotNull(toggle);

            Assert.AreEqual("CacheInheritableDatasource", toggle.Name);
            Assert.IsTrue(toggle.Users.Count > 0);

            Assert.AreEqual("abcd", toggle.Users[0].Name);
        }

        [Test]
        public void ValidateRolesTest()
        {
            IConfiguration configuration = InitConfiguration();

            ToggleConfigurationSection config = configuration.GetSection("ToggleConfiguration").Get<ToggleConfigurationSection>();

            ToggleElement toggle = config.Toggles[0];

            Assert.IsNotNull(toggle);

            Assert.AreEqual("CacheInheritableDatasource", toggle.Name);
            Assert.IsTrue(toggle.Roles.Count > 0);

            Assert.AreEqual("Staff", toggle.Roles[0].Name);
        }

        [Test]
        public void ValidateIpAddressesTest()
        {
            IConfiguration configuration = InitConfiguration();

            ToggleConfigurationSection config = configuration.GetSection("ToggleConfiguration").Get<ToggleConfigurationSection>();

            ToggleElement toggle = config.Toggles[0];

            Assert.IsNotNull(toggle);

            Assert.AreEqual("CacheInheritableDatasource", toggle.Name);
            Assert.IsTrue(toggle.IpAddresses.Count > 0);

            Assert.AreEqual("127.0.0.1/28", toggle.IpAddresses[0].Value);
        }
    }
}
