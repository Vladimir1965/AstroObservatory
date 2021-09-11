// <copyright file="MoonInfluence.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology { 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
using AstroSharedOrbits.Systems;
using JetBrains.Annotations;

    /// <summary>
    /// Moon Influence.
    /// </summary>
    public sealed class MoonInfluence {
        #region Properties
        /// <summary>
        /// Gets or sets The status list.
        /// </summary>
        /// <value>
        /// The status list.
        /// </value>
        public static List<EarthStatus> StatusList { get; set; }

        /// <summary>
        /// Gets or sets The diagram list.
        /// </summary>
        /// <value>
        /// The diagram list.
        /// </value>
        [UsedImplicitly]
        public static List<Dictionary<string, int>> DiagramList { get; set; }

        //// public int Count { get { return this.Count; } set { this.Count=value; } }

        /// <summary>
        /// Gets or sets the diagram.
        /// </summary>
        /// <value>
        /// The diagram.
        /// </value>
        public Dictionary<string, int> Diagram { get; set; }

        /// <summary>
        /// Gets or sets the extremes.
        /// </summary>
        /// <value>
        /// The extremes.
        /// </value>
        public List<ExtremeInfluence> Extremes { get; [UsedImplicitly] set; }

        /// <summary>
        /// Gets or sets List.
        /// </summary>
        /// <value>
        /// The list.
        /// </value>
        [UsedImplicitly]
        private StringBuilder List { get; set; }

        #endregion

        #region Public static methods
        /// <summary>
        /// Inserts the earth status.
        /// </summary>
        /// <param name="year">The year.</param>
        [UsedImplicitly]
        public static void InsertEarthStatus(int year) {
            //// var list = new List<EarthStatus>; 
            for (var day = 0; day <= 366; day++) { //// 366
                for (var hour = 0; hour < 1; hour++) { //// 24
                    var status = GetEarthStatus(year, day, hour);
                    MoonInfluence.StatusList.Add(status);
                }

                //// dc.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the earth status.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="day">The day.</param>
        /// <param name="hour">The hour.</param>
        /// <returns> Returns value. </returns>
        public static EarthStatus GetEarthStatus(int year, int day, int hour) {
            var dt0 = new DateTime(year, 1, 1, 0, 0, 0);
            var dt1 = dt0.AddDays(day - 1);
            var datetime = dt1.AddHours(hour);

            var tyear = year + (day + hour / 24.0) / Julian.TropicalYear;
            var julianDate = Julian.JulYear(tyear);

            //// double julianDate = Julian.JulianDay(19, 4, 1990);
            //// double julianDate = Julian.JulianDay(13, 10, 1992);
            //// double julianDate = Julian.JulianDay(12, 4, 1992); //// Meeus Sun
            //// double julianDate = Julian.JulianDay(27, 5, 1913); 
            //// double julianDate = Julian.JulianDay(22, 12, 1999); 
            //// double julianDate = Julian.JulianDay(15, 1, 1930); //// Perigee
            //// double julianDate = Julian.JulianDay(2, 3, 1984); /// Apogee

            SystemManager.SetJulianDate(julianDate);

            var status = new EarthStatus {
                Day = day,
                JulianDay = (decimal)julianDate,
                TropicalYear = (decimal)tyear,
                EventTime = datetime,
                EarthLongitude = (decimal)EarthSystem.Earth.Point.Longitude,
                EarthLatitude = (decimal)EarthSystem.Earth.Point.Latitude,
                MoonLongitude = (decimal)EarthSystem.Moon.Point.Longitude,
                MoonLatitude = (decimal)EarthSystem.Moon.Point.Latitude,
                EclipticObliquity = (decimal)EarthSystem.Earth.EclipticObliquity,
                MoonAscension = (decimal)EarthSystem.Moon.RightAscension,
                MoonDeclination = (decimal)EarthSystem.Moon.Declination
            };

            var earthDistRatio = EarthSystem.Earth.Point.RT / EarthSystem.Earth.A;
            var moonDistRatio = EarthSystem.Moon.Point.RT / EarthSystem.Moon.A;
            status.SunEarthDistance = (decimal)earthDistRatio;
            status.EarthMoonDistance = (decimal)moonDistRatio;

            var angleToNode = Angles.Mod360(EarthSystem.Moon.Longitude - EarthSystem.Moon.LW);
            var angleToPericentre = Angles.Mod360(EarthSystem.Moon.Longitude - EarthSystem.Moon.LP);
            status.MoonNode = (decimal)angleToNode;
            status.MoonPericentre = (decimal)angleToPericentre;

            //// double x = EarthSystem.Moon.SunMeanAnomaly;
            status.SunAscension = (decimal)EarthSystem.Earth.SunRightAscension;
            status.SunDeclination = (decimal)EarthSystem.Earth.SunDeclination;

            status.GreenwichLongitude = hour * 15;
            //// double dayLongitude = AstroMath.Frac(julianDate / 24)*360;
            return status;
        }
        #endregion

        #region Public mehods

        /// <summary>
        /// Summations the specified from day.
        /// </summary>
        /// <param name="fromDay">From day.</param>
        /// <param name="toDay">To day.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public List<EarthStatus> Summation(int fromDay, int toDay) {
            this.Diagram = new Dictionary<string, int>();
            var list = (from st in MoonInfluence.StatusList where st.Day >= fromDay && st.Day <= toDay select st).ToList();
            //// int[,] diagram = new int[24, 13];
            list.ForEach(status => {
                var hour = status.EventTime.Hour;
                var moonAscField = (int)Math.Floor(status.MoonAscension / 15);
                //// int moonAscField = (int)Math.Floor(status.MoonLongitude / 15);
                var sunAscField = (int)Math.Floor(status.SunAscension / 15);
                var moonDecField = (int)Math.Floor(Angles.Mod180Sym((double)status.MoonDeclination) / 15);
                //// int moonDecField = (int)Math.Floor(Angles.Mod180Sym((double)status.MoonLatitude) / 15);
                var sunDecField = (int)Math.Floor(Angles.Mod180Sym((double)status.SunDeclination) / 15);
                var moonHour = (moonAscField - hour + 24) % 24;
                var sunHour = (sunAscField - hour + 24) % 24;
                this.AddToDiagram(moonDecField, sunDecField, moonHour, sunHour);
            });

            return list;
        }

        /// <summary>
        /// Lists the diagram extremes.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="minValue">The min value.</param>
        [UsedImplicitly]
        public void ListDiagramExtremes(IEnumerable<EarthStatus> list, int minValue) {
            var lastStatus = list.LastOrDefault();
            foreach (var key in this.Diagram.Keys) {
                var value = this.Diagram[key];
                if (value <= minValue) {
                    continue;
                }

                var extreme = new ExtremeInfluence {
                    Key = key
                };

                var pos = key.IndexOf('#');
                extreme.Longitude = int.Parse(key.Substring(0, pos)) * 15;
                extreme.Latitude = (int.Parse(key.Substring(pos + 1)) - 6) * 15;
                extreme.Value = value;
                if (lastStatus != null) {
                    extreme.EventTime = lastStatus.EventTime;
                }

                this.Extremes.Add(extreme);
            }
        }

        /// <summary>
        /// Generates the diagrams.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public string GenerateDiagrams(int year) {
            this.List = new StringBuilder();
            this.List.Append("<HTML>\n\r");
            this.List.Append("<PRE>\n\r");

            for (int decade = 0; decade <= 36; decade++) {
                int[,] diagram = new int[24, 13];
                var list = this.PrepareDecade(year, decade);

                for (int i = 0; i < list.Count; i++) {
                    double julianDate = list[i];
                    SystemManager.SetJulianDate(julianDate);
                    //// double dayLongitude = AstroMath.Frac(julianDate / 24)*360;
                    int hour = i % 24;
                    double moonDistRatio = Math.Pow(EarthSystem.Moon.Point.RT / EarthSystem.Moon.A, 3);
                    double earthDistRatio = Math.Pow(EarthSystem.Earth.Point.RT / EarthSystem.Earth.A, 2);

                    double moonLongitude = EarthSystem.Moon.RightAscension; //// EarthSystem.Moon.Longitude
                    double moonLattitude = EarthSystem.Moon.Declination;    //// EarthSystem.Moon.Latitude

                    int moonlghfield = (int)Math.Round(moonLongitude / 15);
                    int moonlatfield = (int)Math.Floor(Angles.Mod180(moonLattitude + 90) / 15);

                    int earthLongitudeField = (int)Math.Round(Angles.Mod360(EarthSystem.Earth.Point.Longitude + 180) / 15);
                    int earthLattitudeField = (int)Math.Floor(Angles.Mod180(-EarthSystem.Earth.Point.Latitude + 90) / 15);
                    double angleToNode = Angles.Mod180Sym(EarthSystem.Moon.LW - EarthSystem.Moon.Point.Longitude);

                    int lghm = (moonlghfield + 24 - hour) % 24;
                    int valueMoon = (int)(5.0 / moonDistRatio);
                    if (Math.Abs(angleToNode) < 30) {
                        valueMoon += 10;
                    }

                    if (Math.Abs(angleToNode) < 15) {
                        valueMoon += 10;
                    }

                    diagram[lghm, moonlatfield] += 2 * valueMoon;
                    diagram[lghm, (moonlatfield - 1) % 24] += valueMoon;
                    diagram[lghm, (moonlatfield + 1) % 24] += valueMoon;

                    int lghe = (earthLongitudeField + 24 - hour) % 24;
                    int valueEarth = (int)(5.0 / earthDistRatio);
                    diagram[lghe, earthLattitudeField] += 2 * valueEarth;
                    diagram[lghe, (earthLattitudeField - 1) % 24] += valueEarth;
                    diagram[lghe, (earthLattitudeField + 1) % 24] += valueEarth;
                }

                this.List.AppendFormat("\n");
                this.List.Append(Julian.CalendarDate(list[0], false) + " " + Julian.CalendarDate(list[239], false));
                this.List.AppendFormat(".... (decade {0,3}) \n", decade);
                for (int j = 0; j < 12; j++) {
                    for (int i = 0; i < 24; i++)
                    {
                        int f = (int)Math.Round(diagram[i, j] / 10.0);
                        this.List.AppendFormat(f >= 30 ? "<B>{0,3}</B> " : "{0,3} ", f);
                    }

                    this.List.AppendFormat("\n");
                }
            }

            this.List.Append("</PRE>\n\r");
            this.List.Append("</HTML>\n\r");
            return this.List.ToString();
        }
        #endregion
 
        #region Private mehods
        /// <summary>
        /// Prepares the decade.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="decade">The decade.</param>
        /// <returns> Returns value. </returns>
        private List<double> PrepareDecade(int year, int decade) {
            List<double> list = new List<double>();
            int decadeday = decade * 10;
            for (int i = 0; i <= 9; i++) {
                int day = decadeday + i;
                double tyear = year + day / Julian.TropicalYear;
                double date = Julian.JulYear(tyear);
                for (int hour = 0; hour <= 23; hour++) {
                    double dfrac = Julian.DayFraction(hour, 0, 0);
                    double datetime = date + dfrac;
                    list.Add(datetime);
                }
            }

            return list;
        }

        /// <summary>
        /// Adds to diagram.
        /// </summary>
        /// <param name="moonDecField">The moon dec field.</param>
        /// <param name="sunDecField">The sun dec field.</param>
        /// <param name="moonHour">The moon hour.</param>
        /// <param name="sunHour">The sun hour.</param>
        private void AddToDiagram(int moonDecField, int sunDecField, int moonHour, int sunHour) {
            const int valueMoon = 1;
            const int valueEarth = 1;
            /* double angleToNode = Angles.Mod180Sym((double)status.MoonNode);
            valueMoon = (int)(10.0 / Math.Pow((double)status.EarthMoonDistance, 3));
            if (Math.Abs(angleToNode) < 40) {
                valueMoon += 5;
            }

            if (Math.Abs(angleToNode) < 20) {
                valueMoon += 5;
            }

            valueEarth = (int)(10.0 / Math.Pow((double)status.SunEarthDistance, 2));

            string moonKey0 = string.Format("{0}#{1}", (moonHour - 3) % 24, moonDecField + 6);
            string moonKey1 = string.Format("{0}#{1}", (moonHour - 3) % 24, (moonDecField + 6 - 1) % 12);
            string moonKey2 = string.Format("{0}#{1}", (moonHour - 3) % 24, (moonDecField + 6 + 1) % 12);

            string sunKey0 = string.Format("{0}#{1}", (sunHour - 3) % 24, sunDecField + 6);
            string sunKey1 = string.Format("{0}#{1}", (sunHour - 3) % 24, (sunDecField + 6 - 1) % 12);
            string sunKey2 = string.Format("{0}#{1}", (sunHour - 3) % 24, (sunDecField + 6 + 1) % 12);
            
            string moonKey0 = string.Format("{0}#{1}", moonHour, moonDecField + 6);
            string moonKey1 = string.Format("{0}#{1}", moonHour, (moonDecField + 6 - 1) % 12);
            string moonKey2 = string.Format("{0}#{1}", moonHour, (moonDecField + 6 + 1) % 12);

            string sunKey0 = string.Format("{0}#{1}", sunHour, sunDecField + 6);
            string sunKey1 = string.Format("{0}#{1}", sunHour, (sunDecField + 6 - 1) % 12);
            string sunKey2 = string.Format("{0}#{1}", sunHour, (sunDecField + 6 + 1) % 12);
            */

            var moonKey0 = $"{(moonHour + 12) % 24}#{moonDecField + 6}";
            var moonKey1 = $"{(moonHour + 12) % 24}#{(moonDecField + 6 - 1) % 12}";
            var moonKey2 = $"{(moonHour + 12) % 24}#{(moonDecField + 6 + 1) % 12}";

            var sunKey0 = $"{(sunHour + 12) % 24}#{sunDecField + 6}";
            var sunKey1 = $"{(sunHour + 12) % 24}#{(sunDecField + 6 - 1) % 12}";
            var sunKey2 = $"{(sunHour + 12) % 24}#{(sunDecField + 6 + 1) % 12}";

            this.Diagram[moonKey0] = this.Diagram.ContainsKey(moonKey0) ? this.Diagram[moonKey0] + 2 * valueMoon : 2 * valueMoon;
            this.Diagram[moonKey1] = this.Diagram.ContainsKey(moonKey1) ? this.Diagram[moonKey1] + valueMoon : valueMoon;
            this.Diagram[moonKey2] = this.Diagram.ContainsKey(moonKey2) ? this.Diagram[moonKey2] + valueMoon : valueMoon;
            this.Diagram[sunKey0] = this.Diagram.ContainsKey(sunKey0) ? this.Diagram[sunKey0] + 2 * valueEarth : 2 * valueEarth;
            this.Diagram[sunKey1] = this.Diagram.ContainsKey(sunKey1) ? this.Diagram[sunKey1] + valueEarth : valueEarth;
            this.Diagram[sunKey2] = this.Diagram.ContainsKey(sunKey2) ? this.Diagram[sunKey2] + valueEarth : valueEarth;
        }

        //// Moon diagrams - test.
        #endregion
    }
}