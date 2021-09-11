// <copyright file="IlluminatedFraction.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Moons {
    using System;
    using AstroSharedClasses.Computation;
    using JetBrains.Annotations;

    /// <summary>
    /// Illuminated Fraction.
    /// </summary>
    public static class IlluminatedFraction {
        /// <summary>
        /// Phases the angle.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static double PhaseAngle(double r, double givenParameter, double givenDelta) {
            //// Return the result
            return Angles.Mod360(Angles.RadDeg(Math.Acos((r * r + givenDelta * givenDelta - givenParameter * givenParameter) / (2 * givenParameter * givenDelta))));
        }

        /// <summary>
        /// Phases the angle.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="r0">The r0.</param>
        /// <param name="b">The B.</param>
        /// <param name="longL">The L.</param>
        /// <param name="l0">The l0.</param>
        /// <param name="delta">The delta.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double PhaseAngle(double r, double r0, double b, double longL, double l0, double delta) {
            //// Convert from degrees to radians
            b = Angles.DegRad(b);
            longL = Angles.DegRad(longL);
            l0 = Angles.DegRad(l0);

            //// Return the result
            return Angles.Mod360(Angles.RadDeg(Math.Acos((r - r0 * Math.Cos(b) * Math.Cos(longL - l0)) / delta)));
        }

        /// <summary>
        /// Phases the angle rectangular.
        /// </summary>
        /// <param name="x">The given x.</param>
        /// <param name="y">The given y.</param>
        /// <param name="z">The given z.</param>
        /// <param name="b">The given B.</param>
        /// <param name="longL">The given L.</param>
        /// <param name="delta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double PhaseAngleRectangular(double x, double y, double z, double b, double longL, double delta) {
            //// Convert from degrees to radians
            b = Angles.DegRad(b);
            longL = Angles.DegRad(longL);
            var cosB = Math.Cos(b);

            //// Return the result
            return Angles.Mod360(Angles.RadDeg(Math.Acos((x * cosB * Math.Cos(longL) + y * cosB * Math.Sin(longL) + z * Math.Sin(b)) / delta)));
        }

        /// <summary>
        /// Converts to illuminated fraction.
        /// </summary>
        /// <param name="phaseAngle">The phase angle.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double ConvertToIlluminatedFraction(double phaseAngle) {
            //// Convert from degrees to radians
            phaseAngle = Angles.DegRad(phaseAngle);

            //// Return the result
            return (1 + Math.Cos(phaseAngle)) / 2;
        }

        /// <summary>
        /// Converts to illuminated fraction.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDelta">The given delta.</param>
        /// <returns>Returns value.</returns>
        public static double ConvertToIlluminatedFraction(double r, double givenParameter, double givenDelta) {
            return ((r + givenDelta) * (r + givenDelta) - givenParameter * givenParameter) / (4 * givenParameter * givenDelta);
        }
    }
}
