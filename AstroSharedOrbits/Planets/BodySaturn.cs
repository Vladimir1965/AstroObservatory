// <copyright file="BodySaturn.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Planets {
    using System;
    using System.Diagnostics;
    using JetBrains.Annotations;
    using AstroSharedOrbits.Systems;
    using AstroSharedClasses.Enums;
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedClasses.Computation;
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.OrbitalData;

    /// <summary>
    /// Body Saturn.
    /// </summary>
    public sealed class BodySaturn : Orbit {
        /// <summary>
        /// Initializes a new instance of the BodySaturn class.
        /// </summary>
        public BodySaturn()
            : base("S", "Saturn") {
            this.PerTime = 1944.687238;      ////
            this.Body.Mass = 568.46e24;           //// [kg]
            this.Body.Radius = 60.268e6;          //// [m]
            this.Body.J = 26.73;              //// [deg]
            this.Knke = 10;                 ////4;      
            this.MeanPeriod = 29.457;
        }

        #region Naughter - PerihelionAphelion
        /// <summary>
        /// Saturn the K.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static long SaturnK(double year) {
            return (long)(0.03393 * (year - 2003.52));
        }

        /// <summary>
        /// Saturn the perihelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusPerihelion(long givenK) {
            double kdash = givenK;
            var kSquared = kdash * kdash;
            return 2452830.12 + 10764.21676 * kdash + 0.000827 * kSquared;
        }

        /// <summary>
        /// Saturn the aphelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusAphelion(long givenK) {
            var kdash = givenK + 0.5;
            var kSquared = kdash * kdash;
            return 2452830.12 + 10764.21676 * kdash + 0.000827 * kSquared;
        }
        #endregion

        #region Naughter - Aproximation

        /// <summary>
        /// Saturn the mean longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnMeanLongitude(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(50.077444 + 1223.5110686 * timeT + 0.00051908 * timeSquared - 0.000000030 * timeCubed);
        }

        /// <summary>
        /// Saturn the semimajor axis.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnSemimajorAxis(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;

            return 9.554909192 - 0.0000021390 * timeT + 0.000000004 * timeSquared;
        }

        /// <summary>
        /// Saturn the eccentricity.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnEccentricity(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return 0.05554814 - 0.0003446641 * timeT - 0.0000006436 * timeSquared + 0.00000000340 * timeCubed;
        }

        /// <summary>
        /// Saturn the inclination.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnInclination(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(2.488879 - 0.0037362 * timeT - 0.00001519 * timeSquared + 0.000000087 * timeCubed);
        }

        /// <summary>
        /// Saturn the longitude ascending node.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnLongitudeAscendingNode(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(113.665503 + 0.8770880 * timeT - 0.00012176 * timeSquared - 0.000002249 * timeCubed);
        }

        /// <summary>
        /// Saturn the longitude perihelion.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnLongitudePerihelion(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(93.057237 + 1.19637613 * timeT + 0.00083753 * timeSquared + 0.000004928 * timeCubed);
        }

        #endregion

        #region Naughter - Aproximation J2000
        /// <summary>
        /// Saturn the mean longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnMeanLongitudeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(50.077444 + 1222.1138488 * timeT + 0.00021004 * timeSquared - 0.000000046 * timeCubed);
        }

        /// <summary>
        /// Saturn the inclination J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnInclinationJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(2.488879 + 0.0025514 * timeT - 0.00004906 * timeSquared + 0.000000017 * timeCubed);
        }

        /// <summary>
        /// Saturn the longitude ascending node J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnLongitudeAscendingNodeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(113.665503 - 0.2566722 * timeT - 0.00018399 * timeSquared + 0.000000480 * timeCubed);
        }

        /// <summary>
        /// Saturn the longitude perihelion J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnLongitudePerihelionJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(93.057237 + 0.5665415 * timeT + 0.00052850 * timeSquared + 0.000004912 * timeCubed);
        }

        #endregion

        #region Naughter - Magnitude
        /// <summary>
        /// Saturn the magnitude muller.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <param name="deltaU">The delta u.</param>
        /// <param name="givenB">The givenB.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double SaturnMagnitudeMuller(double givenParameter, double givenDelta, double deltaU, double givenB) {
            //// Convert from degrees to radians
            givenB = Angles.DegRad(givenB);
            var sinB = Math.Sin(givenB);

            return -8.68 + 5 * Math.Log10(givenParameter * givenDelta) + 0.044 * Math.Abs(deltaU) - 2.60 * Math.Sin(Math.Abs(givenB)) + 1.25 * sinB * sinB;
        }

        /// <summary>
        /// Saturn the magnitude AA.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <param name="deltaU">The delta u.</param>
        /// <param name="givenB">The givenB.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double SaturnMagnitudeAA(double givenParameter, double givenDelta, double deltaU, double givenB) {
            //// Convert from degrees to radians
            givenB = Angles.DegRad(givenB);
            var sinB = Math.Sin(givenB);

            return -8.88 + 5 * Math.Log10(givenParameter * givenDelta) + 0.044 * Math.Abs(deltaU) - 2.60 * Math.Sin(Math.Abs(givenB)) + 1.25 * sinB * sinB;
        }
        #endregion

        #region Naughter
        /// <summary>
        /// Saturn the equatorial semidiameter A.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnEquatorialSemidiameterA(double givenDelta) {
            return 83.33 / givenDelta;
        }

        /// <summary>
        /// Saturn the polar semidiameter A.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnPolarSemidiameterA(double givenDelta) {
            return 74.57 / givenDelta;
        }

        /// <summary>
        /// Apparent saturn polar semidiameter A.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <param name="givenB">The givenB.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double ApparentSaturnPolarSemidiameterA(double givenDelta, double givenB) {
            var cosB = Math.Cos(Angles.DegRad(givenB));
            return SaturnPolarSemidiameterA(givenDelta) * Math.Sqrt(1 - 0.199197 * cosB * cosB);
        }

        /// <summary>
        /// Saturn the equatorial semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnEquatorialSemidiameterB(double givenDelta) {
            return 82.73 / givenDelta;
        }

        /// <summary>
        /// Saturn the polar semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SaturnPolarSemidiameterB(double givenDelta) {
            return 73.82 / givenDelta;
        }

        /// <summary>
        /// Apparent saturn polar semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <param name="givenB">The givenB.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double ApparentSaturnPolarSemidiameterB(double givenDelta, double givenB) {
            var cosB = Math.Cos(Angles.DegRad(givenB));
            return SaturnPolarSemidiameterB(givenDelta) * Math.Sqrt(1 - 0.203800 * cosB * cosB);
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
            for (i = 0; i < VsopData.L0SaturnCoefficients.Length; i++) {
                l0 += VsopData.L0SaturnCoefficients[i].A * Math.Cos(VsopData.L0SaturnCoefficients[i].B + VsopData.L0SaturnCoefficients[i].C * rho);
            }

            //// Calculate L1
            double l1 = 0;
            for (i = 0; i < VsopData.L1SaturnCoefficients.Length; i++) {
                l1 += VsopData.L1SaturnCoefficients[i].A * Math.Cos(VsopData.L1SaturnCoefficients[i].B + VsopData.L1SaturnCoefficients[i].C * rho);
            }

            //// Calculate L2
            double l2 = 0;
            for (i = 0; i < VsopData.L2SaturnCoefficients.Length; i++) {
                l2 += VsopData.L2SaturnCoefficients[i].A * Math.Cos(VsopData.L2SaturnCoefficients[i].B + VsopData.L2SaturnCoefficients[i].C * rho);
            }

            //// Calculate L3
            double l3 = 0;
            for (i = 0; i < VsopData.L3SaturnCoefficients.Length; i++) {
                l3 += VsopData.L3SaturnCoefficients[i].A * Math.Cos(VsopData.L3SaturnCoefficients[i].B + VsopData.L3SaturnCoefficients[i].C * rho);
            }

            //// Calculate L4
            double l4 = 0;
            for (i = 0; i < VsopData.L4SaturnCoefficients.Length; i++) {
                l4 += VsopData.L4SaturnCoefficients[i].A * Math.Cos(VsopData.L4SaturnCoefficients[i].B + VsopData.L4SaturnCoefficients[i].C * rho);
            }

            //// Calculate L5
            double l5 = 0;
            for (i = 0; i < VsopData.L5SaturnCoefficients.Length; i++) {
                l5 += VsopData.L5SaturnCoefficients[i].A * Math.Cos(VsopData.L5SaturnCoefficients[i].B + VsopData.L5SaturnCoefficients[i].C * rho);
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
            var rho5 = rho4 * rho;

            //// Calculate B0
            double b0 = 0;
            int i;
            for (i = 0; i < VsopData.B0SaturnCoefficients.Length; i++) {
                b0 += VsopData.B0SaturnCoefficients[i].A * Math.Cos(VsopData.B0SaturnCoefficients[i].B + VsopData.B0SaturnCoefficients[i].C * rho);
            }

            //// Calculate B1
            double b1 = 0;
            for (i = 0; i < VsopData.B1SaturnCoefficients.Length; i++) {
                b1 += VsopData.B1SaturnCoefficients[i].A * Math.Cos(VsopData.B1SaturnCoefficients[i].B + VsopData.B1SaturnCoefficients[i].C * rho);
            }

            //// Calculate B2
            double b2 = 0;
            for (i = 0; i < VsopData.B2SaturnCoefficients.Length; i++) {
                b2 += VsopData.B2SaturnCoefficients[i].A * Math.Cos(VsopData.B2SaturnCoefficients[i].B + VsopData.B2SaturnCoefficients[i].C * rho);
            }

            //// Calculate B3
            double b3 = 0;
            for (i = 0; i < VsopData.B3SaturnCoefficients.Length; i++) {
                b3 += VsopData.B3SaturnCoefficients[i].A * Math.Cos(VsopData.B3SaturnCoefficients[i].B + VsopData.B3SaturnCoefficients[i].C * rho);
            }

            //// Calculate B4
            double b4 = 0;
            for (i = 0; i < VsopData.B4SaturnCoefficients.Length; i++) {
                b4 += VsopData.B4SaturnCoefficients[i].A * Math.Cos(VsopData.B4SaturnCoefficients[i].B + VsopData.B4SaturnCoefficients[i].C * rho);
            }

            //// Calculate B5
            double b5 = 0;
            for (i = 0; i < VsopData.B5SaturnCoefficients.Length; i++) {
                b5 += VsopData.B5SaturnCoefficients[i].A *
                      Math.Cos(VsopData.B5SaturnCoefficients[i].B + VsopData.B5SaturnCoefficients[i].C * rho);
            }

            var value = (b0 + b1 * rho + b2 * rhoSquared + b3 * rhoCubed + b4 * rho4 + b5 * rho5) / 100000000;

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
            var rho5 = rho4 * rho;

            //// Calculate R0
            double r0 = 0;
            int i;
            for (i = 0; i < VsopData.R0SaturnCoefficients.Length; i++) {
                r0 += VsopData.R0SaturnCoefficients[i].A * Math.Cos(VsopData.R0SaturnCoefficients[i].B + VsopData.R0SaturnCoefficients[i].C * rho);
            }

            //// Calculate R1
            double r1 = 0;
            for (i = 0; i < VsopData.R1SaturnCoefficients.Length; i++) {
                r1 += VsopData.R1SaturnCoefficients[i].A * Math.Cos(VsopData.R1SaturnCoefficients[i].B + VsopData.R1SaturnCoefficients[i].C * rho);
            }

            //// Calculate R2
            double r2 = 0;
            for (i = 0; i < VsopData.R2SaturnCoefficients.Length; i++) {
                r2 += VsopData.R2SaturnCoefficients[i].A * Math.Cos(VsopData.R2SaturnCoefficients[i].B + VsopData.R2SaturnCoefficients[i].C * rho);
            }

            //// Calculate R3
            double r3 = 0;
            for (i = 0; i < VsopData.R3SaturnCoefficients.Length; i++) {
                r3 += VsopData.R3SaturnCoefficients[i].A * Math.Cos(VsopData.R3SaturnCoefficients[i].B + VsopData.R3SaturnCoefficients[i].C * rho);
            }

            //// Calculate R4
            double r4 = 0;
            for (i = 0; i < VsopData.R4SaturnCoefficients.Length; i++) {
                r4 += VsopData.R4SaturnCoefficients[i].A * Math.Cos(VsopData.R4SaturnCoefficients[i].B + VsopData.R4SaturnCoefficients[i].C * rho);
            }

            //// Calculate R5
            double r5 = 0;
            for (i = 0; i < VsopData.R5SaturnCoefficients.Length; i++) {
                r5 += VsopData.R5SaturnCoefficients[i].A * Math.Cos(VsopData.R5SaturnCoefficients[i].B + VsopData.R5SaturnCoefficients[i].C * rho);
            }

            return (r0 + r1 * rho + r2 * rhoSquared + r3 * rhoCubed + r4 * rho4 + r5 * rho5) / 100000000;
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
            var a = Angles.Mod360(82.74 + 40.76 * timeT);
            a = Angles.DegRad(a);
            var b = Angles.Mod360(29.86 + 1181.36 * timeT);
            b = Angles.DegRad(b);
            var c = Angles.Mod360(14.13 + 590.68 * timeT);
            c = Angles.DegRad(c);
            var d = Angles.Mod360(220.02 + 1262.87 * timeT);
            d = Angles.DegRad(d);

            double delta;
            switch (type) {
                case EventType.Opposition:
                    delta = (-0.0209 + 0.0006 * timeT + 0.00023 * timeT2) +
                            Math.Sin(anomalyM) * (4.5795 - 0.0312 * timeT - 0.00017 * timeT2) +
                            Math.Cos(anomalyM) * (1.1462 - 0.0351 * timeT + 0.00011 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.0985 - 0.0015 * timeT) +
                            Math.Cos(2 * anomalyM) * (0.0733 - 0.0031 * timeT + 0.00001 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0025 - 0.0001 * timeT) +
                            Math.Cos(3 * anomalyM) * (0.0050 - 0.0002 * timeT) +
                            Math.Sin(a) * (-0.0337 * timeT + 0.00018 * timeT2) +
                            Math.Cos(a) * (-0.8510 + 0.0044 * timeT + 0.00068 * timeT2) +
                            Math.Sin(b) * (-0.0064 * timeT + 0.00004 * timeT2) +
                            Math.Cos(b) * (0.2397 - 0.0012 * timeT - 0.00008 * timeT2) +
                            Math.Sin(c) * (-0.0010 * timeT) +
                            Math.Cos(c) * (0.1245 + 0.0006 * timeT) +
                            Math.Sin(d) * (0.0024 * timeT - 0.00003 * timeT2) +
                            Math.Cos(d) * (0.0477 - 0.0005 * timeT - 0.00006 * timeT2);
                    break;
                case EventType.Conjunction:
                    delta = (0.0172 - 0.0006 * timeT + 0.00023 * timeT2) +
                            Math.Sin(anomalyM) * (-8.5885 + 0.0411 * timeT + 0.00020 * timeT2) +
                            Math.Cos(anomalyM) * (-1.1470 + 0.0352 * timeT - 0.00011 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.3331 - 0.0034 * timeT - 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.1145 - 0.0045 * timeT + 0.00002 * timeT2) +
                            Math.Sin(3 * anomalyM) * (-0.0169 + 0.0002 * timeT) +
                            Math.Cos(3 * anomalyM) * (-0.0109 + 0.0004 * timeT) +
                            Math.Sin(a) * (-0.0337 * timeT + 0.00018 * timeT2) +
                            Math.Cos(a) * (-0.8510 + 0.0044 * timeT + 0.00068 * timeT2) +
                            Math.Sin(b) * (-0.0064 * timeT + 0.00004 * timeT2) +
                            Math.Cos(b) * (0.2397 - 0.0012 * timeT - 0.00008 * timeT2) +
                            Math.Sin(c) * (-0.0010 * timeT) +
                            Math.Cos(c) * (0.1245 + 0.0006 * timeT) +
                            Math.Sin(d) * (0.0024 * timeT - 0.00003 * timeT2) +
                            Math.Cos(d) * (0.0477 - 0.0005 * timeT - 0.00006 * timeT2);
                    break;
                case EventType.Station1:
                    delta = (-68.8840 + 0.0009 * timeT + 0.00023 * timeT2) +
                            Math.Sin(anomalyM) * (5.5452 - 0.0279 * timeT - 0.00020 * timeT2) +
                            Math.Cos(anomalyM) * (3.0727 - 0.0430 * timeT + 0.00007 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.1101 - 0.0006 * timeT - 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.1654 - 0.0043 * timeT + 0.00001 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0010 + 0.0001 * timeT) +
                            Math.Cos(3 * anomalyM) * (0.0095 - 0.0003 * timeT) +
                            Math.Sin(a) * (-0.0337 * timeT + 0.00018 * timeT2) +
                            Math.Cos(a) * (-0.8510 + 0.0044 * timeT + 0.00068 * timeT2) +
                            Math.Sin(b) * (-0.0064 * timeT + 0.00004 * timeT2) +
                            Math.Cos(b) * (0.2397 - 0.0012 * timeT - 0.00008 * timeT2) +
                            Math.Sin(c) * (-0.0010 * timeT) +
                            Math.Cos(c) * (0.1245 + 0.0006 * timeT) +
                            Math.Sin(d) * (0.0024 * timeT - 0.00003 * timeT2) +
                            Math.Cos(d) * (0.0477 - 0.0005 * timeT - 0.00006 * timeT2);
                    break;
                default:
                    Debug.Assert(type == EventType.Station2, "Reason for the assert");
                    delta = (68.8720 - 0.0007 * timeT + 0.00023 * timeT2) +
                            Math.Sin(anomalyM) * (5.9399 - 0.0400 * timeT - 0.00015 * timeT2) +
                            Math.Cos(anomalyM) * (-0.7998 - 0.0266 * timeT + 0.00014 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.1738 - 0.0032 * timeT) +
                            Math.Cos(2 * anomalyM) * (-0.0039 - 0.0024 * timeT + 0.00001 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0073 - 0.0002 * timeT) +
                            Math.Cos(3 * anomalyM) * (0.0020 - 0.0002 * timeT) +
                            Math.Sin(a) * (-0.0337 * timeT + 0.00018 * timeT2) +
                            Math.Cos(a) * (-0.8510 + 0.0044 * timeT + 0.00068 * timeT2) +
                            Math.Sin(b) * (-0.0064 * timeT + 0.00004 * timeT2) +
                            Math.Cos(b) * (0.2397 - 0.0012 * timeT - 0.00008 * timeT2) +
                            Math.Sin(c) * (-0.0010 * timeT) +
                            Math.Cos(c) * (0.1245 + 0.0006 * timeT) +
                            Math.Sin(d) * (0.0024 * timeT - 0.00003 * timeT2) +
                            Math.Cos(d) * (0.0477 - 0.0005 * timeT - 0.00006 * timeT2);
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

        /// <summary>
        /// Compute perturbations.
        /// </summary>
        public override void Perturbate() {
            switch (this.Variant) {
                case AlgVariant.VarSchlyter:
                    this.PerturbateSchlyterLongitude();
                    this.PerturbateSchlyterLatitude();
                    break;
                case AlgVariant.None:
                    break;
                case AlgVariant.VarBretagnon87:
                    break;
                case AlgVariant.VarBretagnon82:
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
            double[] lw = { 113.6634, 2.38980e-5, 0.0, 0.0 };
            double[] i = { 2.4886, -1.081e-7, 0.0, 0.0 };
            double[] w = { 339.3939, 2.97661e-5, 0.0, 0.0 };
            double[] a = { 9.55475 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] e = { 0.055546, -9.499e-9, 0.0, 0.0 };
            double[] vm = { 316.9670, 0.0334442282, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }

        /// <summary>
        /// BRETAGNON Vsop82.
        /// </summary>
        private void InitBretagnon82() {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            double[] a = { 9.5549100 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] lm = { 0.8740170, 21.329910000, 4e-6, 0.0 };
            double[] k = { -2.960000e-3, -5.300e-4, 3e-6, 0.0 };
            double[] h = { 5.543000e-2, -3.760e-4, -3e-6, 0.0 };
            double[] q = { -8.718000e-3, 8.000e-5, 0.00, 0.0 };
            double[] p = { 1.989200e-2, 5.900e-5, 0.00, 0.0 };
            this.BretElements = new BretagnonElements(a, lm, k, h, q, p);
        }

        /// <summary>
        /// BRETAGNON Vsop87.
        /// </summary>
        /// <param name="givenVsopPath">The given Vsop path.</param>
        private void InitBretagnon87(string givenVsopPath) {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            this.Vsop87.InitWith(givenVsopPath + "Vsop87.SAT", 0.0);
        }

        #endregion

        #region Perturbations
        /// <summary>
        /// Perturbate Schlyter Longitude.
        /// </summary>
        private void PerturbateSchlyterLongitude() {
            var j = SolarSystem.Singleton.Jupiter.VM;
            var s = SolarSystem.Singleton.Saturn.VM;
            var d01 = +0.812 * Angles.Sinus((2 * j) - (5 * s) - 67.6);
            var d02 = -0.229 * Angles.Cosin((2 * j) - (4 * s) - 2.0);
            var d03 = +0.119 * Angles.Sinus(j - (2 * s) - 3.0);
            var d04 = +0.046 * Angles.Sinus((2 * j) - (6 * s) - 69.0);
            var d05 = +0.014 * Angles.Sinus(j - (3 * s) + 32.0);
            var dLongitude = d01 + d02 + d03 + d04 + d05;
            this.Point.Longitude = this.Longitude + dLongitude;
        }

        /// <summary>
        /// Perturbate Schlyter Latitude.
        /// </summary>
        private void PerturbateSchlyterLatitude() {
            // SCHLYTER
            var j = SolarSystem.Singleton.Jupiter.VM;
            var s = SolarSystem.Singleton.Saturn.VM;
            var d01 = -0.020 * Angles.Cosin((2 * j) - (4 * s) - 2.0);
            var d02 = +0.018 * Angles.Sinus((2 * j) - (6 * s) - 49.0);
            var dlth = d01 + d02;
            this.Point.Latitude = this.Point.Latitude + dlth;
        }
        #endregion
    }
}
