using System;
using TMCCommons;
using Xunit;
using TestTMCCommons.Model;

namespace TestTMCCommons
{
    public class TestEnumUtil
    {
        [Fact]
        public void TestEnumUtil_GetAttributes_Planets()
        {
            double earthWeight = 72;
            double mass = earthWeight / Planet.EARTH.SurfaceGravity();

            Assert.Equal(1.9e+27, Planet.JUPITER.Mass());
            Assert.Equal(27.27, Math.Round(Planet.MARS.SurfaceWeight(mass), 2));
        }

        [Fact]
        public void TestEnumUtil_GetValues() {
            var planets = EnumUtil.GetValues<Planet>();
            Assert.Equal(Planet.EARTH, planets[3]);
        }
    }
}
