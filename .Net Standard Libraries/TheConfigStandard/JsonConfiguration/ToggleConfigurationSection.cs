

namespace TheConfigStandard.JsonConfiguration
{
    using System.Collections.Generic;
    using System.Configuration;

    public class ToggleConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("toggles")]
        public List<ToggleElement> toggles { get; set; }
    }
}
