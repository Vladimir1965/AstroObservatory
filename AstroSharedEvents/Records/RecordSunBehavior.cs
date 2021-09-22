// <copyright file="RecordSunBehavior.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Records
{
    using AstroSharedClasses.Calendars;
    using AstroSharedOrbits.Systems;
    using System.Globalization;

    /// <summary>
    /// Record Sun Behavior.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordSunBehavior : AbstractRecord
    {
        /// <summary>
        /// Outputs the longitudes sun.
        /// </summary>
        public override void OutputRecord()
        {
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));
            this.Text.AppendFormat(CultureInfo.CurrentCulture, " Longitude:{0,6:F2}", SolarSystem.Singleton.Sun.Longitude);
            var dist = SolarSystem.Singleton.Sun.Point.RT / SolarSystem.Singleton.Sun.Body.Radius;
            this.Text.AppendFormat(CultureInfo.CurrentCulture, " R:{0,8:F6}", dist);
            this.Text.AppendFormat(
                                    " v:{0,6:F1} W:{1,6:F1} ",
                                    SolarSystem.Singleton.Sun.Point.ActualSpeed / 10000,
                                    SolarSystem.Singleton.Sun.Point.ActualAcceleration);
            /*
            this.Text.AppendFormat(
                                    " Tactual:{0,6:F1} Tmean:{1,6:F1} {2} ",
                                    SolarSystem.Singleton.BarycentreBehavior.ActualPeriod,
                                    SolarSystem.Singleton.BarycentreBehavior.MeanAngularPeriod,
                                    SolarSystem.Singleton.BarycentreBehavior.Retrograde ? "Retrograde" : string.Empty);
            */
            ////  this.Text.AppendFormat(" {0,8:F6}", dist*Math.Cos(SolarSystem.SunX.projPhi) );
            ////  this.Text.AppendFormat(" {0,1}:{1,6:F2}", SolarSystem.Sun.Abbrev, SolarSystem.Sun.Longitude);
            ////  this.Text.AppendFormat(" {0,1}:{1,6:F2}", SolarSystem.Jupiter.Abbrev, SolarSystem.Jupiter.Longitude);

            this.IsFinished = true;
        }
    }
}
