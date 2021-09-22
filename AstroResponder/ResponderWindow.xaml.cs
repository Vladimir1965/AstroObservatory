// <copyright file="ResponderWindow.xaml.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroResponder
{
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Enums;
    using AstroSharedClasses.Records;
    using AstroSharedEvents.Geology;
    using AstroSharedEvents.Lists;
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.Planets;
    using AstroSharedOrbits.Systems;
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Xml.Linq;

    /// <summary>
    /// Responder Window.
    /// </summary>
    public partial class ResponderWindow : Window
    {
        /// <summary>
        /// The date from
        /// </summary>
        private double dateFrom;

        /// <summary>
        /// The date to
        /// </summary>
        private double dateTo;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponderWindow"/> class.
        /// </summary>
        public ResponderWindow()
        {
            this.InitializeComponent();
            this.TBDateFrom.Text = "1750,0"; ////  "-3000,00"; "1749,00"; //// "1950,0";
            this.TBDateTo.Text = "2050,0"; //// "-2650,00"; "2020,0";   //// "2000,0";
        }
        #endregion

        #region Private methods - Bodies
        /// <summary>
        /// Lists the perihelia.
        /// </summary>
        public void ListPerihelia(Orbit orbit)
        {
            var kfrom = orbit.OrbitK(this.dateFrom);
            var kto = orbit.OrbitK(this.dateTo);
            for (long k = kfrom; k < kto; k++) {
                var julianDate = orbit.MeeusPerihelion(k);
                var s = string.Format(
                    "{0,8:F2} \t {1} \n",
                    Julian.Year(julianDate),
                    Julian.CalendarDate(julianDate, false));
                this.InfoText.Text += s;
            }
        }

        /// <summary>
        /// Lists the perihelia.
        /// </summary>
        public void ListAphelia(Orbit orbit)
        {
            var kfrom = orbit.OrbitK(this.dateFrom);
            var kto = orbit.OrbitK(this.dateTo);
            for (long k = kfrom; k < kto; k++) {
                var julianDate = orbit.MeeusAphelion(k);
                var s = string.Format(
                    "{0,8:F2} \t {1} \n",
                    Julian.Year(julianDate),
                    Julian.CalendarDate(julianDate, false));
                this.InfoText.Text += s;
            }
        }
        #endregion

        /// <summary>
        /// Lists the select data.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListSelectData(object sender, RoutedEventArgs e)
        {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            //// SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;

            this.dateFrom = double.Parse(this.TBDateFrom.Text, CultureInfo.CurrentCulture.NumberFormat);
            this.dateTo = double.Parse(this.TBDateTo.Text, CultureInfo.CurrentCulture.NumberFormat);
            AstCharacteristic result = AstCharacteristic.DateDiffs;
            var astTag = (string)((ComboBoxItem)this.outputBox1.SelectedItem).Tag;
            if (!Enum.TryParse(astTag, out result)) {
                result = AstCharacteristic.DateDiffs;
            }

            var tabTag = (string)((TabItem)this.tabControl1.SelectedItem).Tag;
            switch (tabTag) {
                case "Raster": {
                        var eventList = this.GetEventList();
                        this.InfoText.Text = eventList.PrintCharacteristic(result);
                        break;
                    }

                case "Bodies": {
                        var name = (string)((ComboBoxItem)this.bodyBox1.SelectedItem).Tag;
                        var orbit = SolarSystem.Singleton.FindOrbit(name);
                        if (orbit != null) {
                            switch ((string)((ComboBoxItem)this.singlActionBox.SelectedItem).Tag) {
                                case "1":
                                    this.ListPerihelia(orbit);
                                    break;
                                case "2":
                                    this.ListAphelia(orbit);
                                    break;
                            }
                        }

                        break;
                    }

                case "Crossing":
                    var name1 = (string)((ComboBoxItem)this.crossBodyBox1.SelectedItem).Tag;
                    var orbit1 = SolarSystem.Singleton.FindOrbit(name1);
                    var name2 = (string)((ComboBoxItem)this.crossBodyBox2.SelectedItem).Tag;
                    var orbit2 = SolarSystem.Singleton.FindOrbit(name2);
                    if (orbit1 != null && orbit2 != null) {
                        SystemManager.CurrentSystem = AstSystem.Solar;
                        EventList dateList = new EventList();
                        Interval interval = new Interval(dateList);
                        interval.InitWith(this.dateFrom, this.dateTo, 10, 1, 100);

                        byte crossingType = 1; //// crossingBox
                        interval.ConfigurationDates(crossingType, orbit1, orbit2);
                        this.InfoText.Text = interval.DateList.PrintCharacteristic(result);
                    }
                    break;

                case "Events": {
                        switch ((string)((ComboBoxItem)this.typeBox.SelectedItem).Tag) {
                            case "1":
                                this.ListVolcanoes();
                                break;
                            case "2":
                                this.ListEarthquakes();
                                break;
                            case "6":
                                this.VolcanoesAfterEarthquakes();
                                break;
                        }

                        break;
                    }


                case "Resonance": {
                        this.ListResonances();
                        break;
                    }

                case "Uniform": {
                        switch ((string)((ComboBoxItem)this.typeBox.SelectedItem).Tag) {
                            case "1":
                                this.ListVolcanoes();
                                break;
                            case "2":
                                this.ListEarthquakes();
                                break;
                            case "6":
                                this.VolcanoesAfterEarthquakes();
                                break;
                        }

                        break;
                    }

                default:
                    break;
            }
        }

        #region Private methods - DateLists
        private EventList GetEventList() {
            EventList dateList = new EventList();
            Interval interval = new Interval(dateList);

            if ((string)((TabItem)this.tabControl1.SelectedItem).Tag != "Raster") {
                return null; 
            }

            switch ((string)((ComboBoxItem)this.bodyPeriodBox.SelectedItem).Tag) {
                case "Ten years":
                    interval.DateList.AddDates(this.dateFrom, this.dateTo, 10.000);
                    break;
                case "Years":
                    interval.DateList.AddDates(this.dateFrom, this.dateTo, 1.000);
                    break;
                case "Months":
                    interval.DateList.AddDates(this.dateFrom, this.dateTo, 1.000 / 12);
                    break;
                case "Weeks":
                    interval.DateList.AddDates(this.dateFrom, this.dateTo, 7.000 / 365.2422);
                    break;
                case "Days":
                    interval.DateList.AddDates(this.dateFrom, this.dateTo, 1.000 / 365.2422);
                    break;
                case "Solar maxima":
                    interval.DateList.AddSelectedDates(EventList.SchoveMaxDates, this.dateFrom, this.dateTo);
                    break;
                case "Solar minima":
                    interval.DateList.AddSelectedDates(EventList.SchoveMaxDates, this.dateFrom, this.dateTo);
                    break;                 
                case "Mayan dates":
                    interval.DateList.AddSelectedDates(EventList.AllMayanDates, this.dateFrom, this.dateTo);
                    break;
            }

            return interval.DateList;
        }

       #endregion

       #region Private methods - Events
            /// <summary>
            /// Lists the volcanoes.
            /// </summary>
            private void ListVolcanoes()
        {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            SystemManager.SetEnabled(true);

            var sv = new SolveVolcanoes();
            sv.LoadFromXml();
            sv.PassVolcanoes();
            this.InfoText.Text = sv.Text;
        }

        /// <summary>
        /// Lists the earthquakes.
        /// </summary>
        private void ListEarthquakes()
        {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            SystemManager.SetEnabled(true);

            var se = new SolveEarthquakes();
            se.LoadFromXml();
            se.PassEarthquakes();
            this.InfoText.Text = se.Text;
        }


        /// <summary>
        /// Tests volcanoes after earthquakes.
        /// </summary>
        private void VolcanoesAfterEarthquakes()
        {
            //// TestKalendaRule2
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

                var gr = new GeoRecord('V', r.StartDay, r.StartMonth, r.StartYear, r.VolcanoName + " #" + r.VEI.ToString() + " (" + r.Duration.ToString() + ")");
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

        #endregion

        #region Private methods - Resonances

        /// <summary>
        /// Lists the resonances.
        /// </summary>
        private void ListResonances()
        {
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

            this.InfoText.Text += s0; //// + s1 + s2 + s3 + s4 + s5; ////  +s8 + s16;

            //// string s = Resonances.Resonant(4, false, 10000, 10000000, 224.701, 365.256, 4332.67, 2 * 4054.1);
        }

        #endregion

        #region Private methods - Loading
        /// <summary>
        /// Load the volcanoes.
        /// </summary>
        private void LoadVolcanoes()
        {
            var sv = new SolveVolcanoes();
            sv.LoadFromXls();
            sv.StoreToXml();
        }

        /// <summary>
        /// Load the earthquakes.
        /// </summary>
        private void LoadEarthquakes()
        {
            var se = new SolveEarthquakes();
            se.LoadFromQuakeml();
            se.StoreToXml();
        }

        /// <summary>
        /// Loads the flares.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void LoadFlares(object sender, RoutedEventArgs e)
        {
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

            var sb = new StringBuilder();
            foreach (var fday in sumlist) {
                sb.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "{0,8:F0} \t{1,10} \t{2,7:F2} \t{3,7:F2} \t{4,7:F2} \n",
                                    fday.DayNumber,
                                    fday.DayInfo,
                                    fday.North,
                                    fday.South,
                                    fday.Total);
            }

            this.InfoText.Text = sb.ToString().Replace('.', ',');
        }
        #endregion

        /// <summary>
        /// Special List.
        /// </summary>
        /// <param name="givenAstroType">Type of the given system.</param>
        [UsedImplicitly]
        private void SpecialList(string givenAstroType)
        { //// byte action
            SystemManager.CurrentSystem = AstSystem.Solar;
            EventList dateList = new EventList();
            Interval interval = new Interval(dateList);
            interval.InitWith(this.dateFrom, this.dateTo, 10, 1, 100);
            //// interval.InitWith(dateFrom, dateTo, 1, 1, 100);
            interval.SpecialDates(givenAstroType);
        }

        /// <summary>
        /// Tests the tidal list.
        /// </summary>
        private void TestTidalList()
        {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;

            EventList dateList = new EventList();
            Interval interval = new Interval(dateList);
            interval.InitWith(this.dateFrom, this.dateTo, 3, 1, 1);

            //// Alignment
            interval.DateList.AddDates(this.dateFrom, this.dateTo, 30 / 365.25);
            //// interval.InitWith(dateFrom, dateTo, 5, 1, 15); 
            //// interval.SpecialDates("Quadra");

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
        private void TestDateList()
        {
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

            EventList dateList = new EventList();
            Interval interval = new Interval(dateList);
            //// interval.InitWith(dateFrom, dateTo, 1*365.25, 1, 1);
            interval.InitWith(dateFrom, dateTo, 30, 1, 1);

            //// interval.DateList.AddSelectedDates(DateList.SolarMaxDates, dateFrom, dateTo);
            //// interval.DateList.AddSelectedDates(DateList.SchoveMaxDates, dateFrom, dateTo);
            //// interval.DateList.AddDates(dateFrom, dateTo, 115.1/2); //// 10.0,  0.5, /2

            //// interval.DateList.AddDates(dateFrom, dateTo, 3.00 / 365.25); // 30
            //// interval.DateList.AddDates(dateFrom, dateTo, 15.00 / 365.25); // 30
            ////  interval.DateList.AddDates(dateFrom, dateTo, 1.00 / 10.00); // 30
            interval.DateList.AddDates(dateFrom, dateTo, 1.0 / 1.0); //// 10*365.25 / 365.25

            SolarSystem.Singleton.Jupiter.Enabled = true;
            SolarSystem.Singleton.Saturn.Enabled = true;
            SolarSystem.Singleton.Uranus.Enabled = true;
            SolarSystem.Singleton.Neptune.Enabled = true;

            #warning Initialization
            ////            interval.DateList.RunningTotalPeriod = 0;
            ////            interval.DateList.RunningNumberOfPeriods = 0;

            this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffs);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffsOuter);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.OrientedBaryAxis);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.Experiment);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffsZharkova);

            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(.AstCharacteristic.OrientedBaryAxis); ////  AstSystem.Solar
        }

        /// <summary>
        /// Lists the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TestSolarSystem(object sender, RoutedEventArgs e)
        {
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            //// SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            SystemManager.CurrentSystem = AstSystem.Solar;
            //// SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87,  false,  AstroSetup.vsopRootPath); //// AlgVariant.VarBretagnon82
            //// DataLink.InitDataLink();

            //// SolarSystem.Singleton.Influences = false;
            //// DateList dateList = new DateList();
            //// Interval interval = new Interval(dateList);
            //// this.ListSpecialDates(dateFrom, dateTo, "Sun-Moon-E-J"); //// Sun-E-Moon-J
            //// this.ListSpecialDates(dateFrom, dateTo, "J-Sun-E-Moon"); //// J-Sun-Moon-E            
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffs); //// AstSystem.Solar
            //// ListEarthQuakes()

            this.ListSpecialDates("Quadra");
            //// this.ListSpecialDates(dateFrom, dateTo, "PlanetX");
        }

        #region Private methods
        /// <summary>
        /// List Special Dates.
        /// </summary>
        /// <param name="givenAstroType">Type of the given system.</param>
        private void ListSpecialDates(string givenAstroType)
        {
            EventList dateList = new EventList();
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
            interval.InitWith(this.dateFrom, this.dateTo, 30, 1, 180); //// 30, 1, 120 / 10,1,30
            //// interval.InitWith(dateFrom, dateTo, 15, 1, 15); //// 10,1,30
            //// interval.InitWith(dateFrom, dateTo, 30, 1, 180); //// 10,1,30
            //// interval.InitWith(dateFrom, dateTo, 30, 10, 90); //// 30,1,360 //// 10,1,30 //// 30,1,90

            interval.SpecialDates(givenAstroType);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.LghInner);
            //// this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.LghOuter);
            this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.DateDiffs); //// AstSystem.Solar
            ////xxxx interval.DateList.WriteToAstroEvents(givenAstroType);
        }
        #endregion

    }
}