using System.Configuration;

namespace TheConfigStandard.JsonConfiguration
{
    public class UsersElement : ConfigurationSection
    {
        [ConfigurationProperty("user")]
        public string name { get; set; }
    }
}