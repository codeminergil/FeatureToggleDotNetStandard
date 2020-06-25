using System.Collections.Generic;
using System.Configuration;

namespace TheConfigStandard.JsonConfiguration
{
    public class ToggleElement : ConfigurationSection
    {
        [ConfigurationProperty("roles")]
        public List<RolesElementCollection> roles { get; set; }

        [ConfigurationProperty("users")]
        public List<UsersElementCollection> users { get; set; }

        [ConfigurationProperty("ipaddresses")]
        public List<IpAddressesElementCollection> ipaddresses { get; set; }

        [ConfigurationProperty("name")]
        public string name { get; set; }

        [ConfigurationProperty("enabled")]
        public bool enabled { get; set; }
    }
}