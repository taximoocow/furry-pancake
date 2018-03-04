using System;
using PlanetExt = TMCCommons.EnumExtender<TestTMCCommons.Model.Planet, TestTMCCommons.Model.PlanetAttr>;
namespace TestTMCCommons.Model
{
    /// <summary>
    /// Example to recreate planets example from java⁄
    /// https://docs.oracle.com/javase/tutorial/java/javaOO/enum.html
    /// </summary>
    public enum Planet
    {
        [PlanetAttr(3.303e+23, 2.4397e6)]
        MERCURY,

        [PlanetAttr(4.869e+24, 6.0518e6)]
        VENUS,

        [PlanetAttr(5.976e+24, 6.37814e6)]
        EARTH,

        [PlanetAttr(6.421e+23, 3.3972e6)]
        MARS,

        [PlanetAttr(1.9e+27, 7.1492e7)]
        JUPITER,

        [PlanetAttr(5.688e+26, 6.0268e7)]
        SATURN,

        [PlanetAttr(8.686e+25, 2.5559e7)]
        URANUS,

        [PlanetAttr(1.024e+26, 2.4746e7)]
        NEPTUNE
    }

    class PlanetAttr : Attribute
    {
        public double Mass { get; set; }
        public double Radius { get; set; }

        internal PlanetAttr(double mass, double radius)
        {
            Mass = mass;
            Radius = radius;
        }
    }

    /// <summary>
    /// Extension class for the Planet enum
    /// </summary>
    public static class Planets
    {
        // universal gravitational constant  (m3 kg-1 s-2)
        public static readonly double G = 6.67300E-11;

        /// <summary>
        /// Mass of the specified planet.
        /// </summary>
        /// <returns>The mass.</returns>
        public static double Mass(this Planet planet)
        {
            return PlanetExt.GetAttributes(planet).Mass;
        }

        /// <summary>
        /// Radius of the specified planet.
        /// </summary>
        /// <returns>The radius.</returns>
        public static double Radius(this Planet planet)
        {
            return PlanetExt.GetAttributes(planet).Radius;
        }

        /// <summary>
        /// Surface Gravity of the specified planet.
        /// </summary>
        /// <returns>The gravity.</returns>
        public static double SurfaceGravity(this Planet planet)
        {
            double mass = Mass(planet);
            double radius = Radius(planet);
            return G * mass / (radius * radius);
        }

        /// <summary>
        /// Surface Weight of the specified planet.
        /// </summary>
        /// <returns>The weight.</returns>
        /// <param name="otherMass">Other mass.</param>
        public static double SurfaceWeight(this Planet planet, double otherMass)
        {
            return otherMass * SurfaceGravity(planet);
        }
    }
}
