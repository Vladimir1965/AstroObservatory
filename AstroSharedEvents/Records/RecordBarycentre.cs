// <copyright file="RecordBarycentre.cs" company="Traced-Ideas, Czech republic">
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
    using AstroSharedOrbits.Dwarfs;
    using AstroSharedOrbits.Systems;
    using System.Globalization;

    /// <summary>
    /// Record Barycentre.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordBarycentre : AbstractRecord
    {
        /// <summary>
        /// Outputs the oriented bary axis.
        /// </summary>
        public override void OutputRecord()
        {
            /*if (SolarSystem.Singleton.Sun.Point.RT > 0.5 * SolarSystem.Singleton.Sun.Body.Radius)
            ////if (SolarSystem.Singleton.Sun.Point.RT < 1.7 * SolarSystem.Singleton.Sun.Body.Radius)
            {
                    return false;
            }*/
            var M = SolarSystem.Singleton.Mercury;
            var V = SolarSystem.Singleton.Venus;
            var E = SolarSystem.Singleton.Earth;
            var R = SolarSystem.Singleton.Mars;
            var J = SolarSystem.Singleton.Jupiter;
            var S = SolarSystem.Singleton.Saturn;
            var U = SolarSystem.Singleton.Uranus;
            var N = SolarSystem.Singleton.Neptune;
            var X = SolarSystem.Singleton.PlanetX;

            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            //// var Lp = SolarSystem.Singleton.Pluto.Longitude;
            var Lp = BodyPluto.EclipticLongitude(this.JulianDate);
            var Lx = SolarSystem.Singleton.PlanetX.Longitude;

            this.Text.AppendFormat("{0,8:F2} ", Julian.Year(this.JulianDate));
            this.Text.Append(" " + Julian.CalendarDate(this.JulianDate, false));

            var sundiff = Angles.Mod360Sym(SolarSystem.Singleton.Barycentre.Longitude - SolarSystem.Singleton.Gravicentre.Longitude);

            this.Text.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}\t{3,5:F1}",
                                Lj,
                                Ls,
                                Lu,
                                Ln);

            this.Text.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1}\t{1,5:F1}",
                                Lp,
                                Lx);

            this.Text.AppendFormat(
                                    CultureInfo.InvariantCulture,
                                    "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}",
                                    SolarSystem.Singleton.Barycentre.Longitude,
                                    Angles.Mod360(SolarSystem.Singleton.Gravicentre.Longitude),
                                    sundiff);

            this.Text.AppendFormat(
                                "\tB\t{0,8:F2}\t {1,5:F1}\t{2,6:F2}\t{3}",
                                SolarSystem.Singleton.Sun.Point.RT / SolarSystem.Singleton.Sun.Body.Radius,
                                SolarSystem.Singleton.BarycentreBehavior.ActualPeriod,
                                SolarSystem.Singleton.BarycentreBehavior.MeanAngularPeriod,
                                SolarSystem.Singleton.BarycentreBehavior.Retrograde ? "RG" : string.Empty);

            /*
            this.Text.AppendFormat(
                                "\tS\t {0,10:F1}\t{1,10:F1}\t{2,12:F1}",
                                SolarSystem.Singleton.Sun.BarySunBehavior.TotalLgh,
                                SolarSystem.Singleton.Sun.GraviSunBehavior.TotalLgh,
                                SolarSystem.Singleton.Sun.BarySunBehavior.TotalJulianDay / 365.25);
                                        
            this.Text.AppendFormat(
                                "\tG\t {0,5:F1}\t{1,6:F2}\t{2}",
                                SolarSystem.Singleton.GravicentreBehavior.ActualPeriod,
                                SolarSystem.Singleton.GravicentreBehavior.MeanAngularPeriod,
                                SolarSystem.Singleton.GravicentreBehavior.Retrograde ? "RG" : string.Empty);
            */

            this.Text.AppendFormat(
                                "\tV\t{0,10:F1}\t{1,10:F1}",
                                SolarSystem.Singleton.Sun.Point.ActualSpeed / SolarSystem.Singleton.Sun.Body.Radius * 100 * 100,
                                SolarSystem.Singleton.Sun.Point.ActualAcceleration / SolarSystem.Singleton.Sun.Body.Radius * 100 * 100000);
            
            this.IsFinished = true;
        }
    }
}
