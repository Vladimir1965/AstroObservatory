// <copyright file="RecordPlanetRadius.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Records
{
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Enums;
    using AstroSharedOrbits.Systems;
    using System.Globalization;

    /// <summary>
    /// Record Planet Radius.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordPlanetRadius : AbstractRecord
    {
        /// <summary>
        /// Outputs the distances.
        /// </summary>
        public override void OutputRecord()
        {
            double dist = 0;
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));
            ////  this.Text.AppendFormat(" {0,1}:{1,9:F6}", SolarSystem.Sun.Abbrev, SolarSystem.Sun.RT/DefOrbit.AstroMath.AstroUnit);
            for (var k = 0; k < (int)AstPlanet.Count; k++) {
                var orbitB = SolarSystem.Singleton.Orbit[k];
                dist = orbitB.Point.RT / AstroMath.AstroUnit;
                this.Text.AppendFormat(
                    dist < 0.01 ? " {0,1}:{1,8:F6}" : dist < 10.0 ? " {0,1}:{1,6:F3}" : " {0,1}:{1,6:F2}",
                    orbitB.Body.Abbreviation,
                    dist);
            }

            this.IsFinished = true;
        }
    }
}
