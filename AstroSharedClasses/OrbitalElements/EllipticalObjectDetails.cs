// <copyright file="EllipticalObjectDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.OrbitalElements {
    using JetBrains.Annotations;

    /// <summary>
    /// Elliptical Object Details.
    /// </summary>
    public sealed class EllipticalObjectDetails
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EllipticalObjectDetails" /> class.
        /// </summary>
        public EllipticalObjectDetails()
        {
            this.HeliocentricRectangularEquatorial = new Coordinates.Coordinate3D();
            this.HeliocentricRectangularEcliptical = new Coordinates.Coordinate3D();
        }
        #endregion

        /// <summary>
        /// Gets the heliocentric rectangular equatorial.
        /// </summary>
        /// <value>The heliocentric rectangular equatorial.</value>
        public Coordinates.Coordinate3D HeliocentricRectangularEquatorial { get; }

        /// <summary>
        /// Gets the heliocentric rectangular ecliptical.
        /// </summary>
        /// <value>The heliocentric rectangular ecliptical.</value>
        public Coordinates.Coordinate3D HeliocentricRectangularEcliptical { get; }

        /// <summary>
        /// Gets or sets the heliocentric ecliptic longitude.
        /// </summary>
        /// <value>The heliocentric ecliptic longitude.</value>
        public double HeliocentricEclipticLongitude { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the heliocentric ecliptic latitude.
        /// </summary>
        /// <value>The heliocentric ecliptic latitude.</value>
        public double HeliocentricEclipticLatitude { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the true geocentric RA.
        /// </summary>
        /// <value>The true geocentric RA.</value>
        public double TrueGeocentricRA { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the true geocentric declination.
        /// </summary>
        /// <value>The true geocentric declination.</value>
        public double TrueGeocentricDeclination { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the true geocentric distance.
        /// </summary>
        /// <value>The true geocentric distance.</value>
        public double TrueGeocentricDistance { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the true geocentric light time.
        /// </summary>
        /// <value>The true geocentric light time.</value>
        public double TrueGeocentricLightTime { get; set; }

        /// <summary>
        /// Gets or sets the astrometric geocentric RA.
        /// </summary>
        /// <value>The astrometric geocentric RA.</value>
        public double AstrometricGeocentricRA { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the astrometric geocentric declination.
        /// </summary>
        /// <value>The astrometric geocentric declination.</value>
        public double AstrometricGeocentricDeclination { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the astrometric geocentric distance.
        /// </summary>
        /// <value>The astrometric geocentric distance.</value>
        public double AstrometricGeocentricDistance { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the astrometric geocentric light time.
        /// </summary>
        /// <value>The astrometric geocentric light time.</value>
        public double AstrometricGeocentricLightTime { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the elongation.
        /// </summary>
        /// <value>The elongation.</value>
        public double Elongation { get; set; }

        /// <summary>
        /// Gets or sets the phase angle.
        /// </summary>
        /// <value>The phase angle.</value>
        public double PhaseAngle { get; set; }
    }
}
