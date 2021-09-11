// <copyright file="DateListOutput.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Lists
{
    using JetBrains.Annotations;
    using AstroSharedOrbits.Dwarfs;
    using AstroSharedOrbits.Systems;
    using System;
    using System.Globalization;
    using AstroSharedOrbits.Orbits;
    using global::AstroSharedClasses.Computation;
    using global::AstroSharedClasses.Enums;
    using global::AstroSharedClasses.Calendars;
    using AstroSharedEvents.Crossing;

    /// <summary>
    /// Date List.
    /// </summary>
    public partial class EventList: DateList
    {
        /// <summary>
        /// The energy j
        /// </summary>
        public OrbitEnergy energyJ = new OrbitEnergy();
        public OrbitEnergy energyS = new OrbitEnergy();

        #region MayanConstants
        /// <summary>
        /// Mayan Correlation Constant.
        /// </summary>
        [UsedImplicitly]
        public const long MayanCorrelationConstant = 508392;
        //// public const long MayanCorrelationConstant = 584285;
        //// public const long MayanCorrelationConstant = 622261; //// Bohm
        #endregion

        #region Fields
        /// <summary>
        /// The last value.
        /// </summary>
        private double lastValue;

        /// <summary>
        /// The last v
        /// </summary>
        private double lastV = 0;

        /// <summary>
        /// The last v2
        /// </summary>
        private double lastV2 = 0;

        /// <summary>
        /// The last v3
        /// </summary>
        private double lastV3 = 0;

        /// <summary>
        /// The last v4
        /// </summary>
        private double lastV4 = 0;

        /// <summary>
        /// The last julian date v
        /// </summary>
        private double lastJulianDateV = -1000;
        //// private double lastB1 = -1000;
        //// private double lastA1 = -1000;
        #endregion

        #region Public methods
        /// <summary>
        /// VYPIS POZIC PLANET (TABULKY).
        /// </summary>
        /// <param name="charact">The charact.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public string PrintCharacteristic(AstCharacteristic charact)
        { //// AstSystem system
            //// double diff = 0;
            this.List.Append("<HTML>\n\r");
            this.List.Append("<PRE>\n\r");
            //// foreach (double julianDate in this.Date) {
            for (var i = 0; i < this.Date.Count; i++)
            {
                var julianDate = this.Date[i];

                var addNewLine = this.PrintDateRecord(i, julianDate, charact, Julian.JulianYear); //// ref diff ref lastResult

                if (addNewLine)
                {
                    this.List.Append("\n"); // NEW LINE
                }

                this.LastJulianDate = julianDate;
            }

            this.List.Append("</PRE>\n\r");
            this.List.Append("</HTML>\n\r");

            return this.List.ToString();
        }

        /// <summary>
        /// Prints the date record.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="charact">The charact.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <returns> Returns value. </returns>
        public bool PrintDateRecord(int i, double julianDate, AstCharacteristic charact, double timeUnit)
        { //// ref double diff, , ref string lastResult
            var info = i < this.Info.Count ? this.Info[i] : string.Empty;

            var addNewLine = false;
            //// SystemManager.SetJulianDate(julianDate);
            SolarSystem.Singleton.SetJulianDate(julianDate);
            //// temporary 2020/03 EarthSystem.SetJulianDate(julianDate);

            double diff = 0;
            switch (charact)
            {
                case AstCharacteristic.DateDiffs:
                    if (this.LastJulianDate > -10000000)
                    {
                        diff = julianDate - this.LastJulianDate;
                    }

                    addNewLine = false;
                    this.OutputDateDiffs(julianDate, timeUnit, info, diff);
                    //// this.OutputDateDiffsVuckevic(julianDate, timeUnit, info, diff);
                    break;

                case AstCharacteristic.DateDiffsOuter:
                    if (this.LastJulianDate > -10000000)
                    {
                        diff = julianDate - this.LastJulianDate;
                    }

                    addNewLine = false;
                    this.OutputDateDiffsOuter(julianDate, timeUnit, info, diff);
                    //// this.OutputDateDiffsVuckevic(julianDate, timeUnit, info, diff);
                    break;

                case AstCharacteristic.DateDiffsZharkova:
                    if (this.LastJulianDate > -10000000)
                    {
                        diff = julianDate - this.LastJulianDate;
                    }

                    addNewLine = false;
                    this.OutputDateDiffsZharkova(julianDate, timeUnit, info, diff);
                    //// this.OutputDateDiffsVuckevic(julianDate, timeUnit, info, diff);
                    break;               

                case AstCharacteristic.LongitudesOuter:
                    addNewLine = true;
                    this.OutputLongitudesOuter(julianDate);
                    break;

                case AstCharacteristic.LongitudesInner:
                    addNewLine = true;
                    this.OutputLongitudesInner(julianDate);
                    break;

                case AstCharacteristic.LongitudesSun:
                    //// dist = 
                    this.OutputLongitudesSun(julianDate);
                    break;

                case AstCharacteristic.Distances:
                    //// dist = 
                    this.OutputDistances(julianDate);
                    break;

                case AstCharacteristic.SunInfluences:
                    this.OutputSunInfluences(julianDate);
                    break;

                case AstCharacteristic.OrientedBaryAxis:
                    addNewLine = this.OutputOrientedBaryAxis(julianDate);
                    break;

                case AstCharacteristic.Conjunctions:
                    this.OutputConjunctions(julianDate);
                    break;

                case AstCharacteristic.LongitudesToExcel:
                    addNewLine = true;
                    this.OutputLongitudesToExcel(julianDate);
                    break;

                case AstCharacteristic.EarthSystem:
                    addNewLine = true;
                    this.OutputEarthSystem(julianDate, info);

                    break;

                case AstCharacteristic.Experiment:
                    {
                        //// this.OutputTidalExcell(julianDate);
                        this.OutputExperiment(julianDate);
                        break;
                    }

                case AstCharacteristic.None:
                    break;

                    //// default: break;
            }

            return addNewLine;
        }

        /// <summary>
        /// Appends the solar maximum approx values.
        /// </summary>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public double AppendSolarMaxApproxValues()
        {
            double longJ = Angles.Mod360(SolarSystem.Singleton.Jupiter.Longitude);
            double longJa = Angles.Mod360(SolarSystem.Singleton.Jupiter.LP - 180);
            double longS = Angles.Mod360(SolarSystem.Singleton.Saturn.Longitude);
            //// double Sa = Angles.Mod360(SolarSystem.Singleton.Saturn.LP - 180);
            //// double Sp = Angles.Mod360(SolarSystem.Singleton.Saturn.LP);
            double longU = Angles.Mod360(SolarSystem.Singleton.Uranus.Longitude);
            double longN = Angles.Mod360(SolarSystem.Singleton.Neptune.Longitude);
            /*
            double gJJa = Angles.Sinus((longJ - longJa) / 2);
            double gJS = Angles.Sinus(longJ - longS);
            double gJU = Angles.Sinus(longJ - longU);
            double gJN = Angles.Sinus(longJ - longN);
            double gSU = Angles.Sinus(longS - longU);
            double gSN = Angles.Sinus(longS - longN);
            double gUN = Angles.Sinus(longU - longN);
            */
            double gJRes = Angles.Cosin((longJ - longJa + longU - longN) / 2); //// only one extreme on 360dg
            double gSRes = Angles.Cosin(longS - longJa + 3 * longU - 4 * longN);

            double g3Res = Angles.Sinus((2 * (longJ - longJa) - 4 * longS + 2 * longN) / 2);
            double g4Res = Angles.Cosin(1 * (longJ - longJa) + 2 * longU - 3 * longN);

            //// double g3Res = Angles.Cosin((2*(J - Ja)  - 3 * S + 3 * U - 2 * N)/2);
            //// double g4Res = Angles.Cosin(( 1 * S + 3 * U - 4 * N));

            //// double g3Res = Angles.Cosin((J - Ja - 2 * S + 4 * U - 3 * N));
            //// double g4Res = Angles.Cosin((J - Ja - 3 * S + 4 * U - 2 * N) / 2);

            //// double g3Res = Angles.Cosin((J/3 + S/2)); //// only one extreme on 360dg
            //// double g4Res = Angles.Cosin((3*S - U)/2); //// only one extreme on 360dg

            //// double vJJa = 10 * (Math.Abs(gJJa));
            /*
            double vJJa = 10 * Math.Abs(gJJa);
            double vJS = 10 * Math.Abs(gJS);
            double vJU = 10 * Math.Abs(gJU);
            double vJN = 10 * Math.Abs(gJN);
            double vSU = 10 * Math.Abs(gSU);
            double vSN = 10 * Math.Abs(gSN);
            double vUN = 10 * Math.Abs(gUN);
            */
            double vJRes = 10 * Math.Abs(gJRes);
            double vSRes = 10 * Math.Abs(gSRes);
            double v3Res = 10 * Math.Abs(g3Res);
            double v4Res = 10 * Math.Abs(g4Res);

            //// double univalue = vJJa + vJS + vJU + vJN + vSU + vSN + vUN;
            //// double value = 0.0 * vJJa + 1.0 * vJS + 0.0 * vJU + 1.0 * vJN + 1.0 * vSU + 0.0 * vSN + 1.0 * vUN; //// value > 3
            double value = 1.0 * vJRes + 1.0 * vSRes + 1.0 * v3Res + 1.0 * v4Res;
            //// + 0.0 * vJJa + 0.0 * vJS + 0.0 * vJU + 0.0 * vJN + 0.0 * vSU + 0.0 * vSN + 0.0 * vUN;

            if (value > 1.0 && value > this.lastValue)
            {
                this.List.Append("***");
            }
            else
            {
                this.List.Append("   ");
            }

            //// "JS{4,4:F1} JU{5,4:F1} JN{6,4:F1} SU{7,4:F1} SN{8,4:F1} UN{9,4:F1} ",
            //// vJS, vJU, vJN, vSU, vSN, vUN);
            this.List.AppendFormat(
                            "V{0,5:F1} Rj{1,5:F1} Rs{2,5:F1} R3{3,5:F1} R4{4,5:F1} ",
                             value,
                             vJRes,
                             vSRes,
                             v3Res,
                             v4Res);

            this.lastValue = value;
            return value;
        }

        /// <summary>
        /// Appends the solar resonance angles.
        /// </summary>
        [UsedImplicitly]
        private void AppendSolarResonanceAngles()
        {
            //// var deltaUN = Angles.Mod360Sym(SolarSystem.Neptune.Longitude - SolarSystem.Uranus.Longitude);
            //// var deltaJS = Angles.Mod360Sym(SolarSystem.Saturn.Longitude - SolarSystem.Jupiter.Longitude);
            //// var rx = Angles.Mod360Sym(deltaUN - deltaJJa);
            //// var sx = Angles.Mod180Sym(deltaUN - deltaJS + 90);    //// 1/J-1/S-1/U+1/N
            //// var x = Angles.Cosin(2 * deltaUN);
            //// var correction = 120 * x * Math.Abs(x)

            var deltaJJp = Angles.Mod360Sym(SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Jupiter.LP);
            var delta2S = Angles.Mod360Sym(2 * SolarSystem.Singleton.Saturn.Longitude);
            var longitudeN = Angles.Mod360Sym(SolarSystem.Singleton.Neptune.Longitude);
            var angle = 3 * (SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Jupiter.LP) - 8 * (SolarSystem.Singleton.Saturn.Longitude)
              - SolarSystem.Singleton.Uranus.Longitude + 5 * SolarSystem.Singleton.Neptune.Longitude;

            this.List.AppendFormat(
                    " JJp:{0,4:F0} 2S:{1,4:F0} N:{2,4:F0}   RA:{3,4:F0}     ",
                    deltaJJp,
                    delta2S,
                    longitudeN,
                    Angles.Mod360Sym(angle - 180));
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Outputs the earth system.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="info">The information.</param>
        private void OutputEarthSystem(double julianDate, string info)
        {
            //// const bool otherPlanets = false; if (otherPlanets) {
            //// SolarSystem.Venus.SetJulianDate(julianDate); SolarSystem.Jupiter.SetJulianDate(julianDate);
            //// }
            var moonDistProc = ((EarthSystem.Moon.Point.RT / EarthSystem.Moon.A) - 1) * 100;
            var earthDistProc = ((EarthSystem.Earth.Point.RT / EarthSystem.Earth.A) - 1) * 100;
            var lunarPhase = Angles.Mod360Sym(EarthSystem.Earth.Longitude - EarthSystem.Moon.Longitude);
            var angleToNode = Angles.Mod180Sym(EarthSystem.Moon.LW - EarthSystem.Moon.Longitude);

            //// if (Math.Abs(angleToEcliptic) < 30 || Math.Abs(angleToEcliptic) > 60) { //// Math.Abs(lunarPhase) < 30) 
            //// if (Math.Abs(angleToEcliptic) >= 30 && Math.Abs(angleToEcliptic) <= 60) { //// Math.Abs(lunarPhase) < 30) 
            //// if (Math.Abs(lunarPhase) <= 45 && Math.Abs(angleToEcliptic) <= 45) {
            //// if (moonDistProc<-5) {
            //// degrees 00B0
            //// double timelgh = AstroMath.Frac(julianDate)*360;
            this.List.Append(Julian.CalendarDate(julianDate, true) + " ");
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));
            this.List.AppendFormat("{0}\n\r", info);
            this.List.AppendFormat(" MOON    LGH:{0,7:F2}°        LAT:{1,7:F2}°  DISTANCE: {2,6:F2}%\n\r", EarthSystem.Moon.Longitude, EarthSystem.Moon.Point.Latitude, moonDistProc);
            this.List.AppendFormat(" EARTH   LGH:{0,7:F2}°        LAT:{1,7:F2}°  DISTANCE: {2,6:F2}%\n\r", EarthSystem.Earth.Longitude, EarthSystem.Earth.Point.Latitude, earthDistProc);
            //// if (otherPlanets) {
            ////     this.List.AppendFormat(" Venus   LGH:{0,7:F2}°        LAT:{1,7:F2}°\n\r", SolarSystem.Venus.Longitude, SolarSystem.Venus.Latitude);
            ////     this.List.AppendFormat(" Jupiter LGH:{0,7:F2}°        LAT:{1,7:F2}°\n\r", SolarSystem.Jupiter.Longitude, SolarSystem.Jupiter.Latitude);
            //// }

            this.List.AppendFormat(" LUNAR PHASE:{0,7:F2}°       NODE:{1,7:F2}°\n\r", lunarPhase, angleToNode);
            //// }
            //// this.List.AppendFormat(" TIME   LGH:{0,6:F2}   MON:{1,6:F2}\n", timelgh, Angles.Mod360(timelgh - EarthSystem.Moon.Longitude));
            //// this.List.AppendFormat(" QUAKE  LGH:{0,6:F2}   LAT:{1,6:F2} ", EarthSystem.Moon.Longitude, EarthSystem.Moon.Latitude);

            //// this.List.AppendFormat(" {0,10}:{1,6:F2}:{2,6:F2}\n", EarthSystem.MoonMeeus.Name, EarthSystem.MoonMeeus.Longitude, EarthSystem.MoonMeeus.Latitude);
            //// this.List.AppendFormat(" {0,10}:{1,6:F2}:{2,6:F2}\n", EarthSystem.MoonSchlyter.Name, EarthSystem.MoonSchlyter.Longitude, EarthSystem.MoonSchlyter.Latitude);
            //// this.List.AppendFormat(" {0,10}:{1,6:F2}:{2,6:F2}\n", EarthSystem.MoonChapront.Name, EarthSystem.MoonChapront.Longitude, EarthSystem.MoonChapront.Latitude);
            //// this.List.AppendFormat(" {0,10}:{1,6:F2}:{2,6:F2}\n", EarthSystem.MoonNaughter.Name, EarthSystem.MoonNaughter.Longitude, EarthSystem.MoonNaughter.Latitude);
        }

        /// <summary>
        /// Outputs the longitudes to excel.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        private void OutputLongitudesToExcel(double julianDate)
        {
            this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(julianDate));
            for (var k = 0; k < (int)AstPlanet.Count - 1; k++)
            {
                if (k < (int)AstPlanet.Mercury || k > (int)AstPlanet.Neptune)
                {
                    continue;
                }

                var orbitB = SolarSystem.Singleton.Orbit[k];
                this.List.AppendFormat("{0,4:F0}\t", orbitB.Longitude);
            }

            for (var k = 0; k < (int)AstPlanet.Count - 1; k++)
            {
                if (k < (int)AstPlanet.Mercury || k > (int)AstPlanet.Neptune)
                {
                    continue;
                }

                var orbitB = SolarSystem.Singleton.Orbit[k];
                this.List.AppendFormat("{0,4:F0}\t", orbitB.LP);
            }

            //// double m = SolarSystem.Mercury.Longitude;
            var v = SolarSystem.Singleton.Venus.Longitude;
            var e = SolarSystem.Singleton.Earth.Longitude;
            //// double r = SolarSystem.Mars.Longitude; 

            var j = SolarSystem.Singleton.Jupiter.Longitude;
            //// double s = SolarSystem.Saturn.Longitude;
            var u = SolarSystem.Singleton.Uranus.Longitude;
            var n = SolarSystem.Singleton.Neptune.Longitude;

            var jp = SolarSystem.Singleton.Jupiter.LP;

            var jjp = Angles.Mod360(j - jp);
            var un = Angles.Mod360(u - n);
            var ve = Angles.Mod360(3 * v - 3 * e);
            var je = Angles.Mod360(2 * j - 2 * e);
            var ro = Angles.Mod360(jjp + un);
            var ri = Angles.Mod360(ve + je);

            this.List.AppendFormat("{0,4:F0}\t", jjp);
            this.List.AppendFormat("{0,4:F0}\t", un);
            this.List.AppendFormat("{0,4:F0}\t", ve);
            this.List.AppendFormat("{0,4:F0}\t", je);

            this.List.AppendFormat("{0,4:F0}\t", ri);
            this.List.AppendFormat("{0}\t", Angles.EqualDeg180(ri, 0, 10) ? "MAX" : (Angles.EqualDeg180(ri, 90, 10) ? "MIN" : string.Empty));

            this.List.AppendFormat("{0,4:F0}\t", ro);
            this.List.AppendFormat("{0}\t", Angles.EqualDeg(ro, 180, 10) ? "MAX" : (Angles.EqualDeg(ro, 0, 10) ? "MIN" : string.Empty));
        }


        /// <summary>
        /// Outputs the experiment.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        private void OutputExperiment(double julianDate) {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            ////  this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            var y = Julian.Year(julianDate);
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", y);

            var d1 = Angles.Mod360Sym(Lj - Ls);
            var d2 = Angles.Mod360Sym(Lj - Lu);
            var d3 = Angles.Mod360Sym(Lj - Ln);
            
            var f1 = Angles.Cosin(d1);
            var f2 = -Angles.Sinus(d2);
            var f3 = -Angles.Sinus(d3);

            var c1 = 50 * f1 * f1 * f1;
            var c2 = 50 * f2 * f2 * f2;
            var c3 = 100 * f3 * f3 * f3;

            var f = 1.5*(c1 + c2 + c3);

            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", f);
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", c1);
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", c2);
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", c3);
            this.List.AppendFormat(CultureInfo.InvariantCulture, "\n ");

            /*
            var f1 = Angles.Mod360Sym(Lj - Ls);
            var f2 = Angles.Mod360Sym(Lj - Lu - 90);
            var f = 0.0000;
            if (f1 < 45) {
                f += 2*(45 - f1);
            }

            if (f2 < 45) {
                f += Math.Abs(45 - f2);
            }
            */
        }


        public double RunningTotalPeriod;
        public int RunningNumberOfPeriods;

        /// <summary>
        /// Outputs the experiment.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        private void OutputPlanetcentrePeriod(double julianDate)
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            ////  this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            var y = Julian.Year(julianDate);
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", y);

            var Lp = SolarSystem.Singleton.Planetcentre.Longitude;
            var Rp = SolarSystem.Singleton.Planetcentre.RT;
            var Rps = Rp / AstroMath.AstroUnit;   //// / SolarSystem.Singleton.Sun.Body.Radius;

            //// ϖ = suma(mi.ri2.ωi) / (ṟ2.suma(mi))
            var mass = SolarSystem.Singleton.PlanetMass;
            var omega = SolarSystem.Singleton.MomentSum / Rp / Rp / mass;
            var period  =  2 * Math.PI / omega / AstroMath.SecondsInDay / 365.25;

            this.RunningTotalPeriod += period;
            this.RunningNumberOfPeriods++;
            var meanPeriod = this.RunningTotalPeriod / this.RunningNumberOfPeriods;

            if (y > 2195) {
                this.List.AppendFormat("J{0,4:F0}\tS{1,4:F0}\tU{2,4:F0}\tN{3,4:F0}\tC{4,4:F0}\t", Lj, Ls, Lu, Ln, Lp);
                this.List.AppendFormat("{0,10:F4}\t", Rps);
                this.List.AppendFormat("{0,10:F4}\t", period);
                this.List.AppendFormat("{0,10:F4}", meanPeriod);

                //// this.List.AppendFormat(CultureInfo.InvariantCulture, "\t");
                this.List.AppendFormat(CultureInfo.InvariantCulture, "\n ");
            }
        }

        /// <summary>
        /// Outputs the experiment outher cosines.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        private void OutputExperimentOutherCosines(double julianDate) {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var Lp = BodyPluto.EclipticLongitude(julianDate);

            ////  this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            var y = Julian.Year(julianDate);
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", y);

            this.List.AppendFormat("{0,4:F0}\t", Lu);
            this.List.AppendFormat("{0,4:F0}\t", Ln);
            this.List.AppendFormat("{0,4:F0}\t", Lp);

            this.List.AppendFormat(CultureInfo.InvariantCulture, "\t");

            var value1 = 25 * Angles.Cosin(Lu - Ln);  //// 60, 100
            var value2 = 50 * Angles.Cosin(Lu - Lp);  //// 80, 40
            var value3 = 100 * Angles.Cosin(Ln - Lp);  //// 100, 60

            this.List.AppendFormat("{0,7:F2}\t", value1);
            this.List.AppendFormat("{0,7:F2}\t", value2);
            this.List.AppendFormat("{0,7:F2}\t", value3);

            this.List.AppendFormat("{0,7:F2}\t", value1 + value2 + value3);

            this.List.AppendFormat(CultureInfo.InvariantCulture, "\n ");
        }

        /// <summary>
        /// Outputs the aspects x.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        private void OutputAspectsX(double julianDate)
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var Lx = SolarSystem.Singleton.PlanetX.Longitude;

            ////  this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            var y = Julian.Year(julianDate);
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", y);

            this.List.AppendFormat("{0,4:F0}\t", Lj);
            this.List.AppendFormat("{0,4:F0}\t", Ls);
            this.List.AppendFormat("{0,4:F0}\t", Lu);
            this.List.AppendFormat("{0,4:F0}\t", Ln);
            this.List.AppendFormat("{0,4:F0}\t", Lx);

            this.List.Append(Constellation.IsConjunction(Lj, Lx, 10) ? " JX," : string.Empty);
            this.List.Append(Constellation.IsConjunction(Ls, Lx, 10) ? " SX," : string.Empty);
            this.List.Append(Constellation.IsConjunction(Lu, Lx, 10) ? " UX," : string.Empty);
            this.List.Append(Constellation.IsConjunction(Ln, Lx, 10) ? " NX," : string.Empty);

            this.List.Append(Constellation.IsOpposition(Lj, Lx, 10) ? " J-X," : string.Empty);
            this.List.Append(Constellation.IsOpposition(Ls, Lx, 10) ? " S-X," : string.Empty);
            this.List.Append(Constellation.IsOpposition(Lu, Lx, 10) ? " U-X," : string.Empty);
            this.List.Append(Constellation.IsOpposition(Ln, Lx, 10) ? " N-X," : string.Empty);

            this.List.AppendFormat(CultureInfo.InvariantCulture, "\n ");
        }

        /// <summary>
        /// Outputs the experiment new beats.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        private void OutputExperimentNewBeats(double julianDate)
        {
            ////  this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            var y = Julian.Year(julianDate);
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", y);

            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var Lnp = 60; //// SolarSystem.Singleton.Neptune.LP;
            var Lx = SolarSystem.Singleton.PlanetX.Longitude;
            var Lxp = 240; //// SolarSystem.Singleton.Neptune.LP;

            var Xn = SolarSystem.Singleton.Neptune.Point.XH;
            var Xx = SolarSystem.Singleton.PlanetX.Point.XH;
            var Yn = SolarSystem.Singleton.Neptune.Point.YH;
            var Yx = SolarSystem.Singleton.PlanetX.Point.YH;

           /*  var P = new SpacePoint();
            P.XH = Xn + Xx;
            P.YH = Yn + Yx;
            P.RecomputeSphericals(); */

            //// Beats N-X
            var fn = 100 * Angles.Cosin(Ln-Lnp+180);
            var fx = 100 * Angles.Cosin(Lx-Lxp+180);
            var fs = fn + fx;
            var fd = fn - fx;
            //// var ft = 100 * Angles.Cosin(P.Longitude);
            
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,4:F0}\t{1,4:F0}\t{2,4:F0}\t{3,4:F0} ",
                fn,
                fx,
                Math.Abs(fs),
                fd);

            this.List.AppendFormat(CultureInfo.InvariantCulture, "\n ");
        }

        /// <summary>
        /// Outputs the experiment outer resonance.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        private void OutputExperimentOuterResonance(double julianDate)
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            ////  this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            var y = Julian.Year(julianDate);
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", y);

            //// Kalenda  J-3S+2U-N
            var a1 = Angles.Mod360(Lj - 3* Ls);
            var a2 = Angles.Mod360(2 * Lu - Ln);
            var a3 = Angles.Mod360(3 * Lu - 3* Ln);
            var argument12 = Angles.Mod360(a1 + a2);
            var argument13 = Angles.Mod360(a1 + a3);
            var value = Angles.Mod360(360 * (y - 1838.2) / 287.78);

            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,4:F0}\t{1,4:F0}\t{2,4:F0}\t{3,4:F0}\t{4,4:F0}\t{5,4:F0}\t{6,4:F0}\t{7,4:F0} ",
                100*Angles.Sinus(a1),
                100 * Angles.Sinus(a2),
                100 * Angles.Sinus(a3),
                100 * Angles.Sinus(argument12),
                100 * Angles.Sinus(argument13),
                100 * Angles.Sinus(value),
                argument12 - 180,
                Angles.Mod360Sym(argument13 - value));
          
            this.List.AppendFormat(CultureInfo.InvariantCulture, "\n "); 
        }

        /// <summary>
        /// Outputs the experiment energy.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        private void OutputExperimentEnergy(double julianDate)
        {
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Lsp = SolarSystem.Singleton.Saturn.LP;
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;

            this.energyJ.SetOrbit(SolarSystem.Singleton.Jupiter, SolarSystem.Singleton.Sun);
            this.energyS.SetOrbit(SolarSystem.Singleton.Saturn, SolarSystem.Singleton.Sun);

            //// var Ej = 0; ////this.energyJ.Ekin / 1e30;
            //// var Es = 0; //// this.energyS.Ekin / 1e30;

            var Uj = -this.energyJ.Epot / 1e33;
            var Us = -this.energyS.Epot / 1e33;

            ////  this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(julianDate));

            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "{0,4:F0}\t{1,4:F0}\t{2,13:F0} ",
                Ljp,
                Angles.Mod360(Lj - Ljp),
                Uj);

            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,4:F0}\t{1,4:F0}\t{2,13:F0}  ",
                Lsp,
                Angles.Mod360(Ls - Lsp),
                Us);

            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,13:F0} \n ",
                Uj + Us
            );
        }

        /// <summary>
        /// Outputs the date diffs year.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        private void OutputDateDiffsYear(double julianDate, double timeUnit, string info, double diff) {
            var diff1 = julianDate - this.lastJulianDateV;
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(julianDate));
            this.List.AppendFormat("\n ");
            this.lastJulianDateV = julianDate;
        }

        /// <summary>
        /// Outputs the date diffs.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        private void OutputDateDiffs(double julianDate, double timeUnit, string info, double diff) {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Lsp = SolarSystem.Singleton.Saturn.LP;
            var Lup = SolarSystem.Singleton.Uranus.LP;
            var Lnp = SolarSystem.Singleton.Neptune.LP;

            //// if (Math.Abs(delta) < 20) {

                var diff1 = julianDate - this.lastJulianDateV;
            
                this.List.AppendFormat("{0,9:F3}\t", Math.Round(diff1 / timeUnit, 3));
                this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
                this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));

            /*    this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t{0,4:F0} {1,4:F0} {2,4:F0} {3,4:F0}",
                    Lj,
                    Ls,
                    Lu,
                    Ln);


            var dJU = Angles.Mod360Sym(Lu - Lj);
            var dJN = Angles.Mod360Sym(Ln - Lj - 90);

            var delta1 = Angles.Mod360Sym(Lu + Ln - 2* Lj);
            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t{0,4:F0} \t{1,4:F0} ", delta1, 0);
                    */
            /*
            var delta = Angles.Mod360Sym(Ln - Lj);
            this.List.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "\t{0,4:F0} ", delta);
            */
            this.List.AppendFormat("\n ");
                this.lastJulianDateV = julianDate;
            //// }

            /*
            var a = -Angles.Cosin(Lj-Ljp - 90) * 100;
            var b = -Angles.Cosin((Lj - Ls + 90) * 2 - 90) * 100;
            //// var a = Angles.Cosin((Lj - Ljp)/2) * 100;
            //// var b = Angles.Cosin((Lj - Ls + 90)) * 100;
            //// var c = -Angles.Cosin(Lu - Lup - 30) * 100;
            //// var c = Angles.Cosin((Lu - Ln + 90) - 30) * 100;
            //// var a = Angles.Sinus(Lj) * 100;
            //// var b = Angles.Sinus((Lj - Ls + 90)*2)*100;
            var f = a + b;
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "{0,7:F0}\t{1,7:F0}\t{2,7:F0}",
                a,b,f);
            */

            /*
            var axUN = Angles.AxisOf(Lu, Ln);
            var diffAxJ = Angles.Mod360Sym(axUN - Lj); 
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,4:F0} {1,4:F0} ",
                axUN,
                diffAxJ);
            */
            /*
            var dj = Angles.Mod360Sym(Lj - Ljp);
            var ds = Angles.Mod360Sym(Ls - Lsp);
            var du = Angles.Mod360Sym(Lu - Lup);
            var dn = Angles.Mod360Sym(Ln - Lnp);

            var total = Math.Abs(dj) + Math.Abs(ds) + Math.Abs(du) + Math.Abs(dn);
            if (total > 500) {
                this.List.AppendFormat(CultureInfo.CurrentCulture, " Total {0,8:F2}", total);
            }*/

            //// }
        }

        /// <summary>
        /// Outputs the date diffs ve moon.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        private void OutputDateDiffsVEMoon(double julianDate, double timeUnit, string info, double diff) {
            var Lv = SolarSystem.Singleton.Venus.Longitude;
            var Le = SolarSystem.Singleton.Earth.Longitude;
            var Lmoon = EarthSystem.Moon.Longitude;

            /// if (Angles.EqualDeg(Lv, Le, 3) && Angles.EqualDeg(Lv, Lmoon, 3) && Angles.EqualDeg(Le, Lmoon, 3)) {
            if (Angles.EqualDeg(Lv, Le, 0.4)) {
                var diff1 = julianDate - this.lastJulianDateV;
                this.List.AppendFormat("{0,9:F3}\t", Math.Round(diff1 / timeUnit, 3));
                this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
                this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(julianDate));

                this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0} {2,4:F0}", Angles.Mod360(Lv), Angles.Mod360(Le), Angles.Mod360(Lmoon));
                this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0} {2,4:F0}", 0, Angles.Mod360(Lv - Le), Angles.Mod360(Lmoon - Le));
                this.List.AppendFormat("\n ");
                this.lastJulianDateV = julianDate;
            }
        }

        /// <summary>
        /// Outputs the date diffs js.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        private void OutputDateDiffsJS(double julianDate, double timeUnit, string info, double diff)
        {
            var diff1 = julianDate - this.lastJulianDateV;
            this.List.AppendFormat("{0,8:F2}\t", Math.Round(diff1 / timeUnit, 3));
            this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(julianDate));

            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Vj = Orbit.InstantaneousVelocity(SolarSystem.Singleton.Jupiter.Point.RT, SolarSystem.Singleton.Jupiter.A) / SolarSystem.Singleton.Jupiter.Point.RT * 1e18;

            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lsp = SolarSystem.Singleton.Saturn.LP;
            var Vs = Orbit.InstantaneousVelocity(SolarSystem.Singleton.Saturn.Point.RT, SolarSystem.Singleton.Saturn.A) / SolarSystem.Singleton.Saturn.Point.RT * 1e18;

            //// var Lu = SolarSystem.Singleton.Uranus.Longitude;
            this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0}", Lj, Ljp);
            this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0}", Ls, Lsp);
            //// this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} ", Lu);

            var delta = Math.Abs(Vj - Vs * 8/3);
            if (delta > 0)
            {
                this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,7:F2} {1,7:F2} {2,15:F1}", Vj, Vs * 8/3, 1000 / delta);
            }

            this.List.AppendFormat("\n ");
            this.lastJulianDateV = julianDate;
        }

        /// <summary>
        /// Outputs the date diffs un.
        /// </summary>
        /// <param name="julianDate">The julian date.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        private void OutputDateDiffsUN(double julianDate, double timeUnit, string info, double diff)
        {
            var diff1 = julianDate - this.lastJulianDateV;
            this.List.AppendFormat("{0,8:F2}\t", Math.Round(diff1 / timeUnit, 3));
            this.List.AppendFormat("{0}\t", Julian.CalendarDate(julianDate, false));
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}\t", Julian.Year(julianDate));

            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Lup = SolarSystem.Singleton.Uranus.LP;
            var Vu = Orbit.InstantaneousVelocity(SolarSystem.Singleton.Uranus.Point.RT, SolarSystem.Singleton.Uranus.A) / SolarSystem.Singleton.Uranus.Point.RT * 1e18;

            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var Lnp = SolarSystem.Singleton.Neptune.LP;
            var Vn = Orbit.InstantaneousVelocity(SolarSystem.Singleton.Neptune.Point.RT, SolarSystem.Singleton.Neptune.A) / SolarSystem.Singleton.Neptune.Point.RT * 1e18;

            //// var Lu = SolarSystem.Singleton.Uranus.Longitude;
            this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0}", Lu, Lup);
            this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0}", Ln, Lnp);
            //// this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} ", Lu);

            var delta = Math.Abs(Vu - Vn * 2);
            if (delta > 0)
            {
                this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,7:F2} {1,7:F2} {2,15:F1}", Vu, Vn * 2, 1000 / delta);
            }

            this.List.AppendFormat("\n ");
            this.lastJulianDateV = julianDate;
        }

        /// <summary>
        /// Outputs the date diffs.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        private void OutputDateDiffsZharkova(double julianDate, double timeUnit, string info, double diff)
        {
            var diff1 = julianDate - this.lastJulianDateV;
            /*
            if (SolarSystem.Singleton.TotalQuadratureIndex < 31.95) {   ////  1.98, 5.99 ,7.991, 4.49, 27, 25, 5.98, 37.5, 35, 30, 11.5
                return;
            }
            if  (SolarSystem.Singleton.TotalAlignmentIndex + SolarSystem.Singleton.TotalQuadratureIndex < 15.00) {   //// 7.991, 4.49, 27, 25, 5.98, 37.5, 35, 30, 11.5
                return;
            } */

            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            //// var Ln = SolarSystem.Singleton.Neptune.Longitude;

            var year = Julian.Year(julianDate);
            /*
            //// this.List.AppendFormat("{0,8:F2} \t{1,8:F2} \t", Math.Round(diff1 / timeUnit, 3), year);
            this.List.AppendFormat("\t{0,8:F2} \t", year);
            this.List.Append(Julian.CalendarDate(julianDate, false));
            */

            bool sign =    (year > 1631.60 && year < 1643.67) || (year > 1655.32 && year < 1667.39)
                        || (year > 1679.05 && year < 1691.12) || (year > 1702.77 && year < 1714.84)
                        || (year > 1726.49 && year < 1738.56) || (year > 1750.22 && year < 1762.29)
                        || (year > 1773.94 && year < 1786.01) || (year > 1797.67 && year < 1809.74)
                        || (year > 1821.39 && year < 1833.46) || (year > 1845.12 && year < 1857.18)
                        || (year > 1868.84 && year < 1880.91) || (year > 1892.56 && year < 1904.63)
                        || (year > 1916.29 && year < 1928.36) || (year > 1940.01 && year < 1952.08)
                        || (year > 1963.74 && year < 1975.80) || (year > 1987.46 && year < 1999.53)
                        || (year > 2011.18 && year < 2023.25) || (year > 2034.91 && year < 2046.98)
                        || (year > 2058.63 && year < 2070.70);

            var dJS = Angles.Mod360Sym(Lj - Ls);
            var dJU = Angles.Mod360Sym(Lj - Lu + 180);
            var dJa = Angles.Mod360Sym(Lj - Ljp + 180);
            var blackvalue = Angles.Mod360(dJa / 2);
            if (sign) {
                blackvalue = Angles.Mod360(dJa / 2 + 180);
            }

            var cblue = 100* Angles.Cosin(dJS) / 2 + 50 * Angles.Cosin(dJU) / 2;
            var cblack = 100*Angles.Cosin(blackvalue);
            var cred = (cblue + cblack) / 2;
            var ctotal = (cblue + cred) * 0.9;
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "{0,4:F0}\t{1,4:F0}\t{2,4:F0}\t{3,4:F0} ",
                cblue,
                cblack,
                cred,
                ctotal
            );

            this.List.AppendFormat("\n ");
            this.lastJulianDateV = julianDate;
        }

        /*
        var Lr = SolarSystem.Singleton.Mars.Longitude;
        var Le = SolarSystem.Singleton.Earth.Longitude;
        var Lv = SolarSystem.Singleton.Venus.Longitude;
        var Lm = SolarSystem.Singleton.Mercury.Longitude;

        var dJS = Angles.Mod360(Ls - Lj);
        var dJU = Angles.Mod360(Lu - Lj);
        var dJN = Angles.Mod360(Ln - Lj);
        var dSU = Angles.Mod360(Lu - Ls);
        var dSN = Angles.Mod360(Ln - Ls);
        */
        /*
        this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\tJ {0,4:F0}\tS {1,4:F0} dJS\t{2,4:F0} dJa\t{3,4:F0}\tsign {4} red\t{5,4:F0} ",
                Lj,
                Ls,
                dJS,
                dJa,
                sign ? "-" : "+",
                redvalue
         );
         */
        /*            
this.List.AppendFormat(
CultureInfo.InvariantCulture,
"\tD {0,7:F1} {1,7:F1} {2,7:F1} {3,7:F1} ",
dJU, dJN, dSU, dSN);
*/
        /*
        var Ej = SolarSystem.Singleton.Jupiter.Potential / 1e14;
        var Es = SolarSystem.Singleton.Saturn.Potential / 1e14;
        var Eu = SolarSystem.Singleton.Uranus.Potential / 1e14;
        var En = SolarSystem.Singleton.Neptune.Potential / 1e14;
        */
        /*
        var Ej = 10.0;
        var Es = 10.0;
        var Eu = 1.0;
        var En = 1.0;

        var Euj = Eu * Angles.Cosin(dJU);
        var Enj = En * Angles.Cosin(dJN);
        var Eus = Eu * Angles.Cosin(dSU);
        var Ens = En * Angles.Cosin(dSN);
        */
        /*
        var Fj = Ej + Math.Abs(Euj) + Math.Abs(Enj);
        var Fs = Es + Math.Abs(Eus) + Math.Abs(Ens);
        */
        /*
        var Fj = Ej + Euj;
        var Fs = Es + Ens;

        var force = Fj * Fs * Math.Pow(Angles.Sinus(dJS),2);
        */
        /*
        this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tR {0,7:F1} {1,7:F1} {2,7:F1} {3,7:F1} ",
                    Euj, Enj, Eus, Ens);

        this.List.AppendFormat(
        CultureInfo.InvariantCulture,
        "\tE {0,7:F1} {1,7:F1} {2,7:F1} {3,7:F1} ",
        Ej, Es, Eu, En);
        */
        /*
        this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tF {0,12:F2} {1,12:F2} *{2,12:F2}* {3,6:F1} ",
                    Fj, Fs, force, dJS);
        */
        /*
        this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\tB {0,5:F1}\t{1,5:F1}",
                                Angles.Mod360(SolarSystem.Singleton.Barycentre.Longitude),
                                SolarSystem.Singleton.Barycentre.RT/ SolarSystem.Singleton.Sun.Body.Radius);

        this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\tG {0,5:F1}\t{1,5:F1}",
                Angles.Mod360(SolarSystem.Singleton.Gravicentre.Longitude),
                SolarSystem.Singleton.Gravicentre.RT);

        */
        /*
        this.List.AppendFormat(
            CultureInfo.InvariantCulture,
            "\t{0,8:F5} {1,8:F5} {2,8:F5} {3,8:F5} {4,8:F5}",
            SolarSystem.Singleton.TotalAlignmentIndex,
            SolarSystem.Singleton.TotalQuadratureIndex,
            SolarSystem.Singleton.TotalPerihelionIndex,
            SolarSystem.Singleton.TotalBiangularIndex,
            SolarSystem.Singleton.TotalTriangularIndex);
        */
        /*
         *             bool sign =    (year > 1626.00 && year < 1639.50) || (year > 1649.00 && year < 1660.00)
                        || (year > 1675.00 && year < 1685.00) || (year > 1693.00 && year < 1705.50)
                        || (year > 1718.20 && year < 1727.50) || (year > 1738.70 && year < 1750.30)
                        || (year > 1761.50 && year < 1769.70) || (year > 1778.40 && year < 1788.10)
                        || (year > 1805.20 && year < 1816.40) || (year > 1829.90 && year < 1837.20)
                        || (year > 1848.10 && year < 1860.10) || (year > 1870.60 && year < 1883.90)
                        || (year > 1894.10 && year < 1907.00) || (year > 1917.60 && year < 1928.40)
                        || (year > 1937.40 && year < 1947.50) || (year > 1957.90 && year < 1968.90)
                        || (year > 1979.90 && year < 1989.60) || (year > 2000.30 && year < 2012.00)
                        || (year > 2023.00 && year < 2034.00);
        */

        /// <summary>
        /// Outputs the date diffs allign.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        [UsedImplicitly]
        private void OutputDateDiffsAllign(double julianDate, double timeUnit, string info, double diff)
        {
            /*
            var tai = SolarSystem.Singleton.TotalAlignmentIndex;
            //// if (tai > 0.02) { return; }
            if (tai < 1.95) { //// 1.9998
                return;
            } */
        ////  tai > 0.02 && tai < 1.9 1.9995, 5.80, 11.22, 5.99, 46, 48, 55, 11.9, 45
        /*
        double mi = SolarSystem.Singleton.TotalAlignmentIndex * SolarSystem.Singleton.TotalPerihelionIndex;
        double q = 0;
        if (mi > 0) {
            q = Math.Sqrt(mi);
        }

        if (q < 6.0) { //// 5.99, 46, 48, 55, 11.9, 45
            return;
        }*/

        /*
        if (SolarSystem.Singleton.TotalPerihelionIndex < 3.6) { //// 3.8 5.99, 46, 48, 55, 11.9, 45
            return;
        }
        */
        /*
        if (SolarSystem.Singleton.TotalQuadratureIndex < 1) { //// 45
            return;
        }*/

        var diff1 = julianDate - this.lastJulianDateV;
            /*
            var Lm = SolarSystem.Singleton.Mercury.Longitude;
            var Lv = SolarSystem.Singleton.Venus.Longitude;
            var Le = SolarSystem.Singleton.Earth.Longitude;
            */
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            /*
            var Lja = SolarSystem.Singleton.Jupiter.Point.ActualLongitude;
            var Lsa = SolarSystem.Singleton.Saturn.Point.ActualLongitude;
            var Lua = SolarSystem.Singleton.Uranus.Point.ActualLongitude;
            var Lna = SolarSystem.Singleton.Neptune.Point.ActualLongitude;
            */
            /*
                        if (Constellation.IsConjunction(Lj, Ls, 10.0)) {
                            return;
                        }*/
            /*

            
            var dwarf = SolarSystem.Singleton.Oileus;
            var L1 = dwarf.Longitude;
            */
            ////this.List.AppendFormat("{0,8:F2} \t{1,8:F2} \t{2,8:F2} \t", Math.Round(diff1 / timeUnit, 3), Math.Round(diff1, 2), Julian.Year(julianDate));

            //// this.List.AppendFormat("{0,8:F2}", Julian.Year(julianDate));
            this.List.AppendFormat("{0,8:F2} \t{1,8:F2} \t",  Math.Round(diff1 / timeUnit, 3),   Julian.Year(julianDate));
            this.List.Append(Julian.CalendarDate(julianDate, false));
           
            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t{0,4:F0} {1,4:F0} {2,4:F0} {3,4:F0}",
                    Lj,
                    Ls,
                    Lu,
                    Ln);
            /*
            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tActual\t{0,4:F0} {1,4:F0} {2,4:F0} {3,4:F0}",
                    Lja,
                    Lsa,
                    Lua,
                    Lna);
            
            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}",
                    Lj,
                    Ij,
                    L1);

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tP{0,5:F1}\t{1,5:F1}\t{2,5:F1}\t{3,5:F1}",
                        dwarf.LP,
                        dwarf.PerihelionIndex,
                        dwarf.Point.Latitude,
                        dwarf.Point.RT / AstroMath.AstroUnit);
            */

            /*
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                " dP {0,5:F1} {1,5:F1} {2,5:F1} {3,5:F1} ",
            Angles.Mod360(Lj - SolarSystem.Singleton.Jupiter.LP),
            Angles.Mod360(Ls - SolarSystem.Singleton.Saturn.LP),
            Angles.Mod360(Lu - SolarSystem.Singleton.Uranus.LP),
            Angles.Mod360(Ln - SolarSystem.Singleton.Neptune.LP));
            */

            /*
            var sUJ = 100 * Angles.Sinus(2 * dUJ);
            var sNJ = 100 * Angles.Sinus(2 * dNJ); 
            var total = Math.Abs(sUJ) + Math.Abs(sNJ);
            //// var total = sUJ + sNJ;
            */

            /*
            var dUN = Angles.Mod360(Lu - Ln);
            var dUJ = Angles.Mod360(Lu - Lj);
            var dNJ = Angles.Mod360(Lj - Ln); //// Ln - Lj
            var axUN = Angles.Mod360((Lu + Ln) / 2);
            var dax = Angles.Mod360(axUN - Lj);
            var fceUN = 10 * Angles.Sinus(dUN);
            var fcedax = 10 * Angles.Sinus(2 * dax);
            var total = 2*Math.Abs(fceUN * fcedax);
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                    " J {0,5:F1} S {1,5:F1} axUN {2,5:F1} {3,5:F1} \t# U-J {4,5:F1} J-N {5,5:F1}",
            Lj,
            Ls,
            axUN,
            dax,
            dUJ,
            dNJ);

            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                " \t# {0,5:F1} {1,5:F1} # {2,5:F1}",
            fceUN,
            fcedax,
            total);
            */
            /*
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                " \t# {0,5:F1} {1,5:F1} # {2,5:F1}",
            sUJ,
            sNJ,
            total); */

            var Ij = SolarSystem.Singleton.Jupiter.PerihelionIndex;
            var Is = SolarSystem.Singleton.Saturn.PerihelionIndex;
            var Iu = SolarSystem.Singleton.Uranus.PerihelionIndex;
            var In = SolarSystem.Singleton.Neptune.PerihelionIndex;

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                        "\t{0,7:F3} {1,7:F3} {2,7:F3} {3,7:F3}",
                        Ij,
                        Is,
                        Iu,
                        In);

            /*
            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                        "\tL {0,5:F1} A{1,6:F4} P{2,6:F4}",
                        SolarSystem.Singleton.MeanAlignmentLongitude, SolarSystem.Singleton.TotalAlignmentIndex, 
                        SolarSystem.Singleton.TotalPerihelionIndex); //// q
             */
            
            this.List.AppendFormat(CultureInfo.InvariantCulture, "\t {0,7:F4} ", SolarSystem.Singleton.TotalPerihelionIndex);
            /*
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,5:F1} \t{1,5:F1}", SolarSystem.Singleton.TotalAlignmentIndex, SolarSystem.Singleton.TotalQuadratureIndex);

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}",
                    Lv,
                    Le,
                    Lj);
            */
            /* Angle index for testing solar extremes .... (quadratures...)
            var djs = Angles.Mod360(Lj - Ls ); //// -30
            var mjs = Math.Round(djs / 30);

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}\t{3,5:F0}\t{4,5:F0}",
                    Lj,
                    Ls,
                    djs,
                    mjs * 30,
                    mjs);
            */

            this.List.AppendFormat("\n ");
            this.lastJulianDateV = julianDate;
        }

        /// <summary>
        /// Outputs the date diffs dwarfs.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        [UsedImplicitly]
        private void OutputDateDiffsDwarfs(double julianDate, double timeUnit, string info, double diff)
        { 
            var diff1 = julianDate - this.lastJulianDateV;

            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            this.List.AppendFormat("{0,8:F2} \t{1,8:F2} \t", Math.Round(diff1 / timeUnit, 3), Julian.Year(julianDate));
            this.List.Append(Julian.CalendarDate(julianDate, false));

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tUr {0,5:F1}\tNe {1,5:F1}\tEr {2,5:F1}\tHa {3,5:F1}\tMa {4,5:F1}\tOr {5,5:F1}\tQu {6,5:F1}\tSa {7,5:F1}\tSe {8,5:F1}",
                    Lu, 
                    Ln,
                    SolarSystem.Singleton.Eris.Longitude, 
                    SolarSystem.Singleton.Haumea.Longitude, 
                    SolarSystem.Singleton.Makemake.Longitude,
                    SolarSystem.Singleton.Orcus.Longitude, 
                    SolarSystem.Singleton.Quaoar.Longitude, 
                    SolarSystem.Singleton.Salacia.Longitude, 
                    SolarSystem.Singleton.Sedna.Longitude);

            this.List.AppendFormat("\n ");
            this.lastJulianDateV = julianDate;
        }

        /* this.List.AppendFormat(
        CultureInfo.InvariantCulture,
        "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}\t{3,5:F1}",
        Lv,
        Le,
        Lj,
        Ls);

        this.List.AppendFormat(
        CultureInfo.InvariantCulture,
        "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}\t{3,5:F1}\t{4,5:F1}\t{5,5:F1}",
        Lj,
        Ls,
        Angles.Mod360(Lj - Ls),
        Angles.Mod360(Lj - Le),
        Angles.Mod360(Lj - Lv),
        Angles.Mod360(Lj - Lu));
        */
        /*
          this.List.AppendFormat(
                  CultureInfo.InvariantCulture,
                  "\t{0,5:F1}",   mjs);
        */

        /// <summary>
        /// Outputs the date diffs outer.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        private void OutputDateDiffsOuter(double julianDate, double timeUnit, string info, double diff)
        {
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var Lo = SolarSystem.Singleton.Outercentre.Longitude;
            var Ro = SolarSystem.Singleton.Outercentre.RT / 10000000;

            if (Ro > 75)
            {
                var diff1 = julianDate - this.lastJulianDateV;

                this.List.AppendFormat("{0,8:F2}  {1,8:F2}", Math.Round(diff1 / timeUnit, 3), Julian.Year(julianDate));
                //// this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
                this.List.Append(" " + Julian.CalendarDate(julianDate, false));

                //// this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,5:F1}", Angles.Mod360Sym(Lj - Lo));

                this.List.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "\t{0,10:F1}\t{1,5:F1}\t-\t{2,5:F1}\t{3,5:F1}\t{4,5:F1}",
                        Ro,
                        Lo,
                        Ls,
                        Lu,
                        Ln);
                this.List.AppendFormat("\n ");
                this.lastJulianDateV = julianDate;
            }
        }

        /// <summary>
        /// Outputs the date diffs solar.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        [UsedImplicitly]
        private void OutputDateDiffsSolar(double julianDate, double timeUnit, string info, double diff)
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lsp = SolarSystem.Singleton.Saturn.LP;

            //// var Qjs = Math.Abs(Angles.Sinus(Lj - Ls));
            var Qjs = -Angles.Sinus(Lj - Ls);
            var Qjp = Angles.Cosin((Lj - Ljp - 180) / 2);
            var Qsp = Angles.Cosin((Ls - Lsp - 180) / 2);
            //// var Qjp = Angles.Cosin((Lj - Ljp - 180));
            //// var Qsp = Angles.Cosin((Ls - Lsp - 180));

            var value = 160 * Qjs + 40 * Qjp; //// +20*Qsp;
            if (value > 180)
            {
                this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
                //// this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,5:F1}", Angles.Mod360Sym(Lj - Lo));

                this.List.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}-\t{3,7:F2}\t{4,7:F2}-\t{5,7:F2}",
                        Lj,
                        Ls,
                        Ljp,
                        Qjs,
                        Qjp,
                        value);
                this.List.AppendFormat("\n ");
            }

            this.lastJulianDateV = julianDate;
        }

        /// <summary>
        /// Outputs the date diffs jsve.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        [UsedImplicitly]
        private void OutputDateDiffsJSVE(double julianDate, double timeUnit, string info, double diff)
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lv = SolarSystem.Singleton.Venus.Longitude;
            var Le = SolarSystem.Singleton.Earth.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            var Vj = SolarSystem.Singleton.Jupiter.Body.Mass / Math.Pow(SolarSystem.Singleton.Jupiter.Point.RT, 2) / 1e3;
            var Vs = SolarSystem.Singleton.Saturn.Body.Mass / Math.Pow(SolarSystem.Singleton.Saturn.Point.RT, 2) / 1e3;
            var Vv = SolarSystem.Singleton.Venus.Body.Mass / Math.Pow(SolarSystem.Singleton.Venus.Point.RT, 2) / 1e3;
            var Ve = SolarSystem.Singleton.Earth.Body.Mass / Math.Pow(SolarSystem.Singleton.Earth.Point.RT, 2) / 1e3;
            var Qjs = Math.Abs(Angles.Sinus(Lj - Ls));
            var Qjv = Math.Abs(Angles.Sinus(Lj - Lv));
            var Qsv = Math.Abs(Angles.Sinus(Ls - Lv));
            var Qje = Math.Abs(Angles.Sinus(Lj - Le));
            var Qse = Math.Abs(Angles.Sinus(Ls - Le));
            var Qve = Math.Abs(Angles.Sinus(Lv - Le));

            var Pjs = 50* Vj * Vs * Qjs;
            var Pjv = Vj * Vv * Qjv;
            var Psv = Vs * Vv * Qsv;
            var Pje = Vj * Ve * Qje;
            var Pse = Vs * Ve * Qse;
            var Pve = Vv * Ve * Qve;
            var value = Pjs + Pjv + Psv + Pje + Pse + Pve;
            if (value > 30)
            {
                this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
                //// this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,5:F1}", Angles.Mod360Sym(Lj - Lo));

                this.List.AppendFormat(
                        CultureInfo.InvariantCulture,
                        "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}-\t{3,7:F2}\t{4,7:F2}\t{5,7:F2}-\t{6,7:F2}\t{7,7:F2}\t{8,7:F2}-\t{9,7:F2}",
                        Lj,
                        Ls,
                        Lv,
                        Pjs,
                        Pjv,
                        Psv,
                        Pje,
                        Pse,
                        Pve,
                        value);
                this.List.AppendFormat("\n ");
            }

            this.lastJulianDateV = julianDate;
        }

        /// <summary>
        /// Outputs the date diffs vuckevic.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        [UsedImplicitly]
        private void OutputDateDiffsVuckevic(double julianDate, double timeUnit, string info, double diff)
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            
            //// var v1 = (t - 1937.4) / 19.859;
            var v1 = Angles.Mod360(Lj - Ls + 90);

            //// var v2 = (t - 1934.1) / 23.724;
            //// var p2 = Angles.Mod360Sym(Lj - Ljp -180);
            var v2 = Angles.Mod180Sym((Lj - Ljp-180)/2);
            var t2 = Julian.Year(julianDate);
            var cs2 = Angles.Cosin(360*(t2-1934.1)/23.724);
            var c1 = Angles.Cosin(v1);
            var c2 = cs2; //// Angles.Cosin(v2)*s2;
                          //// var c2 = Math.Abs(2 * Angles.Sinus(v2)) - 1;
            //// if (Math.Abs(c1 + c2)>0.5)
            {
                //// this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
                //// this.List.AppendFormat("({0,7:F2} , {1,7:F2}) =>  {2,7:F2} ... {3,7:F2} ", c1, c2, c1 + c2, Math.Abs(c1 + c2));
                this.List.AppendFormat("{0,7:F2}\t{1,7:F2}\t{2,7:F2}\t{3,7:F2}", c1, c2, c1 + c2, Math.Abs(c1 + c2));
                this.List.AppendFormat("\n ");

                this.lastJulianDateV = julianDate;
            }
        }

        /// <summary>
        /// Outputs the date diffs vuckevi original.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        [UsedImplicitly]
        private void OutputDateDiffsVuckeviOrig(double julianDate, double timeUnit, string info, double diff)
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            var d1 = Angles.Mod180Sym((Lj - Ljp) / 2);
            var d2 = Angles.Mod360(Lj - Ls);
            var d3 = Angles.Mod360(Lu - Ln);

            //// if (Angles.EqualDeg(d1, 180, 35) && Angles.EqualDeg(d2, 90, 35))
            //// if (Angles.EqualDeg(d1, 180, 35)) //// && Angles.EqualDeg(d2, 90, 35))
            {
                ////   var diff1 = julianDate - this.lastJulianDateV;
                ////this.List.AppendFormat("{0,8:F2}  ", Math.Round(diff1 / timeUnit, 3));

                this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));

                /*
                this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}\t{3,5:F1}",
                    Lj,
                    Ls,
                    Lu,
                    Ln);
                    */
                ///// 2000 * (Math.Abs(Angles.Sinus(d1)) - 0.5),
                var v1 = 1000 * Math.Abs(Angles.Cosin(d1)) * Angles.Cosin(d3);
                var v2 = 2000 * Math.Abs(Angles.Sinus(d2));
                var v3 = 1000 * Angles.Cosin(d3);
                this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,6:F0}\t{1,6:F0}\t{2,6:F0}\t{3,6:F0}",
                                v1,
                                v2,
                                v3,
                                2*(v2+v1-v3));
                this.List.AppendFormat("\n ");

                this.lastJulianDateV = julianDate;
            }
        }

        /// <summary>
        /// Outputs the date diffs.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        [UsedImplicitly]
        private void OutputDateDiffsWolf(double julianDate, double timeUnit, string info, double diff)
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            //// var Lp = SolarSystem.Singleton.Pluto.Longitude;
            var Lp = BodyPluto.EclipticLongitude(julianDate);
            var Lx = SolarSystem.Singleton.PlanetX.Longitude;

            var d1 = Angles.Mod360Sym(Lj - Ljp)/2;
            var d2 = Angles.Mod360Sym(Lj - Ls);
            var d3 = 0; //// Angles.Mod360Sym(Ls - Lu);
            var d4 = Angles.Mod360Sym(Lu - Ln);
            //// var d3 = Angles.Mod360Sym(Lu - Ln);
            //// var p1 = Math.Abs(Angles.Cosin((+45 + d1) / 2));
            //// var p2 = Math.Abs(Angles.Cosin(+60 + d2));
            var p1 = Math.Abs(Angles.Sinus(d1));
            var p2 = Math.Abs(Angles.Sinus(d2));
            var p3 = Math.Abs(Angles.Sinus(d3));
            var p4 = Math.Abs(Angles.Sinus(d4));
            //// var force12 = 1 * p1 + 1 * p2;
            //// var force13 = 1 * p1 + 1 * p3;
            var force = 2 * p1 + 1 * p2  + 1 * p3 + 1 * p4;
            //// var power12 = Math.Pow(1+force12, 3);
            //// var power13 = Math.Pow(1+force13, 3);
            var power = Math.Pow(2 + force, 3);

            /*if (power < 10)
            {
                return;
            }*/

            //// var diff1 =  julianDate - this.lastJulianDateV;
            //// this.List.AppendFormat("{0,8:F2}  ", Math.Round(diff1 / timeUnit, 3));
            this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
            //// this.List.Append(" " + Julian.CalendarDate(julianDate, false));

            this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1}",
                                Ljp);
            this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1} {1,5:F1}",
                                Lj,
                                Ls);
            
            this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1} {1,5:F1}",
                                Lu,
                                Ln);

            /*
            this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1}\t{1,5:F1}",
                                Lp,
                                Lx);
            */
            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tD {0,5:F0} {1,5:F0} {2,5:F0}",
                    Angles.Mod360(d1),
                    Angles.Mod360(d2),
                    Angles.Mod360(d3));

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tP {0,5:F1} {1,5:F1} {2,5:F1} {3,5:F1}",
                    p1,
                    p2,
                    p3,
                    p4);

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tF {0,6:F1} {1,6:F1}",
                    force,
                    power);

            this.List.AppendFormat("\n ");

            this.lastJulianDateV = julianDate;
        }

        /// <summary>
        /// Outputs the date diffs.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        [UsedImplicitly]
        private void OutputDateDiffsTest(double julianDate, double timeUnit, string info, double diff) {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            //// var LPj = SolarSystem.Singleton.Jupiter.LP;

            var M = (Ls + Lj);
            var B = (Lj - Ls + Lu - Ln);
            //// var V1 = Math.Abs(Angles.Mod360Sym((M + B) / 4));
            var M1 = Angles.Mod360Sym(M);
            var B1 = Angles.Mod360(B / 2);
            /*
            if (Math.Abs(Angles.Mod360(B1 - this.lastB1)) > 150)
            {
                B1 = Angles.Mod360(B1 + 180);
            }*/

            var A1 = Angles.Mod360((M1 + B1)); ////  Angles.Mod360((M1 + B1));    

            //// if (Math.Abs(Angles.Mod360(A1 - this.lastA1)) > 150)
            //// {  A1 = Angles.Mod360(A1 + 180);   } 

            //// var V1 = Angles.Mod360(((M1 - B1)));
            var V1 = 200 * Angles.Cosin(M1 - B1);
            //// var V2 = 200 * Angles.Cosin((M1 + B1));
            var V2 = 200 * Angles.Cosin(A1);
            //// var V2 = A1;

            //// this.List.AppendFormat("{0,10:F5} \t{1,10:F5} \t{2,10:F5} ", M1,B1,V1);
            this.List.AppendFormat("{0,10:F5} \t{1,10:F5} ", V1, V2);

            // this.lastB1 = B1;

            ////this.List.AppendFormat("{0,10:F5} \t{1,10:F5}", M1, B1);
            //// this.List.AppendFormat("{0,10:F5} \t{1,10:F5}", V1, V2);
            //// var A = (Lj - LPj) - (Ls - Lu + Ln + 90) * 3;
            //// var V = Angles.Mod360Sym(A);
            //// var dJp = Angles.Mod360((Lj - LPj)/2);
            //// var dJa = Angles.Mod360((Lj - LPj - 180)/2);

            //// this.List.AppendFormat("{0,8:F2}  {1,8:F2}", Math.Round(diff / timeUnit, 3), Julian.Year(julianDate));
            //// this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
            //// this.List.Append(" " + Julian.CalendarDate(julianDate, false));

            //// this.List.AppendFormat("\t{0,10:F5}\t{1,8:F3}\t{2,8:F3}", -V, -Angles.Sinus(dJp)*30, -Math.Abs(Angles.Cosin(dJp)) * 40);

            //// var F = 180 - Math.Abs(Angles.Mod360Sym(2 * (Lj - LPj) - 3 * Ls + 4 * Lu - 4 * Ln));
            //// this.List.AppendFormat("\t{0,6:F1}", -F)); //// 2J - 3S + 4U -4N 

            //// this.List.AppendFormat("\t{0,6:F1}", -3*V + F);

            //// this.List.AppendFormat("\t Lj-Lp:{0,6:F1} S:{1,6:F1} U:{2,6:F1} N:{3,6:F1} S-U+N{4,6:F1}",
            ////                Angles.Mod360(Lj - LPj),  Ls,  Lu, Ln, Angles.Mod360(Ls - Lu + Ln));

            //// this.List.AppendFormat("\t {0, -30} ", info);
            this.List.AppendFormat("\n ");

            this.lastJulianDateV = julianDate;
        } 

        /// <summary>
        /// Outputs the date diffs optim bruckner.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <param name="timeUnit">The time unit.</param>
        /// <param name="info">The information.</param>
        /// <param name="diff">The difference.</param>
        [UsedImplicitly]
        private void OutputDateDiffsOptimBruckner(double julianDate, double timeUnit, string info, double diff)
        {
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            var LPj = SolarSystem.Singleton.Jupiter.LP;
            //// var V = ((Lj - LPj) / 3) - (Ls - Lu + Ln + 90);
            var A = (Lj - LPj) - (Ls - Lu + Ln + 90) * 3;
            var V = Angles.Mod360Sym(A);
            bool isminmax = (Math.Sign(V - this.lastV) == Math.Sign(this.lastV - this.lastV2)
                        && Math.Sign(this.lastV2 - this.lastV3) == Math.Sign(this.lastV3 - this.lastV4)
                        && Math.Sign(V - this.lastV) != Math.Sign(this.lastV2 - this.lastV3));

            bool iszerominus = V <= 0.0 && this.lastV > 0 && this.lastV > V && this.lastV2 > this.lastV && this.lastV3 > this.lastV2;
            bool iszeroplus = V >= 0.0 && this.lastV < 0 && this.lastV < V && this.lastV2 < this.lastV && this.lastV3 < this.lastV2;

            if (isminmax || iszerominus || iszeroplus)
            {
                diff = julianDate - this.lastJulianDateV;
                //// var x = Math.Round(diff / timeUnit * 365.25);
                //// if (x>250 && x<270) {

                this.List.AppendFormat("{0,8:F2}  {1,8:F2}", Math.Round(diff / timeUnit, 3), Julian.Year(julianDate));
                //// this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
                this.List.Append(" " + Julian.CalendarDate(julianDate, false));

                this.List.AppendFormat("\t{0,10:F5}", -V);

                //// this.List.AppendFormat("\t {0, -30} ", info);
                this.List.AppendFormat("\n ");

                this.lastJulianDateV = julianDate;
            }

            this.lastV4 = this.lastV3;
            this.lastV3 = this.lastV2;
            this.lastV2 = this.lastV;
            this.lastV = V;
        }

        //// Resonance Value  
        /*
        var Lv = SolarSystem.Singleton.Venus.Longitude;
        var Le = SolarSystem.Singleton.Earth.Longitude;
        var Lj = SolarSystem.Singleton.Jupiter.Longitude;
        this.List.AppendFormat("\tR={0,8:F3}",  Angles.Mod180Sym(3*Lv - 5*Le + 2*Lj) );
        */

        //// this.List.AppendFormat("\t E:{0,6:F1} J:{1,6:F1} Moon:{2,6:F1}", SolarSystem.Earth.Longitude, SolarSystem.Jupiter.Longitude, EarthSystem.Moon.EclipticLongitude);
        //// var declination = Angles.NormalSymmetricAngle360(EarthSystem.Moon.Declination);
        //// this.List.AppendFormat("\t E:{0,6:F1} Moon:{1,6:F1} {2,6:F1} Declin:{3,6:F1}",
        //// SolarSystem.Earth.Longitude, Angles.Mod360(EarthSystem.Moon.EclipticLongitude - EarthSystem.Moon.LP), EarthSystem.Moon.EclipticLongitude - SolarSystem.Earth.Longitude, declination);
        //// this.List.AppendFormat("{0,8:F0}\t ", AstroMath.ModN(julianDate+9,29.53));
        //// this.List.AppendFormat("({0,8:F2}) {1,8:F2} \t", Math.Round(diff / timeUnit, 3), Julian.Year(julianDate));
        //// this.List.AppendFormat("{0,8:F2}\t ", Math.Round(AstroMath.ModN((julianDate / timeUnit), 19.86), 3));
        //// this.List.AppendFormat("\t E:{0,6:F1} J:{1,6:F1} S:{2,6:F1}", SolarSystem.Earth.Longitude, SolarSystem.Jupiter.Longitude, SolarSystem.Saturn.Longitude);
        //// this.List.AppendFormat("\t {0,8:F0} {1,8:F2} ", julianDate, (julianDate - 584285) / 365.2422);
        ////}

        /// <summary>
        /// Outputs the distances.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <returns> Returns value. </returns>
        private double OutputDistances(double julianDate)
        {
            double dist = 0;
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));
            ////  this.List.AppendFormat(" {0,1}:{1,9:F6}", SolarSystem.Sun.Abbrev, SolarSystem.Sun.RT/DefOrbit.AstroMath.AstroUnit);
            for (var k = 0; k < (int)AstPlanet.Count; k++)
            {
                var orbitB = SolarSystem.Singleton.Orbit[k];
                dist = orbitB.Point.RT / AstroMath.AstroUnit;
                this.List.AppendFormat(
                    dist < 0.01 ? " {0,1}:{1,8:F6}" : dist < 10.0 ? " {0,1}:{1,6:F3}" : " {0,1}:{1,6:F2}",
                    orbitB.Body.Abbreviation,
                    dist);
            }

            return dist;
        }

        /// <summary>
        /// Outputs the longitudes sun.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <returns> Returns value. </returns>
        private double OutputLongitudesSun(double julianDate)
        {
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));
            this.List.AppendFormat(CultureInfo.CurrentCulture, " Longitude:{0,6:F2}", SolarSystem.Singleton.Sun.Longitude);
            var dist = SolarSystem.Singleton.Sun.Point.RT / SolarSystem.Singleton.Sun.Body.Radius;
            this.List.AppendFormat(CultureInfo.CurrentCulture, " R:{0,8:F6}", dist);
            this.List.AppendFormat(
                                    " v:{0,6:F1} W:{1,6:F1} ",
                                    SolarSystem.Singleton.Sun.Point.ActualSpeed / 10000,
                                    SolarSystem.Singleton.Sun.Point.ActualAcceleration);
            /*
            this.List.AppendFormat(
                                    " Tactual:{0,6:F1} Tmean:{1,6:F1} {2} ",
                                    SolarSystem.Singleton.BarycentreBehavior.ActualPeriod,
                                    SolarSystem.Singleton.BarycentreBehavior.MeanAngularPeriod,
                                    SolarSystem.Singleton.BarycentreBehavior.Retrograde ? "Retrograde" : string.Empty);
            */
            ////  this.List.AppendFormat(" {0,8:F6}", dist*Math.Cos(SolarSystem.SunX.projPhi) );
            ////  this.List.AppendFormat(" {0,1}:{1,6:F2}", SolarSystem.Sun.Abbrev, SolarSystem.Sun.Longitude);
            ////  this.List.AppendFormat(" {0,1}:{1,6:F2}", SolarSystem.Jupiter.Abbrev, SolarSystem.Jupiter.Longitude);
            return dist;
        }

        /// <summary>
        /// Outputs the longitudes inner.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        private void OutputLongitudesInner(double julianDate)
        {
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));
            for (var k = 0; k < (int)AstPlanet.Count; k++)
            {
                if (k < (int)AstPlanet.Mercury || k > (int)AstPlanet.Mars)
                {
                    continue;
                }

                var orbitB = SolarSystem.Singleton.Orbit[k];
                this.List.AppendFormat(" {0,1}:{1,6:F2}", orbitB.Body.Abbreviation, orbitB.Longitude);
            }

            this.List.Append(" " + Julian.CalendarDate(julianDate, false));
        }

        /// <summary>
        /// Outputs the longitudes outer.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        private void OutputLongitudesOuter(double julianDate)
        {
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));
            for (var k = 0; k < (int)AstPlanet.Count - 1; k++)
            {
                if (k < (int)AstPlanet.Jupiter || k > (int)AstPlanet.X)
                {
                    continue;
                }

                var orbitB = SolarSystem.Singleton.Orbit[k];
                this.List.AppendFormat(" {0,1}:{1,6:F2} ({2,6:F2})", orbitB.Body.Abbreviation, orbitB.Longitude, orbitB.LP);
            }

            this.List.Append(" " + Julian.CalendarDate(julianDate, false));
        }

        /// <summary>
        /// Outputs the sun influences.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        private void OutputSunInfluences(double julianDate)
        {
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));
            this.List.AppendFormat(
                            CultureInfo.InvariantCulture,
                            " I:{0,6:F2} B:{1,6:F2} J:{2,6:F2} v:{3,10:F3} ",
                            SolarSystem.Singleton.Sun.InfluenceLgh,
                            Angles.Mod360(SolarSystem.Singleton.Sun.Longitude + 180),
                            SolarSystem.Singleton.Jupiter.Longitude,
                            SolarSystem.Singleton.Sun.InfluenceValue); //// -3000
            this.List.AppendFormat(
                            " Phi:{0,6:F2} V:({1,10:F3},{2,10:F3}) ",
                            SolarSystem.Singleton.Sun.InfluencePhi,
                            SolarSystem.Singleton.Sun.InfluenceRadial,
                            SolarSystem.Singleton.Sun.InfluenceTangential);
        }

        /// <summary>
        /// Outputs the tidal orientation.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        private bool OutputTidalOrientation(double julianDate)
        {
            /*var M = SolarSystem.Singleton.Mercury;
            var V = SolarSystem.Singleton.Venus;
            var E = SolarSystem.Singleton.Earth;
            var R = SolarSystem.Singleton.Mars;
            var J = SolarSystem.Singleton.Jupiter;
            var S = SolarSystem.Singleton.Saturn;
            var U = SolarSystem.Singleton.Uranus;
            var N = SolarSystem.Singleton.Neptune;
            var X = SolarSystem.Singleton.X;*/

            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Le = SolarSystem.Singleton.Earth.Longitude;
            var Lv = SolarSystem.Singleton.Venus.Longitude;

            this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
            this.List.Append(" " + Julian.CalendarDate(julianDate, false));

            this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}",
                                Lv,
                                Le,
                                Lj);

            this.List.AppendFormat(
                                    CultureInfo.InvariantCulture,
                                    "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}",
                                    SolarSystem.Singleton.Barycentre.Longitude,
                                    Angles.Mod360(SolarSystem.Singleton.Gravicentre.Longitude));

            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,5:F1}\t{0,8:F2}",
                SolarSystem.Singleton.TidalExtreme.Longitude, 
                SolarSystem.Singleton.TidalExtreme.RT);

            return true;
        }

        /// <summary>
        /// Outputs the tidal excell.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <returns>Returns value.</returns>
        private bool OutputTidalExcell(double julianDate)
        {
            var M = SolarSystem.Singleton.Mercury;
            var V = SolarSystem.Singleton.Venus;
            var E = SolarSystem.Singleton.Earth;
            var J = SolarSystem.Singleton.Jupiter;

            this.List.AppendFormat("{0,10:F4} ", Julian.Year(julianDate));
            this.List.Append("\t" + Julian.CalendarDate(julianDate, false));

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tL \t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t",
                    M.Longitude,
                    V.Longitude,
                    E.Longitude,
                    J.Longitude);

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tR \t{0,15:F1}\t{1,15:F1}\t{2,15:F1}\t{3,15:F1}\t",
                    M.Point.RT,
                    V.Point.RT,
                    E.Point.RT,
                    J.Point.RT);

            var gM = M.Body.Mass / M.Point.RT / M.Point.RT / M.Point.RT * 1e12;
            var gV = V.Body.Mass / V.Point.RT / V.Point.RT / V.Point.RT * 1e12;
            var gE = E.Body.Mass / E.Point.RT / E.Point.RT / E.Point.RT * 1e12;
            var gJ = J.Body.Mass / J.Point.RT / J.Point.RT / J.Point.RT * 1e12;

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tM/R3 \t{0,12:F3}\t{1,12:F3}\t{2,12:F3}\t{3,12:F3}\t",
                    gM,
                    gV,
                    gE,
                    gJ);

            this.List.AppendFormat(
                                    CultureInfo.InvariantCulture,
                                    "\tBary\t{0,5:F1}\t{1,5:F1}",
                                    Angles.Mod360(SolarSystem.Singleton.Barycentre.Longitude),
                                    SolarSystem.Singleton.Barycentre.RT);

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tGravi\t{0,5:F1}\t{1,5:F1}",
                    Angles.Mod360(SolarSystem.Singleton.Gravicentre.Longitude),
                    SolarSystem.Singleton.Gravicentre.RT);

            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\tIdx \t{0,6:F2} ", 
                SolarSystem.Singleton.TotalAlignmentIndex);

            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t\t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t",
                    M.AlignmentIndex,
                    V.AlignmentIndex,
                    E.AlignmentIndex,
                    J.AlignmentIndex);

            //// var angle1 = Angles.CorrectAngle(V.Longitude - J.Longitude); revert
            var angle1 = Angles.CorrectAngle(J.Longitude - V.Longitude);
            var y1 = gV + gJ * Angles.Cosin(2 * angle1);
            var x1 = gJ * Angles.Sinus(2 * angle1);
            var g1 = Math.Sqrt(x1 * x1 + y1 * y1);
            var delta1 = Angles.ArcSinus(x1 / g1) / 2;
            var dip1 = V.Longitude + delta1;
            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t(1) \t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t{4,6:F2}\t{5,6:F2}\t",
                    angle1,
                    y1,
                    x1,
                    g1,
                    delta1,
                    dip1);

            //// var angle2 = Angles.CorrectAngle(dip1 - M.Longitude); revert
            var angle2 = Angles.CorrectAngle(M.Longitude - dip1);
            var y2 = g1 + gM * Angles.Cosin(2 * angle2);
            var x2 = gM * Angles.Sinus(2 * angle2);
            var g2 = Math.Sqrt(x2 * x2 + y2 * y2);
            var delta2 = Angles.ArcSinus(x2 / g2) / 2;
            var dip2 = dip1 + delta2;

            this.List.AppendFormat(
                   CultureInfo.InvariantCulture,
                   "\t(2) \t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t{4,6:F2}\t{5,6:F2}\t",
                   angle2,
                   y2,
                   x2,
                   g2,
                   delta2,
                   dip2);

            //// var angle3 = Angles.CorrectAngle(dip2 - E.Longitude); revert
            var angle3 = Angles.CorrectAngle(E.Longitude - dip2);
            var y3 = g2 + gE * Angles.Cosin(2 * angle3);
            var x3 = gE * Angles.Sinus(2 * angle3);
            var g3 = Math.Sqrt(x3 * x3 + y3 * y3);
            var delta3 = Angles.ArcSinus(x3 / g3) / 2;
            var dip3 = dip2 + delta3;

            this.List.AppendFormat(
                   CultureInfo.InvariantCulture,
                    "\t(3) \t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t{4,6:F2}\t{5,6:F2}\t",
                    angle3,
                    y3,
                    x3,
                    g3,
                    delta3,
                    dip3);

            this.List.AppendFormat("\n ");

            return true;
        }

        /// <summary>
        /// Outputs the oriented bary axis.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        /// <returns>Returns value.</returns>
        private bool OutputOrientedBaryAxis(double julianDate)
        {
            /*if (SolarSystem.Singleton.Sun.Point.RT > 0.5 * SolarSystem.Singleton.Sun.Body.Radius)
            ////if (SolarSystem.Singleton.Sun.Point.RT < 1.7 * SolarSystem.Singleton.Sun.Body.Radius)
            {
                    return false;
            }*/
            var M = SolarSystem.Singleton.Mercury;
            var V = SolarSystem.Singleton.Venus;
            var E = SolarSystem.Singleton.Earth;
            var R = SolarSystem.Singleton.Mars;
            var J = SolarSystem.Singleton.Jupiter;
            var S = SolarSystem.Singleton.Saturn;
            var U = SolarSystem.Singleton.Uranus;
            var N = SolarSystem.Singleton.Neptune;
            var X = SolarSystem.Singleton.PlanetX;

            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            //// var Lp = SolarSystem.Singleton.Pluto.Longitude;
            var Lp = BodyPluto.EclipticLongitude(julianDate);
            var Lx = SolarSystem.Singleton.PlanetX.Longitude;

            this.List.AppendFormat("{0,8:F2} ", Julian.Year(julianDate));
            this.List.Append(" " + Julian.CalendarDate(julianDate, false));

            var sundiff = Angles.Mod360Sym(SolarSystem.Singleton.Barycentre.Longitude - SolarSystem.Singleton.Gravicentre.Longitude);

            this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}\t{3,5:F1}",
                                Lj,
                                Ls,
                                Lu,
                                Ln);

            this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                "\t{0,5:F1}\t{1,5:F1}",
                                Lp,
                                Lx);

            this.List.AppendFormat(
                                    CultureInfo.InvariantCulture,
                                    "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}",
                                    SolarSystem.Singleton.Barycentre.Longitude,
                                    Angles.Mod360(SolarSystem.Singleton.Gravicentre.Longitude),
                                    sundiff);

            this.List.AppendFormat(
                                "\tB\t{0,8:F2}\t {1,5:F1}\t{2,6:F2}\t{3}",
                                SolarSystem.Singleton.Sun.Point.RT / SolarSystem.Singleton.Sun.Body.Radius,
                                SolarSystem.Singleton.BarycentreBehavior.ActualPeriod,
                                SolarSystem.Singleton.BarycentreBehavior.MeanAngularPeriod,
                                SolarSystem.Singleton.BarycentreBehavior.Retrograde ? "RG" : string.Empty);

            /*
            this.List.AppendFormat(
                                "\tS\t {0,10:F1}\t{1,10:F1}\t{2,12:F1}",
                                SolarSystem.Singleton.Sun.BarySunBehavior.TotalLgh,
                                SolarSystem.Singleton.Sun.GraviSunBehavior.TotalLgh,
                                SolarSystem.Singleton.Sun.BarySunBehavior.TotalJulianDay / 365.25);
                                        
            this.List.AppendFormat(
                                "\tG\t {0,5:F1}\t{1,6:F2}\t{2}",
                                SolarSystem.Singleton.GravicentreBehavior.ActualPeriod,
                                SolarSystem.Singleton.GravicentreBehavior.MeanAngularPeriod,
                                SolarSystem.Singleton.GravicentreBehavior.Retrograde ? "RG" : string.Empty);
            */

            this.List.AppendFormat(
                                "\tV\t{0,10:F1}\t{1,10:F1}",
                                SolarSystem.Singleton.Sun.Point.ActualSpeed / SolarSystem.Singleton.Sun.Body.Radius * 100 * 100,
                                SolarSystem.Singleton.Sun.Point.ActualAcceleration / SolarSystem.Singleton.Sun.Body.Radius * 100 * 100000);

            return true;
        }

            //// if (Math.Abs(sundiff) > 90)
            //// if (SolarSystem.Singleton.TidalExtreme.RT > 3.8)
            //// if (SolarSystem.Singleton.Sun.TidalExtreme.RT > 4000000)
            //// if (SolarSystem.Singleton.DipoleExtreme.RT > 3.05)
            //// if (Mun  > 1.5 *Fj && Mun < 1.6 * Fj)

            //// if (Math.Abs(percentUN - percentJ) < 3)
            
            /*
            if (Angles.EqualDeg(functionJJp + functionUN, 180, 2))
            {
                this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));

                //// this.List.AppendFormat("\t{0}", Julian.CalendarDate(julianDate, true));

                this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tdJJp {0,5:F1}\tdUN {1,5:F1}\tD {2,5:F1}",
                    functionJJp,
                    functionUN,
                    Angles.Mod360(functionJJp + functionUN)
                );
                */
            /*
            this.List.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tdJ {0,5:F1}\tdUN {1,5:F1}\tD {2,5:F1}\tFj {3,6:F1}\tMun {4,6:F1}\tW {5,6:F1} [{6,3:F0}% {7,3:F0}% ]",
                    Angles.Mod360(J.Longitude - J.LP),
                    Angles.Mod360(U.Longitude - N.Longitude),
                    Angles.Mod360(Lun - J.Longitude),
                    dFj,
                    Mun,
                    Mun + dFj,
                    percentJ,
                    percentUN
                    );
            */
            /*
            this.List.AppendFormat(
                                "\tR\t{0,8:F2}\t{1,8:F2}\t{2,8:F2}\t",
                                SolarSystem.Singleton.TidalExtreme.RT,
                                SolarSystem.Singleton.TidalExtreme.XH,
                                SolarSystem.Singleton.TidalExtreme.YH); */
            /*
            foreach (var orbit in SolarSystem.Singleton.Orbit)
            {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }

                //// Tides
                var e = orbit.Body.Mass *  orbit.Point.RT / orbit.Point.RT / orbit.Point.RT;
                var phi = Angles.Mod180Sym(orbit.Longitude - SolarSystem.Singleton.TidalExtreme.Longitude);
                var F = 10 * e * Angles.Cosin(phi);
                if (F > 0.01) //// 0.01
                {
                    this.List.AppendFormat(
                            CultureInfo.InvariantCulture,
                                    "\t{0,5}:{1,5:F0}:{2,5:F2}:{3,5:F2}", orbit.Body.Abbreviation, phi, F, 10*e);
                }
            }
            */
            /*
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\t{0,5:F1}\t{1,5:F1}\t{2,5:F1}\t{3,5:F1}",
                M.Longitude,
                V.Longitude,
                E.Longitude,
                R.Longitude);
            */
            /*
                     * 
                    this.List.AppendFormat(
                                "\tB\t{0,8:F2}\t{1,8:F2}\t{2,8:F2}\tG\t{3,8:F2}\t{4,8:F2}\t{5,8:F2}",
                                SolarSystem.Singleton.Sun.Point.RT / SolarSystem.Singleton.Sun.Body.Radius,
                                SolarSystem.Singleton.Sun.Point.XH / SolarSystem.Singleton.Sun.Body.Radius,
                                SolarSystem.Singleton.Sun.Point.YH / SolarSystem.Singleton.Sun.Body.Radius,
                                SolarSystem.Singleton.Gravicentre.RT,
                                SolarSystem.Singleton.Gravicentre.XH,
                                SolarSystem.Singleton.Gravicentre.YH);
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\tL\t{0,5:F1}",
                SolarSystem.Singleton.DipoleExtreme.Longitude);

            this.List.AppendFormat(
                "\tR\t{0,8:F2}",
                SolarSystem.Singleton.DipoleExtreme.RT);

            this.List.AppendFormat(
                "\tT\t {0,5:F1}\t{1,6:F2}\t{2}",
                SolarSystem.Singleton.DipoleExtremeBehavior.ActualPeriod,
                SolarSystem.Singleton.DipoleExtremeBehavior.MeanAngularPeriod,
                SolarSystem.Singleton.DipoleExtremeBehavior.Retrograde ? "RG" : string.Empty);
            */
            /*
            this.List.AppendFormat(
                CultureInfo.InvariantCulture,
                "\tL\t{0,5:F1}",
                SolarSystem.Singleton.TidalExtreme.Longitude);

            this.List.AppendFormat(
                "\tR\t{0,8:F2}",
                SolarSystem.Singleton.TidalExtreme.RT);

            this.List.AppendFormat(
                "\tT\t {0,5:F1}\t{1,6:F2}\t{2}",
                SolarSystem.Singleton.TidalExtremeBehavior.ActualPeriod,
                SolarSystem.Singleton.TidalExtremeBehavior.MeanAngularPeriod,
                SolarSystem.Singleton.TidalExtremeBehavior.Retrograde ? "RG" : string.Empty);
            */
            /*
            * /*
            var Mu = U.Body.Mass * U.Point.RT / 1e36;
            var Mn = N.Body.Mass * N.Point.RT / 1e36;
            var Mx = Mu * Angles.Cosin(U.Point.Longitude) + Mn * Angles.Cosin(N.Point.Longitude);
            var My = Mu * Angles.Sinus(U.Point.Longitude) + Mn * Angles.Sinus(N.Point.Longitude);
            var Mun = 720-Math.Sqrt(Mx * Mx + My * My) ;
            var Lun = Angles.ArcTan2(Mx, My);
            var Fj = J.Body.Mass / J.Point.RT / J.Point.RT;
            var dFj = 3460 - Fj; //// 3460            
            var percentJ = 100-100 * dFj / 610; //// var percentJ = 100 * dFj / (Mun + dFj);
            var percentUN = 100-100 * (Angles.Mod180(U.Longitude - N.Longitude) / 180);
            */
            /*
            var dJJp = Angles.Mod360(J.Longitude - J.LP);
            var functionJJp = dJJp;
            /// var functionUN = Angles.Mod360(U.Longitude - N.Longitude);
            //// var functionUN = Angles.Mod360(Math.Sqrt(U.Longitude* U.Longitude - N.Longitude* N.Longitude));
            var dUN = Angles.Mod360(360 * (julianDate / 365.25 / 171.4));
            var f = Angles.Cosin(2 * dUN) * Math.Abs(Angles.Cosin(2 * dUN));
            var functionUN = dUN + f * 120; 
            
            //// if (SolarSystem.Singleton.SunJS.Retrograde)
            return false;
        }*/        
            /*
        private void OutputOrientedBaryAxisOlder(double julianDate)
        {
            var b1 = SolarSystem.Singleton.SunJS.FirstBody;
            var b2 = SolarSystem.Singleton.SunJS.NextBody;
            this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));
            this.List.AppendFormat(
                                CultureInfo.InvariantCulture,
                                " {0,1}:{1,6:F2} {2,1}:{3,6:F2} Axis:{4,6:F2}",
                                b1.Abbrev,
                                b1.Longitude,
                                b2.Abbrev,
                                b2.Longitude,
                                Angles.Mod360(SolarSystem.Singleton.SunJS.Longitude + 180));
            this.List.AppendFormat(
                                " Lghtotal:{0,5:F0} JulianDaytotal:{1,6:F0}",
                                SolarSystem.Singleton.SunJS.TotalLgh,
                                SolarSystem.Singleton.SunJS.TotalJulianDay);
            this.List.AppendFormat(
                                " Tactual:{0,5:F1} Tmean:{1,6:F2}",
                                SolarSystem.Singleton.SunJS.ActualPeriod,
                                SolarSystem.Singleton.SunJS.MeanAngularPeriod);
        } */
    
        /// <summary>
        /// Outputs the conjunctions.
        /// </summary>
        /// <param name="julianDate">The julianDate.</param>
        private void OutputConjunctions(double julianDate) {
    /*
            double aLgh = 50;  //// 50
            var longJ = Angles.Mod360(SolarSystem.Singleton.Jupiter.Longitude);
            var longS = Angles.Mod360(SolarSystem.Singleton.Saturn.Longitude);
            var longU = Angles.Mod360(SolarSystem.Singleton.Uranus.Longitude);
            var longN = Angles.Mod360(SolarSystem.Singleton.Neptune.Longitude);
            //// double X = Angles.Mod360(SolarSystem.X.Longitude); 
            var result = string.Empty;
            //// bool includingX = false;
            result += IsConjunction(longJ, longS, longU, longN, aLgh) ? " JSUN," : string.Empty;
            result += IsOpposition(longJ, longS, longU, longN, aLgh) ? " J-SUN," : string.Empty;
            result += IsOpposition(longS, longJ, longU, longN, aLgh) ? " S-JUN," : string.Empty;
            result += IsOpposition(longU, longJ, longS, longN, aLgh) ? " U-JSN," : string.Empty;
            result += IsOpposition(longN, longJ, longS, longU, aLgh) ? " N-JSU," : string.Empty;
            result += IsDoubleOpposition(longJ, longS, longU, longN, aLgh) ? " SJ-UN," : string.Empty;
            result += IsDoubleOpposition(longJ, longU, longS, longN, aLgh) ? " UJ-SN," : string.Empty;
            result += IsDoubleOpposition(longJ, longN, longS, longU, aLgh) ? " NJ-SU," : string.Empty;

            if (string.IsNullOrEmpty(result)) {
                aLgh = 50;
                result += IsConjunction(longJ, longS, longU, aLgh) ? " JSU," : string.Empty;
                result += IsConjunction(longJ, longS, longN, aLgh) ? " JSN," : string.Empty;
                result += IsConjunction(longJ, longU, longN, aLgh) ? " JUN," : string.Empty;
                result += IsConjunction(longS, longU, longN, aLgh) ? " SUN," : string.Empty;
                result += IsOpposition(longJ, longS, longU, aLgh) ? " J-SU," : string.Empty;
                result += IsOpposition(longJ, longS, longN, aLgh) ? " J-SN," : string.Empty;
                result += IsOpposition(longJ, longU, longN, aLgh) ? " J-UN," : string.Empty;
                result += IsOpposition(longS, longJ, longU, aLgh) ? " S-JU," : string.Empty;
                result += IsOpposition(longS, longJ, longN, aLgh) ? " S-JN," : string.Empty;
                result += IsOpposition(longS, longU, longN, aLgh) ? " S-UN," : string.Empty;
                result += IsOpposition(longU, longJ, longN, aLgh) ? " U-JN," : string.Empty;
                result += IsOpposition(longU, longJ, longS, aLgh) ? " U-JS," : string.Empty;
                result += IsOpposition(longU, longS, longN, aLgh) ? " U-SN," : string.Empty;
                result += IsOpposition(longN, longJ, longS, aLgh) ? " N-JS," : string.Empty;
                result += IsOpposition(longN, longJ, longU, aLgh) ? " N-JU," : string.Empty;
                result += IsOpposition(longN, longS, longU, aLgh) ? " N-SU," : string.Empty;
            }

            if (!string.IsNullOrEmpty(result)) {
                //// if (lastResult != result) {  this.List.Append(Environment.NewLine);  }

                this.List.AppendFormat("{0,5:F0}", Julian.Year(julianDate));
                this.List.Append(result);
                //// lastResult = result;
            } */ 
        } 

        /// <summary>
        /// Appends the jsun axes.
        /// </summary>
        [UsedImplicitly]
        private void AppendJsunAxes() {
            var js = Angles.Mod360Sym(SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Saturn.Longitude);
            var nu = Angles.Mod360Sym(SolarSystem.Singleton.Neptune.Longitude - SolarSystem.Singleton.Uranus.Longitude);

            this.List.AppendFormat(" J-S:{0,4:F0} N-U:{1,4:F0}  ", js, nu);
        }
        #endregion
    }
}

#region other unused

/*
this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} \t{1,4:F0}", Lj, Ls);
this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} \t{1,4:F0}", Lu, Ln);
*/
/*
//// this.List.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(julianDate));
var alpha = SolarSystem.Singleton.TotalAlignmentIndex;
this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,6:F0}", 10 * alpha);
//// var alpha = Angles.Mod360(1 * Lj - 1 * Ls - 8 * Lu + 8 * Ln);
//// this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,6:F0}", 100 * Angles.Sinus(alpha));
*/
/*
var u = -(SolarSystem.Singleton.Uranus.Point.RT- SolarSystem.Singleton.Uranus.A) / 1.0E10;
var n = -(SolarSystem.Singleton.Neptune.Point.RT - SolarSystem.Singleton.Neptune.A) / 1.0E10;
var x = u+n;
this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,6:F2}\t{1,6:F2}\t{2,6:F2}", u,n,x);
*/
/*
this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0}", Ljm);

int alpha = (int)(Math.Round(Ljm / 30, 0));
this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0}", alpha);
*/

/*
var Lx = SolarSystem.Singleton.PlanetX.Longitude;
this.List.AppendFormat(CultureInfo.InvariantCulture, "\t{0,4:F0} {1,4:F0} {2,4:F0}", 
            Angles.Mod360(Lu), Angles.Mod360(Ln), Angles.Mod360(Lx));
*/

//// var Lj = SolarSystem.Singleton.Jupiter.Longitude;
//// var Ljm = Angles.Mod360(Lj);
//// if (Lj > 75 && Lj < 135) {
///
#endregion
