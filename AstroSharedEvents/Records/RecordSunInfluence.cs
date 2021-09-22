// <copyright file="RecordSunInfluence.cs" company="Traced-Ideas, Czech republic">
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
    using System.Globalization;

    /// <summary>
    /// Record Sun Influence.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordSunInfluence : AbstractRecord
    {
        /// <summary>
        /// Outputs the sun influences.
        /// </summary>
        public override void OutputRecord()
        {
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));
            this.Text.AppendFormat(
                            CultureInfo.InvariantCulture,
                            " I:{0,6:F2} B:{1,6:F2} J:{2,6:F2} v:{3,10:F3} ",
                            SolarSystem.Singleton.Sun.InfluenceLgh,
                            Angles.Mod360(SolarSystem.Singleton.Sun.Longitude + 180),
                            SolarSystem.Singleton.Jupiter.Longitude,
                            SolarSystem.Singleton.Sun.InfluenceValue); //// -3000
            this.Text.AppendFormat(
                            " Phi:{0,6:F2} V:({1,10:F3},{2,10:F3}) ",
                            SolarSystem.Singleton.Sun.InfluencePhi,
                            SolarSystem.Singleton.Sun.InfluenceRadial,
                            SolarSystem.Singleton.Sun.InfluenceTangential);

            this.IsFinished = true;
        }

        /// <summary>
        /// Appends the jsun axes.
        /// </summary>
        [UsedImplicitly]
        private void OutputRecord2()
        {
            var js = Angles.Mod360Sym(SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Saturn.Longitude);
            var nu = Angles.Mod360Sym(SolarSystem.Singleton.Neptune.Longitude - SolarSystem.Singleton.Uranus.Longitude);

            this.Text.AppendFormat(" J-S:{0,4:F0} N-U:{1,4:F0}  ", js, nu);
        }
    }
}
