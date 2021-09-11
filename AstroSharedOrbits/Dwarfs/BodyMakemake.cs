// <copyright file="BodyMakemake.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

using AstroSharedClasses.Computation;
using AstroSharedClasses.OrbitalElements;

namespace AstroSharedOrbits.Dwarfs
{
    /// <summary> Orbit Body Makemake. </summary>
    public sealed class BodyMakemake : Orbits.Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyMakemake"/> class.
        /// </summary>
        public BodyMakemake()
            : base("Makemake", "Makemake") {
            this.Body.Radius = 0;              //// [m]
            this.Knke = 5;                     //// 
            this.Body.Mass = 0;                //// [kg]
 
            this.Time.EpochOrbit = 2457000.5;
            this.Time.EpochEquinox = 2457000.5;
            double[] lw = { 79.3659, 0.0, 0.0, 0.0 };
            double[] i = { 29.00685, 0.0, 0.0, 0.0 };
            double[] w = { 297.240, 0.0, 0.0, 0.0 };
            double[] e = { 0.15586, 0.0, 0.0, 0.0 };
            double[] a = { 45.715 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            var period = 309.09;
            double[] vm = { 15.0, 360.00 / period / 365.25, 0.0, 0.0 };  //// phaseShift
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
