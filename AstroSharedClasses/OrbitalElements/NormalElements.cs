// <copyright file="NormalElements.cs" company="Traced-Ideas, Czech republic">
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
    public sealed class NormalElements {
        /// <summary>
        /// Longitude of the ascending node    [deg/Jdi].
        /// </summary>
        private readonly double[] vLW;      

        /// <summary>
        /// Inclination of orbit (eclip.)      [deg/Jdi].
        /// </summary>
        private readonly double[] vI;         

        /// <summary>
        ///  Argument of the perihelion         [deg/Jdi].
        /// </summary>
        private readonly double[] vW;     

        /// <summary>
        ///  Mean distance (semimajor axis)     [m/Jdi].
        /// </summary>
        private readonly double[] vA;     

        /// <summary>
        /// Eccentricity                       [/Jdi].
        /// </summary>
        private readonly double[] vE;     

        /// <summary>
        ///  Mean anomaly                       [deg/Jdi].
        /// </summary>
        private readonly double[] vVM;

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalElements"/> class.
        /// </summary>
        /// <param name="aLW">A value LW.</param>
        /// <param name="aI">A value I.</param>
        /// <param name="aw">The value aw.</param>
        /// <param name="aA">A value A.</param>
        /// <param name="aE">A value E.</param>
        /// <param name="aVM">A value VM.</param>
        public NormalElements(double[] aLW, double[] aI, double[] aw, double[] aA, double[] aE, double[] aVM) {
            this.vLW = aLW; 
            this.vI = aI; 
            this.vW = aw; 
            this.vA = aA; 
            this.vE = aE; 
            this.vVM = aVM;
        }

        /// <summary>
        /// Element LW.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public double LW(double julianDate) {
            return Computation.Angles.Mod360(Computation.AstroMath.HornerSum(this.vLW, julianDate));  // Longitude noeud ascendant
        }

        /// <summary>
        /// Element I.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public double I(double julianDate) {
            return Computation.Angles.Mod360(Computation.AstroMath.HornerSum(this.vI, julianDate));  // inclination
        }

        /// <summary>
        /// Element W.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public double W(double julianDate) {
            return Computation.Angles.Mod360(Computation.AstroMath.HornerSum(this.vW, julianDate));  // argument of perihelion
        }

        /// <summary>
        /// Element A.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public double A(double julianDate) {
            return Computation.AstroMath.HornerSum(this.vA, julianDate);
        }

        /// <summary>
        /// Element E.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public double E(double julianDate) {
            return Computation.AstroMath.HornerSum(this.vE, julianDate);
        }

        /// <summary>
        /// Element VM.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public double VM(double julianDate) {
            return Computation.Angles.Mod360(Computation.AstroMath.HornerSum(this.vVM, julianDate));  // anomalie moyenne
        }

        /// <summary>
        /// Node Period.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public double NodePeriod() {
            if (this.vLW[1] > Computation.AstroMath.Zero) {
                return 1.0 / this.vLW[1];
            }

            return 0;
        }

        /// <summary>
        /// Mean Orbital Period.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public double MeanOrbitalPeriod() { //// years
            return Math.Pow(this.vA[0], 1.5);  //// / Math.Sqrt(1 + Mass / AstroMath.SunMassT) 
        }

        /// <summary>
        /// Mean Daily Motion.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public double MeanDailyMotion() { //// deg/ day
            return this.vVM[1];
        }
    }
}
