// <copyright file="PhysicalMoonDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Physical Moon Details.
    /// </summary>
    public sealed class PhysicalMoonDetails {
        /// <summary>
        /// Gets or sets the ldash.
        /// </summary>
        /// <value>The ldash.</value>
        public double Ldash { get; set; }

        /// <summary>
        /// Gets or sets the bdash.
        /// </summary>
        /// <value>The bdash.</value>
        public double Bdash { get; set; }

        /// <summary>
        /// Gets or sets the ldash2.
        /// </summary>
        /// <value>The ldash2.</value>
        public double Ldash2 { get; set; }

        /// <summary>
        /// Gets or sets the bdash2.
        /// </summary>
        /// <value>The bdash2.</value>
        public double Bdash2 { get; set; }

        /// <summary>
        /// Gets or sets the L.
        /// </summary>
        /// <value>The L.</value>
        [UsedImplicitly] public double L { get; set; }

        /// <summary>
        /// Gets or sets the B.
        /// </summary>
        /// <value>The B.</value>
        public double B { get; set; }

        /// <summary>
        /// Gets or sets the P.
        /// </summary>
        /// <value>The P.</value>
        public double P { get; set; }
    }
}
