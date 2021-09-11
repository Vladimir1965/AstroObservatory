// <copyright file="SiderealTime.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.OrbitalData
{
    using System;
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using JetBrains.Annotations;

    /// <summary>
    /// Support for Sidereal time.
    /// </summary>
    public static class SiderealTime {
        #region Naughter
        /// <summary>
        /// Means the greenwich sidereal time.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeanGreenwichSiderealTime(double julianDay) {
            //// Get the Julian day for the same day at midnight
            var date1 = new SpecialDate();
            date1.Set(julianDay, Date.AfterPapalReform(julianDay));
            date1.Get();
            var date = new SpecialDate();
            date.Set(date1.InnerYear, date1.InnerMonth, date1.InnerDay, 0, 0, 0, date.InGregorianCalendar());
            var julianDayMidnight = date.Julian();

            //// Calculate the sidereal time at midnight
            var julianCentury = (julianDayMidnight - 2451545) / 36525;
            var tSquared = julianCentury * julianCentury;
            var tCubed = tSquared * julianCentury;
            var value = 100.46061837 + (36000.770053608 * julianCentury) + (0.000387933 * tSquared) - (tCubed / 38710000);

            //// Adjust by the time of day
            value += ((date.InnerHour * 15) + (date.InnerMinute * 0.25) + (date.InnerSecond * 0.0041666666666666666666666666666667)) * 1.00273790935;

            value = Angles.DegreesToHours(value);

            return Angles.MapTo0To24Range(value);
        }

        /// <summary>
        /// Apparent the greenwich sidereal time.
        /// </summary>
        /// <param name="julianDay">The given julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double ApparentGreenwichSiderealTime(double julianDay) {
            var meanObliquity = Nutation.MeanObliquityOfEcliptic(julianDay);
            var trueObliquity = meanObliquity + Nutation.NutationInObliquity(julianDay) / 3600;
            var nutationInLongitude = Nutation.NutationInLongitude(julianDay);

            var value = MeanGreenwichSiderealTime(julianDay) + (nutationInLongitude * Math.Cos(Angles.DegRad(trueObliquity)) / 54000);
            return Angles.MapTo0To24Range(value);
        }
        #endregion

        #region AstroAlgo
        /// <summary>Computes the mean sidereal time, the Greenwich hour angle of the mean vernal point (the intersection of the ecliptic of the date with the mean equator of the date), for any instant UT NOT just 0 hour UT.</summary>
        /// <param name="jd">Julian Day at any instant UT.</param>
        /// <returns>Mean sidereal time at the meridian of Greenwich (double) in degrees.</returns>
        /// <remarks>Tested with Example 11.b pg 85.</remarks>
        [UsedImplicitly]
        public static double MeanSiderealTime(double jd) {
            //// calculate julian centuries for the given input
            var julianCentury = Julian.JulianCenturies(jd);

            //// calculate mst
            var mst = 280.46061837 + 360.98564736629 * (jd - 2451545.0) + 0.000387933 * julianCentury * julianCentury - (julianCentury * julianCentury * julianCentury) / 38710000.0;
            mst = Angles.Normal360B(mst);

            return mst;
        }

        /// <summary>Computes the apparent sidereal time at Greenwich, or the Greenwich hour angle of the true vernal equinox.</summary>
        /// <param name="jd">Julian Day at any instant UT.</param>
        /// <returns>Apparent sidereal time at the meridian of Greenwich (double) in degrees.</returns>
        public static double AppSiderealTime(double jd) {
            //// deltaPsi = nutation in longitude 
            //// deltaEpsilon = nutation of obliquity 
            //// epsilon = true obliquity of the ecliptic 
            //// epsilonNull = mean obliquity of the ecliptic 

            ////  convert day to Julian Centuries
            var julianCentury = Julian.JulianCenturies(jd);

            ////  calculate nutation and obliquity values
            Nutation.NutationOfLongitudeAndObliquity(julianCentury, out var deltaPsi, out var deltaEpsilon);
            Nutation.Obliquity(julianCentury, out var epsilon, out var epsilonNull);

            ////  determine the mean sidereal time for the given day
            var mst = MeanSiderealTime(jd);

            ////  determine the apparent sidereal time
            return mst + deltaPsi / 15.0 * Math.Cos(epsilon * Angles.Deg2Radian) / 240.0;
        }

        /// <summary>Computes the azimuth and altitude of a body knowing its apparent right ascension and declination.</summary>
        /// <param name="jd">Julian Day for day/time to calculate at UT.</param>
        /// <param name="alpha">Apparent right ascension in degrees.</param>
        /// <param name="delta">Apparent declination in degrees.</param>
        /// <param name="longL">Longitude in degrees.</param>
        /// <param name="phi">Latitude in degrees.</param>
        /// <param name="azimuthA">Azimuth in degrees west of south.</param>
        /// <param name="h">Altitude in degrees.</param>
        [UsedImplicitly]
        public static void AzimuthAltitude(double jd, double alpha, double delta, double longL, double phi, out double azimuthA, out double h) {
            //// apparent sidereal time at Greenwich
            var theta0 = AppSiderealTime(jd);

            //// calculate local hour angle  
            //// normalize the hour angle to +0 to +360 degrees 
            var hour = Angles.Normal360B(theta0 - longL - alpha);

            //// calculate azimuth
            azimuthA = Math.Atan2(Math.Sin(hour * Angles.Deg2Radian), Math.Cos(hour * Angles.Deg2Radian) * Math.Sin(phi * Angles.Deg2Radian) - Math.Tan(delta * Angles.Deg2Radian) * Math.Cos(phi * Angles.Deg2Radian)) * Angles.Radian2Deg;

            //// calculate altitude 
            h = Math.Asin(Math.Sin(phi * Angles.Deg2Radian) * Math.Sin(delta * Angles.Deg2Radian) + Math.Cos(phi * Angles.Deg2Radian) * Math.Cos(delta * Angles.Deg2Radian) * Math.Cos(hour * Angles.Deg2Radian)) * Angles.Radian2Deg;
        }

        /// <summary>Computes the apparent coordinates of the sun.</summary>
        /// <param name="julianDay">Julian Day for day/time to calculate at TD.</param>
        /// <param name="alpha">Apparent right ascension in degrees.</param>
        /// <param name="delta">Apparent declination in degrees.</param>
        /// <remark>Tested against example 24.a, pg. 153 on 2006-Jan-05.</remark>
        [UsedImplicitly]
        public static void ApparentSolarCoordinates(double julianDay, out double alpha, out double delta) {
            ////  Get Julian Centuries
            var julianCentury = Julian.JulianCenturies(julianDay);
            ////  calculate the geometric mean longitude of the sun
            var longL0 = 280.46645 + 36000.76983 * julianCentury + 0.0003032 * julianCentury * julianCentury;
            ////  calculate the mean anomaly of the sun
            var anomalyM = 357.52910 + 35999.05030 * julianCentury - 0.0001559 * julianCentury * julianCentury - 0.00000048 * julianCentury * julianCentury * julianCentury;
            ////  calculate the eccentricity of the Earth's Orbit
            //// double e = 0.016708617 - 0.000042037 * julianCentury - 0.0000001236 * julianCentury * julianCentury;
            ////  calculate the sun's equation of center
            var c = (1.914600 - 0.004817 * julianCentury - 0.000014 * julianCentury * julianCentury) * Math.Sin(anomalyM * Angles.Deg2Radian)
                       + (0.019993 - 0.000101 * julianCentury) * Math.Sin(2 * anomalyM * Angles.Deg2Radian)
                       + 0.000290 * Math.Sin(3 * anomalyM * Angles.Deg2Radian);
            ////  calculate the sun's true longitude
            var longitude = longL0 + c;
            ////  calculate the true anomaly of the sun 
            //// double v = anomalyM + C;
            ////  calculate the sun's radius vector, distance of the earth in AUs
            //// double R = (1.000001018 * (1 - e * e)) / (1 + e * Math.Cos(v * Angles.Deg2Radian));
            //// nutation
            var omega = 125.04 - 1934.136 * julianCentury;

            ////  calculate the apparent longitude of the sun
            var lamda = Angles.Normal360B(longitude - 0.00569 - 0.00478 * Math.Sin(omega * Angles.Deg2Radian));

            ////  calculate the mean obliquity of the ecliptic
            var ep0 = ((23 * 60) + 26) * 60 + 21.448 - 46.8150 * julianCentury - 0.00059 * julianCentury * julianCentury + 0.001813 * julianCentury * julianCentury * julianCentury;
            ep0 /= 3600;

            ////  correct mean obliquity of the ecliptic
            ep0 = ep0 + 0.00256 * Math.Cos(omega * Angles.Deg2Radian);

            ////  calculate right ascension and declination
            alpha = Angles.Normal360B(Math.Atan2(Math.Cos(ep0 * Angles.Deg2Radian) * Math.Sin(lamda * Angles.Deg2Radian), Math.Cos(lamda * Angles.Deg2Radian)) * Angles.Radian2Deg);
            delta = Math.Asin(Math.Sin(ep0 * Angles.Deg2Radian) * Math.Sin(lamda * Angles.Deg2Radian)) * Angles.Radian2Deg;
        }
        #endregion
    }
}
