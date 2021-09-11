// <copyright file="Angle.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation
{
    using System;
    using JetBrains.Annotations;

    //// DigitalStudios {

    /// <summary>
    /// Geometric Angle.
    /// </summary>
    [UsedImplicitly]
    public struct Angle {
        /// <summary>  Angle degree.  </summary>
        private readonly int degree;

        /// <summary>  Angle minute.  </summary>
        private readonly int arcmin;

        /// <summary>  Angle second.  </summary>
        private readonly double arcsec;

        /// <summary>
        /// Initializes a new instance of the <see cref="Angle"/> struct.
        /// </summary>
        /// <param name="degree">The degree.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public Angle(int degree, int minute, double second) {
            if (minute < 0 || minute > 59) {
                throw new ArgumentOutOfRangeException(nameof(minute), "Must be a integer between 0 and 59 inclusive.)");
            }

            if (second < 0.0 || !(second < 60.0)) {
                throw new ArgumentOutOfRangeException(nameof(second), "Must be a double in the domain [0.0,60.0)");
            }

            this.degree = degree;
            this.arcmin = minute;
            this.arcsec = second;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Angle" /> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public Angle(double value) {
            this.degree = (int)Math.Truncate(value);
            var fracMin = (value - this.degree) * 60.0;
            this.arcmin = (int)Math.Truncate(fracMin);
            this.arcsec = (fracMin - this.arcmin) * 60.0;
        }

        /// <summary>
        /// Gets the fractional degrees.
        /// </summary>
        /// <value>The fractional degrees.</value>
        [UsedImplicitly]
        public double FractionalDegrees => this.degree + (this.arcmin + this.arcsec / 60.0) / 60.0;

        /// <summary>
        /// Gets the hour.
        /// </summary>
        /// <value>The hour.</value>
        [UsedImplicitly]
        public int Hour => (int)Math.Truncate(this.degree / 15.0);

        /// <summary>
        /// Gets the degree.
        /// </summary>
        /// <value>The degree.</value>
        [UsedImplicitly]
        public int Degree => this.degree;

        /// <summary>
        /// Gets the arc minute.
        /// </summary>
        /// <value>The arc minute.</value>
        [UsedImplicitly]
        public int ArcMinute => this.arcmin;

        /// <summary>
        /// Gets the arc second.
        /// </summary>
        /// <value>The arc second.</value>
        [UsedImplicitly]
        public double ArcSecond => this.arcsec;
    }
}
