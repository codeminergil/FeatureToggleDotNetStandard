using System.Configuration;

namespace TheConfigStandard.JsonConfiguration
{
    public class RoleElement : ConfigurationSection
    {
        [ConfigurationProperty("ApplicationName")]
        public string name { get; set; }
    }
}