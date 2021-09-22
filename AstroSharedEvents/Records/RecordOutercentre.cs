// <copyright file="RecordOutercentre.cs" company="Traced-Ideas, Czech republic">
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
    /// Record Outercentre.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordOutercentre : AbstractRecord
    {
        /// <summary>
        /// Outputs the oriented bary axis.
        /// </summary>
        public override void OutputRecord()
        {
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var Lo = SolarSystem.Singleton.Outercentre.Longitude;
            var Ro = SolarSystem.Singleton.Outercentre.RT / 10000000;

            if (Ro > 75) {
                this.Text.AppendFormat("{0,8:F2}  {1,8:F2}", Math.Round(this.LastDateDiff / this.TimeUnit, 3), Julian.Year(this.JulianDate));
                //// this.Text.AppendFormat("{0,8:F2} ", Julian.Year(this.JulianDate));
                this.Text.Append(" " + Julian.CalendarDate(this.JulianDate, false));

                //// this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,5:F1}", Angles.Mod360Sym(Lj - Lo));

                this.Text.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "\t{0,10:F1}\t{1,5:F1}\t-\t{2,5:F1}\t{3,5:F1}\t{4,5:F1}",
                        Ro,
                        Lo,
                        Ls,
                        Lu,
                        Ln);

                this.IsFinished = true;
            }
        }
    }
}
