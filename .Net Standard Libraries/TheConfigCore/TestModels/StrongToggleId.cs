using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TheConfigStandard;

namespace TheConfigCore.TestModels
{
    [ExcludeFromCodeCoverage]
    public class StrongToggleId : ToggleId
    {
        public StrongToggleId()
        {
            Name = GetType().Name;
        }
    }
}
