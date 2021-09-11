// <copyright file="OrbitEnergy.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author> vl </author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Orbits
{
    using AstroSharedClasses.Computation;
    using AstroSharedOrbits.Systems;
    using System;

    /// <summary>
    /// Orbit Energy.
    /// </summary>
    public class OrbitEnergy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrbitEnergy"/> class.
        /// </summary>
        public OrbitEnergy()
        {
        }

        /// <summary>
        /// Gets or sets Ellipse param a*(1-e^2).
        /// </summary>
        public double P { get; set; }

        /// <summary>
        /// Gets or sets Auxiliary axis.
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Gets or sets Corrected mass of the Sun.
        /// </summary>
        public double M0 { get; set; }

        /// <summary>
        /// Gets or sets Corrected mass of planet.
        /// </summary>
        public double M1 { get; set; }

        /// <summary>
        /// Gets Kepler constant of area.
        /// m R v
        /// </summary>
        /// <value> Property description. </value>
        public double Carea { get; set; }

        /// <summary>
        /// Gets Area of ellipse.
        /// </summary>
        /// <value> Property description. </value>
        public double Sellipse { get; set; }

        /// <summary>
        /// Gets Torbital.
        /// </summary>
        /// <value> Property description. </value>
        public double Torbital { get; set; }

        /// <summary>
        /// Gets or sets Velocity      [m/s].
        /// </summary>
        public double U { get; set; }

        /// <summary>
        /// Gets or sets Mean velocity      [m/s].
        /// </summary>
        public double Umean { get; set; }

        /// <summary>
        /// Gets or sets Kinetic energy [W].
        /// </summary>
        public double Ekin { get; set; }

        /// <summary>
        /// Gets or sets Potential energy [W].
        /// </summary>
        /// <value> Property description. </value>
        public double Epot { get; set; }

        /// <summary>
        /// Gets Total energy [W].
        /// </summary>
        /// <value> Property description. </value>
        public double Energy => this.Ekin + this.Epot;

        /// <summary>
        /// Gets Omega.
        /// </summary>
        /// <value> Property description. </value>
        public double Omega { get; set; }

        /// <summary>
        /// Gets Alpha.
        /// </summary>
        /// <value> Property description. </value>
        public double Alpha { get; set; }

        /// <summary>
        /// Gets Momentum [].
        /// </summary>
        /// <value> Property description. </value>
        public double Momentum { get; set; }

        /// <summary>
        /// Gets Angular Momentum [].
        /// </summary>
        /// <value> Property description. </value>
        public double AngularMomentum { get; set; }

        /// <summary>
        /// Gets Lagrange function [W].
        /// </summary>
        /// <value> Property description. </value>
        public double Lagrange { get; set; }

        /// <summary>
        /// Gets Hamilton function [] -AstroMath.Kappa*M0/2/A.
        /// </summary>
        /// <value> Property description. </value>
        public double Hamilton { get; set; }

        /// <summary>
        /// Gets Poincare.
        /// </summary>
        /// <value> Property description. </value>
        public double Poincare { get; set; }

        /// <summary>
        /// Gets Fsun - force to Sun  [N] SolarKappa*m()/RT/RT.
        /// </summary>
        /// <value> Property description. </value>
        public double Fsun { get; set; }

        /*
        /// <summary>
        /// Gets Velocity at perihelion [m/s].
        /// </summary>
        /// <value> Property description. </value>
        public double Uper => 2 * AstroMath.ConstPi * this.A / this.Torbital * this.Coex;

        /// <summary>
        /// Gets Velocity at aphelion [m/s].
        /// </summary>
        /// <value> Property description. </value>
        public double Uapo => 2 * AstroMath.ConstPi * this.A / this.Torbital / this.Coex;
        */

        /// <summary>
        /// Sets the orbit.
        /// </summary>
        /// <param name="givenOrbit">The given orbit.</param>
        /// <param name="givenSun">The given sun.</param>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public void SetOrbit(Orbit givenOrbit, BodySun givenSun)
        {
            this.P = givenOrbit.A * (1 - (givenOrbit.E * givenOrbit.E));
            this.B = givenOrbit.A * Math.Sqrt(1 - (givenOrbit.E * givenOrbit.E));
            this.M0 = givenSun.Body.Mass + givenOrbit.Body.Mass;
            this.M1 = (givenSun.Body.Mass * givenOrbit.Body.Mass) / this.M0;

            /// m R v = m R^2 ω = m R^2 *2PI/T 
            this.Carea = Math.Sqrt(AstroMath.Kappa * this.M1 * this.P); //// sqrt(kg*m) = kg*m^2/s

            this.Sellipse = AstroMath.ConstPi * givenOrbit.A * this.B;
            this.Torbital = this.Sellipse / this.Carea;

            //// spead v = omega * R
            this.U = 2.0 * AstroMath.SolarKappaSqrt * Math.Sqrt(Math.Abs((2.0 / givenOrbit.Point.RT) - (2.0 / givenOrbit.A)));
            this.Ekin = this.M1 * this.U * this.U / 2;
            this.Epot = -AstroMath.Kappa * this.M0 * this.M1 / givenOrbit.Point.RT;        // SolarKappa*m()/RT
            this.Umean = Math.Sqrt(AstroMath.Kappa * this.M0 * givenOrbit.A);  // sqrt(u_per*u_apo)
            this.Omega = givenOrbit.A * this.Umean / givenOrbit.Point.RT / givenOrbit.Point.RT;
            this.Alpha = Math.Asin(givenOrbit.A * this.Umean / givenOrbit.Point.RT / this.U);
            this.Momentum = this.M1 * this.U;

            //// this.AngularMomentum = this.M1 * this.U * givenOrbit.Point.RT;
            var omega = 2 * Math.PI / givenOrbit.MeanPeriod / AstroMath.SecondsInDay / 365.25;
            this.AngularMomentum = this.M1 * givenOrbit.Point.RT * givenOrbit.Point.RT * omega;

            this.Lagrange = this.Ekin - this.Epot;
            this.Hamilton = this.Energy / this.M1;
            this.Poincare = givenOrbit.A * this.Umean * this.Umean;
            this.Fsun = this.Epot / givenOrbit.Point.RT;
        }
    }
}
