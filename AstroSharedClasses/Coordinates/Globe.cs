// <copyright file="Globe.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Coordinates {
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// Globe object.
    /// </summary>
    public static class Globe {
        /// <summary>
        /// Rho sin theta prime.
        /// </summary>
        /// <param name="geographicalLatitude">The geographical latitude.</param>
        /// <param name="height">The height.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double RhoSinThetaPrime(double geographicalLatitude, double height) {
            geographicalLatitude = Computation.Angles.DegRad(geographicalLatitude);

            var u = Math.Atan(0.99664719 * Math.Tan(geographicalLatitude));
            return 0.99664719 * Math.Sin(u) + (height / 6378149 * Math.Sin(geographicalLatitude));
        }

        /// <summary>
        /// Rho cos theta prime.
        /// </summary>
        /// <param name="geographicalLatitude">The geographical latitude.</param>
        /// <param name="height">The height.</param>
        /// <returns> Returns value. </returns>
        public static double RhoCosThetaPrime(double geographicalLatitude, double height) {
            //// Convert from degrees to radians
            geographicalLatitude = Computation.Angles.DegRad(geographicalLatitude);

            var u = Math.Atan(0.99664719 * Math.Tan(geographicalLatitude));
            return Math.Cos(u) + (height / 6378149 * Math.Cos(geographicalLatitude));
        }

        /// <summary>
        /// Radius of parallel of latitude.
        /// </summary>
        /// <param name="geographicalLatitude">The geographical latitude.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double RadiusOfParallelOfLatitude(double geographicalLatitude) {
            //// Convert from degrees to radians
            geographicalLatitude = Computation.Angles.DegRad(geographicalLatitude);

            var sinGeo = Math.Sin(geographicalLatitude);
            return (6378.14 * Math.Cos(geographicalLatitude)) / Math.Sqrt(1 - 0.0066943847614084 * sinGeo * sinGeo);
        }

        /// <summary>
        /// Radius of curvature.
        /// </summary>
        /// <param name="geographicalLatitude">The geographical latitude.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double RadiusOfCurvature(double geographicalLatitude) {
            //// Convert from degrees to radians
            geographicalLatitude = Computation.Angles.DegRad(geographicalLatitude);

            var sinGeo = Math.Sin(geographicalLatitude);
            return (6378.14 * (1 - 0.0066943847614084)) / Math.Pow(1 - 0.0066943847614084 * sinGeo * sinGeo, 1.5);
        }

        /// <summary>
        /// Distances the between points.
        /// </summary>
        /// <param name="geographicalLatitude1">The geographical latitude1.</param>
        /// <param name="geographicalLongitude1">The geographical longitude1.</param>
        /// <param name="geographicalLatitude2">The geographical latitude2.</param>
        /// <param name="geographicalLongitude2">The geographical longitude2.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double DistanceBetweenPoints(double geographicalLatitude1, double geographicalLongitude1, double geographicalLatitude2, double geographicalLongitude2) {
            //// Convert from degrees to radians
            geographicalLatitude1 = Computation.Angles.DegRad(geographicalLatitude1);
            geographicalLatitude2 = Computation.Angles.DegRad(geographicalLatitude2);
            geographicalLongitude1 = Computation.Angles.DegRad(geographicalLongitude1);
            geographicalLongitude2 = Computation.Angles.DegRad(geographicalLongitude2);

            var latitudeF = (geographicalLatitude1 + geographicalLatitude2) / 2;
            var g = (geographicalLatitude1 - geographicalLatitude2) / 2;
            var lambda = (geographicalLongitude1 - geographicalLongitude2) / 2;
            var sinG = Math.Sin(g);
            var cosG = Math.Cos(g);
            var cosF = Math.Cos(latitudeF);
            var sinF = Math.Sin(latitudeF);
            var sinLambda = Math.Sin(lambda);
            var cosLambda = Math.Cos(lambda);
            var s = (sinG * sinG * cosLambda * cosLambda) + (cosF * cosF * sinLambda * sinLambda);
            var c = (cosG * cosG * cosLambda * cosLambda) + (sinF * sinF * sinLambda * sinLambda);
            var w = Math.Atan(Math.Sqrt(s / c));
            var r = Math.Sqrt(s * c) / w;
            var d = 2 * w * 6378.14;
            var hprime = (3 * r - 1) / (2 * c);
            var hprime2 = (3 * r + 1) / (2 * s);
            const double f = 0.0033528131778969144060323814696721;

            return d * (1 + (f * hprime * sinF * sinF * cosG * cosG) - (f * hprime2 * cosF * cosF * sinG * sinG));
        }
    }
}
