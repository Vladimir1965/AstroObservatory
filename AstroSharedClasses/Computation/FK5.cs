// <copyright file="FK5.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation
{
    using System;

    /// <summary>
    /// FK5 corrections.
    /// </summary>
    public static class FK5 {
        /// <summary>
        /// Corrections the in longitude.
        /// </summary>
        /// <param name="longitude">The given longitude.</param>
        /// <param name="latitude">The given latitude.</param>
        /// <param name="julianDay">The given julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double CorrectionInLongitude(double longitude, double latitude, double julianDay) {
            var julianCentury = (julianDay - 2451545) / 36525;
            var ldash = longitude - 1.397 * julianCentury - 0.00031 * julianCentury * julianCentury;

            //// Convert to radians
            ldash = Computation.Angles.DegRad(ldash);
            //// Longitude = Angles.DegRad(Longitude);
            latitude = Computation.Angles.DegRad(latitude);

            var val = -0.09033 + 0.03916 * (Math.Cos(ldash) + Math.Sin(ldash)) * Math.Tan(latitude);
            return Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, val);
        }

        /// <summary>
        /// Corrections the in latitude.
        /// </summary>
        /// <param name="longitude">The longitude.</param>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double CorrectionInLatitude(double longitude, double julianDay) {
            var julianCentury = (julianDay - 2451545) / 36525;
            var ldash = longitude - 1.397 * julianCentury - 0.00031 * julianCentury * julianCentury;

            //// Convert to radians
            ldash = Computation.Angles.DegRad(ldash);
            //// Longitude = Angles.DegRad(Longitude);

            var val = 0.03916 * (Math.Cos(ldash) - Math.Sin(ldash));
            return Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, val);
        }

        /// <summary>
        /// Converts the Vsop to F k5 J2000.
        /// </summary>
        /// <param name="val">The given value.</param>
        /// <returns> Returns value. </returns>
        public static Coordinates.Coordinate3D ConvertVsopToFK5J2000(Coordinates.Coordinate3D val) {
            var result = new Coordinates.Coordinate3D {
                X = val.X + 0.000000440360 * val.Y - 0.000000190919 * val.Z,
                Y = -0.000000479966 * val.X + 0.917482137087 * val.Y - 0.397776982902 * val.Z,
                Z = 0.397776982902 * val.Y + 0.917482137087 * val.Z
            };

            return result;
        }

        /// <summary>
        /// Converts the Vsop to F k5 B1950.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns> Returns value. </returns>
        public static Coordinates.Coordinate3D ConvertVsopToFK5B1950(Coordinates.Coordinate3D val) {
            var result = new Coordinates.Coordinate3D {
                X = 0.999925702634 * val.X + 0.012189716217 * val.Y + 0.000011134016 * val.Z,
                Y = -0.011179418036 * val.X + 0.917413998946 * val.Y - 0.397777041885 * val.Z,
                Z = -0.004859003787 * val.X + 0.397747363646 * val.Y + 0.917482111428 * val.Z
            };

            return result;
        }

        /// <summary>
        /// Converts the Vsop to F k5 any equinox.
        /// </summary>
        /// <param name="val">The given value.</param>
        /// <param name="julianDayEquinox">The julianDay equinox.</param>
        /// <returns> Returns value. </returns>
        public static Coordinates.Coordinate3D ConvertVsopToFK5AnyEquinox(Coordinates.Coordinate3D val, double julianDayEquinox) {
            var t = (julianDayEquinox - 2451545.0) / 36525;
            var timeSquared = t * t;
            var timeCubed = timeSquared * t;

            var sigma = 2306.2181 * t + 0.30188 * timeSquared + 0.017988 * timeCubed;
            sigma = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, sigma));

            var zeta = 2306.2181 * t + 1.09468 * timeSquared + 0.018203 * timeCubed;
            zeta = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, zeta));

            var phi = 2004.3109 * t - 0.42665 * timeSquared - 0.041833 * timeCubed;
            phi = Computation.Angles.DegRad(Coordinates.CoordinateTransformation.DmsToDegrees(0, 0, phi));

            var cosSigma = Math.Cos(sigma);
            var cosZeta = Math.Cos(zeta);
            var cosPhi = Math.Cos(phi);
            var sinSigma = Math.Sin(sigma);
            var sinZeta = Math.Sin(zeta);
            var sinPhi = Math.Sin(phi);

            var xx = cosSigma * cosZeta * cosPhi - sinSigma * sinZeta;
            var xy = sinSigma * cosZeta + cosSigma * sinZeta * cosPhi;
            var xz = cosSigma * sinPhi;
            var yx = -cosSigma * sinZeta - sinSigma * cosZeta * cosPhi;
            var yy = cosSigma * cosZeta - sinSigma * sinZeta * cosPhi;
            var yz = -sinSigma * sinPhi;
            var zx = -cosZeta * sinPhi;
            var zy = -sinZeta * sinPhi;
            var zz = cosPhi;

            var result = new Coordinates.Coordinate3D {
                X = xx * val.X + yx * val.Y + zx * val.Z,
                Y = xy * val.X + yy * val.Y + zy * val.Z,
                Z = xz * val.X + yz * val.Y + zz * val.Z
            };

            return result;
        }
    }
}
