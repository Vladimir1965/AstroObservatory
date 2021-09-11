// <copyright file="BodyVenus.cs" company="Traced-Ideas, Czech republic">
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
    using AstroSharedOrbits.OrbitalData;
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.Systems;
    using JetBrains.Annotations;

    /// <summary>
    /// Body Venus.
    /// </summary>
    public sealed class BodyVenus : Orbit {
        /// <summary>
        /// Initializes a new instance of the BodyVenus class.
        /// </summary>
        public BodyVenus()
            : base("V", "VenusS") {
            this.PerTime = 1970.383320;     // [year AD] 
            this.Body.Mass = 4.869e24;           // [kg]
            this.Body.Radius = 6.052e6;          // [m]
            this.Body.J = 177.3;                 ////  [deg]
            this.Knke = 10;                 ////  3;                 
        }

        #region Naughter - PerihelionAphelion
        /// <summary>
        /// Venuses the K.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static long VenusK(double year) {
            return (long)(1.62549 * (year - 2000.53));
        }

        /// <summary>
        /// Venuses the perihelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusPerihelion(long givenK) {
            double kdash = givenK;
            var kSquared = kdash * kdash;
            return 2451738.233 + 224.7008188 * kdash - 0.0000000327 * kSquared;
        }

        /// <summary>
        /// Venuses the aphelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusAphelion(long givenK) {
            var kdash = givenK + 0.5;
            var kSquared = kdash * kdash;
            return 2451738.233 + 224.7008188 * kdash - 0.0000000327 * kSquared;
        }
        #endregion

        #region Naughter - Aproximation
        /// <summary>
        /// Venuses the mean longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusMeanLongitude(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(181.979801 + 58519.2130302 * timeT + 0.00031014 * timeSquared + 0.000000015 * timeCubed);
        }

        /// <summary>
        /// Venuses the semimajor axis.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusSemimajorAxis() {
            return 0.723329820;
        }

        /// <summary>
        /// Venuses the eccentricity.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusEccentricity(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return 0.00677192 - 0.000047765 * timeT + 0.0000000981 * timeSquared + 0.00000000046 * timeCubed;
        }

        /// <summary>
        /// Venuses the inclination.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusInclination(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(3.394662 + 0.0010037 * timeT - 0.00000088 * timeSquared - 0.000000007 * timeCubed);
        }

        /// <summary>
        /// Venuses the longitude ascending node.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusLongitudeAscendingNode(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(76.679920 + 0.9011206 * timeT + 0.00040618 * timeSquared - 0.000000093 * timeCubed);
        }

        /// <summary>
        /// Venuses the longitude perihelion.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusLongitudePerihelion(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(131.563703 + 1.4022288 * timeT - 0.00107618 * timeSquared - 0.000005678 * timeCubed);
        }
        #endregion

        #region Naughter - Aproximation J2000
        /// <summary>
        /// Venuses the mean longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusMeanLongitudeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(181.979801 + 58517.8156760 * timeT + 0.00000165 * timeSquared - 0.000000002 * timeCubed);
        }

        /// <summary>
        /// Venuses the inclination J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusInclinationJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(3.394662 - 0.0008568 * timeT - 0.00003244 * timeSquared + 0.000000009 * timeCubed);
        }

        /// <summary>
        /// Venuses the longitude ascending node J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusLongitudeAscendingNodeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(76.679920 - 0.2780134 * timeT - 0.00014257 * timeSquared - 0.000000164 * timeCubed);
        }

        /// <summary>
        /// Venuses the longitude perihelion J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusLongitudePerihelionJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(131.563703 + 0.0048746 * timeT - 0.00138467 * timeSquared - 0.000005695 * timeCubed);
        }

        #endregion

        #region Naughter - Magnitude
        /// <summary>
        /// Venuses the magnitude muller.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <param name="i">The given i.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double VenusMagnitudeMuller(double givenParameter, double givenDelta, double i) {
            return -4.00 + 5 * Math.Log10(givenParameter * givenDelta) + 0.01322 * i + 0.0000004247 * i * i * i;
        }

        /// <summary>
        /// Venuses the magnitude AA.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <param name="i">The i.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double VenusMagnitudeAA(double givenParameter, double givenDelta, double i) {
            var i2 = i * i;
            var i3 = i2 * i;

            return -4.40 + 5 * Math.Log10(givenParameter * givenDelta) + 0.0009 * i + 0.000239 * i2 - 0.00000065 * i3;
        }
        #endregion

        #region Naughter

        /// <summary>
        /// Venuses the semidiameter A.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusSemidiameterA(double givenDelta) {
            return 8.41 / givenDelta;
        }

        /// <summary>
        /// Venuses the semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VenusSemidiameterB(double givenDelta) {
            return 8.34 / givenDelta;
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
            for (i = 0; i < VsopData.L0VenusCoefficients.Length; i++) {
                l0 += VsopData.L0VenusCoefficients[i].A * Math.Cos(VsopData.L0VenusCoefficients[i].B + VsopData.L0VenusCoefficients[i].C * rho);
            }

            //// Calculate L1
            double l1 = 0;
            for (i = 0; i < VsopData.L1VenusCoefficients.Length; i++) {
                l1 += VsopData.L1VenusCoefficients[i].A * Math.Cos(VsopData.L1VenusCoefficients[i].B + VsopData.L1VenusCoefficients[i].C * rho);
            }

            //// Calculate L2
            double l2 = 0;
            for (i = 0; i < VsopData.L2VenusCoefficients.Length; i++) {
                l2 += VsopData.L2VenusCoefficients[i].A * Math.Cos(VsopData.L2VenusCoefficients[i].B + VsopData.L2VenusCoefficients[i].C * rho);
            }

            //// Calculate L3
            double l3 = 0;
            for (i = 0; i < VsopData.L3VenusCoefficients.Length; i++) {
                l3 += VsopData.L3VenusCoefficients[i].A * Math.Cos(VsopData.L3VenusCoefficients[i].B + VsopData.L3VenusCoefficients[i].C * rho);
            }

            //// Calculate L4
            double l4 = 0;
            for (i = 0; i < VsopData.L4VenusCoefficients.Length; i++) {
                l4 += VsopData.L4VenusCoefficients[i].A * Math.Cos(VsopData.L4VenusCoefficients[i].B + VsopData.L4VenusCoefficients[i].C * rho);
            }

            //// Calculate L5
            double l5 = 0;
            for (i = 0; i < VsopData.L5VenusCoefficients.Length; i++) {
                l5 += VsopData.L5VenusCoefficients[i].A * Math.Cos(VsopData.L5VenusCoefficients[i].B + VsopData.L5VenusCoefficients[i].C * rho);
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
            for (i = 0; i < VsopData.B0VenusCoefficients.Length; i++) {
                b0 += VsopData.B0VenusCoefficients[i].A * Math.Cos(VsopData.B0VenusCoefficients[i].B + VsopData.B0VenusCoefficients[i].C * rho);
            }

            //// Calculate B1
            double b1 = 0;
            for (i = 0; i < VsopData.B1VenusCoefficients.Length; i++) {
                b1 += VsopData.B1VenusCoefficients[i].A * Math.Cos(VsopData.B1VenusCoefficients[i].B + VsopData.B1VenusCoefficients[i].C * rho);
            }

            //// Calculate B2
            double b2 = 0;
            for (i = 0; i < VsopData.B2VenusCoefficients.Length; i++) {
                b2 += VsopData.B2VenusCoefficients[i].A * Math.Cos(VsopData.B2VenusCoefficients[i].B + VsopData.B2VenusCoefficients[i].C * rho);
            }

            //// Calculate B3
            double b3 = 0;
            for (i = 0; i < VsopData.B3VenusCoefficients.Length; i++) {
                b3 += VsopData.B3VenusCoefficients[i].A * Math.Cos(VsopData.B3VenusCoefficients[i].B + VsopData.B3VenusCoefficients[i].C * rho);
            }

            //// Calculate B4
            double b4 = 0;
            for (i = 0; i < VsopData.B4VenusCoefficients.Length; i++) {
                b4 += VsopData.B4VenusCoefficients[i].A * Math.Cos(VsopData.B4VenusCoefficients[i].B + VsopData.B4VenusCoefficients[i].C * rho);
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
            for (i = 0; i < VsopData.R0VenusCoefficients.Length; i++) {
                r0 += VsopData.R0VenusCoefficients[i].A * Math.Cos(VsopData.R0VenusCoefficients[i].B + VsopData.R0VenusCoefficients[i].C * rho);
            }

            //// Calculate R1
            double r1 = 0;
            for (i = 0; i < VsopData.R1VenusCoefficients.Length; i++) {
                r1 += VsopData.R1VenusCoefficients[i].A * Math.Cos(VsopData.R1VenusCoefficients[i].B + VsopData.R1VenusCoefficients[i].C * rho);
            }

            //// Calculate R2
            double r2 = 0;
            for (i = 0; i < VsopData.R2VenusCoefficients.Length; i++) {
                r2 += VsopData.R2VenusCoefficients[i].A * Math.Cos(VsopData.R2VenusCoefficients[i].B + VsopData.R2VenusCoefficients[i].C * rho);
            }

            //// Calculate R3
            double r3 = 0;
            for (i = 0; i < VsopData.R3VenusCoefficients.Length; i++) {
                r3 += VsopData.R3VenusCoefficients[i].A * Math.Cos(VsopData.R3VenusCoefficients[i].B + VsopData.R3VenusCoefficients[i].C * rho);
            }

            //// Calculate R4
            double r4 = 0;
            for (i = 0; i < VsopData.R4VenusCoefficients.Length; i++) {
                r4 += VsopData.R4VenusCoefficients[i].A * Math.Cos(VsopData.R4VenusCoefficients[i].B + VsopData.R4VenusCoefficients[i].C * rho);
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
        /// <param name="timeT2">The t2.</param>
        /// <returns> Returns value. </returns>
        public static double PlanetaryPhenomenaDelta(EventType type, double anomalyM, double timeT, double timeT2) {
            double delta;
            switch (type)
            {
                case EventType.InferiorConjunction:
                    delta = (-0.0096 + 0.0002 * timeT - 0.00001 * timeT2) +
                            Math.Sin(anomalyM) * (2.0009 - 0.0033 * timeT - 0.00001 * timeT2) +
                            Math.Cos(anomalyM) * (0.5980 - 0.0104 * timeT + 0.00001 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.0967 - 0.0018 * timeT - 0.00003 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.0913 + 0.0009 * timeT - 0.00002 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0046 - 0.0002 * timeT) +
                            Math.Cos(3 * anomalyM) * (0.0079 + 0.0001 * timeT);
                    break;
                case EventType.SuperiorConjunction:
                    delta = (0.0099 - 0.0002 * timeT - 0.00001 * timeT2) +
                            Math.Sin(anomalyM) * (4.1991 - 0.0121 * timeT - 0.00003 * timeT2) +
                            Math.Cos(anomalyM) * (-0.6095 + 0.0102 * timeT - 0.00002 * timeT2) +
                            Math.Sin(2 * anomalyM) * (0.2500 - 0.0028 * timeT - 0.00003 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.0063 + 0.0025 * timeT - 0.00002 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0232 - 0.0005 * timeT - 0.00001 * timeT2) +
                            Math.Cos(3 * anomalyM) * (0.0031 + 0.0004 * timeT);
                    break;
                case EventType.EasternElongation:
                    delta = (-70.7600 + 0.0002 * timeT - 0.00001 * timeT2) +
                            Math.Sin(anomalyM) * (1.0282 - 0.0010 * timeT - 0.00001 * timeT2) +
                            Math.Cos(anomalyM) * (0.2761 - 0.0060 * timeT) +
                            Math.Sin(2 * anomalyM) * (-0.0438 - 0.0023 * timeT + 0.00002 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.1660 - 0.0037 * timeT - 0.00004 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0036 + 0.0001 * timeT) +
                            Math.Cos(3 * anomalyM) * (-0.0011 + 0.00001 * timeT2);
                    break;
                case EventType.WesternElongation:
                    delta = (70.7462 - 0.00001 * timeT2) +
                            Math.Sin(anomalyM) * (1.1218 - 0.0025 * timeT - 0.00001 * timeT2) +
                            Math.Cos(anomalyM) * (0.4538 - 0.0066 * timeT) +
                            Math.Sin(2 * anomalyM) * (0.1320 + 0.0020 * timeT - 0.00003 * timeT2) +
                            Math.Cos(2 * anomalyM) * (-0.0702 + 0.0022 * timeT + 0.00004 * timeT2) +
                            Math.Sin(3 * anomalyM) * (0.0062 - 0.0001 * timeT) +
                            Math.Cos(3 * anomalyM) * (0.0015 - 0.00001 * timeT2);
                    break;
                case EventType.Station1:
                    delta = (-21.0672 + 0.0002 * timeT - 0.00001 * timeT2) +
                            Math.Sin(anomalyM) * (1.9396 - 0.0029 * timeT - 0.00001 * timeT2) +
                            Math.Cos(anomalyM) * (1.0727 - 0.0102 * timeT) +
                            Math.Sin(2 * anomalyM) * (0.0404 - 0.0023 * timeT - 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.1305 - 0.0004 * timeT - 0.00003 * timeT2) +
                            Math.Sin(3 * anomalyM) * (-0.0007 - 0.0002 * timeT) +
                            Math.Cos(3 * anomalyM) * 0.0098;
                    break;
                default:
                    Debug.Assert(type == EventType.Station2, "Reason for the assert");
                    delta = (21.0623 - 0.00001 * timeT2) +
                            Math.Sin(anomalyM) * (1.9913 - 0.0040 * timeT - 0.00001 * timeT2) +
                            Math.Cos(anomalyM) * (-0.0407 - 0.0077 * timeT) +
                            Math.Sin(2 * anomalyM) * (0.1351 - 0.0009 * timeT - 0.00004 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.0303 + 0.0019 * timeT) +
                            Math.Sin(3 * anomalyM) * (0.0089 - 0.0002 * timeT) +
                            Math.Cos(3 * anomalyM) * (0.0043 + 0.0001 * timeT);
                    break;
            }

            return delta;
        }

        /// <summary>
        /// Planetary elongation value.
        /// </summary>
        /// <param name="bEastern">The b eastern.</param>
        /// <param name="anomalyM">The M.</param>
        /// <param name="timeT">The T.</param>
        /// <param name="timeT2">The t2.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double PlanetaryElongationValue(bool bEastern, double anomalyM, double timeT, double timeT2)
        {
            double value;
            if (bEastern) {
                value = (46.3173 + 0.0001 * timeT) +
                        Math.Sin(anomalyM) * (0.6916 - 0.0024 * timeT) +
                        Math.Cos(anomalyM) * (0.6676 - 0.0045 * timeT) +
                        Math.Sin(2 * anomalyM) * (0.0309 - 0.0002 * timeT) +
                        Math.Cos(2 * anomalyM) * (0.0036 - 0.0001 * timeT);
            }
            else {
                value = 46.3245 +
                        Math.Sin(anomalyM) * (-0.5366 - 0.0003 * timeT + 0.00001 * timeT2) +
                        Math.Cos(anomalyM) * (0.3097 + 0.0016 * timeT - 0.00001 * timeT2) +
                        Math.Sin(2 * anomalyM) * (-0.0163) +
                        Math.Cos(2 * anomalyM) * (-0.0075 + 0.0001 * timeT);
            }

            return value;
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
            double[] lw = { 76.6799, 2.46590e-5, 0.0, 0.0 };
            double[] i = { 3.3946, 2.75e-8, 0.0, 0.0 };
            double[] w = { 54.8910, 1.38374e-5, 0.0, 0.0 };
            double[] a = { 0.723330 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] e = { 0.006773, -1.302e-9, 0.0, 0.0 };
            double[] vm = { 48.0052, 1.6021302244, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }

        /// <summary>
        /// BRETAGNON Vsop82.
        /// </summary>
        private void InitBretagnon82() {
            this.Time.EpochOrbit = 2451545; 
            this.Time.EpochEquinox = 2451545;
            double[] a = { 0.7233298 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] lm = { 3.1761467, 1021.3286000, 0.0, 0.0 };
            double[] k = { -4.492800e-3, 3.130e-5, 1e-7, 0.0 };
            double[] h = { 5.066800e-3, -3.610e-5, 2e-7, 0.0 };
            double[] q = { 6.824100e-3, 1.381e-4, -1e-7, 0.0 };
            double[] p = { 2.882290e-2, -4.040e-5, -6e-7, 0.0 };
            this.BretElements = new BretagnonElements(a, lm, k, h, q, p);
        }

        /// <summary>
        /// BRETAGNON Vsop87.
        /// </summary>
        /// <param name="givenVsopPath">The given Vsop path.</param>
        private void InitBretagnon87(string givenVsopPath)
        {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            this.Vsop87.InitWith(givenVsopPath + "Vsop87.VEN", 0.0);
        }
        #endregion
    }
}
