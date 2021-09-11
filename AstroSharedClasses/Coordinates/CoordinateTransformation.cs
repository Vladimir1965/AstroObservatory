// <copyright file="CoordinateTransformation.cs" company="Traced-Ideas, Czech republic">
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
    using System.Diagnostics;

    /// <summary>
    /// Coordinate Transformation.
    /// </summary>
    public static class CoordinateTransformation {
        #region Naughter

        /// <summary>
        /// Equatorial2s the horizontal.
        /// </summary>
        /// <param name="localHourAngle">The local hour angle.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns> Returns value. </returns>
        public static Coordinate2D Equatorial2Horizontal(double localHourAngle, double delta, double latitude) {
            localHourAngle = Computation.Angles.HoursToRadians(localHourAngle);
            delta = Computation.Angles.DegRad(delta);
            latitude = Computation.Angles.DegRad(latitude);

            var horizontal = new Coordinate2D {
                X = Computation.Angles.RadDeg(Math.Atan2(Math.Sin(localHourAngle), Math.Cos(localHourAngle) * Math.Sin(latitude) - Math.Tan(delta) * Math.Cos(latitude)))
            };
            if (horizontal.X < 0) {
                horizontal.X += 360;
            }

            horizontal.Y = Computation.Angles.RadDeg(Math.Asin(Math.Sin(latitude) * Math.Sin(delta) + Math.Cos(latitude) * Math.Cos(delta) * Math.Cos(localHourAngle)));

            return horizontal;
        }

        /// <summary>
        /// Horizontal2s the equatorial.
        /// </summary>
        /// <param name="azimuth">The azimuth.</param>
        /// <param name="altitude">The altitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Coordinate2D Horizontal2Equatorial(double azimuth, double altitude, double latitude) {
            //// Convert from degrees to radians
            azimuth = Computation.Angles.DegRad(azimuth);
            altitude = Computation.Angles.DegRad(altitude);
            latitude = Computation.Angles.DegRad(latitude);

            var equatorial = new Coordinate2D {
                X = Computation.Angles.RadiansToHours(Math.Atan2(Math.Sin(azimuth), Math.Cos(azimuth) * Math.Sin(latitude) + Math.Tan(altitude) * Math.Cos(latitude)))
            };
            if (equatorial.X < 0) {
                equatorial.X += 24;
            }

            equatorial.Y = Computation.Angles.RadDeg(Math.Asin(Math.Sin(latitude) * Math.Sin(altitude) - Math.Cos(latitude) * Math.Cos(altitude) * Math.Cos(azimuth)));

            return equatorial;
        }

        /// <summary>
        /// Equatorial2s the galactic.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="delta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Coordinate2D Equatorial2Galactic(double alpha, double delta) {
            alpha = 192.25 - Computation.Angles.HoursToDegrees(alpha);
            alpha = Computation.Angles.DegRad(alpha);
            delta = Computation.Angles.DegRad(delta);

            var galactic = new Coordinate2D {
                X = Computation.Angles.RadDeg(Math.Atan2(Math.Sin(alpha), Math.Cos(alpha) * Math.Sin(Computation.Angles.DegRad(27.4)) - Math.Tan(delta) * Math.Cos(Computation.Angles.DegRad(27.4))))
            };
            galactic.X = 303 - galactic.X;
            if (galactic.X >= 360) {
                galactic.X -= 360;
            }

            galactic.Y = Computation.Angles.RadDeg(Math.Asin(Math.Sin(delta) * Math.Sin(Computation.Angles.DegRad(27.4)) + Math.Cos(delta) * Math.Cos(Computation.Angles.DegRad(27.4)) * Math.Cos(alpha)));

            return galactic;
        }

        /// <summary>
        /// Galactic2s the equatorial.
        /// </summary>
        /// <param name="l">The l.</param>
        /// <param name="b">The b.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Coordinate2D Galactic2Equatorial(double l, double b) {
            l -= 123;
            l = Computation.Angles.DegRad(l);
            b = Computation.Angles.DegRad(b);

            var equatorial = new Coordinate2D {
                X = Computation.Angles.RadDeg(Math.Atan2(Math.Sin(l), Math.Cos(l) * Math.Sin(Computation.Angles.DegRad(27.4)) - Math.Tan(b) * Math.Cos(Computation.Angles.DegRad(27.4))))
            };
            equatorial.X += 12.25;
            if (equatorial.X < 0) {
                equatorial.X += 360;
            }

            equatorial.X = Computation.Angles.DegreesToHours(equatorial.X);
            equatorial.Y = Computation.Angles.RadDeg(Math.Asin(Math.Sin(b) * Math.Sin(Computation.Angles.DegRad(27.4)) + Math.Cos(b) * Math.Cos(Computation.Angles.DegRad(27.4)) * Math.Cos(l)));

            return equatorial;
        }

        /// <summary>
        /// DMSs to degrees.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <param name="minutes">The minutes.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="bPositive">The b positive.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double DmsToDegrees(double degrees, double minutes, double seconds, bool bPositive = true) {
            //// validate our parameters
            if (!bPositive) {
                Debug.Assert(degrees >= 0, "Reason for the assert");  //// All parameters should be non negative if the "bPositive" parameter is false
                Debug.Assert(minutes >= 0, "Reason for the assert");
                Debug.Assert(seconds >= 0, "Reason for the assert");
            }

            if (bPositive) {
                return degrees + minutes / 60 + seconds / 3600;
            }

            return -degrees - minutes / 60 - seconds / 3600;
        }

        #endregion
    }
}
