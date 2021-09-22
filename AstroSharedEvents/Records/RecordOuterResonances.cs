// <copyright file="RecordOuterResonances.cs" company="Traced-Ideas, Czech republic">
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
    using System.Globalization;

    /// <summary>
    /// Record Outer Resonances.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordOuterResonances : AbstractRecord
    {
        /// <summary>
        /// Outputs the experiment outer resonance.
        /// </summary>
        public override void OutputRecord()
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            ////  this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            var y = Julian.Year(this.JulianDate);
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", y);

            //// Kalenda  J-3S+2U-N
            var a1 = Angles.Mod360(Lj - 3 * Ls);
            var a2 = Angles.Mod360(2 * Lu - Ln);
            var a3 = Angles.Mod360(3 * Lu - 3 * Ln);
            var argument12 = Angles.Mod360(a1 + a2);
            var argument13 = Angles.Mod360(a1 + a3);
            var value = Angles.Mod360(360 * (y - 1838.2) / 287.78);

            this.Text.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,4:F0}\t{1,4:F0}\t{2,4:F0}\t{3,4:F0}\t{4,4:F0}\t{5,4:F0}\t{6,4:F0}\t{7,4:F0} ",
                100 * Angles.Sinus(a1),
                100 * Angles.Sinus(a2),
                100 * Angles.Sinus(a3),
                100 * Angles.Sinus(argument12),
                100 * Angles.Sinus(argument13),
                100 * Angles.Sinus(value),
                argument12 - 180,
                Angles.Mod360Sym(argument13 - value));

            this.Text.AppendFormat(CultureInfo.InvariantCulture, "\n ");

            this.IsFinished = true;
        }

        /// <summary>
        /// Outputs the record2.
        /// </summary>
        private void OutputRecord2()
        {
            //// var deltaUN = Angles.Mod360Sym(SolarSystem.Neptune.Longitude - SolarSystem.Uranus.Longitude);
            //// var deltaJS = Angles.Mod360Sym(SolarSystem.Saturn.Longitude - SolarSystem.Jupiter.Longitude);
            //// var rx = Angles.Mod360Sym(deltaUN - deltaJJa);
            //// var sx = Angles.Mod180Sym(deltaUN - deltaJS + 90);    //// 1/J-1/S-1/U+1/N
            //// var x = Angles.Cosin(2 * deltaUN);
            //// var correction = 120 * x * Math.Abs(x)

            var deltaJJp = Angles.Mod360Sym(SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Jupiter.LP);
            var delta2S = Angles.Mod360Sym(2 * SolarSystem.Singleton.Saturn.Longitude);
            var longitudeN = Angles.Mod360Sym(SolarSystem.Singleton.Neptune.Longitude);
            var angle = 3 * (SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Jupiter.LP) 
                        - 8 * SolarSystem.Singleton.Saturn.Longitude - SolarSystem.Singleton.Uranus.Longitude 
                        + 5 * SolarSystem.Singleton.Neptune.Longitude;

            this.Text.AppendFormat(
                    " JJp:{0,4:F0} 2S:{1,4:F0} N:{2,4:F0}   RA:{3,4:F0}     ",
                    deltaJJp,
                    delta2S,
                    longitudeN,
                    Angles.Mod360Sym(angle - 180));
        }
    }
}
