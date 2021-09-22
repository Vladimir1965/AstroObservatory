// <copyright file="AstroTime.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author> vl </author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>
namespace AstroSharedOrbits.Orbits
{
    /// <summary>
    /// Astro Time.
    /// </summary>
    public class AstroTime
    {
        /// <summary>
        /// Gets or sets Epoch of orbital elements.
        /// </summary>
        /// <value> Property description. </value>
        public double EpochOrbit { get; set; }   ////

        /// <summary>
        /// Gets or sets Epoch of equinox and ecliptic.
        /// </summary>
        /// <value> Property description. </value>
        public double EpochEquinox { get; set; }   //// 

        /// <summary>
        /// Gets or sets Julian Date.
        /// </summary>
        /// <value> Property description. </value>
        public double CurrentJulianDate { get; set; }   //// 

        /// <summary>
        /// Gets or sets the previous julian date.
        /// </summary>
        /// <value>
        /// The previous julian date.
        /// </value>
        public double? PreviousJulianDate { get; set; }   //// 

        /// <summary>
        /// Gets or sets the delta julian date.
        /// </summary>
        /// <value>
        /// The delta julian date.
        /// </value>
        public double DeltaJulianDate { get; set; }   //// Difference CurrentJulianDate - PreviousJulianDate

        /// <summary>
        /// Gets or sets the J year.
        /// </summary>
        /// <value>
        /// The J year.
        /// </value>
        public double JYear { get; set; }   //// 

        /// <summary>
        /// Gets or sets Julian ephemerides day.
        /// </summary>
        /// <value> Property description. </value>
        public double JEDay { get; set; }

        /// <summary>
        /// Gets or sets Julian ephemerides century.
        /// </summary>
        /// <value> Property description. </value>
        public double Jecy { get; set; }
    }
}
