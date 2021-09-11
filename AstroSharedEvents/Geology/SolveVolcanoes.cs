// <copyright file="SolveVolcanoes.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology
{
    using AstroSharedClasses.Calendars;
    using AstroSharedEvents.Crossing;
    using AstroSharedOrbits.Systems;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Solve Volcanoes.
    /// </summary>
    public class SolveVolcanoes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolveVolcanoes"/> class.
        /// </summary>
        public SolveVolcanoes()
        {
        }

        /// <summary>
        /// Gets or sets The event background list.
        /// </summary>
        /// <value>
        /// The eruption record list.
        /// </value>
        public List<EruptionRecord> EruptionRecordList { get; set; }

        /// <summary>
        /// Gets or sets The volcano record list.
        /// </summary>
        /// <value>
        /// The volcano record list.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public List<VolcanoRecord> VolcanoRecordList { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Passes the volcanoes.
        /// </summary>
        public void PassVolcanoes()
        {
            var list = from r in this.EruptionRecordList
                       orderby r.StartYear, r.StartMonth  select r;
            foreach (var record in list)
            {
                var julianDate = Julian.JulianDay(record.StartDay, record.StartMonth, record.StartYear);
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
                if (result) {
                    this.Text += string.Format(
                        "{0,2}.{1,2}.{2,5} {3,6:F1} {4,20} {5} {6}  \n",
                        record.StartDay, 
                        record.StartMonth, 
                        record.StartYear,
                        record.Duration, 
                        record.VolcanoName, 
                        record.EruptionType, 
                        s);
                }
            }
        }

        /// <summary>
        /// Stores to XML.
        /// </summary>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public void StoreToXml()
        {
            string path1 = @"c:\Private\SOLUTIONS-2020\PrivateWPF\AstroData2018\Eruptions.xml";
            ImportEruptions.SaveData(path1);
        }

        /// <summary>
        /// Loads from XML.
        /// </summary>
        public void LoadFromXml()
        {
            string path1 = @"c:\Private\SOLUTIONS-2020\PrivateWPF\AstroData2018\Eruptions.xml";
            ImportEruptions.LoadData(path1);
            this.EruptionRecordList = ImportEruptions.List;
        }

        /// <summary>
        /// Loads the volcanoes.
        /// </summary>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public void LoadFromXls()
        {
            //// this.LoadLocations();
            //// const string pathVolcanoes = @"d:\Solutions\PrivateWPF\AstroData2018\Volcanoes\GVP_Volcano_List.xls";
            //// const string pathEruptions = @"d:\Solutions\PrivateWPF\AstroData2018\Volcanoes\GVP_Eruption_Results.xls";
            //// const string pathEruptions = @"d:\Solutions\PrivateWPF\AstroData2018\Volcanoes\GVP_Eruption_Select.xls";
            const string pathEruptions = @"c:\Private\SOLUTIONS-2020\PrivateWPF\AstroData2018\Volcanoes\GVP_Eruption_Reduced.xls";
            //// ImportVolcanoes.InsertVolcanoes(pathVolcanoes);
            ImportEruptions.InsertEruptions(pathEruptions, string.Empty); //// Vesuvius
            this.EruptionRecordList  = ImportEruptions.List;
        } 
                    /*
            //// List selected eruptions
            var list = ImportVolcanoes.ListEruptions;
            //// var list = from r in origlist where r.VolcanoName=="Vesuvius" select r;
            DateList dateList = new DateList();
            Interval interval = new Interval(dateList);
            list.Sort((x, y) => x.EndYear.CompareTo(y.EndYear));
            dateList.AddEruptionDates(list);

            //// SolarSystem.Singleton.InitSolarSys(LargoBaseAstronomy.AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath);
            LargoBaseAstronomy.EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            //// dateList.Date.Sort();

            dateList.List.Append("<HTML>\n\r");
            dateList.List.Append("<PRE>\n\r");

            int i = 0;
            foreach (var julianDate in dateList.Date)
            {
                //// SolarSystem.SetJulianDate(julianDate);
                //// EarthSystem.SetJulianDate(julianDate);
                //// bool result1 = Constellation.IsConjunction(SolarSystem.Earth.Longitude, EarthSystem.Moon.EclipticLongitude, 6.0);
                bool result1 = true;
                if (result1)
                {
                    dateList.PrintDateRecord(i, julianDate, LargoBaseAstronomy.AstCharacteristic.DateDiffs, LargoBaseAstronomy.Julian.JulianYear); //// AstSystem.Solar 
                    int jd = (int)julianDate;
                    //// int jm = (jd - 523) % 624;
                    //// int jm = (jd - 14) % 624;
                    int jm = (jd - 47) % 156;
                    dateList.List.Append(" M=" + jm.ToString());
                    dateList.List.Append("\n"); // NEW LINE
                    dateList.LastJulianDate = julianDate;
                }

                i++;
            }

            dateList.List.Append("</PRE>\n\r");
            dateList.List.Append("</HTML>\n\r");
            this.Text = interval.DateList.List.ToString();
            */

        /// <summary>
        /// Adds the eruption dates.
        /// </summary>
        /// <param name="records">The records.</param>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public void AddEruptionDates(IEnumerable<EruptionRecord> records)
        {
            foreach (var r in records)
            {
                //// this.Info.Add(r.ToString());
                var date = Julian.JulianDay(r.EndDay, r.EndMonth, r.EndYear);
                //// var dfrac = Julian.DayFraction(r.Hour, r.Minute, 0);
                //// date += dfrac;
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
