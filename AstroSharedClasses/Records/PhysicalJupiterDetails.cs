// <copyright file="PhysicalJupiterDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Physical Jupiter Details.
    /// </summary>
    public sealed class PhysicalJupiterDetails
    {
        /// <summary>
        /// Gets or sets the DE.
        /// </summary>
        /// <value>The DE.</value>
        public double DE { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the DS.
        /// </summary>
        /// <value>The DS.</value>
        public double DS { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the geometricW1.
        /// </summary>
        /// <value>The geometricW1.</value>
        public double GeometricW1 { get; set; }

        /// <summary>
        /// Gets or sets the geometricW2.
        /// </summary>
        /// <value>The geometricW2.</value>
        public double GeometricW2 { get; set; }

        /// <summary>
        /// Gets or sets the apparentW1.
        /// </summary>
        /// <value>The apparentW1.</value>
        public double ApparentW1 { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the apparentW2.
        /// </summary>
        /// <value>The apparentW2.</value>
        public double ApparentW2 { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the P.
        /// </summary>
        /// <value>The P.</value>
        public double P { [UsedImplicitly] get; set; }
    }
}
