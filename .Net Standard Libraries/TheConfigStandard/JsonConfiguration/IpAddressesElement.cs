using System.Configuration;

namespace TheConfigStandard.JsonConfiguration
{
    public class IpAddressesElement : ConfigurationSection
    {
        [ConfigurationProperty("value")]
        public string value { get; set; }
    }
}