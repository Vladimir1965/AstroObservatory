// <copyright file="RecordDwarfs.cs" company="Traced-Ideas, Czech republic">
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

    /// <summary>
    /// Record Dwarfs.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordDwarfs : AbstractRecord
    {
        /// <summary>
        /// Outputs the date diffs dwarfs.
        /// </summary>
        [UsedImplicitly]
        public override void OutputRecord()
        {
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            this.Text.AppendFormat("{0,8:F2} \t{1,8:F2} \t", Math.Round(this.LastDateDiff / this.TimeUnit, 3), Julian.Year(this.JulianDate));
            this.Text.Append(Julian.CalendarDate(this.JulianDate, false));

            this.Text.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tUr {0,5:F1}\tNe {1,5:F1}\tEr {2,5:F1}\tHa {3,5:F1}\tMa {4,5:F1}\tOr {5,5:F1}\tQu {6,5:F1}\tSa {7,5:F1}\tSe {8,5:F1}",
                    Lu,
                    Ln,
                    SolarSystem.Singleton.Eris.Longitude,
                    SolarSystem.Singleton.Haumea.Longitude,
                    SolarSystem.Singleton.Makemake.Longitude,
                    SolarSystem.Singleton.Orcus.Longitude,
                    SolarSystem.Singleton.Quaoar.Longitude,
                    SolarSystem.Singleton.Salacia.Longitude,
                    SolarSystem.Singleton.Sedna.Longitude);

            this.IsFinished = true;
        }
    }
}
