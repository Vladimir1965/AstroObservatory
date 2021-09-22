// <copyright file="RecordZharkova.cs" company="Traced-Ideas, Czech republic">
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
    /// Record Zharkova.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordZharkova : AbstractRecord
    {
        /// <summary>
        /// Outputs the date diffs.
        /// </summary>
        public override void OutputRecord()
        {
            /*
            if (SolarSystem.Singleton.TotalQuadratureIndex < 31.95) {   ////  1.98, 5.99 ,7.991, 4.49, 27, 25, 5.98, 37.5, 35, 30, 11.5
                return;
            }
            if  (SolarSystem.Singleton.TotalAlignmentIndex + SolarSystem.Singleton.TotalQuadratureIndex < 15.00) {   //// 7.991, 4.49, 27, 25, 5.98, 37.5, 35, 30, 11.5
                return;
            } */

            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            //// var Ln = SolarSystem.Singleton.Neptune.Longitude;

            var year = Julian.Year(this.JulianDate);
            /*
            //// this.Text.AppendFormat("{0,8:F2} \t{1,8:F2} \t", Math.Round(diff1 / timeUnit, 3), year);
            this.Text.AppendFormat("\t{0,8:F2} \t", year);
            this.List.Append(Julian.CalendarDate(this.JulianDate, false));
            */

            bool sign = (year > 1631.60 && year < 1643.67) || (year > 1655.32 && year < 1667.39)
                        || (year > 1679.05 && year < 1691.12) || (year > 1702.77 && year < 1714.84)
                        || (year > 1726.49 && year < 1738.56) || (year > 1750.22 && year < 1762.29)
                        || (year > 1773.94 && year < 1786.01) || (year > 1797.67 && year < 1809.74)
                        || (year > 1821.39 && year < 1833.46) || (year > 1845.12 && year < 1857.18)
                        || (year > 1868.84 && year < 1880.91) || (year > 1892.56 && year < 1904.63)
                        || (year > 1916.29 && year < 1928.36) || (year > 1940.01 && year < 1952.08)
                        || (year > 1963.74 && year < 1975.80) || (year > 1987.46 && year < 1999.53)
                        || (year > 2011.18 && year < 2023.25) || (year > 2034.91 && year < 2046.98)
                        || (year > 2058.63 && year < 2070.70);

            var dJS = Angles.Mod360Sym(Lj - Ls);
            var dJU = Angles.Mod360Sym(Lj - Lu + 180);
            var dJa = Angles.Mod360Sym(Lj - Ljp + 180);
            var blackvalue = Angles.Mod360(dJa / 2);
            if (sign) {
                blackvalue = Angles.Mod360(dJa / 2 + 180);
            }

            var cblue = 100 * Angles.Cosin(dJS) / 2 + 50 * Angles.Cosin(dJU) / 2;
            var cblack = 100 * Angles.Cosin(blackvalue);
            var cred = (cblue + cblack) / 2;
            var ctotal = (cblue + cred) * 0.9;
            this.Text.AppendFormat(
                CultureInfo.InvariantCulture,
                "{0,4:F0}\t{1,4:F0}\t{2,4:F0}\t{3,4:F0} ",
                cblue,
                cblack,
                cred,
                ctotal);

            this.IsFinished = true;
        }
    }
}
