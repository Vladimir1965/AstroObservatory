// <copyright file="EventBackground.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author>vl</author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation {
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
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public decimal MoonDeclination { get; set; }

        /// <summary>
        /// Gets or sets The moon ascension.
        /// </summary>
        /// <value>
        /// The moon ascension.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public decimal MoonAscension { get; set; }

        /// <summary>
        /// Gets or sets The sun declination.
        /// </summary>
        /// <value>
        /// The sun declination.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public decimal SunDeclination { get; set; }

        /// <summary>
        /// Gets or sets The sun ascension.
        /// </summary>
        /// <value>
        /// The sun ascension.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public decimal SunAscension { get; set; }

        /// <summary>
        /// Gets or sets The characteristic.
        /// </summary>
        /// <value>
        /// The characteristic.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public string Characteristic { get; set; }

        /// <summary>
        /// Gets or sets The place.
        /// </summary>
        /// <value>
        /// The place.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets The event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Gets or sets The angle ve.
        /// </summary>
        /// <value>
        /// The angle ve.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public decimal AngleVE { get; set; }

        /// <summary>
        /// Gets or sets The angle je.
        /// </summary>
        /// <value>
        /// The angle je.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public decimal AngleJE { get; set; }

        /// <summary>
        /// Gets or sets The angle er.
        /// </summary>
        /// <value>
        /// The angle er.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public decimal AngleER { get; set; }

        /// <summary>
        /// Gets or sets The eruption identifier.
        /// </summary>
        /// <value>
        /// The eruption identifier.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public int EruptionId { get; set; }

        /// <summary>
        /// Gets or sets The earthquake identifier.
        /// </summary>
        /// <value>
        /// The earthquake identifier.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public int EarthquakeId { get; set; }
    }
}
