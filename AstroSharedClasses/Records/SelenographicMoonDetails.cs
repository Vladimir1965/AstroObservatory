// <copyright file="SelenographicMoonDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Selenographic Moon Details.
    /// </summary>
    public sealed class SelenographicMoonDetails {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SelenographicMoonDetails" /> class.
        /// </summary>
        public SelenographicMoonDetails() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelenographicMoonDetails" /> class.
        /// </summary>
        /// <param name="fl0">The FL0.</param>
        /// <param name="fb0">The FB0.</param>
        /// <param name="fc0">The FC0.</param>
        [UsedImplicitly]
        public SelenographicMoonDetails(double fl0, double fb0, double fc0) {
            this.L0 = fl0;
            this.B0 = fb0;
            this.C0 = fc0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the l0.
        /// </summary>
        /// <value>The l0.</value>
        public double L0 { get; set; }

        /// <summary>
        /// Gets or sets the b0.
        /// </summary>
        /// <value>The b0.</value>
        public double B0 { get; set; }

        /// <summary>
        /// Gets or sets the c0.
        /// </summary>
        /// <value>The c0.</value>
        public double C0 { get; set; }
        #endregion
    }
}
