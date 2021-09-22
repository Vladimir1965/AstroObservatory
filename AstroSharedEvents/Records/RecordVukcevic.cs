// <copyright file="RecordVukcevic.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

using AstroSharedClasses.Calendars;
using AstroSharedClasses.Computation;
using AstroSharedOrbits.Systems;
using JetBrains.Annotations;
using System;

namespace AstroSharedEvents.Records
{
    /// <summary>
    /// Record Vukcevic.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordVukcevic : AbstractRecord
    {
        /// <summary>
        /// Outputs the date diffs vuckevic.
        /// </summary>
        [UsedImplicitly]
        public override void OutputRecord()
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;

            //// var v1 = (t - 1937.4) / 19.859;
            var v1 = Angles.Mod360(Lj - Ls + 90);

            //// var v2 = (t - 1934.1) / 23.724;
            //// var p2 = Angles.Mod360Sym(Lj - Ljp -180);
            var v2 = Angles.Mod180Sym((Lj - Ljp - 180) / 2);
            var t2 = Julian.Year(this.JulianDate);
            var cs2 = Angles.Cosin(360 * (t2 - 1934.1) / 23.724);
            var c1 = Angles.Cosin(v1);
            var c2 = cs2; //// Angles.Cosin(v2)*s2;
                          //// var c2 = Math.Abs(2 * Angles.Sinus(v2)) - 1;
                          //// if (Math.Abs(c1 + c2)>0.5)
            {
                //// this.Text.AppendFormat("{0,8:F2} ", Julian.Year(this.JulianDate));
                //// this.Text.AppendFormat("({0,7:F2} , {1,7:F2}) =>  {2,7:F2} ... {3,7:F2} ", c1, c2, c1 + c2, Math.Abs(c1 + c2));
                this.Text.AppendFormat("{0,7:F2}\t{1,7:F2}\t{2,7:F2}\t{3,7:F2}", c1, c2, c1 + c2, Math.Abs(c1 + c2));
            }

            this.IsFinished = true;
        }
    }
}
