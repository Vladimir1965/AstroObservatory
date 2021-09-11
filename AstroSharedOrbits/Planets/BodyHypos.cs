// <copyright file="BodyHypos.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Planets {
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedOrbits.Orbits;
    using System;

    /// <summary> Orbit Body Hypos. </summary>
    public sealed class BodyHypos : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyHypos"/> class.
        /// </summary>
        /// <param name="code">Shortcut of the name.</param>
        /// <param name="name">The given name.</param>
        /// <param name="period">The given period.</param>
        /// <param name="phaseShift">The phase shift.</param>
        /// <param name="mass">The given mass.</param>
        public BodyHypos(
                    string code, 
                    string name, 
                    float period,
                    float phaseShift, 
                    float mass)
            : base(code, name) {
            this.Time.EpochOrbit = 2451543.5;      //// (2451545.0)
            this.Time.EpochEquinox = 2451543.5;
            this.Body.Radius = 6.65e7;             //// [m]
            this.Knke = 5;                     //// //
            this.SetPeriod(period, phaseShift);
            this.Body.Mass = mass;                //// 2.6e24;  // [kg]
            this.MeanPeriod = period;
        }

        /// <summary>
        /// Set Period.
        /// </summary>
        /// <param name="period">The period.</param>
        /// <param name="phaseShift">The phase shift.</param>
        private void SetPeriod(float period, float phaseShift) {
            double[] lw = { 0.0, 0.0, 0.0, 0.0 };
            double[] i = { 0.0, 0.0, 0.0, 0.0 };
            double[] w = { 0.0, 0.0, 0.0, 0.0 };
            double[] a = { Math.Pow(Math.Abs(period), 2.0 / 3.0) * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            double[] e = { 0.0, 0.0, 0.0, 0.0 };
            //// double[] E = { 0.048498, 4.469e-9, 0.0, 0.0 };
            double[] vm = { phaseShift, 360.00 / period / 365.25, 0.0, 0.0 };
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
