// <copyright file="BodyOrcus.cs" company="Traced-Ideas, Czech republic">
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
    /// <summary> Orbit Body Orcus. </summary>
    public sealed class BodyOrcus : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyOrcus"/> class.
        /// </summary>
        public BodyOrcus()
            : base("Orcus", "Orcus") {
            this.Body.Radius = 0;              //// [m]
            this.Knke = 5;                     //// 
            this.Body.Mass = 6.41 *1e20;       //// [kg]
 
            this.Time.EpochOrbit = 2457400.5;
            this.Time.EpochEquinox = 2457400.5;
            double[] lw = { 268.72, 0.0, 0.0, 0.0 };
            double[] i = { 20.582, 0.0, 0.0, 0.0 };
            double[] w = { 72.393, 0.0, 0.0, 0.0 };
            double[] e = { 0.2201, 0.0, 0.0, 0.0 };
            double[] a = { 39.398 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            var period = 247.29;
            double[] vm = { 358.163, 360.00 / period / 365.25, 0.0, 0.0 };  //// phaseShift
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
