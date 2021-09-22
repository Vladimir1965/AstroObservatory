// <copyright file="SolveMayan.cs" company="Largo">
// Copyright (c) 2009 All Right Reserved
// </copyright>
// <author> vl </author>
// <email></email>
// <date>2009-01-01</date>
// <summary>Contains ...</summary>
namespace XAstro.Astro {
    using JetBrains.Annotations;
    using LargoBaseAstronomy.Computation;
    using LargoBaseAstronomy.Records;
    using LargoBaseAstronomy.Systems;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Solve Mayan.
    /// </summary>
    public class SolveMayan {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SolveMayan"/> class.
        /// </summary>
        public SolveMayan()
        {
            this.ListGivenCorrelations();
            this.ListMayanDatesInRange(0, 0, 0);
            this.ListEquinoxesInCorrelations();
            this.CheckCorrelationsInRange();
            this.CheckSavedCorrelations();
            this.ListMoonDatesInCorrelations();
            this.ListAllMoonPhasesMayan();
            this.ListEquinoxesOfYear(2000);
            this.ListPotentialCorrelations();
            this.ListDresdenEclipses();
            this.ListMayanDates(null);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets The mayan correlation list.
        /// </summary>
        /// <value>
        /// The mayan correlation list.
        /// </value>
        public static List<MayanCorrelation> MayanCorrelationList { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        private string Text { get; set; }
        #endregion

        #region Public static methods
        /// <summary>
        /// Equinoxes the characteristic.
        /// </summary>
        /// <param name="mayanDate">The mayan date.</param>
        /// <param name="mayanShift">The mayan shift.</param>
        /// <returns> Returns value. </returns>
        public static string EquinoxCharacteristic(long mayanDate, long mayanShift) {
            //// const double MeanLunation = 29.5306;
            ////  const double MeanHalfLunation = MeanLunation / 2;
            double julianDate = mayanShift + mayanDate;
            double phase = AstroConfiguration.ComputeEquinoxPhase(julianDate, out var equinoxType); //// FullMoon
            double year = LargoBaseAstronomy.Calendars.Julian.Year(julianDate);
            double jdateresult = LargoBaseAstronomy.Abstract.EquinoxesAndSolstices.EquinoxSolstice(year, equinoxType);
            string cdate = LargoBaseAstronomy.Calendars.Julian.CalendarDate(jdateresult, false);
            string s = $"{Math.Round(phase, 1),6:F2} {equinoxType,-20} {cdate}";
            return s;
        }

        /// <summary>
        /// Checks the correlation.
        /// </summary>
        /// <param name="mayanShift">The mayan shift.</param>
        /// <returns> Returns value. </returns>
        public static bool CheckCorrelation(long mayanShift) {
            long n = (mayanShift - 14880) % 37960;
            if (n > 60 && n < 37900) {
                return false;
            }

            long mayanDate = LargoBaseAstronomy.Calendars.Julian.MayanDay(9, 16, 4, 11, 3);
            double julianDate = mayanShift + mayanDate;
            bool x = AstroConfiguration.IsFullMoon(julianDate, 5); ////5
            if (!x) {
                return false;
            }

            mayanDate = LargoBaseAstronomy.Calendars.Julian.MayanDay(9, 16, 12, 5, 17);
            julianDate = mayanShift + mayanDate;
            x = AstroConfiguration.IsEquinoxSolsticePoint(julianDate, 10); ////5
            if (!x) {
                return false;
            }

            julianDate = mayanShift + LargoBaseAstronomy.Calendars.Julian.MayanDay(9, 15, 9, 15, 14);
            x = AstroConfiguration.IsConjunction(SolarSystem.Singleton.Venus, SolarSystem.Singleton.Earth, julianDate, 20); ////15
            if (!x) {
                return false;
            }

            julianDate = mayanShift + LargoBaseAstronomy.Calendars.Julian.MayanDay(9, 9, 16, 3, 0);
            x = AstroConfiguration.IsAspect(SolarSystem.Singleton.Earth, SolarSystem.Singleton.Mars, julianDate, 45); ////30
            return x;
        }

        /// <summary>
        /// Lunar characteristic.
        /// </summary>
        /// <param name="mayanDate">The mayan date.</param>
        /// <param name="mayanShift">The mayan shift.</param>
        /// <returns> Returns value. </returns>
        public static string LunarCharacteristic(long mayanDate, long mayanShift) {
            //// const double MeanLunation = 29.5306;
            ////  const double MeanHalfLunation = MeanLunation / 2;
            double julianDate = mayanShift + mayanDate;
            double phase = AstroConfiguration.ComputeMoonPhase(julianDate, LargoBaseAstronomy.Enums.MoonPhase.NewMoon); //// FullMoon

            const double meanHalfEclipse = 173.31;
            const long anySolarEclipseDay = 1921240; //// 26.1.548
            double ediff = ((meanHalfEclipse * 1000) + julianDate - anySolarEclipseDay) % meanHalfEclipse;

            string s = $"{phase,6:F2} ({ediff,6:F2})";
            return s;
        }
        #endregion

        #region Private methods 1
        /// <summary>
        /// List Given Correlations.
        /// </summary>
        private void ListGivenCorrelations() {
            List<int> shifts = new List<int> { 508391, 584283, 622261 };
            MayanRecord r = new MayanRecord(9, 16, 4, 11, 3, string.Empty);
            foreach (int shift in shifts) {
                this.Text += $"{r.MayanDay} #{shift} {LunarCharacteristic(r.MayanDay, shift)}\n";
            }
        }

        /// <summary>
        /// List Mayan Dates In Range.
        /// </summary>
        /// <param name="mdayFrom">The Mayan Date from.</param>
        /// <param name="mdayTo">The Mayan Date to.</param>
        /// <param name="period">The period.</param>
        [UsedImplicitly]
        private void ListMayanDatesInRange(long mdayFrom, long mdayTo, int period) {
            const long shift = LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant;
            for (long mayanDay = mdayFrom; mayanDay < mdayTo; mayanDay += period) {
                long julianDate = mayanDay + shift;
                MayanRecord mr = new MayanRecord(mayanDay);
                //// this.InfoText.Text += string.Format("{0} #{1} {2,5:F2} {3} \n",
                ////    mayanDay, shift, mr.ToString(shift),  Julian.CalendarDate(julianDate, false)); 

                this.Text +=
                    $"{mr.ToString(LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant)}   {LargoBaseAstronomy.Calendars.Julian.CalendarDate(julianDate, false)}  {LargoBaseAstronomy.Calendars.Julian.Year(julianDate),7:F2} \n";
            }
        }

        /// <summary>
        /// Check Correlations In Range.
        /// </summary>
        [UsedImplicitly]
        private void CheckCorrelationsInRange() {
            for (int c = 390000; c < 680000; c++) {
                var x = CheckCorrelation(c);
                if (!x) {
                    continue;
                }

                this.Text += $"#{c} {(c - 14880) % 37960}\n";
            }
        }

        /// <summary>
        /// Check Saved Correlations.
        /// </summary>
        [UsedImplicitly]
        private void CheckSavedCorrelations() {
            var correlations = (from tc in SolveMayan.MayanCorrelationList
                                orderby tc.Number
                                select tc).ToList();
            foreach (var correlation in correlations) {
                var x = CheckCorrelation(correlation.Number);
                if (!x) {
                    continue;
                }

                this.Text +=
                    $"#{correlation.Number} {(correlation.Number - 14880) % 37960}  {correlation.Description}  {correlation.Round}\n";
            }
        }
        //// ------------------------------

        /// <summary>
        /// Lists the moon dates in correlations.
        /// </summary>
        [UsedImplicitly]
        private void ListMoonDatesInCorrelations() {
            var correlations = (from tc in SolveMayan.MayanCorrelationList
                                orderby tc.Number
                                select tc).ToList();
            var ds1 = LargoBaseAstronomy.Computation.DateList.MayanDatesMoon;
            foreach (var dr in ds1) {
                long mayanDay = dr.MayanDay;
                foreach (var correlation in correlations) {
                    long shift = correlation.Number;
                    double julianDate = shift + mayanDay;
                    if (julianDate < 1721045) {
                        continue;
                    }

                    this.Text +=
                        $"{mayanDay} #{shift} {LunarCharacteristic(mayanDay, shift)} {LargoBaseAstronomy.Calendars.Julian.CalendarDate(julianDate, false)} {dr.Info} \n";
                }

                this.Text += "\n";
            }
        }

        //// ------------------------------

        /// <summary>
        /// Lists the equinoxes in correlations.
        /// </summary>
        [UsedImplicitly]
        private void ListEquinoxesInCorrelations() {
            var correlations = (from tc in SolveMayan.MayanCorrelationList
                                orderby tc.Number
                                select tc).ToList();

            var ds2 = LargoBaseAstronomy.Computation.DateList.MayanDatesEquinox;
            foreach (var dr in ds2) {
                long mayanDay = dr.MayanDay;
                foreach (var correlation in correlations) {
                    long shift = correlation.Number;
                    double julianDate = shift + mayanDay;
                    if (julianDate < 1721045) {
                        continue;
                    }

                    this.Text +=
                        $"{mayanDay} #{shift} {EquinoxCharacteristic(mayanDay, shift)} {LargoBaseAstronomy.Calendars.Julian.CalendarDate(julianDate, false)} {dr.Info} \n";
                }

                this.Text += "\n";
            }
        }

        /// <summary>
        /// Lists all moon phases mayan.
        /// </summary>
        [UsedImplicitly]
        private void ListAllMoonPhasesMayan() {
            DateTime? lastdt = null;
            TimeSpan diff = new TimeSpan(0);
            for (int year = 571; year < 845; year++) {
                List<DateTime> list = LargoBaseAstronomy.Moons.MoonPhases.ListOfMoonPhases(LargoBaseAstronomy.Enums.MoonPhase.NewMoon, year);
                foreach (var dt in list) {
                    double d = LargoBaseAstronomy.Calendars.Julian.Date2Julian(dt);
                    if (lastdt != null) {
                        DateTime lastdtx = (DateTime)lastdt;
                        diff = dt.Subtract(lastdtx);
                    }

                    MayanRecord r = new MayanRecord((long)d - LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant);
                    this.Text += $"{r}  {diff.Days + (diff.Hours / 24.0),6:F2}  {dt} \n";
                    lastdt = dt;
                }
            }
        }

        /// <summary>
        /// Lists the equinoxes of year.
        /// </summary>
        /// <param name="year">A given year.</param>
        [UsedImplicitly]
        private void ListEquinoxesOfYear(double year) {
            double time1 = LargoBaseAstronomy.Abstract.EquinoxesAndSolstices.EquinoxSolstice(year, LargoBaseAstronomy.Enums.EquinoxType.VernalEquinox);
            double time2 = LargoBaseAstronomy.Abstract.EquinoxesAndSolstices.EquinoxSolstice(year, LargoBaseAstronomy.Enums.EquinoxType.SummerSolstice);
            double time3 = LargoBaseAstronomy.Abstract.EquinoxesAndSolstices.EquinoxSolstice(year, LargoBaseAstronomy.Enums.EquinoxType.AutumnalEquinox);
            double time4 = LargoBaseAstronomy.Abstract.EquinoxesAndSolstices.EquinoxSolstice(year, LargoBaseAstronomy.Enums.EquinoxType.WinterSolstice);
            this.Text += $"{time1} {time2} {time3} {time4}";
        }
        #endregion

        /* ListMayanDatabase
        /// <summary>
        /// Lists the mayan database.
        /// </summary>
        [UsedImplicitly]
        private void ListMayanDatabase()
        {
            this.InfoText.Text = string.Empty;
            var dc = DataBridgeAstronomy.GetAstronomyContext;
            var mdatesrt = (from md in dc.TMayanDate
                            //// where md.Description.Contains("SERP")
                            //// where md.Origin.Contains("new")
                            orderby md.Number
                            select md).ToList();
            const long shift = DateList.MayanCorrelationConstant;
            foreach (var mayaRecord in mdatesrt)
            {
                long mayanDay = mayaRecord.Number;
                double julianDate = shift + mayanDay;
                MayanRecord mr = new MayanRecord(mayanDay);
                //// MayanRecord mr = new MayanRecord(mayaRecord.Baktun,mayaRecord.Katun,mayaRecord.Tun,mayaRecord.Uinal,mayaRecord.Kin,mayaRecord.Description);
                //// long test780 = mayanDay % 780;
                //// if (test780 > 390) {
                ////     test780 -= 780;
                //// }

                //// if (Math.Abs(test780) > 0) {
                ////     continue;
                //// } 

                //// long test819 = (shift + mayanDay) % 819 - 609;
                //// if (Math.Abs(test819) > 6) {
                ////     continue;
                //// }
                ////  if (mr.Katun!= 0 && mr.Tun!=0) {
                ////      continue;
                ////  }

                //// bool x = AstroConfiguration.IsEquinoxSolsticePoint(julianDate, 50); ////5
                //// if (x) {
                    //// string characteristic = EquinoxCharacteristic(mayanDay, shift);
                    //// if (characteristic.Contains("Autumn")) { //// Winterm, Summer, Vernal, Autumn
                      ////   this.InfoText.Text += string.Format("{0} #{1} {2,5:F2} {3} {4} {5} \n",
                      ////                   mayanDay, shift, characteristic,
                      ////                   mr,
                      ////                   Julian.CalendarDate(julianDate, false),
                       ////                  mayaRecord.Description);
                     ////    this.InfoText.Text += "\n";
                    //// }
               ////  }

               ////  this.InfoText.Text += string.Format(
               ////                                  "{0}   {1}  {2,7:F2} \n",
               ////                                  mr.ToString(DateList.MayanCorrelationConstant),
              ////                                   Julian.CalendarDate(julianDate, false),
              ////                                   Julian.Year(julianDate));
                this.InfoText.Text += string.Format(
                                                "{0,-10} {1} {2,7:F2} {3} {4} {5} {6} \n",
                                                mr.ToString(DateList.MayanCorrelationConstant),
                                                Julian.CalendarDate(julianDate, false),
                                                Julian.Year(julianDate),
                                                mayaRecord.Description,
                                                mayaRecord.Origin,
                                                mayaRecord.Multiples,
                                                mayaRecord.AstroClass);
                this.InfoText.Text += "\n";
            }
        }
*/

        #region Private methods 2
        /// <summary>
        /// Lists the potential correlations.
        /// </summary>
        [UsedImplicitly]
        private void ListPotentialCorrelations() {
            LargoBaseAstronomy.Computation.DateList dateList = new LargoBaseAstronomy.Computation.DateList();
            Interval interval = new Interval(dateList);

            interval.CorrelationDates(546000, 546800, 1);
            this.Text = interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);

            interval.CorrelationDates(390000, 680000, 1);
            interval.CorrelationDates(508389, 508389, 1);
            this.Text = interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);

            //// interval.CorrelationDates(584285, 584285, 1);
            //// interval.CorrelationDates(508363, 508363, 5);
            //// interval.CorrelationDates(622258, 622261, 5);
            //// interval.CorrelationDates(560000, 640000, 1);
            //// interval.CorrelationDates(47000, 780000, 1);
            interval.CorrelationDates(390000, 680000, 1);
            this.Text = interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
        }

        /// <summary>
        /// Lists the dresden eclipses.
        /// </summary>
        [UsedImplicitly]
        private void ListDresdenEclipses() {
            MayanRecord mr = new MayanRecord(9, 16, 4, 10, 8, "eclipse");
            var distances = new[] { 177, 177, 148, 177, 177, 177, 178, 177, 177, 177, 177, 177,
                                148, 178, 177, 177, 177, 177, 148, 177, 177, 177, 178,
                                177, 177, 148, 177, 177, 178, 177, 177, 177, 177, 177, 177, 148, 178,
                                177, 177, 177, 177, 148, 177, 177, 177, 177, 177, 177, 148, 177, 177, 178,
                                177, 177, 177, 177, 177, 148, 177, 178,
                                177, 177, 177, 177, 148, 177, 177, 177, 177 };
            long mayanDay = mr.MayanDay;
            int c1 = 0;
            this.Text = string.Empty;
            double julianDate = LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant + mayanDay;
            this.Text += $"{0,5} {c1,5} {mr} {LargoBaseAstronomy.Calendars.Julian.CalendarDate(julianDate, false)} {0} \n";
            foreach (var d in distances) {
                c1 += d;
                long d1 = mayanDay + c1;
                MayanRecord mr1 = new MayanRecord(d1);
                julianDate = LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant + d1;
                double m = c1 % 173.31;
                if (m > 80) {
                    m = m - 173.31;
                }

                this.Text +=
                    $"{d,5} {c1,5} {mr1.ToString(LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant)} {LargoBaseAstronomy.Calendars.Julian.CalendarDate(julianDate, false)} {LargoBaseAstronomy.Calendars.Julian.Year(julianDate)} {Math.Round(m)} \n";
            }
        }

        /// <summary>
        /// Lists the mayan dates.
        /// </summary>
        /// <param name="interval">The interval.</param>
        [UsedImplicitly]
        private void ListMayanDates(Interval interval) {
            this.Text += "MayanDatesSerpent";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDatesSerpent, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant);
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            this.Text += "MayanDatesRJS(serpent)";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDatesRjs, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant);
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            this.Text += "MayanDatesMoon";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDatesMoon, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant);
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            this.Text += "MayanDates819";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDates819, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant);
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            this.Text += "MayanDatesGodK";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDatesGodK, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant);
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            this.Text += "MayanDatesEquinox";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDatesEquinox, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant);
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            this.Text += "MayanDatesFires";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDatesFires, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant);
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            this.Text += "MayanDatesJS";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDatesJS, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant);
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDatesEjs, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant); //// 0.5
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.MayanDates819, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant); //// 0.5
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
            this.Text += "\n--------------\n";
            interval.DateList = new LargoBaseAstronomy.Computation.DateList();
            interval.DateList.AddMayanDates(LargoBaseAstronomy.Computation.DateList.AllMayanDates, LargoBaseAstronomy.Computation.DateList.MayanCorrelationConstant); //// 0.5
            this.Text += interval.DateList.PrintCharacteristic(LargoBaseAstronomy.Enums.AstCharacteristic.DateDiffs);
        }
        #endregion
    }
}
