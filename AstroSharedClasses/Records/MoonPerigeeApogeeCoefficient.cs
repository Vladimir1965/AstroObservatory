// <copyright file="MoonPerigeeApogeeCoefficient.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    /// <summary>
    /// Moon Perigee Apogee Coefficient.
    /// </summary>
    public sealed class MoonPerigeeApogeeCoefficient {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoonPerigeeApogeeCoefficient" /> class.
        /// </summary>
        /// <param name="elongD">The elongD.</param>
        /// <param name="anomalyM">The anomalyM.</param>
        /// <param name="latitudeF">The LatitudeF.</param>
        /// <param name="C">The C.</param>
        /// <param name="T">The T.</param>
        public MoonPerigeeApogeeCoefficient(int elongD, int anomalyM, int latitudeF, double C, double T) {
            this.D = elongD;
            this.M = anomalyM;
            this.LatitudeF = latitudeF;
            this.C = C;
            this.T = T;
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
        /// Gets the LatitudeF.
        /// </summary>
        /// <value>The LatitudeF.</value>
        public int LatitudeF { get; }

        /// <summary>
        /// Gets the C.
        /// </summary>
        /// <value>The C.</value>
        public double C { get; }

        /// <summary>
        /// Gets the T.
        /// </summary>
        /// <value>The T.</value>
        public double T { get; }
    }
}
