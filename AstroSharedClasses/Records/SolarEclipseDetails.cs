// <copyright file="SolarEclipseDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Solar Eclipse Details.
    /// </summary>
    public sealed class SolarEclipseDetails {
        /// <summary>
        /// Gets or sets a value indicating whether b eclipse.
        /// </summary>
        /// <value>The b eclipse.</value>
        public bool BEclipse { get; set; }

        /// <summary>
        /// Gets or sets the time of maximum eclipse.
        /// </summary>
        /// <value>The time of maximum eclipse.</value>
        public double TimeOfMaximumEclipse { get; set; }

        /// <summary>
        /// Gets or sets the F.
        /// </summary>
        /// <value>The F.</value>
        public double LatitudeF { get; set; }

        /// <summary>
        /// Gets or sets the u.
        /// </summary>
        /// <value>The u.</value>
        public double U { get; set; }

        /// <summary>
        /// Gets or sets the gamma.
        /// </summary>
        /// <value>The gamma.</value>
        public double Gamma { get; set; }

        /// <summary>
        /// Gets or sets the greatest magnitude.
        /// </summary>
        /// <value>The greatest magnitude.</value>
        public double GreatestMagnitude { [UsedImplicitly] get; set; }
    }
}
