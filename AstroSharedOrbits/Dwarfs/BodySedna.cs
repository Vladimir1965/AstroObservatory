// <copyright file="BodySedna.cs" company="Traced-Ideas, Czech republic">
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
    /// <summary> Orbit Body Sedna. </summary>
    public sealed class BodySedna : Orbits.Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodySedna"/> class.
        /// https://en.wikipedia.org/wiki/90377_Sedna#Orbit_and_rotation
        /// </summary>
        public BodySedna()
            : base("Sedna", "Sedna") {
            this.Body.Radius = 0;              //// [m]
            this.Knke = 5;                     //// 
            this.Body.Mass = 0;                //// [kg]
 
            this.Time.EpochOrbit = 2457400.5;
            this.Time.EpochEquinox = 2457400.5;
            double[] lw = { 144.546, 0.0, 0.0, 0.0 };
            double[] i = { 11.92872, 0.0, 0.0, 0.0 };
            double[] w = { 311.29, 0.0, 0.0, 0.0 };
            double[] e = { 0.85491, 0.0, 0.0, 0.0 };
            double[] a = { 506.8 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            var period = 10787.1; ////11400.0;
            double[] vm = { 358.163, 360.00 / period / 365.25, 0.0, 0.0 };  //// phaseShift
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
