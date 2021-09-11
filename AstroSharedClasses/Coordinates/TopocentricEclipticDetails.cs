// <copyright file="TopocentricEclipticDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author>vl</author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace LargoLibAstro {

    /// <summary>
    /// Topocentric Ecliptic Details.
    /// </summary>
    public class TopocentricEclipticDetails
    {
        /// <summary>
        /// Gets or sets the lambda.
        /// </summary>
        /// <value>The lambda.</value>
        public double Lambda { get; set; }

        /// <summary>
        /// Gets or sets the beta.
        /// </summary>
        /// <value>The beta.</value>
        public double Beta { get; set; }

        /// <summary>
        /// Gets or sets the semidiameter.
        /// </summary>
        /// <value>The semidiameter.</value>
        public double Semidiameter { get; set; }
    }
}
