// <copyright file="RiseTransitSet.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

//// PJN / 28-03-2009 1. Fixed a bug in CAARiseTransitSet::Rise where the cyclical nature of a RA value was
//// not taken into account during the interpolation. In fact Meeus in the book even refers to this issue as 
//// "Important remarks, 2."  on page 30 of the second edition. Basically when interpolating RA, we need 
//// to be careful that the 3 values are consistent with respect to each other when any one of them wraps 
//// around from 23H 59M 59S around to 0H 0M 0S. In this case, the RA has increased by 0H 0M 1S of RA instead 
//// of decreasing by 23H 59M 59S. Thanks to Corky Corcoran and Danny Flippo for both reporting this issue. 
//// 2. Fixed a bug in the calculation of the parameter "H" in CAARiseTransitSet::Rise when  calculating 
//// the local hour angle of the body for the time of transit. PJN / 30-04-2009 1. Fixed a bug where 
//// the M values were not being constrained to between 0 and 1 in CAARiseTransitSet::Rise. Thanks to Matthew 
//// Yager for reporting this issue.
namespace AstroSharedEvents.Crossing { 
    using System;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Coordinates;
    using AstroSharedClasses.Records;
    using AstroSharedOrbits.OrbitalData;
    using JetBrains.Annotations;

    /// <summary>
    /// Rise Transit Set.
    /// </summary>
    [UsedImplicitly]
    public static class RiseTransitSet {
        #region Naughter
        /// <summary>
        /// Rises the specified julianDay.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="alpha1">The alpha1.</param>
        /// <param name="delta1">The delta1.</param>
        /// <param name="alpha2">The alpha2.</param>
        /// <param name="delta2">The delta2.</param>
        /// <param name="alpha3">The alpha3.</param>
        /// <param name="delta3">The delta3.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="h0">The h0.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static RiseTransitSetDetails Rise(double julianDay, double alpha1, double delta1, double alpha2, double delta2, double alpha3, double delta3, double longitude, double latitude, double h0) {
            //// What will be the return value
            var details = new RiseTransitSetDetails { BValid = false };

            //// Calculate the sidereal time
            var theta0 = SiderealTime.ApparentGreenwichSiderealTime(julianDay);
            theta0 *= 15; //// Express it as degrees

            //// Calculate deltat
            var deltaT = DynamicalTime.DeltaT(julianDay);

            //// Convert values to radians
            var delta2Rad = Angles.DegRad(delta2);
            var latitudeRad = Angles.DegRad(latitude);

            //// Convert the standard latitude to radians
            var h0Rad = Angles.DegRad(h0);

            var cosH0 = (Math.Sin(h0Rad) - Math.Sin(latitudeRad) * Math.Sin(delta2Rad)) / (Math.Cos(latitudeRad) * Math.Cos(delta2Rad));

            //// Check that the object actually rises
            if ((cosH0 > 1) || (cosH0 < -1)) {
                return details;
            }

            var angleH0 = Math.Acos(cosH0);
            angleH0 = Angles.RadDeg(angleH0);

            var m0 = (alpha2 * 15 + longitude - theta0) / 360;
            var m1 = m0 - angleH0 / 360;
            var m2 = m0 + angleH0 / 360;

            while (m0 > 1) {
                m0 -= 1;
            }

            while (m0 < 0) {
                m0 += 1;
            }

            while (m1 > 1) {
                m1 -= 1;
            }

            while (m1 < 0) {
                m1 += 1;
            }

            while (m2 > 1) {
                m2 -= 1;
            }

            while (m2 < 0) {
                m2 += 1;
            }

            //// Ensure the RA values are corrected for interpolation. Due to important Remark 2 by Meeus on Interopolation of RA values
            if ((alpha2 - alpha1) > 12.0) {
                alpha1 += 24;
            }
            else if ((alpha2 - alpha1) < -12.0) {
                alpha2 += 24;
            }

            if ((alpha3 - alpha2) > 12.0) {
                alpha2 += 24;
            }
            else if ((alpha3 - alpha2) < -12.0) {
                alpha3 += 24;
            }

            for (var i = 0; i < 2; i++) {
                //// Calculate the details of rising
                var theta1 = theta0 + 360.985647 * m1;
                theta1 = Angles.Mod360(theta1);

                var n = m1 + deltaT / 86400;

                var alpha = Interpolation.Interpolate(n, alpha1, alpha2, alpha3);
                var delta = Interpolation.Interpolate(n, delta1, delta2, delta3);

                var h = theta1 - longitude - alpha * 15;
                var horizontal = CoordinateTransformation.Equatorial2Horizontal(h / 15, delta, latitude);

                var deltaM = (horizontal.Y - h0) / (360 * Math.Cos(Angles.DegRad(delta)) * Math.Cos(latitudeRad) * Math.Sin(Angles.DegRad(h)));
                m1 += deltaM;

                //// Calculate the details of transit
                theta1 = theta0 + 360.985647 * m0;
                theta1 = Angles.Mod360(theta1);

                n = m0 + deltaT / 86400;

                alpha = Interpolation.Interpolate(n, alpha1, alpha2, alpha3);

                h = theta1 - longitude - alpha * 15;
                h = Angles.Mod360(h);
                if (h > 180) {
                    h -= 360;
                }

                deltaM = -h / 360;
                m0 += deltaM;

                //// Calculate the details of setting
                theta1 = theta0 + 360.985647 * m2;
                theta1 = Angles.Mod360(theta1);

                n = m2 + deltaT / 86400;

                alpha = Interpolation.Interpolate(n, alpha1, alpha2, alpha3);
                delta = Interpolation.Interpolate(n, delta1, delta2, delta3);

                h = theta1 - longitude - alpha * 15;
                horizontal = CoordinateTransformation.Equatorial2Horizontal(h / 15, delta, latitude);

                deltaM = (horizontal.Y - h0) / (360 * Math.Cos(Angles.DegRad(delta)) * Math.Cos(latitudeRad) * Math.Sin(Angles.DegRad(h)));
                m2 += deltaM;
            }

            //// Finally before we exit, convert to hours
            details.BValid = true;
            details.Rise = m1 * 24;
            details.Set = m2 * 24;
            details.Transit = m0 * 24;

            return details;
        }
        #endregion

        #region AstroAlgo
        /// <summary>Computes the rising, setting and transit time of a body.</summary>
        /// <param name="longL">Longitude in degrees.</param>
        /// <param name="phi">Latitude in degrees.</param>
        /// <param name="h0">Standard altitude of the body at time of rising and setting.  
        /// sun = -0.8333  stars and planets = -0.5667  moon (mean value ONLY) = +0.125 .
        /// </param>
        /// <param name="julianDay">Julian Day for day/time to calculate at 0 hour UT.</param>
        /// <param name="ascentA">Apparent right ascention in degrees at julianDay-1, julianDay and julianDay+1 respectively at 0 hour Dynamical Time.</param>
        /// <param name="declinD">Apparent declination in degrees at julianDay-1, julianDay and julianDay+1 respectively at 0 hour Dynamical Time.</param>
        /// <returns>Triple of transit, rising, and setting times.</returns>
        [UsedImplicitly]
        public static double[] RiseTranSet(double longL, double phi, double h0, double julianDay, double[] ascentA, double[] declinD) {
            var theta = new double[3];  //// array of sidereal times, transit, rising, setting
            var n = new double[3];      ////  interpolating factor, transit, rising, setting
            var alpha = new double[3];  //// right ascention correction factor
            var gamma = new double[3];  //// declination correction factor
            var localH = new double[3];      ////  local hour angle
            var h = new double[3];      ////  altitude
            const double deltaT = 56;
            var m = new double[3];              ////  transit, rising, setting time respectively of object

            ////  get apparent sidereal time at greenwich at 0 hour Universal Time on julianDay from an almanac or calculation
            ////  use a test value theta0 = 177.74208 from pg 99
            //// double theta0 = 177.74208;             ////  apparent sidereal time
            var theta0 = SiderealTime.AppSiderealTime(julianDay);

            ////  Make sure the body is not above or below the horizon all day
            if (
                Math.Abs(-Math.Sin(phi * Angles.Deg2Radian) * Math.Sin(declinD[1] * Angles.Deg2Radian) /
                         Math.Cos(phi * Angles.Deg2Radian) * Math.Cos(declinD[1] * Angles.Deg2Radian)) > 1) {
                throw new InvalidOperationException(
                    "The body is above or below the horizon all day and thus has no rising or setting time.");
            }

            ////  Calculate approximate times, 14.1  approximate time
            var angleH0 = Math.Acos((Math.Sin(h0 * Angles.Deg2Radian) - Math.Sin(phi * Angles.Deg2Radian) * Math.Sin(declinD[1] * Angles.Deg2Radian)) / (Math.Cos(phi * Angles.Deg2Radian) * Math.Cos(declinD[1] * Angles.Deg2Radian))) * Angles.Radian2Deg;

            ////  calculate transit time
            m[0] = Angles.Normalize0To1((ascentA[1] + longL - theta0) / 360.0);

            ////  calculate rise and set time
            m[1] = Angles.Normalize0To1(m[0] - angleH0 / 360.0);
            m[2] = Angles.Normalize0To1(m[0] + angleH0 / 360.0);

            ////  for each m value do
            for (short i = 0; i < 3; ++i) {
                ////  compute the sidereal time
                theta[i] = theta0 + 360.985647 * m[i];
                theta[i] = Angles.Normal360B(theta[i]);

                ////  compute interpolating factor
                n[i] = m[i] + (deltaT / 86400.0);

                ////  interpolate alpha and gamma from input, 3.3
                alpha[i] = ascentA[1] + (n[i] / 2.0) * (-ascentA[0] + ascentA[2] + n[i] * (ascentA[2] - ascentA[1] - ascentA[1] + ascentA[0]));
                gamma[i] = declinD[1] + (n[i] / 2.0) * (-declinD[0] + declinD[2] + n[i] * (declinD[2] - declinD[1] - declinD[1] + declinD[0]));

                ////  calculate local hour angle
                localH[i] = Angles.Normal180B(theta[i] - longL - alpha[i]);

                ////  calculate altitude, 12.6
                h[i] = Math.Asin(Math.Sin(phi * Angles.Deg2Radian) * Math.Sin(gamma[i] * Angles.Deg2Radian) + Math.Cos(phi * Angles.Deg2Radian) * Math.Cos(gamma[i] * Angles.Deg2Radian) * Math.Cos(localH[i] * Angles.Deg2Radian)) * Angles.Radian2Deg;
            }

            ////  make corrections
            m[0] = m[0] + (-localH[0] / 360.0);
            m[1] = m[1] + (h[1] - h0) / (360 * Math.Cos(gamma[1]) * Math.Cos(phi) * Math.Sin(localH[1]));
            m[2] = m[2] + (h[2] - h0) / (360 * Math.Cos(gamma[2]) * Math.Cos(phi) * Math.Sin(localH[2]));

            return m;
        }

        #endregion
    }
}
