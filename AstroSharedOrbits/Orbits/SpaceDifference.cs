// <copyright file="SpaceDifference.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author> vl </author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Orbits
{
    using System;

    /// <summary>
    /// Space Difference.
    /// </summary>
    public class SpaceDifference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceDifference"/> class.
        /// </summary>
        /// <param name="pointA">The point a.</param>
        /// <param name="pointB">The point b.</param>
        public SpaceDifference(SpacePoint pointA, SpacePoint pointB)
        {
            this.DX = pointB.XH - pointA.XH;
            this.DY = pointB.YH - pointA.YH;
            this.DZ = pointB.ZH - pointA.ZH;
            this.DS = Math.Sqrt((this.DX * this.DX) + (this.DY * this.DY) + (this.DZ * this.DZ));
        }

        /// <summary>
        /// Gets or sets the dx.
        /// </summary>
        /// <value>
        /// The dx.
        /// </value>
        public double DX { get; set; }

        /// <summary>
        /// Gets or sets the dy.
        /// </summary>
        /// <value>
        /// The dy.
        /// </value>
        public double DY { get; set; }

        /// <summary>
        /// Gets or sets the dz.
        /// </summary>
        /// <value>
        /// The dz.
        /// </value>
        public double DZ { get; set; }

        /// <summary>
        /// Gets or sets the ds.
        /// </summary>
        /// <value>
        /// The ds.
        /// </value>
        public double DS { get; set; }
    }
}
