// <copyright file="SaturnMoonDetail.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.OrbitalElements {
    using JetBrains.Annotations;

    /// <summary>
    /// Saturn Moon Detail.
    /// </summary>
    public sealed class SaturnMoonDetail
    {
        /// <summary>
        /// True Rectangular Coordinates.
        /// </summary>
        public readonly Coordinates.Coordinate3D TrueRectangularCoordinates = new Coordinates.Coordinate3D();

        /// <summary>
        /// Apparent Rectangular Coordinates.
        /// </summary>
        public readonly Coordinates.Coordinate3D ApparentRectangularCoordinates = new Coordinates.Coordinate3D();

        /// <summary>
        /// Gets or sets a value indicating whether the b in transit.
        /// </summary>
        /// <value>The b in transit.</value>
        public bool BInTransit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the b in occultation.
        /// </summary>
        /// <value>The b in occultation.</value>
        public bool BInOccultation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the b in eclipse.
        /// </summary>
        /// <value>The b in eclipse.</value>
        public bool BInEclipse { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the b in shadow transit.
        /// </summary>
        /// <value>The b in shadow transit.</value>
        public bool BInShadowTransit { [UsedImplicitly] get; set; }
    }
}
