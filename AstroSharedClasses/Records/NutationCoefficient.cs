// <copyright file="NutationCoefficient.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Nutation Coefficient.
    /// </summary>
    public sealed class NutationCoefficient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NutationCoefficient" /> class.
        /// </summary>
        [UsedImplicitly]
        public NutationCoefficient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NutationCoefficient" /> class.
        /// </summary>
        /// <param name="fD">The f D.</param>
        /// <param name="fM">The f M.</param>
        /// <param name="fMprime">The f mprime.</param>
        /// <param name="fF">The f LatitudeF.</param>
        /// <param name="fomega">The fomega.</param>
        /// <param name="fsincoeff1">The fsincoeff1.</param>
        /// <param name="fsincoeff2">The fsincoeff2.</param>
        /// <param name="fcoscoeff1">The fcoscoeff1.</param>
        /// <param name="fcoscoeff2">The fcoscoeff2.</param>
        public NutationCoefficient(int fD, int fM, int fMprime, int fF, int fomega, int fsincoeff1, double fsincoeff2,int fcoscoeff1, double fcoscoeff2) {
            this.D = fD;
            this.M = fM;
            this.Mprime = fMprime;
            this.LatitudeF = fF;
            this.Omega = fomega;
            this.Sincoeff1 = fsincoeff1;
            this.Sincoeff2 = fsincoeff2;
            this.Coscoeff1 = fcoscoeff1;
            this.Coscoeff2 = fcoscoeff2;
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
        /// Gets the mprime.
        /// </summary>
        /// <value>The mprime.</value>
        public int Mprime { get; }

        /// <summary>
        /// Gets the LatitudeF.
        /// </summary>
        /// <value>The LatitudeF.</value>
        public int LatitudeF { get; }

        /// <summary>
        /// Gets the omega.
        /// </summary>
        /// <value>The omega.</value>
        public int Omega { get; }

        /// <summary>
        /// Gets the sincoeff1.
        /// </summary>
        /// <value>The sincoeff1.</value>
        public int Sincoeff1 { get; }

        /// <summary>
        /// Gets the sincoeff2.
        /// </summary>
        /// <value>The sincoeff2.</value>
        public double Sincoeff2 { get; }

        /// <summary>
        /// Gets the coscoeff1.
        /// </summary>
        /// <value>The coscoeff1.</value>
        public int Coscoeff1 { get; }

        /// <summary>
        /// Gets the coscoeff2.
        /// </summary>
        /// <value>The coscoeff2.</value>
        public double Coscoeff2 { get; }
    }
}
