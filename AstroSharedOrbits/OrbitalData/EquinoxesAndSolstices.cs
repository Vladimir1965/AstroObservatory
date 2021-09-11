// <copyright file="EquinoxesAndSolstices.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.OrbitalData
{
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Enums;
    using AstroSharedOrbits.Systems;
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Equinoxes And Solstices.
    /// </summary>
    [UsedImplicitly]
    public static class EquinoxesAndSolstices {
        #region Naughter
        /// <summary>
        /// Springs the equinox.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SpringEquinox(long year) {
            //// calculate the approximate date
            double julianDayE;
            if (year <= 1000) {
                var y = year / 1000.0;
                var ysquared = y * y;
                var ycubed = ysquared * y;
                var y4 = ycubed * y;
                julianDayE = 1721139.29189 + 365242.13740 * y + 0.06134 * ysquared + 0.00111 * ycubed - 0.00071 * y4;
            }
            else {
                var y = (year - 2000) / 1000.0;
                var ysquared = y * y;
                var ycubed = ysquared * y;
                var y4 = ycubed * y;
                julianDayE = 2451623.80984 + 365242.37404 * y + 0.05169 * ysquared - 0.00411 * ycubed - 0.00057 * y4;
            }

            double correction;
            do {
                var sunLongitude = BodySun.ApparentEclipticLongitude(julianDayE);
                correction = 58 * Math.Sin(Angles.DegRad(-sunLongitude));
                julianDayE += correction;
            }
            while (Math.Abs(correction) > 0.00001); //// Corresponds to an error of 0.86 of a second

            return julianDayE;
        }

        /// <summary>
        /// Summers the solstice.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SummerSolstice(long year) {
            //// calculate the approximate date
            double julianDayE;

            if (year <= 1000) {
                var y = year / 1000.0;
                var ysquared = y * y;
                var ycubed = ysquared * y;
                var y4 = ycubed * y;
                julianDayE = 1721233.25401 + 365241.72562 * y - 0.05323 * ysquared + 0.00907 * ycubed + 0.00025 * y4;
            }
            else {
                var y = (year - 2000) / 1000.0;
                var ysquared = y * y;
                var ycubed = ysquared * y;
                var y4 = ycubed * y;
                julianDayE = 2451716.56767 + 365241.62603 * y + 0.00325 * ysquared + 0.00888 * ycubed - 0.00030 * y4;
            }

            double correction;
            do {
                var sunLongitude = BodySun.ApparentEclipticLongitude(julianDayE);
                correction = 58 * Math.Sin(Angles.DegRad(90 - sunLongitude));
                julianDayE += correction;
            }
            while (Math.Abs(correction) > 0.00001); //// Corresponds to an error of 0.86 of a second

            return julianDayE;
        }

        /// <summary>
        /// Autumns the equinox.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double AutumnEquinox(long year) {
            //// calculate the approximate date
            double julianDayE;

            if (year <= 1000) {
                var y = year / 1000.0;
                var ysquared = y * y;
                var ycubed = ysquared * y;
                var y4 = ycubed * y;
                julianDayE = 1721325.70455 + 365242.49558 * y - 0.11677 * ysquared - 0.00297 * ycubed + 0.00074 * y4;
            }
            else {
                var y = (year - 2000) / 1000.0;
                var ysquared = y * y;
                var ycubed = ysquared * y;
                var y4 = ycubed * y;
                julianDayE = 2451810.21715 + 365242.01767 * y - 0.11575 * ysquared + 0.00337 * ycubed + 0.00078 * y4;
            }

            double correction;
            do {
                var sunLongitude = BodySun.ApparentEclipticLongitude(julianDayE);
                correction = 58 * Math.Sin(Angles.DegRad(180 - sunLongitude));
                julianDayE += correction;
            }
            while (Math.Abs(correction) > 0.00001); //// Corresponds to an error of 0.86 of a second

            return julianDayE;
        }

        /// <summary>
        /// Winters the solstice.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double WinterSolstice(long year) {
            //// calculate the approximate date
            double julianDayE;

            if (year <= 1000) {
                var y = year / 1000.0;
                var ysquared = y * y;
                var ycubed = ysquared * y;
                var y4 = ycubed * y;
                julianDayE = 1721414.39987 + 365242.88257 * y - 0.00769 * ysquared - 0.00933 * ycubed - 0.00006 * y4;
            }
            else {
                var y = (year - 2000) / 1000.0;
                var ysquared = y * y;
                var ycubed = ysquared * y;
                var y4 = ycubed * y;
                julianDayE = 2451900.05952 + 365242.74049 * y - 0.06223 * ysquared - 0.00823 * ycubed + 0.00032 * y4;
            }

            double correction;
            do {
                var sunLongitude = BodySun.ApparentEclipticLongitude(julianDayE);
                correction = 58 * Math.Sin(Angles.DegRad(270 - sunLongitude));
                julianDayE += correction;
            }
            while (Math.Abs(correction) > 0.00001); //// Corresponds to an error of 0.86 of a second

            return julianDayE;
        }

        /// <summary>
        /// Length of the spring.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double LengthOfSpring(long year) {
            return SummerSolstice(year) - SpringEquinox(year);
        }

        /// <summary>
        /// Length the of summer.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double LengthOfSummer(long year) {
            return AutumnEquinox(year) - SummerSolstice(year);
        }

        /// <summary>
        /// Length the of autumn.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double LengthOfAutumn(long year) {
            return WinterSolstice(year) - AutumnEquinox(year);
        }

        /// <summary>
        /// Length the of winter.
        /// </summary>
        /// <param name="year">The given year.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double LengthOfWinter(long year) {
            //// The winter season wraps around into the following Year
            return SpringEquinox(year + 1) - WinterSolstice(year);
        }
        #endregion

        #region AstroAlgo
        /// <summary>
        /// Get the date the equinox or solstice occurs.
        /// </summary>
        /// <param name="season">Equinox or solstice to calculate for.</param>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Date and time event occurs.
        /// </returns>
        [UsedImplicitly]
        public static DateTime GetEquinoxSolstice(EquinoxType season, int year) {
            return Julian.Julian2Date(EquinoxSolstice(year, season));
        }

        /// <summary>Calculates time of Equinox and Solstice.
        /// </summary>
        /// <param name="year">Year to calculate for.</param>
        /// <param name="inES">Event to calculate.</param>
        /// <returns>Date and time event occurs as a fractional Julian Day.</returns>
        [UsedImplicitly]
        public static double EquinoxSolstice(double year, EquinoxType inES) {
            double y;
            double jden;           //// Julian Ephemeris Day 

            if (year >= 1000)
            {
                y = (Math.Floor(year) - 2000) / 1000;

                switch (inES)
                {
                    case EquinoxType.VernalEquinox:
                        jden = 2451623.80984 + 365242.37404 * y + 0.05169 * (y * y) - 0.00411 * (y * y * y) - 0.00057 * (y * y * y * y);
                        break;
                    case EquinoxType.SummerSolstice:
                        jden = 2451716.56767 + 365241.62603 * y + 0.00325 * (y * y) - 0.00888 * (y * y * y) - 0.00030 * (y * y * y * y);
                        break;
                    case EquinoxType.AutumnalEquinox:
                        jden = 2451810.21715 + 365242.01767 * y + 0.11575 * (y * y) - 0.00337 * (y * y * y) - 0.00078 * (y * y * y * y);
                        break;
                    case EquinoxType.WinterSolstice:
                        jden = 2451900.05952 + 365242.74049 * y + 0.06223 * (y * y) - 0.00823 * (y * y * y) - 0.00032 * (y * y * y * y);
                        break;
                    default:
                        return -1; // throw exception
                }
            }
            else
            {
                y = Math.Floor(year) / 1000;

                switch (inES)
                {
                    case EquinoxType.VernalEquinox:
                        jden = 1721139.29189 + 365242.13740 * y + 0.06134 * (y * y) - 0.00111 * (y * y * y) - 0.00071 * (y * y * y * y);
                        break;
                    case EquinoxType.SummerSolstice:
                        jden = 1721233.25401 + 365241.72562 * y + 0.05323 * (y * y) - 0.00907 * (y * y * y) - 0.00025 * (y * y * y * y);
                        break;
                    case EquinoxType.AutumnalEquinox:
                        jden = 1721325.70455 + 365242.49558 * y + 0.11677 * (y * y) - 0.00297 * (y * y * y) - 0.00074 * (y * y * y * y);
                        break;
                    case EquinoxType.WinterSolstice:
                        jden = 1721414.39987 + 365242.88257 * y + 0.00769 * (y * y) - 0.00933 * (y * y * y) - 0.00006 * (y * y * y * y);
                        break;
                    default:
                        return -1; // throw exception
                }
            }

            var julianCentury = (jden - 2451545.0) / 36525;

            var w = 35999.373 * julianCentury - 2.47;

            var lambda = 1 + 0.0334 * Math.Cos(w * Angles.Deg2Radian) + 0.0007 * Math.Cos(2 * w * Angles.Deg2Radian);

            var valueS = 485 * Math.Cos(Angles.Deg2Radian * 324.96 + Angles.Deg2Radian * (1934.136 * julianCentury))
                       + 203 * Math.Cos(Angles.Deg2Radian * 337.23 + Angles.Deg2Radian * (32964.467 * julianCentury))
                       + 199 * Math.Cos(Angles.Deg2Radian * 342.08 + Angles.Deg2Radian * (20.186 * julianCentury))
                       + 182 * Math.Cos(Angles.Deg2Radian * 27.85 + Angles.Deg2Radian * (445267.112 * julianCentury))
                       + 156 * Math.Cos(Angles.Deg2Radian * 73.14 + Angles.Deg2Radian * (45036.886 * julianCentury))
                       + 136 * Math.Cos(Angles.Deg2Radian * 171.52 + Angles.Deg2Radian * (22518.443 * julianCentury))
                       + 77 * Math.Cos(Angles.Deg2Radian * 222.54 + Angles.Deg2Radian * (65928.934 * julianCentury))
                       + 74 * Math.Cos(Angles.Deg2Radian * 296.72 + Angles.Deg2Radian * (3034.906 * julianCentury))
                       + 70 * Math.Cos(Angles.Deg2Radian * 243.58 + Angles.Deg2Radian * (9037.513 * julianCentury))
                       + 58 * Math.Cos(Angles.Deg2Radian * 119.81 + Angles.Deg2Radian * (33718.147 * julianCentury))
                       + 52 * Math.Cos(Angles.Deg2Radian * 297.17 + Angles.Deg2Radian * (150.678 * julianCentury))
                       + 50 * Math.Cos(Angles.Deg2Radian * 21.02 + Angles.Deg2Radian * (2281.226 * julianCentury))
                       + 45 * Math.Cos(Angles.Deg2Radian * 247.54 + Angles.Deg2Radian * (29929.562 * julianCentury))
                       + 44 * Math.Cos(Angles.Deg2Radian * 325.15 + Angles.Deg2Radian * (31555.956 * julianCentury))
                       + 29 * Math.Cos(Angles.Deg2Radian * 60.93 + Angles.Deg2Radian * (4443.417 * julianCentury))
                       + 28 * Math.Cos(Angles.Deg2Radian * 155.12 + Angles.Deg2Radian * (67555.328 * julianCentury))
                       + 17 * Math.Cos(Angles.Deg2Radian * 288.79 + Angles.Deg2Radian * (4562.452 * julianCentury))
                       + 16 * Math.Cos(Angles.Deg2Radian * 198.04 + Angles.Deg2Radian * (62894.029 * julianCentury))
                       + 14 * Math.Cos(Angles.Deg2Radian * 199.76 + Angles.Deg2Radian * (31436.921 * julianCentury))
                       + 12 * Math.Cos(Angles.Deg2Radian * 95.39 + Angles.Deg2Radian * (14577.848 * julianCentury))
                       + 12 * Math.Cos(Angles.Deg2Radian * 287.11 + Angles.Deg2Radian * (31931.756 * julianCentury))
                       + 12 * Math.Cos(Angles.Deg2Radian * 320.81 + Angles.Deg2Radian * (34777.259 * julianCentury))
                       + 9 * Math.Cos(Angles.Deg2Radian * 227.73 + Angles.Deg2Radian * (1222.114 * julianCentury))
                       + 8 * Math.Cos(Angles.Deg2Radian * 15.45 + Angles.Deg2Radian * (16859.074 * julianCentury));

            return jden + (0.00001 * valueS / lambda);
        }

        /// <summary>
        /// Means the specified year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="season">The season.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Mean(int year, Season season) {
            double y;
            double julianDayE0;
            Debug.WriteLine("Calculating Mean Equinox/Solstice for {0}, {1}", season, year);
            if (year > 3000 || year < -1000) {
                Trace.WriteLine("Year is outside range of accuracy. Expected value between -1000 and +3000; value was " + year, "Equinox");
            }

            if (year >= 1000) {
                y = (year - 2000d) / 1000d;
                julianDayE0 = CalculateJulianDayE0(EquinoxTables.TableB[season], y);
            }
            else {
                y = year / 1000d;
                julianDayE0 = CalculateJulianDayE0(EquinoxTables.TableA[season], y);
            }

            Debug.WriteLine("Y\t= " + y);
            Debug.WriteLine("JulianDayE0\t= " + julianDayE0);
            return julianDayE0;
        }

        /// <summary>
        /// Approximates the specified year.
        /// </summary>
        /// <param name="year">The given year.</param>
        /// <param name="season">The given season.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Approximate(int year, Season season) {
            var julianDayE0 = Mean(year, season);

            Debug.WriteLine("Calculating Approximate Equinox/Solstice for {0}, {1} from JulianDayE0", season, year);

            var julianCentury = (julianDayE0 - 2451545.0) / 36525;
            julianCentury = Math.Round(julianCentury, 9);

            var w = (35999.373 * julianCentury) - 2.47;
            var deltaLambda = 1 + 0.0334 * Math.Cos(w) + 0.0007 * Math.Cos(2 * w); //// Δλ
            double valueS = 0;

            //// S = Σ[A Cos(B + (C * julianCentury))] 
            Array.ForEach(
                    EquinoxTables.TableC, 
                    list => {
                        var s = (List<double>)list;
                        valueS += s[0] * Math.Cos(s[1] + (s[2] * julianCentury));
                    });

            valueS = Math.Floor(valueS);

            var julianDayE = Math.Round(julianDayE0 + ((0.00001 * valueS) / deltaLambda), 5);

            //// Debug information 
            Debug.WriteLine("T\t= " + julianCentury);
            Debug.WriteLine("W\t= " + w);
            Debug.WriteLine("Δλ\t= " + deltaLambda);
            Debug.WriteLine("S\t= " + valueS);
            Debug.WriteLine("JulianDayE\t= " + julianDayE);

            return julianDayE;
        }

        #endregion

        /// <summary>
        /// Calculates the julianDay e0.
        /// </summary>
        /// <param name="series">The series.</param>
        /// <param name="y">The given Y.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double CalculateJulianDayE0(IList<double> series, double y) {
            return Math.Round(series[0] + (series[1] * y) + (series[2] * Math.Pow(y, 2)) + (series[3] * Math.Pow(y, 3)) + (series[4] * Math.Pow(y, 4)), 5);
        }
    }
}
