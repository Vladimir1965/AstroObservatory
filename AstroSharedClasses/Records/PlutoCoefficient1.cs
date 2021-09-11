// <copyright file="PlutoCoefficient1.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    /// <summary>
    /// Pluto Coefficient1.
    /// </summary>
    public sealed class PlutoCoefficient1
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PlutoCoefficient1" /> class.
        /// </summary>
        /// <param name="valueJ">The J.</param>
        /// <param name="valueS">The S.</param>
        /// <param name="valueP">The P.</param>
        public PlutoCoefficient1(int valueJ, int valueS, int valueP) {
            this.J = valueJ;
            this.S = valueS;
            this.P = valueP;
        }
        #endregion

        /// <summary>
        /// Gets the J.
        /// </summary>
        /// <value>The J.</value>
        public int J { get; }

        /// <summary>
        /// Gets the S.
        /// </summary>
        /// <value>The S.</value>
        public int S { get; }

        /// <summary>
        /// Gets the P.
        /// </summary>
        /// <value>The P.</value>
        public int P { get; }
    }
}
