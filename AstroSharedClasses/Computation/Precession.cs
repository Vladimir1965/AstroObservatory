// <copyright file="Precession.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation
{
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// Support for Precession.
    /// </summary>
    public static class Precession {
        #region Naughter
        /// <summary>
        /// Adjusts the position using uniform proper motion.
        /// </summary>
        /// <param name="t">The given t.</param>
        /// <param name="alpha">The alpha.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="pMAlpha">The p m alpha.</param>
        /// <param name="pMDelta">The p m delta.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static Coordinates.Coordinate2D AdjustPositionUsingUniformProperMotion(double t, double alpha, double delta, double pMAlpha, double pMDelta) {
            var value = new Coordinates.Coordinate2D { X = alpha + (pMAlpha * t / 3600), Y = delta + (pMDelta * t / 3600) };

            return value;
        }

        /// <summary>
        /// Adjusts the position using motion in space.
        /// </summary>
        /// <param name="givenParameter">The givenParameter.</param>
        /// <param name="givenDeltaR">The given delta R.</param>
        /// <param name="t">The t.</param>
        /// <param name="alpha">The alpha.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="pMAlpha">The p m alpha.</param>
        /// <param name="pMDelta">The p m delta.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static Coordinates.Coordinate2D AdjustPositionUsingMotionInSpace(double givenParameter, double givenDeltaR, double t, double alpha, double delta, double pMAlpha, double pMDelta) {
            //// Convert DeltaR from km/s to Parsecs / Year
            givenDeltaR /= 977792;

            //// Convert from seconds of time to Radians / Year
            pMAlpha /= 13751;

            //// Convert from seconds of arc to Radians / Year
            pMDelta /= 206265;

            //// Now convert to radians
            alpha = Computation.Angles.HoursToRadians(alpha);
            delta = Computation.Angles.DegRad(delta);

            var x = givenParameter * Math.Cos(delta) * Math.Cos(alpha);
            var y = givenParameter * Math.Cos(delta) * Math.Sin(alpha);
            var z = givenParameter * Math.Sin(delta);

            var deltaX = x / givenParameter * givenDeltaR - z * pMDelta * Math.Cos(alpha) - y * pMAlpha;
            var deltaY = y / givenParameter * givenDeltaR - z * pMDelta * Math.Sin(alpha) + x * pMAlpha;
            var deltaZ = z / givenParameter * givenDeltaR + givenParameter * pMDelta * Math.Cos(delta);

            x += t * deltaX;
            y += t * deltaY;
            z += t * deltaZ;

            var value = new Coordinates.Coordinate2D {
                X = Computation.Angles.RadiansToHours(Math.Atan2(y, x))
            };

            if (value.X < 0) {
                value.X += 24;
            }

            value.Y = Computation.Angles.RadDeg(Math.Atan2(z, Math.Sqrt(x * x + y * y)));

            return value;
        }

        /// <summary>
        /// Precess equatorial.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="julianDay0">The J d0.</param>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Coordinates.Coordinate2D PrecessEquatorial(double alpha, double delta, double julianDay0, double julianDay) {
            var julianCentury = (julianDay0 - 2451545.0) / 36525;
            var julianCentury2 = julianCentury * julianCentury;
            var t = (julianDay - julianDay0) / 36525;
            var timeSquared = t * t;
            var timeCubed = timeSquared * t;

            //// Now convert to radians
            alpha = Computation.Angles.HoursToRadians(alpha);
            delta = Computation.Angles.DegRad(delta);

            var sigma = (2306.2181 + 1.39656 * julianCentury - 0.000139 * julianCentury2) * t + (0.30188 - 0.0000344 * julianCentury) * timeSquared + 0.017988 * timeCubed;
            sigma = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, sigma));

            var zeta = (2306.2181 + 1.39656 * julianCentury - 0.000138 * julianCentury2) * t + (1.09468 + 0.000066 * julianCentury) * timeSquared + 0.018203 * timeCubed;
            zeta = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, zeta));

            var phi = (2004.3109 - 0.8533 * julianCentury - 0.000217 * julianCentury2) * t - (0.42665 + 0.000217 * julianCentury) * timeSquared - 0.041833 * timeCubed;
            phi = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, phi));

            var a = Math.Cos(delta) * Math.Sin(alpha + sigma);
            var b = Math.Cos(phi) * Math.Cos(delta) * Math.Cos(alpha + sigma) - Math.Sin(phi) * Math.Sin(delta);
            var c = Math.Sin(phi) * Math.Cos(delta) * Math.Cos(alpha + sigma) + Math.Cos(phi) * Math.Sin(delta);

            var value = new Coordinates.Coordinate2D { X = Computation.Angles.RadiansToHours(Math.Atan2(a, b) + zeta) };
            if (value.X < 0) {
                value.X += 24;
            }

            value.Y = Computation.Angles.RadDeg(Math.Asin(c));

            return value;
        }

        /// <summary>
        /// Precess equatorial F k4.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="julianDay0">The J d0.</param>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Coordinates.Coordinate2D PrecessEquatorialFK4(double alpha, double delta, double julianDay0, double julianDay) {
            var julianCentury = (julianDay0 - 2415020.3135) / 36524.2199;
            var t = (julianDay - julianDay0) / 36524.2199;
            var timeSquared = t * t;
            var timeCubed = timeSquared * t;

            //// Now convert to radians
            alpha = Computation.Angles.HoursToRadians(alpha);
            delta = Computation.Angles.DegRad(delta);

            var sigma = (2304.250 + 1.396 * julianCentury) * t + 0.302 * timeSquared + 0.018 * timeCubed;
            sigma = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, sigma));

            var zeta = 0.791 * timeSquared + 0.001 * timeCubed;
            zeta = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, zeta));
            zeta += sigma;

            var phi = (2004.682 - 0.853 * julianCentury) * t - 0.426 * timeSquared - 0.042 * timeCubed;
            phi = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, phi));

            var a = Math.Cos(delta) * Math.Sin(alpha + sigma);
            var b = Math.Cos(phi) * Math.Cos(delta) * Math.Cos(alpha + sigma) - Math.Sin(phi) * Math.Sin(delta);
            var c = Math.Sin(phi) * Math.Cos(delta) * Math.Cos(alpha + sigma) + Math.Cos(phi) * Math.Sin(delta);

            var value = new Coordinates.Coordinate2D { X = Computation.Angles.RadiansToHours(Math.Atan2(a, b) + zeta) };
            if (value.X < 0) {
                value.X += 24;
            }

            value.Y = Computation.Angles.RadDeg(Math.Asin(c));

            return value;
        }

        /// <summary>
        /// Precesses the ecliptic.
        /// </summary>
        /// <param name="lambda">The lambda.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="julianDay0">The J d0.</param>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static Coordinates.Coordinate2D PrecessEcliptic(double lambda, double beta, double julianDay0, double julianDay) {
            var julianCentury = (julianDay0 - 2451545.0) / 36525;
            var julianCentury2 = julianCentury * julianCentury;
            var t = (julianDay - julianDay0) / 36525;
            var timeSquared = t * t;
            var timeCubed = timeSquared * t;

            //// Now convert to radians
            lambda = Computation.Angles.DegRad(lambda);
            beta = Computation.Angles.DegRad(beta);

            var eta = (47.0029 - 0.06603 * julianCentury + 0.000598 * julianCentury2) * t + (-0.03302 + 0.000598 * julianCentury) * timeSquared + 0.00006 * timeCubed;
            eta = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, eta));

            var pi = 174.876384 * 3600 + 3289.4789 * julianCentury + 0.60622 * julianCentury2 - (869.8089 + 0.50491 * julianCentury) * t + 0.03536 * timeSquared;
            pi = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, pi));

            var p = (5029.0966 + 2.22226 * julianCentury - 0.000042 * julianCentury2) * t + (1.11113 - 0.000042 * julianCentury) * timeSquared - 0.000006 * timeCubed;
            p = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, p));

            var a = Math.Cos(eta) * Math.Cos(beta) * Math.Sin(pi - lambda) - Math.Sin(eta) * Math.Sin(beta);
            var b = Math.Cos(beta) * Math.Cos(pi - lambda);
            var c = Math.Cos(eta) * Math.Sin(beta) + Math.Sin(eta) * Math.Cos(beta) * Math.Sin(pi - lambda);

            var value = new Coordinates.Coordinate2D { X = Computation.Angles.RadDeg(p + pi - Math.Atan2(a, b)) };
            if (value.X < 0) {
                value.X += 360;
            }

            value.Y = Computation.Angles.RadDeg(Math.Asin(c));

            return value;
        }

        /// <summary>
        /// Equatorial the PM to ecliptic.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="pMAlpha">The p m alpha.</param>
        /// <param name="pMDelta">The p m delta.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static Coordinates.Coordinate2D EquatorialPMToEcliptic(double alpha, double delta, double beta, double pMAlpha, double pMDelta, double epsilon) {
            //// Convert to radians
            epsilon = Computation.Angles.DegRad(epsilon);
            alpha = Computation.Angles.HoursToRadians(alpha);
            delta = Computation.Angles.DegRad(delta);
            beta = Computation.Angles.DegRad(beta);

            var cosb = Math.Cos(beta);
            var sinEpsilon = Math.Sin(epsilon);

            var value = new Coordinates.Coordinate2D {
                X =
                    (pMDelta * sinEpsilon * Math.Cos(alpha) +
                     pMAlpha * Math.Cos(delta) *
                     (Math.Cos(epsilon) * Math.Cos(delta) + sinEpsilon * Math.Sin(delta) * Math.Sin(alpha))) / (cosb * cosb),
                Y =
                    (pMDelta * (Math.Cos(epsilon) * Math.Cos(delta) + sinEpsilon * Math.Sin(delta) * Math.Sin(alpha)) -
                     pMAlpha * sinEpsilon * Math.Cos(alpha) * Math.Cos(delta)) / cosb
            };

            return value;
        }

        #endregion
    }
}
