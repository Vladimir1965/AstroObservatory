// <copyright file="ParabolicObjectElements.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.OrbitalElements {
    using JetBrains.Annotations;

    /// <summary>
    /// Parabolic Object Elements.
    /// </summary>
    public sealed class ParabolicObjectElements
    {
        /// <summary>
        /// Gets or sets the q.
        /// </summary>
        /// <value>The q.</value>
        public double Q { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the i.
        /// </summary>
        /// <value>The i.</value>
        [UsedImplicitly]
        public double I { get; set; }

        /// <summary>
        /// Gets or sets the w.
        /// </summary>
        /// <value>The w.</value>
        public double W { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets the omega.
        /// </summary>
        /// <value>The omega.</value>
        [UsedImplicitly]
        public double Omega { get; set; }

        /// <summary>
        /// Gets or sets the julianDay equinox.
        /// </summary>
        /// <value>The julianDay equinox.</value>
        [UsedImplicitly]
        public double JulianDayEquinox { get; set; }

        /// <summary>
        /// Gets or sets the T.
        /// </summary>
        /// <value>The T.</value>
        public double T { get; [UsedImplicitly] set; }
    }
}
