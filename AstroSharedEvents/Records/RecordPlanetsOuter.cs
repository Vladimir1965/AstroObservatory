// <copyright file="RecordPlanetsOuter.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Records
{
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Enums;
    using AstroSharedOrbits.Systems;
    using System.Globalization;

    /// <summary>
    /// Record Planets Outer.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordPlanetsOuter : AbstractRecord
    {
        /// <summary>
        /// Outputs the longitudes outer.
        /// </summary>
        public override void OutputRecord()
        {
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));
            for (var k = 0; k < (int)AstPlanet.Count - 1; k++) {
                if (k < (int)AstPlanet.Jupiter || k > (int)AstPlanet.X) {
                    continue;
                }

                var orbitB = SolarSystem.Singleton.Orbit[k];
                this.Text.AppendFormat(" {0,1}:{1,6:F2} ({2,6:F2})", orbitB.Body.Abbreviation, orbitB.Longitude, orbitB.LP);
            }

            this.Text.Append(" " + Julian.CalendarDate(this.JulianDate, false));
   
            this.IsFinished = true;
        }
    }
}
