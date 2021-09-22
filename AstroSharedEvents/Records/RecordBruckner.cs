// <copyright file="RecordBruckner.cs" company="Traced-Ideas, Czech republic">
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
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Record Bruckner.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordBruckner : AbstractRecord
    {
        /// <summary>
        /// The last v
        /// </summary>
        private double lastV = 0;

        /// <summary>
        /// The last v2
        /// </summary>
        private double lastV2 = 0;

        /// <summary>
        /// The last v3
        /// </summary>
        private double lastV3 = 0;

        /// <summary>
        /// The last v4
        /// </summary>
        private double lastV4 = 0;

        /// <summary>
        /// Outputs the date diffs optim bruckner.
        /// </summary>
        [UsedImplicitly]
        public override void OutputRecord()
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var LPj = SolarSystem.Singleton.Jupiter.LP;
            //// var V = ((Lj - LPj) / 3) - (Ls - Lu + Ln + 90);
            var A = (Lj - LPj) - (Ls - Lu + Ln + 90) * 3;
            var V = Angles.Mod360Sym(A);
            bool isminmax = Math.Sign(V - this.lastV) == Math.Sign(this.lastV - this.lastV2)
                        && Math.Sign(this.lastV2 - this.lastV3) == Math.Sign(this.lastV3 - this.lastV4)
                        && Math.Sign(V - this.lastV) != Math.Sign(this.lastV2 - this.lastV3);

            bool iszerominus = V <= 0.0 && this.lastV > 0 && this.lastV > V && this.lastV2 > this.lastV && this.lastV3 > this.lastV2;
            bool iszeroplus = V >= 0.0 && this.lastV < 0 && this.lastV < V && this.lastV2 < this.lastV && this.lastV3 < this.lastV2;

            if (isminmax || iszerominus || iszeroplus) {
                //// var x = Math.Round(diff / timeUnit * 365.25);
                //// if (x>250 && x<270) {
                this.Text.AppendFormat("{0,8:F2}  {1,8:F2}", Math.Round(this.LastDateDiff / this.TimeUnit, 3), Julian.Year(this.JulianDate));
                //// this.Text.AppendFormat("{0,8:F2} ", Julian.Year(this.JulianDate));
                this.Text.Append(" " + Julian.CalendarDate(this.JulianDate, false));
                this.Text.AppendFormat("\t{0,10:F5}", -V);
            }

            this.lastV4 = this.lastV3;
            this.lastV3 = this.lastV2;
            this.lastV2 = this.lastV;
            this.lastV = V;

            this.IsFinished = true;
        }
    }
}
