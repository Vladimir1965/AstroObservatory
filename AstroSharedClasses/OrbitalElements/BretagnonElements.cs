// <copyright file="BretagnonElements.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.OrbitalElements {
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// Normal Elements.
    /// </summary>
    public sealed class BretagnonElements {
        /// <summary>
        /// Initializes a new instance of the <see cref="BretagnonElements"/> class.
        /// </summary>
        /// <param name="aA">A value A.</param>
        /// <param name="aLM">A value LM.</param>
        /// <param name="k">The number k.</param>
        /// <param name="h">The number h.</param>
        /// <param name="q">The number q.</param>
        /// <param name="p">The number p.</param>
        public BretagnonElements(double[] aA, double[] aLM, double[] k, double[] h, double[] q, double[] p) {
            this.Av = aA;
            this.LMV = aLM;
            this.K = k;
            this.H = h;
            this.Q = q;
            this.P = p;
        }

        /// <summary>
        /// Gets Av.
        /// </summary>
        private double[] Av { get;  }       //// mean distance (semimajor axis)     [m/Jdi]

        /// <summary>
        /// Gets LMv.
        /// </summary>
        private double[] LMV { get; }      //// Longitude of pseudo planet    

        /// <summary>
        /// Gets Bretagnon's parameter K.
        /// </summary>
        private double[] K { get; }       //// Bretagnon's parameter          

        /// <summary>
        /// Gets Bretagnon's parameter H.
        /// </summary>
        private double[] H { get; }       //// Bretagnon's parameter          

        /// <summary>
        /// Gets Bretagnon's parameter Q.
        /// </summary>
        private double[] Q { get; }       //// Bretagnon's parameter         

        /// <summary>
        /// Gets Bretagnon's parameter P.
        /// </summary>
        private double[] P { get; }       //// Bretagnon's parameter          

        /// <summary>
        /// Element A.
        /// </summary>
        /// <param name="julianCentury">The julian century.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public double A(double julianCentury) {
            return Computation.AstroMath.HornerSum(this.Av, julianCentury);
        }

        /// <summary>
        /// Element LM.
        /// </summary>
        /// <param name="julianCentury">The julian century.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public double LM(double julianCentury) {
            return Computation.Angles.RadDeg(Computation.Angles.Mod2Pi(Computation.AstroMath.HornerSum(this.LMV, julianCentury))); // Longitude moyenne
        }

        /// <summary>
        /// Element K0.
        /// </summary>
        /// <param name="julianCentury">The julian century.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public double K0(double julianCentury) {
            return Computation.AstroMath.HornerSum(this.K, julianCentury);
        }

        /// <summary>
        /// Element H0.
        /// </summary>
        /// <param name="julianCentury">The julian century.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public double H0(double julianCentury) {
            return Computation.AstroMath.HornerSum(this.H, julianCentury);
        }

        /// <summary>
        /// Element Q0.
        /// </summary>
        /// <param name="julianCentury">The julian century.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public double Q0(double julianCentury) {
            return Computation.AstroMath.HornerSum(this.Q, julianCentury);
        }

        /// <summary>
        /// Element P0.
        /// </summary>
        /// <param name="julianCentury">The julian century.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public double P0(double julianCentury) {
            return Computation.AstroMath.HornerSum(this.P, julianCentury);
        }

        /// <summary>
        /// Pseudo Period.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public double PseudoPeriod() {
            if (this.LMV[1] > Computation.AstroMath.Zero) {
                return 1.0 / this.LMV[1];
            }

            return 0;
        }

        /// <summary>
        /// Mean Daily Motion.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public double MeanDailyMotion() { //// deg/ day
            return Computation.AstroMath.Angle360Deg / this.MeanOrbitalPeriod() / 365.25; //// ??
        }

        /// <summary>
        /// Mean Orbital Period.
        /// </summary>
        /// <returns> Returns value. </returns>
        private double MeanOrbitalPeriod() { //// years
            return Math.Pow(this.Av[0], 1.5);  ////  / Math.Sqrt(1 + Mass / AstroMath.SunMassT) 
        }
    }
}
