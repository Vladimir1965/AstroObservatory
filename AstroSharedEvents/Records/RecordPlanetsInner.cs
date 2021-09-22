// <copyright file="RecordPlanetsInner.cs" company="Traced-Ideas, Czech republic">
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
    /// Record Planets Inner.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordPlanetsInner : AbstractRecord
    {
        /// <summary>
        /// Outputs the longitudes inner.
        /// </summary>
        public override void OutputRecord()
        {
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));
            for (var k = 0; k < (int)AstPlanet.Count; k++) {
                if (k < (int)AstPlanet.Mercury || k > (int)AstPlanet.Mars) {
                    continue;
                }

                var orbitB = SolarSystem.Singleton.Orbit[k];
                this.Text.AppendFormat(" {0,1}:{1,6:F2}", orbitB.Body.Abbreviation, orbitB.Longitude);
            }

            this.Text.Append(" " + Julian.CalendarDate(this.JulianDate, false));

            this.IsFinished = true;
        }

        /// <summary>
        /// Outputs the longitudes to excel.
        /// </summary>
        private void OutputRecord2()
        {
            this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(this.JulianDate));
            for (var k = 0; k < (int)AstPlanet.Count - 1; k++) {
                if (k < (int)AstPlanet.Mercury || k > (int)AstPlanet.Neptune) {
                    continue;
                }

                var orbitB = SolarSystem.Singleton.Orbit[k];
                this.Text.AppendFormat("{0,4:F0}\t", orbitB.Longitude);
            }

            for (var k = 0; k < (int)AstPlanet.Count - 1; k++) {
                if (k < (int)AstPlanet.Mercury || k > (int)AstPlanet.Neptune) {
                    continue;
                }

                var orbitB = SolarSystem.Singleton.Orbit[k];
                this.Text.AppendFormat("{0,4:F0}\t", orbitB.LP);
            }

            //// double m = SolarSystem.Mercury.Longitude;
            var v = SolarSystem.Singleton.Venus.Longitude;
            var e = SolarSystem.Singleton.Earth.Longitude;
            //// double r = SolarSystem.Mars.Longitude; 

            var j = SolarSystem.Singleton.Jupiter.Longitude;
            //// double s = SolarSystem.Saturn.Longitude;
            var u = SolarSystem.Singleton.Uranus.Longitude;
            var n = SolarSystem.Singleton.Neptune.Longitude;

            var jp = SolarSystem.Singleton.Jupiter.LP;

            var jjp = Angles.Mod360(j - jp);
            var un = Angles.Mod360(u - n);
            var ve = Angles.Mod360(3 * v - 3 * e);
            var je = Angles.Mod360(2 * j - 2 * e);
            var ro = Angles.Mod360(jjp + un);
            var ri = Angles.Mod360(ve + je);

            this.Text.AppendFormat("{0,4:F0}\t", jjp);
            this.Text.AppendFormat("{0,4:F0}\t", un);
            this.Text.AppendFormat("{0,4:F0}\t", ve);
            this.Text.AppendFormat("{0,4:F0}\t", je);

            this.Text.AppendFormat("{0,4:F0}\t", ri);
            this.Text.AppendFormat("{0}\t", Angles.EqualDeg180(ri, 0, 10) ? "MAX" : (Angles.EqualDeg180(ri, 90, 10) ? "MIN" : string.Empty));

            this.Text.AppendFormat("{0,4:F0}\t", ro);
            this.Text.AppendFormat("{0}\t", Angles.EqualDeg(ro, 180, 10) ? "MAX" : (Angles.EqualDeg(ro, 0, 10) ? "MIN" : string.Empty));
        }
    }
}
