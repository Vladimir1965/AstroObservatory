// <copyright file="CoordinateEquatorial2D.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Coordinates
{
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Coordinate Equatorial 2D.
    /// </summary>
    public sealed class CoordinateEquatorial2D {
        /// <summary>
        /// Gets the alpha.
        /// </summary>
        /// <value>
        /// The alpha.
        /// </value>
        public double Alpha { get; private set; }

        /// <summary>
        /// Gets the delta.
        /// </summary>
        /// <value>
        /// The delta.
        /// </value>
        public double Delta { get; private set; }

        /// <summary>
        /// Gets or sets the alpha hours.
        /// </summary>
        /// <value>
        /// The alpha hours.
        /// </value>
        public double AlphaHours {
            get => Computation.Angles.DegreesToHours(this.Alpha);

            [UsedImplicitly]
            set => this.Alpha = Computation.Angles.HoursToDegrees(value);
        }

        /// <summary>
        /// Gets or sets the alpha radians.
        /// </summary>
        /// <value>
        /// The alpha radians.
        /// </value>
        public double AlphaRadians {
            get => Computation.Angles.DegRad(this.Alpha);

            set {
                this.Alpha = Computation.Angles.RadDeg(value);
                if (this.Alpha < 0) {
                    this.Alpha += 360;
                }
            }
        }

        /// <summary>
        /// Gets or sets the delta radians.
        /// </summary>
        /// <value>
        /// The delta radians.
        /// </value>
        public double DeltaRadians {
            get => Computation.Angles.DegRad(this.Delta);

            set {
                this.Delta = Computation.Angles.RadDeg(value);
                if (this.Delta < 0) {
                    this.Delta += 360;
                }
            }
        }

        /// <summary>
        /// Equatorial2s the ecliptic.
        /// </summary>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public CoordinateEcliptic2D ToEcliptic(double epsilon) {
            var alphaRad = this.AlphaRadians;
            var deltaRad = this.DeltaRadians;
            var epsilonRad = Computation.Angles.DegRad(epsilon);

            var ecliptic = new CoordinateEcliptic2D {
                LambdaRadians = Math.Atan2(Math.Sin(alphaRad) * Math.Cos(epsilonRad) + Math.Tan(deltaRad) * Math.Sin(epsilonRad), Math.Cos(alphaRad)),
                BetaRadians = Math.Asin(Math.Sin(deltaRad) * Math.Cos(epsilonRad) - Math.Cos(deltaRad) * Math.Sin(epsilonRad) * Math.Sin(alphaRad))
            };
            return ecliptic;
        }
    }
}
