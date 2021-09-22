// <copyright file="WinBarycentre.xaml.cs" company="Largo">
// Copyright (c) 2009 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2009-01-01</date>
// <summary>Contains ...</summary>
namespace XAstro.Astro
{
    using LargoBaseAstronomy.Calendars;
    using LargoBaseAstronomy.Computation;
    using LargoBaseAstronomy.Enums;
    using LargoBaseAstronomy.Maths;
    using LargoBaseAstronomy.Orbits;
    using LargoBaseAstronomy.Systems;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Interact logic.
    /// </summary>
    public partial class WinBarycentre : Window
    {
        /// <summary>
        /// Measure constant.
        /// </summary>
        private const int MeasurePercent = 100;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WinBarycentre"/> class.
        /// </summary>
        public WinBarycentre()
        {
            this.InitializeComponent();
            this.TBDateFrom.Text = "1800,00";
            this.TBDateTo.Text = "2022,0";
            this.TBDrawFrom.Text = "1900,0";
            this.TBDrawTo.Text = "1960,0";
            this.AddAxes(Brushes.Black);
        }
        #endregion

        /// <summary>
        /// Tests the date list.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        public void TestDateList(object sender, RoutedEventArgs e)
        {
            SystemManager.CurrentSystem = AstSystem.Solar;
            var s = new SolarSystem(AstroSetup.vsopRootPath);
            //// SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            double dateFrom = double.Parse(this.TBDateFrom.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            double dateTo = double.Parse(this.TBDateTo.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            ////  SolarSystem.Singleton.Influences = false;
            DateList dateList = new DateList();
            Interval interval = new Interval(dateList);
            interval.InitWith(dateFrom, dateTo, 10, 1, 1);
            //// interval.DateList.AddDates(dateFrom, dateTo, 30/365.2422);  //// 30 days 
            //// interval.DateList.AddDates(dateFrom, dateTo, 15 / 365.2422);  //// 15 days = 0.04106863883746
            interval.DateList.AddDates(dateFrom, dateTo, 0.5);  //// 15 days = 0.04106863883746
            /*
            SolarSystem.Singleton.BarycentreBehavior.ResetCounters();
            SolarSystem.Singleton.GravicentreBehavior.ResetCounters();
            SolarSystem.Singleton.TidalExtremeBehavior.ResetCounters();
            */
            this.InfoText.Text = interval.DateList.PrintCharacteristic(AstCharacteristic.OrientedBaryAxis);
            /*
            SolarSystem.Singleton.BarycentreBehavior.ResetCounters();
            SolarSystem.Singleton.GravicentreBehavior.ResetCounters();
            SolarSystem.Singleton.TidalExtremeBehavior.ResetCounters();
            */
            this.OutputDateList(interval.DateList);
        }

        /// <summary>
        /// Tests the planet x by retrograde sun.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        public void TestPlanetXByRetrogradeSun(object sender, RoutedEventArgs e)
        {
            /*
            SystemManager.CurrentSystem = AstSystem.Solar;
            SolarSystem.Singleton.InitSolarSys(AlgVariant.VarBretagnon87, false, AstroSetup.vsopRootPath);
            EarthSystem.InitSystem(AstroSetup.vsopRootPath);
            double dateFrom = double.Parse(this.TBDateFrom.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            double dateTo = double.Parse(this.TBDateTo.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            SolarSystem.Singleton.Influences = false;

            for (int period = 300; period < 800; period += 10)
            {
                for (int phase = 0; phase < 360; phase += 10)
                {
                    var x= SolarSystem.Singleton.AdjustX(period, phase, 4.0f);
                    //// var sun = SolarSystem.Singleton.RebuildSun();


                    var jd = Julian.Date2Julian(new DateTime(1313, 1, 1));
                    SolarSystem.Singleton.SetJulianDate(jd);
                    //// x.SetJulianDate(jd);
                    sun.SetJulianDate(jd);
                    var sd1313 = Angles.Mod360Sym(sun.Longitude - SolarSystem.Singleton.Gravicentre.Longitude);
                    var ad1313 = Math.Abs(sd1313);
                    
                    jd = Julian.Date2Julian(new DateTime(1632, 1, 1));
                    SolarSystem.Singleton.SetJulianDate(jd);
                    sun.SetJulianDate(jd);
                    var sd1632 = Angles.Mod360Sym(sun.Longitude - SolarSystem.Singleton.Gravicentre.Longitude);
                    var ad1632 = Math.Abs(sd1632);
                    
                    jd = Julian.Date2Julian(new DateTime(1672, 1, 1));
                    SolarSystem.Singleton.SetJulianDate(jd);
                    sun.SetJulianDate(jd);
                    var sd1672 = Angles.Mod360Sym(sun.Longitude - SolarSystem.Singleton.Gravicentre.Longitude);
                    var ad1672 = Math.Abs(sd1672);
                    
                    jd = Julian.Date2Julian(new DateTime(1811, 1, 1));
                    SolarSystem.Singleton.SetJulianDate(jd);
                    sun.SetJulianDate(jd);
                    var sd1811 = Angles.Mod360Sym(sun.Longitude - SolarSystem.Singleton.Gravicentre.Longitude);
                    var ad1811 = Math.Abs(sd1811);
                    
                    jd = Julian.Date2Julian(new DateTime(1851, 1, 1));
                    SolarSystem.Singleton.SetJulianDate(jd);
                    sun.SetJulianDate(jd);
                    var sd1850 = Angles.Mod360Sym(sun.Longitude - SolarSystem.Singleton.Gravicentre.Longitude);
                    var ad1850 = Math.Abs(sd1850);
                    
                    jd = Julian.Date2Julian(new DateTime(1951, 1, 1));
                    SolarSystem.Singleton.SetJulianDate(jd);
                    sun.SetJulianDate(jd);
                    var sd1951 = Angles.Mod360Sym(sun.Longitude - SolarSystem.Singleton.Gravicentre.Longitude);
                    var ad1951 = Math.Abs(sd1951);
                    
                    jd = Julian.Date2Julian(new DateTime(1990, 7, 1));
                    SolarSystem.Singleton.SetJulianDate(jd);
                    sun.SetJulianDate(jd);
                    var sd1990 = Angles.Mod360Sym(sun.Longitude - SolarSystem.Singleton.Gravicentre.Longitude);
                    var ad1990 = Math.Abs(sd1990);

                    if ( ad1313 > 50 //// && ad1632 > 45 
                        && ad1672 > 50 
                        && ad1811 > 50  
                        && ad1850 < 90  
                        && ad1951 < 90 
                        && ad1990 < 90)
                    {
                        this.InfoText.Text += string.Format("{0}  {1} {2}  \n", period, phase, ad1990);
                    }
                }
            } */
        }

        /// <summary>
        /// Outputs the date list.
        /// </summary>
        /// <param name="dateList">The date list.</param>
        public void OutputDateList(DateList dateList)
        {
            Point lastPoint = new Point(0, 0);
            double drawFrom = double.Parse(this.TBDrawFrom.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            double drawTo = double.Parse(this.TBDrawTo.Text, System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            double jdrawFrom = Julian.JulYear(drawFrom);
            double jdrawTo = Julian.JulYear(drawTo);
            //// this.canvas1
            for (var i = 0; i < dateList.Date.Count; i++) {
                var julianDate = dateList.Date[i];
                var cdate = Julian.Year(julianDate);
                if (julianDate < jdrawFrom || julianDate > jdrawTo) {
                    continue;
                }

                SolarSystem.Singleton.SetJulianDate(julianDate);
                //// Systems.EarthSystem.SetJulianDate(julianDate);

                var point = new Point(1.5 * SolarSystem.Singleton.Sun.Point.XH / SolarSystem.Singleton.Sun.Body.Radius, 1.5 * SolarSystem.Singleton.Sun.Point.YH / SolarSystem.Singleton.Sun.Body.Radius);
                var brush = Brushes.Black;
                if (cdate > 1959 && cdate < 1961) {
                    brush = Brushes.Red;
                }

                if (cdate > 1939 && cdate < 1941) {
                    brush = Brushes.DeepSkyBlue;
                }

                if (cdate > 1919 && cdate < 1921) {
                    brush = Brushes.YellowGreen;
                }

                this.AddPoint(point, brush);

                if (lastPoint.X != 0 && lastPoint.Y != 0) {
                    this.AddLine(lastPoint, point, brush);
                }

                lastPoint = point;
            }
        }

        #region Canvas Graphic Support

        /// <summary>
        /// Adds the point.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="stroke">The stroke.</param>
        private void AddPoint(Point c1, Brush stroke)
        {
            const int size = 400;
            Ellipse elips = new Ellipse
            {
                Width = 5,
                Height = 5,
                Stroke = stroke
            };

            this.canvas1.Children.Add(elips);
            Canvas.SetLeft(elips, size + (c1.X * MeasurePercent));
            Canvas.SetTop(elips, size - (c1.Y * MeasurePercent));
        }

        /// <summary>
        /// Adds the line.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="stroke">The stroke.</param>
        private void AddLine(Point c1, Point c2, Brush stroke)
        {
            const int size = 400;
            this.canvas1.Children.Add(new Line
            {
                X1 = size + (c1.X * MeasurePercent),
                Y1 = size - (c1.Y * MeasurePercent),
                X2 = size + (c2.X * MeasurePercent),
                Y2 = size - (c2.Y * MeasurePercent),
                Stroke = stroke
            });
        }

        /// <summary>
        /// Adds the axes.
        /// </summary>
        /// <param name="stroke">The stroke.</param>
        private void AddAxes(Brush stroke)
        {
            var zero = new Point(0, 0);
            var one = new Point(1, 0);
            var onei = new Point(0, 1);
            var xpoint = new Point(4, 0);
            var xpointminus = new Point(-4, 0);
            var ypoint = new Point(0, 4);
            var ypointminus = new Point(0, -4);
            this.AddLine(zero, xpoint, stroke);
            this.AddLine(zero, xpointminus, stroke);
            this.AddLine(zero, ypoint, stroke);
            this.AddLine(zero, ypointminus, stroke);
            this.AddPoint(zero, stroke);
            /*
            for (int n = -4; n <= +4; n++)
            {
                var p = new Point(n, n);
                this.AddPoint(p, stroke);
            } */
        }

        /*
        /// <summary>
        /// Draws the Riemann function.
        /// </summary>
        /// <param name="baseNumber">The base number.</param>
        /// <param name="stroke">The stroke.</param>
        private void DrawRiemannFunction(int baseNumber, ComplexNumber u, ComplexNumber v, Brush stroke) {
            //// ComplexNumber eu = ComplexNumber.Exponential(u);
            //// ComplexNumber ev = ComplexNumber.Exponential(v);
            //// this.AddPoint(eu, Brushes.Blue);
            //// this.AddPoint(ev, Brushes.Green);
            //// this.AddLine(eu, er, Brushes.Blue);
            //// this.AddLine(ev, er, Brushes.Green);
        } */
        #endregion

        /// <summary>
        /// Tests the beats.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TestBeats(object sender, RoutedEventArgs e)
        {
            //// var list = new List<float>(DateList.SchoveMaxDates0);
            //// var list = new List<float>(DateList.SchoveMinDates0);            
            var list = new List<float>(DateList.SolarMaxDates);
            //// var list = new List<float>(DateList.SolarMinDates);
            //// list.RemoveAt(0);
            this.InfoText.Text = string.Empty;
            for (int shift = 1; shift < list.Count; shift++) {
                this.InfoText.Text += string.Format("\n***  {0,3}  *** \n\n", shift);
                for (int i = 0 + shift; i < list.Count; i++) {
                    var lastd = list[i - shift];
                    var d = list[i];
                    var t1 = d - lastd;
                    var t2 = 11.862 * shift;
                    var beat = (1 / (1 / t1 - 1 / t2)) / shift;
                    this.InfoText.Text += string.Format("({0,7:F2}...{1,7:F2}) ({2,7:F2},{3,7:F2}) => {4,10:F2} {5,10:F2} \n", 
                                lastd, d, t1, t2, beat, t1 + t2);
                }
            }
        }

        /// <summary>
        /// Tests the beats ratio.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        private void TestBeatsRatio(object sender, RoutedEventArgs e)
        {
            //// var list = new List<float>(DateList.SolarMaxDates);
            var list = new List<float>(DateList.SolarMinDates);
            //// list.RemoveAt(0);
            float lastd = 0;
            float lastd2 = 0;
            foreach (var d in list) {
                //// var t = d - lastd;
                var t1 = d - lastd;
                var t2 = lastd - lastd2;
                var beat = 1 / ((1 / t1) - (1 / t2));
                this.InfoText.Text += string.Format("({0,7:F2},{1,7:F2},{2,7:F2}) => {3,10:F2} \n", lastd2, lastd, d, beat);

                lastd2 = lastd;
                lastd = d;
            }
        }

        /// <summary>
        /// Tests the beats hale.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        private void TestBeatsHale(object sender, RoutedEventArgs e)
        {
            //// var list = new List<float>(DateList.SolarMaxDates);
            var list = new List<float>(DateList.SolarMinDates);
            list.RemoveAt(0);
            float lastd = 0;
            float lastd2 = 0;
            foreach (var d in list) {
                //// var t = d - lastd;
                var t = d - lastd2;
                var beat = 1 / ((1 / t) - (1 / 2.000 / 11.862));
                this.InfoText.Text += string.Format("({0,7:F2}-{1,7:F2}) =>  ({2,7:F2},23.724) = {3,10:F2} \n", d, lastd2, t, beat);

                lastd2 = lastd;
                lastd = d;
            }
        }

        /// <summary>
        /// Tests of the functions.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TestVukcevic(object sender, RoutedEventArgs e)
        {
            for (int t = 1925; t < 1965; t += 1) {
                var v1 = (t - 1937.4) / 19.859;
                var v2 = (t - 1934.1) / 23.724;
                var c1 = Angles.Cosin(360 * v1);
                var c2 = Angles.Cosin(360 * v2);
                this.InfoText.Text += string.Format(
                        "{0,7} ({1,7:F2} , {2,7:F2}) =>  {3,7:F2}  \n",
                        t, 
                        c1, 
                        c2, 
                        Math.Abs(c1 + c2));
            }
        }
    }
}
