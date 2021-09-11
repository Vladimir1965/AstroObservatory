// <copyright file="BodyEris.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

using AstroSharedClasses.Computation;
using AstroSharedClasses.OrbitalElements;
using AstroSharedOrbits.Orbits;

namespace AstroSharedOrbits.Dwarfs {
    /// <summary> Orbit Body Eris. </summary>
    public sealed class BodyEris : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyEris"/> class.
        /// </summary>
        public BodyEris()
            : base("Eris", "Eris") {
            this.Body.Radius = 1163 * 1e3;    //// [m]
            this.Knke = 5;                    //// 
            this.Body.Mass = 1.66*1e22;       //// [kg]
 
            this.Time.EpochOrbit = 2457000.5;
            this.Time.EpochEquinox = 2457000.5;
            double[] lw = { 35.9531, 0.0, 0.0, 0.0 };
            double[] i = { 44.0445, 0.0, 0.0, 0.0 };
            double[] w = { 150.977, 0.0, 0.0, 0.0 };
            double[] e = { 0.44068, 0.0, 0.0, 0.0 };
            double[] a = { 67.781 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            var period = 558.04;
            double[] vm = { 204.16, 360.00 / period / 365.25, 0.0, 0.0 };  //// phaseShift
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
