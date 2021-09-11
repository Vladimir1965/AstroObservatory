// <copyright file="Earthquake.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology
{
    using System;

    /// <summary>
    /// Earthquake - record.
    /// </summary>
    public class Earthquake {
        /// <summary>
        /// Gets or sets The event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Gets or sets The latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Gets or sets The longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Gets or sets The magnitude.
        /// </summary>
        /// <value>
        /// The magnitude.
        /// </value>
        public decimal Magnitude { get; set; }

        /// <summary>
        /// Gets or sets The location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets The identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The earth location.
        /// </summary>
        /// <value>
        /// The earth location.
        /// </value>
        public EarthLocation EarthLocation { get; set; }
    }
}
