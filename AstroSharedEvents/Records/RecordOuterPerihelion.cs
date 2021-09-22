// <copyright file="RecordOuterPerihelion.cs" company="Traced-Ideas, Czech republic">
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
    using JetBrains.Annotations;
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Record Outer Perihelion.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordOuterPerihelion : AbstractRecord
    {
        /// <summary>
        /// Outputs the date diffs allign.
        /// </summary>
        [UsedImplicitly]
        public override void OutputRecord()
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            this.Text.AppendFormat("{0,8:F2} \t{1,8:F2} \t", Math.Round(this.LastDateDiff / this.TimeUnit, 3), Julian.Year(this.JulianDate));
            this.Text.Append(Julian.CalendarDate(this.JulianDate, false));

            this.Text.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t{0,4:F0} {1,4:F0} {2,4:F0} {3,4:F0}",
                    Lj,
                    Ls,
                    Lu,
                    Ln);
            var Ij = SolarSystem.Singleton.Jupiter.PerihelionIndex;
            var Is = SolarSystem.Singleton.Saturn.PerihelionIndex;
            var Iu = SolarSystem.Singleton.Uranus.PerihelionIndex;
            var In = SolarSystem.Singleton.Neptune.PerihelionIndex;

            this.Text.AppendFormat(
                    CultureInfo.InvariantCulture,
                        "\t{0,7:F3} {1,7:F3} {2,7:F3} {3,7:F3}",
                        Ij,
                        Is,
                        Iu,
                        In);

            this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t {0,7:F4} ", SolarSystem.Singleton.TotalPerihelionIndex);

            this.IsFinished = true;
        }
    }
}
