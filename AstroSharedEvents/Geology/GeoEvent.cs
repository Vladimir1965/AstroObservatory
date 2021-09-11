// <copyright file="AstroEvent.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology { 
    using System;

    /// <summary>
    /// Astro Event.
    /// </summary>
    public class AstroEvent {
        /// <summary>
        /// Gets or sets The event type.
        /// </summary>
        /// <value>
        /// The type of the event.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets The earthquake desc.
        /// </summary>
        /// <value>
        /// The earthquake desc.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public string EarthquakeDesc { get; set; }

        /// <summary>
        /// Gets or sets The earthquake identifier.
        /// </summary>
        /// <value>
        /// The earthquake identifier.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public int? EarthquakeId { get; set; }

        /// <summary>
        /// Gets or sets The event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Gets or sets The eruption desc.
        /// </summary>
        /// <value>
        /// The eruption desc.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public string EruptionDesc { get; set; }

        /// <summary>
        /// Gets or sets The eruption identifier.
        /// </summary>
        /// <value>
        /// The eruption identifier.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public int? EruptionId { get; set; }

        /// <summary>
        /// Gets or sets The astro date.
        /// </summary>
        /// <value>
        /// The astro date.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public DateTime AstroDate { get; set; }
    }
}
