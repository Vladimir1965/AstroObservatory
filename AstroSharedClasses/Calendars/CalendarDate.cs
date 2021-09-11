// <copyright file="CalendarDate.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Calendars {
    using JetBrains.Annotations;

    /// <summary>
    /// Calendar Date.
    /// </summary>
    public sealed class CalendarDate {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public long Year; ////  { get; set; }

        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>The month.</value>
        public long Month; ////  { get; set; }

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>The day.</value>
        public long Day; //// { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarDate" /> class.
        /// </summary>
        public CalendarDate() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarDate" /> class.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        [UsedImplicitly]
        public CalendarDate(long year, long month, long day) {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarDate" /> class.
        /// </summary>
        /// <param name="original">The original.</param>
        public CalendarDate(CalendarDate original) {
            this.Year = original.Year;
            this.Month = original.Month;
            this.Day = original.Day;
        }
    }
}
