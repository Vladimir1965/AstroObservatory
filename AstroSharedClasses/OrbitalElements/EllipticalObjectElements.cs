// <copyright file="EllipticalObjectElements.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.OrbitalElements {
    using JetBrains.Annotations;

    /// <summary>
    /// Elliptical Object Elements.
    /// </summary>
    public sealed class EllipticalObjectElements
    {
        /// <summary>
        /// Gets or sets a.
        /// </summary>
        /// <value>The element A.</value>
        public double A { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the e.
        /// </summary>
        /// <value>The element e.</value>
        public double E { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the i.
        /// </summary>
        /// <value>The element i.</value>
        public double I { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the w.
        /// </summary>
        /// <value>The element w.</value>
        public double W { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the omega.
        /// </summary>
        /// <value>The element omega.</value>
        public double Omega { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the julianDay equinox.
        /// </summary>
        /// <value>The element julianDay equinox.</value>
        public double JulianDayEquinox { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the T.
        /// </summary>
        /// <value>The element T.</value>
        public double T { get; [UsedImplicitly] set; }
    }
}
