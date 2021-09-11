// <copyright file="LunarEclipseDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Lunar Eclipse Details.
    /// </summary>
    public sealed class LunarEclipseDetails {
        /// <summary>
        /// Gets or sets a value indicating whether [b eclipse].
        /// </summary>
        /// <value>
        /// The b eclipse.
        /// </value>
        public bool BEclipse { get; set; }

        /// <summary>
        /// Gets or sets the time of maximum eclipse.
        /// </summary>
        /// <value>The time of maximum eclipse.</value>
        public double TimeOfMaximumEclipse { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the LatitudeF.
        /// </summary>
        /// <value>The LatitudeF.</value>
        public double LatitudeF { [UsedImplicitly] private get; set; }

        /// <summary>
        /// Gets or sets the u.
        /// </summary>
        /// <value>The u.</value>
        public double U { get; set; }

        /// <summary>
        /// Gets or sets the gamma.
        /// </summary>
        /// <value>The gamma.</value>
        public double Gamma { get; set; }

        /// <summary>
        /// Gets or sets the penumbral radii.
        /// </summary>
        /// <value>The penumbral radii.</value>
        public double PenumbralRadii { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the umbral radii.
        /// </summary>
        /// <value>The umbral radii.</value>
        public double UmbralRadii { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the penumbral magnitude.
        /// </summary>
        /// <value>The penumbral magnitude.</value>
        public double PenumbralMagnitude { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the umbral magnitude.
        /// </summary>
        /// <value>The umbral magnitude.</value>
        public double UmbralMagnitude { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the partial duration of the phase semi.
        /// </summary>
        /// <value>The partial duration of the phase semi.</value>
        public double PartialPhaseSemiDuration { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the total duration of the phase semi.
        /// </summary>
        /// <value>The total duration of the phase semi.</value>
        public double TotalPhaseSemiDuration { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the partial duration of the phase penumbra semi.
        /// </summary>
        /// <value>The partial duration of the phase penumbra semi.</value>
        public double PartialPhasePenumbraSemiDuration { [UsedImplicitly] get; set; }
    }
}
