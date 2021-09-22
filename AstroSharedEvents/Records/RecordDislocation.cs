// <copyright file="RecordDislocation.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Records
{
    using AstroSharedClasses.Calendars;
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.Systems;
    using System;
    using System.Globalization;

    /// <summary>
    /// Record Dislocation.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordDislocation : AbstractRecord
    {
        /// <summary>
        /// Outputs the date diffs un.
        /// </summary>
        public override void OutputRecord()
        {
            this.Text.AppendFormat("{0,8:F2}\t", Math.Round(this.LastDateDiff / this.TimeUnit, 3));
            this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(this.JulianDate));

            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Lup = SolarSystem.Singleton.Uranus.LP;
            var Vu = Orbit.InstantaneousVelocity(SolarSystem.Singleton.Uranus.Point.RT, SolarSystem.Singleton.Uranus.A) / SolarSystem.Singleton.Uranus.Point.RT * 1e18;

            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var Lnp = SolarSystem.Singleton.Neptune.LP;
            var Vn = Orbit.InstantaneousVelocity(SolarSystem.Singleton.Neptune.Point.RT, SolarSystem.Singleton.Neptune.A) / SolarSystem.Singleton.Neptune.Point.RT * 1e18;

            //// var Lu = SolarSystem.Singleton.Uranus.Longitude;
            this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0}", Lu, Lup);
            this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0}", Ln, Lnp);
            //// this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} ", Lu);

            var delta = Math.Abs(Vu - Vn * 2);
            if (delta > 0) {
                this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,7:F2} {1,7:F2} {2,15:F1}", Vu, Vn * 2, 1000 / delta);
            }

            this.IsFinished = true;
        }
    }
}
