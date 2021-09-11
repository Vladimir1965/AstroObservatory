// <copyright file="MoonIllumination.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Moons {
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Coordinates;
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Moon Illuminated Fraction.
    /// </summary>
    public static class MoonIllumination {
        #region Naughter
        /// <summary>
        /// Geocentric elongation.
        /// </summary>
        /// <param name="objectAlpha">The object alpha.</param>
        /// <param name="objectDelta">The object delta.</param>
        /// <param name="sunAlpha">The sun alpha.</param>
        /// <param name="sunDelta">The sun delta.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double GeocentricElongation(double objectAlpha, double objectDelta, double sunAlpha, double sunDelta) {
            //// Convert the RA's to radians
            objectAlpha = Angles.DegRad(objectAlpha * 15);
            sunAlpha = Angles.DegRad(sunAlpha * 15);

            //// Convert the declinations to radians
            objectDelta = Angles.DegRad(objectDelta);
            sunDelta = Angles.DegRad(sunDelta);

            //// Return the result
            return Angles.RadDeg(Math.Acos(Math.Sin(sunDelta) * Math.Sin(objectDelta) + Math.Cos(sunDelta) * Math.Cos(objectDelta) * Math.Cos(sunAlpha - objectAlpha)));
        }

        /// <summary>
        /// Phases the angle.
        /// </summary>
        /// <param name="geocentricElongation">The geocentric elongation.</param>
        /// <param name="earthObjectDistance">The earth object distance.</param>
        /// <param name="earthSunDistance">The earth sun distance.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double PhaseAngle(double geocentricElongation, double earthObjectDistance, double earthSunDistance) {
            //// Convert from degrees to radians
            geocentricElongation = Angles.DegRad(geocentricElongation);

            //// Return the result
            return Angles.Mod360(Angles.RadDeg(Math.Atan2(earthSunDistance * Math.Sin(geocentricElongation), earthObjectDistance - earthSunDistance * Math.Cos(geocentricElongation))));
        }

        /// <summary>
        /// Illuminateds the fraction.
        /// </summary>
        /// <param name="phaseAngle">The phase angle.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double IlluminatedFraction(double phaseAngle) {
            //// Convert from degrees to radians
            phaseAngle = Angles.DegRad(phaseAngle);

            //// Return the result
            return (1 + Math.Cos(phaseAngle)) / 2;
        }

        /// <summary>
        /// Positions the angle.
        /// </summary>
        /// <param name="coord0">The coord0.</param>
        /// <param name="coord1">The coord1.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double PositionAngle(CoordinateEquatorial2D coord0, CoordinateEquatorial2D coord1) {
            //// Convert to radians
            var alpha0 = coord0.AlphaRadians;
            var alpha1 = coord1.AlphaRadians;
            var delta0 = coord0.DeltaRadians;
            var delta1 = coord1.DeltaRadians;

            return Angles.Mod360(Angles.RadDeg(Math.Atan2(Math.Cos(delta0) * Math.Sin(alpha0 - alpha1), Math.Sin(delta0) * Math.Cos(delta1) - Math.Cos(delta0) * Math.Sin(delta1) * Math.Cos(alpha0 - alpha1))));
        }
        #endregion

        #region AstroAlgo
        /// <summary>
        /// Calculate lunar illumination in a year.  Starts at midnight the first day of the year.
        /// </summary>
        /// <param name="inc">Whole or fractional days between each calculation.</param>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double[] GetLunations(double inc, int year) {
            ////  increment size must be greater than 0
            inc = (inc > 0) ? inc : 1;

            ////  create an array the size of number of days in the year
            var day1 = new DateTime(year, 1, 1, 0, 0, 0);

            ////  create a double array the size of the number of days in the current object's year
            ////  divided by the increment size
            var lunations = new double[(int)((DateTime.IsLeapYear(day1.Year) ? 366 : 365) / inc)];

            ////  calculate each of the illumination values for each increment
            for (var i = 0; i < lunations.Length; ++i) {
                var jd = Julian.Date2Julian(day1);
                lunations[i] = SimpleIllumination(jd);
                day1 = day1.AddDays(inc);
            }

            return lunations;
        }

        /// <summary>
        /// Simple illumination.
        /// </summary>
        /// <param name="jd">The jd.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SimpleIllumination(double jd) {
            ////  Julian Centuries pg. 131
            var timeT = (jd - 2451545.0) / 36525.0;

            //// mean elogation of the moon
            var elongationD = 297.8502042 + (445267.1115168 * timeT)
                       - (0.0016300 * timeT * timeT)
                       + ((timeT * timeT * timeT) / 545868)
                       - ((timeT * timeT * timeT * timeT) / 113065000);

            //// sun's mean anomaly
            var anomalyM = 357.5291092 + (35999.0502909 * timeT)
                       - (0.0001536 * timeT * timeT)
                       + ((timeT * timeT * timeT) / 24490000);

            //// moon's mean anomaly
            var mprime = 134.9634114 + (477198.8676313 * timeT)
                            + (0.0089970 * timeT * timeT)
                            + ((timeT * timeT * timeT) / 69699)
                            - ((timeT * timeT * timeT * timeT) / 14712000);

            elongationD = Math.IEEERemainder(elongationD, 360.0);
            anomalyM = Math.IEEERemainder(anomalyM, 360.0);
            mprime = Math.IEEERemainder(mprime, 360.0);

            anomalyM = Angles.Deg2Radian * anomalyM;
            mprime = Angles.Deg2Radian * mprime;

            //// phase angle of the moon
            var i = 180 - elongationD - (6.289 * Math.Sin(mprime))
                       + (2.100 * Math.Sin(anomalyM))
                       - (1.274 * Math.Sin(2 * Angles.Deg2Radian * elongationD - mprime))
                       - (0.658 * Math.Sin(2 * Angles.Deg2Radian * elongationD))
                       - (0.214 * Math.Sin(2 * mprime))
                       - (0.110 * Math.Sin(Angles.Deg2Radian * elongationD));

            //// illuminated fraction of moon's disc
            var k = (1 + Math.Cos(i * Angles.Deg2Radian)) / 2;

            return k;
        }
        #endregion
    }
}
