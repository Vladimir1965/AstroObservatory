// <copyright file="SolveEarthquakes.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology
{
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Enums;
    using AstroSharedEvents.Crossing;
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.Systems;
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Solve Earthquakes.
    /// </summary>
    public class SolveEarthquakes {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolveEarthquakes"/> class.
        /// </summary>
        public SolveEarthquakes()
        {
            /*
            this.TestEarthquakesPeriod();
            this.TestEarthquakesPeriodOld();
            this.TestEarthquakeRegions();
            this.EarthquakeRegions();
            this.EarthquakeDifferences();
            this.ListDiagrams();
            this.ListEarthQuakes();
            */
        }

        #region Properties
        /// <summary>
        /// Gets or sets The event background list.
        /// </summary>
        /// <value>
        /// The event background list.
        /// </value>
        public static List<EventBackground> EventBackgroundList { get; set; }

        /// <summary>
        /// Gets or sets the earthquake record list.
        /// </summary>
        /// <value>
        /// The earthquake record list.
        /// </value>
        public List<EarthquakeRecord> EarthquakeRecordList { get; set; }

        /// <summary>
        /// Gets or sets The earthquake list.
        /// </summary>
        /// <value>
        /// The earthquake list.
        /// </value>
        public List<Earthquake> EarthquakeList { get; set; }

        /*
        /// Gets or sets The astronomical event list.
        /// </summary>
        /// <value>
        /// The astronomical event list.
        /// </value>
        public static List<AstroEvent> AstroEventList { get; set; }
        */

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }
        #endregion

        /// <summary>
        /// Stores to XML.
        /// </summary>
        [UsedImplicitly]
        public void StoreToXml()
        {
            string path1 = @"d:\Solutions\PrivateWPF\AstroData2018\Quakes.xml";
            ImportEarthquakes.SaveData(path1);
        }

        /// <summary>
        /// Loads from XML.
        /// </summary>
        public void LoadFromXml()
        {
            string path1 = @"c:\Private\SOLUTIONS-2020\PrivateWPF\AstroData2018\Quakes.xml";
            ImportEarthquakes.LoadData(path1);
            this.EarthquakeRecordList = ImportEarthquakes.List;
        }

        /// <summary>
        /// Loads the earthquakes.
        /// </summary>
        [UsedImplicitly]
        public void LoadFromQuakeml()
        {
            this.LoadLocations();
            string path1 = @"d:\Solutions\PrivateWPF\AstroData2018\Earthquakes\quakeml8.0-10.0.xml";
            ImportEarthquakes.LoadQuakeml(path1);

            string path2 = @"d:\Solutions\PrivateWPF\AstroData2018\Earthquakes\quakeml7.7-8.0.xml";
            ImportEarthquakes.LoadQuakeml(path2);

            string path3 = @"d:\Solutions\PrivateWPF\AstroData2018\Earthquakes\quakeml7.5-7.7.xml";
            ImportEarthquakes.LoadQuakeml(path3);

            this.EarthquakeRecordList = ImportEarthquakes.List;

            /*
            //// List earthquakes in connection to Moon
            var list = ImportEarthquakes.List;
            DateList dateList = new DateList();
            Interval interval = new Interval(dateList);
            dateList.AddEarthquakeDates(list);

            ////  SolarSystem.Singleton.InitSolarSys(LargoBaseAstronomy.AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath);
            LargoBaseAstronomy.EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            dateList.Date.Sort();

            dateList.List.Append("<HTML>\n\r");
            dateList.List.Append("<PRE>\n\r");

            int i = 0;
            foreach (var julianDate in dateList.Date) {
                SolarSystem.Singleton.SetJulianDate(julianDate);
                LargoBaseAstronomy.EarthSystem.SetJulianDate(julianDate);
                //// x1 = Constellation.IsConjunction(SolarSystem.Jupiter.Longitude, SolarSystem.Earth.Longitude, 30.0);
                //// Nov
                //// bool result1 = Constellation.IsOpposition(SolarSystem.Earth.Longitude, EarthSystem.Moon.EclipticLongitude, 3.0);
                //// Full Moon
                bool result1 = Constellation.IsConjunction(SolarSystem.Singleton.Earth.Longitude, LargoBaseAstronomy.EarthSystem.Moon.EclipticLongitude, 6.0);
                if (result1) {
                    bool result2 = true;
                    //// bool result2 = Constellation.IsConjunction(EarthSystem.Moon.EclipticLongitude, EarthSystem.Moon.LP, 30) ||
                    ////     Constellation.IsOpposition(EarthSystem.Moon.EclipticLongitude, EarthSystem.Moon.LP, 30);
                    if (result2) {
                        dateList.PrintDateRecord(i, julianDate, LargoBaseAstronomy.AstCharacteristic.DateDiffs, LargoBaseAstronomy.Julian.JulianYear); //// AstSystem.Solar 
                        dateList.List.Append("\n"); // NEW LINE
                        dateList.LastJulianDate = julianDate;
                    }
                }

                i++;
            }

            dateList.List.Append("</PRE>\n\r");
            dateList.List.Append("</HTML>\n\r");
            this.Text = interval.DateList.List.ToString();
            */
        }

        /*
        /// <summary>
        /// Lists the earthquakes.
        /// </summary>
        private void ListEarthQuakes() {
            DateList dateList = new DateList();
            Interval interval = new Interval(dateList);

            //// var list = DateList.EarthquakeDatesAustralia;
            var list = DateList.EarthquakeDates;
            interval.DateList.AddEarthquakeDates(list);
            this.Text = interval.DateList.PrintCharacteristic(LargoBaseAstronomy.AstCharacteristic.DateDiffs); //// AstSystem.Solar
            foreach (var julianDate in interval.DateList.Date) {
                double ratio = (julianDate / 0.5458774) - 0.32;
                double delta = ratio - Math.Round(ratio);
                if (Math.Abs(delta) < 0.1) {
                    this.Text += " " + LargoBaseAstronomy.Julian.CalendarDate(julianDate, false) + "\n";
                }
            }
        } */

        /// <summary>
        /// Passes the earthquakes.
        /// </summary>
        public void PassEarthquakes()
        {
            var list = from r in this.EarthquakeRecordList
                       orderby r.Year, r.Month
                       select r;
            foreach (var record in list)
            {
                var julianDate = Julian.JulianDay(record.Day, record.Month, record.Year);
                SolarSystem.Singleton.SetJulianDate(julianDate);

                var Ln = SolarSystem.Singleton.Neptune.Longitude;
                var Lu = SolarSystem.Singleton.Uranus.Longitude;
                var Ls = SolarSystem.Singleton.Saturn.Longitude;
                var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                //// var Lr = SolarSystem.Singleton.Mars.Longitude;
                var Le = SolarSystem.Singleton.Earth.Longitude;
                //// var Lv = SolarSystem.Singleton.Venus.Longitude;
                //// var Lm = SolarSystem.Singleton.Mercury.Longitude;

                //// var result = Constellation.IsOpposition(Lj, Le, 10.0)
                ////                 && Constellation.IsOpposition(Lj, Lu, 20.0);

                var s = Constellation.IsConjunction(Lj, Le, 10.0) ? "JE," : string.Empty;
                s += Constellation.IsOpposition(Lj, Ls, 20.0) ? "J-S," : string.Empty;
                s += Constellation.IsOpposition(Lj, Lu, 20.0) ? "J-U," : string.Empty;
                s += Constellation.IsOpposition(Lj, Ln, 20.0) ? "J-N," : string.Empty;
                s += Constellation.IsConjunction(Lj, Ls, 20.0) ? "JS," : string.Empty;
                s += Constellation.IsConjunction(Lj, Lu, 20.0) ? "JU," : string.Empty;
                s += Constellation.IsConjunction(Lj, Ln, 20.0) ? "JN," : string.Empty;

                var result = Constellation.IsConjunction(Lj, Ln, 10.0);
                if (result)
                {
                    this.Text += string.Format(
                            "{0,2}.{1,2}.{2,5} {3,5:F1} {4,20} {5} {6} \n",
                            record.Day, 
                            record.Month, 
                            record.Year,
                            record.Magnitude, 
                            record.Location, 
                            record.Area, 
                            s);
                }
            }
        }

        #region Earthquakes-Period

        /* Earthquakes
                    foreach (var eqn in earthquakes) {
                        var daysdiff = adate.Subtract(eqn.EventTime).Days;
                        if (Math.Abs(daysdiff) <= 3) {
                            var description = string.Format("{0:yyyy-MM-dd} {1} {2}",
                                        eqn.EventTime, eqn.EarthLocation.Country ?? eqn.EarthLocation.Ocean, eqn.Magnitude);
                            ev.EarthquakeDesc = description;
                            ev.EarthquakeId = eqn.Id;
                            ev.EventDate = eqn.EventTime;
                        }
                    }

                    foreach (var eru in eruptions) {
                        if (eru.StartTime == null) {
                            continue;
                        }

                        var daysdiff = adate.Subtract((DateTime)eru.StartTime).Days;
                        if (Math.Abs(daysdiff) <= 3) {
                            var description = string.Format("{0:yyyy-MM-dd} {1} {2}",
                                        eru.StartTime, eru.VolcanoName, eru.EruptionType);
                            ev.EruptionDesc = description;
                            ev.EruptionId = eru.Id;
                            ev.EventDate = eru.StartTime;
                        }
                    }

                  ////   dc.SaveChanges();
                }
         */
        //// --------------

        /// <summary>
        /// Tests the earthquakes period.
        /// </summary>
        [UsedImplicitly]
        private void TestEarthquakesPeriod() {
            var earthquakes = (from te in this.EarthquakeList
                               orderby te.EventTime ascending, te.Latitude, te.Longitude
                               select te).ToList();
            List<string> list = new List<string>();
            foreach (var eq in earthquakes) {
                var item =
                    $"{eq.EventTime:yyyy-MM-dd} {eq.EarthLocation.Country ?? eq.EarthLocation.Ocean} {eq.Magnitude} #0#";
                list.Add(item);
                for (int i = 1; i < 100; i++) {
                    var eventTime = eq.EventTime.AddDays(i * 398.8);  //// saros 6585,  natural 9753, mayan 11960
                    foreach (var eqn in earthquakes) {
                        if (eqn.EventTime < eq.EventTime) {
                            continue;
                        }

                        if (Math.Abs(eqn.EventTime.Subtract(eventTime).Days) < 3) {
                            var item2 =
                                $"{eqn.EventTime:yyyy-MM-dd} {eqn.EarthLocation.Country ?? eqn.EarthLocation.Ocean} {eqn.Magnitude} #{i}#";
                            list.Add(item2);
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            string lastline = "123456789654654";
            foreach (var line in list) {
                sb.AppendLine(lastline);

                var line1 = line;
                if (line1.Contains("#0#")) {
                    sb.AppendLine("------------");
                }

                //// var yline1 = int.Parse(line1.Substring(0, 4));
                //// var ylastline = int.Parse(lastline.Substring(0, 4));
                //// if (yline1 - ylastline > 20) {
                sb.AppendLine(line1);
                //// }
                lastline = line1;
            }

            this.Text = sb.ToString();
        }

        //// ------------------------------

        /// <summary>
        /// Tests the earthquakes period old.
        /// </summary>
        [UsedImplicitly]
        private void TestEarthquakesPeriodOld() {
            var earthquakes = (from te in this.EarthquakeList
                               orderby te.EventTime ascending, te.Latitude, te.Longitude
                               select te).ToList();
            List<string> list = new List<string>();
            foreach (var eq in earthquakes) {
                var item =
                    $"{eq.EventTime:yyyy-MM-dd} {eq.EarthLocation.Country ?? eq.EarthLocation.Ocean} {eq.Magnitude}";
                list.Add(item);
                for (int i = 1; i < 5; i++) {
                    var eventTime = eq.EventTime.AddDays(i * 9753);
                    var itemi = $"{eventTime:yyyy-MM-dd}     {eq.EventTime:yyyy-MM-dd} #{i.ToString()}";
                    list.Add(itemi);
                }
            }

            list.Sort();
            StringBuilder sb = new StringBuilder();
            string lastline = "123456789654654";
            foreach (var line in list) {
                var line1 = line;
                if (line1.Substring(0, 7) == lastline.Substring(0, 7)) {
                    line1 += "***";
                }

                var n1 = int.Parse(line1.Substring(8, 2));
                var nlast = int.Parse(lastline.Substring(8, 2));
                if (Math.Abs(n1 - nlast) <= 7) {
                    line1 += " !!!";
                    sb.AppendLine(string.IsNullOrWhiteSpace(line1.Substring(12, 1)) ? line1 : lastline);
                }

                sb.AppendLine("# " + line1);
                lastline = line1;
            }

            this.Text = sb.ToString();
        }
        #endregion

        #region Earthquakes-Diagrams
        /// <summary>
        /// Tests the earthquake regions.
        /// </summary>
        [UsedImplicitly]
        private void TestEarthquakeRegions() {
            SystemManager.CurrentSystem = AstSystem.Earth;
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            //// SolarSystem.Singleton.InitSolarSys(LargoBaseAstronomy.AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath); //// AlgVariant.VarBretagnon82
            //// DataLink.InitDataLink();
            ////this.EarthquakeRegions();
        }

        /// <summary>
        /// Earthquakes the differences.
        /// </summary>
        [UsedImplicitly]
        private void EarthquakeRegions() {
            //// StringBuilder text = new StringBuilder();
            var earthquakes = (from te in this.EarthquakeList
                               orderby te.EventTime ascending, te.Latitude, te.Longitude
                               select te).ToList(); //// te.EventTime
            Dictionary<string, int> density = new Dictionary<string, int>();
            foreach (var eq in earthquakes) {
                int alpha = (int)(Math.Round(Angles.Mod360((double)eq.Longitude) / 15, 0) * 15);
                int beta = (int)(Math.Round(Angles.Mod180Sym((double)eq.Latitude) / 15, 0) * 15);
                string key = $"{alpha}#{beta}";
                density[key] = density.ContainsKey(key) ? density[key] + 1 : 0;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("      ");
            for (int alpha = 0; alpha < 360; alpha += 15) {
                sb.AppendFormat("{0,4}", alpha);
            }

            sb.AppendFormat("\n");

            sb.AppendFormat("------");
            for (int alpha = 0; alpha < 360; alpha += 15) {
                sb.AppendFormat("----");
            }

            sb.AppendFormat("\n");
            for (int beta = 90; beta >= -90; beta -= 15) {
                sb.AppendFormat("{0,4} :", beta);

                for (int alpha = 0; alpha < 360; alpha += 15) {
                    string key = $"{alpha}#{beta}";
                    int value = density.ContainsKey(key) ? density[key] : 0;

                    sb.AppendFormat("{0,4}", value);
                }

                sb.AppendFormat("\n");
            }

            earthquakes.ForEach(eq => {
                int alpha = (int)(Math.Round(Angles.Mod360((double)eq.Longitude) / 15, 0) * 15);
                int beta = (int)(Math.Round(Angles.Mod180Sym((double)eq.Latitude) / 15, 0) * 15);
                string key = $"{alpha}#{beta}";
                if (key == "240#45") { //// "120#0" //// 285#-15  //// 285#-30 //// "270#15"  //// "255#15"
                    EarthLocation loc = ImportLocations.GetLocation(eq.LocationId);
                    sb.AppendLine(loc.Country ?? loc.Ocean);
                }
            });

            //// Displayed result is multiplicative factor to Verma Lunar map of forces.
            this.Text = sb.ToString();
        }

        //// ------------------------------

        /// <summary>
        /// Earthquakes the differences.
        /// </summary>
        [UsedImplicitly]
        private void EarthquakeDifferences() {
            StringBuilder text = new StringBuilder();
            DateTime lastDateTime = DateTime.Today;

            var earthquakes = (from te in this.EarthquakeList
                               orderby te.EventTime ascending, te.Latitude, te.Longitude
                               select te).ToList(); //// te.EventTime
            earthquakes.ForEach(eq => {
                DateTime dt = eq.EventTime;
                double tyear = dt.Year + ((dt.DayOfYear - 1 + (dt.Hour / 24.0)) / Julian.TropicalYear);
                double julianDate = Julian.JulYear(tyear);
                SolarSystem.Singleton.Jupiter.SetJulianDate(julianDate);
                SolarSystem.Singleton.Earth.SetJulianDate(julianDate);
                double value = Angles.Mod360Sym(SolarSystem.Singleton.Earth.Longitude - SolarSystem.Singleton.Jupiter.Longitude);
                //// absValue = Math.Abs(Angles.Mod180Sym(value));
                var x = eq.EventTime.Subtract(lastDateTime);
                if (x.TotalDays > 180 && x.TotalDays < 380) {
                    text.AppendFormat("({0}) {1}-{2}  {3} \n", Math.Round(x.TotalDays), lastDateTime, eq.EventTime, Math.Round(value));
                }

                lastDateTime = eq.EventTime;
            });

            this.Text = text.ToString();
        }

        //// ------------------------------

        /// <summary>
        /// Lists the diagrams.
        /// </summary>
        [UsedImplicitly]
        private void ListDiagrams() {
            MoonInfluence mi = new MoonInfluence { Extremes = new List<ExtremeInfluence>() };
            const int year = 1934;
            const int interval = 9;
            MoonInfluence.InsertEarthStatus(year);
            //// int[,] diagram = new int[24, 13];
            //// mi.Summation(0, 9);
            //// for (int decade = 0; decade <= 36; decade++) {
            //// for (int i = 0; i < 10; i++) {
            ////         mi.Summation(10 * decade, 10 * decade+9);
            //// }
            //// } 

            for (int day = interval + 1; day <= 365; day++) {
                //// for (int i = 0; i < 10; i++) {
                List<EarthStatus> list = mi.Summation(day - interval, day);
                mi.ListDiagramExtremes(list, 650);
                //// }
                this.WriteDiagram(year, day, mi, interval);
            }

            StringBuilder text = new StringBuilder();
            mi.Extremes.ForEach(ei => text.AppendFormat("{0,20} LAT:{1,4:F0} LNG:{2,4:F0} VAL:{3} \n", ei.EventTime, ei.Latitude, ei.Longitude, ei.Value));

            this.Text = text.ToString();
        }

        /// <summary>
        /// Writes the diagram.
        /// </summary>
        /// <param name="year">The given year.</param>
        /// <param name="day">The given day.</param>
        /// <param name="mi">The moon influence.</param>
        /// <param name="interval">The interval.</param>
        private void WriteDiagram(int year, int day, MoonInfluence mi, int interval) {
            StringBuilder sb = new StringBuilder();
            DateTime dt = new DateTime(year, 1, 1);
            dt = dt.AddDays(day - 1);
            sb.AppendFormat("*** {0} ***\n", dt);
            //// for (int declin = -6; declin <= 6; declin++) {
            for (int declin = -4; declin < 4; declin++) {
                for (int hour = 0; hour < 24; hour++) {
                    string key = $"{hour}#{declin + 6}";
                    int value = mi.Diagram.ContainsKey(key) ? mi.Diagram[key] / interval : 0;

                    sb.AppendFormat("{0,4}", value);
                }

                sb.AppendFormat("\n");
            }

            for (int hour = 0; hour < 24; hour++) {
                int value = 0;
                for (int declin = -4; declin < 4; declin++) {
                    string key = $"{hour}#{declin + 6}";
                    if (mi.Diagram.ContainsKey(key)) {
                        value += mi.Diagram[key] / interval;
                    }
                }

                sb.AppendFormat("{0,4}", value);
            }

            sb.AppendFormat("\n");
            this.Text += sb.ToString();
        }
        #endregion

        /// <summary>
        /// Adds the earthquake dates.
        /// </summary>
        /// <param name="records">The records.</param>
        [UsedImplicitly]
        public void AddEarthquakeDates(IEnumerable<EarthquakeRecord> records)
        {
            foreach (var r in records)
            {
                //// this.Info.Add(r.ToString());
                var date = Julian.JulianDay(r.Day, r.Month, r.Year);
                var dfrac = Julian.DayFraction(r.Hour, r.Minute, 0);
                date += dfrac;
                var localtime = Math.Round((r.Longitude / 360) * 48, 0) / 48;  //// Longitude to half-hour multiple

                switch (r.Time)
                {
                    case "IST":
                        {
                            date -= 5.5 / 24;
                            break;
                        }

                    case "LOCAL":
                        {
                            date -= localtime;
                            break;
                        }

                    case "UTC+8":
                        {
                            date -= 8.0 / 24;
                            break;
                        }
                }

                //// this.AddDate(date);
            }
        }

        /// <summary>
        /// Loads the locations.
        /// </summary>
        private void LoadLocations()
        {
            const string rpathearth = @"d:\Solutions\PrivateWPF\AstroData2018\Locations\Geo-Earth"; //// Geo-EarthNames not done
            const string rpathoceans = @"d:\Solutions\PrivateWPF\AstroData2018\Locations\Geo-OceanNames";

            ImportLocations.LoadLocations(rpathearth);
            ImportLocations.LoadLocations(rpathoceans);
        }
    }
}
