// <copyright file="BodyNeptune.cs" company="Traced-Ideas, Czech republic">
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
    /// Initializes a new instance of the BodyNeptune class.
    /// </summary>
    public sealed class BodyNeptune : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyNeptune"/> class.
        /// </summary>
        public BodyNeptune()
            : base("N", "Neptune") {
            this.PerTime = 1876.668072;      ////
            this.Body.Mass = 102.43e24;          //// [kg]
            this.Body.Radius = 24.766e6;          //// [m]
            this.Body.J = 29.56;              //// [deg]
            this.Knke = 10;                 //// 3;       
            this.MeanPeriod = 164.79;
        }

        #region Naughter - PerihelionAphelion
        /// <summary>
        /// Neptune the K.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static long NeptuneK(double year) {
            return (long)(0.00607 * (year - 2047.5));
        }

        /// <summary>
        /// Neptune the perihelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusPerihelion(long givenK) {
            double kdash = givenK;
            var kSquared = kdash * kdash;
            return 2468895.1 + 60190.33 * kdash + 0.03429 * kSquared;
        }

        /// <summary>
        /// Neptune the aphelion.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeeusAphelion(long givenK) {
            var kdash = givenK + 0.5;
            var kSquared = kdash * kdash;
            return 2468895.1 + 60190.33 * kdash + 0.03429 * kSquared;
        }
        #endregion

        #region Naughter - Aproximation

        /// <summary>
        /// Neptune the mean longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneMeanLongitude(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeSquared = julianCentury * julianCentury;
            var timeCubed = timeSquared * julianCentury;

            return Angles.Mod360(304.348665 + 219.8833092 * julianCentury + 0.00030882 * timeSquared + 0.000000018 * timeCubed);
        }

        /// <summary>
        /// Neptune the semimajor axis.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneSemimajorAxis(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeSquared = julianCentury * julianCentury;

            return 30.110386869 - 0.0000001663 * julianCentury + 0.00000000069 * timeSquared;
        }

        /// <summary>
        /// Neptune the eccentricity.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneEccentricity(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeCubed = julianCentury * julianCentury * julianCentury;

            return 0.00945575 + 0.000006033 * julianCentury - 0.00000000005 * timeCubed;
        }

        /// <summary>
        /// Neptune the inclination.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneInclination(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeSquared = julianCentury * julianCentury;
            var timeCubed = timeSquared * julianCentury;

            return Angles.Mod360(1.769953 - 0.0093082 * julianCentury - 0.00000708 * timeSquared + 0.000000027 * timeCubed);
        }

        /// <summary>
        /// Neptune the longitude ascending node.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneLongitudeAscendingNode(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeSquared = julianCentury * julianCentury;
            var timeCubed = timeSquared * julianCentury;

            return Angles.Mod360(131.784057 + 1.1022039 * julianCentury + 0.00025952 * timeSquared - 0.000000637 * timeCubed);
        }

        /// <summary>
        /// Neptune the longitude perihelion.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneLongitudePerihelion(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeSquared = julianCentury * julianCentury;
            var timeCubed = timeSquared * julianCentury;

            return Angles.Mod360(48.120276 + 1.4262957 * julianCentury + 0.00038434 * timeSquared + 0.000000020 * timeCubed);
        }

        #endregion

        #region Naughter - Aproximation J2000
        /// <summary>
        /// Neptune the mean longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneMeanLongitudeJ2000(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeSquared = julianCentury * julianCentury;
            var timeCubed = timeSquared * julianCentury;

            return Angles.Mod360(304.348665 + 218.4862002 * julianCentury + 0.00000059 * timeSquared - 0.000000002 * timeCubed);
        }

        /// <summary>
        /// Neptune the inclination J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneInclinationJ2000(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeSquared = julianCentury * julianCentury;

            return Angles.Mod360(1.769953 + 0.0002256 * julianCentury + 0.00000023 * timeSquared);
        }

        /// <summary>
        /// Neptune the longitude ascending node J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneLongitudeAscendingNodeJ2000(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeSquared = julianCentury * julianCentury;
            var timeCubed = timeSquared * julianCentury;

            return Angles.Mod360(131.784057 - 0.0061651 * julianCentury - 0.00000219 * timeSquared - 0.000000078 * timeCubed);
        }

        /// <summary>
        /// Neptune the longitude perihelion J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneLongitudePerihelionJ2000(double julianDay) {
            var julianCentury = (julianDay - 2451545.0) / 36525;
            var timeSquared = julianCentury * julianCentury;

            return Angles.Mod360(48.120276 + 0.0291866 * julianCentury + 0.00007610 * timeSquared);
        }
        #endregion

        #region Naughter - Magnitude
        /// <summary>
        /// Neptune the magnitude muller.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double NeptuneMagnitudeMuller(double givenParameter, double givenDelta) {
            return -7.05 + 5 * Math.Log10(givenParameter * givenDelta);
        }

        /// <summary>
        /// Neptune the magnitude AA.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double NeptuneMagnitudeAA(double givenParameter, double givenDelta) {
            return -6.87 + 5 * Math.Log10(givenParameter * givenDelta);
        }
        #endregion

        #region Naughter
        /// <summary>
        /// Neptune the semidiameter A.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneSemidiameterA(double givenDelta)
        {
            return 36.56 / givenDelta;
        }

        /// <summary>
        /// Neptune the semidiameter B.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double NeptuneSemidiameterB(double givenDelta)
        {
            return 33.50 / givenDelta;
        }

        /// <summary>
        /// Ecliptic longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double EclipticLongitude(double julianDay)
        {
            var rho = (julianDay - 2451545) / 365250;
            var rhoSquared = rho * rho;
            var rhoCubed = rhoSquared * rho;
            var rho4 = rhoCubed * rho;

            //// Calculate L0
            double l0 = 0;
            int i;
            for (i = 0; i < VsopData.L0NeptuneCoefficients.Length; i++) {
                l0 += VsopData.L0NeptuneCoefficients[i].A * Math.Cos(VsopData.L0NeptuneCoefficients[i].B + VsopData.L0NeptuneCoefficients[i].C * rho);
            }

            //// Calculate L1
            double l1 = 0;
            for (i = 0; i < VsopData.L1NeptuneCoefficients.Length; i++) {
                l1 += VsopData.L1NeptuneCoefficients[i].A * Math.Cos(VsopData.L1NeptuneCoefficients[i].B + VsopData.L1NeptuneCoefficients[i].C * rho);
            }

            //// Calculate L2
            double l2 = 0;
            for (i = 0; i < VsopData.L2NeptuneCoefficients.Length; i++) {
                l2 += VsopData.L2NeptuneCoefficients[i].A * Math.Cos(VsopData.L2NeptuneCoefficients[i].B + VsopData.L2NeptuneCoefficients[i].C * rho);
            }

            //// Calculate L3
            double l3 = 0;
            for (i = 0; i < VsopData.L3NeptuneCoefficients.Length; i++) {
                l3 += VsopData.L3NeptuneCoefficients[i].A * Math.Cos(VsopData.L3NeptuneCoefficients[i].B + VsopData.L3NeptuneCoefficients[i].C * rho);
            }

            //// Calculate L4
            double l4 = 0;
            for (i = 0; i < VsopData.L4NeptuneCoefficients.Length; i++) {
                l4 += VsopData.L4NeptuneCoefficients[i].A * Math.Cos(VsopData.L4NeptuneCoefficients[i].B + VsopData.L4NeptuneCoefficients[i].C * rho);
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
        public static double EclipticLatitude(double julianDay)
        {
            var rho = (julianDay - 2451545) / 365250;
            var rhoSquared = rho * rho;
            var rhoCubed = rhoSquared * rho;
            var rho4 = rhoCubed * rho;

            //// Calculate B0
            double b0 = 0;
            int i;
            for (i = 0; i < VsopData.B0NeptuneCoefficients.Length; i++) {
                b0 += VsopData.B0NeptuneCoefficients[i].A * Math.Cos(VsopData.B0NeptuneCoefficients[i].B + VsopData.B0NeptuneCoefficients[i].C * rho);
            }

            //// Calculate B1
            double b1 = 0;
            for (i = 0; i < VsopData.B1NeptuneCoefficients.Length; i++) {
                b1 += VsopData.B1NeptuneCoefficients[i].A * Math.Cos(VsopData.B1NeptuneCoefficients[i].B + VsopData.B1NeptuneCoefficients[i].C * rho);
            }

            //// Calculate B2
            double b2 = 0;
            for (i = 0; i < VsopData.B2NeptuneCoefficients.Length; i++) {
                b2 += VsopData.B2NeptuneCoefficients[i].A * Math.Cos(VsopData.B2NeptuneCoefficients[i].B + VsopData.B2NeptuneCoefficients[i].C * rho);
            }

            //// Calculate B3
            double b3 = 0;
            for (i = 0; i < VsopData.B3NeptuneCoefficients.Length; i++) {
                b3 += VsopData.B3NeptuneCoefficients[i].A * Math.Cos(VsopData.B3NeptuneCoefficients[i].B + VsopData.B3NeptuneCoefficients[i].C * rho);
            }

            //// Calculate B4
            double b4 = 0;
            for (i = 0; i < VsopData.B4NeptuneCoefficients.Length; i++) {
                b4 += VsopData.B4NeptuneCoefficients[i].A * Math.Cos(VsopData.B4NeptuneCoefficients[i].B + VsopData.B4NeptuneCoefficients[i].C * rho);
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
        public static double RadiusVector(double julianDay)
        {
            var rho = (julianDay - 2451545) / 365250;
            var rhoSquared = rho * rho;
            var rhoCubed = rhoSquared * rho;

            //// Calculate R0
            double r0 = 0;
            int i;
            for (i = 0; i < VsopData.R0NeptuneCoefficients.Length; i++) {
                r0 += VsopData.R0NeptuneCoefficients[i].A * Math.Cos(VsopData.R0NeptuneCoefficients[i].B + VsopData.R0NeptuneCoefficients[i].C * rho);
            }

            //// Calculate R1
            double r1 = 0;
            for (i = 0; i < VsopData.R1NeptuneCoefficients.Length; i++) {
                r1 += VsopData.R1NeptuneCoefficients[i].A * Math.Cos(VsopData.R1NeptuneCoefficients[i].B + VsopData.R1NeptuneCoefficients[i].C * rho);
            }

            //// Calculate R2
            double r2 = 0;
            for (i = 0; i < VsopData.R2NeptuneCoefficients.Length; i++) {
                r2 += VsopData.R2NeptuneCoefficients[i].A * Math.Cos(VsopData.R2NeptuneCoefficients[i].B + VsopData.R2NeptuneCoefficients[i].C * rho);
            }

            //// Calculate R3
            double r3 = 0;
            for (i = 0; i < VsopData.R3NeptuneCoefficients.Length; i++) {
                r3 += VsopData.R3NeptuneCoefficients[i].A * Math.Cos(VsopData.R3NeptuneCoefficients[i].B + VsopData.R3NeptuneCoefficients[i].C * rho);
            }

            return (r0 + r1 * rho + r2 * rhoSquared + r3 * rhoCubed) / 100000000;
        }

        #endregion

        #region Naughter - Phenomena
        /// <summary>
        /// Planetary phenomena delta.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="anomalyM">The anomalyM.</param>
        /// <param name="julianCentury">The julianCentury.</param>
        /// <param name="timeT2">The t2.</param>
        /// <returns> Returns value. </returns>
        public static double PlanetaryPhenomenaDelta(EventType type, double anomalyM, double julianCentury, double timeT2) {
            var e = Angles.Mod360(207.83 + 8.51 * julianCentury);
            e = Angles.DegRad(e);
            var g = Angles.Mod360(276.74 + 209.98 * julianCentury);
            g = Angles.DegRad(g);
            
            double delta;
            //// Debug.Assert(obj == SolarSystemObject.Neptune, "Reason for the assert");

            if (type == EventType.Opposition) {
                delta = (-0.0140 + 0.00001 * timeT2) +
                        Math.Sin(anomalyM) * (-1.3486 + 0.0010 * julianCentury + 0.00001 * timeT2) +
                        Math.Cos(anomalyM) * (0.8597 + 0.0037 * julianCentury) +
                        Math.Sin(2 * anomalyM) * (-0.0082 - 0.0002 * julianCentury + 0.00001 * timeT2) +
                        Math.Cos(2 * anomalyM) * (0.0037 - 0.0003 * julianCentury) +
                        Math.Cos(e) * -0.5964 +
                        Math.Cos(g) * 0.0728;
            }
            else {
                Debug.Assert(type == EventType.Conjunction, "Reason for the assert");

                delta = 0.0168 +
                        Math.Sin(anomalyM) * (-2.5606 + 0.0088 * julianCentury + 0.00002 * timeT2) +
                        Math.Cos(anomalyM) * (-0.8611 - 0.0037 * julianCentury + 0.00002 * timeT2) +
                        Math.Sin(2 * anomalyM) * (0.0118 - 0.0004 * julianCentury + 0.00001 * timeT2) +
                        Math.Cos(2 * anomalyM) * (0.0307 - 0.0003 * julianCentury) +
                        Math.Cos(e) * (-0.5964) +
                        Math.Cos(g) * 0.0728;
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

        #region Initializers
        /// <summary>
        /// Init Schlyter.
        /// </summary>
        private void InitSchlyter() {
            this.Time.EpochOrbit = 2451543.5;
            this.Time.EpochEquinox = 2451543.5;
            double[] lw = { 131.7806, 3.0173e-5, 0.0, 0.0 };
            double[] i = { 1.7700, -2.55e-7, 0.0, 0.0 };
            double[] w = { 272.8461, -6.027e-6, 0.0, 0.0 };
            double[] a = { 30.05826 * AstroMath.AstroUnit, 3.313e-8, 0.0, 0.0 };
            double[] e = { 0.008606, 2.15e-9, 0.0, 0.0 };
            double[] vm = { 260.2471, 0.005995147, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }

        /// <summary>
        /// BRETAGNON VSOP82.
        /// </summary>
        private void InitBretagnon82() {
            this.Time.EpochOrbit = 2451545;
            this.Time.EpochEquinox = 2451545;
            double[] a = { 30.110387 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] lm = { 5.3118860, 3.8133040000, 0.0, 0.0 };
            double[] k = { 6.000000e-3, 1.000e-6, 0.0, 0.0 };
            double[] h = { 6.692000e-3, 8.000e-6, 0.0, 0.0 };
            double[] q = { -1.029100e-2, 0.00, 0.00, 0.0 };
            double[] p = { 1.151700e-2, 3.000e-6, 0.00, 0.0 };
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
            this.Vsop87.InitWith(givenVsopPath + "Vsop87.NEP", 0.0);
        }
        #endregion
    }
}
