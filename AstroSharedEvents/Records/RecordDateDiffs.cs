// <copyright file="RecordDateDiffs.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Records
{
    using AstroSharedClasses.Calendars;
    using AstroSharedOrbits.Systems;
    using System;
    using System.Globalization;

    /// <summary>
    /// Record Date Diffs.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordDateDiffs : AbstractRecord
    {
        /// <summary>
        /// Outputs the date diffs.
        /// </summary>
        public override void OutputRecord()
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Lsp = SolarSystem.Singleton.Saturn.LP;
            var Lup = SolarSystem.Singleton.Uranus.LP;
            var Lnp = SolarSystem.Singleton.Neptune.LP;

            //// if (Math.Abs(delta) < 20) {
            this.Text.AppendFormat("{0,9:F3}\t", Math.Round(this.LastDateDiff / this.TimeUnit, 3));
            this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));

            this.IsFinished = true;
        }
    }
}
