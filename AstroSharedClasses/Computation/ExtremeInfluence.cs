// <copyright file="ExtremeInfluence.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation {
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// Extreme Influence.
    /// </summary>
    public sealed class ExtremeInfluence {
        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        public DateTime EventTime { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public int Longitude { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public int Latitude { [UsedImplicitly] get; set; }
    }
}
