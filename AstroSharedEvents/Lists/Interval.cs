// <copyright file="Interval.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Lists { 
    using System;
    using JetBrains.Annotations;
    using AstroSharedOrbits.Dwarfs;
    using AstroSharedOrbits.Systems;
    using global::AstroSharedClasses.Enums;
    using global::AstroSharedClasses.Computation;
    using global::AstroSharedClasses.Calendars;
    using AstroSharedEvents.Crossing;
    using AstroSharedOrbits.Orbits;

    /// <summary>
    /// Interval of events.
    /// </summary>
    public sealed class Interval : Constellation {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class.
        /// </summary>
        /// <param name="dateList">The date list.</param>
        public Interval(AstroSharedClasses.Computation.DateList dateList) {
            this.DateList = dateList;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Date List.
        /// </summary>
        /// <value> Property description. </value>
        public AstroSharedClasses.Computation.DateList DateList { get; set; }

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
        public static bool IsLimitFunction(double date) {
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
        /// Conjunction Dates.
        /// </summary>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="n1">The number n1.</param>
        /// <param name="n2">The number n2.</param>
        /// <param name="accuracy">If set to <c>true</c> [accuracy].</param>
        [UsedImplicitly]
        public void ConfigurationDates(byte actionType, AstPlanet n1, AstPlanet n2, bool accuracy) {
            var orbitA = SolarSystem.Singleton.Orbit[(int)n1];
            var orbitB = SolarSystem.Singleton.Orbit[(int)n2];
            if (((int)n1 < (int)AstPlanet.Jupiter) || ((int)n2 < (int)AstPlanet.Jupiter)) {
                if (accuracy) {
                    this.StepDays = 0.5;
                    this.SkipDays = 10;
                    this.DegEps = 0.1; // inner planets
                }
                else {
                    this.StepDays = 1;
                    this.SkipDays = 10;
                    this.DegEps = 0.5;
                }
            }
            else {
                if (accuracy) {
                    this.StepDays = 10;
                    this.SkipDays = 100;
                    this.DegEps = 0.5; // outer planets
                }
                else {
                    this.StepDays = 100;
                    this.SkipDays = 100;
                    this.DegEps = 1.0;
                }
            }

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
        public void CorrelationDates(long shiftFrom, long shiftTo, int shiftStep) {
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
        public void DresdenCodexDates() {
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
                        double skipDays) {
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
                        double skipDays) {
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
        public void SpecialDates(string givenAstroType) {
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
        public float SpecialSumation() { //// float phaseShift
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
        private static bool ValidSpecialDate(string givenAstroType, double julianDate) {
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


                        /// eruptions?
                        result = Constellation.IsConjunction(Lj, Ls, 45.0)
                                   ////   && Constellation.IsOpposition(Le, Lu, 20.0)
                                   && ((Constellation.IsRightAngle(Ls, Lu, 25.0) && Constellation.IsRightAngle(Lj, Lu, 25.0))
                                   || (Constellation.IsRightAngle(Ls, Ln, 25.0) && Constellation.IsRightAngle(Lj, Ln, 25.0)))
                                    && (Constellation.IsAspect(Le, Lu, 10.0) || Constellation.IsAspect(Le, Ln, 10.0)
                                  );

                        /*
                        result = ( Constellation.IsConjunction(Lj, Ln, 20.0)
                                   || Constellation.IsConjunction(Lj, Lu, 20.0)
                                   || Constellation.IsConjunction(Lj, Ls, 20.0))
                                && Constellation.IsOpposition(Lj, Le, 10.0);
                        */
                        /*
                        result = Constellation.IsRightAngle(Lj, Ln, 20.0)
                                   && Constellation.IsConjunction(Lj, Lu, 20.0);

                        result = Constellation.IsTrigAspect(Ln, Ls, 40.0)
                                    && Constellation.IsTrigAspect(Lj, Ls, 40.0)
                                    && Constellation.IsTrigAspect(Lj, Ln, 40.0)
                                    && !Constellation.IsConjunction(Lj, Ls, 30.0)
                                    && !Constellation.IsConjunction(Lj, Ln, 30.0)
                                    && !Constellation.IsConjunction(Ls, Ln, 30.0);
                        */
                        //// && Constellation.IsConjunction(Lj, Lu, 30.0);

                        /*
                        result = Constellation.IsAspect(Lu, Ln, 10.0)
                                    && Constellation.IsOpposition(Lj, Ls, 20.0);
                        */
                        /* pro Filipa a Tynu
                        result = Constellation.IsConjunction(Lj, Ls, 8.0)
                            && Constellation.IsConjunction(Lj, Le, 10.0);                        
                            */
                        /*
                        result = Constellation.IsConjunction(Lj, Ls, 10.0)
                                && Constellation.IsOpposition(Lj, Le, 40.0);
                                */
                        ////        && Constellation.IsRightAngle(Lj, Ln, 15.0)


                        //// result = Constellation.IsConjunction(Lj, Ls, 3.0);
                        //&& Constellation.IsConjunction(Lj, Lu, 90)
                        //&& Constellation.IsConjunction(Lj, Ln, 90);

                        /*
                        result = Constellation.IsAspect(Lj, Lu, 1.0)
                                && Constellation.IsRightAngle(Lj, Ln, 15.0);
                         */
                        /*
                        result = Constellation.IsConjunction(Lj, Lu, 1.0)
                                && Constellation.IsConjunction(Lj, Ln, 30);
                        */

                        //// result = Constellation.IsConjunction(Lu, Ln, 0.5);

                        //// result = Constellation.IsAspect(Lj, Lu, 2.0);

                        /*
                        result = Constellation.IsAspect(Lj, Lu, 3.0)
                              && Constellation.IsConjunction(Lj, Ln, 5.0);
                        */

                        //// && Constellation.IsConjunction(Ln, Lu, 5.0);

                        /*
                        var a = Math.Abs(Math.Sin(Lj - Ljp));
                        var b = Math.Abs(Math.Sin(Lj - Ls));
                        var f = a + b;
                        result = f > 1.5f;


                        var f = Math.Abs(Angles.Mod360Sym(Lj - Ljp)) + Math.Abs(Angles.Mod180Sym(Lj - Ls + 90));
                        result = f > 210;


                        result = Constellation.IsConjunction(Lj, Ls, 10.0)
                                && Constellation.IsConjunction(Le, Lr, 10.0)
                                && Constellation.IsRightAngle(Lj, Le, 10.0);
                        */

                        /*
                        var axUN = Angles.AxisOf(Lu, Ln);
                        var diffAxJ = Angles.Mod360Sym(axUN/2 - Lj);
                        result = Constellation.IsConjunction(axUN, diffAxJ, 20.0);
                        */
                        /*
                        result = Constellation.IsConjunction(SolarSystem.Singleton.Jupiter.Longitude 
                                                                  + SolarSystem.Singleton.Uranus.Longitude 
                                                                  - SolarSystem.Singleton.Neptune.Longitude, 
                                                                  SolarSystem.Singleton.Jupiter.LP - 180.0, 5.0); 

                        //// var alpha = Angles.Mod360(1 * Lj - 1 * Ls - 1 * Lu + 1 * Ln);
                        var alpha = Angles.Mod360(1 * Lj - 4 * Lu + 3 * Lx + 90);
                        //// var alpha = Angles.Mod360(2 * Lj - 1 * Ls - 5 * Lu + 1 * Ln + 3 * Lx);
                        result = Constellation.IsAspect(alpha, 0, 1);

                        result = Constellation.IsOpposition(Ls, Lx, 20.0)
                                && Constellation.IsConjunction(Lu, Lx, 20.0)
                                && Constellation.IsConjunction(Ln, Lx, 20.0);
                                */

                        //// result = Constellation.IsConjunction(Lj, Lx, 20.0) && Constellation.IsConjunction(Lu, Lx, 20.0);
                        //// result = Constellation.IsOpposition(Lu, Lx, 15.0) && Constellation.IsConjunction(Ln, Lx, 15.0);
                        //// result = Constellation.IsOpposition(Ln, Lx, 10.0) && Constellation.IsConjunction(Lu, Lx, 10.0);
                        //// result = Constellation.IsConjunction(Lj, Lx, 20.0) && Constellation.IsConjunction(Ls, Lx, 20.0);
                        //// result = Constellation.IsConjunction(Lu, Lx, 10.0) && Constellation.IsConjunction(Ln, Lx, 10.0);
                        //// result = Constellation.IsConjunction(Lj, Lx, 2.0);
                        //// result = Constellation.IsConjunction(Ls, Lx, 1.0);
                        //// result = Constellation.IsConjunction(Lu, Lx, 1.0);
                        //// result = Constellation.IsConjunction(Ln, Lx, 1.0);

                        //// result = Constellation.IsAspect(Ls, Lu, 3.0);
                        //// result = Constellation.IsRightAngle(Ls, Ln, 3.0);

                        /*
                    var axisUN = Angles.AxisOf(Lu, Ln);
                    result = Constellation.IsAspect(Ljp, axisUN, 5.0);

                         var axisUN = Angles.AxisOf(Lu, Ln);
                         result = Constellation.IsAspect(Lj, axisUN, 5.0);
                         * 
                         result = Constellation.IsConjunction(Lj, Lu, 45.0)
                              && Constellation.IsConjunction(Lj, Ln, 45.0)
                              && !Constellation.IsConjunction(Lu, Ln, 45.0);
                              */

                        /*
                        var axisJS = Angles.AxisOf(Lj, Ls);
                        var axisUN = Angles.AxisOf(Lu, Ln);
                        result = Constellation.IsAspect(axisJS, axisUN, 5.0);
                        */
                        /*
                        result = Constellation.IsConjunction(Lj, Ln, 30.0)
                                 && Constellation.IsConjunction(Ls, Lu, 30.0);
                         */        //// && Constellation.IsRightAngle(Lj, Ls, 20.0);

                        //// result = Constellation.IsConjunction(2 * Lj + 180, 5 * Ls, 1.0);
                        //// result = Constellation.IsConjunction(1 * Ls, 3 * Lu, 1.0);

                        /*
                            result = Constellation.IsAspect(Lj, Ln, 20.0)
                                 && Constellation.IsRightAngle(Lj, Ls, 20.0);
                          */
                        //// && Constellation.IsTrigAspect(Ls, Lu, 10.0);

                        /*
                  result = Constellation.IsOpposition(Lj, Lu, 15.0)
                              && Constellation.IsAspect(Ls, Lu, 15.0);

                  result = Constellation.IsConjunction(1 * Lj + 180, 3 * Ls, 1.0);
                  */
                        /*
                        result = Constellation.IsConjunction(Lj, Ls, 30.0)
                             && Constellation.IsConjunction(Lv, Lj, 30.0)
                             && Constellation.IsConjunction(Le, Lj, 30.0)
                             && Constellation.IsConjunction(Lr, Lj, 30.0);
                            ////  && Constellation.IsConjunction(Lm, Lj, 30.0)
                        */
                        //// var axisUN = Angles.AxisOf(Lu, Ln);
                        /*
                        result = Constellation.IsConjunction(Lj, Lu, 120.0)
                              && Constellation.IsConjunction(Ls, Ln, 120.0)
                              && Constellation.IsConjunction(Lj, Ls, 150.0)
                              && Constellation.IsConjunction(Lu, Ln, 150.0)
                              && (Constellation.IsConjunction(Lj, Ls, 30.0) || Constellation.IsConjunction(Lu, Ln, 30.0));
                        */
                        /*
                         result = Constellation.IsOpposition(Lj, Ls, 45.0)
                               && Constellation.IsOpposition(Lj, Lu, 45.0)
                               && Constellation.IsOpposition(Lj, Ln, 45.0)
                                 && Constellation.IsApocentre(Lj, Ljp, 30.0);
                         */
                        /*
                        result = Constellation.IsOpposition(Lj, Ls, 15.0)
                              && Constellation.IsOpposition(Lj, Lu, 60.0)
                              && Constellation.IsOpposition(Lj, Ln, 60.0)
                              && Constellation.IsPericentre(Lj, Ljp,15.0);
                              */
                        /*
                        result = Constellation.IsConjunction(Lj, Ls, 10.0)
                              && Constellation.IsRightAngle(Lj, axisUN, 10.0);
                              */
                        /*
                                                result = Constellation.IsTrigMultiple(Lj, Ls, 10.0)
                                                      && Constellation.IsTrigMultiple(Lu, Ln, 10.0);
                        */
                        /*
///// var alpha = Angles.Mod360(12 * Lj - 12 * Ls - 8*12 * Lu + 8*12 * Ln);
var alpha = Angles.Mod360(1 * Lj - 1 * Ls - 8 * Lu + 8 * Ln); //// + 90
//// var alpha = Angles.Mod360(Lj/24 - Ls/24 - Lu/3 + Ln/3);
result = Constellation.IsAspect(alpha, 0, 0.5);
*/

                        /*
                         * 
                        result = Constellation.IsOpposition(Le, Lj, 80.0)
                                    && Constellation.IsOpposition(Le, Ls, 80.0)
                                    && Constellation.IsOpposition(Le, Lu, 80.0)
                                    && Constellation.IsOpposition(Le, Ln, 80.0);
                         * 
                        var alpha = Angles.Mod360(1 * Lj - 1 * Ls - 1 * Lu + 1 * Ln);
                        result = Constellation.IsAspect(alpha, 0, 5.0);
                        */

                        //// var Lx = SolarSystem.Singleton.PlanetX.Longitude;

                        //// result = Constellation.IsConjunction(Lj, Ljp+90, 1.0);
                        //// result = Constellation.IsApocentre(Lj, Ljp, 1.0);
                        /*
                    result = Constellation.IsRightAngle(Lj, Ln, 25.0)
                            && Constellation.IsConjunction(Ln, Le, 25.0)
                            && Constellation.IsConjunction(Lm, Le, 25.0);
                            */
                        /*
                        result = ((Constellation.IsOpposition(Lv, Le, 35.0) && Constellation.IsOpposition(Lm, Lr, 35.0))
                                || (Constellation.IsOpposition(Lm, Le, 35.0) && Constellation.IsOpposition(Lv, Lr, 35.0))
                                || (Constellation.IsOpposition(Lr, Le, 35.0) && Constellation.IsOpposition(Lm, Lv, 35.0)));
                       */
                        ////    && Constellation.IsConjunction(Lj, Ls, 30.0);

                        /*
                        var rAB = Angles.Mod360(1 * Lj - 3 * Ls);
                        result = Angles.EqualDeg(rAB, -120, 0.60);
                        */

                        //// result = Constellation.IsConjunction(Lv, Le, 10.0)
                        ////         && Constellation.IsOpposition(Lj, Lr, 30.0);

                        //// result = Constellation.IsConjunction(1 * Lu, -1 * Ln, 1.0);
                        //// result = Constellation.IsConjunction(2 * Lj, 5 * Ls, 1.0);
                        //// result = Constellation.IsConjunction(3 * Lj, 8 * Ls, 1.0);

                        /*
                        //// var axisJS = Angles.AxisOf(Lj, Ls);
                        //// var axisUN = Angles.AxisOf(Lu, Ln);
                        //// var axisUP = Angles.AxisOf(Lu, Lp);
                        //// var axisUP = Angles.Mod360Sym(Lu-Lp);
                        var JS = Angles.Mod360Sym(Lj-Ls);
                        result = Constellation.IsRightAngle(Lj, Lp, 10.0)
                                && Constellation.IsConjunction(Lj, Ls, 30.0);

                        //// result = Constellation.IsOpposition(Lx, Ln, 1.0);
                        */
                        /*
                        result = Constellation.IsApocentre(Lj, SolarSystem.Singleton.Jupiter.LP, 20.0)
                                 && Constellation.IsAspect(Lj, Lu, 20.0);

                         result = Constellation.IsAspect(Le, Lm, 5.0)
                                 && Constellation.IsAspect(Lr, Lv, 5.0); 
                        
                        result = Constellation.IsApocentre(Lj, SolarSystem.Singleton.Jupiter.LP, 20.0)
                                 && Constellation.IsAspect(Lj, Le, 20.0);

                        result = Constellation.IsConjunction(Le, Lr, 5.0)
                                 && Constellation.IsApocentre(Lj, SolarSystem.Singleton.Jupiter.LP, 20.0)
                                 && Constellation.IsOpposition(Lj, Le, 20.0);

                        result = Constellation.IsAspect(Lj, Ls, 5.0)
                                 && Constellation.IsRightAngle(Lj, Lu, 10.0);

          result = Constellation.IsAspect(Lj, Ls, 5.0)
                   && Constellation.IsRightAngle(Lj, Lu, 10.0);
        
         result = Constellation.IsRightAngle(Lj, Ls, 5.0)
                   && Constellation.IsAspect(Lu, Ls, 10.0);

         result = Constellation.IsAspect(Lj, Ls, 5.0)
                   && Constellation.IsAspect(Lj, Lu, 10.0)
                   && Constellation.IsAspect(Ls, Lu, 10.0);

         result = Constellation.IsConjunction(Lj, Ls, 5.0)
                   && Constellation.IsRightAngle(Lj, Lu, 10.0)
                   && Constellation.IsRightAngle(Ls, Lu, 10.0);

          ----
          result = Constellation.IsAspect(Lu, Lp, 3.0);

          result = Constellation.IsConjunction(Lu, Ln, 15.0)
                   && Constellation.IsAspect(Lu, Lp, 15.0)
                   && Constellation.IsAspect(Ln, Lp, 15.0);
                   */
                        /*
                        result = Constellation.IsOpposition(Lj, Lp, 5.0)
                                 && Constellation.IsRightAngle(Lj, Ls, 10.0);
                                 */
                        /*
                        result = Constellation.IsAspect(Lj, Lu, 30.0)
                                 && Constellation.IsAspect(Lj, Ln, 30.0)
                                 && Constellation.IsRightAngle(Lj, Ls, 10.0);
                         */
                        /*
                        result = Constellation.IsAxialRightAngle(
                            SolarSystem.Singleton.Jupiter, SolarSystem.Singleton.Saturn,
                            SolarSystem.Singleton.Uranus, SolarSystem.Singleton.Neptune, julianDate, 1);
                        */
                        /*
                        var Lr = SolarSystem.Singleton.Mars.Longitude;
                        var Le = SolarSystem.Singleton.Earth.Longitude;
                        var Lv = SolarSystem.Singleton.Venus.Longitude;
                        var Lm = SolarSystem.Singleton.Mercury.Longitude;                  
                        */
                        /*
                        result = Constellation.IsConjunction(Lm, Lj, 20.0)
                            && Constellation.IsConjunction(Lv, Lr, 20.0)
                            && Constellation.IsOpposition(Lj, Lu, 40.0);
                        */
                        /*
                        result = Constellation.IsAspect(Lj, Lu, 25.0)
                              && Constellation.IsAspect(Lj, Ln, 25.0)
                              && Constellation.IsAspect(Lu, Ln, 25.0);
                        */
                        ////      && Constellation.IsRightAngle(Ls, Lj, 30.0);
                        /*
                        result = Constellation.IsOpposition(Lj, Lu, 45.0)
                              && Constellation.IsOpposition(Ls, Ln, 45.0)
                              && Constellation.IsRightAngle(Ls, Lj, 30.0);
                        */
                        /*
                       result = Constellation.IsConjunction(Lj, Lu, 15.0)
                               && Constellation.IsConjunction(Ls, Ln, 15.0);
                       */
                        /*
                        var Lbary = SolarSystem.Singleton.Barycentre.Longitude;

                        //// var alpha = Angles.Mod180(2 * Lj - 2 * Ls + 1 * Lu - 3.5 * Ln);
                        var alpha = Angles.Mod360(2 * Lj - 2 * Ls  + 1 * Lu - 3.5 * Ln);
                        //// var alpha = Angles.Mod360(2 * Lj - 2 * Ls - 1 * Lu + 3.5 * Ln);
                        //// var alpha = Angles.Mod360(3.5 * Lj - 6 * Ls);
                        result = Angles.EqualDeg(alpha, 0, 3);
                        */
                        /*
                        result = Constellation.IsConjunction(Lm, Le, 30.0)
                                && Constellation.IsOpposition(Lm, Lv, 30.0)
                                && Constellation.IsOpposition(Le, Lv, 30.0)
                                && Constellation.IsConjunction(Lv, Lj, 60.0)
                                && Constellation.IsConjunction(Lj, Ls, 40.0);
                        ////   && Constellation.IsRightAngle(Le, Lbary, 20.0);
                        */

                        /*
                        result = Constellation.IsAspect(Lv, Le, 20.0)
                                && Constellation.IsRightAngle(Le, Lj, 20.0)
                                && Constellation.IsRightAngle(Lv, Lj, 20.0);
                        */
                        /*
                        result = Constellation.IsRightAngle(Lj, Ls, 15.0)
                                && Constellation.IsRightAngle(Lv, Le, 5.0);
                        */
                        /*
                        result = Constellation.IsConjunction(Lj, Le, 3.0)
                                && Constellation.IsOpposition(Lj, Ls, 30.0)
                                && Constellation.IsOpposition(Lj, Lu, 30.0)
                                && Constellation.IsOpposition(Lj, Ln, 30.0);
                        
                        result = Constellation.IsOpposition(Lj, Le, 30.0)
                               && Constellation.IsConjunction(Lj, Lv, 30.0)
                               && Constellation.IsConjunction(Lj, Ls, 50.0)
                               && !Constellation.IsConjunction(Lj, Ls, 5.0);
                        */
                        /*
                        result = Constellation.IsOpposition(Lj, Lu, 20.0)
                               && Constellation.IsConjunction(Lj, Le, 20.0)
                               && Constellation.IsConjunction(Lj, Ls, 50.0)
                               && !Constellation.IsConjunction(Lj, Ls, 5.0);
                               */
                        /*        
                        result = Constellation.IsOpposition(Lj, Lu, 20.0)
                               && Constellation.IsConjunction(Lj, Le, 20.0)
                               && Constellation.IsRightAngle(Le, Lv, 20.0);
                               */
                        /*
                        result = Constellation.IsConjunction(Ls, Lr, 20.0)
                                && Constellation.IsConjunction(Lj, Le, 10.0)
                                && Constellation.IsApocentre(Ls,SolarSystem.Singleton.Saturn.LP, 30.0);
                                */
                        /*
                        result = Constellation.IsOpposition(Ls, Lr, 5.0)
                               && Constellation.IsOpposition(Lj, Le, 5.0);
                               */
                        /*        
                        result = Constellation.IsConjunction(Ls, Lr, 20.0)
                                   && Constellation.IsConjunction(Lj, Le, 10.0)
                                   && Constellation.IsConjunction(Lv, Lm, 20.0);
                                   */
                        /*
                        result = Constellation.IsOpposition(Lm, Lv, 20.0)
                               && Constellation.IsConjunction(Lj, Le, 10.0)
                               && Constellation.IsRightAngle(Le, Lv, 20.0);
                               */
                        //// result = Constellation.IsTrigAspect(Lj+60, Ls, 1.0);
                        //// && Constellation.IsTrigAspect(Lj, Le, 6.0);

                        //// result = Constellation.IsAspect(Lj, Lv, 25.0)
                        ////     && Constellation.IsAspect(Lj, Le, 25.0);
                        ////     && Constellation.IsConjunction(Lj, Lr, 30.0);

                        //// var alpha = Angles.Mod360(Lm - 5 * Le + 4 * Lv);
                        /*var alpha = Angles.Mod360(Lv - Lj - 180);
                        var beta = Angles.Mod360(Le - Lj);

                        var alpha = Angles.Mod360(Lv - Lj - 180);
                        var beta = Angles.Mod360(Le - Lj); 

                        var alpha = Angles.Mod360(Lv - Lj);
                        var beta = Angles.Mod360(Le - Lj - 180);

                        var alpha = Angles.Mod360(Lv - Lj - 180);
                        var beta = Angles.Mod360(Le - Lj - 180);
                        
                        var alpha = Angles.Mod180(Lj - Lv);
                        var alpha = Angles.Mod360(Lj - Le);
                        var beta = Angles.Mod360(Lm - Lv);
                        var gama = Angles.Mod360(Le - Lv - 180);
                        var alpha = Angles.Mod360(Lm - Lv);
                        var beta = Angles.Mod360(Le - Lv-180);

                        var alpha = Angles.Mod360(Lj - Lv - 90);
                        var beta = Angles.Mod360(Lj - Ls - 90); 

                        var alpha = Angles.Mod360(Lm - 4 * Lv + 2 * Le + Lr);
                        
                        var alpha = Angles.Mod360(3*Lv - 5*Le + 2*Lj);
                        var beta = Angles.Mod360(41 * Lv - 69 * Le + 28 * Lj+180);
                        */

                        /*
                        var alpha = Angles.Mod360(Lm - Lv);
                        result = Angles.EqualDeg(alpha, 0, 5);
                        */

                        //// var alpha = Angles.Mod360(Lm/15 - Lv/4 + Le/5);
                        //// var alpha = Angles.Mod360(1 * Lm - 5 * Lv + 4 * Le);
                        //// var alpha = Angles.Mod360(3 * Lv - 5 * Le + 2 * Lj);
                        //// var alpha = Angles.Mod360(1 * Lv - 2 * Le + 1 * Lr);
                        //// var alpha = Angles.Mod360(8 * Lv - 12 * Le - 3 * Lr + 7 * Lj +180);
                        //// var alpha = Angles.Mod360(1 * Lm - 5 * Lv + 4 * Le);
                        //// var alpha = Angles.Mod360(8 * Lv - 12 * Le + 4 * Lr);
                        //// var alpha = Angles.Mod360(2 * Lv - 3 * Le + 1 * Lr);
                        /* var alpha = Angles.Mod360(3 * Lj - 4 * Ls);
                        result = Angles.EqualDeg(alpha, 0, 1);
                        */
                        /*
                        var alpha = Angles.Mod360(Lj - Le);
                        var beta = Angles.Mod360(Lj - Ls - 90);

                        result = Angles.EqualDeg(alpha, 0, 2)
                                    && Angles.EqualDeg(beta, 0, 30);    */
                        /*  && Angles.EqualDeg(beta, 0, 5);
                         && Angles.EqualDeg(gama, 0, 60); */
                        //// result = Angles.EqualDeg(alpha, 0, 1);
                    }

                    break;

                case "Quadra1":
                    {
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
                case "Quadra2":
                    {
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

                case "Maunder":
                    {
                        var Ljp = SolarSystem.Singleton.Jupiter.LP;
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                        var Ls = SolarSystem.Singleton.Saturn.Longitude;
                        var d1 = Angles.Mod360(Lj - Ljp);
                        var d2 = Angles.Mod180(Lj - Ls);

                        result = (Angles.EqualDeg(d1, 0, 20) && Angles.EqualDeg(d2, 90, 20));
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

                        ////  result = Constellation.IsConjunction(Lx, 127, 1.0);

                        //// result = Constellation.IsRightAngle(Lu, Lx, 1.0);

                        //// result = Constellation.IsConjunction(Lu, Lx, 30.0) && Constellation.IsConjunction(Ln, Lx, 30.0);
                        //// result = Constellation.IsConjunction(Lu, Lx, 10.0) && Constellation.IsConjunction(Ln, Lx, 10.0);
                        /*
                        var a = Angles.Mod360Sym((1 * Lj - 1 * Ls - 1 * Ln + 1 * Lx)*2); ////  - 30
                        result = Math.Abs(a) < 3;
                        */
                        /*
                        //// var a = Angles.Mod360Sym(3 * Lj - 2 * Ls - 2 * Lx);
                        var a = Angles.Mod360Sym(2 * Lj - 2 * Ls - 1 * Lu + 1 * Lx); ////  - 30
                        var a = Angles.Mod360Sym(2 * Lj - 2 * Ls - 1 * Lu + 1 * Lx - 220); ////  - 30
                        //// var a = Angles.Mod360Sym(2 * Lj - 2 * Ls - 2 * Ln + 1 * Lx);
                        //// var a = Angles.Mod360Sym(4 * Lj - 4 * Ls - 1*Lu - 2 * Ln + 2 * Lx);

                        result = Math.Abs(a) < 3;
                        */
                        ////result = Constellation.IsConjunction(Lu, Lx, 3.0);
                        //// result = Constellation.IsOpposition(Lu, Lx, 3.0);
                        ////result = Constellation.IsConjunction(Ln, Lx, 3.0);
                        //// result = Constellation.IsOpposition(Ln, Lx, 3.0);

                        /*
                        var Lv = SolarSystem.Singleton.Venus.Longitude;
                        var Le = SolarSystem.Singleton.Earth.Longitude;
                        var Lr = SolarSystem.Singleton.Mars.Longitude;

                        result = Constellation.IsAspect(Le, Lr, 20.0)
                                 && Constellation.IsAspect(Le, Lv, 30.0)
                                 && Constellation.IsAspect(Lr, Lv, 30.0);
                                 */
                        /*    
                        result = Constellation.IsPericentre(Lj, Ljp, 10.0)
                                 && Constellation.IsPericentre(Lu, Lup, 30.0)
                                 && Constellation.IsOpposition(Lj, Lu, 30.0);


                        result = Constellation.IsConjunction(Lj, Le, 15.0)
                                 && Constellation.IsConjunction(Lv, Lr, 15.0)
                                 && Constellation.IsAspect(Lj, Ls, 15.0)
                                 && Constellation.IsAspect(Lu, Ln, 30.0);

                        result = Constellation.IsOpposition(Lj, Ls, 1.0)
                                 && Constellation.IsOpposition(Lj, Lu, 30.0)
                                 && Constellation.IsOpposition(Lj, Ln, 45.0);

                        var dj = Angles.Mod360(Lj - Ljp);
                        var du = Angles.Mod360(Ljp - Lu);

                        result = Constellation.IsConjunction(dj, du, 5.0);
                        */
                        //// result = Constellation.IsRightAngle(Lu, Lx, 1.0);

                        //// result = Constellation.IsOpposition(Ln, Lx, 1.0);
                        //// result = Constellation.IsConjunction(Ln, Lx, 1.0);
                        //// result = Constellation.IsRightAngle(Ln, Lx, 1.0);

                        //// result = Constellation.IsOpposition(Ln, Lx, 1.0);
                        //// result = Constellation.IsOpposition(Ln, Lx, 1.0);
                        //// result = Constellation.IsConjunction(Ln, Lx, 1.0);

                        /*
                        result = Constellation.IsOpposition(Lu, Lx, 20.0)
                                    && Constellation.IsOpposition(Ln, Lx, 20.0);
                        */
                        //// result = Constellation.IsOpposition(Ls, Ln, 2.0);
                        //// result = Constellation.IsConjunction(Lj, Lx, 2.0);
                    }

                    break;

                case "Solar-Impulses":
                    {
                        //// long jdatelong = (long)julianDate;  result = jdatelong % 30 < 10;
                        var Lv = SolarSystem.Singleton.Venus.Longitude;
                        var Le = SolarSystem.Singleton.Earth.Longitude;
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Jupiter.LP;
                        var a = Angles.Mod180Sym(3 * Lv - 5 * Le + 2 * Lj);
                        result = Math.Abs(a) < 5;
                    }

                    /*
                    result = Constellation.IsConjunction(SolarSystem.Singleton.Venus.Longitude, SolarSystem.Singleton.Jupiter.Longitude, 20.0)
                        && Constellation.IsConjunction(SolarSystem.Singleton.Venus.Longitude, SolarSystem.Singleton.Earth.Longitude, 20.0)
                        && Constellation.IsConjunction(SolarSystem.Singleton.Earth.Longitude, SolarSystem.Singleton.Jupiter.Longitude, 20.0);
                    */
                    /*
                    result = Constellation.IsConjunction(SolarSystem.Singleton.Mercury.Longitude, SolarSystem.Singleton.Earth.Longitude, 45.0)
                        && Constellation.IsConjunction(SolarSystem.Singleton.Venus.Longitude, SolarSystem.Singleton.Earth.Longitude, 45.0)
                        && Constellation.IsConjunction(SolarSystem.Singleton.Jupiter.Longitude, SolarSystem.Singleton.Earth.Longitude, 30.0); */
                    ////    && Constellation.IsConjunction(SolarSystem.Singleton.Saturn.Longitude, SolarSystem.Singleton.Earth.Longitude, 80.0);
                    //// result = Constellation.IsConjunction(SolarSystem.Singleton.Mercury.Longitude, SolarSystem.Singleton.Earth.Longitude, 5.0);
                    //// result = Constellation.IsConjunction(SolarSystem.Singleton.Mercury.Longitude, SolarSystem.Singleton.Venus.Longitude, 5.0);
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

                case "BrucknerPeri":
                    {
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
                case "BrucknerApo":
                    {
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

                case "Bruckner":
                    {
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

                case "BrucknerNew":
                    {
                        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
                        var Ls = SolarSystem.Singleton.Saturn.Longitude;
                        var Lu = SolarSystem.Singleton.Uranus.Longitude;
                        var Ln = SolarSystem.Singleton.Neptune.Longitude;
                        var LPj = SolarSystem.Singleton.Jupiter.LP;
                        //// var LPs = SolarSystem.Singleton.Saturn.LP;

                        //// var V = 4 * (Lj- LPj) / 3 + Ls;  //// LPj);
                        var M = 2* (Ls + Lj);
                        var B = (+Lj - Ls + Lu - Ln); //// /2;
                        var U1 = Angles.Mod360Sym((M - B));
                        var U2 = Angles.Mod360Sym((M + B)/2);
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
        private static bool ValidCorrelation(long shift) {
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
        private static bool ValidCorrelationHistory(long shift) {
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
        /// <param name="actionType">Type of the action.</param>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="julianDate">The julianDate.</param>
        /// <returns> Returns value. </returns>
        private bool EvaluateConfiguration(byte actionType, Orbit orbitA, Orbit orbitB, double julianDate) {
            var result = false;
            switch (actionType) {
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
        private bool ValidDresdenCodex(double date) {
            //// return IsConjunction(SolarSystem.Venus, SolarSystem.Earth, date + 85970.0, this.DegEps);
            var x = IsConjunction(SolarSystem.Singleton.Jupiter, SolarSystem.Singleton.Saturn, date + 85970.0, this.DegEps);
            return x;
        }
    }
        #endregion
}

//// result = IsPericentre(SolarSystem.Jupiter, date, 1);
////Angles.AxisOf( SolarSystem.Saturn.Longitude,SolarSystem.Neptune.Longitude) 
/* result = IsConjunction(SolarSystem.Saturn, SolarSystem.Neptune, date, 30)
      && IsRightAngle(SolarSystem.Jupiter, SolarSystem.Saturn, date, 30) 
      && IsRightAngle(SolarSystem.Jupiter, SolarSystem.Neptune, date, 30); 

result = IsApocentre(SolarSystem.Jupiter, date, 1)
    && IsConjunction(SolarSystem.Jupiter, SolarSystem.Mars, date, 10);
 * 
result = IsApocentre(SolarSystem.Jupiter, date, 1)
    && (IsConjunction(SolarSystem.Uranus, SolarSystem.Neptune, date, 45));
                    
result = IsApocentre(SolarSystem.Jupiter, date, 1)
    && (IsConjunction(SolarSystem.Saturn, SolarSystem.Neptune, date, 60));
                    
result = IsApocentre(SolarSystem.Jupiter, date, 1)
    && (IsConjunction(SolarSystem.Saturn, SolarSystem.Uranus, date, 45)); 

result = IsApocentre(SolarSystem.Jupiter, date, 1)
   && (IsConjunction(SolarSystem.Uranus, SolarSystem.Neptune, date, 45)
   || IsConjunction(SolarSystem.Saturn, SolarSystem.Neptune, date, 45)
   || IsConjunction(SolarSystem.Saturn, SolarSystem.Uranus, date, 45));

//// result = IsRightAngle(SolarSystem.Jupiter, SolarSystem.Saturn, date, 1); 
////  2009,00 J:301,96 S:165,84 U:351,68 N:323,55 H:165,66 2008 Dec 28
////  2009,00 M:348,42 V: 42,69 E: 97,06 R:266,63 2008 Dec 28  0 AD
 result = IsConjunction(SolarSystem.Saturn.Longitude - SolarSystem.Jupiter.Longitude, 165.84 - 301.96, 5) // 45
     && IsConjunction(SolarSystem.Uranus.Longitude - SolarSystem.Jupiter.Longitude, 351.68 - 301.96, 45)
     && IsConjunction(SolarSystem.Neptune.Longitude - SolarSystem.Jupiter.Longitude, 323.55 - 301.96, 45); 
////  result = IsOpposition(SolarSystem.Jupiter, SolarSystem.Saturn, date, 30) // 45
////     && IsAspect(SolarSystem.Jupiter, SolarSystem.Sun, date, 15); //30
////   result = IsAspect(SolarSystem.Jupiter, SolarSystem.Saturn, date, 2);
////  result = IsOpposition(SolarSystem.Uranus, SolarSystem.Saturn, date, 30)
////       && IsOpposition(SolarSystem.Uranus, SolarSystem.Neptune, date, 30);
 result = IsOpposition(SolarSystem.Jupiter, SolarSystem.Saturn, date, 80)
      && IsOpposition(SolarSystem.Jupiter, SolarSystem.Uranus, date, 80)
      && IsOpposition(SolarSystem.Jupiter, SolarSystem.Neptune, date, 80)
      && IsConjunction(SolarSystem.Uranus, SolarSystem.Neptune, date, 160)
      && IsConjunction(SolarSystem.Saturn, SolarSystem.Neptune, date, 160)
      && IsConjunction(SolarSystem.Saturn, SolarSystem.Uranus, date, 160);

////  result = this.IsVernalPoint(SolarSystem.Jupiter, date, 0.005);
    result = IsConjunction(SolarSystem.Earth, SolarSystem.Mars, date, 1)
        && IsLine(SolarSystem.Earth, SolarSystem.Venus, SolarSystem.Mars, date + 520, 10); 
result = IsLine(SolarSystem.Earth, SolarSystem.Venus, SolarSystem.Mars, date, 10)
        && IsLine(SolarSystem.Earth, SolarSystem.Venus, SolarSystem.Mars, date+260, 10);
                    
result = IsConjunction(SolarSystem.Earth, SolarSystem.Mars, date, 1) 
        && IsLine(SolarSystem.Earth, SolarSystem.Venus, SolarSystem.Mars, date+260, 10)
        && IsLine(SolarSystem.Earth, SolarSystem.Venus, SolarSystem.Mars, date-260, 10);
                   
result = IsConjunction(SolarSystem.Earth, SolarSystem.Mars, date, 1)
    || IsOpposition(SolarSystem.Earth, SolarSystem.Mars, date, 1)
        || IsLine(SolarSystem.Earth, SolarSystem.Venus, SolarSystem.Mars, date, 5);
                    
//// result = IsConjunction(SolarSystem.Earth, SolarSystem.Venus, date, 1)
////        && EarthSystem.IsNewMoon(date, 5);
////result = IsPericentre(SolarSystem.Jupiter, date, 20.0)
////        && IsAspect(SolarSystem.Earth, SolarSystem.Jupiter, date, 20);
//// result = EarthSystem.IsFullMoon(date, 0.3);
//// result = EarthSystem.IsAnyEclipse(date, 0.5, 10.0);
//// result = EarthSystem.IsNewMoon(date, 0.1);
//// result = IsConjunction(SolarSystem.Jupiter.Longitude + SolarSystem.Uranus.Longitude - SolarSystem.Neptune.Longitude, SolarSystem.Jupiter.LP - 180.0, 0.3);
//// result = IsConjunction(SolarSystem.Jupiter.Longitude + SolarSystem.Uranus.Longitude - SolarSystem.Neptune.Longitude, SolarSystem.Jupiter.LP, 0.3);

////result = IsConjunction(SolarSystem.Jupiter, SolarSystem.Saturn, date, 0.2);
                    
result = IsApocentre(SolarSystem.Jupiter, date, 1.0)
            && IsApocentre(SolarSystem.Saturn, date, 20.0)
            && IsPericentre(SolarSystem.Uranus, date, 30.0);

result = IsOpposition(SolarSystem.Jupiter, SolarSystem.Uranus, date, 5.0)
        && IsRightAngle(SolarSystem.Saturn, SolarSystem.Jupiter, date, 15.0)
        && IsRightAngle(SolarSystem.Saturn, SolarSystem.Uranus, date, 15.0);
                    
result = IsPericentre(SolarSystem.Jupiter, date, 5.0)
&& IsPericentre(SolarSystem.Saturn, date, 20.0)
&& IsPericentre(SolarSystem.Uranus, date, 20.0);

//// result = IsNodalAspect(SolarSystem.Earth, SolarSystem.Saturn, date, 0.5);
//// result = IsConjunction(SolarSystem.Jupiter, SolarSystem.Saturn, date, 35.0) && IsConjunction(SolarSystem.Jupiter, SolarSystem.Uranus, date, 45.0);
//// && IsOpposition(SolarSystem.Jupiter, SolarSystem.Neptune, date, 80.0);

//// && IsConjunction(SolarSystem.Neptune, SolarSystem.Saturn, date, 30.0)
    && IsPericentre(SolarSystem.Jupiter, date, 10.0)
    && IsRightAngle(SolarSystem.Jupiter, SolarSystem.Neptune, date, 30.0);

    * result = IsConjunction(SolarSystem.Jupiter, SolarSystem.Saturn, date, 30)
    && IsConjunction(SolarSystem.Uranus, SolarSystem.Neptune, date, 30.0)
    && IsPericentre(SolarSystem.Jupiter, date, 10.0)
    && IsRightAngle(SolarSystem.Jupiter, SolarSystem.Neptune, date, 30.0);

var ju = Angles.BalancedAxisOf(SolarSystem.Jupiter.Longitude, 1.0, SolarSystem.Uranus.Longitude, 1.0);
var sn = Angles.BalancedAxisOf(SolarSystem.Saturn.Longitude, 1.0, SolarSystem.Neptune.Longitude, 1.0);
return Angles.EqualDeg180(ju, sn, 1.0);

result = IsConjunction(SolarSystem.Mercury, SolarSystem.Earth, date, 30)
        && IsConjunction(SolarSystem.Venus, SolarSystem.Mars, date, 30)
        && IsOpposition(SolarSystem.Venus, SolarSystem.Earth, date, 30);
                   
////        && IsRightAngle(SolarSystem.Jupiter, SolarSystem.Earth, date, 30)                           
////        && IsRightAngle(SolarSystem.Jupiter, SolarSystem.Venus, date, 30);
result = IsConjunction(SolarSystem.Mercury, SolarSystem.Venus, date, 30)
        && IsConjunction(SolarSystem.Mercury, SolarSystem.Earth, date, 30)
        && IsConjunction(SolarSystem.Venus, SolarSystem.Earth, date, 30);
    * 
result = IsOpposition(SolarSystem.Jupiter, SolarSystem.Saturn, date, 30)
            && IsOpposition(SolarSystem.Jupiter, SolarSystem.Uranus, date, 60)
            && IsOpposition(SolarSystem.Jupiter, SolarSystem.Neptune, date, 60); 
//// result = IsRightAngle(SolarSystem.Uranus, SolarSystem.Neptune, date, 1);
//// result = IsPericentre(SolarSystem.Uranus, date, 3.0) && IsPericentre(SolarSystem.Neptune, date, 3.0); 
//// result = IsPericentre(SolarSystem.Jupiter, date, 1.0);
//// result = IsOrbitalResonance(1, SolarSystem.Jupiter, +1, SolarSystem.Uranus, -1, SolarSystem.Neptune, 180, 360, date, 1.0);
//// result = IsPericentre(SolarSystem.Mars, date, 0.9);
//// result = IsApocentre(SolarSystem.Mars, date, 0.1);
//// result = IsPericentre(SolarSystem.Mars, date, 0.4);
//// result = IsResonance(1, SolarSystem.Mercury, -5, SolarSystem.Venus, -4, SolarSystem.Earth, +15, SolarSystem.Mars, 0, 360, date, 5.0);
////           && IsResonance(5, SolarSystem.Venus, -15, SolarSystem.Mars, 0, 360, date, 5.0);

////result = IsConjunction(SolarSystem.Jupiter, SolarSystem.Saturn, date, 5);
////
//// result = IsOrbitalResonance(1, SolarSystem.Jupiter, +1, SolarSystem.Uranus, -1, SolarSystem.Neptune,180, 360, date, 1.0);
//// result = IsOrbitalResonance(2, SolarSystem.Jupiter, 3, SolarSystem.Venus, -5, SolarSystem.Earth, 0, 180, date, 1.0);

//// result = IsPericentre(SolarSystem.Jupiter, date, 1.0); ////  && IsPericentre(SolarSystem.Jupiter, date, 5.0);
//// result = IsOrbitalResonance(1, SolarSystem.Jupiter, +1, SolarSystem.Uranus, -1, SolarSystem.Neptune, 180, 360, date, 0.3);

result = IsOrbitalResonance(2, SolarSystem.Jupiter, 3, SolarSystem.Venus, -5, SolarSystem.Earth, 0, 180, date, 1.0);
result = IsOrbitalResonance(2, SolarSystem.Jupiter, 3, SolarSystem.Venus, -5, SolarSystem.Earth, 90, 180, date, 1.0);

result = IsOrbitalResonance(1, SolarSystem.Jupiter, +1, SolarSystem.Uranus, -1, SolarSystem.Neptune, 180, 360, date, 0.3);                     
result = IsOrbitalResonance(1, SolarSystem.Jupiter, +1, SolarSystem.Uranus, -1, SolarSystem.Neptune, 0, 360, date, 0.3);
//// result = IsConjunction(SolarSystem.Jupiter.Longitude + SolarSystem.Uranus.Longitude - SolarSystem.Neptune.Longitude, SolarSystem.Jupiter.LP - 180, 5);

//// result = IsResonance(1, SolarSystem.Jupiter, +1, SolarSystem.Uranus, -1, SolarSystem.Neptune, 180, 360, date, 0.3);
//// result = IsResonance(1, SolarSystem.Jupiter, +1, SolarSystem.Uranus, -1, SolarSystem.Neptune, 0, 360, date, 0.3);
//// result = IsResonance(1, SolarSystem.Saturn, -1, SolarSystem.Uranus, 1, SolarSystem.Neptune, 90, 360, date, 0.2);
//// result = IsResonance(1, SolarSystem.Saturn, -1, SolarSystem.Uranus, 1, SolarSystem.Neptune, -90, 360, date, 0.2);
//// result = IsPericentre(SolarSystem.Jupiter, date, 0.5);
//// result = IsPericentre(SolarSystem.Mars, date, 0.5); //// || IsApocentre(SolarSystem.Jupiter, date, 0.5); 
//// result = IsPericentre(SolarSystem.Saturn, date, 0.5) || IsApocentre(SolarSystem.Saturn, date, 0.5); 
//// result = IsPericentre(SolarSystem.Jupiter, date, 0.5);//// || IsApocentre(SolarSystem.Jupiter, date, 0.5); 
//// result = IsResonance(SolarSystem.Jupiter, SolarSystem.Neptune, SolarSystem.Uranus, date, 0.4);
//// result = IsResonance(SolarSystem.Jupiter, SolarSystem.Uranus, SolarSystem.Neptune, date, 0.4);
////result = IsResonance(SolarSystem.Saturn, SolarSystem.Uranus, SolarSystem.Neptune, date, 0.2);

//// result = IsConjunction(SolarSystem.Earth, SolarSystem.Venus, date, 1);
//// result = IsResonance(SolarSystem.Jupiter, SolarSystem.Uranus, SolarSystem.Neptune, date, 1)
////         && IsConjunction(SolarSystem.Earth, SolarSystem.Venus, date, 30);
//// result = IsResonance(SolarSystem.Saturn, SolarSystem.Uranus, SolarSystem.Neptune, date, 0.5);
//// result = IsResonance(SolarSystem.Jupiter, SolarSystem.Neptune, SolarSystem.Uranus, date, 1);
////result = IsConjunction(SolarSystem.Jupiter, SolarSystem.Uranus, date, 10)
////           && IsRightAngle(SolarSystem.Jupiter, SolarSystem.Neptune, date, 5);
//// result = IsRightAngle(SolarSystem.Uranus, SolarSystem.Neptune, date, 1)  && IsConjunction(SolarSystem.Jupiter, SolarSystem.Neptune, date, 1);
//// result = IsRightAngle(SolarSystem.Uranus, SolarSystem.Neptune, date, 0.2);
////  result = IsRightAngle(SolarSystem.Jupiter, SolarSystem.Saturn, date, 10)
////        && IsRightAngle(SolarSystem.Saturn, SolarSystem.Uranus, date, 20); 
//// double value = SolarMaxApproxValue(date,0);
//// result = value > 10;
//// result = IsConjunction(SolarSystem.Jupiter.Longitude + SolarSystem.Uranus.Longitude - SolarSystem.Neptune.Longitude, SolarSystem.Jupiter.LP - 180, 5);
//// result = true;
                    
Mayan
date = shift + Julian.MayanDay(9, 15, 6, 13, 1);
x = IsConjunction(SolarSystem.Mercury, SolarSystem.Earth, date, 20); ////15
if (!x) {
    return false;
} 
 * 
date = shift + Julian.MayanDay(8, 17, 11, 3, 0);
x = IsAspect(SolarSystem.Earth, SolarSystem.Mars, date, 30); ////30
if (!x) {
    return false;
}
 * 
 * 
date = shift + Julian.MayanDay(9, 13, 17, 15, 12);
x = IsAspect(SolarSystem.Jupiter, SolarSystem.Saturn, date, 45); //// 90
if (!x) {
    return false;
} 

 * 
var rec = new MayanRecord(6, 1, 11, 3, 1, "RJS-a", true);
date = shift + rec.MayanDay();
bool p = IsConjunction(SolarSystem.Jupiter, SolarSystem.Saturn, date, 40); //// 90
bool q = IsConjunction(SolarSystem.Mars, SolarSystem.Jupiter, date, 40);  //// 40
bool r = IsConjunction(SolarSystem.Mars, SolarSystem.Saturn, date, 40);  //// 40
x = p && q && r;
if (!x) {
    return false;
}

 * 
date = shift + Julian.MayanDay(8, 16, 14, 15, 4);
bool a = IsConjunction(SolarSystem.Jupiter, SolarSystem.Saturn, date, 40); //// 90
bool b = IsOpposition(SolarSystem.Earth, SolarSystem.Jupiter, date, 40);  //// 40
bool c = IsOpposition(SolarSystem.Earth, SolarSystem.Saturn, date, 40);  //// 40
x = a && b && c;
if (!x) {
    return false;
} 
 * 
 * 
date = shift + Julian.MayanDay(10, 17,  2, 15, 12);
x = IsConjunction(SolarSystem.Mercury, SolarSystem.Earth, date, 30);
if (!x) {
    return false;
}
            
date = shift + Julian.MayanDay(9, 18, 1, 7, 9);
x = IsConjunction(SolarSystem.Venus, SolarSystem.Mars, date, 45);
if (!x) {
    return false;
}
            
date = shift + Julian.MayanDay(9, 16, 8, 16, 10);
bool f1 = IsConjunction(SolarSystem.Mercury, SolarSystem.Earth, date, 40);
bool g1 = IsOpposition(SolarSystem.Mars, SolarSystem.Earth, date, 40);
x = x && f1 && g1;

date = shift + Julian.MayanDay(9, 17, 4, 15, 3);
bool f2 = IsConjunction(SolarSystem.Mercury, SolarSystem.Earth, date, 40);
bool g2 = IsOpposition(SolarSystem.Mars, SolarSystem.Earth, date, 40);
x = x && f2 && g2;
            //// return IsConjunction(SolarSystem.Venus, SolarSystem.Earth, date + 85970.0, this.DegEps);
    Mayan
date = shift + Julian.MayanDay(8, 16, 14, 15, 4);
bool a = IsConjunction(SolarSystem.Jupiter, SolarSystem.Saturn, date, 90); //// 90
bool b = IsAspect(SolarSystem.Earth, SolarSystem.Jupiter, date, 40);  //// 40
bool c = IsAspect(SolarSystem.Earth, SolarSystem.Saturn, date, 40);  //// 40
x = a && b && c;
if (!x) {
    return false;
}

double date = shift + Julian.MayanDay(9, 13, 17, 15, 12);
bool x = IsConjunction(SolarSystem.Jupiter, SolarSystem.Saturn, date, 15);

date = shift + Julian.MayanDay(9, 14, 17, 15, 11);
x = IsConjunction(SolarSystem.Jupiter, SolarSystem.Saturn, date, 15); */