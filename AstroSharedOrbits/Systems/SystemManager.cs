// <copyright file="SystemManager.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Systems {
    using AstroSharedClasses.Enums;

    /// <summary>
    /// System Manager.
    /// </summary>
    public static class SystemManager {
        /// <summary>
        /// Gets or sets Vsop Path.
        /// </summary>
        /// <value> Property description. </value>
        public static string VsopPath { get; set; }

        /// <summary>
        /// Gets or sets the current system.
        /// </summary>
        /// <value>The current system.</value>
        public static AstSystem CurrentSystem { get;  set; }

        /// <summary>
        /// Sets the julian date.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        public static void SetJulianDate(double givenJulianDay) {
            switch (CurrentSystem) {
                case AstSystem.Solar:
                    SolarSystem.Singleton.SetJulianDate(givenJulianDay);
                    break;
                case AstSystem.Earth:
                    EarthSystem.SetJulianDate(givenJulianDay);
                    break;
                case AstSystem.Jupiter:
                    break;
            }
        }

        /// <summary>
        /// Sets the enabled.
        /// </summary>
        /// <param name="flag">The flag.</param>
        public static void SetEnabled(bool flag) {
            {
                switch (CurrentSystem) {
                    case AstSystem.Solar:
                        SolarSystem.Singleton.SetEnabled(flag);
                        break;
                    case AstSystem.Earth:
                        //// EarthSystem.SetEnabled(flag);
                        break;
                    case AstSystem.Jupiter:
                        break;
                }
            }
        }
    }
}
