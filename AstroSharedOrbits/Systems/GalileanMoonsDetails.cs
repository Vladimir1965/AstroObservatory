// <copyright file="GalileanMoonsDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 2010 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2010-05-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Systems {
    using AstroSharedClasses.OrbitalElements;
    using JetBrains.Annotations;

    /// <summary>
    /// Galilean Moons Details.
    /// </summary>
    public sealed class GalileanMoonsDetails {
        /// <summary>
        /// Gets or sets the satellite1.
        /// </summary>
        /// <value>
        /// The satellite1.
        /// </value>
        public GalileanMoonDetail Satellite1 { get; [UsedImplicitly] set; }  //// = new GalileanMoonDetail();

        /// <summary>
        /// Gets or sets the satellite2.
        /// </summary>
        /// <value>
        /// The satellite2.
        /// </value>
        public GalileanMoonDetail Satellite2 { get; [UsedImplicitly] set; }  //// = new GalileanMoonDetail();

        /// <summary>
        /// Gets or sets the satellite3.
        /// </summary>
        /// <value>
        /// The satellite3.
        /// </value>
        public GalileanMoonDetail Satellite3 { get; [UsedImplicitly] set; }  //// = new GalileanMoonDetail();

        /// <summary>
        /// Gets or sets the satellite4.
        /// </summary>
        /// <value>
        /// The satellite4.
        /// </value>
        public GalileanMoonDetail Satellite4 { get; [UsedImplicitly] set; }  //// = new GalileanMoonDetail();
    }
}
