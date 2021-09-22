// <copyright file="Interval.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Lists
{
    using AstroSharedEvents.Crossing;
    using AstroSharedOrbits.Dwarfs;
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.Systems;
    using global::AstroSharedClasses.Calendars;
    using global::AstroSharedClasses.Computation;
    using global::AstroSharedClasses.Enums;
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Interval of events.
    /// </summary>
    public sealed class Interval : Constellation
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class.
        /// </summary>
        /// <param name="dateList">The date list.</param>
        public Interval(EventList dateList)
        {
            this.DateList = dateList;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Date List.
        /// </summary>
        /// <value> Property description. </value>
        public EventList DateList { get; set; }

        /// <summary>
        /// Gets or sets Date From.
        /// </summary>
        private double DateFrom { get; set; }    //// Julian Date 

        /// <summary>
        /// Gets or sets Date To.
        /// </summary>
        private double DateTo { get; set; }    //// Julian Date 

        /// <summary>
        /// Gets or sets Deg Eps.
        /// </summary>
        private double DegEps { get; set; }

        /// <summary>
        /// Gets or sets Skip Days.
        /// </summary>
        /// <value>
        /// The skip days.
        /// </value>
        private double SkipDays { get; set; }

        /// <summary>
        /// Gets or sets Step Days.
        /// </summary>
        private double StepDays { get; set; }    //// Julian Date step 
        #endregion
        //// Difference epsilon [degrees] 

        //// Julian Date skip  
        #region Static methods
        /// <summary>
        /// Is Limit Function.
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsLimitFunction(double date)
        {
            const double value = 0;
            SolarSystem.Singleton.Jupiter.SetJulianDate(date);
            //// Saturn.SetJulianDate(date);  Uranus.SetJulianDate(date);   Neptune.SetJulianDate(date); 
            //// Value = Jupiter.AngularMomentum()+Saturn.AngularMomentum()+Uranus.AngularMomentum()+Neptune.AngularMomentum();
            //// printf("%f, ",F);
            return value > 3.2e46; // <10.2
        }
        #endregion

        #region Methods
        /// <summary>
        /// Configurations dates.
        /// </summary>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="accuracy">If set to <c>true</c> [accuracy].</param>
        [UsedImplicitly]
        public void ConfigurationDates(byte actionType, Orbit orbitA, Orbit orbitB) //// , bool accuracy
        {
            this.StepDays = Math.Ceiling(Math.Min(orbitA.MeanPeriod, orbitB.MeanPeriod) * 365.0 / 100.0);
            this.SkipDays = this.StepDays * 10;
            this.DegEps = 1.0;

            double julianDate;
            for (julianDate = this.DateFrom; julianDate <= this.DateTo; julianDate = julianDate + this.StepDays) {
                SystemManager.SetJulianDate(julianDate);
                var result = this.EvaluateConfiguration(actionType, orbitA, orbitB, julianDate);

                if (!result) {
                    continue;
                }

                this.DateList.AddDate(julianDate);
                julianDate = julianDate + this.SkipDays;
            }
        }

        /// <summary>
        /// Correlations the dates.
        /// </summary>
        /// <param name="shiftFrom">The shift from.</param>
        /// <param name="shiftTo">The shift to.</param>
        /// <param name="shiftStep">The shift step.</param>
        [UsedImplicitly]
        public void CorrelationDates(long shiftFrom, long shiftTo, int shiftStep)
        {
            SystemManager.SetEnabled(true);
            for (var shift = shiftFrom; shift <= shiftTo; shift = shift + shiftStep) {
                var ok = ValidCorrelation(shift);
                if (!ok) {
                    continue;
                }

                double julianDate = shift;
                this.DateList.AddDate(julianDate);
                //// julianDate = julianDate + this.SkipDays;
            }
        }

        /// <summary>
        /// Dresden Codex Dates.
        /// </summary>
        [UsedImplicitly]
        public void DresdenCodexDates()
        {
            SystemManager.SetEnabled(true);
            for (var julianDate = this.DateFrom; julianDate <= this.DateTo; julianDate = julianDate + this.StepDays) {
                var ok = this.ValidDresdenCodex(julianDate);
                if (!ok) {
                    continue;
                }

                this.DateList.AddDate(julianDate);
                julianDate = julianDate + this.SkipDays;
            }
        }

        /// <summary>
        /// Init With.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="stepDays">The step days.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <param name="skipDays">The skip days.</param>
        [UsedImplicitly]
        public void InitWith(
                        double dateFrom,
                        double dateTo,
                        double stepDays,
                        double epsilon,
                        double skipDays)
        {
            this.DateFrom = Julian.JulYear(dateFrom);
            this.DateTo = Julian.JulYear(dateTo);
            this.StepDays = stepDays;
            this.DegEps = epsilon;
            this.SkipDays = skipDays;
        }

        /// <summary>
        /// Init With JulDate.
        /// </summary>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="stepDays">The step days.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <param name="skipDays">The skip days.</param>
        [UsedImplicitly]
        public void InitWithJulDate(
                        double dateFrom,
                        double dateTo,
                        double stepDays,
                        double epsilon,
                        double skipDays)
        {
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.StepDays = stepDays;
            this.DegEps = epsilon;
            this.SkipDays = skipDays;
        }

        /// <summary>
        /// Special Dates.
        /// </summary>
        /// <param name="givenAstroType">Type of the given astro.</param>
        [UsedImplicitly]
        public void SpecialDates(string givenAstroType)
        {
            SystemManager.SetEnabled(true);
            for (var julianDate = this.DateFrom; julianDate <= this.DateTo; julianDate = julianDate + this.StepDays) {
                var ok = ValidSpecialDate(givenAstroType, julianDate);
                if (!ok) {
                    continue;
                }

                this.DateList.AddDate(julianDate);
                julianDate = julianDate + this.SkipDays;
            }
        }

        /// <summary>
        /// Special Sumation.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public float SpecialSumation()
        { //// float phaseShift
            float sum = 0;
            //// SolarSystem.X.NormElements._VM[0] = phaseShift;
            SystemManager.SetEnabled(true);
            var r = new Relation();
            for (var julianDate = this.DateFrom; julianDate <= this.DateTo; julianDate = julianDate + this.StepDays) {
                SolarSystem.Singleton.Jupiter.SetJulianDate(julianDate);
                SolarSystem.Singleton.Saturn.SetJulianDate(julianDate);
                SolarSystem.Singleton.Uranus.SetJulianDate(julianDate);
                SolarSystem.Singleton.Neptune.SetJulianDate(julianDate);
                SolarSystem.Singleton.PlanetX.SetJulianDate(julianDate);
                r.SetBodies(SolarSystem.Singleton.Jupiter, SolarSystem.Singleton.PlanetX);
                var value = (float)(SolarSystem.Singleton.Jupiter.Body.Mass / r.DiffR);
                sum = sum + value;
                r.SetBodies(SolarSystem.Singleton.Saturn, SolarSystem.Singleton.PlanetX);
                value = (float)(SolarSystem.Singleton.Saturn.Body.Mass / r.DiffR);
                sum = sum + value;
                r.SetBodies(SolarSystem.Singleton.Uranus, SolarSystem.Singleton.PlanetX);
                value = (float)(SolarSystem.Singleton.Uranus.Body.Mass / r.DiffR);
                sum = sum + value;
                r.SetBodies(SolarSystem.Singleton.Neptune, SolarSystem.Singleton.PlanetX);
                value = (float)(SolarSystem.Singleton.Neptune.Body.Mass / r.DiffR);
                sum = sum + value;
            }

            return sum;
        }

        #region Private static methods
        /// <summary>
        /// Valid Special Date.
        /// </summary>
        /// <param name="givenAstroType">Type of the given astro.</param>
        /// <param name="julianDate">The julianDate.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static bool ValidSpecialDate(string givenAstroType, double julianDate)
        {
            var result = false;
            bool x1;
            ////this.StepDays = 10; this.SkipDays = 20;
            //// SystemManager.SetJulianDate(date);
            var infoDate = Julian.CalendarDate(julianDate, false);
            if (infoDate.Equals("xxx")) {
                return false;
            }

            SolarSystem.Singleton.SetJulianDate(julianDate);
            //// SolarSystem.Earth.SetJulianDate(date);
            //// SolarSystem.Venus.SetJulianDate(date);

            switch (givenAstroType) {
                case "Quadra": {
                        var Ln = SolarSystem.Singleton.Neptune.Longitude;
                        var Lu = SolarSystem.Singleton.Uranus.Longitude;
                        var Ls = SolarSystem.Singleton.Saturn.Longitude;
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                        var Lp = BodyPluto.EclipticLongitude(julianDate);
                        var Lr = SolarSystem.Singleton.Mars.Longitude;
                        var Le = SolarSystem.Singleton.Earth.Longitude;
                        var Lv = SolarSystem.Singleton.Venus.Longitude;
                        var Lm = SolarSystem.Singleton.Mercury.Longitude;
                        var Ljp = SolarSystem.Singleton.Jupiter.LP;

                        var Lx = SolarSystem.Singleton.PlanetX.Longitude;

                        //// eruptions?
                        result = Constellation.IsConjunction(Lj, Ls, 45.0)
                                   ////   && Constellation.IsOpposition(Le, Lu, 20.0)
                                   && ((Constellation.IsRightAngle(Ls, Lu, 25.0) && Constellation.IsRightAngle(Lj, Lu, 25.0))
                                   || (Constellation.IsRightAngle(Ls, Ln, 25.0) && Constellation.IsRightAngle(Lj, Ln, 25.0)))
                                    && (Constellation.IsAspect(Le, Lu, 10.0) || Constellation.IsAspect(Le, Ln, 10.0));
                    }

                    break;

                case "Quadra1": {
                        var Ljp = SolarSystem.Singleton.Jupiter.LP;
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                        var Ls = SolarSystem.Singleton.Saturn.Longitude;
                        var Lu = SolarSystem.Singleton.Uranus.Longitude;
                        var Ln = SolarSystem.Singleton.Neptune.Longitude;
                        /*
                        var alpha = Angles.Mod180(Lu - Ln - 90);
                        var beta = Angles.Mod180(Lj - Ls - 90);
                        result = Angles.EqualDeg(alpha, 0, 30) && Angles.EqualDeg(beta, 0, 15);
                        */

                        var alpha = Angles.Mod360(Lu - Ln - 120);
                        var alpha2 = Angles.Mod360(Lu - Ln + 120);
                        //// var beta = Angles.Mod360(Lj - Ls - 120);
                        result = Angles.EqualDeg(alpha, 0, 10) || Angles.EqualDeg(alpha2, 0, 10);
                    }

                    break;
                case "Quadra2": {
                        var Ljp = SolarSystem.Singleton.Jupiter.LP;
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                        var Ls = SolarSystem.Singleton.Saturn.Longitude;
                        var Lsp = SolarSystem.Singleton.Saturn.LP;
                        var Lu = SolarSystem.Singleton.Uranus.Longitude;
                        var Ln = SolarSystem.Singleton.Neptune.Longitude;
                        var Lv = SolarSystem.Singleton.Venus.Longitude;
                        var Le = SolarSystem.Singleton.Earth.Longitude;

                        var alpha = Angles.Mod180(Lj - Lu - 90);
                        var beta = Angles.Mod180(Lj - Ln - 90);
                        //// var beta = Angles.Mod180((Ls - Lsp)/2);
                        //// var beta = Angles.Mod180(Lj - Lv);
                        //// var gama = Angles.Mod180(Lj - Le);
                        //// var alpha = Angles.Mod180(Lj - Ls - 90);
                        //// var alpha = Angles.Mod180(Lu - Ln - 90);
                        //// var beta = Angles.Mod180((Lj - Ljp)/2);
                        //// var Lo = SolarSystem.Singleton.Outercentre.Longitude;
                        //// var alpha = Angles.Mod180(Ls - Lo + 120);
                        result = Angles.EqualDeg(alpha, 0, 15) && Angles.EqualDeg(beta, 0, 15);
                        ////  && Angles.EqualDeg(beta, 0, 20) && Angles.EqualDeg(gama, 0, 20);
                    }

                    break;

                case "Maunder": {
                        var Ljp = SolarSystem.Singleton.Jupiter.LP;
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                        var Ls = SolarSystem.Singleton.Saturn.Longitude;
                        var d1 = Angles.Mod360(Lj - Ljp);
                        var d2 = Angles.Mod180(Lj - Ls);

                        result = Angles.EqualDeg(d1, 0, 20) && Angles.EqualDeg(d2, 90, 20);
                        //// result = (Angles.EqualDeg(d1, 180, 20) && Angles.EqualDeg(d2, 90, 20));
                        //// result = (Angles.EqualDeg(d1, 180, 20) && Angles.EqualDeg(d2, 0, 20));
                        //// result = (Angles.EqualDeg(d1, 0, 20) && Angles.EqualDeg(d2, 0, 20));

                        //// result = Constellation.IsOpposition(Ls, Ln, 2.0);
                        //// result = Constellation.IsConjunction(Lj, Lx, 2.0);
                    }

                    break;

                case "PlanetX": {
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                        var Ljp = SolarSystem.Singleton.Jupiter.LP;
                        var Ls = SolarSystem.Singleton.Saturn.Longitude;
                        var Lu = SolarSystem.Singleton.Uranus.Longitude;
                        var Lup = SolarSystem.Singleton.Uranus.LP;
                        var Ln = SolarSystem.Singleton.Neptune.Longitude;
                        var Lp = BodyPluto.EclipticLongitude(julianDate);
                        var Lx = SolarSystem.Singleton.PlanetX.Longitude;

                        result = Constellation.IsConjunction(Lj, Lx, 10.0) && Constellation.IsConjunction(Ls, Lx, 20.0);
                    }

                    break;

                case "Solar-Impulses": {
                        //// long jdatelong = (long)julianDate;  result = jdatelong % 30 < 10;
                        var Lv = SolarSystem.Singleton.Venus.Longitude;
                        var Le = SolarSystem.Singleton.Earth.Longitude;
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Jupiter.LP;
                        var a = Angles.Mod180Sym(3 * Lv - 5 * Le + 2 * Lj);
                        result = Math.Abs(a) < 5;
                    }

                    break;

                case "Resonance":
                    result = Constellation.IsOrbitalResonance(2, SolarSystem.Singleton.Jupiter, -3, SolarSystem.Singleton.Saturn, +1, SolarSystem.Singleton.Neptune, 45, 180, julianDate, 10.0);
                    break;

                case "MoonTest":
                    EarthSystem.SetJulianDate(julianDate);
                    var declination = Angles.NormalSymmetricAngle360(EarthSystem.Moon.Declination);
                    //// var ra = Angles.EqualDeg(SolarSystem.Earth.Longitude, EarthSystem.Moon.EclipticLongitude, 5.0);
                    //// Constellation.IsRightAngle(SolarSystem.Earth.Longitude, EarthSystem.Moon.EclipticLongitude, 20.0);
                    result = declination < -10; ////  && ra;
                    break;

                case "SolarApprox1":
                    result = Constellation.IsConjunction(SolarSystem.Singleton.Jupiter.Longitude + SolarSystem.Singleton.Uranus.Longitude - SolarSystem.Singleton.Neptune.Longitude, SolarSystem.Singleton.Jupiter.LP - 180.0, 5.0); //// 0.3
                    break;

                case "SolarApprox2":
                    result = Constellation.IsConjunction(SolarSystem.Singleton.Jupiter.Longitude + SolarSystem.Singleton.Uranus.Longitude - SolarSystem.Singleton.Neptune.Longitude, SolarSystem.Singleton.Jupiter.LP, 5.0); //// 0.3
                    break;

                case "SolarApproxWithCorrection":
                    var deltaUN = SolarSystem.Singleton.Neptune.Longitude - SolarSystem.Singleton.Uranus.Longitude;
                    ////  var correction = 0; 
                    var x = Angles.Cosin(2 * deltaUN);
                    var correction = 120 * x * Math.Abs(x);
                    var deltaJJa = SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Jupiter.LP - 180;

                    result = Constellation.IsConjunction(deltaUN + correction, deltaJJa, 5.0); //// 0.3
                    break;

                case "SolarApproxTest":
                    //// var angle = (3 * (SolarSystem.Jupiter.Longitude) - 8 * (SolarSystem.Saturn.Longitude));
                    //// result = IsConjunction(angle, 0, 3.0); //// 0.3
                    var angle = 3 * SolarSystem.Singleton.Jupiter.Longitude - 8 * SolarSystem.Singleton.Saturn.Longitude
                                  - SolarSystem.Singleton.Uranus.Longitude + 5 * SolarSystem.Singleton.Neptune.Longitude - SolarSystem.Singleton.Jupiter.LP;
                    result = Constellation.IsConjunction(angle, 180, 2.0); //// 0.3
                    //// var angle = SolarSystem.Jupiter.Longitude - SolarSystem.Jupiter.LP  - 2 * (SolarSystem.Saturn.Longitude) + SolarSystem.Neptune.Longitude;
                    //// result = IsConjunction(4*angle,  0 , 2.0); //// angle, 2*angle, 0.3
                    break;

                case "SolarApproxAxis":
                    var axisSU = Angles.AxisOf(SolarSystem.Singleton.Uranus.Longitude, SolarSystem.Singleton.Saturn.Longitude);
                    var axisJN = Angles.AxisOf(SolarSystem.Singleton.Neptune.Longitude, SolarSystem.Singleton.Jupiter.Longitude);
                    result = Constellation.IsRightAngle(axisSU, axisJN, 1.0); //// MINIMA
                    //// result = IsDiagonalAngle(axisSU, axisJN, 1.0); //// MAXIMA
                    break;

                case "Sun-Moon-E-J":
                    EarthSystem.SetJulianDate(julianDate);
                    x1 = Constellation.IsConjunction(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Earth.Longitude, 30.0);
                    if (x1) {
                        result = Constellation.IsOpposition(SolarSystem.Singleton.Earth.Longitude, EarthSystem.Moon.EclipticLongitude, 15.0);
                    }

                    break;

                case "Sun-E-Moon-J":
                    EarthSystem.SetJulianDate(julianDate);
                    x1 = Constellation.IsConjunction(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Earth.Longitude, 30.0);
                    if (x1) {
                        result = Constellation.IsConjunction(SolarSystem.Singleton.Earth.Longitude, EarthSystem.Moon.EclipticLongitude, 15.0);
                    }

                    break;

                case "J-Sun-Moon-E":
                    EarthSystem.SetJulianDate(julianDate);
                    x1 = Constellation.IsOpposition(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Earth.Longitude, 30.0);
                    if (x1) {
                        result = Constellation.IsOpposition(SolarSystem.Singleton.Earth.Longitude, EarthSystem.Moon.EclipticLongitude, 15.0);
                    }

                    break;

                case "J-Sun-E-Moon":
                    EarthSystem.SetJulianDate(julianDate);
                    x1 = Constellation.IsOpposition(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Earth.Longitude, 30.0);
                    if (x1) {
                        result = Constellation.IsConjunction(SolarSystem.Singleton.Earth.Longitude, EarthSystem.Moon.EclipticLongitude, 15.0);
                    }

                    break;

                case "Kilauea":
                    result = Constellation.IsConjunction(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Saturn.Longitude, 50.0)
                        && Constellation.IsConjunction(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Earth.Longitude, 25.0)
                        && Constellation.IsConjunction(SolarSystem.Singleton.Saturn.Longitude, SolarSystem.Singleton.Earth.Longitude, 25.0);
                    break;

                case "BrucknerPeri": {
                        var angleValue = SolarSystem.Singleton.Saturn.Longitude - SolarSystem.Singleton.Uranus.Longitude + SolarSystem.Singleton.Neptune.Longitude + 90; //// - SolarSystem.Singleton.Jupiter.Longitude
                        var mangle = Angles.Mod360Sym(angleValue * 3);
                        result = Constellation.IsPericentre(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Jupiter.LP, 1.0)
                            && Math.Abs(mangle) < 3; ////> 35; 
                                                     //// && Constellation.IsConjunction(SolarSystem.Singleton.Saturn.Longitude, SolarSystem.Singleton.Neptune.Longitude, 10.0);
                        /* if (result)
                         {
                             angleValue = angleValue + 1;
                         }*/
                    }

                    break;
                case "BrucknerApo": {
                        var angleValue = SolarSystem.Singleton.Saturn.Longitude - SolarSystem.Singleton.Uranus.Longitude + SolarSystem.Singleton.Neptune.Longitude + 90; //// - SolarSystem.Singleton.Jupiter.Longitude
                        var mangle = Angles.Mod360Sym((angleValue - 180) * 3);
                        result = Constellation.IsApocentre(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Jupiter.LP, 1.0)
                            && Math.Abs(mangle) > 25;
                        //// && Constellation.IsConjunction(SolarSystem.Singleton.Saturn.Longitude, SolarSystem.Singleton.Neptune.Longitude, 10.0);
                        /* if (result)
                         {
                             angleValue = angleValue + 1;
                         }*/
                    }

                    break;

                case "Bruckner": {
                        //// result = Constellation.IsPericentre(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Jupiter.LP, 1.0);
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                        var Ls = SolarSystem.Singleton.Saturn.Longitude;
                        var Lu = SolarSystem.Singleton.Uranus.Longitude;
                        var Ln = SolarSystem.Singleton.Neptune.Longitude;
                        var LPj = SolarSystem.Singleton.Jupiter.LP;
                        var V = (Lj - LPj) - (Ls - Lu + Ln + 90) * 3;
                        result = Angles.EqualDeg(SolarSystem.Singleton.Mercury.Longitude, 0, 20) && Math.Abs(Angles.Mod360Sym(V)) > 40;
                    }

                    break;

                case "BrucknerNew": {
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                        var Ls = SolarSystem.Singleton.Saturn.Longitude;
                        var Lu = SolarSystem.Singleton.Uranus.Longitude;
                        var Ln = SolarSystem.Singleton.Neptune.Longitude;
                        var LPj = SolarSystem.Singleton.Jupiter.LP;
                        //// var LPs = SolarSystem.Singleton.Saturn.LP;

                        //// var V = 4 * (Lj- LPj) / 3 + Ls;  //// LPj);
                        var M = 2 * (Ls + Lj);
                        var B = +Lj - Ls + Lu - Ln; //// /2;
                        var U1 = Angles.Mod360Sym(M - B);
                        var U2 = Angles.Mod360Sym((M + B) / 2);
                        result = Angles.EqualDeg(U1, 0, 10);
                    }

                    break;
            }

            return result;
        }

        /// <summary>
        /// Valids the correlation.
        /// </summary>
        /// <param name="shift">The shift.</param>
        /// <returns> Returns value. </returns>
        private static bool ValidCorrelation(long shift)
        {
            //// Lunations
            //// const double MeanLunation = 29.5306;
            ////  const double MeanHalfLunation = MeanLunation / 2;
            //// const double MeanHalfEclipse = 173.31;
            //// const long AnySolarEclipseDay = 1921240; //// 26.1.548
            double date = shift + Julian.MayanDay(9, 16, 4, 11, 3); //// 18
            //// double mdiff = (MeanLunation * 10000 + date - AnySolarEclipseDay) % MeanLunation;
            //// if ((mdiff > 5) && (mdiff < MeanLunation - 5)) {  return false;   } 
            //// double ediff = (MeanHalfEclipse * 1000 + date - AnySolarEclipseDay) % MeanHalfEclipse;
            //// if ((ediff > 12) && (ediff < MeanHalfEclipse - 12)) { return false;  }

            var x = IsFullMoon(date, 5);
            if (!x) {
                return false;
            }

            date = shift + Julian.MayanDay(9, 16, 12, 5, 17);
            x = Constellation.IsEquinoxSolsticePoint(date, 10); ////5
            if (!x) {
                return false;
            }

            date = shift + Julian.MayanDay(9, 15, 9, 15, 14);
            x = Constellation.IsConjunction(SolarSystem.Singleton.Venus, SolarSystem.Singleton.Earth, date, 20); //// 15
            if (!x) {
                return false;
            }

            date = shift + Julian.MayanDay(9, 9, 16, 3, 0);
            x = Constellation.IsAspect(SolarSystem.Singleton.Earth, SolarSystem.Singleton.Mars, date, 30); ////30
            return x;
        }

        /// <summary>
        /// Validates the correlation history.
        /// </summary>
        /// <param name="shift">The shift.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        private static bool ValidCorrelationHistory(long shift)
        {
            //// Lunation
            var date = shift + Julian.MayanDay(9, 11, 15, 14, 0) - 12 + 29.5306 / 2;
            if (Math.Abs((date % 29.5306) - 6) > 3) {
                return false;
            }

            date = shift + Julian.MayanDay(8, 17, 11, 3, 0);
            //// x = x & IsConjunction(SolarSystem.Earth, SolarSystem.Mars, date, 20);
            var x = Constellation.IsAspect(SolarSystem.Singleton.Earth, SolarSystem.Singleton.Mars, date, 30);
            if (!x) {
                return false;
            }

            date = shift + Julian.MayanDay(9, 15, 9, 15, 14);
            x = Constellation.IsConjunction(SolarSystem.Singleton.Venus, SolarSystem.Singleton.Earth, date, 15);
            if (!x) {
                return false;
            }

            date = shift + Julian.MayanDay(9, 16, 12, 5, 17);
            x = Constellation.IsEquinoxSolsticePoint(date, 5);
            return x;
        }
        #endregion

        /// <summary>
        /// Evaluates the configuration.
        /// </summary>
        /// <param name="crossingType">Type of the crossing.</param>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="julianDate">The julianDate.</param>
        /// <returns> Returns value. </returns>
        private bool EvaluateConfiguration(byte crossingType, Orbit orbitA, Orbit orbitB, double julianDate)
        {
            var result = false;
            switch (crossingType) {
                case 1:
                    result = Constellation.IsConjunction(orbitA, orbitB, julianDate, this.DegEps);
                    break;
                case 2:
                    result = Constellation.IsOpposition(orbitA, orbitB, julianDate, this.DegEps);
                    break;
                case 3:
                    result = Constellation.IsAspect(orbitA, orbitB, julianDate, this.DegEps);
                    break;
                case 4:
                    result = Constellation.IsRightAngle(orbitA, orbitB, julianDate, this.DegEps);
                    break;
                    //// Resharper default: break;
            }

            return result;
        }

        /// <summary>
        /// Valid Dresden Codex.
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private bool ValidDresdenCodex(double date)
        {
            //// return IsConjunction(SolarSystem.Venus, SolarSystem.Earth, date + 85970.0, this.DegEps);
            var x = IsConjunction(SolarSystem.Singleton.Jupiter, SolarSystem.Singleton.Saturn, date + 85970.0, this.DegEps);
            return x;
        }
    }
    #endregion
}
