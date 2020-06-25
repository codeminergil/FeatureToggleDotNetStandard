namespace TheConfigStandard.JsonConfiguration
{
    using System.Collections.Generic;
    using System.Configuration;

    public class RolesElementCollection : ConfigurationSection
    {
        [ConfigurationProperty("role")]
        public RoleElement role { get; set; }
    }
}