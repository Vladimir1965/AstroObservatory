// <copyright file="MoonPerigeeApogee.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>
//// History: PJN / 07-02-2009 1. Fixed a seemingly copy and paste bug in TruePerigee. The layout of the code to accumulate 
//// the "Sigma" value was incorrect. The terms involving T (e.g. +0.00019*T, -0.00013*T etc were adding these terms 
//// to the argument of the sin incorrectly. With the bug fixed the worked example 50.a from the book gives: 2447442.3543003569 
//// JulianDayE or 1988 October 7 at 20h:30m:11.5 seconds. The previous buggy code was giving the same value of 2447442.3543003569, 
//// but this would be the case because T was a small value in the example.  You would expect the error in the calculated 
//// to be bigger as the date departs from the Epoch 2000.0. Thanks to Neoklis Kyriazis for reporting this bug.

namespace AstroSharedOrbits.Moons {
    using System;
    using System.Linq;
    using AstroSharedClasses.Computation;
    using AstroSharedOrbits.OrbitalData;
    using JetBrains.Annotations;

    /// <summary>
    /// Moon Perigee Apogee.
    /// </summary>
    [UsedImplicitly]
    public static class MoonPerigeeApogee {
        /// <summary>
        /// Ks the specified year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double K(double year) {
            return 13.2555 * (year - 1999.97);
        }

        /// <summary>
        /// Means the perigee.
        /// </summary>
        /// <param name="givenK">The given givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeanPerigee(double givenK) {
            //// convert from K to T
            var timeT = givenK / 1325.55;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;
            var dT4 = timeCubed * timeT;

            return 2451534.6698 + 27.55454989 * givenK - 0.0006691 * timeSquared - 0.000001098 * timeCubed + 0.0000000052 * dT4;
        }

        /// <summary>
        /// Means the apogee.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeanApogee(double givenK) {
            //// Uses the same formula as MeanPerigee
            return MeanPerigee(givenK);
        }

        /// <summary>
        /// Trues the perigee.
        /// </summary>
        /// <param name="givenK">The given givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double TruePerigee(double givenK) {
            var meanJulianDay = MeanPerigee(givenK);

            //// convert from K to timeT
            var timeT = givenK / 1325.55;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;
            var dT4 = timeCubed * timeT;

            var elongD = Angles.Mod360(171.9179 + 335.9106046 * givenK - 0.0100383 * timeSquared - 0.00001156 * timeCubed + 0.000000055 * dT4);
            elongD = Angles.DegRad(elongD);
            var anomalyM = Angles.Mod360(347.3477 + 27.1577721 * givenK - 0.0008130 * timeSquared - 0.0000010 * timeCubed);
            anomalyM = Angles.DegRad(anomalyM);
            var latitudeF = Angles.Mod360(316.6109 + 364.5287911 * givenK - 0.0125053 * timeSquared - 0.0000148 * timeCubed);
            latitudeF = Angles.DegRad(latitudeF);

            var sigma = MoonPerigeeQuotients.MoonPerigeeApogeeCoefficients1.Sum(t => (t.C + timeT * t.T) * Math.Sin(elongD * t.D + anomalyM * t.M + latitudeF * t.LatitudeF));

            return meanJulianDay + sigma;
        }

        /// <summary>
        /// Perigees the parallax.
        /// </summary>
        /// <param name="givenK">The given K.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double PerigeeParallax(double givenK) {
            //// convert from K to T
            var timeT = givenK / 1325.55;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;
            var dT4 = timeCubed * timeT;

            var elongD = Angles.Mod360(171.9179 + 335.9106046 * givenK - 0.0100383 * timeSquared - 0.00001156 * timeCubed + 0.000000055 * dT4);
            elongD = Angles.DegRad(elongD);
            var anomalyM = Angles.Mod360(347.3477 + 27.1577721 * givenK - 0.0008130 * timeSquared - 0.0000010 * timeCubed);
            anomalyM = Angles.DegRad(anomalyM);
            var latitudeF = Angles.Mod360(316.6109 + 364.5287911 * givenK - 0.0125053 * timeSquared - 0.0000148 * timeCubed);
            latitudeF = Angles.DegRad(latitudeF);

            var parallax = 3629.215 + MoonPerigeeQuotients.MoonPerigeeApogeeCoefficients3.Sum(t => (t.C + timeT * t.T) * Math.Cos(elongD * t.D + anomalyM * t.M + latitudeF * t.LatitudeF));

            return parallax / 3600;
        }

        /// <summary>
        /// Trues the apogee.
        /// </summary>
        /// <param name="givenK">The given k.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double TrueApogee(double givenK) {
            var meanJulianDay = MeanApogee(givenK);

            //// convert from K to T
            var timeT = givenK / 1325.55;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;
            var dT4 = timeCubed * timeT;

            var elongD =
                Angles.Mod360(171.9179 + 335.9106046 * givenK - 0.0100383 * timeSquared - 0.00001156 * timeCubed +
                                                          0.000000055 * dT4);
            elongD = Angles.DegRad(elongD);
            var anomalyM = Angles.Mod360(347.3477 + 27.1577721 * givenK - 0.0008130 * timeSquared - 0.0000010 * timeCubed);
            anomalyM = Angles.DegRad(anomalyM);
            var latitudeF =
                Angles.Mod360(316.6109 + 364.5287911 * givenK - 0.0125053 * timeSquared - 0.0000148 * timeCubed);
            latitudeF = Angles.DegRad(latitudeF);

            var sigma = MoonPerigeeQuotients.MoonPerigeeApogeeCoefficients2.Sum(t => (t.C + timeT * t.T) * Math.Sin(elongD * t.D + anomalyM * t.M + latitudeF * t.LatitudeF));

            return meanJulianDay + sigma;
        }

        /// <summary>
        /// Apogees the parallax.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double ApogeeParallax(double givenK) {
            //// convert from K to T
            var timeT = givenK / 1325.55;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;
            var dT4 = timeCubed * timeT;

            var elongD =
                Angles.Mod360(171.9179 + 335.9106046 * givenK - 0.0100383 * timeSquared - 0.00001156 * timeCubed +
                                                          0.000000055 * dT4);
            elongD = Angles.DegRad(elongD);
            var anomalyM =
                Angles.Mod360(347.3477 + 27.1577721 * givenK - 0.0008130 * timeSquared - 0.0000010 * timeCubed);
            anomalyM = Angles.DegRad(anomalyM);
            var latitudeF =
                Angles.Mod360(316.6109 + 364.5287911 * givenK - 0.0125053 * timeSquared - 0.0000148 * timeCubed);
            latitudeF = Angles.DegRad(latitudeF);

            var parallax = 3245.251 + MoonPerigeeQuotients.MoonPerigeeApogeeCoefficients4.Sum(t => (t.C + timeT * t.T) * Math.Cos(elongD * t.D + anomalyM * t.M + latitudeF * t.LatitudeF));
            return parallax / 3600;
        }
    }
}