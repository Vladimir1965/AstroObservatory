// <copyright file="RecordPlanetCentre.cs" company="Traced-Ideas, Czech republic">
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
    /// Record Planet Centre.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordPlanetCentre : AbstractRecord
    {
        /// <summary>
        /// The running total period
        /// </summary>
        public double RunningTotalPeriod;

        /// <summary>
        /// The running number of periods
        /// </summary>
        public int RunningNumberOfPeriods;

        /// <summary>
        /// Outputs the experiment.
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

            var Lp = SolarSystem.Singleton.Planetcentre.Longitude;
            var Rp = SolarSystem.Singleton.Planetcentre.RT;
            var Rps = Rp / AstroMath.AstroUnit;   //// / SolarSystem.Singleton.Sun.Body.Radius;

            //// ϖ = suma(mi.ri2.ωi) / (ṟ2.suma(mi))
            var mass = SolarSystem.Singleton.PlanetMass;
            var omega = SolarSystem.Singleton.MomentSum / Rp / Rp / mass;
            var period = 2 * Math.PI / omega / AstroMath.SecondsInDay / 365.25;

            this.RunningTotalPeriod += period;
            this.RunningNumberOfPeriods++;
            var meanPeriod = this.RunningTotalPeriod / this.RunningNumberOfPeriods;

            if (y > 2195) {
                this.Text.AppendFormat("J{0,4:F0}\tS{1,4:F0}\tU{2,4:F0}\tN{3,4:F0}\tC{4,4:F0}\t", Lj, Ls, Lu, Ln, Lp);
                this.Text.AppendFormat("{0,10:F4}\t", Rps);
                this.Text.AppendFormat("{0,10:F4}\t", period);
                this.Text.AppendFormat("{0,10:F4}", meanPeriod);
            }

            this.IsFinished = true;
        }
    }
}
