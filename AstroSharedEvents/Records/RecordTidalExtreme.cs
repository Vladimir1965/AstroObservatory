// <copyright file="RecordTidalExtreme.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

using AstroSharedClasses.Calendars;
using AstroSharedClasses.Computation;
using AstroSharedOrbits.Systems;
using JetBrains.Annotations;
using System.Globalization;

namespace AstroSharedEvents.Records
{
    /// <summary>
    /// Record Tidal Extreme.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordTidalExtreme : AbstractRecord
    {
        /// <summary>
        /// Outputs the tidal orientation.
        /// </summary>
        [UsedImplicitly]
        public override void OutputRecord()
        {
            /*var M = SolarSystem.Singleton.Mercury;
            var V = SolarSystem.Singleton.Venus;
            var E = SolarSystem.Singleton.Earth;
            var R = SolarSystem.Singleton.Mars;
            var J = SolarSystem.Singleton.Jupiter;
            var S = SolarSystem.Singleton.Saturn;
            var U = SolarSystem.Singleton.Uranus;
            var N = SolarSystem.Singleton.Neptune;
            var X = SolarSystem.Singleton.X;*/

            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Le = SolarSystem.Singleton.Earth.Longitude;
            var Lv = SolarSystem.Singleton.Venus.Longitude;

            this.Text.AppendFormat("{0,8:F2} ", Julian.Year(this.JulianDate));
            this.Text.Append(" " + Julian.CalendarDate(this.JulianDate, false));

            this.Text.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}",
                                Lv,
                                Le,
                                Lj);

            this.Text.AppendFormat(
                                    CultureInfo.InvariantCulture,
                                    "\t{0,5:F1}\t{1,5:F1}",
                                    SolarSystem.Singleton.Barycentre.Longitude,
                                    Angles.Mod360(SolarSystem.Singleton.Gravicentre.Longitude));

            this.Text.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,5:F1}\t{0,8:F2}",
                SolarSystem.Singleton.TidalExtreme.Longitude,
                SolarSystem.Singleton.TidalExtreme.RT);

            this.IsFinished = true;
        }
    }
}
