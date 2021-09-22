// <copyright file="RecordPlanetsMiddle.cs" company="Traced-Ideas, Czech republic">
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
    using System.Globalization;

    /// <summary>
    /// Record Planets Middle.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordPlanetsMiddle : AbstractRecord
    {
        /// <summary>
        /// Outputs the date diffs jsve.
        /// </summary>
        [UsedImplicitly]
        public override void OutputRecord()
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lv = SolarSystem.Singleton.Venus.Longitude;
            var Le = SolarSystem.Singleton.Earth.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            var Vj = SolarSystem.Singleton.Jupiter.Body.Mass / Math.Pow(SolarSystem.Singleton.Jupiter.Point.RT, 2) / 1e3;
            var Vs = SolarSystem.Singleton.Saturn.Body.Mass / Math.Pow(SolarSystem.Singleton.Saturn.Point.RT, 2) / 1e3;
            var Vv = SolarSystem.Singleton.Venus.Body.Mass / Math.Pow(SolarSystem.Singleton.Venus.Point.RT, 2) / 1e3;
            var Ve = SolarSystem.Singleton.Earth.Body.Mass / Math.Pow(SolarSystem.Singleton.Earth.Point.RT, 2) / 1e3;
            var Qjs = Math.Abs(Angles.Sinus(Lj - Ls));
            var Qjv = Math.Abs(Angles.Sinus(Lj - Lv));
            var Qsv = Math.Abs(Angles.Sinus(Ls - Lv));
            var Qje = Math.Abs(Angles.Sinus(Lj - Le));
            var Qse = Math.Abs(Angles.Sinus(Ls - Le));
            var Qve = Math.Abs(Angles.Sinus(Lv - Le));

            var Pjs = 50 * Vj * Vs * Qjs;
            var Pjv = Vj * Vv * Qjv;
            var Psv = Vs * Vv * Qsv;
            var Pje = Vj * Ve * Qje;
            var Pse = Vs * Ve * Qse;
            var Pve = Vv * Ve * Qve;
            var value = Pjs + Pjv + Psv + Pje + Pse + Pve;
            if (value > 30) {
                this.Text.AppendFormat("{0,8:F2} ", Julian.Year(this.JulianDate));
                //// this.Text.AppendFormat(CultureInfo.InvariantCulture, "\t{0,5:F1}", Angles.Mod360Sym(Lj - Lo));

                this.Text.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}-\t{3,7:F2}\t{4,7:F2}\t{5,7:F2}-\t{6,7:F2}\t{7,7:F2}\t{8,7:F2}-\t{9,7:F2}",
                        Lj,
                        Ls,
                        Lv,
                        Pjs,
                        Pjv,
                        Psv,
                        Pje,
                        Pse,
                        Pve,
                        value);
            }

            this.IsFinished = true;
        }
    }
}
