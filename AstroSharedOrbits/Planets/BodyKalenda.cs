// <copyright file="BodyKalenda.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Planets {
    using JetBrains.Annotations;

    /// <summary> Initializes a new instance of the BodyKalenda class. </summary>
    [UsedImplicitly]
    public sealed class BodyKalenda : Orbits.Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="BodyKalenda"/> class.
        /// </summary>
        public BodyKalenda()
            : base("K", "KALENDA") {
            this.PerTime = 1741.810448;          ////
            this.Body.Mass = 2.6e24;                  //// [kg]
            this.Body.Radius = 6.65e7;                //// [m]
            this.Body.J = 0;             //// [deg]
            this.Knke = 7;          ////
        }

        /// <summary>
        /// Schlyter or Chapront.
        /// </summary>
        public override void Init() {
            this.InitNormal();
        }

        #region Initializers
        /// <summary>
        /// Init Normal.
        /// </summary>
        private void InitNormal() {
            this.Time.EpochOrbit = 2451543.5;         //// (2451545.0)
            this.Time.EpochEquinox = 2451543.5;
            /* Temporarily not used
          this.A[0] = 161.4 * AstroMath.AstroUnit; // [m]
          this.A[1] = 0;                    //// [m/Jd]
          this.A[2] = 0;                    ////  [m/Jd2]
          this.A[3] = 0;                    ////  [m/Jd3]

          this.E[0] = 0.0;                    //// []
          this.E[1] = 0.0;                  //// [/Jd]
          this.E[2] = 0;                    ////  [/Jd2]
          this.E[3] = 0;                    ////  [/Jd3]

          this.I[0] = 0;                    //// [deg]
          this.I[1] = 0;                    //// ["/Jd]
          this.I[2] = 0;                    //// [/Jd2]
          this.I[3] = 0;                    //// [/Jd3]

          this.LW[0] = 0;                   //// [deg]
          this.LW[1] = 0;                   //// ["/Jd]
          this.LW[2] = 0;                   //// [/Jd2]
          this.LW[3] = 0;                   //// [/Jd3]

          this.W[0] = 0;                    //// [deg]
          this.W[1] = 0;                       //// [deg/Jd]
          this.W[2] = 0;                    //// [deg/Jd2]
          this.W[3] = 0;                    //// [deg/Jd3]

          this.VM[0] = 189;                   //// [deg]
          this.VM[1] = 0.00048;               //// [deg/Jd]
          this.VM[2] = 0;                   //// [deg/Jd2]
          this.VM[3] = 0;                   //// [deg/Jd3]

          this.LM[0] = 0;                   //// [deg]
          this.LM[1] = 0;                   //// ["/Jd]
          this.LM[2] = 0;                   //// [deg/Jd2]
          this.LM[3] = 0;                   //// [deg/Jd3]

          this.LP[0] = 0;                   //// [deg]
          this.LP[1] = 0;                   //// ["/Jd]
          this.LP[2] = 0;                   //// [deg/Jd2]
          this.LP[3] = 0;                   //// [deg/Jd3]
            */
        }
        #endregion
    }
}
