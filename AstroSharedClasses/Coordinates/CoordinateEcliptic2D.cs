// <copyright file="CoordinateEcliptic2D.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Coordinates
{
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// Coordinate Ecliptic 2D.
    /// </summary>
    public sealed class CoordinateEcliptic2D {
        /// <summary>
        /// Gets or sets the lambda.
        /// </summary>
        /// <value>
        /// The lambda.
        /// </value>
        [UsedImplicitly]
        public double Lambda { get; set; }

        /// <summary>
        /// Gets or sets the beta.
        /// </summary>
        /// <value>
        /// The beta.
        /// </value>
        [UsedImplicitly]
        public double Beta { get; set; }

        /// <summary>
        /// Gets or sets the lambda radians.
        /// </summary>
        /// <value>
        /// The lambda radians.
        /// </value>
        [UsedImplicitly]
        public double LambdaRadians {
            get => Computation.Angles.DegRad(this.Lambda);

            set {
                this.Lambda = Computation.Angles.RadDeg(value);
                if (this.Lambda < 0) {
                    this.Lambda += 360;
                }
            }
        }

        /// <summary>
        /// Gets or sets the beta radians.
        /// </summary>
        /// <value>
        /// The beta radians.
        /// </value>
        [UsedImplicitly]
        public double BetaRadians {
            get => Computation.Angles.DegRad(this.Beta);

            set {
                this.Beta = Computation.Angles.RadDeg(value);
                if (this.Beta < 0) {
                    this.Beta += 360;
                }
            }
        }

        /// <summary>
        /// Ecliptic2s the equatorial.
        /// </summary>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public CoordinateEquatorial2D ToEquatorial(double epsilon) {
            var lambdaRad = this.LambdaRadians;
            var betaRad = this.BetaRadians;
            var epsilonRad = Computation.Angles.DegRad(epsilon);

            var equatorial = new CoordinateEquatorial2D {
                AlphaRadians = Math.Atan2(Math.Sin(lambdaRad) * Math.Cos(epsilonRad) - Math.Tan(betaRad) * Math.Sin(epsilonRad), Math.Cos(lambdaRad)),
                DeltaRadians = Math.Asin(Math.Sin(betaRad) * Math.Cos(epsilonRad) + Math.Cos(betaRad) * Math.Sin(epsilonRad) * Math.Sin(lambdaRad))
            };
            return equatorial;
        }
    }
}
