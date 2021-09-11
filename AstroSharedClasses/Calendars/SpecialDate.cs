// <copyright file="SpecialDate.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Calendars {
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Special Date.
    /// </summary>
    public class SpecialDate {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialDate" /> class.
        /// </summary>
        public SpecialDate() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialDate"/> class.
        /// </summary>
        /// <param name="givenYear">The given year.</param>
        /// <param name="givenMonth">The given month.</param>
        /// <param name="givenDay">The given day.</param>
        /// <param name="givenGregorianCalendar">The b gregorian calendar.</param>
        public SpecialDate(long givenYear, long givenMonth, double givenDay, bool givenGregorianCalendar) {
            this.Set(givenYear, givenMonth, givenDay, 0, 0, 0, givenGregorianCalendar);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialDate"/> class.
        /// </summary>
        /// <param name="givenYear">The given year.</param>
        /// <param name="givenMonth">The given month.</param>
        /// <param name="givenDay">The given day.</param>
        /// <param name="givenHour">The given hour.</param>
        /// <param name="givenMinute">The given minute.</param>
        /// <param name="givenSecond">The given second.</param>
        /// <param name="givenGregorianCalendar">The b gregorian calendar.</param>
        public SpecialDate(long givenYear, long givenMonth, double givenDay, double givenHour, double givenMinute, double givenSecond, bool givenGregorianCalendar) {
            this.Set(givenYear, givenMonth, givenDay, givenHour, givenMinute, givenSecond, givenGregorianCalendar);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialDate" /> class.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="givenGregorianCalendar">The b gregorian calendar.</param>
        public SpecialDate(double julianDay, bool givenGregorianCalendar) {
            this.Set(julianDay, givenGregorianCalendar);
        }
        #endregion

        /// <summary>
        /// Gets Inner Year.
        /// </summary>
        /// <value>
        /// The property value.
        /// </value>
        public long InnerYear { get; private set; }

        /// <summary>
        /// Gets Inner Month.
        /// </summary>
        /// <value>
        /// The property value.
        /// </value>
        public long InnerMonth { get; private set; }

        /// <summary>
        /// Gets Inner Day.
        /// </summary>
        /// <value>
        /// The property value.
        /// </value>
        public long InnerDay { get; private set; }

        /// <summary>
        /// Gets Inner Hour.
        /// </summary>
        /// <value>
        /// The property value.
        /// </value>
        public long InnerHour { get; private set; }

        /// <summary>
        /// Gets Inner Minute.
        /// </summary>
        /// <value>
        /// The property value.
        /// </value>
        public long InnerMinute { get; private set; }

        /// <summary>
        /// Gets Inner Second.
        /// </summary>
        /// <value>
        /// The property value.
        /// </value>
        public double InnerSecond { get; private set; }

        #region Private properties
        /// <summary>
        /// Gets or sets a value indicating whether is this date in the Gregorian calendar.
        /// </summary>
        /// <value>
        /// <c>True</c> if [M_B gregorian calendar]; otherwise, <c>false</c>.
        /// </value>
        private bool MBGregorianCalendar { get; set; }

        /// <summary>
        /// Gets or sets Julian Day number for this date.
        /// </summary>
        private double MDblJulian { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Sets the specified year.
        /// </summary>
        /// <param name="givenYear">The given year.</param>
        /// <param name="givenMonth">The given month.</param>
        /// <param name="givenDay">The given day.</param>
        /// <param name="givenHour">The given hour.</param>
        /// <param name="givenMinute">The given minute.</param>
        /// <param name="givenSecond">The given second.</param>
        /// <param name="givenGregorianCalendar">The b gregorian calendar.</param>
        public void Set(long givenYear, long givenMonth, double givenDay, double givenHour, double givenMinute, double givenSecond, bool givenGregorianCalendar) {
            var dblDay = givenDay + (givenHour / 24) + (givenMinute / 1440) + (givenSecond / 86400);
            this.Set(Date.DateToJulianDay(givenYear, givenMonth, dblDay, givenGregorianCalendar), givenGregorianCalendar);
        }

        /// <summary>
        /// Sets the specified julianDay.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="givenGregorianCalendar">The given gregorian calendar.</param>
        public void Set(double julianDay, bool givenGregorianCalendar) {
            this.MDblJulian = julianDay;
            this.SetInGregorianCalendar(givenGregorianCalendar);
        }

        /// <summary>
        /// Days the of week.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public DayOfWeek DayOfWeek() {
            return (DayOfWeek)((long)(this.MDblJulian + 1.5) % 7);
        }

        /// <summary>
        /// Leaps this instance.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public bool Leap() {
            return Date.IsLeap(this.Year(), this.MBGregorianCalendar);
        }

        /// <summary>
        /// Minutes this instance.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public long GetMinute() {
            this.Get();
            return this.InnerMinute;
        }

        /// <summary>
        /// Month of this instance.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public long GetMonth() {
            this.Get();
            return this.InnerMonth;
        }

        /// <summary>
        /// Seconds this instance.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public double GetSecond() {
            this.Get();
            return this.InnerSecond;
        }
        #endregion

        /// <summary>
        /// Ins the gregorian calendar.
        /// </summary>
        /// <returns> Returns value. </returns>
        public bool InGregorianCalendar() {
            return this.MBGregorianCalendar;
        }

        /// <summary>
        /// Julian this instance.
        /// </summary>
        /// <returns> Returns value. </returns>
        public double Julian() {
            return this.MDblJulian;
        }

        /// <summary>
        /// Days this instance.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public long GetDay() {
            this.Get();
            return this.InnerDay;
        }

        /// <summary>
        /// Days the of year.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public double DayOfYear() {
            this.Get();
            return Date.DayOfYear(this.MDblJulian, this.InnerYear, Date.AfterPapalReform(this.InnerYear, 1, 1));
        }

        /// <summary>
        /// Days in the month.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public long DaysInMonth() {
            this.Get();
            return Date.DaysInMonth(this.InnerMonth, Date.IsLeap(this.InnerYear, this.MBGregorianCalendar));
        }

        /// <summary>
        /// Days in the year.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public long DaysInYear() {
            this.Get();
            return Date.IsLeap(this.InnerYear, this.MBGregorianCalendar) ? 366 : 365;
        }

        /// <summary>
        /// Fractional year.
        /// </summary>
        /// <returns> Returns value. </returns>
        public double FractionalYear() {
            this.Get();
            long daysInYear = Date.IsLeap(this.InnerYear, this.MBGregorianCalendar) ? 366 : 365;

            return this.InnerYear + ((this.MDblJulian - Date.DateToJulianDay(this.InnerYear, 1, 1, Date.AfterPapalReform(this.InnerYear, 1, 1))) / daysInYear);
        }

        /// <summary>
        /// Gets the specified year.
        /// </summary>
        public void Get() {
            var julianDay = this.MDblJulian + 0.5;
            var f = Computation.AstroMath.Mod(julianDay, out var tempZ);
            var z = (long)tempZ;
            long yearA;

            //// There is a difference here between the Meeus implementation and this one
            //// if (Z >= 2299161)       //// The Meeus implementation automatically assumes the Gregorian Calendar 
            //// came into effect on 15 October 1582 (julianDay: 2299161), while the Date
            //// implementation has a "m_bGregorianCalendar" value to decide if the date
            //// was specified in the Gregorian or Julian  This difference
            //// means in effect that Date fully supports a prophylactic version of the
            //// Julian calendar. This allows you to construct Julian dates after the Papal
            //// reform in 1582. This is useful if you want to construct dates in countries
            //// which did not immediately adapt the Gregorian calendar
            if (this.MBGregorianCalendar) {
                var alpha = Date.IntValue((z - 1867216.25) / 36524.25);
                yearA = z + 1 + alpha - Date.IntValue(Date.IntValue(alpha) / 4.0);
            }
            else {
                yearA = z;
            }

            var b = yearA + 1524;
            var c = Date.IntValue((b - 122.1) / 365.25);
            var d = Date.IntValue(365.25 * c);
            var e = Date.IntValue((b - d) / 30.6001);

            var dblDay = b - d - Date.IntValue(30.6001 * e) + f;
            this.InnerDay = (long)dblDay;

            this.InnerMonth = e < 14 ? e - 1 : e - 13;
            this.InnerYear = this.InnerMonth > 2 ? c - 4716 : c - 4715;

            f = Computation.AstroMath.Mod(dblDay, out tempZ);
            this.InnerHour = Date.IntValue(f * 24);
            this.InnerMinute = Date.IntValue((f - (this.InnerHour / 24.0)) * 1440.0);
            this.InnerSecond = (f - (this.InnerHour / 24.0) - (this.InnerMinute / 1440.0)) * 86400.0;
        }

        /// <summary>
        /// Hours this instance.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public long Hour() {
            this.Get();
            return this.InnerHour;
        }

        #region Private
        /// <summary>
        /// Sets the in gregorian calendar.
        /// </summary>
        /// <param name="givenGregorianCalendar">The b gregorian calendar.</param>
        public void SetInGregorianCalendar(bool givenGregorianCalendar) {
            var bAfterPapalReform = this.MDblJulian >= 2299160.5;
            ////  #if DEBUG  if (givenGregorianCalendar) // We do not allow storage of prophylactic Gregorian dates
            ////  Debug.Assert(bAfterPapalReform);  #endif 
            this.MBGregorianCalendar = givenGregorianCalendar && bAfterPapalReform;
        }

        /// <summary>
        /// Years this instance.
        /// </summary>
        /// <returns> Returns value. </returns>
        private long Year() {
            this.Get();
            return this.InnerYear;
        }

        #endregion
    }
}
