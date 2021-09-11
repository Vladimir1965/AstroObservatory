// <copyright file="BodyMars.cs" company="Traced-Ideas, Czech republic">
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
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.Systems;
    using JetBrains.Annotations;

    /// <summary>
    /// Initializes a new instance of the BodyMars class.
    /// </summary>
    public sealed class BodyMars : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyMars"/> class.
        /// </summary>
        public BodyMars()
            : base("R", "Mars") {
            this.PerTime = 1969.802234;      ////
            this.Body.Mass = 0.6419e24;           //// [kg]
            this.Body.Radius = 3.393e6;           //// [m]
            this.Body.J = 23.98;                   //// // [deg]
            this.Knke = 10;                   //// // 5
        }

        #region Naughter - PerihelionAphelion
        /// <summary>
        /// Marses the K.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static long MarsK(double year) {
            return (long)(0.53166 * (year - 2001.78));
        }

        /// <summary>
        /// Marses the perihelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusPerihelion(long givenK) {
            double kdash = givenK;
            var kSquared = kdash * kdash;
            return 2452195.026 + 686.9957857 * kdash - 0.0000001187 * kSquared;
        }

        /// <summary>
        /// Marses the aphelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusAphelion(long givenK) {
            var kdash = givenK + 0.5;
            var kSquared = kdash * kdash;
            return 2452195.026 + 686.9957857 * kdash - 0.0000001187 * kSquared;
        }
        #endregion

        #region Naughter - Aproximation

        /// <summary>
        /// Marses the mean longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsMeanLongitude(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(355.433000 + 19141.6964471 * timeT + 0.00031052 * timeSquared + 0.000000016 * timeCubed);
        }

        /// <summary>
        /// Marses the semimajor axis.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsSemimajorAxis() {
            return 1.523679342;
        }

        /// <summary>
        /// Marses the eccentricity.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsEccentricity(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return 0.09340065 + 0.000090484 * timeT - 0.0000000806 * timeSquared - 0.00000000025 * timeCubed;
        }

        /// <summary>
        /// Marses the inclination.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsInclination(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(1.849726 - 0.0006011 * timeT + 0.00001276 * timeSquared - 0.000000007 * timeCubed);
        }

        /// <summary>
        /// Marses the longitude ascending node.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsLongitudeAscendingNode(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(49.588093 + 0.7720959 * timeT + 0.00001557 * timeSquared + 0.000002267 * timeCubed);
        }

        /// <summary>
        /// Marses the longitude perihelion.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsLongitudePerihelion(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(336.060234 + 1.8410449 * timeT + 0.00013477 * timeSquared + 0.000000536 * timeCubed);
        }

        #endregion

        #region Naughter - Aproximation J2000
        /// <summary>
        /// Marses the mean longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsMeanLongitudeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(355.433000 + 19140.2993039 * timeT + 0.00000262 * timeSquared - 0.000000003 * timeCubed);
        }

        /// <summary>
        /// Marses the inclination J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsInclinationJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(1.849726 - 0.0081477 * timeT - 0.00002255 * timeSquared - 0.000000029 * timeCubed);
        }

        /// <summary>
        /// Marses the longitude ascending node J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsLongitudeAscendingNodeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(49.588093 - 0.2950250 * timeT - 0.00064048 * timeSquared - 0.000001964 * timeCubed);
        }

        /// <summary>
        /// Marses the longitude perihelion J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsLongitudePerihelionJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(336.060234 + 0.4439016 * timeT - 0.00017313 * timeSquared + 0.000000518 * timeCubed);
        }

        #endregion

        #region Naughter - Magnitude
        /// <summary>
        /// Marses the magnitude muller.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <param name="i">The i.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double MarsMagnitudeMuller(double givenParameter, double givenDelta, double i) {
            return -1.3 + 5 * Math.Log10(givenParameter * givenDelta) + 0.01486 * i;
        }

        /// <summary>
        /// Marses the magnitude AA.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <param name="i">The i.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double MarsMagnitudeAA(double givenParameter, double givenDelta, double i) {
            return -1.52 + 5 * Math.Log10(givenParameter * givenDelta) + 0.016 * i;
        }
        #endregion

        #region Naughter
        /// <summary>
        /// Marses the semidiameter A.
        /// </summary>
        /// <param name="delta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsSemidiameterA(double delta) {
            return 4.68 / delta;
        }

        /// <summary>
        /// Marses the semidiameter B.
        /// </summary>
        /// <param name="delta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MarsSemidiameterB(double delta) {
            return 4.68 / delta;
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
            var rho5 = rho4 * rho;

            //// Calculate L0
            double l0 = 0;
            int i;
            for (i = 0; i < OrbitalData.VsopData.L0MarsCoefficients.Length; i++) {
                l0 += OrbitalData.VsopData.L0MarsCoefficients[i].A *
                      Math.Cos(OrbitalData.VsopData.L0MarsCoefficients[i].B + OrbitalData.VsopData.L0MarsCoefficients[i].C * rho);
            }

            //// Calculate L1
            double l1 = 0;
            for (i = 0; i < OrbitalData.VsopData.L1MarsCoefficients.Length; i++) {
                l1 += OrbitalData.VsopData.L1MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L1MarsCoefficients[i].B + OrbitalData.VsopData.L1MarsCoefficients[i].C * rho);
            }

            //// Calculate L2
            double l2 = 0;
            for (i = 0; i < OrbitalData.VsopData.L2MarsCoefficients.Length; i++) {
                l2 += OrbitalData.VsopData.L2MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L2MarsCoefficients[i].B + OrbitalData.VsopData.L2MarsCoefficients[i].C * rho);
            }

            //// Calculate L3
            double l3 = 0;
            for (i = 0; i < OrbitalData.VsopData.L3MarsCoefficients.Length; i++) {
                l3 += OrbitalData.VsopData.L3MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L3MarsCoefficients[i].B + OrbitalData.VsopData.L3MarsCoefficients[i].C * rho);
            }

            //// Calculate L4
            double l4 = 0;
            for (i = 0; i < OrbitalData.VsopData.L4MarsCoefficients.Length; i++) {
                l4 += OrbitalData.VsopData.L4MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L4MarsCoefficients[i].B + OrbitalData.VsopData.L4MarsCoefficients[i].C * rho);
            }

            //// Calculate L5
            double l5 = 0;
            for (i = 0; i < OrbitalData.VsopData.L5MarsCoefficients.Length; i++) {
                l5 += OrbitalData.VsopData.L5MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L5MarsCoefficients[i].B + OrbitalData.VsopData.L5MarsCoefficients[i].C * rho);
            }

            var value = (l0 + l1 * rho + l2 * rhoSquared + l3 * rhoCubed + l4 * rho4 + l5 * rho5) / 100000000;

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
            for (i = 0; i < OrbitalData.VsopData.B0MarsCoefficients.Length; i++) {
                b0 += OrbitalData.VsopData.B0MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B0MarsCoefficients[i].B + OrbitalData.VsopData.B0MarsCoefficients[i].C * rho);
            }

            //// Calculate B1
            double b1 = 0;
            for (i = 0; i < OrbitalData.VsopData.B1MarsCoefficients.Length; i++) {
                b1 += OrbitalData.VsopData.B1MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B1MarsCoefficients[i].B + OrbitalData.VsopData.B1MarsCoefficients[i].C * rho);
            }

            //// Calculate B2
            double b2 = 0;
            for (i = 0; i < OrbitalData.VsopData.B2MarsCoefficients.Length; i++) {
                b2 += OrbitalData.VsopData.B2MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B2MarsCoefficients[i].B + OrbitalData.VsopData.B2MarsCoefficients[i].C * rho);
            }

            //// Calculate B3
            double b3 = 0;
            for (i = 0; i < OrbitalData.VsopData.B3MarsCoefficients.Length; i++) {
                b3 += OrbitalData.VsopData.B3MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B3MarsCoefficients[i].B + OrbitalData.VsopData.B3MarsCoefficients[i].C * rho);
            }

            //// Calculate B4
            double b4 = 0;
            for (i = 0; i < OrbitalData.VsopData.B4MarsCoefficients.Length; i++) {
                b4 += OrbitalData.VsopData.B4MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B4MarsCoefficients[i].B + OrbitalData.VsopData.B4MarsCoefficients[i].C * rho);
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
            for (i = 0; i < OrbitalData.VsopData.R0MarsCoefficients.Length; i++) {
                r0 += OrbitalData.VsopData.R0MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R0MarsCoefficients[i].B + OrbitalData.VsopData.R0MarsCoefficients[i].C * rho);
            }

            //// Calculate R1
            double r1 = 0;
            for (i = 0; i < OrbitalData.VsopData.R1MarsCoefficients.Length; i++) {
                r1 += OrbitalData.VsopData.R1MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R1MarsCoefficients[i].B + OrbitalData.VsopData.R1MarsCoefficients[i].C * rho);
            }

            //// Calculate R2
            double r2 = 0;
            for (i = 0; i < OrbitalData.VsopData.R2MarsCoefficients.Length; i++) {
                r2 += OrbitalData.VsopData.R2MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R2MarsCoefficients[i].B + OrbitalData.VsopData.R2MarsCoefficients[i].C * rho);
            }

            //// Calculate R3
            double r3 = 0;
            for (i = 0; i < OrbitalData.VsopData.R3MarsCoefficients.Length; i++) {
                r3 += OrbitalData.VsopData.R3MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R3MarsCoefficients[i].B + OrbitalData.VsopData.R3MarsCoefficients[i].C * rho);
            }

            //// Calculate R4
            double r4 = 0;
            for (i = 0; i < OrbitalData.VsopData.R4MarsCoefficients.Length; i++) {
                r4 += OrbitalData.VsopData.R4MarsCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R4MarsCoefficients[i].B + OrbitalData.VsopData.R4MarsCoefficients[i].C * rho);
            }

            return (r0 + r1 * rho + r2 * rhoSquared + r3 * rhoCubed + r4 * rho4) / 100000000;
        }

        #endregion

        #region Naughter - Phenomena
        /// <summary>
        /// Planetary phenomena delta.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="anomalyM">The M.</param>
        /// <param name="timeT">The T.</param>
        /// <param name="timeT2">The time t2.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double PlanetaryPhenomenaDelta(EventType type, double anomalyM, double timeT, double timeT2) {
            double delta;

            switch (type) {
                case EventType.Opposition:
                    delta = (-0.3088 + 0.00002 * timeT2) +
                            Math.Sin(anomalyM) * (-17.6965 + 0.0363 * timeT + 0.00005 * timeT2) +
                            Math.Cos(anomalyM) * (18.3131 + 0.0467 * timeT - 0.00006 * timeT2) +
                            Math.Sin(2 * anomalyM) * (-0.2162 - 0.0198 * timeT - 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (-4.5028 - 0.0019 * timeT + 0.00007 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.8987 + 0.0058 * timeT - 0.00002 * timeT2) +
                            Math.Cos(3 * anomalyM) * (0.7666 - 0.0050 * timeT - 0.00003 * timeT2) +
                            Math.Sin(4 * anomalyM) * (-0.3636 - 0.0001 * timeT + 0.00002 * timeT2) +
                            Math.Cos(4 * anomalyM) * (0.0402 + 0.0032 * timeT) +
                            Math.Sin(5 * anomalyM) * (0.0737 - 0.0008 * timeT) +
                            Math.Cos(5 * anomalyM) * (-0.0980 - 0.0011 * timeT);
                    break;
                case EventType.Conjunction:
                    delta = (0.3102 - 0.0001 * timeT + 0.00001 * timeT2) +
                            Math.Sin(anomalyM) * (9.7273 - 0.0156 * timeT + 0.00001 * timeT2) +
                            Math.Cos(anomalyM) * (-18.3195 - 0.0467 * timeT + 0.00009 * timeT2) +
                            Math.Sin(2 * anomalyM) * (-1.6488 - 0.0133 * timeT + 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (-2.6117 - 0.0020 * timeT + 0.00004 * timeT2) +
                            Math.Sin(3 * anomalyM) * (-0.6827 - 0.0026 * timeT + 0.00001 * timeT2) +
                            Math.Cos(3 * anomalyM) * (0.0281 + 0.0035 * timeT + 0.00001 * timeT2) +
                            Math.Sin(4 * anomalyM) * (-0.0823 + 0.0006 * timeT + 0.00001 * timeT2) +
                            Math.Cos(4 * anomalyM) * (0.1584 + 0.0013 * timeT) +
                            Math.Sin(5 * anomalyM) * (0.0270 + 0.0005 * timeT) +
                            Math.Cos(5 * anomalyM) * 0.0433;
                    break;
                case EventType.Station1:
                    delta = (-37.0790 - 0.0009 * timeT + 0.00002 * timeT2) +
                            Math.Sin(anomalyM) * (-20.0651 + 0.0228 * timeT + 0.00004 * timeT2) +
                            Math.Cos(anomalyM) * (14.5205 + 0.0504 - 0.00001 * timeT2) +
                            Math.Sin(2 * anomalyM) * (1.1737 - 0.0169 * timeT) +
                            Math.Cos(2 * anomalyM) * (-4.2550 - 0.0075 * timeT + 0.00008 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.4897 + 0.0074 * timeT - 0.00001 * timeT2) +
                            Math.Cos(3 * anomalyM) * (1.1151 - 0.0021 * timeT - 0.00005 * timeT2) +
                            Math.Sin(4 * anomalyM) * (-0.3636 - 0.0020 * timeT + 0.00001 * timeT2) +
                            Math.Cos(4 * anomalyM) * (-0.1769 + 0.0028 * timeT + 0.00002 * timeT2) +
                            Math.Sin(5 * anomalyM) * (0.1437 - 0.0004 * timeT) +
                            Math.Cos(5 * anomalyM) * (-0.0383 - 0.0016 * timeT);
                    break;
                default:
                    Debug.Assert(type == EventType.Station2, "Reason for the assert");
                    delta = (36.7191 + 0.0016 * timeT + 0.00003 * timeT2) +
                            Math.Sin(anomalyM) * (-12.6163 + 0.0417 * timeT - 0.00001 * timeT2) +
                            Math.Cos(anomalyM) * (20.1218 + 0.0379 * timeT - 0.00006 * timeT2) +
                            Math.Sin(2 * anomalyM) * (-1.6360 - 0.0190 * timeT) +
                            Math.Cos(2 * anomalyM) * (-3.9657 + 0.0045 * timeT + 0.00007 * timeT2) +
                            Math.Sin(3 * anomalyM) * (1.1546 + 0.0029 * timeT - 0.00003 * timeT2) +
                            Math.Cos(3 * anomalyM) * (0.2888 - 0.0073 * timeT - 0.00002 * timeT2) +
                            Math.Sin(4 * anomalyM) * (-0.3128 + 0.0017 * timeT + 0.00002 * timeT2) +
                            Math.Cos(4 * anomalyM) * (0.2513 + 0.0026 * timeT - 0.00002 * timeT2) +
                            Math.Sin(5 * anomalyM) * (-0.0021 - 0.0016 * timeT) +
                            Math.Cos(5 * anomalyM) * (-0.1497 - 0.0006 * timeT);
                    break;
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
                        this.InitBretagnon87(SystemManager.VsopPath);
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
            double[] lw = { 49.5574, 2.11081e-5, 0.0, 0.0 };
            double[] i = { 1.8497, -1.78e-8, 0.0, 0.0 };
            double[] w = { 286.5016, 2.92961e-5, 0.0, 0.0 };
            double[] a = { 1.523688 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] e = { 0.093405, 2.516e-9, 0.0, 0.0 };
            double[] vm = { 18.6021, 0.5240207766, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }

        /// <summary>
        /// BRETAGNON Vsop82.
        /// </summary>
        private void InitBretagnon82() {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            double[] a = { 1.5236793 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] lm = { 6.2034809, 334.06124310, 0.0, 0.0 };
            double[] k = { 8.536560e-2, 3.763e-4, -25e-7, 0.0 };
            double[] h = { -3.789970e-2, 6.247e-4, 16e-7, 0.0 };
            double[] q = { 1.047040e-2, 1.710e-5, -4e-7, 0.0 };
            double[] p = { 1.228450e-2, -1.080e-4, -2e-7, 0.0 };
            this.BretElements = new BretagnonElements(a, lm, k, h, q, p);
        }

        /// <summary>
        /// BRETAGNON Vsop87.
        /// </summary>
        /// <param name="givenVsopPath">The given Vsop path.</param>
        private void InitBretagnon87(string givenVsopPath) {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            this.Vsop87.InitWith(givenVsopPath + "Vsop87.MAR", 0.0);
        }
        #endregion
    }
}
