// <copyright file="RecordMainEnergy.cs" company="Traced-Ideas, Czech republic">
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
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.Systems;
    using System;
    using System.Globalization;

    /// <summary>
    /// Record Main Energy.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordMainEnergy : AbstractRecord
    {
        /// <summary>
        /// The energy j
        /// </summary>
        public OrbitEnergy energyJ = new OrbitEnergy();

        /// <summary>
        /// The energy s
        /// </summary>
        public OrbitEnergy energyS = new OrbitEnergy();

        /// <summary>
        /// Outputs the experiment energy.
        /// </summary>
        public override void OutputRecord()
        {
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Lsp = SolarSystem.Singleton.Saturn.LP;
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;

            this.energyJ.SetOrbit(SolarSystem.Singleton.Jupiter, SolarSystem.Singleton.Sun);
            this.energyS.SetOrbit(SolarSystem.Singleton.Saturn, SolarSystem.Singleton.Sun);

            //// var Ej = 0; ////this.energyJ.Ekin / 1e30;
            //// var Es = 0; //// this.energyS.Ekin / 1e30;

            var Uj = -this.energyJ.Epot / 1e33;
            var Us = -this.energyS.Epot / 1e33;

            ////  this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(this.JulianDate));

            this.Text.AppendFormat(
                CultureInfo.InvariantCulture,
                "{0,4:F0}\t{1,4:F0}\t{2,13:F0} ",
                Ljp,
                Angles.Mod360(Lj - Ljp),
                Uj);

            this.Text.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,4:F0}\t{1,4:F0}\t{2,13:F0}  ",
                Lsp,
                Angles.Mod360(Ls - Lsp),
                Us);

            this.Text.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,13:F0} \n ",
                Uj + Us);

            this.IsFinished = true;
        }

        /// <summary>
        /// Outputs the date diffs js.
        /// </summary>
        private void OutputRecord2()
        {
            this.Text.AppendFormat("{0,8:F2}\t", Math.Round(this.LastDateDiff / this.TimeUnit, 3));
            this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(this.JulianDate));

            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Vj = Orbit.InstantaneousVelocity(SolarSystem.Singleton.Jupiter.Point.RT, SolarSystem.Singleton.Jupiter.A) / SolarSystem.Singleton.Jupiter.Point.RT * 1e18;

            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lsp = SolarSystem.Singleton.Saturn.LP;
            var Vs = Orbit.InstantaneousVelocity(SolarSystem.Singleton.Saturn.Point.RT, SolarSystem.Singleton.Saturn.A) / SolarSystem.Singleton.Saturn.Point.RT * 1e18;

            //// var Lu = SolarSystem.Singleton.Uranus.Longitude;
            this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0}", Lj, Ljp);
            this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0}", Ls, Lsp);
            //// this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} ", Lu);

            var delta = Math.Abs(Vj - Vs * 8 / 3);
            if (delta > 0) {
                this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,7:F2} {1,7:F2} {2,15:F1}", Vj, Vs * 8 / 3, 1000 / delta);
            }
        }
    }
}
