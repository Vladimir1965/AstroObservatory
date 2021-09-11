// <copyright file="BodyMoonSchlyter.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Moons {
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.OrbitalElements;
    using JetBrains.Annotations;

    /// <summary>
    /// Initializes a new instance of the BodyMoon class.
    /// </summary>
    [UsedImplicitly]
    public sealed class BodyMoonSchlyter : BodyMoon {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyMoonSchlyter"/> class.
        /// </summary>
        public BodyMoonSchlyter()
            : base("MO", "Schlyter") {
            this.PerTime = 0.0;             ////
            this.Body.Mass = 7.349e22;           //// [kg]
            this.Body.Radius = 1.7380e6;         //// [m]
            ////  T=2.73217e1;
            this.Body.J = 0.00;                    //// // [deg]
            this.Knke = 5;                    //// //
        }

        /// <summary>
        /// Init Schlyter.
        /// </summary>
        public override void Init() {
            this.Time.EpochOrbit = 2451543.5;   // (2451545.0)
            this.Time.EpochEquinox = 2451543.5;
            double[] lw = { 125.1228, -0.0529538083, 0.0, 0.0 };
            double[] i = { 5.1454, 0.0, 0.0, 0.0 };
            double[] w = { 318.0634, 0.1643573223, 0.0, 0.0 };
            double[] a = { 3.8438e8, 0.0, 0.0, 0.0 };
            double[] e = { 0.054900, 0.0, 0.0, 0.0 };
            double[] vm = { 115.3654, 13.0649929509, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }

        /// <summary>
        /// Compute perturbations.
        /// </summary>
        public override void Perturbate()
        {
            this.PerturbateLongitude();
            this.PerturbateLatitude();
            //// this.PerturbateDistance();
        }

        #region Perturbations

        /// <summary>
        /// Perturbate Schlyter Distance.
        /// </summary>
        [UsedImplicitly]
        private void PerturbateDistance() {
            const double value = 23455.65184;
            var lme = Systems.EarthSystem.Earth.LM;     ////   double VMe=Earth->VM;
            this.D = this.LM - lme;                        //// // Moon's mean elongation
            ////   double this.LatitudeF= LM-LW;             //// Moon's argument of latitude
            var d01 = -0.580 / value * Angles.Cosin(VM - (2 * this.D));
            var d02 = -0.460 / value * Angles.Cosin(2 * this.D);
            var dRT = d01 + d02;
            this.Point.RT = this.Point.RT + dRT;
        }

        /// <summary>
        /// Perturbate Schlyter Longitude.
        /// </summary>
        private void PerturbateLongitude() {
            var lme = Systems.EarthSystem.Earth.LM;
            var vme = Systems.EarthSystem.Earth.VM;
            this.D = this.LM - lme;       //// Moon's mean elongation
            this.LatitudeF = this.LM - this.LW;        //// Moon's argument of latitude
            var d01 = -1.274 * Angles.Sinus(VM - (2 * this.D));
            var d02 = +0.658 * Angles.Sinus(2 * this.D);
            var d03 = -0.186 * Angles.Sinus(vme);
            var d04 = -0.059 * Angles.Sinus((2 * VM) - (2 * this.D));
            var d05 = -0.057 * Angles.Sinus(VM - (2 * this.D) + vme);
            var d06 = +0.053 * Angles.Sinus(VM + (2 * this.D));
            var d07 = +0.046 * Angles.Sinus((2 * this.D) - vme);
            var d08 = +0.041 * Angles.Sinus(VM - vme);
            var d09 = -0.035 * Angles.Sinus(this.D);
            var d10 = -0.031 * Angles.Sinus(VM + vme);
            var d11 = -0.015 * Angles.Sinus((2 * this.LatitudeF) - (2 * this.D));
            var d12 = +0.011 * Angles.Sinus(VM - (4 * this.D));

            var dLongitude = d01 + d02 + d03 + d04 + d05 + d06 + d07 + d08 + d09 + d10 + d11 + d12;
            this.Point.Longitude = this.Point.Longitude + dLongitude;
        }

        /// <summary>
        /// Perturbate Schlyter Latitude.
        /// </summary>
        private void PerturbateLatitude() {
            var lme = Systems.EarthSystem.Earth.LM;     ////   double VMe=Earth.VM;
            this.D = this.LM - lme;                        //// // Moon's mean elongation
            this.LatitudeF = this.LM - this.LW;                         //// // Moon's argument of latitude

            var d01 = -0.173 * Angles.Sinus(this.LatitudeF - (2 * this.D));
            var d02 = -0.055 * Angles.Sinus(VM - this.LatitudeF - (2 * this.D));
            var d03 = -0.046 * Angles.Sinus(VM + this.LatitudeF - (2 * this.D));
            var d04 = +0.033 * Angles.Sinus(this.LatitudeF + (2 * this.D));
            var d05 = +0.017 * Angles.Sinus((2 * VM) + this.LatitudeF);

            var dlth = d01 + d02 + d03 + d04 + d05;
            this.Point.Latitude = this.Point.Latitude + dlth;
        }
        #endregion
    }
}
