// <copyright file="Body2012VP113.cs" company="Traced-Ideas, Czech republic">
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
    /// <summary> Orbit Body Eris. </summary>
    public sealed class Body2012VP113 : Orbits.Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="Body2012VP113"/> class.
        /// </summary>
        public Body2012VP113()
            : base("TNO1", "2012VP113") {
            this.Body.Radius = 0;    //// [m]
            this.Knke = 5;                    //// 
            this.Body.Mass = 0;       //// [kg]
 
            this.Time.EpochOrbit = 2457400.5;
            this.Time.EpochEquinox = 2457400.5;
            double[] lw = { 90.818, 0.0, 0.0, 0.0 };
            double[] i = { 24.047, 0.0, 0.0, 0.0 };
            double[] w = { 293.72, 0.0, 0.0, 0.0 };
            double[] e = { 0.6896, 0.0, 0.0, 0.0 };
            double[] a = { 265.8 * AstroMath.AstroUnit, 0.0, 0.0, 0.0 };
            var period = 4175.54;
            double[] vm = { 3.2115, 360.00 / period / 365.25, 0.0, 0.0 };  //// phaseShift
            this.NormElements = new NormalElements(lw, i, w, a, e, vm);
        }
    }
}
