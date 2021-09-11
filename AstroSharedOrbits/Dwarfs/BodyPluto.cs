// <copyright file="BodyPluto.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Dwarfs
{
    using System;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedOrbits.Orbits;
    using JetBrains.Annotations;

    /// <summary> Initializes a new instance of the BodyPluto class. </summary>
    [UsedImplicitly]
    public sealed class BodyPluto : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyPluto"/> class.
        /// </summary>
        public BodyPluto()
            : base("T", "PLUTON") {
            this.PerTime = 1741.810448;      ////
            this.Body.Mass = 0.0125e24;           //// [kg]
            this.Body.Radius = 1.137e6;           //// [m]
            this.Body.J = 118.5;               //// [deg]
            this.Knke = 7;                    //// //
            this.Time.EpochOrbit = 2451543.5;   //// (2451545.0)
            this.Time.EpochEquinox = 2451543.5;

            //// Schlyter or Chapront.
            double[] lw = { 110.30347, -37.330, 0.0, 0.0 }; //// deg/Jd^k
            double[] i = { 17.14175, 11.07, 0.0, 0.0 }; //// deg/Jd^k
            double[] w = { 29.12410, 1.01444e-5, 0.0, 0.0 }; //// deg/Jd^k
            double[] a = { 39.48168677 * AstroMath.AstroUnit * AstroMath.AstroUnit, -769.12e-6 * AstroMath.AstroUnit, 0.0, 0.0 }; //// [m/Jd^k]
            //// !?!?
            double[] e = { 0.24880766, 0.0, 0.0, 0.0 }; ////  [/Jd^k]
            //// double[] e = { 0.24880766, 64.65e-6, 0.0, 0.0 }; ////  [/Jd^k]
            double[] vm = { 168.6562, 4.0923344368, 0.0, 0.0 }; //// deg/Jd^k
            //// E = { 0.048498, 4.469e-9, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);

            /*           
           _LM[0] = 238.92881;         //// [deg]
           _LM[1] = 522747.90;         //// ["/Jd]
           _LM[2] = 0;                 //// [deg/Jd2]
           _LM[3] = 0;                 //// [deg/Jd3]

           _LP[0] = 224.06676;         //// [deg]
           _LP[1] = -132.25;           //// ["/Jd]
           _LP[2] = 0;                 //// [deg/Jd2]
           _LP[3] = 0;                 //// [deg/Jd3]
           */
        }

        /// <summary>
        /// Middle Perihelion Length.
        /// </summary>
        /// <param name="currentTime">The current time.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static float MiddlePerihelionLength(float currentTime) {
            //// float time100 = (float) (1970.0F - currentTime)/100.0F;
            return 223.00F;
        }

        #region Naughter - Magnitude
        /// <summary>
        /// Pluto magnitude AA.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double PlutoMagnitudeAA(double givenParameter, double givenDelta) {
            return -1.00 + 5 * Math.Log10(givenParameter * givenDelta);
        }
        #endregion

        #region Naughter
        /// <summary>
        /// Pluto semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double PlutoSemidiameterB(double givenDelta)
        {
            return 2.07 / givenDelta;
        }

        /// <summary>
        /// Ecliptic longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double EclipticLongitude(double julianDay)
        {
            var timeT = (julianDay - 2451545) / 36525;
            var valueJ = 34.35 + 3034.9057 * timeT;
            var valueS = 50.08 + 1222.1138 * timeT;
            var valueP = 238.96 + 144.9600 * timeT;

            //// Calculate Longitude
            double longL = 0;
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var i = 0; i < OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients.Length; i++) {
                var alpha = OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients[i].J * valueJ + OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients[i].S * valueS + OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients[i].P * valueP;
                alpha = Angles.DegRad(alpha);
                longL += (OrbitalData.PlutoPerturbationQuotients.PlutoLongitudeCoefficients[i].A * Math.Sin(alpha)) + (OrbitalData.PlutoPerturbationQuotients.PlutoLongitudeCoefficients[i].B * Math.Cos(alpha));
            }

            longL = longL / 1000000;
            longL += 238.958116 + 144.96 * timeT;
            longL = Angles.Mod360(longL);

            return longL;
        }

        /// <summary>
        /// Ecliptic latitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double EclipticLatitude(double julianDay)
        {
            var timeT = (julianDay - 2451545) / 36525;
            var valueJ = 34.35 + 3034.9057 * timeT;
            var valueS = 50.08 + 1222.1138 * timeT;
            var valueP = 238.96 + 144.9600 * timeT;

            //// Calculate Latitude
            double longL = 0;
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var i = 0; i < OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients.Length; i++) {
                var alpha = OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients[i].J * valueJ + OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients[i].S * valueS + OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients[i].P * valueP;
                alpha = Angles.DegRad(alpha);
                longL += OrbitalData.PlutoPerturbationQuotients.PlutoLatitudeCoefficients[i].A * Math.Sin(alpha) + OrbitalData.PlutoPerturbationQuotients.PlutoLatitudeCoefficients[i].B * Math.Cos(alpha);
            }

            longL = longL / 1000000;
            longL += -3.908239;

            return longL;
        }

        /// <summary>
        /// Radius vector.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double RadiusVector(double julianDay)
        {
            var timeT = (julianDay - 2451545) / 36525;
            var valueJ = 34.35 + 3034.9057 * timeT;
            var valueS = 50.08 + 1222.1138 * timeT;
            var valueP = 238.96 + 144.9600 * timeT;

            //// Calculate Radius
            double r = 0;
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var i = 0; i < OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients.Length; i++) {
                var alpha = OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients[i].J * valueJ + OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients[i].S * valueS + OrbitalData.PlutoPerturbationQuotients.PlutoArgumentCoefficients[i].P * valueP;
                alpha = Angles.DegRad(alpha);
                r += (OrbitalData.PlutoPerturbationQuotients.PlutoRadiusCoefficients[i].A * Math.Sin(alpha)) + (OrbitalData.PlutoPerturbationQuotients.PlutoRadiusCoefficients[i].B * Math.Cos(alpha));
            }

            r = r / 10000000;
            r += 40.7241346;

            return r;
        }
        #endregion
    }
}
