// <copyright file="EclipticalElementDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Ecliptical Element Details.
    /// </summary>
    public sealed class EclipticalElementDetails
    {
        /// <summary>
        /// Gets or sets the i.
        /// </summary>
        /// <value>The i.</value>
        public double I { get; set; }

        /// <summary>
        /// Gets or sets the w.
        /// </summary>
        /// <value>The w.</value>
        public double W { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the omega.
        /// </summary>
        /// <value>The omega.</value>
        public double Omega { [UsedImplicitly] get; set; }
    }
}
