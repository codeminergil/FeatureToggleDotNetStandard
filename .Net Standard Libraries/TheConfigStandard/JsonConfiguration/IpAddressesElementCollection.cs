namespace TheConfigStandard.JsonConfiguration
{
    using System.Collections.Generic;
    using System.Configuration;

    public class IpAddressesElementCollection : ConfigurationSection
    {
        [ConfigurationProperty("ipaddress")]
        public IpAddressesElement ipaddress { get; set; }
    }
}