// <copyright file="RiseTransitSetDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Rise Transit Set Details.
    /// </summary>
    public sealed class RiseTransitSetDetails
    {
        /// <summary>
        /// B Valid.
        /// </summary>
        [UsedImplicitly] 
        public bool BValid = true;

        /// <summary>
        /// Gets or sets the rise.
        /// </summary>
        /// <value>The rise.</value>
        public double Rise { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the transit.
        /// </summary>
        /// <value>The transit.</value>
        public double Transit { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the set.
        /// </summary>
        /// <value>The set.</value>
        public double Set { [UsedImplicitly] get; set; }
    }
}
