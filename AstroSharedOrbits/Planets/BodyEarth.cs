// <copyright file="BodyEarth.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Planets
{
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Coordinates;
    using AstroSharedClasses.Enums;
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedOrbits.OrbitalData;
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.Systems;
    using JetBrains.Annotations;
    using System;

    /// <summary> Orbit Body Earth. </summary>
    public sealed class BodyEarth : Orbit {
        /// <summary>
        /// The obliquity of the ecliptic
        /// double ie = 23.452294 - 0.0130125 * timeT - 0.00000164 * Math.Pow(timeT, 2) + 0.000000503 * Math.Pow(timeT, 3).
        /// </summary>
        //// private readonly double[] ie = { 23.452294, -0.0130125, -0.00000164, +0.000000503 };

        private readonly double[] ie = { 23.4392911, -0.013004167, -0.00000016389, +0.0000005036 };

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyEarth"/> class.
        /// </summary>
        public BodyEarth()
            : base("E", "Earth") {
            this.PerTime = 0.0;              ////
            this.Body.Mass = 5.975e24;            //// [kg]
            this.Body.Radius = 6.378e6;           //// [m]
            this.Body.J = 23.45;                   //// // [deg]
            this.Knke = 10;                   //// // 3
            //// Moon  = new BodyMoon;
            this.MeanPeriod = 1.000;
        }

        #region Naughter - PerihelionAphelion
        /// <summary>
        /// Earth the K.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static long EarthK(double year) {
            return (long)(0.99997 * (year - 2000.01));
        }

        /// <summary>
        /// Earth the perihelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <param name="bBarycentric">The b barycentric.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthPerihelion(long givenK, bool bBarycentric) {
            double kdash = givenK;
            var kSquared = kdash * kdash;
            var julianDay = 2451547.507 + 365.2596358 * kdash + 0.0000000156 * kSquared;

            if (bBarycentric) {
                return julianDay;
            }

            //// Apply the corrections
            var a1 = Angles.Mod360(328.41 + 132.788585 * givenK);
            a1 = Angles.DegRad(a1);
            var a2 = Angles.Mod360(316.13 + 584.903153 * givenK);
            a2 = Angles.DegRad(a2);
            var a3 = Angles.Mod360(346.20 + 450.380738 * givenK);
            a3 = Angles.DegRad(a3);
            var a4 = Angles.Mod360(136.95 + 659.306737 * givenK);
            a4 = Angles.DegRad(a4);
            var a5 = Angles.Mod360(249.52 + 329.653368 * givenK);
            a5 = Angles.DegRad(a5);

            julianDay += 1.278 * Math.Sin(a1);
            julianDay -= 0.055 * Math.Sin(a2);
            julianDay -= 0.091 * Math.Sin(a3);
            julianDay -= 0.056 * Math.Sin(a4);
            julianDay -= 0.045 * Math.Sin(a5);

            return julianDay;
        }

        /// <summary>
        /// Earth the aphelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <param name="bBarycentric">The b barycentric.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthAphelion(long givenK, bool bBarycentric) {
            var kdash = givenK + 0.5;
            var kSquared = kdash * kdash;
            var julianDay = 2451547.507 + 365.2596358 * kdash + 0.0000000156 * kSquared;

            if (bBarycentric) {
                return julianDay;
            }

            //// Apply the corrections
            var a1 = Angles.Mod360(328.41 + 132.788585 * givenK);
            a1 = Angles.DegRad(a1);
            var a2 = Angles.Mod360(316.13 + 584.903153 * givenK);
            a2 = Angles.DegRad(a2);
            var a3 = Angles.Mod360(346.20 + 450.380738 * givenK);
            a3 = Angles.DegRad(a3);
            var a4 = Angles.Mod360(136.95 + 659.306737 * givenK);
            a4 = Angles.DegRad(a4);
            var a5 = Angles.Mod360(249.52 + 329.653368 * givenK);
            a5 = Angles.DegRad(a5);

            julianDay -= 1.352 * Math.Sin(a1);
            julianDay += 0.061 * Math.Sin(a2);
            julianDay += 0.062 * Math.Sin(a3);
            julianDay += 0.029 * Math.Sin(a4);
            julianDay += 0.031 * Math.Sin(a5);

            return julianDay;
        }
        #endregion

        #region Naughter - Aproximation

        /// <summary>
        /// Earth the mean longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthMeanLongitude(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(100.466457 + 36000.7698278 * timeT + 0.00030322 * timeSquared + 0.000000020 * timeCubed);
        }

        /// <summary>
        /// Earth the semimajor axis.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthSemimajorAxis() {
            return 1.000001018;
        }

        /// <summary>
        /// Earth the eccentricity.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthEccentricity(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return 0.01670863 - 0.000042037 * timeT - 0.0000001267 * timeSquared + 0.00000000014 * timeCubed;
        }

        /// <summary>
        /// Earth the inclination.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthInclination() {
            return 0;
        }

        /// <summary>
        /// Earth the longitude perihelion.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthLongitudePerihelion(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(102.937348 + 1.17195366 * timeT + 0.00045688 * timeSquared - 0.000000018 * timeCubed);
        }
        #endregion

        #region Naughter - Aproximation J2000
        /// <summary>
        /// Earth the mean longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthMeanLongitudeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(100.466457 + 35999.3728565 * timeT - 0.00000568 * timeSquared - 0.000000001 * timeCubed);
        }

        /// <summary>
        /// Earth the inclination J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthInclinationJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return 0.0130548 * timeT - 0.00000931 * timeSquared - 0.000000034 * timeCubed;
        }

        /// <summary>
        /// Earth the longitude ascending node J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthLongitudeAscendingNodeJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(174.873176 - 0.241098 * timeT + 0.00004262 * timeSquared + 0.000000001 * timeCubed);
        }

        /// <summary>
        /// Earth the longitude perihelion J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double EarthLongitudePerihelionJ2000(double julianDay) {
            var timeT = (julianDay - 2451545.0) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;

            return Angles.Mod360(102.937348 + 0.3225654 * timeT + 0.00014799 * timeSquared - 0.000000039 * timeCubed);
        }

        #endregion

        #region Naughter
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
            var nL0Coefficients = VsopData.L0EarthCoefficients.Length;
            double l0 = 0;
            for (var i = 0; i < nL0Coefficients; i++) {
                l0 += VsopData.L0EarthCoefficients[i].A *
                      Math.Cos(VsopData.L0EarthCoefficients[i].B + VsopData.L0EarthCoefficients[i].C * rho);
            }

            //// Calculate L1
            var nL1Coefficients = VsopData.L1EarthCoefficients.Length;
            double l1 = 0;
            for (var i = 0; i < nL1Coefficients; i++) {
                l1 += VsopData.L1EarthCoefficients[i].A * Math.Cos(VsopData.L1EarthCoefficients[i].B + VsopData.L1EarthCoefficients[i].C * rho);
            }

            //// Calculate L2
            var nL2Coefficients = VsopData.L2EarthCoefficients.Length;
            double l2 = 0;
            for (var i = 0; i < nL2Coefficients; i++) {
                l2 += VsopData.L2EarthCoefficients[i].A * Math.Cos(VsopData.L2EarthCoefficients[i].B + VsopData.L2EarthCoefficients[i].C * rho);
            }

            //// Calculate L3
            var nL3Coefficients = VsopData.L3EarthCoefficients.Length;
            double l3 = 0;
            for (var i = 0; i < nL3Coefficients; i++) {
                l3 += VsopData.L3EarthCoefficients[i].A * Math.Cos(VsopData.L3EarthCoefficients[i].B + VsopData.L3EarthCoefficients[i].C * rho);
            }

            //// Calculate L4
            var nL4Coefficients = VsopData.L4EarthCoefficients.Length;
            double l4 = 0;
            for (var i = 0; i < nL4Coefficients; i++) {
                l4 += VsopData.L4EarthCoefficients[i].A * Math.Cos(VsopData.L4EarthCoefficients[i].B + VsopData.L4EarthCoefficients[i].C * rho);
            }

            //// Calculate L5
            var nL5Coefficients = VsopData.L5EarthCoefficients.Length;
            double l5 = 0;
            for (var i = 0; i < nL5Coefficients; i++) {
                l5 += VsopData.L5EarthCoefficients[i].A * Math.Cos(VsopData.L5EarthCoefficients[i].B + VsopData.L5EarthCoefficients[i].C * rho);
            }

            var val = (l0 + l1 * rho + l2 * rhoSquared + l3 * rhoCubed + l4 * rho4 + l5 * rho5) / 100000000.0;

            //// convert results back to degrees
            val = Angles.Mod360(Angles.RadDeg(val));
            return val;
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
            var nB0Coefficients = VsopData.B0EarthCoefficients.Length;
            double b0 = 0;
            for (var i = 0; i < nB0Coefficients; i++) {
                b0 += VsopData.B0EarthCoefficients[i].A *
                      Math.Cos(VsopData.B0EarthCoefficients[i].B + VsopData.B0EarthCoefficients[i].C * rho);
            }

            //// Calculate B1
            var nB1Coefficients = VsopData.B1EarthCoefficients.Length;
            double b1 = 0;
            for (var i = 0; i < nB1Coefficients; i++) {
                b1 += VsopData.B1EarthCoefficients[i].A * Math.Cos(VsopData.B1EarthCoefficients[i].B + VsopData.B1EarthCoefficients[i].C * rho);
            }

            //// Calculate B2
            var nB2Coefficients = VsopData.B2EarthCoefficients.Length;
            double b2 = 0;
            for (var i = 0; i < nB2Coefficients; i++) {
                b2 += VsopData.B2EarthCoefficients[i].A * Math.Cos(VsopData.B2EarthCoefficients[i].B + VsopData.B2EarthCoefficients[i].C * rho);
            }

            //// Calculate B3
            var nB3Coefficients = VsopData.B3EarthCoefficients.Length;
            double b3 = 0;
            for (var i = 0; i < nB3Coefficients; i++) {
                b3 += VsopData.B3EarthCoefficients[i].A * Math.Cos(VsopData.B3EarthCoefficients[i].B + VsopData.B3EarthCoefficients[i].C * rho);
            }

            //// Calculate B4
            var nB4Coefficients = VsopData.B4EarthCoefficients.Length;
            double b4 = 0;
            for (var i = 0; i < nB4Coefficients; i++) {
                b4 += VsopData.B4EarthCoefficients[i].A * Math.Cos(VsopData.B4EarthCoefficients[i].B + VsopData.B4EarthCoefficients[i].C * rho);
            }

            var val = (b0 + b1 * rho + b2 * rhoSquared + b3 * rhoCubed + b4 * rho4) / 100000000.0;

            //// convert results back to degrees
            val = Angles.RadDeg(val);
            return val;
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
            var nR0Coefficients = VsopData.R0EarthCoefficients.Length;
            double r0 = 0;
            for (var i = 0; i < nR0Coefficients; i++) {
                r0 += VsopData.R0EarthCoefficients[i].A * Math.Cos(VsopData.R0EarthCoefficients[i].B + VsopData.R0EarthCoefficients[i].C * rho);
            }

            //// Calculate R1
            var nR1Coefficients = VsopData.R1EarthCoefficients.Length;
            double r1 = 0;
            for (var i = 0; i < nR1Coefficients; i++) {
                r1 += VsopData.R1EarthCoefficients[i].A * Math.Cos(VsopData.R1EarthCoefficients[i].B + VsopData.R1EarthCoefficients[i].C * rho);
            }

            //// Calculate R2
            var nR2Coefficients = VsopData.R2EarthCoefficients.Length;
            double r2 = 0;
            for (var i = 0; i < nR2Coefficients; i++) {
                r2 += VsopData.R2EarthCoefficients[i].A * Math.Cos(VsopData.R2EarthCoefficients[i].B + VsopData.R2EarthCoefficients[i].C * rho);
            }

            //// Calculate R3
            var nR3Coefficients = VsopData.R3EarthCoefficients.Length;
            double r3 = 0;
            for (var i = 0; i < nR3Coefficients; i++) {
                r3 += VsopData.R3EarthCoefficients[i].A * Math.Cos(VsopData.R3EarthCoefficients[i].B + VsopData.R3EarthCoefficients[i].C * rho);
            }

            //// Calculate R4
            var nR4Coefficients = VsopData.R4EarthCoefficients.Length;
            double r4 = 0;
            for (var i = 0; i < nR4Coefficients; i++) {
                r4 += VsopData.R4EarthCoefficients[i].A *
                      Math.Cos(VsopData.R4EarthCoefficients[i].B + VsopData.R4EarthCoefficients[i].C * rho);
            }

            return (r0 + r1 * rho + r2 * rhoSquared + r3 * rhoCubed + r4 * rho4) / 100000000.0;
        }

        /// <summary>
        /// Ecliptic longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julian day.</param>
        /// <returns> Returns value. </returns>
        public static double EclipticLongitudeJ2000(double julianDay) {
            var rho = (julianDay - 2451545) / 365250;
            var rhoSquared = rho * rho;
            var rhoCubed = rhoSquared * rho;
            var rho4 = rhoCubed * rho;

            //// Calculate L0
            var nL0Coefficients = VsopData.L0EarthCoefficients.Length;
            double l0 = 0;
            for (var i = 0; i < nL0Coefficients; i++) {
                l0 += VsopData.L0EarthCoefficients[i].A * Math.Cos(VsopData.L0EarthCoefficients[i].B + VsopData.L0EarthCoefficients[i].C * rho);
            }

            //// Calculate L1
            var nL1Coefficients = VsopData.L1EarthCoefficientsJ2000.Length;
            double l1 = 0;
            for (var i = 0; i < nL1Coefficients; i++) {
                l1 += VsopData.L1EarthCoefficientsJ2000[i].A * Math.Cos(VsopData.L1EarthCoefficientsJ2000[i].B + VsopData.L1EarthCoefficientsJ2000[i].C * rho);
            }

            //// Calculate L2
            var nL2Coefficients = VsopData.L2EarthCoefficientsJ2000.Length;
            double l2 = 0;
            for (var i = 0; i < nL2Coefficients; i++) {
                l2 += VsopData.L2EarthCoefficientsJ2000[i].A * Math.Cos(VsopData.L2EarthCoefficientsJ2000[i].B + VsopData.L2EarthCoefficientsJ2000[i].C * rho);
            }

            //// Calculate L3
            var nL3Coefficients = VsopData.L3EarthCoefficientsJ2000.Length;
            double l3 = 0;
            for (var i = 0; i < nL3Coefficients; i++) {
                l3 += VsopData.L3EarthCoefficientsJ2000[i].A * Math.Cos(VsopData.L3EarthCoefficientsJ2000[i].B + VsopData.L3EarthCoefficientsJ2000[i].C * rho);
            }

            //// Calculate L4
            var nL4Coefficients = VsopData.L4EarthCoefficientsJ2000.Length;
            double l4 = 0;
            for (var i = 0; i < nL4Coefficients; i++) {
                l4 += VsopData.L4EarthCoefficientsJ2000[i].A * Math.Cos(VsopData.L4EarthCoefficientsJ2000[i].B + VsopData.L4EarthCoefficientsJ2000[i].C * rho);
            }

            var val = (l0 + l1 * rho + l2 * rhoSquared + l3 * rhoCubed + l4 * rho4) / 100000000.0;

            //// convert results back to degrees
            val = Angles.Mod360(Angles.RadDeg(val));
            return val;
        }

        /// <summary>
        /// Ecliptic latitude J2000.
        /// </summary>
        /// <param name="julianDay">The julian day.</param>
        /// <returns> Returns value. </returns>
        public static double EclipticLatitudeJ2000(double julianDay) {
            var rho = (julianDay - 2451545) / 365250;
            var rhoSquared = rho * rho;
            var rhoCubed = rhoSquared * rho;
            var rho4 = rhoCubed * rho;

            //// Calculate B0
            var nB0Coefficients = VsopData.B0EarthCoefficients.Length;
            double b0 = 0;
            for (var i = 0; i < nB0Coefficients; i++) {
                b0 += VsopData.B0EarthCoefficients[i].A * Math.Cos(VsopData.B0EarthCoefficients[i].B + VsopData.B0EarthCoefficients[i].C * rho);
            }

            //// Calculate B1
            var nB1Coefficients = VsopData.B1EarthCoefficientsJ2000.Length;
            double b1 = 0;
            for (var i = 0; i < nB1Coefficients; i++) {
                b1 += VsopData.B1EarthCoefficientsJ2000[i].A * Math.Cos(VsopData.B1EarthCoefficientsJ2000[i].B + VsopData.B1EarthCoefficientsJ2000[i].C * rho);
            }

            //// Calculate B2
            var nB2Coefficients = VsopData.B2EarthCoefficientsJ2000.Length;
            double b2 = 0;
            for (var i = 0; i < nB2Coefficients; i++) {
                b2 += VsopData.B2EarthCoefficientsJ2000[i].A * Math.Cos(VsopData.B2EarthCoefficientsJ2000[i].B + VsopData.B2EarthCoefficientsJ2000[i].C * rho);
            }

            //// Calculate B3
            var nB3Coefficients = VsopData.B3EarthCoefficientsJ2000.Length;
            double b3 = 0;
            for (var i = 0; i < nB3Coefficients; i++) {
                b3 += VsopData.B3EarthCoefficientsJ2000[i].A * Math.Cos(VsopData.B3EarthCoefficientsJ2000[i].B + VsopData.B3EarthCoefficientsJ2000[i].C * rho);
            }

            //// Calculate B4
            var nB4Coefficients = VsopData.B4EarthCoefficientsJ2000.Length;
            double b4 = 0;
            for (var i = 0; i < nB4Coefficients; i++) {
                b4 += VsopData.B4EarthCoefficientsJ2000[i].A * Math.Cos(VsopData.B4EarthCoefficientsJ2000[i].B + VsopData.B4EarthCoefficientsJ2000[i].C * rho);
            }

            var val = (b0 + b1 * rho + b2 * rhoSquared + b3 * rhoCubed + b4 * rho4) / 100000000.0;

            //// convert results back to degrees
            val = Angles.RadDeg(val);
            return val;
        }

        /// <summary>
        /// Suns the mean anomaly.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double SunMeanAnomaly(double julianDay) {
            var timeT = (julianDay - 2451545) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;
            return Angles.Mod360(357.5291092 + 35999.0502909 * timeT - 0.0001536 * timeSquared + timeCubed / 24490000);
        }

        /// <summary>
        /// Eccentricities the specified julianDay.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double Eccentricity(double julianDay) {
            var timeT = (julianDay - 2451545) / 36525;
            var timeSquared = timeT * timeT;
            return 1 - 0.002516 * timeT - 0.0000074 * timeSquared;
        }

        #endregion

        /* Temporarily not used
        /// <summary>
        /// Set Julian Date.
        /// </summary>
        /// <param name="givenJulianDay"></param>
        public override void SetJulianDate(double givenJulianDay) {
            base.SetJulianDate(givenJulianDay);
            //// SATELLITES
            //// Moon.SetJulianDate(givenJulianDay);
        }*/

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
        /// Calculates the dependent properties.
        /// </summary>
        protected override void CalculateDependentProperties() {
            base.CalculateDependentProperties();
            this.EclipticObliquity = Angles.Mod360(AstroMath.HornerSum(this.ie, this.Time.Jecy));   //// The obliquity of the ecliptic

            double sunAsc = 0, sunDec = 0;
            if (SystemManager.CurrentSystem == AstSystem.Earth)
            {
                sunAsc = Angles.Mod360(EarthSystem.Earth.Longitude + 180);
                sunDec = Angles.Mod360(-EarthSystem.Earth.Point.Latitude);
            }

            if (SystemManager.CurrentSystem == AstSystem.Solar) {
                sunAsc = Angles.Mod360(SolarSystem.Singleton.Earth.Longitude + 180);
                sunDec = Angles.Mod360(-SolarSystem.Singleton.Earth.Point.Latitude);
            }
            //// this.SunRightAscension = sunAsc;
                //// this.SunDeclination = sunDec;

            var ecliptic = new CoordinateEcliptic2D {
                Lambda = sunAsc,
                Beta = sunDec
            };

            var equatorial = ecliptic.ToEquatorial(this.EclipticObliquity);
            this.SunRightAscension = equatorial.Alpha;
            this.SunDeclination = equatorial.Delta;            
        }

        #region Initializers
        /// <summary>
        /// Init Schlyter.
        /// </summary>
        private void InitSchlyter() {
            this.Time.EpochOrbit = 2451543.5;
            this.Time.EpochEquinox = 2451543.5;
            double[] lw = { 0.0, 0.0, 0.0, 0.0 };
            double[] i = { 0.0, 0.0, 0.0, 0.0 };
            double[] w = { 282.9404, 4.70935e-5, 0.0, 0.0 };
            double[] a = { 1.000000 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] e = { 0.016709, -1.151e-9, 0.0, 0.0 };
            double[] vm = { 356.0470, 0.9856002585, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
            //// Moon->InitSchlyter();
        }

        /// <summary>
        /// BRETAGNON Vsop82.
        /// </summary>
        private void InitBretagnon82() {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            double[] a = { 1.0000010 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] lm = { 1.7534703, 628.30758490, -1e-7, 0.0 };
            double[] k = { -3.740800e-3, -8.230e-5, 3e-7, 0.0 };
            double[] h = { 1.628450e-2, -6.200e-5, -3e-7, 0.0 };
            double[] q = { 0.0, -1.135e-4, 1e-7, 0.0 };
            double[] p = { 0.0, 1.020e-5, 5e-7, 0.0 };
            this.BretElements = new BretagnonElements(a, lm, k, h, q, p);
            //// SATELLITES  //  Moon->InitBretagnon();
        }

        /// <summary>
        /// BRETAGNON Vsop87.
        /// </summary>
        /// <param name="givenVsopPath">The given Vsop path.</param>
        private void InitBretagnon87(string givenVsopPath) {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            this.Vsop87.InitWith(givenVsopPath + "Vsop87.EMB", 0.0);
        }
        #endregion
    }
}
