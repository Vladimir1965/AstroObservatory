// <copyright file="PlutoCoefficient2.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    /// <summary>
    /// Pluto Coefficient2.
    /// </summary>
    public sealed class PlutoCoefficient2
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PlutoCoefficient2" /> class.
        /// </summary>
        /// <param name="givenA">The A.</param>
        /// <param name="givenB">The B.</param>
        public PlutoCoefficient2(double givenA, double givenB) {
            this.A = givenA;
            this.B = givenB;
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
    }
}
