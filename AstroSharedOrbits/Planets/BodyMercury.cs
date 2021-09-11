// <copyright file="BodyMercury.cs" company="Traced-Ideas, Czech republic">
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
    /// Initializes a new instance of the BodyMercury class.
    /// </summary>
    public sealed class BodyMercury : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyMercury"/> class.
        /// </summary>
        public BodyMercury()
            : base("M", "Mercury") {
            this.PerTime = 1970.980204;      ////
            this.Body.Mass = 0.3302e24;           //// [kg]
            this.Body.Radius = 2.439e6;           //// [m]
            this.Body.J = 2.000;                   //// // [deg]
            this.Knke = 10;                   //// 5
        }

        #region Naughter - PerihelionAphelion
        /// <summary>
        /// Mercuries the K.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static long MercuryK(double year) {
            return (long)(4.15201 * (year - 2000.12));
        }

        /// <summary>
        /// Mercuries the perihelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusPerihelion(long givenK) {
            return 2451590.257 + 87.96934963 * givenK;
        }

        /// <summary>
        /// Mercuries the aphelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusAphelion(long givenK) {
            var kdash = givenK + 0.5;
            return 2451590.257 + 87.96934963 * kdash;
        }
        #endregion

        #region Naughter - Aproximation
        /// <summary>
        /// Mercuries the mean longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercuryMeanLongitude(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(252.250906 + 149474.0722491 * timeT + 0.00030350 * timeSquared + 0.000000018 * timeCubed);
        }

        /// <summary>
        /// Mercuries the semimajor axis.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercurySemimajorAxis() {
            return 0.387098310;
        }

        /// <summary>
        /// Mercuries the eccentricity.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercuryEccentricity(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return 0.20563175 + 0.000020407 * timeT - 0.0000000283 * timeSquared - 0.00000000018 * timeCubed;
        }

        /// <summary>
        /// Mercuries the inclination.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercuryInclination(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(7.004986 + 0.0018215 * timeT - 0.00001810 * timeSquared + 0.000000056 * timeCubed);
        }

        /// <summary>
        /// Mercuries the longitude ascending node.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercuryLongitudeAscendingNode(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(48.330893 + 1.1861883 * timeT + 0.00017542 * timeSquared + 0.000000215 * timeCubed);
        }

        /// <summary>
        /// Mercuries the longitude perihelion.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercuryLongitudePerihelion(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(77.456119 + 1.5564776 * timeT + 0.00029544 * timeSquared + 0.000000009 * timeCubed);
        }
        #endregion

        #region Naughter - Aproximation J2000

        /// <summary>
        /// Mercuries the mean longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercuryMeanLongitudeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(252.250906 + 149472.6746358 * timeT - 0.00000536 * timeSquared + 0.000000002 * timeCubed);
        }

        /// <summary>
        /// Mercuries the inclination J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercuryInclinationJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(7.004986 - 0.0059516 * timeT + 0.00000080 * timeSquared + 0.000000043 * timeCubed);
        }

        /// <summary>
        /// Mercuries the longitude ascending node J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercuryLongitudeAscendingNodeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(48.330893 - 0.1254227 * timeT - 0.00008833 * timeSquared - 0.000000200 * timeCubed);
        }

        /// <summary>
        /// Mercuries the longitude perihelion J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercuryLongitudePerihelionJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(77.456119 + 0.1588643 * timeT - 0.00001342 * timeSquared - 0.000000007 * timeCubed);
        }

        #endregion

        #region Naughter - Magnitude
        /// <summary>
        /// Mercuries the magnitude muller.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <param name="i">The i.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double MercuryMagnitudeMuller(double givenParameter, double givenDelta, double i) {
            var i50 = i - 50;
            return 1.16 + 5 * Math.Log10(givenParameter * givenDelta) + 0.02838 * i50 + 0.0001023 * i50 * i50;
        }

        /// <summary>
        /// Mercuries the magnitude AA.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <param name="i">The given i.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double MercuryMagnitudeAA(double givenParameter, double givenDelta, double i) {
            var i2 = i * i;
            var i3 = i2 * i;

            return -0.42 + 5 * Math.Log10(givenParameter * givenDelta) + 0.0380 * i - 0.000273 * i2 + 0.000002 * i3;
        }
        #endregion

        #region Naughter
        /// <summary>
        /// Mercuries the semidiameter A.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercurySemidiameterA(double givenDelta) {
            return 3.34 / givenDelta;
        }

        /// <summary>
        /// Mercuries the semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MercurySemidiameterB(double givenDelta) {
            return 3.36 / givenDelta;
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
            for (i = 0; i < OrbitalData.VsopData.L0MercuryCoefficients.Length; i++) {
                l0 += OrbitalData.VsopData.L0MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L0MercuryCoefficients[i].B + OrbitalData.VsopData.L0MercuryCoefficients[i].C * rho);
            }

            //// Calculate L1
            double l1 = 0;
            for (i = 0; i < OrbitalData.VsopData.L1MercuryCoefficients.Length; i++) {
                l1 += OrbitalData.VsopData.L1MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L1MercuryCoefficients[i].B + OrbitalData.VsopData.L1MercuryCoefficients[i].C * rho);
            }

            //// Calculate L2
            double l2 = 0;
            for (i = 0; i < OrbitalData.VsopData.L2MercuryCoefficients.Length; i++) {
                l2 += OrbitalData.VsopData.L2MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L2MercuryCoefficients[i].B + OrbitalData.VsopData.L2MercuryCoefficients[i].C * rho);
            }

            //// Calculate L3
            double l3 = 0;
            for (i = 0; i < OrbitalData.VsopData.L3MercuryCoefficients.Length; i++) {
                l3 += OrbitalData.VsopData.L3MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L3MercuryCoefficients[i].B + OrbitalData.VsopData.L3MercuryCoefficients[i].C * rho);
            }

            //// Calculate L4
            double l4 = 0;
            for (i = 0; i < OrbitalData.VsopData.L4MercuryCoefficients.Length; i++) {
                l4 += OrbitalData.VsopData.L4MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L4MercuryCoefficients[i].B + OrbitalData.VsopData.L4MercuryCoefficients[i].C * rho);
            }

            //// Calculate L5
            double l5 = 0;
            for (i = 0; i < OrbitalData.VsopData.L5MercuryCoefficients.Length; i++) {
                l5 += OrbitalData.VsopData.L5MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L5MercuryCoefficients[i].B + OrbitalData.VsopData.L5MercuryCoefficients[i].C * rho);
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
            for (i = 0; i < OrbitalData.VsopData.B0MercuryCoefficients.Length; i++) {
                b0 += OrbitalData.VsopData.B0MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B0MercuryCoefficients[i].B + OrbitalData.VsopData.B0MercuryCoefficients[i].C * rho);
            }

            //// Calculate B1
            double b1 = 0;
            for (i = 0; i < OrbitalData.VsopData.B1MercuryCoefficients.Length; i++) {
                b1 += OrbitalData.VsopData.B1MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B1MercuryCoefficients[i].B + OrbitalData.VsopData.B1MercuryCoefficients[i].C * rho);
            }

            //// Calculate B2
            double b2 = 0;
            for (i = 0; i < OrbitalData.VsopData.B2MercuryCoefficients.Length; i++) {
                b2 += OrbitalData.VsopData.B2MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B2MercuryCoefficients[i].B + OrbitalData.VsopData.B2MercuryCoefficients[i].C * rho);
            }

            //// Calculate B3
            double b3 = 0;
            for (i = 0; i < OrbitalData.VsopData.B3MercuryCoefficients.Length; i++) {
                b3 += OrbitalData.VsopData.B3MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B3MercuryCoefficients[i].B + OrbitalData.VsopData.B3MercuryCoefficients[i].C * rho);
            }

            //// Calculate B4
            double b4 = 0;
            for (i = 0; i < OrbitalData.VsopData.B4MercuryCoefficients.Length; i++) {
                b4 += OrbitalData.VsopData.B4MercuryCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B4MercuryCoefficients[i].B + OrbitalData.VsopData.B4MercuryCoefficients[i].C * rho);
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

            //// Calculate R0
            double r0 = 0;
            int i;
            for (i = 0; i < OrbitalData.VsopData.R0MercuryCoefficients.Length; i++) {
                r0 += OrbitalData.VsopData.R0MercuryCoefficients[i].A *
                      Math.Cos(OrbitalData.VsopData.R0MercuryCoefficients[i].B + OrbitalData.VsopData.R0MercuryCoefficients[i].C * rho);
            }

            //// Calculate R1
            double r1 = 0;
            for (i = 0; i < OrbitalData.VsopData.R1MercuryCoefficients.Length; i++) {
                r1 += OrbitalData.VsopData.R1MercuryCoefficients[i].A *
                      Math.Cos(OrbitalData.VsopData.R1MercuryCoefficients[i].B + OrbitalData.VsopData.R1MercuryCoefficients[i].C * rho);
            }

            //// Calculate R2
            double r2 = 0;
            for (i = 0; i < OrbitalData.VsopData.R2MercuryCoefficients.Length; i++) {
                r2 += OrbitalData.VsopData.R2MercuryCoefficients[i].A *
                      Math.Cos(OrbitalData.VsopData.R2MercuryCoefficients[i].B + OrbitalData.VsopData.R2MercuryCoefficients[i].C * rho);
            }

            //// Calculate R3
            double r3 = 0;
            for (i = 0; i < OrbitalData.VsopData.R3MercuryCoefficients.Length; i++) {
                r3 += OrbitalData.VsopData.R3MercuryCoefficients[i].A *
                      Math.Cos(OrbitalData.VsopData.R3MercuryCoefficients[i].B + OrbitalData.VsopData.R3MercuryCoefficients[i].C * rho);
            }

            return (r0 + r1 * rho + r2 * rhoSquared + r3 * rhoCubed) / 100000000;
        }

        #endregion

        #region Naughter - Phenomena
        /// <summary>
        /// Planetary phenomena delta.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="anomalyM">The M.</param>
        /// <param name="timeT">The T.</param>
        /// <param name="timeT2">The t2.</param>
        /// <returns> Returns value. </returns>
        public static double PlanetaryPhenomenaDelta(EventType type, double anomalyM, double timeT, double timeT2) {
            double delta;
            switch (type) {
                case EventType.InferiorConjunction:
                    delta = (0.0545 + 0.0002 * timeT) +
                            Math.Sin(anomalyM) * (-6.2008 + 0.0074 * timeT + 0.00003 * timeT2) +
                            Math.Cos(anomalyM) * (-3.2750 - 0.0197 * timeT + 0.00001 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.4737 - 0.0052 * timeT - 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.8111 + 0.0033 * timeT - 0.00002 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0037 + 0.0018 * timeT) +
                            Math.Cos(3 * anomalyM) * (-0.1768 + 0.00001 * timeT2) +
                            Math.Sin(4 * anomalyM) * (-0.0211 - 0.0004 * timeT) +
                            Math.Cos(4 * anomalyM) * (0.0326 - 0.0003 * timeT) +
                            Math.Sin(5 * anomalyM) * (0.0083 + 0.0001 * timeT) +
                            Math.Cos(5 * anomalyM) * (-0.0040 + 0.0001 * timeT);
                    break;
                case EventType.SuperiorConjunction:
                    delta = (-0.0548 - 0.0002 * timeT) +
                            Math.Sin(anomalyM) * (7.3894 - 0.0100 * timeT - 0.00003 * timeT2) +
                            Math.Cos(anomalyM) * (3.2200 + 0.0197 * timeT - 0.00001 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.8383 - 0.0064 * timeT - 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.9666 + 0.0039 * timeT - 0.00003 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0770 - 0.0026 * timeT) +
                            Math.Cos(3 * anomalyM) * (0.2758 + 0.0002 * timeT - 0.00002 * timeT2) +
                            Math.Sin(4 * anomalyM) * (-0.0128 - 0.0008 * timeT) +
                            Math.Cos(4 * anomalyM) * (0.0734 - 0.0004 * timeT - 0.00001 * timeT2) +
                            Math.Sin(5 * anomalyM) * (-0.0122 - 0.0002 * timeT) +
                            Math.Cos(5 * anomalyM) * (0.0173 - 0.0002 * timeT);
                    break;
                case EventType.EasternElongation:
                    delta = (-21.6101 + 0.0002 * timeT) +
                            Math.Sin(anomalyM) * (-1.9803 - 0.0060 * timeT + 0.00001 * timeT2) +
                            Math.Cos(anomalyM) * (1.4151 - 0.0072 * timeT - 0.00001 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.5528 - 0.0005 * timeT - 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.2905 + 0.0034 * timeT + 0.00001 * timeT2) +
                            Math.Sin(3 * anomalyM) * (-0.1121 - 0.0001 * timeT + 0.00001 * timeT2) +
                            Math.Cos(3 * anomalyM) * (-0.0098 - 0.0015 * timeT) +
                            Math.Sin(4 * anomalyM) * 0.0192 +
                            Math.Cos(4 * anomalyM) * (0.0111 + 0.0004 * timeT) +
                            Math.Sin(5 * anomalyM) * -0.0061 +
                            Math.Cos(5 * anomalyM) * (-0.0032 - 0.0001 * timeT2);
                    break;
                case EventType.WesternElongation:
                    delta = (21.6249 - 0.0002 * timeT) +
                            Math.Sin(anomalyM) * (0.1306 + 0.0065 * timeT) +
                            Math.Cos(anomalyM) * (-2.7661 - 0.0011 * timeT + 0.00001 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.2438 - 0.0024 * timeT - 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.5767 + 0.0023 * timeT) +
                            Math.Sin(3 * anomalyM) * 0.1041 +
                            Math.Cos(3 * anomalyM) * (-0.0184 + 0.0007 * timeT) +
                            Math.Sin(4 * anomalyM) * (-0.0051 - 0.0001 * timeT) +
                            Math.Cos(4 * anomalyM) * (0.0048 + 0.0001 * timeT) +
                            Math.Sin(5 * anomalyM) * 0.0026 +
                            Math.Cos(5 * anomalyM) * 0.0037;
                    break;
                case EventType.Station1:
                    delta = (-11.0761 + 0.0003 * timeT) +
                            Math.Sin(anomalyM) * (-4.7321 + 0.0023 * timeT + 0.00002 * timeT2) +
                            Math.Cos(anomalyM) * (-1.3230 - 0.0156 * timeT) +
                            Math.Sin(2 * anomalyM) * (0.2270 - 0.0046 * timeT) +
                            Math.Cos(2 * anomalyM) * (0.7184 + 0.0013 * timeT - 0.00002 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0638 + 0.0016 * timeT) +
                            Math.Cos(3 * anomalyM) * (-0.1655 + 0.0007 * timeT) +
                            Math.Sin(4 * anomalyM) * (-0.0395 - 0.0003 * timeT) +
                            Math.Cos(4 * anomalyM) * (0.0247 - 0.0006 * timeT) +
                            Math.Sin(5 * anomalyM) * 0.0131 +
                            Math.Cos(5 * anomalyM) * (0.0008 + 0.0002 * timeT);
                    break;
                default:
                    Debug.Assert(type == EventType.Station2, "Reason for the assert");
                    delta = (11.1343 - 0.0001 * timeT) +
                            Math.Sin(anomalyM) * (-3.9137 + 0.0073 * timeT + 0.00002 * timeT2) +
                            Math.Cos(anomalyM) * (-3.3861 - 0.0128 * timeT + 0.00001 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.5222 - 0.0040 * timeT - 0.00002 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.5929 + 0.0039 * timeT - 0.00002 * timeT2) +
                            Math.Sin(3 * anomalyM) * (-0.0593 + 0.0018 * timeT) +
                            Math.Cos(3 * anomalyM) * (-0.1733 - 0.0007 * timeT + 0.00001 * timeT2) +
                            Math.Sin(4 * anomalyM) * (-0.0053 - 0.0006 * timeT) +
                            Math.Cos(4 * anomalyM) * (0.0476 - 0.0001 * timeT) +
                            Math.Sin(5 * anomalyM) * (0.0070 + 0.0002 * timeT) +
                            Math.Cos(5 * anomalyM) * (-0.0115 + 0.0001 * timeT);
                    break;
            }

            return delta;
        }

        /// <summary>
        /// Planetary elongation value.
        /// </summary>
        /// <param name="bEastern">The b eastern.</param>
        /// <param name="anomalyM">The anomalyM.</param>
        /// <param name="timeT">The T.</param>
        /// <param name="timeT2">The t2.</param>
        /// <returns> Returns value. </returns>
        public static double PlanetaryElongationValue(bool bEastern, double anomalyM, double timeT, double timeT2) {
            double value;
            if (bEastern) {
                value = 22.4697 +
                         Math.Sin(anomalyM) * (-4.2666 + 0.0054 * timeT + 0.00002 * timeT2) +
                         Math.Cos(anomalyM) * (-1.8537 - 0.0137 * timeT) +
                         Math.Sin(2 * anomalyM) * (0.3598 + 0.0008 * timeT - 0.00001 * timeT2) +
                         Math.Cos(2 * anomalyM) * (-0.0680 + 0.0026 * timeT) +
                         Math.Sin(3 * anomalyM) * (-0.0524 - 0.0003 * timeT) +
                         Math.Cos(3 * anomalyM) * (0.0052 - 0.0006 * timeT) +
                         Math.Sin(4 * anomalyM) * (0.0107 + 0.0001 * timeT) +
                         Math.Cos(4 * anomalyM) * (-0.0013 + 0.0001 * timeT) +
                         Math.Sin(5 * anomalyM) * (-0.0021) +
                         Math.Cos(5 * anomalyM) * 0.0003;
            }
            else {
                value = (22.4143 - 0.0001 * timeT) +
                        Math.Sin(anomalyM) * (4.3651 - 0.0048 * timeT - 0.00002 * timeT2) +
                        Math.Cos(anomalyM) * (2.3787 + 0.0121 * timeT - 0.00001 * timeT2) +
                        Math.Sin(2 * anomalyM) * (0.2674 + 0.0022 * timeT) +
                        Math.Cos(2 * anomalyM) * (-0.3873 + 0.0008 * timeT + 0.00001 * timeT2) +
                        Math.Sin(3 * anomalyM) * (-0.0369 - 0.0001 * timeT) +
                        Math.Cos(3 * anomalyM) * (0.0017 - 0.0001 * timeT) +
                        Math.Sin(4 * anomalyM) * 0.0059 +
                        Math.Cos(4 * anomalyM) * (0.0061 + 0.0001 * timeT) +
                        Math.Sin(5 * anomalyM) * 0.0007 +
                        Math.Cos(5 * anomalyM) * (-0.0011);
            }

            return value;
        }

        #endregion

        #region Naughter - Phenomena
        #endregion

        #region Naughter - Phenomena
        #endregion

        #region Naughter - Phenomena
        #endregion

        #region Naughter - Phenomena
        #endregion

        #region Naughter - Phenomena
        #endregion

        /// <summary>
        /// Schlyter or Chapront.
        /// </summary>
        public override void Init() {
            switch (this.Variant) {
                case AlgVariant.VarBretagnon82:
                    this.InitBretagnon82();
                    break;
                case AlgVariant.VarBretagnon87:
                    this.InitBretagnon87(SystemManager.VsopPath);
                    break;
                case AlgVariant.VarSchlyter:
                    this.InitSchlyter();
                    break;
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
            double[] lw = { 48.3313, 3.24587e-5, 0.0, 0.0 };
            double[] i = { 7.0047, 5.00e-8, 0.0, 0.0 };
            double[] w = { 29.1241, 1.01444e-5, 0.0, 0.0 };
            double[] a = { 0.387098 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] e = { 0.205635, 5.59e-10, 0.0, 0.0 };
            double[] vm = { 168.6562, 4.0923344368, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }

        /// <summary>
        /// Init Bretagnon 82.
        /// </summary>
        private void InitBretagnon82() {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            double[] a = { 0.3870983 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] lm = { 4.4026088, 2608.7903142, -1e-7, 0.0 };
            double[] k = { 4.466060e-2, -5.521e-4, -2e-7, 0.0 };
            double[] h = { 2.007233e-1, 1.438e-4, -8e-7, 0.0 };
            double[] q = { 4.061560e-2, 6.540e-5, -1e-7, 0.0 };
            double[] p = { 4.563550e-2, -1.276e-4, -1e-7, 0.0 };
            this.BretElements = new BretagnonElements(a, lm, k, h, q, p);
        }

        /// <summary>
        /// BRETAGNON Vsop87.
        /// </summary>
        /// <param name="givenVsopPath">The given Vsop path.</param>
        private void InitBretagnon87(string givenVsopPath) {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            this.Vsop87.InitWith(givenVsopPath + "Vsop87.MER", 0.0);
        }
        #endregion
    }
}
