namespace FeatureTogglesCoreTests.JsonTests.TestModels
{
    using System.Diagnostics.CodeAnalysis;
 //   using FeatureTogglesIConfiguration;
    using FeatureToggles;

    [ExcludeFromCodeCoverage]
    public class StrongToggleId : ToggleId
    {
        public StrongToggleId()
        {
            Name = GetType().Name;
        }
    }
}
