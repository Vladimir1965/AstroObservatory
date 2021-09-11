// <copyright file="PhysicalSunDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Physical Sun Details.
    /// </summary>
    public sealed class PhysicalSunDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalSunDetails" /> class.
        /// </summary>
        public PhysicalSunDetails()
        {
        }

        #region Properties
        /// <summary>
        /// Gets or sets the P.
        /// </summary>
        /// <value>The P.</value>
        public double P { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the b0.
        /// </summary>
        /// <value>The b0.</value>
        public double B0 { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the l0.
        /// </summary>
        /// <value>The l0.</value>
        public double L0 { [UsedImplicitly] get; set; }
        #endregion
    }
}
