// <copyright file="Relation.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Crossing
{
    using AstroSharedClasses.Computation;
    using AstroSharedOrbits.Orbits;
    using JetBrains.Annotations;
    using System;

    /// <summary> Relation of orbits. </summary>
    public sealed class Relation {
        //// void SetBodies ( Orbit *A, Orbit *B);

        #region Public properties
        /// <summary>
        /// Gets Diff Phi.
        /// </summary>
        /// <value> Property description. </value>
        public double DiffPhi { get; private set; }       // line angle

        /// <summary>
        /// Gets Diff R.
        /// </summary>
        /// <value> Property description. </value>
        public double DiffR { get; private set; }         // distance

        /// <summary>
        /// Gets or sets Diff Longitude.
        /// </summary>
        /// <value> Property description. </value>
        private double DiffLgh { [UsedImplicitly] get; set; }       // Longitude heliocentric

        /// <summary>
        /// Gets or sets Diff Latitude.
        /// </summary>
        /// <value> Property description. </value>
        private double DiffLth { [UsedImplicitly] get; set; }       // latitude heliocentric

        /// <summary>
        /// Gets or sets Diff XH.
        /// </summary>
        /// <value> Property description. </value>
        private double DiffXH { get; set; }        // X,Y,Z heliocentric

        /// <summary>
        /// Gets or sets Diff YH.
        /// </summary>
        /// <value> Property description. </value>
        private double DiffYH { get; set; }

        /// <summary>
        /// Gets or sets Diff ZH.
        /// </summary>
        /// <value>
        /// Property description.
        /// </value>
        private double DiffZH { get; set; }

        //// double   dF;            ////  gravitational Power
        //// double   dA;            ////  acceleration of A
        //// double   dB;            ////  acceleration of B 
        #endregion 

        #region Public properties
        /// <summary>
        /// Gets or sets Body A.
        /// </summary>
        private Orbit BodyA { get; set; }

        /// <summary>
        /// Gets or sets Body B.
        /// </summary>
        /// <value> Property description. </value>
        private Orbit BodyB { get; set; }

        /// <summary>
        /// Gets or sets Diff R2.
        /// </summary>
        /// <value> Property description. </value>
        private double DiffR2 { get; set; }        // distance^2 
        #endregion

        /// <summary>
        /// Set Bodies.
        /// </summary>
        /// <param name="anA">A given body A.</param>
        /// <param name="aB">A given body B.</param>
        public void SetBodies(Orbit anA, Orbit aB) {
            this.BodyA = anA; 
            this.BodyB = aB;
            this.DiffLgh = Angles.Mod360(this.BodyB.Point.Longitude - this.BodyA.Point.Longitude);
            this.DiffLth = Angles.Mod360(this.BodyB.Point.Latitude - this.BodyA.Point.Latitude);
            this.DiffXH = this.BodyB.Point.XH - this.BodyA.Point.XH;
            this.DiffYH = this.BodyB.Point.YH - this.BodyA.Point.YH;
            this.DiffZH = this.BodyB.Point.ZH - this.BodyA.Point.ZH;
            this.DiffR2 = (this.DiffXH * this.DiffXH) + (this.DiffYH * this.DiffYH) + (this.DiffZH * this.DiffZH);
            if (this.BodyA.Point.RT > this.BodyB.Point.RT) {
                this.DiffR = -Math.Sqrt(this.DiffR2);
            }
            else {
                this.DiffR = Math.Sqrt(this.DiffR2);
            }

            this.DiffPhi = Angles.ArcTan2(this.DiffYH, this.DiffXH);
           //// ENERGY
           //// if (!Equal(this.DiffR,0,1e-10)) {
           ////    dF = AstroMath.Kappa* (A->Mass)*(B->Mass)/this.DiffR2;
           ////    dA = AstroMath.Kappa* (B->Mass) /this.DiffR2;
           ////    dB = AstroMath.Kappa* (A->Mass) /this.DiffR2;
           //// }
        }
    }
}
