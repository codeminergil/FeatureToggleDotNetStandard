using FeatureTogglesIConfiguration.JsonConfiguration;
using FeatureTogglesIConfiguration.Models;

namespace FeatureTogglesIConfiguration
{
    public class ToggleFactory : IToggleFactory
    {
        private IToggleConfiguration Configuration { get; }

        private IToggleDataProvider DataProvider { get; }

        public ToggleFactory(IToggleConfiguration configuration, IToggleDataProvider dataProvider)
        {
            Configuration = configuration;
            DataProvider = dataProvider;
        }

        public Toggle Get(string name)
        {
            if (!Configuration.SystemEnabled)
            {
                return new Toggle(name, Configuration.DefaultValue);
            }

            Toggle data = DataProvider.GetFlag(name);
            if (data == null)
            {
                return Toggle.Empty;
            }

            return data;
        }
        public Toggle Get(string name, ToggleData userData)
        {
            if (!Configuration.SystemEnabled)
            {
                return new Toggle(name, Configuration.DefaultValue);
            }

            if (userData == null)
            {
                return Get(name);
            }

            Toggle data = DataProvider.GetFlag(name, userData);
            if (data == null)
            {
                return Toggle.Empty;
            }

            return data;
        }

        public Toggle Get<T>() where T : ToggleId
        {
            string name = typeof(T).Name;
            if (!Configuration.SystemEnabled)
            {
                return new Toggle(name, Configuration.DefaultValue);
            }

            Toggle data = DataProvider.GetFlag(name);
            if (data == null)
            {
                return Toggle.Empty;
            }

            return data;
        }

        public Toggle Get<T>(ToggleData userData) where T : ToggleId
        {
            string name = typeof(T).Name;
            if (!Configuration.SystemEnabled)
            {
                return new Toggle(name, Configuration.DefaultValue);
            }

            if (userData == null)
            {
                return Get<T>();
            }

            Toggle data = DataProvider.GetFlag(name, userData);
            if (data == null)
            {
                return Toggle.Empty;
            }

            return data;
        }
    }
}
