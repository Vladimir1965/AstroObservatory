// <copyright file="RecordEarthSystem.cs" company="Traced-Ideas, Czech republic">
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
    using AstroSharedOrbits.Systems;
    using System;
    using System.Globalization;

    /// <summary>
    /// Record Earth System.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordEarthSystem : AbstractRecord
    {
        /// <summary>
        /// Outputs the earth system.
        /// </summary>
        public override void OutputRecord()
        {
            //// const bool otherPlanets = false; if (otherPlanets) {
            //// SolarSystem.Venus.SetJulianDate(this.JulianDate); SolarSystem.Jupiter.SetJulianDate(this.JulianDate);
            //// }
            var moonDistProc = ((EarthSystem.Moon.Point.RT / EarthSystem.Moon.A) - 1) * 100;
            var earthDistProc = ((EarthSystem.Earth.Point.RT / EarthSystem.Earth.A) - 1) * 100;
            var lunarPhase = Angles.Mod360Sym(EarthSystem.Earth.Longitude - EarthSystem.Moon.Longitude);
            var angleToNode = Angles.Mod180Sym(EarthSystem.Moon.LW - EarthSystem.Moon.Longitude);

            //// if (Math.Abs(angleToEcliptic) < 30 || Math.Abs(angleToEcliptic) > 60) { //// Math.Abs(lunarPhase) < 30) 
            //// if (Math.Abs(angleToEcliptic) >= 30 && Math.Abs(angleToEcliptic) <= 60) { //// Math.Abs(lunarPhase) < 30) 
            //// if (Math.Abs(lunarPhase) <= 45 && Math.Abs(angleToEcliptic) <= 45) {
            //// if (moonDistProc<-5) {
            //// degrees 00B0
            //// double timelgh = AstroMath.Frac(this.JulianDate)*360;
            this.Text.Append(Julian.CalendarDate(this.JulianDate, true) + " ");
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));
            //// this.Text.AppendFormat("{0}\n\r", this.Info);
            this.Text.AppendFormat(" MOON    LGH:{0,7:F2}°        LAT:{1,7:F2}°  DISTANCE: {2,6:F2}%\n\r", EarthSystem.Moon.Longitude, EarthSystem.Moon.Point.Latitude, moonDistProc);
            this.Text.AppendFormat(" EARTH   LGH:{0,7:F2}°        LAT:{1,7:F2}°  DISTANCE: {2,6:F2}%\n\r", EarthSystem.Earth.Longitude, EarthSystem.Earth.Point.Latitude, earthDistProc);
            //// if (otherPlanets) {
            ////     this.Text.AppendFormat(" Venus   LGH:{0,7:F2}°        LAT:{1,7:F2}°\n\r", SolarSystem.Venus.Longitude, SolarSystem.Venus.Latitude);
            ////     this.Text.AppendFormat(" Jupiter LGH:{0,7:F2}°        LAT:{1,7:F2}°\n\r", SolarSystem.Jupiter.Longitude, SolarSystem.Jupiter.Latitude);
            //// }

            this.Text.AppendFormat(" LUNAR PHASE:{0,7:F2}°       NODE:{1,7:F2}°\n\r", lunarPhase, angleToNode);
            //// }
            //// this.Text.AppendFormat(" TIME   LGH:{0,6:F2}   MON:{1,6:F2}\n", timelgh, Angles.Mod360(timelgh - EarthSystem.Moon.Longitude));
            //// this.Text.AppendFormat(" QUAKE  LGH:{0,6:F2}   LAT:{1,6:F2} ", EarthSystem.Moon.Longitude, EarthSystem.Moon.Latitude);

            //// this.Text.AppendFormat(" {0,10}:{1,6:F2}:{2,6:F2}\n", EarthSystem.MoonMeeus.Name, EarthSystem.MoonMeeus.Longitude, EarthSystem.MoonMeeus.Latitude);
            //// this.Text.AppendFormat(" {0,10}:{1,6:F2}:{2,6:F2}\n", EarthSystem.MoonSchlyter.Name, EarthSystem.MoonSchlyter.Longitude, EarthSystem.MoonSchlyter.Latitude);
            //// this.Text.AppendFormat(" {0,10}:{1,6:F2}:{2,6:F2}\n", EarthSystem.MoonChapront.Name, EarthSystem.MoonChapront.Longitude, EarthSystem.MoonChapront.Latitude);
            //// this.Text.AppendFormat(" {0,10}:{1,6:F2}:{2,6:F2}\n", EarthSystem.MoonNaughter.Name, EarthSystem.MoonNaughter.Longitude, EarthSystem.MoonNaughter.Latitude);

            this.IsFinished = true;
        }

        /// <summary>
        /// Outputs the date diffs ve moon.
        /// </summary>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        private void OutputRecord2(double timeUnit, string info, double diff)
        {
            var Lv = SolarSystem.Singleton.Venus.Longitude;
            var Le = SolarSystem.Singleton.Earth.Longitude;
            var Lmoon = EarthSystem.Moon.Longitude;

            //// if (Angles.EqualDeg(Lv, Le, 3) && Angles.EqualDeg(Lv, Lmoon, 3) && Angles.EqualDeg(Le, Lmoon, 3)) {
            if (Angles.EqualDeg(Lv, Le, 0.4)) {
                this.Text.AppendFormat("{0,9:F3}\t", Math.Round(this.LastDateDiff / timeUnit, 3));
                this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
                this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(this.JulianDate));

                this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0} {2,4:F0}", Angles.Mod360(Lv), Angles.Mod360(Le), Angles.Mod360(Lmoon));
                this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0} {2,4:F0}", 0, Angles.Mod360(Lv - Le), Angles.Mod360(Lmoon - Le));
            }
        }
    }
}
