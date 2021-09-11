// <copyright file="DateList.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation
{
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Date List.
    /// </summary>
    public partial class DateList  //// : AstroConfiguration
    {
        #region Fields

        /// <summary>
        /// Last CurrentJulianDate.
        /// </summary>
        public double LastJulianDate;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AstroSharedClasses.Computation.DateList"/> class.
        /// </summary>
        public DateList() {
            this.Date = new List<double>();
            this.List = new StringBuilder();
            this.Info = new List<string>();
            this.LastJulianDate = -10000000;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public List<double> Date { get; set; }

        //// public int Count { get { return this.Count; } set { this.Count=value; } }

        /// <summary>
        /// Gets or sets List.
        /// </summary>
        /// <value>
        /// The list.
        /// </value>
        public StringBuilder List { get; set; }

        /// <summary>
        /// Gets List.
        /// </summary>
        private List<string> Info { get; }

        #endregion

        #region Public methods
        /// <summary>
        /// Add date to list.
        /// </summary>
        /// <param name="date">The given date.</param>
        public void AddDate(double date) {
            this.Date.Add(date);
        }

        /// <summary>
        /// Adds the selected dates.
        /// </summary>
        /// <param name="dates">The dates.</param>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        [UsedImplicitly]
        public void AddSelectedDates(IEnumerable<float> dates, double dateFrom, double dateTo) {
            foreach (var date in dates.Where(date => dateFrom <= date && date <= dateTo)) {
                this.AddDate(Calendars.Julian.JulYear(date));
            }
        }

        /// <summary>
        /// Adds the mayan dates.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <param name="c">The c.</param>
        [UsedImplicitly]
        public void AddMayanDates(IEnumerable<Records.MayanRecord> records, long c) {
            foreach (var r in records) {
                this.AddMayanDate(c, r.Baktun, r.Katun, r.Tun, r.Uinal, r.Kin, r.Info);
            }
        }

        /// <summary>
        /// List of days and their differences.
        /// </summary>
        /// <param name="fromDate">Given date from.</param>
        /// <param name="toDate">Given date to.</param>
        /// <param name="step">The given step in years.</param>
        [UsedImplicitly]
        public void AddDates(double fromDate, double toDate, double step) {
            ////  ALL CYCLES MAX
            for (var t = fromDate; t < toDate; t += step) {
                this.Date.Add(Calendars.Julian.JulYear(t));
            }
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Add Mayan Date.
        /// </summary>
        /// <param name="c">The Mayan longcount.</param>
        /// <param name="baktun">The Mayan baktun.</param>
        /// <param name="katun">The Mayan katun.</param>
        /// <param name="tun">The Mayan tun.</param>
        /// <param name="uinal">The Mayan uinal.</param>
        /// <param name="kin">The Mayan kin.</param>
        /// <param name="info">The info text.</param>
        private void AddMayanDate(long c, int baktun, int katun, int tun, int uinal, int kin, string info) {
            this.Info.Add(info);
            this.AddDate(c + Calendars.Julian.MayanCorrectedDay(baktun, katun, tun, uinal, kin));
        }

        #endregion
    }
}
