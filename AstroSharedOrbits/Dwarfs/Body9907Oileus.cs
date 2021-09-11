// <copyright file="Body9907Oileus.cs" company="Traced-Ideas, Czech republic">
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
    /// <summary> Orbit Body Oileus. </summary>
    public sealed class Body9907Oileus : Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="Body9907Oileus"/> class.
        /// </summary>
        public Body9907Oileus()
            : base("Oileus", "Oileus") {
            this.Body.Radius = 0;    //// [m]
            this.Knke = 5;                    //// 
            this.Body.Mass = 0;       //// [kg]
 
            this.Time.EpochOrbit = 2456200.5;
            this.Time.EpochEquinox = 2456200.5;
            double[] lw = { 153.77672, 0.0, 0.0, 0.0 };
            double[] i = { 8.14186, 0.0, 0.0, 0.0 };
            double[] w = { 263.72786, 0.0, 0.0, 0.0 };
            double[] e = { 0.0672607, 0.0, 0.0, 0.0 };
            double[] a = { 5.2999862 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            var period = 12.20;
            double[] vm = { 56.06718, 360.00 / period / 365.25, 0.0, 0.0 };  //// phaseShift
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
