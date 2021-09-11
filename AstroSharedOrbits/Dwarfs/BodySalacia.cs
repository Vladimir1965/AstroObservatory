// <copyright file="BodySalacia.cs" company="Traced-Ideas, Czech republic">
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
    /// <summary> Orbit Body Salacia. </summary>
    public sealed class BodySalacia : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodySalacia"/> class.
        /// </summary>
        public BodySalacia()
            : base("Salacia", "Salacia") {
            this.Body.Radius = 0;              //// [m]
            this.Knke = 5;                     //// 
            this.Body.Mass = 4.38 * 1e20;      //// [kg]
 
            this.Time.EpochOrbit = 2457400.5;
            this.Time.EpochEquinox = 2457400.5;
            double[] lw = { 279.96, 0.0, 0.0, 0.0 };
            double[] i = { 23.925, 0.0, 0.0, 0.0 };
            double[] w = { 309.61, 0.0, 0.0, 0.0 };
            double[] e = { 0.1097, 0.0, 0.0, 0.0 };
            double[] a = { 41.947 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            var period = 271.68;
            double[] vm = { 122.93, 360.00 / period / 365.25, 0.0, 0.0 };  //// phaseShift
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
