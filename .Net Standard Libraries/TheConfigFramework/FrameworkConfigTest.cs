

namespace TheConfigFramework
{
    using NUnit.Framework;
    using System.Configuration;
    using TheConfigStandard.XmlConfiguration;

    [TestFixture]
    public class FrameworkConfigTest
    {
        [Test]
        public void LoadSectionConfigTest()
        {
            ToggleConfigurationSection section = ConfigurationManager.GetSection("ToggleConfiguration") as ToggleConfigurationSection;

            Assert.IsNotNull(section);
        }

        [Test]
        public void ValidateSettingsTest()
        {
            ToggleConfigurationSection section = ConfigurationManager.GetSection("ToggleConfiguration") as ToggleConfigurationSection;

            ToggleElement toggle = section.Toggles[0];

            Assert.IsNotNull(toggle);

            Assert.AreEqual("CacheInheritableDatasource", toggle.Name);
            Assert.IsTrue(toggle.Users.Count > 0);
            Assert.IsTrue(toggle.Roles.Count > 0);
            Assert.IsTrue(toggle.IpAddresses.Count > 0);
        }

        [Test]
        public void ValidateUsersTest()
        {
            ToggleConfigurationSection section = ConfigurationManager.GetSection("ToggleConfiguration") as ToggleConfigurationSection;

            ToggleElement toggle = section.Toggles[0];

            Assert.IsNotNull(toggle);

            Assert.AreEqual("CacheInheritableDatasource", toggle.Name);
            Assert.IsTrue(toggle.Users.Count > 0);

            Assert.AreEqual("abcd", toggle.Users[0].Name);
        }

        [Test]
        public void ValidateRolesTest()
        {
            ToggleConfigurationSection section = ConfigurationManager.GetSection("ToggleConfiguration") as ToggleConfigurationSection;

            ToggleElement toggle = section.Toggles[0];

            Assert.IsNotNull(toggle);

            Assert.AreEqual("CacheInheritableDatasource", toggle.Name);
            Assert.IsTrue(toggle.Roles.Count > 0);

            Assert.AreEqual("Staff", toggle.Roles[0].Name);
        }

        [Test]
        public void ValidateIpAddressesTest()
        {
            ToggleConfigurationSection section = ConfigurationManager.GetSection("ToggleConfiguration") as ToggleConfigurationSection;

            ToggleElement toggle = section.Toggles[0];

            Assert.IsNotNull(toggle);

            Assert.AreEqual("CacheInheritableDatasource", toggle.Name);
            Assert.IsTrue(toggle.IpAddresses.Count > 0);

            Assert.AreEqual("127.0.0.1/28", toggle.IpAddresses[0].Value);
        }
    }
}
