// <copyright file="Vsop87Coefficient.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records
{
    using JetBrains.Annotations;

    /// <summary>
    /// Vsop87 Coefficient.
    /// </summary>
    public sealed class Vsop87Coefficient
    {
        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public readonly double A;

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public readonly double B;

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public readonly double C;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vsop87Coefficient" /> class.
        /// </summary>
        [UsedImplicitly]
        public Vsop87Coefficient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vsop87Coefficient" /> class.
        /// </summary>
        /// <param name="fA">The f A.</param>
        /// <param name="fB">The f B.</param>
        /// <param name="fC">The f C.</param>
        public Vsop87Coefficient(double fA, double fB, double fC)
        {
            this.A = fA;
            this.B = fB;
            this.C = fC;
        }
    }
}