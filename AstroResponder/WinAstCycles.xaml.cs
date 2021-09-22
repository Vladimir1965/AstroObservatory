// <copyright file="WinAstCycles.xaml.cs" company="Largo">
// Copyright (c) 2010 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2010-05-01</date>
// <summary>Contains ...</summary>
namespace XAstro.Astro
{
    using JetBrains.Annotations;
    using LargoBase.Abstract;
    using LargoBaseAstronomy.Calendars;
    using LargoBaseAstronomy.Computation;
    using LargoBaseAstronomy.Enums;
    using LargoBaseAstronomy.Events;
    using LargoBaseAstronomy.Maths;
    using LargoBaseAstronomy.Orbits;
    using LargoBaseAstronomy.Planets;
    using LargoBaseAstronomy.Records;
    using LargoBaseAstronomy.Systems;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Xml.Linq;

    /// <summary>
    /// Interaction logic for Astronomic Cycles.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    public sealed partial class WinAstCycles
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WinAstCycles"/> class.
        /// </summary>
        public WinAstCycles() {
            this.InitializeComponent();
            this.TBDateFrom.Text = "1750,0"; ////  "-3000,00"; "1749,00"; //// "1950,0";
            this.TBDateTo.Text = "2050,0"; //// "-2650,00"; "2020,0";   //// "2000,0";
        }
        #endregion

        #region Public static

        /// <summary>
        /// Special List.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="givenAstroType">Type of the given system.</param>
        [UsedImplicitly]
        public static void SpecialList(double dateFrom, double dateTo, string givenAstroType) { //// byte action
            LargoBaseAstronomy.Systems.SystemManager.CurrentSystem = LargoBaseAstronomy.Enums.AstSystem.Solar;
            LargoBaseAstronomy.Computation.DateList dateList = new LargoBaseAstronomy.Computation.DateList();
            Interval interval = new Interval(dateList);
            interval.InitWith(dateFrom, dateTo, 10, 1, 100);
            //// interval.InitWith(dateFrom, dateTo, 1, 1, 100);
            interval.SpecialDates(givenAstroType);
        }
        #endregion

        #region Public methods 

        /// <summary>
        /// Lists the perihelia.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        public void ListPerihelia(object sender, RoutedEventArgs e) {
            for (int k = -400; k < 200; k++) {
                var julianDate = BodyNeptune.MeeusPerihelion(k);
                var s = string.Format(
                    "{0,8:F2} \t {1} \n",
                    LargoBaseAstronomy.Calendars.Julian.Year(julianDate),
                    LargoBaseAstronomy.Calendars.Julian.CalendarDate(julianDate, false));
                this.InfoText.Text += s;
            }
        }

        /// <summary>
        /// Tests the tidal list.
        /// </summary>
        public void TestTidalList() {
            /* Alignment longitudes function 
             * var ratio = 360.0 * 100.0 / 4130.0;
            for (int i = 1300; i < 2300; i++) {
                var v = i * 1.000 / 100.0 * ratio;
                this.InfoText.Text += string.Format("{0,5:F1} {1,5:F1} \n", 878 + i, 8.9 + v);
            }
            return;
            */
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            double dateFrom = double.Parse(this.TBDateFrom.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            double dateTo = double.Parse(this.TBDateTo.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

            LargoBaseAstronomy.Computation.DateList dateList = new LargoBaseAstronomy.Computation.DateList();
            Interval interval = new Interval(dateList);
            interval.InitWith(dateFrom, dateTo, 3, 1, 1);

            //// XLS File
            //// interval.DateList.AddDates(dateFrom, dateTo, 3 / 365.25);

            //// Alignment
            //// interval.DateList.AddDates(dateFrom, dateTo, 15 / 365.25);
            interval.DateList.AddDates(dateFrom, dateTo, 30 / 365.25);
            //// interval.DateList.AddDates(dateFrom, dateTo, 30.43685 / 365.25);
            //// interval.DateList.AddDates(dateFrom, dateTo, 91.31055 / 365.25);
            //// interval.DateList.AddDates(dateFrom, dateTo, 0.5);
            //// interval.DateList.AddDates(dateFrom, dateTo, 1.0); //// 5.0

            //// interval.DateList.AddDates(dateFrom, dateTo, 15 / 365.25);
            //// interval.InitWith(dateFrom, dateTo, 365.25, 1, 1);
            //// interval.DateList.AddDates(dateFrom, dateTo, 25.38 / 365.25);

            //// interval.InitWith(dateFrom, dateTo, 5, 1, 15); 
            //// interval.SpecialDates("Quadra");
            //// interval.DateList.PassDates();

            //// XLS File
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.Experiment);

            //// Alignment
            this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffs);
            //// this.InfoText.Text = interval.DateList.OutputSnapshots();
        }

        /// <summary>
        /// Test Date List.
        /// </summary>
        [UsedImplicitly]
        public void TestDateList() {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            //// SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            //// SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath); //// AlgVariant.VarBretagnon82
            double dateFrom = double.Parse(this.TBDateFrom.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            double dateTo = double.Parse(this.TBDateTo.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            //// byte action = 1;
            //// bool accuracy = true;
            ////  SolarSystem.Singleton.Influences = false;

            //// this.SpecialList(dateFrom, dateTo, action); 
            //// PlacePlanetX(dateFrom, dateTo); 

            LargoBaseAstronomy.Computation.DateList dateList = new LargoBaseAstronomy.Computation.DateList();
            Interval interval = new Interval(dateList);
            //// interval.InitWith(dateFrom, dateTo, 1*365.25, 1, 1);
            interval.InitWith(dateFrom, dateTo, 30, 1, 1);

            //// interval.DateList.AddSelectedDates(LargoBaseAstronomy.Computation.DateList.SolarMaxDates, dateFrom, dateTo);
            //// interval.DateList.AddSelectedDates(LargoBaseAstronomy.Computation.DateList.SchoveMaxDates, dateFrom, dateTo);
            //// interval.DateList.AddDates(dateFrom, dateTo, 115.1/2); //// 10.0,  0.5, /2

            //// interval.DateList.AddDates(dateFrom, dateTo, 3.00 / 365.25); // 30
            //// interval.DateList.AddDates(dateFrom, dateTo, 15.00 / 365.25); // 30
            ////  interval.DateList.AddDates(dateFrom, dateTo, 1.00 / 10.00); // 30
            interval.DateList.AddDates(dateFrom, dateTo, 1.0 / 1.0); //// 10*365.25 / 365.25

            SolarSystem.Singleton.Jupiter.Enabled = true;
            SolarSystem.Singleton.Saturn.Enabled = true;
            SolarSystem.Singleton.Uranus.Enabled = true;
            SolarSystem.Singleton.Neptune.Enabled = true;

            interval.DateList.RunningTotalPeriod = 0;
            interval.DateList.RunningNumberOfPeriods = 0;

            this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffs);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffsOuter);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.OrientedBaryAxis);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.Experiment);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffsZharkova);

            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.OrientedBaryAxis); ////  AstSystem.Solar
        }

        /// <summary>
        /// Lists the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        public void TestSolarSystem(object sender, RoutedEventArgs e) {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            //// SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            //// SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87,  false,  AstroSetup.vsopRootPath); //// AlgVariant.VarBretagnon82
            //// DataLink.InitDataLink();

            double dateFrom = double.Parse(this.TBDateFrom.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            double dateTo = double.Parse(this.TBDateTo.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            //// SolarSystem.Singleton.Influences = false;
            //// LargoBaseAstronomy.Computation.DateList dateList = new LargoBaseAstronomy.Computation.DateList();
            //// Interval interval = new Interval(dateList);
            //// this.ListSpecialDates(dateFrom, dateTo, "Sun-Moon-E-J"); //// Sun-E-Moon-J
            //// this.ListSpecialDates(dateFrom, dateTo, "J-Sun-E-Moon"); //// J-Sun-Moon-E            
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffs); //// AstSystem.Solar
            //// ListEarthQuakes()

            this.ListSpecialDates(dateFrom, dateTo, "Quadra");
            //// this.ListSpecialDates(dateFrom, dateTo, "PlanetX");
        }

        /*
        /// <summary>
        /// Completes the astronomical events.
        /// </summary>
        public void CompleteAstroEvents() {
           var earthquakes = (from te in WinAstCycles.EarthquakeList
                               orderby te.EventTime ascending, te.Latitude, te.Longitude
                               select te).ToList();
            var eruptions = (from te in WinAstCycles.EruptionRecordList
                             orderby te.StartTime ascending, te.VolcanoName
                             select te).ToList();
            
            foreach (var ev in WinAstCycles.AstroEventList) {
                if (ev.AstroDate == null) {
                    continue;
                }

                //// var adate = ev.AstroDate;

                if (ev.EruptionId != null) {
                    ev.EventType = ev.EarthquakeId != null ? "combined" : "eruption";
                }
                else {
                    ev.EventType = ev.EarthquakeId != null ? "earthquake" : null;
                }
                //// dc.SaveChanges();
            }
        }
         * */
        #endregion

        #region Private static
        /// <summary>
        /// Observe Moon In Years.
        /// </summary>
        [UsedImplicitly]
        private static void ObserveMoonInYears() {
            LargoBaseAstronomy.Systems.SystemManager.CurrentSystem = LargoBaseAstronomy.Enums.AstSystem.Earth;
            //// MoonInfluence mi = new MoonInfluence { Extremes = new List<ExtremeInfluence>() };
            for (int year = 571; year < 572; year++) {
                MoonInfluence.InsertEarthStatus(year);
            }

            for (int year = 844; year < 845; year++) {
                MoonInfluence.InsertEarthStatus(year);
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// List Special Dates.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="givenAstroType">Type of the given system.</param>
        private void ListSpecialDates(double dateFrom, double dateTo, string givenAstroType) {
            LargoBaseAstronomy.Computation.DateList dateList = new LargoBaseAstronomy.Computation.DateList();
            Interval interval = new Interval(dateList);
            //// interval.InitWith(dateFrom, dateTo, 1, 1, 20); //// for moon ...2,2,40
            //// interval.InitWith(dateFrom, dateTo, 30, 10, 200); //// for earthquakes ...
            //// interval.InitWith(dateFrom, dateTo, 30, 1, 200); //// for s-activity ...
            //// interval.InitWith(dateFrom, dateTo, 1, 5, 20);
            //// interval.InitWith(dateFrom, dateTo, 3, 0.3, 3600);
            //// interval.InitWith(dateFrom, dateTo, 20, 1, 60); //// 10,1,30

            //// interval.InitWith(dateFrom, dateTo, 365.25, 1, 365.25); //// 10,1,30

            //// interval.InitWith(dateFrom, dateTo, 365.25, 1, 30); //// 10,1,30
            //// interval.InitWith(dateFrom, dateTo, 30.0, 1, 600); //// 30, 1, 120,  20,1,100  / 10,1,30
            interval.InitWith(dateFrom, dateTo, 30, 1, 180); //// 30, 1, 120 / 10,1,30
            //// interval.InitWith(dateFrom, dateTo, 15, 1, 15); //// 10,1,30
            //// interval.InitWith(dateFrom, dateTo, 30, 1, 180); //// 10,1,30
            //// interval.InitWith(dateFrom, dateTo, 30, 10, 90); //// 30,1,360 //// 10,1,30 //// 30,1,90

            interval.SpecialDates(givenAstroType);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.LghInner);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.LghOuter);
            this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffs); //// AstSystem.Solar
            ////xxxx interval.DateList.WriteToAstroEvents(givenAstroType);
        }

        /// <summary>
        /// Exports the data.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListMayanData(object sender, RoutedEventArgs e) {
            //// this.ExportMayanData(null, null);  return;

            SystemManager.CurrentSystem = AstSystem.Solar;
            //// SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath); //// AlgVariant.VarBretagnon82

            var sb = new StringBuilder();

            var mdates = LargoBaseAstronomy.Computation.DateList.AllMayanDates;
            var mdatesrt = (from md in mdates orderby md.MayanDay select md).ToList();
            long lastMayanDay = 0;
            var correlationNumber = LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant;
            foreach (var mayaRecord in mdatesrt) {
                if (mayaRecord.MayanDay == lastMayanDay) {
                    continue;
                }

                double julianDate = correlationNumber + mayaRecord.MayanDay;
                SolarSystem.Singleton.SetJulianDate(julianDate);

                var s = mayaRecord.ToString(correlationNumber);
                var p = string.Format(
                        "M{0,3:F0} V{1,3:F0} E{2,3:F0} R{3,3:F0} J{4,3:F0} S{5,3:F0}",
                        SolarSystem.Singleton.Mercury.Longitude,
                        SolarSystem.Singleton.Venus.Longitude,
                        SolarSystem.Singleton.Earth.Longitude,
                        SolarSystem.Singleton.Mars.Longitude,
                        SolarSystem.Singleton.Jupiter.Longitude,
                        SolarSystem.Singleton.Saturn.Longitude);
                var r = (Angles.EqualDeg(SolarSystem.Singleton.Mercury.Longitude, SolarSystem.Singleton.Venus.Longitude, 20) ? "M-V," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Mercury.Longitude, SolarSystem.Singleton.Earth.Longitude, 20) ? "M-E," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Mercury.Longitude + 180, SolarSystem.Singleton.Earth.Longitude, 20) ? "MoE," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Venus.Longitude, SolarSystem.Singleton.Earth.Longitude, 20) ? "V-E," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Venus.Longitude + 180, SolarSystem.Singleton.Earth.Longitude, 20) ? "VoE," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Venus.Longitude, SolarSystem.Singleton.Mars.Longitude, 20) ? "V-R," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Venus.Longitude, SolarSystem.Singleton.Jupiter.Longitude, 20) ? "V-J," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Earth.Longitude, SolarSystem.Singleton.Mars.Longitude, 20) ? "E-R," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Earth.Longitude + 180, SolarSystem.Singleton.Mars.Longitude, 20) ? "EoR," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Earth.Longitude, SolarSystem.Singleton.Jupiter.Longitude, 20) ? "E-J," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Earth.Longitude + 180, SolarSystem.Singleton.Jupiter.Longitude, 20) ? "EoJ," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Earth.Longitude, SolarSystem.Singleton.Saturn.Longitude, 20) ? "E-S," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Earth.Longitude + 180, SolarSystem.Singleton.Saturn.Longitude, 20) ? "EoS," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Mars.Longitude, SolarSystem.Singleton.Jupiter.Longitude, 20) ? "R-J," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Mars.Longitude, SolarSystem.Singleton.Saturn.Longitude, 20) ? "R-S," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Saturn.Longitude, 20) ? "J-S," : string.Empty) +
                        (Angles.EqualDeg(SolarSystem.Singleton.Jupiter.Longitude + 180, SolarSystem.Singleton.Saturn.Longitude, 20) ? "JoS" : string.Empty);

                var x = s.Replace("###", r + ";" + p);
                var g1 = LargoBaseAstronomy.Calendars.Julian.Year(julianDate) + ";";
                var g2 = LargoBaseAstronomy.Calendars.Julian.CalendarDate(julianDate, false) + ";";
                sb.AppendLine(g1 + g2 + x);

                lastMayanDay = mayaRecord.MayanDay;
            }

            var path = Path.Combine(@"d:\Temp", "MayanDates.csv");
            //// SupportFiles.StringToFile(sb.ToString(), path);
        }

        /// <summary>
        /// Exports the mayan data.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        [UsedImplicitly]
        private void ExportMayanData(object sender, RoutedEventArgs e) {
            var decl = new XDeclaration("1.0", "utf-8", "no");
            var comment = new XComment("Mayan dates");
            var xdoc = new XDocument(decl, comment);
            var xlist = new XElement("Dates");
            xdoc.Add(xlist);

            var mdates = LargoBaseAstronomy.Computation.DateList.AllMayanDates;
            var mdatesrt = (from md in mdates orderby md.MayanDay select md).ToList();
            long lastMayanDay = 0;
            foreach (var mayaRecord in mdatesrt) {
                if (mayaRecord.MayanDay == lastMayanDay) {
                    continue;
                }

                xlist.Add(mayaRecord.GetXElement);
                lastMayanDay = mayaRecord.MayanDay;
            }

            var s = Path.Combine(@"d:\Temp", "MayanDates.xml");
            xdoc.Save(s);
        }

        /// <summary>
        /// Lists the resonances.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListResonances(object sender, RoutedEventArgs e) {
            const float j = 11.8620F;
            const float s = 29.457159F;
            const float u = 84.020473F;
            const float n = 164.77013F;

            const float M = 4130F;
            //// const float w = 11.05F;
            //// const float w = 10.59F;  ////  10.82F
            //// const float q = 13.63F;

            var jm = 1.0000 / ((1 / j) - (1 / M));
            var sm = 1.0000 / ((1 / s) - (1 / M));
            var um = 1.0000 / ((1 / u) - (1 / M));
            var nm = 1.0000 / ((1 / n) - (1 / M));
            const float w = 884;

            string s0 = Resonances.Resonant(4, false, 900, 1000000, jm, sm, um, nm, w);
            //// string s1 = Resonances.Resonant(4, true, 900, 1000000, j, s, u, n, w / 2);
            //// string s1 = Resonances.Resonant(3, false, 900, 1000000, j, u, n, 0, -w);
            //// string s2 = Resonances.Resonant(4, true, 900, 1000000, j, s, u, n, 2 * w);
            //// string s3 = Resonances.Resonant(4, true, 900, 1000000, j, s, u, n, 3 * w);
            //// string s4 = Resonances.Resonant(4, true, 900, 1000000, j, s, u, n, 4 * w);
            //// string s5 = Resonances.Resonant(4, true, 900, 1000000, j, s, u, n, 5 * w);
            //// string s8 = Resonances.Resonant(4, true, 900, 1000000, j, s, u, n, 8 * w);
            //// string s16 = Resonances.Resonant(4, true, 900, 1000000, j, s, u, n, 16 * w);
            this.InfoText.Text += s0; //// + s1 + s2 + s3 + s4 + s5; ////  +s8 + s16;

            //// string s = Resonances.Resonant(4, false, 10000, 10000000, 224.701, 365.256, 4332.67, 2 * 4054.1);
        }

        /// <summary>
        /// Tests the solar activity.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TestSolarActivity(object sender, RoutedEventArgs e) {
            LargoBaseAstronomy.Systems.SystemManager.CurrentSystem = LargoBaseAstronomy.Enums.AstSystem.Solar;
            //// SolarSystem.Singleton.InitSolarSys(LargoBaseAstronomy.Enums.AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath); //// AlgVariant.VarBretagnon82
            LargoBaseAstronomy.Systems.EarthSystem.InitSystem(AstroSetup.vsopRootPath);

            //// DataLink.InitDataLink();

            double dateFrom = double.Parse(this.TBDateFrom.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            double dateTo = double.Parse(this.TBDateTo.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            ////  SolarSystem.Singleton.Influences = false;
            //// LargoBaseAstronomy.Computation.DateList dateList = new LargoBaseAstronomy.Computation.DateList();
            //// Interval interval = new Interval(dateList);
            //// this.ListSolarDates(dateFrom, dateTo, interval);
            this.ListUniformTestDates(dateFrom, dateTo, 366); //// 183
        }

        /// <summary>
        /// Tests the moon.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TestMoon(object sender, RoutedEventArgs e) {
            //// DataLink.InitDataLink();
            //// this.CompleteAstroEvents();
            //// this.TestEarthquakesPeriod();
            //// this.TestEarthquakeRegions(); 
        }

        /// <summary>
        /// List Uniform Test Dates.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="days">The days.</param>
        private void ListUniformTestDates(double dateFrom, double dateTo, int days) {
            LargoBaseAstronomy.Computation.DateList dateList = new LargoBaseAstronomy.Computation.DateList();
            Interval interval = new Interval(dateList);
            interval.DateList.AddDates(dateFrom, dateTo, days / 365.2422); //// 0.5 //// 0.1368955377
            this.InfoText.Text = interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs); //// AstSystem.Solar
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.LongitudesToExcel);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.Conjunctions);
        }

        /// <summary>
        /// List Solar Dates.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="interval">The interval.</param>
        [UsedImplicitly]
        private void ListSolarDates(double dateFrom, double dateTo, Interval interval) {
            //// interval.DateList.SolarMaxDates(dateFrom, dateTo); //// 0.5
            interval.DateList.AddSelectedDates(LargoBaseAstronomy.Computation.DateList.SchoveMaxDates, dateFrom, dateTo); //// 0.5
            this.InfoText.Text = interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
        }
        #endregion

        #region Moon

        /*
        /// <summary>
        /// Lists the quake backgrounds.
        /// </summary>
        [UsedImplicitly]
        private void ListEventBackgrounds() {
            StringBuilder text = new StringBuilder();

            //// order by bg.Earthquake.Magnitude descending, bg.EventTime ascending 
            //// bg.Earthquake.Magnitude descending, bg.Characteristic descending, bg.EventTime ascending
            //// order by bg.Place, bg.EventTime ascending
            var backgrounds = (from bg in SolveEarthquakes.EventBackgroundList
                               orderby bg.EventTime, bg.Place ascending
                               select bg).ToList();

            backgrounds.ForEach(bg => {
                //// Earthquake eq = bg.Earthquake;
                EruptionRecord eruption = (from vo in SolveVolcanoes.EruptionRecordList
                                           where vo.Id == bg.EruptionId
                                           select vo).FirstOrDefault();
                VolcanoRecord volcano = (from vo in SolveVolcanoes.VolcanoRecordList
                                          where eruption != null && vo.VolcanoNumber == eruption.VolcanoNumber
                                          select vo).FirstOrDefault();
                DateTime dt = bg.EventTime;
                if (volcano != null) {
                    if (bg.Place != null) {
                        text.AppendFormat(
                            "{0,-20} E{1,4:F1}({2,3:F0},{3,4:F0}) M({4,3:F0},{5,4:F0}) S({6,3:F0},{7,4:F0}) {8,-24} {9,-30}\n",
                            dt, //// eq.Magnitude, eq.Latitude, eq.Longitude,
                            0,
                            volcano.Latitude,
                            volcano.Longitude,
                            bg.MoonDeclination,
                            bg.MoonAscension,
                            bg.SunDeclination,
                            bg.SunAscension,
                            (bg.Place ?? string.Empty).Substring(0, Math.Min(bg.Place.Length, 24)),
                            ////+ (eruption.EruptionType ?? string.Empty).Substring(0, Math.Min(eruption.EruptionType.Length, 24)), 
                            bg.Characteristic);
                    }
                }

                this.InfoText.Text = text.ToString();
            });
        }
        */
        #endregion

        /// <summary>
        /// Tests the date list.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TestDateList(object sender, RoutedEventArgs e) {
            this.TestDateList();
        }

        /// <summary>
        /// Lists the volcanoes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListVolcanoes(object sender, RoutedEventArgs e) {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            SystemManager.SetEnabled(true);

            var sv = new SolveVolcanoes();
            //// sv.LoadFromXls();
            //// sv.StoreToXml();
            sv.LoadFromXml();
            sv.PassVolcanoes();
            this.InfoText.Text = sv.Text;
        }

        /// <summary>
        /// Lists the earthquakes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListEarthquakes(object sender, RoutedEventArgs e) {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            SystemManager.SetEnabled(true);

            var se = new SolveEarthquakes();
            //// se.LoadFromQuakeml();
            //// se.StoreToXml();
            se.LoadFromXml();
            se.PassEarthquakes();
            this.InfoText.Text = se.Text;
        }


        /// <summary>
        /// Tests volcanoes after earthquakes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TestKalendaRule(object sender, RoutedEventArgs e) {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            SystemManager.SetEnabled(true);

            var list = new List<GeoRecord>();

            var se = new SolveEarthquakes();
            se.LoadFromXml();
            foreach (var r in se.EarthquakeRecordList) {
                var gr = new GeoRecord('E', r.Day, r.Month, r.Year, r.Location + " ("+ r.Magnitude.ToString()+" "+r.Area+ ")");
                gr.Magnitude = r.Magnitude;
                list.Add(gr);
            }
          
            var sv = new SolveVolcanoes();
            sv.LoadFromXml();
            foreach (var r in sv.EruptionRecordList) {
                if (r.StartYear < 1900) {
                    continue;
                }

                var gr = new GeoRecord('V', r.StartDay, r.StartMonth, r.StartYear, r.VolcanoName+" #"+r.VEI.ToString()+ " ("+r.Duration.ToString()+")");
                gr.VEI = r.VEI;
                list.Add(gr);
            }

            var sortedList = (from r in list orderby r.JulianDate select r).ToList();

            var sb = new StringBuilder();
            double lastQuakeJD = 0;
            foreach (var r in sortedList) {
                if (r.GeoType == 'E') {
                    if (r.Magnitude < 8.2) {
                        continue;
                    }

                    sb.AppendFormat("*Q* {0,8:F2} {1} \n", Julian.Year(r.JulianDate), r.Description);
                    lastQuakeJD = r.JulianDate;
                }

                if (r.GeoType == 'V' && r.JulianDate - lastQuakeJD < 365) {
                    sb.AppendFormat("\t\t  +{0,5:F1} => *E* {1,8:F2} {2} \n", r.JulianDate - lastQuakeJD, Julian.Year(r.JulianDate), r.Description);
                }
            }

            this.InfoText.Text = sb.ToString();
        }

        private void TestKalendaRule2(object sender, RoutedEventArgs e) {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            SystemManager.SetEnabled(true);

            var list = new List<GeoRecord>();

            var se = new SolveEarthquakes();
            se.LoadFromXml();
            foreach (var r in se.EarthquakeRecordList) {
                var gr = new GeoRecord('E', r.Day, r.Month, r.Year, r.Location + " (" + r.Magnitude.ToString() + " " + r.Area + ")");
                gr.Magnitude = r.Magnitude;
                list.Add(gr);
            }

            var sv = new SolveVolcanoes();
            sv.LoadFromXml();
            foreach (var r in sv.EruptionRecordList) {
                if (r.StartYear < 1900) {
                    continue;
                }

                var gr = new GeoRecord('V', r.StartDay, r.StartMonth, r.StartYear, r.VolcanoName + " #" + r.VEI.ToString()+ " (" + r.Duration.ToString() + ")");
                gr.VEI = r.VEI;
                list.Add(gr);
            }

            var sortedList = (from r in list orderby r.JulianDate descending select r).ToList();

            for (int VEI = 9; VEI >= 2; VEI--) {
                this.InfoText.Text += string.Format("*** {0} ***\n", VEI);
                var sb = new StringBuilder();
                double lastEruptionJD = 10000000000000;
                foreach (var r in sortedList) {
                    if (r.GeoType == 'V') {
                        if (r.VEI != VEI) {
                            continue;
                        }

                        sb.AppendFormat("*E* {0,8:F2} {1} \n", Julian.Year(r.JulianDate), r.Description);
                        lastEruptionJD = r.JulianDate;
                    }

                    if (r.GeoType == 'E' && lastEruptionJD- r.JulianDate < 5*365) { 
                        if (r.Magnitude < 8.2) {
                            continue;
                        }

                        sb.AppendFormat("\t\t {0,5:F1} => *Q* {1,8:F2} {2} \n", r.JulianDate - lastEruptionJD, Julian.Year(r.JulianDate), r.Description);
                    }
                }

                this.InfoText.Text += sb.ToString();
            }
        }
        /// <summary>
        /// Tests the tidal list.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TestTidalList(object sender, RoutedEventArgs e) {
            this.TestTidalList();
        }

        /// <summary>
        /// Loads the flares.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void LoadFlares(object sender, RoutedEventArgs e) {
            var path = @"c:\Private\SOLUTIONS-2020\PrivateWPF\AstroData2018\flares-cfi";
            var list = new List<FlareDay>();
            for (int year = 1966; year <= 2008; year++) {
                var filePath = Path.Combine(path, "cfi_daily_" + year.ToString() + ".txt");
                //// var fileContent = SupportFiles.FileToString(filePath);
                using (StreamReader sr = new StreamReader(filePath)) {
                    string line; int lineNum = 0;
                    while ((line = sr.ReadLine()) != null) {
                        if (string.IsNullOrWhiteSpace(line)) {
                            continue;
                        }

                        lineNum++;
                        if (lineNum > 5) {
                            var fday = new FlareDay(line);
                            list.Add(fday);
                        }
                    }
                }
            }
            //// ****
            var sumlist = new List<FlareDay>();
            int counter = 0;
            FlareDay sumfday = null;
            foreach (var fday in list) {
                counter++;
                if (counter == 1) {
                    sumfday = new FlareDay();
                    sumfday.DayInfo = fday.DayInfo;
                    sumfday.DayNumber = fday.DayNumber;
                }

                if (sumfday == null) {
                    continue;
                }

                sumfday.North += fday.North;
                sumfday.South += fday.South;
                sumfday.Total += fday.Total;

                if (counter == 15) {
                    sumlist.Add(sumfday);
                    counter = 0;
                }
            }

            var sb = new StringBuilder("");
            foreach (var fday in sumlist) {
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0,8:F0} \t{1,10} \t{2,7:F2} \t{3,7:F2} \t{4,7:F2} \n",
                                    fday.DayNumber, fday.DayInfo, fday.North, fday.South, fday.Total);
            }

            this.InfoText.Text = sb.ToString().Replace('.',',');
        }
    }
}

/* Unused variants
/// <summary>
/// Check Solar Max Approximations.
/// </summary>
private static void CheckSolarMaxApproximations() {
    SystemManager.SetJulianDate(Julian.JulYear(1337.0));
    var v1 = Interval.SolarMaxApproxValue(1337.0, 1);
    SystemManager.SetJulianDate(Julian.JulYear(1345.4));
    var v2 = Interval.SolarMaxApproxValue(1345.4, 1);
    SystemManager.SetJulianDate(Julian.JulYear(1957.9));
    var v3 = Interval.SolarMaxApproxValue(1957.9, 1);
    SystemManager.SetJulianDate(Julian.JulYear(1973.546));
    var v4 = Interval.SolarMaxApproxValue(1973.546, 1);
} 

//// this.EarthquakeDifferences();
//// ImportVolcanoes.InsertVolcanoes();
//// ImportVolcanoes.InsertVolcanoesData();
//// ImportBackgrounds.InsertEarthquakeBackgrounds();
//// ImportBackgrounds.InsertEruptionBackgrounds();

 * SELECT        Id, EruptionId, EarthquakeId, MoonDeclination, MoonAscension, SunDeclination, SunAscension, Place, Characteristic, EventTime
    FROM            EventBackground
    WHERE        (Characteristic LIKE '%Aspect EJ**%')
    ORDER BY Place

////ListEventBackgrounds(dc);
//// this.ListDiagrams();
   
 * SELECT Id, LocationId, Magnitude, Longitude, Latitude, EventTime
 *  FROM Earthquake
 *  WHERE (strftime('%Y', EventTime) = '2007')
 *  ORDER BY EventTime
         
double dateFrom = double.Parse(this.TBDateFrom.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
double dateTo = double.Parse(this.TBDateTo.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
//// EarthSystem.Influences = false;
DateList dateList = new DateList();
Interval interval = new Interval(dateList);
                    
//// 1 minutes precision
//// 17.3.757
interval.InitWith(dateFrom, dateTo, 1.00 / 24 / 60, 1, 0);
//// interval.SpecialDates(1);

interval.DateList.AddDates(dateFrom, dateTo, 1/365.25); //// 0.5 //// 0.1368955377
this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.EarthSystem);
            
            
var list = LoadQuakeml(path);
//// var list = DateList.EarthquakeDates;
interval.DateList.AddEarthquakeDates(list);
this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.EarthSystem, AstSystem.Earth);
            
//// this.InfoText.Text = 
string path = @"d:\Personal\Documents\UmeshVerma\Diagrams";
for (int year = 2010; year < 2011; year+=10) {
    StringBuilder sb = new StringBuilder();
    for (int shift = 0; shift < 10; shift++) {
        string s = interval.DateList.GenerateDiagrams(year+shift);
        sb.Append(s);
    }
    SupportFiles.StringToFile(sb.ToString(), Path.Combine(path, "diagram" + year.ToString() +"-"+ (year+10).ToString() + ".html"));
} 
 * 
 *             ////ListMayanDatesInRange(0, 15000000, 144000);
            ////ListMayanDatesInRange(144000*9, 144000*10, 780);
            ////ListMayanDatesInRange(1278390, 2000000, 364);

            //// this.ListMayanDatabase();

            //// ObserveMoonInYears();
            //// ListDresdenEclipses();
            //// InsertMayanDatesToDatabase();
            //// ListPotentialCorrelations();
            //// ListEquinoxesOfYear(179);
            //// ListAllMoonPhasesMayan();
            //// ListEquinoxesInCorrelations();
            //// ListMoonDatesInCorrelations();
            //// CheckSavedCorrelations();
            //// CheckCorrelationsInRange();
            //// ListMayanDatesInRange();
            //// CheckSolarMaxApproximations();
            //// ListSolarDates(dateFrom, dateTo, interval);
            //// 
            //// this.ListUniformTestDates(dateFrom, dateTo, 819);
            //// ListGivenCorrelations(); 

            //// SolarSystem.Earth.SetJulianDate(Julian.JulianDay(1,3,457));
            
            this.InfoText.Text = string.Empty;
            ListMayanDates(interval);
            
            StringBuilder text = new StringBuilder();
var correlations = (from tc in dc.TCorrelation
                   orderby tc.Number
                   select tc).ToList(); 

             
            interval.DateList.AddDates(dateFrom, dateTo, 1.0); //// 0.5
            this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.LghOuter);
*/