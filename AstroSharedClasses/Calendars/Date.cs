// <copyright file="Date.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>
//// PJN / 26-01-2006 1. After a bug report from Ing. Taras Kapuszczak that a round trip of the date 25 January 100 as 
//// specified in the Gregorian calendar to the Julian day number and then back again produces the incorrect date 26 January 100, 
//// I've spent some time looking into the 2 key Meeus Julian Day algorithms. It seems that the algorithms which converts 
//// from a Calendar date to julianDay works ok for prophylactic dates, but the reverse algorithm which converts from a julianDay 
//// to a Calendar date does not.  Since I made the change in behavior to support prophylactic Gregorian dates to address issues
//// with the Moslem calendar (and since then I have discovered further unresolved bugs in the Moslem calendar algorithms 
//// and advised people to check out my AA+ library instead), I am now reverting these changes so that the date algorithms 
//// are now as presented in Meeus's book. This means that dates after 15 October 1582 are assumed to be in the Gregorian 
//// calendar and dates before are assumed to be in the Julian calendar. This change also means that some of the Date class 
//// methods no longer require the now defunct "bool" parameter to specify which calendar the date represents. 
//// As part of the testing for this release verification code has been added to AATest.cpp to test all the dates from julianDay 0 
//// (i.e. 1 January -4712) to a date long in the future. Hopefully    with this verification code, we should have no more reported 
//// issues with the class Date. Again if you would prefer a much more robust and comprehensive Date time class framework, don't forget 
//// to check out the authors DTime+ library. 2. Optimized Date constructor code 3. Provided a static version of DaysInMonth() method
//// 4. Discovered an issue in JulianToGregorian. It seems the algorithm presented in the book to do conversion from the Julian 
//// to Gregorian calendar fails for Julian dates before the  Gregorian calendar reform in 1582. I have sent an email to Jean Meeus 
//// to find out if this is a bug in my code or a deficiency in the algorithm presented. Currently the code will assert in this
//// function if it is called for a date before the Gregorian reform.
//// PJN / 27-01-2007 1. The static version of the Set method has been renamed to DateToJulianDay to avoid any confusion with
//// the other Set methods. Thanks to Ing. Taras Kapuszczak for reporting this issue. 2. The method InGregorianCalendar has now 
//// also been renamed to the more appropriate AfterPapalReform.

namespace AstroSharedClasses.Calendars {
    using System.Diagnostics;
    using JetBrains.Annotations;

    /// <summary>
    /// Date class.
    /// </summary>
    [UsedImplicitly]
    public sealed class Date {
        /// <summary>
        /// Month Length.
        /// </summary>
        private static readonly int[] MonthLength =
        { 
            31, 28, 31, 30, 31, 30,
            31, 31, 30, 31, 30, 31
        };

        #region Public static
        /// <summary>
        /// Days the of year to day and month.
        /// </summary>
        /// <param name="dayOfYear">The day of year.</param>
        /// <param name="bLeap">The b leap.</param>
        /// <param name="dayOfMonth">The day of month.</param>
        /// <param name="month">The month.</param>
        [UsedImplicitly]
        public static void DayOfYearToDayAndMonth(long dayOfYear, bool bLeap, out long dayOfMonth, out long month) {
            long k = bLeap ? 1 : 2;

            month = dayOfYear < 32 ? 1 : IntValue(9 * (k + dayOfYear) / 275.0 + 0.98);

            dayOfMonth = dayOfYear - IntValue((275 * month) / 9.0) + (k * IntValue((month + 9) / 12.0)) + 30;
        }

        /// <summary>
        /// Gregorian to julian.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static CalendarDate GregorianToJulian(long year, long month, long day) {
            var date = new SpecialDate(year, month, day, true);
            date.SetInGregorianCalendar(false);

            var julianDate = new CalendarDate();
            date.Get();

            julianDate.Year = date.InnerYear;
            julianDate.Month = date.InnerMonth;
            julianDate.Day = date.InnerDay;

            return julianDate;
        }

        /// <summary>
        /// Julian to gregorian.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static CalendarDate JulianToGregorian(long year, long month, long day) {
            var date = new SpecialDate(year, month, day, false);
            date.SetInGregorianCalendar(true);

            var gregorianDate = new CalendarDate();
            date.Get();
            gregorianDate.Year = date.InnerYear;
            gregorianDate.Month = date.InnerMonth;
            gregorianDate.Day = date.InnerDay;

            return gregorianDate;
        }

        /// <summary>
        /// After the papal reform.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static bool AfterPapalReform(double julianDay) {
            return julianDay >= 2299160.5;
        }
        #endregion 

        #region Private static
        /// <summary>
        /// After the papal reform.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static bool AfterPapalReform(long year, long month, double day) {
            return (year > 1582) || ((year == 1582) && (month > 10)) || ((year == 1582) && (month == 10) && (day >= 15));
        }

        /// <summary>
        /// Dates to julianDay.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        /// <param name="givenGregorianCalendar">The b gregorian calendar.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double DateToJulianDay(long year, long month, double day, bool givenGregorianCalendar) {
            var y = year;
            var m = month;
            if (m < 3) {
                y = y - 1;
                m = m + 12;
            }

            long b = 0;
            // ReSharper disable once InvertIf
            if (givenGregorianCalendar) {
                var a = IntValue(y / 100.0);
                b = 2 - a + IntValue(a / 4.0);
            }

            return IntValue(365.25 * (y + 4716)) + IntValue(30.6001 * (m + 1)) + day + b - 1524.5;
        }

        /// <summary>
        /// Days the of year.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="year">The year.</param>
        /// <param name="givenGregorianCalendar">The b gregorian calendar.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double DayOfYear(double julianDay, long year, bool givenGregorianCalendar) {
            return julianDay - DateToJulianDay(year, 1, 1, givenGregorianCalendar) + 1;
        }

        /// <summary>
        /// Days in the month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="bLeap">The b leap.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static long DaysInMonth(long month, bool bLeap) {
            //// Validate our parameters
            Debug.Assert(month >= 1 && month <= 12, "Reason of the assert");

            if (bLeap && month == 2) {
                return MonthLength[1] + 1;
            }

            return MonthLength[month - 1];
        }

        /// <summary>
        /// INTs the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static long IntValue(double value) {
            if (value >= 0) {
                return (long)value;
            }

            return (long)(value - 1);
        }

        /// <summary>
        /// Determines whether the specified year is leap.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="givenGregorianCalendar">The b gregorian calendar.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static bool IsLeap(long year, bool givenGregorianCalendar) {
            if (!givenGregorianCalendar) {
                return (year % 4) == 0;
            }

            if ((year % 100) == 0) {
                return (year % 400) == 0;
            }

            return (year % 4) == 0;
        }
        #endregion
    }
}
