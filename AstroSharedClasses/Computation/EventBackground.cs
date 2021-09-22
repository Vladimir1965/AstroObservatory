// <copyright file="EventBackground.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author>vl</author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation {
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Event Background.
    /// </summary>
    public class EventBackground {
        /// <summary>
        /// Gets or sets The moon declination.
        /// </summary>
        /// <value>
        /// The moon declination.
        /// </value>
        [UsedImplicitly]
        public decimal MoonDeclination { get; set; }

        /// <summary>
        /// Gets or sets The moon ascension.
        /// </summary>
        /// <value>
        /// The moon ascension.
        /// </value>
        [UsedImplicitly]
        public decimal MoonAscension { get; set; }

        /// <summary>
        /// Gets or sets The sun declination.
        /// </summary>
        /// <value>
        /// The sun declination.
        /// </value>
        [UsedImplicitly]
        public decimal SunDeclination { get; set; }

        /// <summary>
        /// Gets or sets The sun ascension.
        /// </summary>
        /// <value>
        /// The sun ascension.
        /// </value>
        [UsedImplicitly]
        public decimal SunAscension { get; set; }

        /// <summary>
        /// Gets or sets The characteristic.
        /// </summary>
        /// <value>
        /// The characteristic.
        /// </value>
        [UsedImplicitly]
        public string Characteristic { get; set; }

        /// <summary>
        /// Gets or sets The place.
        /// </summary>
        /// <value>
        /// The place.
        /// </value>
        [UsedImplicitly]
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets The event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        [UsedImplicitly]
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Gets or sets The angle ve.
        /// </summary>
        /// <value>
        /// The angle ve.
        /// </value>
        [UsedImplicitly]
        public decimal AngleVE { get; set; }

        /// <summary>
        /// Gets or sets The angle je.
        /// </summary>
        /// <value>
        /// The angle je.
        /// </value>
        [UsedImplicitly]
        public decimal AngleJE { get; set; }

        /// <summary>
        /// Gets or sets The angle er.
        /// </summary>
        /// <value>
        /// The angle er.
        /// </value>
        [UsedImplicitly]
        public decimal AngleER { get; set; }

        /// <summary>
        /// Gets or sets The eruption identifier.
        /// </summary>
        /// <value>
        /// The eruption identifier.
        /// </value>
        [UsedImplicitly]
        public int EruptionId { get; set; }

        /// <summary>
        /// Gets or sets The earthquake identifier.
        /// </summary>
        /// <value>
        /// The earthquake identifier.
        /// </value>
        [UsedImplicitly]
        public int EarthquakeId { get; set; }
    }
}
