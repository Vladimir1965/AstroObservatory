// <copyright file="EclipticalElements.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.OrbitalElements {
    using System;
    using AstroSharedClasses.Records;
    using JetBrains.Annotations;

    /// <summary>
    /// Ecliptical Elements.
    /// </summary>
    [UsedImplicitly]
    public static class EclipticalElements {
        /// <summary>
        /// Calculates the specified i0.
        /// </summary>
        /// <param name="i0">The i0.</param>
        /// <param name="w0">The w0.</param>
        /// <param name="omega0">The omega0.</param>
        /// <param name="julianDay0">The J d0.</param>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static EclipticalElementDetails Calculate(double i0, double w0, double omega0, double julianDay0, double julianDay) {
            var timeT = (julianDay0 - 2451545.0) / 36525;
            var dTsquared = timeT * timeT;
            var t = (julianDay - julianDay0) / 36525;
            var timeSquared = t * t;
            var timeCubed = timeSquared * t;

            //// Now convert to radians
            var i0rad = Computation.Angles.DegRad(i0);
            var omega0rad = Computation.Angles.DegRad(omega0);

            var eta = (47.0029 - 0.06603 * timeT + 0.000598 * dTsquared) * t + (-0.03302 + 0.000598 * timeT) * timeSquared + 0.00006 * timeCubed;
            eta = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, eta));

            var pi = 174.876384 * 3600 + 3289.4789 * timeT + 0.60622 * dTsquared - (869.8089 + 0.50491 * timeT) * t + 0.03536 * timeSquared;
            pi = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, pi));

            var p = (5029.0966 + 2.22226 * timeT - 0.000042 * dTsquared) * t + (1.11113 - 0.000042 * timeT) * timeSquared - 0.000006 * timeCubed;
            p = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, p));

            var sini0rad = Math.Sin(i0rad);
            var cosi0rad = Math.Cos(i0rad);
            var sinomega0radPi = Math.Sin(omega0rad - pi);
            var cosomega0radPi = Math.Cos(omega0rad - pi);
            var sineta = Math.Sin(eta);
            var coseta = Math.Cos(eta);
            var a = sini0rad * sinomega0radPi;
            var b = -sineta * cosi0rad + coseta * sini0rad * cosomega0radPi;
            var irad = Math.Asin(Math.Sqrt(a * a + b * b));

            var details = new EclipticalElementDetails {
                I = Computation.Angles.RadDeg(irad)
            };

            var cosi = cosi0rad * coseta + sini0rad * sineta * cosomega0radPi;
            if (cosi < 0) {
                details.I = 180 - details.I;
            }

            var phi = pi + p;
            details.Omega = Computation.Angles.Mod360(Computation.Angles.RadDeg(Math.Atan2(a, b) + phi));

            a = -sineta * sinomega0radPi;
            b = sini0rad * coseta - cosi0rad * sineta * cosomega0radPi;
            var deltaw = Computation.Angles.RadDeg(Math.Atan2(a, b));
            details.W = Computation.Angles.Mod360(w0 + deltaw);

            return details;
        }

        /// <summary>
        /// Fs the k4 B1950 to LatitudeF k5 J2000.
        /// </summary>
        /// <param name="i0">The i0.</param>
        /// <param name="w0">The w0.</param>
        /// <param name="omega0">The omega0.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static EclipticalElementDetails FK4B1950ToFK5J2000(double i0, double w0, double omega0) {
            //// convert to radians
            var longL = Computation.Angles.DegRad(5.19856209);
            var angleJ = Computation.Angles.DegRad(0.00651966);
            var i0rad = Computation.Angles.DegRad(i0);
            var omega0rad = Computation.Angles.DegRad(omega0);
            var sini0rad = Math.Sin(i0rad);
            var cosi0rad = Math.Cos(i0rad);

            //// Calculate some values used later
            var cosJ = Math.Cos(angleJ);
            var sinJ = Math.Sin(angleJ);
            var argumentW = longL + omega0rad;
            var cosW = Math.Cos(argumentW);
            var sinW = Math.Sin(argumentW);
            var a = sinJ * sinW;
            var b = sini0rad * cosJ + cosi0rad * sinJ * cosW;

            //// Calculate the values 
            var details = new EclipticalElementDetails {
                I = Computation.Angles.RadDeg(Math.Asin(Math.Sqrt(a * a + b * b)))
            };

            var cosi = cosi0rad * cosJ - sini0rad * sinJ * cosW;
            if (cosi < 0) {
                details.I = 180 - details.I;
            }

            details.W = Computation.Angles.Mod360(w0 + Computation.Angles.RadDeg(Math.Atan2(a, b)));
            details.Omega = Computation.Angles.Mod360(Computation.Angles.RadDeg(Math.Atan2(sini0rad * sinW, cosi0rad * sinJ + sini0rad * cosJ * cosW)) - 4.50001688);

            return details;
        }
    }
}
