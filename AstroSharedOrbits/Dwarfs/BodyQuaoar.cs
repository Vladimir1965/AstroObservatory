// <copyright file="BodyQuaoar.cs" company="Traced-Ideas, Czech republic">
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
    /// <summary> Orbit Body Quaoar. </summary>
    public sealed class BodyQuaoar : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyQuaoar"/> class.
        /// </summary>
        public BodyQuaoar()
            : base("Quaoar", "Quaoar") {
            this.Body.Radius = 555*1e3;        //// [m]
            this.Knke = 5;                     //// 
            this.Body.Mass = 1.4*1e21;         //// [kg]
 
            this.Time.EpochOrbit = 2458200.5;
            this.Time.EpochEquinox = 2458200.5;
            double[] lw = { 188.78, 0.0, 0.0, 0.0 };
            double[] i = { 7.9870, 0.0, 0.0, 0.0 };
            double[] w = { 147.67, 0.0, 0.0, 0.0 };
            double[] e = { 0.0376, 0.0, 0.0, 0.0 };
            double[] a = { 43.616 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            var period = 288.06;
            double[] vm = { 297.98, 360.00 / period / 365.25, 0.0, 0.0 };  //// phaseShift
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
