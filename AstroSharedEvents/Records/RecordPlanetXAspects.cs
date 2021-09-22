// <copyright file="RecordPlanetXAspects.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Records
{
    using AstroSharedClasses.Calendars;
    using AstroSharedEvents.Crossing;
    using AstroSharedOrbits.Systems;
    using System.Globalization;

    /// <summary>
    /// Record Planet X Aspects.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordPlanetXAspects : AbstractRecord
    {
        /// <summary>
        /// Outputs the aspects x.
        /// </summary>
        public override void OutputRecord()
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var Lx = SolarSystem.Singleton.PlanetX.Longitude;

            ////  this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            var y = Julian.Year(this.JulianDate);
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", y);

            this.Text.AppendFormat("{0,4:F0}\t", Lj);
            this.Text.AppendFormat("{0,4:F0}\t", Ls);
            this.Text.AppendFormat("{0,4:F0}\t", Lu);
            this.Text.AppendFormat("{0,4:F0}\t", Ln);
            this.Text.AppendFormat("{0,4:F0}\t", Lx);

            this.Text.Append(Constellation.IsConjunction(Lj, Lx, 10) ? " JX," : string.Empty);
            this.Text.Append(Constellation.IsConjunction(Ls, Lx, 10) ? " SX," : string.Empty);
            this.Text.Append(Constellation.IsConjunction(Lu, Lx, 10) ? " UX," : string.Empty);
            this.Text.Append(Constellation.IsConjunction(Ln, Lx, 10) ? " NX," : string.Empty);

            this.Text.Append(Constellation.IsOpposition(Lj, Lx, 10) ? " J-X," : string.Empty);
            this.Text.Append(Constellation.IsOpposition(Ls, Lx, 10) ? " S-X," : string.Empty);
            this.Text.Append(Constellation.IsOpposition(Lu, Lx, 10) ? " U-X," : string.Empty);
            this.Text.Append(Constellation.IsOpposition(Ln, Lx, 10) ? " N-X," : string.Empty);

            this.IsFinished = true;
        }
    }
}
