// <copyright file="EarthStatus.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author>vl</author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation {
    using System;

    /// <summary>
    /// Earth Status.
    /// </summary>
    public class EarthStatus {
        /// <summary>
        /// Gets or sets The day.
        /// </summary>
        /// <value>
        /// The day.
        /// </value>
        public int Day { get; set; }

        /// <summary>
        /// Gets or sets The julian day.
        /// </summary>
        /// <value>
        /// The julian day.
        /// </value>
        public decimal JulianDay { get; set; }

        /// <summary>
        /// Gets or sets The tropical year.
        /// </summary>
        /// <value>
        /// The tropical year.
        /// </value>
        public decimal TropicalYear { get; set; }

        /// <summary>
        /// Gets or sets The event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Gets or sets The earth longitude.
        /// </summary>
        /// <value>
        /// The earth longitude.
        /// </value>
        public decimal EarthLongitude { get; set; }

        /// <summary>
        /// Gets or sets The earth latitude.
        /// </summary>
        /// <value>
        /// The earth latitude.
        /// </value>
        public decimal EarthLatitude { get; set; }

        /// <summary>
        /// Gets or sets The moon longitude.
        /// </summary>
        /// <value>
        /// The moon longitude.
        /// </value>
        public decimal MoonLongitude { get; set; }

        /// <summary>
        /// Gets or sets The moon latitude.
        /// </summary>
        /// <value>
        /// The moon latitude.
        /// </value>
        public decimal MoonLatitude { get; set; }

        /// <summary>
        /// Gets or sets The ecliptic obliquity.
        /// </summary>
        /// <value>
        /// The ecliptic obliquity.
        /// </value>
        public decimal EclipticObliquity { get; set; }

        /// <summary>
        /// Gets or sets The moon ascension.
        /// </summary>
        /// <value>
        /// The moon ascension.
        /// </value>
        public decimal MoonAscension { get; set; }

        /// <summary>
        /// Gets or sets The moon declination.
        /// </summary>
        /// <value>
        /// The moon declination.
        /// </value>
        public decimal MoonDeclination { get; set; }

        /// <summary>
        /// Gets or sets The sun earth distance.
        /// </summary>
        /// <value>
        /// The sun earth distance.
        /// </value>
        public decimal SunEarthDistance { get; set; }

        /// <summary>
        /// Gets or sets The earth moon distance.
        /// </summary>
        /// <value>
        /// The earth moon distance.
        /// </value>
        public decimal EarthMoonDistance { get; set; }

        /// <summary>
        /// Gets or sets The moon node.
        /// </summary>
        /// <value>
        /// The moon node.
        /// </value>
        public decimal MoonNode { get; set; }

        /// <summary>
        /// Gets or sets The moon pericentre.
        /// </summary>
        /// <value>
        /// The moon pericentre.
        /// </value>
        public decimal MoonPericentre { get; set; }

        /// <summary>
        /// Gets or sets The sun ascension.
        /// </summary>
        /// <value>
        /// The sun ascension.
        /// </value>
        public decimal SunAscension { get; set; }

        /// <summary>
        /// Gets or sets The sun declination.
        /// </summary>
        /// <value>
        /// The sun declination.
        /// </value>
        public decimal SunDeclination { get; set; }

        /// <summary>
        /// Gets or sets The greenwich longitude.
        /// </summary>
        /// <value>
        /// The greenwich longitude.
        /// </value>
        public decimal GreenwichLongitude { get; set; }
    }
}
