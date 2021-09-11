// <copyright file="PlanetaryPhenomenaCoefficient1.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    /// <summary>
    /// Planetary Phenomena Coefficient1.
    /// </summary>
    public sealed class PlanetaryPhenomenaCoefficient1 {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanetaryPhenomenaCoefficient1" /> class.
        /// </summary>
        /// <param name="a">The A.</param>
        /// <param name="b">The B.</param>
        /// <param name="m0">The m0.</param>
        /// <param name="m1">The m1.</param>
        public PlanetaryPhenomenaCoefficient1(double a, double b, double m0, double m1) {
            this.A = a;
            this.B = b;
            this.M0 = m0;
            this.M1 = m1;
        }
        #endregion

        /// <summary>
        /// Gets the A.
        /// </summary>
        /// <value>The A.</value>
        public double A { get; }

        /// <summary>
        /// Gets the B.
        /// </summary>
        /// <value>The B.</value>
        public double B { get; }

        /// <summary>
        /// Gets the m0.
        /// </summary>
        /// <value>The m0.</value>
        public double M0 { get; }

        /// <summary>
        /// Gets the m1.
        /// </summary>
        /// <value>The m1.</value>
        public double M1 { get; }
    }
}
