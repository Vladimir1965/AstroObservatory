// <copyright file="DateListTidalBands.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Lists
{
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using AstroSharedOrbits.Systems;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary> Tidal extension of DateList. </summary>
    public partial class EventList //// Tidal Bands
    {
        /// <summary>
        /// Gets or sets the snapshots.
        /// </summary>
        /// <value>
        /// The snapshots.
        /// </value>
        public List<AngleBands> Snapshots { get; set; }

        /// <summary>
        /// Inserts the snapshot.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        public void InsertSnapshot(double julianDate)
        {
            var abands = new AngleBands(julianDate);
            foreach (var orbit in SolarSystem.Singleton.Orbit)
            {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }

                //// Tides
                double E = orbit.Body.Mass / orbit.Point.RT / orbit.Point.RT / orbit.Point.RT;
                var longitude = Angles.Mod180(orbit.Longitude);
                int lidx = (int)Math.Round(longitude / 15);
                if (lidx == 12)
                {
                    lidx = 0;
                }

                abands.band[(lidx +12 -2) % 12] += E * 1e11 / 16;
                abands.band[(lidx +12 - 1) % 12] += E * 1e11 / 4;
                abands.band[lidx] += E * 1e11;
                abands.band[(lidx + 1) % 12] += E * 1e11 / 4;
                abands.band[(lidx + 2) % 12] += E * 1e11 / 16;
            }

            abands.Recompute();
            this.Snapshots.Add(abands);
        }

        /// <summary>
        /// Passes the dates.
        /// </summary>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public void PassDates()
        {
            this.Snapshots = new List<AngleBands>();

            //// foreach (double julianDate in this.Date) {
            for (var i = 0; i < this.Date.Count; i++)
            {
                var julianDate = this.Date[i];
                SolarSystem.Singleton.SetJulianDate(julianDate);
                EarthSystem.SetJulianDate(julianDate);
                this.InsertSnapshot(julianDate);
            }
        }

        /// <summary>
        /// Outputs the snapshots.
        /// </summary>
        /// <returns>Returns value.</returns>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public string OutputSnapshots()
        {
            /*AngleBands snap1 = null;
            AngleBands snap2 = null;*/

            foreach (var snap in this.Snapshots)
            {
                var julianDate = snap.julianDate;
                SolarSystem.Singleton.SetJulianDate(julianDate);
                EarthSystem.SetJulianDate(julianDate);

                this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
                this.List.Append("\t" + Julian.CalendarDate(julianDate, false));

                var Lm = SolarSystem.Singleton.Mercury.Longitude;
                var Lv = SolarSystem.Singleton.Venus.Longitude;
                var Le = SolarSystem.Singleton.Earth.Longitude;
                var Lj = SolarSystem.Singleton.Jupiter.Longitude;

                this.List.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "\t \t{0,5:F1}\t{1,5:F1}\t{2,5:F1}\t{3,5:F1}\t",
                        Lm,
                        Lv,
                        Le,
                        Lj);

                this.List.AppendFormat(
                                        CultureInfo.InvariantCulture,
                                        "\tBary\t{0,5:F1}\t{1,5:F1}",
                                        Angles.Mod360(SolarSystem.Singleton.Barycentre.Longitude),
                                        Angles.Mod360(SolarSystem.Singleton.Barycentre.RT));

                this.List.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "\tGravi\t{0,5:F1}\t{1,5:F1}",
                        Angles.Mod360(SolarSystem.Singleton.Gravicentre.Longitude),
                        Angles.Mod360(SolarSystem.Singleton.Gravicentre.RT));

                /*
                if (snap1 != null && snap2 != null)
                {
                    var t3 = snap2.Total + snap1.Total + snap.Total;
                    var m3 = snap2.MaxValue + snap1.MaxValue + snap.MaxValue;
                    var it3 = (t3 > 1400) ? "*" : " ";
                    var im3 = (m3 > 2000) ? "*" : " ";
                    this.List.AppendFormat("\t{0,5:F0}\t{1}\t{2,5:F0}\t{3}",  t3, it3, m3, im3);
                }
                else {
                    this.List.AppendFormat("\t{0,5:F0}\t{1}\t{2,5:F0}\t{3}", 0, " ", 0, " ");
                } */

                var it = (snap.Total > 1000) ? "*" : " ";
                var im = (snap.MaxValue > 800) ? "*" : " ";
                this.List.AppendFormat("\t{0,5:F0}\t{1}\t{2,5:F0}\t{3}", snap.Total, it, snap.MaxValue, im);

                for (int i = 0; i < 12; i++)
                {
                    var v = (snap.band[i] > 200 || snap.band[i] < 1) ? snap.band[i] : 1;
                    this.List.AppendFormat("\t {0,4:F0} ", v);
                }

                this.List.Append("\n");
                /*
                snap2 = snap1;
                snap1 = snap;
                */
            }

            return this.List.ToString();
        }
    }
}
