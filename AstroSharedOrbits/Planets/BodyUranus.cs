// <copyright file="BodyUranus.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Planets {
    using System;
    using System.Diagnostics;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Enums;
    using AstroSharedClasses.OrbitalElements;
    using JetBrains.Annotations;

    /// <summary>
    /// Body Uranus.
    /// </summary>
    public sealed class BodyUranus : Orbits.Orbit {
        /// <summary>
        /// Initializes a new instance of the BodyUranus class.
        /// </summary>
        public BodyUranus()
            : base("U", "Uranus") {
            this.PerTime = 1966.380582;      ////
            this.Body.Mass = 86.83e24;            //// [kg]
            this.Body.Radius = 25.559e6;          //// [m]
            this.Body.J = 97.86;              //// [deg]
            this.Knke = 10;                 ////4;          
            this.MeanPeriod = 84.02;
        }

        #region Naughter - PerihelionAphelion
        /// <summary>
        /// Uranus the K.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static long UranusK(double year) {
            return (long)(0.01190 * (year - 2051.1));
        }

        /// <summary>
        /// Uranus the perihelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusPerihelion(long givenK) {
            double kdash = givenK;
            var kSquared = kdash * kdash;
            return 2470213.5 + 30694.8767 * kdash - 0.00541 * kSquared;
        }

        /// <summary>
        /// Uranus the aphelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusAphelion(long givenK) {
            var kdash = givenK + 0.5;
            var kSquared = kdash * kdash;
            return 2470213.5 + 30694.8767 * kdash - 0.00541 * kSquared;
        }
        #endregion

        #region Naughter - Aproximation
        /// <summary>
        /// Uranus the mean longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusMeanLongitude(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(314.055005 + 429.8640561 * timeT + 0.00030390 * timeSquared + 0.000000026 * timeCubed);
        }

        /// <summary>
        /// Uranus the semimajor axis.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusSemimajorAxis(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;

            return 19.218446062 - 0.0000000372 * timeT + 0.00000000098 * timeSquared;
        }

        /// <summary>
        /// Uranus the eccentricity.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusEccentricity(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return 0.04638122 - 0.000027293 * timeT + 0.0000000789 * timeSquared + 0.00000000024 * timeCubed;
        }

        /// <summary>
        /// Uranus the inclination.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusInclination(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(0.773197 + 0.0007744 * timeT + 0.00003749 * timeSquared - 0.000000092 * timeCubed);
        }

        /// <summary>
        /// Uranus the longitude ascending node.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusLongitudeAscendingNode(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(74.005957 + 0.5211278 * timeT + 0.00133947 * timeSquared + 0.000018484 * timeCubed);
        }

        /// <summary>
        /// Uranus the longitude perihelion.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusLongitudePerihelion(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(173.005291 + 1.4863790 * timeT + 0.00021406 * timeSquared + 0.000000434 * timeCubed);
        }

        #endregion

        #region Naughter - Aproximation J2000
        /// <summary>
        /// Uranus the mean longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusMeanLongitudeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(314.055005 + 428.4669983 * timeT - 0.00000486 * timeSquared + 0.000000006 * timeCubed);
        }

        /// <summary>
        /// Uranus the inclination J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusInclinationJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(0.773197 - 0.0016869 * timeT + 0.00000349 * timeSquared + 0.000000016 * timeCubed);
        }

        /// <summary>
        /// Uranus the longitude ascending node J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusLongitudeAscendingNodeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(74.005957 + 0.0741431 * timeT + 0.00040539 * timeSquared + 0.000000119 * timeCubed);
        }

        /// <summary>
        /// Uranus the longitude perihelion J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusLongitudePerihelionJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(173.005291 + 0.0893212 * timeT - 0.00009470 * timeSquared + 0.000000414 * timeCubed);
        }

        #endregion

        #region Naughter - Magnitude
        /// <summary>
        /// Uranus the magnitude muller.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double UranusMagnitudeMuller(double givenParameter, double givenDelta) {
            return -6.85 + 5 * Math.Log10(givenParameter * givenDelta);
        }

        /// <summary>
        /// Uranus the magnitude AA.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double UranusMagnitudeAA(double givenParameter, double givenDelta) {
            return -7.19 + 5 * Math.Log10(givenParameter * givenDelta);
        }
        #endregion

        #region Naughter
        /// <summary>
        /// Uranus the semidiameter A.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusSemidiameterA(double givenDelta) {
            return 34.28 / givenDelta;
        }

        /// <summary>
        /// Uranus the semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double UranusSemidiameterB(double givenDelta) {
            return 35.02 / givenDelta;
        }

        /// <summary>
        /// Ecliptic longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double EclipticLongitude(double julianDay) {
            var rho = (julianDay - 2451545) / 365250;
            var rhoSquared = rho * rho;
            var rhoCubed = rhoSquared * rho;
            var rho4 = rhoCubed * rho;

            //// Calculate L0
            double l0 = 0;
            int i;
            for (i = 0; i < OrbitalData.VsopData.L0UranusCoefficients.Length; i++) {
                l0 += OrbitalData.VsopData.L0UranusCoefficients[i].A *
                      Math.Cos(OrbitalData.VsopData.L0UranusCoefficients[i].B + OrbitalData.VsopData.L0UranusCoefficients[i].C * rho);
            }

            //// Calculate L1
            double l1 = 0;
            for (i = 0; i < OrbitalData.VsopData.L1UranusCoefficients.Length; i++) {
                l1 += OrbitalData.VsopData.L1UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L1UranusCoefficients[i].B + OrbitalData.VsopData.L1UranusCoefficients[i].C * rho);
            }

            //// Calculate L2
            double l2 = 0;
            for (i = 0; i < OrbitalData.VsopData.L2UranusCoefficients.Length; i++) {
                l2 += OrbitalData.VsopData.L2UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L2UranusCoefficients[i].B + OrbitalData.VsopData.L2UranusCoefficients[i].C * rho);
            }

            //// Calculate L3
            double l3 = 0;
            for (i = 0; i < OrbitalData.VsopData.L3UranusCoefficients.Length; i++) {
                l3 += OrbitalData.VsopData.L3UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L3UranusCoefficients[i].B + OrbitalData.VsopData.L3UranusCoefficients[i].C * rho);
            }

            //// Calculate L4
            double l4 = 0;
            for (i = 0; i < OrbitalData.VsopData.L4UranusCoefficients.Length; i++) {
                l4 += OrbitalData.VsopData.L4UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L4UranusCoefficients[i].B + OrbitalData.VsopData.L4UranusCoefficients[i].C * rho);
            }

            var value = (l0 + l1 * rho + l2 * rhoSquared + l3 * rhoCubed + l4 * rho4) / 100000000;

            //// convert results back to degrees
            value = Angles.Mod360(Angles.RadDeg(value));
            return value;
        }

        /// <summary>
        /// Ecliptic latitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double EclipticLatitude(double julianDay) {
            var rho = (julianDay - 2451545) / 365250;
            var rhoSquared = rho * rho;
            var rhoCubed = rhoSquared * rho;
            var rho4 = rhoCubed * rho;

            //// Calculate B0
            double b0 = 0;
            int i;
            for (i = 0; i < OrbitalData.VsopData.B0UranusCoefficients.Length; i++) {
                b0 += OrbitalData.VsopData.B0UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B0UranusCoefficients[i].B + OrbitalData.VsopData.B0UranusCoefficients[i].C * rho);
            }

            //// Calculate B1
            double b1 = 0;
            for (i = 0; i < OrbitalData.VsopData.B1UranusCoefficients.Length; i++) {
                b1 += OrbitalData.VsopData.B1UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B1UranusCoefficients[i].B + OrbitalData.VsopData.B1UranusCoefficients[i].C * rho);
            }

            //// Calculate B2
            double b2 = 0;
            for (i = 0; i < OrbitalData.VsopData.B2UranusCoefficients.Length; i++) {
                b2 += OrbitalData.VsopData.B2UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B2UranusCoefficients[i].B + OrbitalData.VsopData.B2UranusCoefficients[i].C * rho);
            }

            //// Calculate B3
            double b3 = 0;
            for (i = 0; i < OrbitalData.VsopData.B3UranusCoefficients.Length; i++) {
                b3 += OrbitalData.VsopData.B3UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B3UranusCoefficients[i].B + OrbitalData.VsopData.B3UranusCoefficients[i].C * rho);
            }

            //// Calculate B4
            double b4 = 0;
            for (i = 0; i < OrbitalData.VsopData.B4UranusCoefficients.Length; i++) {
                b4 += OrbitalData.VsopData.B4UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B4UranusCoefficients[i].B + OrbitalData.VsopData.B4UranusCoefficients[i].C * rho);
            }

            var value = (b0 + b1 * rho + b2 * rhoSquared + b3 * rhoCubed + b4 * rho4) / 100000000;

            //// convert results back to degrees
            value = Angles.RadDeg(value);
            return value;
        }

        /// <summary>
        /// Radius vector.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double RadiusVector(double julianDay) {
            var rho = (julianDay - 2451545) / 365250;
            var rhoSquared = rho * rho;
            var rhoCubed = rhoSquared * rho;
            var rho4 = rhoCubed * rho;

            //// Calculate R0
            double r0 = 0;
            int i;
            for (i = 0; i < OrbitalData.VsopData.R0UranusCoefficients.Length; i++) {
                r0 += OrbitalData.VsopData.R0UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R0UranusCoefficients[i].B + OrbitalData.VsopData.R0UranusCoefficients[i].C * rho);
            }

            //// Calculate R1
            double r1 = 0;
            for (i = 0; i < OrbitalData.VsopData.R1UranusCoefficients.Length; i++) {
                r1 += OrbitalData.VsopData.R1UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R1UranusCoefficients[i].B + OrbitalData.VsopData.R1UranusCoefficients[i].C * rho);
            }

            //// Calculate R2
            double r2 = 0;
            for (i = 0; i < OrbitalData.VsopData.R2UranusCoefficients.Length; i++) {
                r2 += OrbitalData.VsopData.R2UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R2UranusCoefficients[i].B + OrbitalData.VsopData.R2UranusCoefficients[i].C * rho);
            }

            //// Calculate R3
            double r3 = 0;
            for (i = 0; i < OrbitalData.VsopData.R3UranusCoefficients.Length; i++) {
                r3 += OrbitalData.VsopData.R3UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R3UranusCoefficients[i].B + OrbitalData.VsopData.R3UranusCoefficients[i].C * rho);
            }

            //// Calculate R4
            double r4 = 0;
            for (i = 0; i < OrbitalData.VsopData.R4UranusCoefficients.Length; i++) {
                r4 += OrbitalData.VsopData.R4UranusCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R4UranusCoefficients[i].B + OrbitalData.VsopData.R4UranusCoefficients[i].C * rho);
            }

            return (r0 + r1 * rho + r2 * rhoSquared + r3 * rhoCubed + r4 * rho4) / 100000000;
        }

        #endregion

        #region Naughter - Phenomena
        /// <summary>
        /// Planetary phenomena delta.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="anomalyM">The anomalyM.</param>
        /// <param name="timeT">The T.</param>
        /// <param name="timeT2">The t2.</param>
        /// <returns> Returns value. </returns>
        public static double PlanetaryPhenomenaDelta(EventType type, double anomalyM, double timeT, double timeT2) {
            var e = Angles.Mod360(207.83 + 8.51 * timeT);
            e = Angles.DegRad(e);
            var f = Angles.Mod360(108.84 + 419.96 * timeT);
            f = Angles.DegRad(f);
            double delta;
            if (type == EventType.Opposition) {
                delta = (0.0844 - 0.0006 * timeT) +
                        Math.Sin(anomalyM) * (-0.1048 + 0.0246 * timeT) +
                        Math.Cos(anomalyM) * (-5.1221 + 0.0104 * timeT + 0.00003 * timeT2) +
                        Math.Sin(2 * anomalyM) * (-0.1428 - 0.0005 * timeT) +
                        Math.Cos(2 * anomalyM) * (-0.0148 - 0.0013 * timeT) +
                        Math.Cos(3 * anomalyM) * 0.0055 +
                        Math.Cos(e) * 0.8850 +
                        Math.Cos(f) * 0.2153;
            }
            else {
                Debug.Assert(type == EventType.Conjunction, "Reason for the assert");

                delta = (-0.0859 + 0.0003 * timeT) +
                        Math.Sin(anomalyM) * (-3.8179 - 0.0148 * timeT + 0.00003 * timeT2) +
                        Math.Cos(anomalyM) * (5.1228 - 0.0105 * timeT - 0.00002 * timeT2) +
                        Math.Sin(2 * anomalyM) * (-0.0803 + 0.0011 * timeT) +
                        Math.Cos(2 * anomalyM) * (-0.1905 - 0.0006 * timeT) +
                        Math.Sin(3 * anomalyM) * (0.0088 + 0.0001 * timeT) +
                        Math.Cos(e) * 0.8850 +
                        Math.Cos(f) * 0.2153;
            }

            return delta;
        }
        #endregion

        /// <summary>
        /// Schlyter or Chapront.
        /// </summary>
        public override void Init() {
            switch (this.Variant) {
                case AlgVariant.VarBretagnon82: {
                        this.InitBretagnon82();
                        break;
                    }

                case AlgVariant.VarBretagnon87: {
                        this.InitBretagnon87(Systems.SystemManager.VsopPath);
                        break;
                    }

                case AlgVariant.VarSchlyter: {
                        this.InitSchlyter();
                        break;
                    }

                case AlgVariant.None:
                    break;
                case AlgVariant.VarChapront:
                    break;
                case AlgVariant.VarNormal:
                    break;
                case AlgVariant.VarMeeus:
                    break;
                case AlgVariant.VarNaughter:
                    break;
                //// Resharper default: break;
            }
        }

        #region Initializers
        /// <summary>
        /// Init Schlyter.
        /// </summary>
        private void InitSchlyter() {
            this.Time.EpochOrbit = 2451543.5; 
            this.Time.EpochEquinox = 2451543.5;
            double[] lw = { 74.0005, 1.3978e-5, 0.0, 0.0 };
            double[] i = { 0.7733, 1.9e-8, 0.0, 0.0 };
            double[] w = { 96.6612, 3.0565e-5, 0.0, 0.0 };
            double[] a = { 19.18171 * AstroMath.AstroUnit, -1.55e-8, 0.0, 0.0 };
            double[] e = { 0.047318, 7.45e-9, 0.0, 0.0 };
            double[] vm = { 142.5905, 0.011725806, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }

        /// <summary>
        /// Init Bretagnon82.
        /// </summary>
        private void InitBretagnon82() {
            this.Time.EpochOrbit = 2451545; 
            this.Time.EpochEquinox = 2451545;
            double[] a = { 19.218446 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] lm = { 5.4812940, 7.4781600000, 0.00, 0.0 };
            double[] k = { -4.595100e-2, 1.800e-5, 0.00, 0.0 };
            double[] h = { 5.638000e-3, -7.500e-5, 0.00, 0.0 };
            double[] q = { 1.859000e-3, -1.200e-5, 0.00, 0.0 };
            double[] p = { 6.486000e-3, -1.200e-5, 0.00, 0.0 };
            this.BretElements = new BretagnonElements(a, lm, k, h, q, p);
        }

        /// <summary>
        /// Init Bretagnon 87.
        /// </summary>
        /// <param name="givenVsopPath">The given Vsop path.</param>
        private void InitBretagnon87(string givenVsopPath) {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            this.Vsop87.InitWith(givenVsopPath + "Vsop87.URA", 0.0);
        }

        #endregion

        #region Perturbations
        /// <summary>
        /// Perturbate Schlyter Longitude.
        /// </summary>
        [UsedImplicitly]
        private void PerturbateSchlyterLongitude() {
            /* 2018
            var j = SolarSystem.Singleton.Jupiter.VM;
            var s = SolarSystem.Singleton.Saturn.VM;
            var u = SolarSystem.Singleton.Uranus.VM;
            var dLongitude = +(0.040 * Angles.Sinus(s - (2 * u) + 6.0))
                       + (0.035 * Angles.Sinus(s - (3 * u) + 33.0))
                       - (0.015 * Angles.Sinus(j - u + 20.0));
            this.Point.Longitude = this.Point.Longitude + dLongitude;
            */
        }
        #endregion
    }
}
