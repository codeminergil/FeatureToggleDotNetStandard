namespace TheConfigStandard.JsonConfiguration
{
    using System.Collections.Generic;
    using System.Configuration;

    public class UsersElementCollection : ConfigurationSection
    {
        [ConfigurationProperty("user")]
        public UsersElement user { get; set; }
    }
}