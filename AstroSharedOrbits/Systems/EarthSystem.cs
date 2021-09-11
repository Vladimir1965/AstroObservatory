// <copyright file="EarthSystem.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Systems {
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Enums;
    using AstroSharedOrbits.Planets;
    using JetBrains.Annotations;

    /// <summary>
    /// Solar Sys.
    /// </summary>
    public static class EarthSystem { //// : AbstractSystem {
        #region Public Properties
        /*
        /// <summary>
        /// Gets Vsop Path.
        /// </summary>
        /// <value> Property description. </value>
        //// [UsedImplicitly]
        //// public static string VsopPath { get; private set; }
        
        /// <summary>
        /// Gets Orbit Planet.
        /// </summary>
        /// <value> Property description. </value>
        //// [UsedImplicitly]
        //// public static Orbit[] OrbitPlanet { get; private set; }
        */

        /// <summary>
        /// Gets Earth.
        /// </summary>
        /// <value> Property description. </value>
        public static BodyEarth Earth { get; private set; }

        /// <summary>
        /// Gets the moon.
        /// </summary>
        /// <value> Property description. </value>
        public static Moons.BodyMoonMeeus Moon { get; private set; }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the Moon.
        /// </summary>
        /// <value> Property description. </value>
        private static Moons.BodyMoonSchlyter MoonSchlyter { get; set; }

        /// <summary>
        /// Gets or sets the Moon.
        /// </summary>
        /// <value> Property description. </value>
        private static Moons.BodyMoonMeeus MoonMeeus { get; set; }

        #endregion
        
        /// <summary>
        /// Init Solar Sys.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        [UsedImplicitly]
        public static void InitSystem(string rootPath) {
            SystemManager.VsopPath = rootPath + "\\Data\\Vsop87\\";
            MakeBodies();
            InitBodies(); 
        }

        /// <summary>
        /// Set Julian Date.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        public static void SetJulianDate(double givenJulianDay) {
            Earth.SetJulianDate(givenJulianDay);
            MoonMeeus.SetJulianDate(givenJulianDay);
            MoonSchlyter.SetJulianDate(givenJulianDay);
            //// MoonChapront.SetJulianDate(givenJulianDay);
            //// MoonNaughter.SetJulianDate(givenJulianDay);
        }

        #region Eclipses
        /// <summary>
        /// Determines whether [is new moon] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static bool IsNewMoon(double date, double epsilon)
        {
            Earth.SetJulianDate(date);
            Moon.SetJulianDate(date);
            var e = Earth.Longitude;
            var l = Angles.Mod360(Moon.Longitude - e);
            return Angles.EqualDeg(l, 180, epsilon);
        }

        /// <summary>
        /// Determines whether [is full moon] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static bool IsFullMoon(double date, double epsilon)
        {
            Earth.SetJulianDate(date);
            Moon.SetJulianDate(date);
            var e = Earth.Longitude;
            var l = Angles.Mod360(Moon.Longitude - e);
            return Angles.EqualDeg(l, 0, epsilon);
        }

        /// <summary>
        /// Is Earth Moon Eclipse.
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <param name="epsilonNode">The epsilon node.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static bool IsAnyEclipse(double date, double epsilon, double epsilonNode)
        {
            Earth.SetJulianDate(date);
            Moon.SetJulianDate(date);
            var e = Earth.Longitude;
            var l = Angles.Mod360(Moon.Longitude - e);
            var lw = Angles.Mod360(Moon.LW - e);
            return Angles.EqualDeg180(l, 0, epsilon) && Angles.EqualDeg180(lw, 0, epsilonNode);
        }

        /// <summary>
        /// Determines whether [is solar eclipse] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <param name="epsilonNode">The epsilon node.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static bool IsSolarEclipse(double date, double epsilon, double epsilonNode)
        {
            Earth.SetJulianDate(date);
            Moon.SetJulianDate(date);
            var e = Earth.Longitude;
            var l = Angles.Mod360(Moon.Longitude - e);
            var lw = Angles.Mod360(Moon.LW - e);
            return Angles.EqualDeg(l, 180, epsilon) && Angles.EqualDeg180(lw, 0, epsilonNode);
        }

        /// <summary>
        /// Determines whether [is lunar eclipse] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <param name="epsilonNode">The epsilon node.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static bool IsLunarEclipse(double date, double epsilon, double epsilonNode)
        {
            Earth.SetJulianDate(date);
            Moon.SetJulianDate(date);
            var e = Earth.Longitude;
            var l = Angles.Mod360(Moon.Longitude - e);
            var lw = Angles.Mod360(Moon.LW - e);
            return Angles.EqualDeg(l, 0, epsilon) && Angles.EqualDeg180(lw, 0, epsilonNode);
        }
        #endregion

        #region Private Static
        /// <summary>
        /// Make Bodies.
        /// </summary>
        private static void MakeBodies() {
            Earth = new BodyEarth();
            MoonMeeus = new Moons.BodyMoonMeeus();
            MoonSchlyter = new Moons.BodyMoonSchlyter();
            ////MoonChapront = new BodyMoonChapront();
            //// MoonNaughter = new BodyMoonNaughter();

            Moon = MoonMeeus;

            Earth.Variant = AlgVariant.VarBretagnon87;
            MoonSchlyter.Variant = AlgVariant.VarSchlyter;
            MoonMeeus.Variant = AlgVariant.VarMeeus;
            //// MoonChapront.AlgVariant = AlgVariant.VarChapront;
            //// MoonNaughter.AlgVariant = AlgVariant.VarNaughter;
        }

        /// <summary>
        /// Init Bodies.
        /// </summary>
        private static void InitBodies() {
            Earth.Init();
            MoonSchlyter.Init();
            MoonMeeus.Init();
            //// MoonChapront.Init();
            //// MoonNaughter.Init();

            Earth.Enabled = true;
            MoonMeeus.Enabled = true;

            MoonSchlyter.Enabled = false;
            //// MoonChapront.Enabled = false;
            //// MoonNaughter.Enabled = false;
        }

        #endregion
    }
}