// <copyright file="EllipticalPlanetaryDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.OrbitalElements {
    using JetBrains.Annotations;

    /// <summary>
    /// Elliptical Planetary Details.
    /// </summary>
    public sealed class EllipticalPlanetaryDetails
    {
        /// <summary>
        /// Gets or sets the apparent geocentric longitude.
        /// </summary>
        /// <value>The apparent geocentric longitude.</value>
        public double ApparentGeocentricLongitude { get; set; }

        /// <summary>
        /// Gets or sets the apparent geocentric latitude.
        /// </summary>
        /// <value>The apparent geocentric latitude.</value>
        public double ApparentGeocentricLatitude { get; set; }

        /// <summary>
        /// Gets or sets the apparent geocentric distance.
        /// </summary>
        /// <value>The apparent geocentric distance.</value>
        public double ApparentGeocentricDistance { get; set; }

        /// <summary>
        /// Gets or sets the apparent light time.
        /// </summary>
        /// <value>The apparent light time.</value>
        public double ApparentLightTime { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the apparent geocentric RA.
        /// </summary>
        /// <value>The apparent geocentric RA.</value>
        public double ApparentGeocentricRA { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the apparent geocentric declination.
        /// </summary>
        /// <value>The apparent geocentric declination.</value>
        public double ApparentGeocentricDeclination { [UsedImplicitly] get; set; }
    }
}
