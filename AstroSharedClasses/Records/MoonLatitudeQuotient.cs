// <copyright file="MoonLatitudeQuotient.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    /// <summary>
    /// Moon Latitude Quotient.
    /// </summary>
    public sealed class MoonLatitudeQuotient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoonLatitudeQuotient" /> class.
        /// </summary>
        /// <param name="angleD">The angle d.</param>
        /// <param name="anomalyM">The M.</param>
        /// <param name="mdash">The M dash.</param>
        /// <param name="latitudeF">The LatitudeF.</param>
        /// <param name="A">The A.</param>
        public MoonLatitudeQuotient(int angleD, int anomalyM, int mdash, int latitudeF, double A)
        {
            this.D = angleD;
                this.M = anomalyM;
                this.Mdash = mdash;
                this.LatitudeF = latitudeF;
                this.A = A;
            }

        /// <summary>
        /// Gets the D.
        /// </summary>
        /// <value>The D.</value>
        public int D { get; }

        /// <summary>
        /// Gets the M.
        /// </summary>
        /// <value>The M.</value>
        public int M { get; }

        /// <summary>
        /// Gets the mdash.
        /// </summary>
        /// <value>The mdash.</value>
        public int Mdash { get; }

        /// <summary>
        /// Gets the LatitudeF.
        /// </summary>
        /// <value>The LatitudeF.</value>
        public int LatitudeF { get; }

        /// <summary>
        /// Gets the A.
        /// </summary>
        /// <value>The A.</value>
        public double A { get; }
    }
}
