// <copyright file="BodyHaumea.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

using AstroSharedClasses.Computation;
using AstroSharedClasses.OrbitalElements;
using AstroSharedOrbits.Orbits;

namespace AstroSharedOrbits.Dwarfs
{
    /// <summary> Orbit Body Haumea. </summary>
    public sealed class BodyHaumea : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyHaumea"/> class.
        /// </summary>
        public BodyHaumea()
            : base("Haumea", "Haumea") {
            this.Body.Radius = 0;              //// [m]
            this.Knke = 5;                     //// 
            this.Body.Mass = 0;                //// [kg]
 
            this.Time.EpochOrbit = 2457000.5;
            this.Time.EpochEquinox = 2457000.5;
            double[] lw = { 121.79, 0.0, 0.0, 0.0 };
            double[] i = { 28.19, 0.0, 0.0, 0.0 };
            double[] w = { 240.20, 0.0, 0.0, 0.0 };
            double[] e = { 0.19126, 0.0, 0.0, 0.0 };
            double[] a = { 43.218 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            var period = 284.12;
            double[] vm = { 209.07, 360.00 / period / 365.25, 0.0, 0.0 };  //// phaseShift
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
