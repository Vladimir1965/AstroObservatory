// <copyright file="Julian.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Calendars {
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
    using AstroSharedClasses.Enums;
    using JetBrains.Annotations;

    /// <summary>
    /// Julian library.
    /// </summary>
    public static class Julian {
        #region Fields
        /// <summary>
        /// Tropical Year.
        /// </summary>
        public const double TropicalYear = 365.2422f;

        /// <summary>
        /// Julian Year.
        /// </summary>
        public const double JulianYear = 365.25;

        /// <summary>
        /// Mayan Tzolkin.
        /// </summary>
        public const double Tzolkin = 260.0; //// 259.9787593 // 260.0

        /// <summary>
        /// Month Abbreviations.
        /// </summary>
        private static readonly string[] MonthAbbrev = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        #endregion

        #region Simple conversions
        /// <summary>
        /// Year - start 1.1. of year 1 BeforeCriste  (astronomical year 0).
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double Year(double givenJulianDay) {
            return (givenJulianDay - 1721057.5) / TropicalYear;
        }

        /// <summary>
        /// Days the fraction.
        /// </summary>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        /// <returns> Returns value. </returns>
        public static double DayFraction(double hour, double minute, double second) {
            return ((((second / 60) + minute) / 60) + hour) / 24;
        }

        /// <summary>
        /// Julian Year.
        /// </summary>
        /// <param name="tropicalYear">A given tropical year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double JulYear(double tropicalYear) {
            return 1721057.5 + (tropicalYear * TropicalYear);
        }
        #endregion

        #region Calendar dates
        /// <summary>
        /// Downey's algorithm.
        /// </summary>
        /// <param name="day">The given day.</param>
        /// <param name="month">The given month.</param>
        /// <param name="year">The given year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double JulianDay(double day, int month, int year) {
            int b;
            var m = month;
            //// vla; Downey uses BeforeCriste convention  y = (year < 0) ? year + 1 : year;
            var y = year;
            if (month < 3) {
                m += 12;
                y -= 1;
            }

            if ((year < 1582) || (year == 1582 && (month < 10 || (month == 10 && day < 15)))) {
                b = 0;
            }
            else {
                var a = y / 100;
                b = 2 - a + (a / 4);
            }

            var c = y < 0 ? (long)((365.25 * y) - 0.75) - 694025L : (long)(365.25 * y) - 694025L;

            var d = (int)(30.6001 * (m + 1));
            var julianDate = b + c + d + day - 0.5 + 2415020.0;
            return julianDate;
        }

        /// <summary>
        /// Calendar Date.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        /// <param name="hoursNeeded">The hours needed.</param>
        /// <returns>Returns value.</returns>
        public static string CalendarDate(double givenJulianDay, bool hoursNeeded) {
            var s = new StringBuilder(string.Empty);
            string era;
            CalendarNum(givenJulianDay, out var day, out var month, out var year);
            if (year < 0) {
                year = -year;
                era = "BC";
            }
            else {
                era = "AD";
            }
            //// print(aFile, "%3.1f %2d %4d %2s", day, month, year, era);
            //// print(aFile, "%2.0f %2d %4d %2s", day, month, year, era);
            if (hoursNeeded) {
                var iday = (int)Math.Floor(day);
                var hour = (day - iday) * 24;
                var ihour = (int)Math.Floor(hour);
                var minute = (hour - ihour) * 60;
                var iminut = (int)Math.Floor(minute);
                var second = (minute - iminut) * 60;
                var isecond = (int)Math.Floor(second);

                s.AppendFormat(CultureInfo.InvariantCulture, "{0,4} {1,3} {2,2} {3,2}:{4,2}:{5,2} {6,2}", year, MonthAbbrev[month - 1], Math.Floor(day), ihour, iminut, isecond, era);
            }
            else {
                s.AppendFormat(CultureInfo.InvariantCulture, "{0,4} {1,3} {2,2} {3,2}", year, MonthAbbrev[month - 1], Math.Floor(day), era);
            }
            ////  print(aFile, "%4d %3s %2.0f %2dh %2s", );
            ////  print(aFile, "%4d %3s %2.0f %2s", year, MonthAbbrev[month-1], floor(day), era);
            return s.ToString();
        }

        /// <summary>
        /// Gregorian Day Of Week.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static int GregorianDayOfWeek(double givenJulianDay) {
            //// cal_mjd() uses Gregorian dates on or after Oct 15, 1582.
            //// (Pope Gregory XIII dropped 10 days, Oct 5..14, and improved the leap-
            //// year algorithm). however, Great Britian and the colonies did not
            //// adopt it until Sept 14, 1752 (they dropped 11 days, Sept 3-13,
            //// due to additional accumulated error). leap years before 1752 thus
            //// can not easily be accounted for from the cal_mjd() number...
            int dow;
            givenJulianDay = givenJulianDay + 0.5 - 2415020.0; // vla
            if (givenJulianDay < -53798.5) {
                ////  pre sept 14, 1752 too hard to correct
                dow = -1;
                return dow;
            }

            dow = (int)((long)Math.Floor(givenJulianDay - .5) + 1) % 7;  // 1/1/1900 (mjd 0.5) is a Monday
            if (dow < 0) {
                dow += 7;
            }

            return dow;
        }

        /// <summary>
        /// Before Criste.
        /// </summary>
        /// <param name="year">The given year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double BeforeCriste(double year) {
            return 1 - year;
        }

        #endregion

        #region Mayans
        /// <summary>
        /// Mayan Day.
        /// </summary>
        /// <param name="baktun">The Mayan baktun number.</param>
        /// <param name="katun">The Mayan katun number.</param>
        /// <param name="tun">The Mayan tun number.</param>
        /// <param name="uinal">The Mayan uinal number.</param>
        /// <param name="kin">The Mayan kin number.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static long MayanDay(int baktun, int katun, int tun, int uinal, int kin) {
            long d;
            checked {
                long k = (baktun * 20) + katun;
                d = (((((k * 20) + tun) * 18) + uinal) * 20) + kin;
            }

            return d;
        }

        /// <summary>
        /// Mayan Corrected Day.
        /// </summary>
        /// <param name="baktun">The Mayan baktun.</param>
        /// <param name="katun">The Mayan katun.</param>
        /// <param name="tun">The Mayan tun.</param>
        /// <param name="uinal">The Mayan uinal.</param>
        /// <param name="kin">The Mayan kin.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double MayanCorrectedDay(int baktun, int katun, int tun, int uinal, int kin) {
            long d;
            checked {
                long k = (baktun * 20) + katun;
                d = (((((k * 20) + tun) * 18) + uinal) * 20) + kin;
            }

            return d / 260.0 * Tzolkin;
        }

        /// <summary>
        /// Mayan Date To String.
        /// </summary>
        /// <param name="longcountNumber">The longcount number.</param>
        /// <param name="givenJulianDay">The given julianDay.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static string MayanDateToString(long longcountNumber, double givenJulianDay) {
            var mayanDay = givenJulianDay - longcountNumber;
            mayanDay = (long) Math.Floor(((mayanDay / Tzolkin) * 260.0) + 0.5);
            var kin = (int)(mayanDay % 20);
            mayanDay = mayanDay / 20;
            var uinal = (int)(mayanDay % 18);
            mayanDay = mayanDay / 18;
            var tun = (int)(mayanDay % 20);
            mayanDay = mayanDay / 20;
            var katun = (int)(mayanDay % 20);
            mayanDay = mayanDay / 20;
            var baktun = (int)(mayanDay % 20);
            return string.Format(CultureInfo.InvariantCulture, "{0,2}.{1,2}.{2,2}.{3,2}.{4,2} {5,8}", baktun, katun, tun, uinal, kin, mayanDay);
            //// printf("%2d.%2d.%2d.%2d.%2d (%7.0f)\n", baktun, katun, tun, uinal, kin, m_day);
        }
        #endregion

        #region Public static
        /// <summary>Converts a fractional Julian Day to a .NET DateTime.</summary>
        /// <param name="julianDay">Fractional Julian Day to convert.</param>
        /// <returns>Date and Time in .NET DateTime format.</returns>
        public static DateTime Julian2Date(double julianDay) {
            double a;
            int month, year;
            var jday = julianDay + 0.5;
            var z = Math.Floor(jday);
            var f = jday - z;
            const double tolerance = 0.00001;

            if (z >= 2299161) {
                var alpha = Math.Floor((z - 1867216.25) / 36524.25);
                a = z + 1 + alpha - Math.Floor(alpha / 4);
            }
            else {
                a = z;
            }

            var b = a + 1524;
            var c = Math.Floor((b - 122.1) / 365.25);
            var d = Math.Floor(365.25 * c);
            var e = Math.Floor((b - d) / 30.6001);
            var day = b - d - Math.Floor(30.6001 * e) + f;

            if (e < 14) {
                month = (int)(e - 1.0);
            }
            else if (Math.Abs(e - 14) < tolerance || Math.Abs(e - 15) < tolerance) {
                month = (int)(e - 13.0);
            }
            else {
                throw new InvalidOperationException("Illegal month calculated.");
            }

            if (month > 2) {
                year = (int)(c - 4716.0);
            }
            else if (month == 1 || month == 2) {
                year = (int)(c - 4715.0);
            }
            else {
                throw new InvalidOperationException("Illegal year calculated.");
            }

            var span = TimeSpan.FromDays(day);
            //// VL, 1.4.2014
            if (year == 1500 && month == 2 && day > 29) {
                day = day - 1;
            }

            return new DateTime(
                            year,
                            month,
                            (int)day,
                            span.Hours,
                            span.Minutes,
                            span.Seconds,
                            span.Milliseconds,
                            new GregorianCalendar(),
                            DateTimeKind.Utc);
        }

        /// <summary>Calculates the Julian Day from a DateTime object.</summary>
        /// <param name="d">DateTime object from which to calculate a Julian Day.</param>
        /// <returns>A fractional Julian Day value.</returns>
        /// <remarks>Tested against pg 61 input data.</remarks>
        public static double Date2Julian(DateTime d) {
            double b;
            var theMonth = d.Month;
            var theYear = d.Year;

            if (d.Month <= 2) {
                --theYear; theMonth += 12;
            }

            var a = Math.Floor(theYear / 100.0);

            if (d.Year < 1582) {
                b = 0;
            }
            else if (d.Year > 1582) {
                b = 2 - a + Math.Floor(a / 4);
            }
            else {
                if (d.Month < 10) {
                    b = 0;
                }
                else if (d.Month > 10) {
                    b = 2 - a + Math.Floor(a / 4);
                }
                else {
                    if (d.Day < 5) {
                        b = 0;
                    }
                    else if (d.Day >= 15) {
                        b = 2 - a + Math.Floor(a / 4);
                    }
                    else {
                        throw new InvalidOperationException("Input day falls between 10/5/1582 and 10/14/1582, which does not exist in the Gregorian Calendar.");
                    }
                } // end middle else
            } // end outer else

            var jd = Math.Floor(365.25 * (theYear + 4716)) + Math.Floor(30.6001 * (theMonth + 1)) + d.Day + b - 1524.5;

            ////  add fractional parts of the day to the Julian Day
            var span = TimeSpan.FromHours(d.Hour) + TimeSpan.FromMinutes(d.Minute) + TimeSpan.FromSeconds(d.Second) + TimeSpan.FromMilliseconds(d.Millisecond);

            return jd + span.TotalDays;
        }

        /// <summary>
        /// Converts a Julian Day number into an Astronomical Date object.
        /// </summary>
        /// <param name="julianDay">A positive Julian Day number.</param>
        /// <returns>An AstroDate object equal to the date of the Julian Day number.</returns>
        [UsedImplicitly]
        public static AstroDate ToDate(double julianDay) {
            int yearA;
            var ad = new AstroDate();

            julianDay = julianDay + 0.5;
            var z = (int)Math.Truncate(julianDay);
            var f = julianDay - z;

            if (z > 2299161) {
                var a = (int)((z - 1867216.25) / 35624.25);
                Debug.WriteLine("a\t= " + a);
                yearA = z + 1 + a - a / 4;
            }
            else {
                yearA = z;
            }

            var b = yearA + 1524;
            var c = (int)((b - 122.1) / 365.25);
            var d = (int)(365.25 * c);
            var e = (int)((b - d) / 30.6001);
            ad.Day = b - d - (int)(30.6001 * e) + f;
            ad.Day = Math.Round(ad.Day, 5);
            ad.Month = e < 14 ? (Month)e - 1 : (Month)e - 13;

            ad.Year = ad.Month == Month.January || ad.Month == Month.February ? c - 4715 : c - 4716;

            Debug.WriteLine("A\t= " + yearA);
            Debug.WriteLine("B\t= " + b);
            Debug.WriteLine("C\t= " + c);
            Debug.WriteLine("D\t= " + d);
            Debug.WriteLine("E\t= " + e);
            Debug.WriteLine("Day\t= " + ad.Day);
            Debug.WriteLine("Month\t= " + ad.Month);
            Debug.WriteLine("Year\t= " + ad.Year);
            return ad;
        }

        /// <summary>
        /// Intervals the specified julianDay1.
        /// </summary>
        /// <param name="jd1">The given julianDay1.</param>
        /// <param name="jd2">The given JulianDay2.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Interval(double jd1, double jd2) {
            return jd2 - jd1;
        }

        /// <summary>
        /// Intervals the specified ad1.
        /// </summary>
        /// <param name="ad1">The given ad1.</param>
        /// <param name="ad2">The given ad2.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Interval(AstroDate ad1, AstroDate ad2) {
            var jd1 = FromDate(ad1.Year, ad1.Month, ad1.Day);
            var jd2 = FromDate(ad2.Year, ad2.Month, ad2.Day);
            return jd2 - jd1;
        }

        /// <summary>
        /// Calculate Julian Centuries.
        /// </summary>
        /// <param name="julianDay">The julian day.</param>
        /// <returns>
        /// Julian Centuries (double) from the Epoch J2000.0 (JulianDaye 2451545.0).
        /// </returns>
        public static double JulianCenturies(double julianDay) {
            return (julianDay - 2451545.0) / 36525.0;
        }

        /// <summary>Returns what day of the week the input Julian Day is.</summary>
        /// <param name="jd">Julian day.</param>
        /// <returns>Day of the week: 0 = Sunday...6 = Saturday.</returns>
        [UsedImplicitly]
        public static int DayOfWeekInt(double jd) {
            return (int)(ZeroHourJulian(jd) + 1.5) % 7;
        }

        /// <summary>
        /// Days the of week.
        /// </summary>
        /// <param name="ad">The ad.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Enums.DayOfWeek DayOfWeek(AstroDate ad) {
            return DayOfWeek(FromDate(ad.Year, ad.Month, ad.Day));
        }

        /// <summary>
        /// Days the of the year.
        /// </summary>
        /// <param name="ad">The ad.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static int DayOfTheYear(AstroDate ad) {
            var k = IsLeepYear(ad.Year) ? 1 : 2;
            var m = (int)ad.Month;
            var d = (int)ad.Day;
            var n = (275 * m) / 9 - k * ((m + 9) / 12) + d - 30;
            Debug.WriteLine("K\t= " + k);
            Debug.WriteLine("M\t= " + m);
            Debug.WriteLine("D\t= " + d);
            Debug.WriteLine("N\t= " + n);
            return n;
        }

        /// <summary>
        /// Downey's algorithm.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        /// <param name="day">The given day.</param>
        /// <param name="month">The given month.</param>
        /// <param name="year">The given year.</param>
        public static void CalendarNum(
                    double givenJulianDay,
                    out double day,
                    out int month,
                    out int year) {
            var d = givenJulianDay + 0.5 - 2415020.0;
            var i = Math.Floor(d);
            var f = d - i;
            const float epsilon = 0.001f;
            if (Math.Abs(f - 1) < epsilon) {
                f = 0;
                i += 1;
            }

            if (i > -115860.0) {
                var a = Math.Floor((i / 36524.25) + .9983573) + 14;
                i += 1 + a - Math.Floor(a / 4.0);
            }

            var b = Math.Floor((i / 365.25) + .802601);
            var ce = i - Math.Floor((365.25 * b) + .750001) + 416;
            var g = Math.Floor(ce / 30.6001);
            day = ce - Math.Floor(30.6001 * g) + f;
            month = g > 13.5 ? (int)(g - 13) : (int)(g - 1);

            year = month < 2.5 ? (int)(b + 1900) : (int)(b + 1899);

            if (year < 1) {
                year -= 1;
            }
        }

        #endregion

        #region Private static
        /// <summary>
        /// Days the of week.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        private static Enums.DayOfWeek DayOfWeek(double julianDay) {
            var d = julianDay - Math.Floor(julianDay);
            var j = d - 0.5;
            julianDay = (julianDay - j) + 1.5;
            return (Enums.DayOfWeek)(julianDay % 7);
        }

        /// <summary>
        /// Determines whether [is leep year] [the specified year].
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns> Returns value. </returns>
        private static bool IsLeepYear(int year) {
            if (year < 1582) { ////Julian Calendar
                return (year % 4) == 0;
            }

            //// Gregorian Calendar
            return (((year % 4) == 0) && ((year % 100) != 0)) || ((year % 400) == 0);
        }

        /// <summary>
        /// Calculates the number of days (and fractions of a day) since the Julian Epoch.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="m">The m.</param>
        /// <param name="d">The d.</param>
        /// <returns>
        /// The number of days since -4712 January 1, 12:00 UT.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Y - CE 1582 October 5-14 are not real dates</exception>
        /// <exception cref="ArgumentOutOfRangeException">CE 1582 October 5-14 are not real dates.</exception>
        private static double FromDate(int y, Month m, double d) {
            int b;

            if (m == Month.January || m == Month.February) {
                y = y - 1; m = m + 12;
            }

            //// First, is this a Julian or Gregorian Date?
            //// Julian Dates are before CE 1582 October 15
            if (y > 1582 || (y == 1582 && m > Month.October) || (y == 1582 && m == Month.October && d >= 15)) {
                var a = y / 100;
                b = 2 - a + (a / 4);
                Debug.WriteLine("A\t= " + a);
            }
            else if (y < 1582 || (y == 1582 && m < Month.October) || (y == 1582 && m == Month.October && d <= 4)) { //// Gregorian dates are after CE 1582 October 4
                b = 0;
            }
            else { //// CE 1582 October 5-14 do not exist, there was a ten day overlay between the Gregorian and Julian calendars
                throw new ArgumentOutOfRangeException(nameof(y), "CE 1582 October 5-14 are not real dates");
            }

            var julianDay = (int)(365.25 * (y + 4716)) + (int)(30.6001 * ((int)m + 1)) + d + b - 1524.5;

            Debug.WriteLine("B\t= " + b);
            Debug.WriteLine("julianDay\t= " + julianDay);
            return julianDay;
        }

        /// <summary>Returns the julianDay value at 0 hour (midnight) of the given input Julian Day.</summary>
        /// <param name="jd">Julian day.</param>
        /// <returns>Julian day at midnight of the input Julian Day.</returns>
        private static double ZeroHourJulian(double jd) {
            return Math.Floor(jd - 0.5) + 0.5;
        }
        #endregion
    }
}
