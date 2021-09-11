// <copyright file="BodyJupiter.cs" company="Traced-Ideas, Czech republic">
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
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedClasses.Enums;
    using AstroSharedClasses.Computation;
    using AstroSharedOrbits.Orbits;

    /// <summary>
    /// Body Jupiter.
    /// </summary>
    public sealed class BodyJupiter : Orbit {
        /// <summary>
        /// Initializes a new instance of the BodyJupiter class.
        /// </summary>
        public BodyJupiter()
            : base("J", "Jupiter") {
            this.PerTime = 1963.733784;     ////
            this.Body.Mass = 1898.6e24;          //// [kg]
            this.Body.Radius = 71.492e6;         //// [m]
            this.Body.J = 3.120;              //// [deg]
            this.Knke = 10;                 //// 4
            this.MeanPeriod = 11.862;
        }

        #region Naughter - PerihelionAphelion
        /// <summary>
        /// Jupiter the K.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static long JupiterK(double year) {
            return (long)(0.08430 * (year - 2011.20));
        }

        /// <summary>
        /// Jupiter the perihelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusPerihelion(long givenK) {
            double kdash = givenK;
            var kSquared = kdash * kdash;
            return 2455636.936 + 4332.897065 * kdash + 0.0001367 * kSquared;
        }

        /// <summary>
        /// Jupiter the aphelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusAphelion(long givenK) {
            var kdash = givenK + 0.5;
            var kSquared = kdash * kdash;
            return 2455636.936 + 4332.897065 * kdash + 0.0001367 * kSquared;
        }
        #endregion

        #region Naughter - Aproximation

        /// <summary>
        /// Jupiter the mean longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterMeanLongitude(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(34.351519 + 3036.3027748 * timeT + 0.00022330 * timeSquared + 0.000000037 * timeCubed);
        }

        /// <summary>
        /// Jupiter the semimajor axis.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterSemimajorAxis(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;

            return 5.202603209 + 0.0000001913 * timeT;
        }

        /// <summary>
        /// Jupiter the eccentricity.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterEccentricity(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return 0.04849793 + 0.000163225 * timeT - 0.0000004714 * timeSquared - 0.00000000201 * timeCubed;
        }

        /// <summary>
        /// Jupiter the inclination.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double JupiterInclination(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(1.303267 - 0.0054965 * timeT + 0.00000466 * timeSquared - 0.000000002 * timeCubed);
        }

        /// <summary>
        /// Jupiter the longitude ascending node.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double JupiterLongitudeAscendingNode(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(100.464407 + 1.0209774 * timeT + 0.00040315 * timeSquared + 0.000000404 * timeCubed);
        }

        /// <summary>
        /// Jupiter the longitude perihelion.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterLongitudePerihelion(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(14.331207 + 1.6126352 * timeT + 0.00103042 * timeSquared - 0.000004464 * timeCubed);
        }

        #endregion

        #region Naughter - Aproximation J2000
        /// <summary>
        /// Jupiter the mean longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterMeanLongitudeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(34.351519 + 3034.9056606 * timeT - 0.00008501 * timeSquared + 0.000000016 * timeCubed);
        }

        /// <summary>
        /// Jupiter the inclination J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterInclinationJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(1.303267 - 0.0019877 * timeT + 0.00003320 * timeSquared + 0.000000097 * timeCubed);
        }

        /// <summary>
        /// Jupiter the longitude ascending node J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterLongitudeAscendingNodeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(100.464407 + 0.1767232 * timeT + 0.00090700 * timeSquared - 0.000007272 * timeCubed);
        }

        /// <summary>
        /// Jupiter the longitude perihelion J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterLongitudePerihelionJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(14.331207 + 0.2155209 * timeT + 0.00072211 * timeSquared - 0.000004485 * timeCubed);
        }

        #endregion

        #region Naughter - Magnitude
        /// <summary>
        /// Jupiter the magnitude muller.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double JupiterMagnitudeMuller(double givenParameter, double givenDelta) {
            return -8.93 + 5 * Math.Log10(givenParameter * givenDelta);
        }

        /// <summary>
        /// Jupiter the magnitude AA.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <param name="i">The i.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double JupiterMagnitudeAA(double givenParameter, double givenDelta, double i) {
            return -9.40 + 5 * Math.Log10(givenParameter * givenDelta) + 0.005 * i;
        }
        #endregion

        #region Naughter
        /// <summary>
        /// Jupiter the equatorial semidiameter A.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterEquatorialSemidiameterA(double givenDelta) {
            return 98.47 / givenDelta;
        }

        /// <summary>
        /// Jupiter the polar semidiameter A.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterPolarSemidiameterA(double givenDelta) {
            return 91.91 / givenDelta;
        }

        /// <summary>
        /// Jupiter the equatorial semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterEquatorialSemidiameterB(double givenDelta) {
            return 98.44 / givenDelta;
        }

        /// <summary>
        /// Jupiter the polar semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double JupiterPolarSemidiameterB(double givenDelta) {
            return 92.06 / givenDelta;
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
            for (i = 0; i < OrbitalData.VsopData.L0JupiterCoefficients.Length; i++) {
                l0 += OrbitalData.VsopData.L0JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L0JupiterCoefficients[i].B + OrbitalData.VsopData.L0JupiterCoefficients[i].C * rho);
            }

            //// Calculate L1
            double l1 = 0;
            for (i = 0; i < OrbitalData.VsopData.L1JupiterCoefficients.Length; i++) {
                l1 += OrbitalData.VsopData.L1JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L1JupiterCoefficients[i].B + OrbitalData.VsopData.L1JupiterCoefficients[i].C * rho);
            }

            //// Calculate L2
            double l2 = 0;
            for (i = 0; i < OrbitalData.VsopData.L2JupiterCoefficients.Length; i++) {
                l2 += OrbitalData.VsopData.L2JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L2JupiterCoefficients[i].B + OrbitalData.VsopData.L2JupiterCoefficients[i].C * rho);
            }

            //// Calculate L3
            double l3 = 0;
            for (i = 0; i < OrbitalData.VsopData.L3JupiterCoefficients.Length; i++) {
                l3 += OrbitalData.VsopData.L3JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L3JupiterCoefficients[i].B + OrbitalData.VsopData.L3JupiterCoefficients[i].C * rho);
            }

            //// Calculate L4
            double l4 = 0;
            for (i = 0; i < OrbitalData.VsopData.L4JupiterCoefficients.Length; i++) {
                l4 += OrbitalData.VsopData.L4JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L4JupiterCoefficients[i].B + OrbitalData.VsopData.L4JupiterCoefficients[i].C * rho);
            }

            //// Calculate L5
            double l5 = 0;
            for (i = 0; i < OrbitalData.VsopData.L5JupiterCoefficients.Length; i++) {
                l5 += OrbitalData.VsopData.L5JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.L5JupiterCoefficients[i].B + OrbitalData.VsopData.L5JupiterCoefficients[i].C * rho);
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
            for (i = 0; i < OrbitalData.VsopData.B0JupiterCoefficients.Length; i++) {
                b0 += OrbitalData.VsopData.B0JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B0JupiterCoefficients[i].B + OrbitalData.VsopData.B0JupiterCoefficients[i].C * rho);
            }

            //// Calculate B1
            double b1 = 0;
            for (i = 0; i < OrbitalData.VsopData.B1JupiterCoefficients.Length; i++) {
                b1 += OrbitalData.VsopData.B1JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B1JupiterCoefficients[i].B + OrbitalData.VsopData.B1JupiterCoefficients[i].C * rho);
            }

            //// Calculate B2
            double b2 = 0;
            for (i = 0; i < OrbitalData.VsopData.B2JupiterCoefficients.Length; i++) {
                b2 += OrbitalData.VsopData.B2JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B2JupiterCoefficients[i].B + OrbitalData.VsopData.B2JupiterCoefficients[i].C * rho);
            }

            //// Calculate B3
            double b3 = 0;
            for (i = 0; i < OrbitalData.VsopData.B3JupiterCoefficients.Length; i++) {
                b3 += OrbitalData.VsopData.B3JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B3JupiterCoefficients[i].B + OrbitalData.VsopData.B3JupiterCoefficients[i].C * rho);
            }

            //// Calculate B4
            double b4 = 0;
            for (i = 0; i < OrbitalData.VsopData.B4JupiterCoefficients.Length; i++) {
                b4 += OrbitalData.VsopData.B4JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B4JupiterCoefficients[i].B + OrbitalData.VsopData.B4JupiterCoefficients[i].C * rho);
            }

            //// Calculate B5
            double b5 = 0;
            for (i = 0; i < OrbitalData.VsopData.B5JupiterCoefficients.Length; i++) {
                b5 += OrbitalData.VsopData.B5JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.B5JupiterCoefficients[i].B + OrbitalData.VsopData.B5JupiterCoefficients[i].C * rho);
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
            for (i = 0; i < OrbitalData.VsopData.R0JupiterCoefficients.Length; i++) {
                r0 += OrbitalData.VsopData.R0JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R0JupiterCoefficients[i].B + OrbitalData.VsopData.R0JupiterCoefficients[i].C * rho);
            }

            //// Calculate R1
            double r1 = 0;
            for (i = 0; i < OrbitalData.VsopData.R1JupiterCoefficients.Length; i++) {
                r1 += OrbitalData.VsopData.R1JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R1JupiterCoefficients[i].B + OrbitalData.VsopData.R1JupiterCoefficients[i].C * rho);
            }

            //// Calculate R2
            double r2 = 0;
            for (i = 0; i < OrbitalData.VsopData.R2JupiterCoefficients.Length; i++) {
                r2 += OrbitalData.VsopData.R2JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R2JupiterCoefficients[i].B + OrbitalData.VsopData.R2JupiterCoefficients[i].C * rho);
            }

            //// Calculate R3
            double r3 = 0;
            for (i = 0; i < OrbitalData.VsopData.R3JupiterCoefficients.Length; i++) {
                r3 += OrbitalData.VsopData.R3JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R3JupiterCoefficients[i].B + OrbitalData.VsopData.R3JupiterCoefficients[i].C * rho);
            }

            //// Calculate R4
            double r4 = 0;
            for (i = 0; i < OrbitalData.VsopData.R4JupiterCoefficients.Length; i++) {
                r4 += OrbitalData.VsopData.R4JupiterCoefficients[i].A * Math.Cos(OrbitalData.VsopData.R4JupiterCoefficients[i].B + OrbitalData.VsopData.R4JupiterCoefficients[i].C * rho);
            }

            //// Calculate R5
            double r5 = 0;
            for (i = 0; i < OrbitalData.VsopData.R5JupiterCoefficients.Length; i++) {
                r5 += OrbitalData.VsopData.R5JupiterCoefficients[i].A *
                      Math.Cos(OrbitalData.VsopData.R5JupiterCoefficients[i].B + OrbitalData.VsopData.R5JupiterCoefficients[i].C * rho);
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

            double delta;
            switch (type) {
                case EventType.Opposition:
                    delta = (-0.1029 - 0.00009 * timeT2) +
                            Math.Sin(anomalyM) * (-1.9658 - 0.0056 * timeT + 0.00007 * timeT2) +
                            Math.Cos(anomalyM) * (6.1537 + 0.0210 * timeT - 0.00006 * timeT2) +
                            Math.Sin(2 * anomalyM) * (-0.2081 - 0.0013 * timeT) +
                            Math.Cos(2 * anomalyM) * (-0.1116 - 0.0010 * timeT) +
                            Math.Sin(3 * anomalyM) * (0.0074 + 0.0001 * timeT) +
                            Math.Cos(3 * anomalyM) * (-0.0097 - 0.0001 * timeT) +
                            Math.Sin(a) * (0.0144 * timeT - 0.00008 * timeT2) +
                            Math.Cos(a) * (0.3642 - 0.0019 * timeT - 0.00029 * timeT2);
                    break;
                case EventType.Conjunction:
                    delta = (0.1027 + 0.0002 * timeT - 0.00009 * timeT2) +
                            Math.Sin(anomalyM) * (-2.2637 + 0.0163 * timeT - 0.00003 * timeT2) +
                            Math.Cos(anomalyM) * (-6.1540 - 0.0210 * timeT + 0.00008 * timeT2) +
                            Math.Sin(2 * anomalyM) * (-0.2021 - 0.0017 * timeT + 0.00001 * timeT2) +
                            Math.Cos(2 * anomalyM) * (0.1310 - 0.0008 * timeT) +
                            Math.Sin(3 * anomalyM) * 0.0086 +
                            Math.Cos(3 * anomalyM) * (0.0087 + 0.0002 * timeT) +
                            Math.Sin(a) * (0.0144 * timeT - 0.00008 * timeT2) +
                            Math.Cos(a) * (0.3642 - 0.0019 * timeT - 0.00029 * timeT2);
                    break;
                case EventType.Station1:
                    delta = (-60.3670 - 0.0001 * timeT - 0.00009 * timeT2) +
                            Math.Sin(anomalyM) * (-2.3144 - 0.0124 * timeT + 0.00007 * timeT2) +
                            Math.Cos(anomalyM) * (6.7439 + 0.0166 * timeT - 0.00006 * timeT2) +
                            Math.Sin(2 * anomalyM) * (-0.2259 - 0.0010 * timeT) +
                            Math.Cos(2 * anomalyM) * (-0.1497 - 0.0014 * timeT) +
                            Math.Sin(3 * anomalyM) * (0.0105 + 0.0001 * timeT) +
                            Math.Cos(3 * anomalyM) * (-0.0098) +
                            Math.Sin(a) * (0.0144 * timeT - 0.00008 * timeT2) +
                            Math.Cos(a) * (0.3642 - 0.0019 * timeT - 0.00029 * timeT2);
                    break;
                default:
                    Debug.Assert(type == EventType.Station2, "Reason for the assert");
                    delta = (60.3023 + 0.0002 * timeT - 0.00009 * timeT2) +
                            Math.Sin(anomalyM) * (0.3506 - 0.0034 * timeT + 0.00004 * timeT2) +
                            Math.Cos(anomalyM) * (5.3635 + 0.0247 * timeT - 0.00007 * timeT2) +
                            Math.Sin(2 * anomalyM) * (-0.1872 - 0.0016 * timeT) +
                            Math.Cos(2 * anomalyM) * (-0.0037 - 0.0005 * timeT) +
                            Math.Sin(3 * anomalyM) * (0.0012 + 0.0001 * timeT) +
                            Math.Cos(3 * anomalyM) * (-0.0096 - 0.0001 * timeT) +
                            Math.Sin(a) * (0.0144 * timeT - 0.00008 * timeT2) +
                            Math.Cos(a) * (0.3642 - 0.0019 * timeT - 0.00029 * timeT2);
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

        /// <summary>
        /// Compute perturbations.
        /// </summary>
        public override void Perturbate() {
            switch (this.Variant) {
                case AlgVariant.VarBretagnon82:
                    this.PerturbateBretagnon82Longitude();
                    break;
                case AlgVariant.VarSchlyter:
                    this.PerturbateSchlyterLongitude();
                    break;
                case AlgVariant.None:
                    break;
                case AlgVariant.VarBretagnon87:
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
            double[] lw = { 100.4542, 2.76854e-5, 0.0, 0.0 };
            double[] i = { 1.3030, -1.557e-7, 0.0, 0.0 };
            double[] w = { 273.8777, +1.64505e-5, 0.0, 0.0 };
            double[] a = { 5.20256 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] e = { 0.048498, 4.469e-9, 0.0, 0.0 };
            double[] vm = { 19.8950, 0.0830853001, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }

        /// <summary>
        /// BRETAGNON  Vsop82.
        /// </summary>
        private void InitBretagnon82() {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            double[] a = { 5.2026032 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] lm = { 0.5995465, 52.969096500, -15e-7, 0.0 };
            double[] k = { 4.498570e-2, 1.130e-4, -11e-7, 0.0 };
            double[] h = { 1.200390e-2, 2.171e-4, 10e-7, 0.0 };
            double[] q = { -2.065600e-3, -3.130e-5, -2e-7, 0.0 };
            double[] p = { 1.118380e-2, -2.340e-5, 2e-7, 0.0 };
            this.BretElements = new BretagnonElements(a, lm, k, h, q, p);
        }

        /// <summary>
        /// BRETAGNON Vsop87.
        /// </summary>
        /// <param name="givenVsopPath">The given Vsop path.</param>
        private void InitBretagnon87(string givenVsopPath) {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            this.Vsop87.InitWith(givenVsopPath + "Vsop87.JUP", 0.0);
        }

        #endregion

        #region Perturbations
        /// <summary>
        /// Perturbate Schlyter Longitude.
        /// </summary>
        private void PerturbateSchlyterLongitude() {
            var j = SolarSystem.Singleton.Jupiter.VM;
            var s = SolarSystem.Singleton.Saturn.VM;
            var d1 = -0.332 * Angles.Sinus((2 * j) - (5 * s) - 67.6);
            var d2 = -0.056 * Angles.Sinus((2 * j) - (2 * s) + 21.0);
            var d3 = +0.042 * Angles.Sinus((3 * j) - (5 * s) + 21.0);
            var d4 = -0.036 * Angles.Sinus(j - (2 * s));
            var d5 = +0.022 * Angles.Cosin(j - s);
            var d6 = +0.023 * Angles.Sinus((2 * s) - (3 * j) + 52.0);
            var d7 = -0.016 * Angles.Sinus(j - (5 * s) - 69.0);
            var dLongitude = d1 + d2 + d3 + d4 + d5 + d6 + d7;
            this.Point.Longitude = this.Longitude + dLongitude;
        }

        /// <summary>
        /// Perturbate Bretagnon82 Longitude.
        /// </summary>
        private void PerturbateBretagnon82Longitude() {
            //// ifdef BRETAGNON
            var j = SolarSystem.Singleton.Jupiter.LM;
            var s = SolarSystem.Singleton.Saturn.LM;
            var d1 = (-56652 * Angles.Sinus((2 * j) - (5 * s))) - (8924 * Angles.Cosin((2 * j) - (5 * s)));
            var d2 = (6165 * Angles.Sinus(j - (2 * s))) - (902 * Angles.Cosin(j - (2 * s)));
            var dLongitude = Angles.RadDeg((d1 + d2) * 1e-7);
            this.Point.Longitude = this.Longitude + dLongitude;
        }
        #endregion
    }
}
