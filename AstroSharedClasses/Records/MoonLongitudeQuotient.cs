// <copyright file="MoonLongitudeQuotient.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    /// <summary>
    /// Moon Longitude Quotient.
    /// </summary>
    public sealed class MoonLongitudeQuotient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoonLongitudeQuotient" /> class.
        /// </summary>
        /// <param name="elongD">The elongD.</param>
        /// <param name="anomalyM">The M.</param>
        /// <param name="mdash">The mdash.</param>
        /// <param name="latitudeF">The latitude f.</param>
        /// <param name="givenA">The A.</param>
        /// <param name="givenB">The givenB.</param>
        public MoonLongitudeQuotient(int elongD, int anomalyM, int mdash, int latitudeF, double givenA, double givenB)
        {
            this.D = elongD;
                this.M = anomalyM;
                this.Mdash = mdash;
                this.LatitudeF = latitudeF;
                this.A = givenA;
                this.B = givenB;
            }

        /// <summary>
        /// Gets the D.
        /// </summary>
        /// <value>The D.</value>
        public int D { get;  }

        /// <summary>
        /// Gets the M.
        /// </summary>
        /// <value>The M.</value>
        public int M { get; }

        /// <summary>
        /// Gets the mdash.
        /// </summary>
        /// <value>The mdash.</value>
        public int Mdash { get;  }

        /// <summary>
        /// Gets the LatitudeF.
        /// </summary>
        /// <value>The LatitudeF.</value>
        public int LatitudeF { get; }

        /// <summary>
        /// Gets the A.
        /// </summary>
        /// <value>The A.</value>
        public double A { get;  }

        /// <summary>
        /// Gets the B.
        /// </summary>
        /// <value>The givenB.</value>
        public double B { get; }
    }
}
