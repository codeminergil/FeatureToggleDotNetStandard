using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TheConfigCore.TestModels;

namespace TheConfigCore
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CoreStaticToggleTest
    {
        [Test]
        public void

            StaticToggleTest()
        {
            bool flag = CoreStaticToggle.IsEnabled;

            Assert.IsTrue(flag, "Static flag should be enabled");
        }
    }
}
