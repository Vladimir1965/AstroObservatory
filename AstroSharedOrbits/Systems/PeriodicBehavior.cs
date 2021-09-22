// <copyright file="PeriodicBehavior.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author> vl </author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

using JetBrains.Annotations;

namespace AstroSharedOrbits.Systems
{
    /// <summary>
    /// Periodic Behavior.
    /// </summary>
    public class PeriodicBehavior
    {
        /// <summary>
        /// Gets or sets Actual Period.
        /// </summary>
        /// <value>
        /// Property description.
        /// </value>
        public double ActualPeriod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PeriodicBehavior"/> is retrograde.
        /// </summary>
        /// <value>
        ///   <c>true</c> if retrograde; otherwise, <c>false</c>.
        /// </value>
        public bool Retrograde { get; set; }

        /// <summary>
        /// Gets or sets Mean Angular Period.
        /// </summary>
        /// <value> Property description. </value>
        public double MeanAngularPeriod { get; set; }

        /// <summary>
        /// Gets or sets Actual Angle Speed.
        /// </summary>
        /// <value> Property description. </value>
        public double ActualAngleSpeed { get; set; }

        /// <summary>
        /// Gets or sets Mean Angle Speed.
        /// </summary>
        /// <value> Property description. </value>
        public double MeanAngleSpeed { get; set; }

        /// <summary>
        /// Gets or sets Total julianDay.
        /// </summary>
        /// <value> Property description. </value>
        public double TotalJulianDay { get; set; }

        /// <summary>
        /// Gets or sets Total Longitude.
        /// </summary>
        /// <value> Property description. </value>
        public double TotalLgh { get; set; }

        /// <summary>
        /// Resets the counters.
        /// </summary>
        [UsedImplicitly]
        public void ResetCounters()
        {
            this.TotalLgh = 0;
            this.TotalJulianDay = 0;
        }
    }
}
