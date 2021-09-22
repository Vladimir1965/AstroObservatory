// <copyright file="AngleBands.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation
{
    using System.Linq;

    /// <summary>
    /// Angle Bands.
    /// </summary>
    public class AngleBands
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AngleBands"/> class.
        /// </summary>
        /// <param name="givenJdate">The given Julian date.</param>
        public AngleBands(double givenJdate)
        {
            this.julianDate = givenJdate;
            this.band = new double[12];
        }

        /// <summary>
        /// Gets or sets the julianDate.
        /// </summary>
        /// <value>
        /// The julianDate.
        /// </value>
        public double julianDate { get; set; }

        /// <summary>
        /// Gets or sets the band.
        /// </summary>
        /// <value>
        /// The band.
        /// </value>
        public double[] band { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public double Total { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public double MaxValue { get; set; }

        /// <summary>
        /// Recomputes this instance.
        /// </summary>
        public void Recompute()
        {
            this.Total = (from x in this.band where x > 200 select x).Sum(); //// 700 ////this.band.Sum();
            this.MaxValue = (from x in this.band select x).Max();
        }
    }
}
