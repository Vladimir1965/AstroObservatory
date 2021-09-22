// <copyright file="Constellation.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Crossing { 
    using System;
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Enums;
    using AstroSharedOrbits.Moons;
    using AstroSharedOrbits.OrbitalData;
    using AstroSharedOrbits.Orbits;
    using AstroSharedOrbits.Systems;
    using JetBrains.Annotations;

    /// <summary>
    /// Astronomical Configuration.
    /// </summary>
    public class Constellation {
        #region Public static - VernalPoint
        /// <summary>
        /// Computes the equinox phase.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="equinoxType">Type of the equinox.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double ComputeEquinoxPhase(double date, out EquinoxType equinoxType) {
            var year = Julian.Year(date);
            double minPhase = 999;
            double minaPhase = 999;
            equinoxType = EquinoxType.None;

            var time0 = EquinoxesAndSolstices.EquinoxSolstice(year - 1, EquinoxType.WinterSolstice);
            var phase = date - time0;
            var aphase = Math.Abs(phase);
            if (aphase < minaPhase) {
                minPhase = phase;
                minaPhase = aphase;
                equinoxType = EquinoxType.WinterSolstice;
            }

            var time1 = EquinoxesAndSolstices.EquinoxSolstice(year, EquinoxType.VernalEquinox);
            phase = date - time1;
            aphase = Math.Abs(phase);
            if (aphase < minaPhase) {
                minPhase = phase;
                minaPhase = aphase;
                equinoxType = EquinoxType.VernalEquinox;
            }

            var time2 = EquinoxesAndSolstices.EquinoxSolstice(year, EquinoxType.SummerSolstice);
            phase = date - time2;
            aphase = Math.Abs(phase);
            if (aphase < minaPhase) {
                minPhase = phase;
                minaPhase = aphase;
                equinoxType = EquinoxType.SummerSolstice;
            }

            var time3 = EquinoxesAndSolstices.EquinoxSolstice(year, EquinoxType.AutumnalEquinox);
            phase = date - time3;
            aphase = Math.Abs(phase);
            if (aphase < minaPhase) {
                minPhase = phase;
                minaPhase = aphase;
                equinoxType = EquinoxType.AutumnalEquinox;
            }

            var time4 = EquinoxesAndSolstices.EquinoxSolstice(year, EquinoxType.WinterSolstice);
            phase = date - time4;
            aphase = Math.Abs(phase);
            if (!(aphase < minaPhase)) {
                return minPhase;
            }

            minPhase = phase;
            //// minaPhase = aphase;
            equinoxType = EquinoxType.WinterSolstice;

            return minPhase;
        }

        /// <summary>
        /// Computes the moon phase.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="phaseType">Type of the phase.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double ComputeMoonPhase(double date, MoonPhase phaseType) {
            var year = Julian.Year(date);
            var list0 = MoonPhases.ListOfMoonPhases(phaseType, (int)year - 1);
            var list = MoonPhases.ListOfMoonPhases(phaseType, (int)year);
            list.Insert(0, list0[list0.Count - 1]);
            double minPhase = 99;
            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var dtime in list) {
                var time1 = Julian.Date2Julian(dtime);
                var phase = date - time1;
                if (phase >= 0 && phase < minPhase) {
                    minPhase = phase;
                }

                if (minPhase < 30) {
                    break;
                }
            }

            return minPhase;
        }

        /// <summary>
        /// Is Vernal Point.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsVernalPoint(Orbit orbitA, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            return Angles.EqualDeg(orbitA.Longitude, 0, epsilon);
        }

        #endregion

        #region Public static methods
        /// <summary>
        /// Quadratures the function.
        /// </summary>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double QuadratureFunction() {
            var j = SolarSystem.Singleton.Jupiter.Longitude;
            ////double jw = SolarSystem.Jupiter.LW;
            var s = SolarSystem.Singleton.Saturn.Longitude;
            var u = SolarSystem.Singleton.Uranus.Longitude;
            var n = SolarSystem.Singleton.Neptune.Longitude;
            ////double nw = SolarSystem.Neptune.LW;
            ////double jjw = jw - j; 
            ////double nnw = nw - n;
            var js = s - j;
            var ju = u - j;
            var jn = n - j;
            var su = u - s;
            var sn = n - s;
            var un = n - u;
            const double cjjw = 0; ////  -1 * Angles.Cosin(jjw);
            const double cnnw = 0; ////  -1 * Angles.Cosin(nnw);
            const int power = 4;
            var cjs = Math.Pow(Angles.Sinus(js), power);
            var cju = Math.Pow(Angles.Sinus(ju), power);
            var cjn = Math.Pow(Angles.Sinus(jn), power);
            var csu = Math.Pow(Angles.Sinus(su), power);
            var csn = Math.Pow(Angles.Sinus(sn), power);
            var cun = Math.Pow(Angles.Sinus(un), power);

            var total = 3 * cjjw + cnnw + (1 * cjs) + (0 * cju) + (0 * cjn) + (0 * csu) + (0 * csn) + (1 * cun); //// >2.9
            return total;
        }

        /*  Planet - Quadratures - Test
         *       public double QuadratureFunctionLast() {
            double j = SolarSystem.Jupiter.Longitude;
            double jw = SolarSystem.Jupiter.LW;
            double s = SolarSystem.Saturn.Longitude;
            double u = SolarSystem.Uranus.Longitude;
            double n = SolarSystem.Neptune.Longitude;
            double nw = SolarSystem.Neptune.LW;
            //// double rj = 0;
            double jjw = jw - j;
            double nnw = nw - n;
            double js = s - j;
            double ju = u - j;
            double jn = n - j;
            double sn = n - s;
            double un = n - u;
            //// double aj = 0;
            double deltaJupiter = -1 * Angles.Cosin(jjw);
            double deltaNeptune = -1 * Angles.Cosin(nnw);
            double cjs = Math.Pow(Angles.Cosin(2 * js), 2);
            double cju = Math.Pow(Angles.Cosin(2 * ju), 2);
            double cjn = Math.Pow(Angles.Cosin(2 * jn), 2);
            double csn = Math.Pow(Angles.Cosin(2 * sn), 2);
            double cun = Math.Pow(Angles.Cosin(2 * un), 2);
            double total = deltaJupiter + deltaNeptune + 2 * cjs + 4 * cju + 10 * cjn + 0 * csn + 4 * cun;
            return total;
        } 

        cjs = cjs>0.5 ? cjs : 0;
        cju = cju>0.5 ? cju : 0;
        cjn = cjn>0.5 ? cjn : 0;
        csu = csu>0.5 ? csu : 0;
        csn = csn>0.5 ? csn : 0;
        cun = cun>0.5 ? cun : 0;

        //// double total = deltaJupiter + deltaNeptune + 1 * cjs + 1 * cju + 3 * cjn + 2 * csu + 3 * csn + 2 * cun;
        //// double total = deltaJupiter + deltaNeptune + 1 * cjs + 1 * cju + 3 * cjn + 1 * csu + 3 * csn + 3 * cun;
        //// double total = deltaJupiter + deltaNeptune + 1 * cjs + 2 * cju + 3 * cjn + 1 * csu + 3 * csn + 3 * cun;
        //// double total = deltaJupiter + deltaNeptune + 1 * cjs + 1 * cju + 1 * cjn + 0 * csu + 0 * csn + 10 * cun; // >2.9
        //// double total = deltaJupiter + deltaNeptune + 1 * cjs + 1 * cju + 1 * cjn + 0 * csu + 0 * csn + 10 * cun; // 11.5
        //// double total = deltaJupiter + deltaNeptune + 1 * cjs + 1 * cju + 1 * cjn + 0 * csu + 2 * csn + 10 * cun;
        */
        #endregion

        #region Conjunctions
        /// <summary>
        /// Is Conjunction.
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="length2">The length2.</param>
        /// <param name="length3">The length3.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsConjunction(double length0, double length1, double length2, double length3, double epsilon) {
            return IsConjunction(length0, length1, epsilon) && IsConjunction(length0, length2, epsilon)
                && IsConjunction(length0, length3, epsilon) && IsConjunction(length1, length2, epsilon)
                && IsConjunction(length1, length3, epsilon) && IsConjunction(length2, length3, epsilon);
        }

        /// <summary>
        /// Is Conjunction.
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsConjunction(double length0, double length1, double epsilon) {
            var rAB = Angles.Mod360(length0 - length1);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Opposition.
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static bool IsOpposition(double length0, double length1, double epsilon)
        {
            var rAB = Angles.Mod360(length0 - length1 + 180);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Determines whether the specified length0 is aspect.
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        ///   <c>true</c> if the specified length0 is aspect; otherwise, <c>false</c>.
        /// </returns>
        [UsedImplicitly]
        public static bool IsAspect(double length0, double length1, double epsilon)
        {
            var rAB = Angles.Mod180(length0 - length1);
            return Angles.EqualDeg(rAB, 0, epsilon)
                    || Angles.EqualDeg(rAB, 180, epsilon);
        }

        /// <summary>
        /// Determines whether [is trig aspect] [the specified length0].
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        ///   <c>true</c> if [is trig aspect] [the specified length0]; otherwise, <c>false</c>.
        /// </returns>
        [UsedImplicitly]
        public static bool IsTrigAspect(double length0, double length1, double epsilon)
        {
            var rAB = Angles.CmodAngle(length0 - length1, AstroMath.Angle120Deg);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Determines whether [is trig multiple] [the specified length0].
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        ///   <c>true</c> if [is trig multiple] [the specified length0]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTrigMultiple(double length0, double length1, double epsilon) {
            var rAB = Angles.Mod60Sym(length0 - length1);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Determines whether [is right angle] [the specified length0].
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns> Returns value. </returns>
        public static bool IsRightAngle(double length0, double length1, double epsilon) {
            var rAB = Math.Abs(Angles.Mod180Sym(length0 - length1));
            return Angles.EqualDeg(rAB, 90, epsilon);
        }

        /// <summary>
        /// Determines whether [is right angle multiple] [the specified length0].
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static bool IsRightAngleMultiple(double length0, double length1, double epsilon) {
            var rAB = Angles.Mod90(length0 - length1);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Determines whether [is diagonal angle multiple] [the specified length0].
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static bool IsDiagonalAngleMultiple(double length0, double length1, double epsilon) {
            var rAB = Angles.Mod90(length0 - length1 + 45);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Resonance.
        /// </summary>
        /// <param name="nA">The number A.</param>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="nB">The number B.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="nC">The number C.</param>
        /// <param name="orbitC">The orbit C.</param>
        /// <param name="phase">The phase.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsOrbitalResonance(int nA, Orbit orbitA, int nB, Orbit orbitB, int nC, Orbit orbitC, double phase, double angle, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            orbitC.SetJulianDate(date);
            //// double value = Angles.Mod360(orbitA.Longitude - orbitB.Longitude + orbitC.Longitude - orbitA.LP + 180); //// + 180  
            var value = Angles.ModAngle((nA * (orbitA.Longitude - orbitA.LP)) + (nB * (orbitB.Longitude - orbitA.LP)) + (nC * (orbitC.Longitude - orbitA.LP)) + phase, angle); //// +90 - 90 + 180 - orbitA.LP  
            //// double value = Angles.Mod360((orbitA.Longitude - orbitA.LP) - (orbitB.Longitude - orbitA.LP) + (orbitC.Longitude - orbitA.LP));
            return Angles.EqualDeg(value, 0, epsilon);
        }

        /// <summary>
        /// Determines whether the specified n A is resonance.
        /// </summary>
        /// <param name="nA">The number A.</param>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="nB">The number B.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="phase">The phase.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        ///   <c>True</c> if the specified n A is resonance; otherwise, <c>false</c>.
        /// </returns>
        [UsedImplicitly]
        public static bool IsResonance(int nA, Orbit orbitA, int nB, Orbit orbitB, double phase, double angle, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            //// double value = Angles.Mod360(orbitA.Longitude - orbitB.Longitude + orbitC.Longitude - orbitA.LP + 180); //// + 180  
            var value = Angles.ModAngle((nA * orbitA.Longitude) + (nB * orbitB.Longitude) + phase, angle); //// +90 - 90 + 180 - orbitA.LP  
            //// double value = Angles.Mod360((orbitA.Longitude - orbitA.LP) - (orbitB.Longitude - orbitA.LP) + (orbitC.Longitude - orbitA.LP));
            return Angles.EqualDeg(value, 0, epsilon);
        }

        /// <summary>
        /// Is orbital Resonance.
        /// </summary>
        /// <param name="nA">The number A.</param>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="nB">The number B.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="nC">The number C.</param>
        /// <param name="orbitC">The orbit C.</param>
        /// <param name="phase">The phase.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsResonance(int nA, Orbit orbitA, int nB, Orbit orbitB, int nC, Orbit orbitC, double phase, double angle, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            orbitC.SetJulianDate(date);
            //// double value = Angles.Mod360(orbitA.Longitude - orbitB.Longitude + orbitC.Longitude - orbitA.LP + 180); //// + 180  
            var value = Angles.ModAngle((nA * orbitA.Longitude) + (nB * orbitB.Longitude) + (nC * orbitC.Longitude) + phase, angle); //// +90 - 90 + 180 - orbitA.LP  
            //// double value = Angles.Mod360((orbitA.Longitude - orbitA.LP) - (orbitB.Longitude - orbitA.LP) + (orbitC.Longitude - orbitA.LP));
            return Angles.EqualDeg(value, 0, epsilon);
        }

        /// <summary>
        /// Determines whether the specified n A is resonance.
        /// </summary>
        /// <param name="nA">The number A.</param>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="nB">The number B.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="nC">The number C.</param>
        /// <param name="orbitC">The orbit C.</param>
        /// <param name="nD">The number D.</param>
        /// <param name="orbitD">The orbit D.</param>
        /// <param name="phase">The phase.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        ///   <c>True</c> if the specified n A is resonance; otherwise, <c>false</c>.
        /// </returns>
        [UsedImplicitly]
        public static bool IsResonance(int nA, Orbit orbitA, int nB, Orbit orbitB, int nC, Orbit orbitC, int nD, Orbit orbitD, double phase, double angle, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            orbitC.SetJulianDate(date);
            orbitD.SetJulianDate(date);
            //// double value = Angles.Mod360(orbitA.Longitude - orbitB.Longitude + orbitC.Longitude - orbitA.LP + 180); //// + 180  
            var value = Angles.ModAngle((nA * orbitA.Longitude) + (nB * orbitB.Longitude) + (nC * orbitC.Longitude) + (nD * orbitD.Longitude) + phase, angle); //// +90 - 90 + 180 - orbitA.LP  
            //// double value = Angles.Mod360((orbitA.Longitude - orbitA.LP) - (orbitB.Longitude - orbitA.LP) + (orbitC.Longitude - orbitA.LP));
            return Angles.EqualDeg(value, 0, epsilon);
        }
        #endregion

        #region Oppositions
        /// <summary>
        /// Is Double Opposition.
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="length2">The length2.</param>
        /// <param name="length3">The length3.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsDoubleOpposition(double length0, double length1, double length2, double length3, double epsilon) {
            return IsConjunction(length0, length1, epsilon) && IsConjunction(length2, length3, epsilon)
                   && IsOpposition(length0, length2, epsilon) && IsOpposition(length1, length2, epsilon)
                   && IsOpposition(length0, length3, epsilon) && IsOpposition(length1, length3, epsilon);
        }

        /// <summary>
        /// Is Opposition.
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="length2">The length2.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsOpposition(double length0, double length1, double length2, double epsilon) {
            return IsOpposition(length0, length1, epsilon) && IsOpposition(length0, length2, epsilon)
                && IsConjunction(length1, length2, epsilon);
        }

        /// <summary>
        /// Is Opposition.
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="length2">The length2.</param>
        /// <param name="length3">The length3.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsOpposition(double length0, double length1, double length2, double length3, double epsilon) {
            return IsOpposition(length0, length1, epsilon) && IsOpposition(length0, length2, epsilon)
                                                   && IsOpposition(length0, length3, epsilon)
                && IsConjunction(length1, length2, length3, epsilon);
        }
        #endregion

        #region Angles
        /// <summary>
        /// Angle comparison.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="length0">The length0.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsAngle(Orbit orbitA, double length0, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            var rA = Angles.Mod360(orbitA.Longitude - length0);
            return Angles.EqualDeg(rA, 0, epsilon);
        }

        #endregion

        #region Aspects
        /// <summary>
        /// Is Mean Aspect.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsMeanAspect(Orbit orbitA, Orbit orbitB, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            var rAB = Angles.Mod180(orbitA.LM - orbitB.LM);
            return Angles.EqualDeg180(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Nodal Aspect.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsNodalAspect(Orbit orbitA, Orbit orbitB, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            var rAB = Angles.Mod180(orbitA.LW - orbitB.Longitude);
            return Angles.EqualDeg180(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Quint Aspect.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsQuintAspect(Orbit orbitA, Orbit orbitB, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            var rAB = Angles.CmodAngle(orbitA.Longitude - orbitB.Longitude, AstroMath.Angle72Deg);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Ratio Aspect.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsRatioAspect(Orbit orbitA, Orbit orbitB, double date, double epsilon, int divisor) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            var rAB = Angles.CmodAngle(orbitA.Longitude - orbitB.Longitude, 360.0 / divisor);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Trig Aspect.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsTrigAspect(Orbit orbitA, Orbit orbitB, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            var rAB = Angles.CmodAngle(orbitA.Longitude - orbitB.Longitude, AstroMath.Angle120Deg);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }
        #endregion

        #region Lines and directions
        /// <summary>
        /// Is Direction.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="orbitC">The orbit C.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsDirection(Orbit orbitA, Orbit orbitB, Orbit orbitC, double date, double epsilon) {
            var r1 = new Relation();
            var r2 = new Relation();
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            orbitC.SetJulianDate(date);
            r1.SetBodies(orbitA, orbitB);
            r2.SetBodies(orbitA, orbitC);
            var rAB = Angles.Mod360(r1.DiffPhi - r2.DiffPhi);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Bodies make a Line.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="orbitC">The orbit C.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsLine(Orbit orbitA, Orbit orbitB, Orbit orbitC, double date, double epsilon) {
            var r1 = new Relation();
            var r2 = new Relation();
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            orbitC.SetJulianDate(date);
            r1.SetBodies(orbitA, orbitB);
            r2.SetBodies(orbitA, orbitC);
            var rAB = Angles.Mod180(r1.DiffPhi - r2.DiffPhi);
            return Angles.EqualDeg180(rAB, 0, epsilon);
        }
        #endregion

        #region Axes
        /// <summary>
        /// Is Axial Coincidence.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="orbitC">The orbit C.</param>
        /// <param name="orbitD">The orbit D.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsAxialCoincidence(Orbit orbitA, Orbit orbitB, Orbit orbitC, Orbit orbitD, double date, double epsilon) {
            /* orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            orbitC.SetJulianDate(date);
            orbitD.SetJulianDate(date); */
            var axab = Angles.AxisOf(orbitA.Longitude, orbitB.Longitude);
            var axcd = Angles.AxisOf(orbitC.Longitude, orbitD.Longitude);
            return Angles.EqualDeg180(axab, axcd, epsilon);
        }

        /// <summary>
        /// Determines whether [is axial right angle] [the specified orbit a].
        /// </summary>
        /// <param name="orbitA">The orbit a.</param>
        /// <param name="orbitB">The orbit b.</param>
        /// <param name="orbitC">The orbit c.</param>
        /// <param name="orbitD">The orbit d.</param>
        /// <param name="date">The date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        ///   <c>true</c> if [is axial right angle] [the specified orbit a]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAxialRightAngle(Orbit orbitA, Orbit orbitB, Orbit orbitC, Orbit orbitD, double date, double epsilon)
        {
            /* orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            orbitC.SetJulianDate(date);
            orbitD.SetJulianDate(date); */
            var axab = Angles.AxisOf(orbitA.Longitude, orbitB.Longitude);
            var axcd = Angles.AxisOf(orbitC.Longitude, orbitD.Longitude);
            return Constellation.IsRightAngle(axab, axcd, epsilon);
        }

        /// <summary>
        /// Is Axial Zero Point.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsAxialZeroPoint(Orbit orbitA, Orbit orbitB, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            //// FIa = Angles.AxisOf( orbitA.Longitude, orbitB.Longitude);
            var fia = RealAxis(orbitA, orbitB);
            return Angles.EqualDeg(fia, 0, epsilon); // EqualDeg180; axPQ+90
        }

        /// <summary>
        /// Is Axis Of.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="bP">The orbit P.</param>
        /// <param name="bQ">The orbit Q.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsAxisOf(Orbit orbitA, Orbit bP, Orbit bQ, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            bP.SetJulianDate(date);
            bQ.SetJulianDate(date);
            var axpq = Angles.AxisOf(bP.Longitude, bQ.Longitude);
            return Angles.EqualDeg180(orbitA.Longitude, axpq, epsilon); // EqualDeg180; axPQ+90
        }

        /// <summary>
        /// Is Balanced Axial Coincidence.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="orbitC">The orbit C.</param>
        /// <param name="orbitD">The orbit D.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsBalancedAxialCoincidence(Orbit orbitA, Orbit orbitB, Orbit orbitC, Orbit orbitD, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            orbitC.SetJulianDate(date);
            orbitD.SetJulianDate(date);
            var axab = Angles.BalancedAxisOf(orbitA.Longitude, orbitA.Body.Mass, orbitB.Longitude, orbitB.Body.Mass);
            var axcd = Angles.BalancedAxisOf(orbitC.Longitude, orbitC.Body.Mass, orbitD.Longitude, orbitD.Body.Mass);
            return Angles.EqualDeg180(axab, axcd, epsilon);
        }

        /// <summary>
        /// Is Real Axial Coincidence.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="orbitC">The orbit C.</param>
        /// <param name="orbitD">The orbit D.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsRealAxialCoincidence(Orbit orbitA, Orbit orbitB, Orbit orbitC, Orbit orbitD, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            orbitC.SetJulianDate(date);
            orbitD.SetJulianDate(date);
            var axab = RealAxis(orbitA, orbitB);
            var axcd = RealAxis(orbitC, orbitD);
            return Angles.EqualDeg180(axab + 90, axcd, epsilon);
        }
        #endregion

        #region Pericentre and Apocentre
        /// <summary>
        /// Is Apocentre.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsApocentre(Orbit orbitA, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            var rAB = Angles.Mod360(orbitA.LP + 180 - orbitA.Longitude);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Pericentre.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsPericentre(Orbit orbitA, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            var rAB = Angles.Mod360(orbitA.LP - orbitA.Longitude);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Determines whether the specified longitude a is apocentre.
        /// </summary>
        /// <param name="longitudeA">The longitude a.</param>
        /// <param name="periA">The peri a.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        ///   <c>true</c> if the specified longitude a is apocentre; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsApocentre(double longitudeA, double periA, double epsilon) {
            var rAB = Angles.Mod360(periA + 180 - longitudeA);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Pericentre.
        /// </summary>
        /// <param name="longitudeA">The longitude a.</param>
        /// <param name="periA">The peri a.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsPericentre(double longitudeA, double periA, double epsilon) {
            var rAB = Angles.Mod360(periA - longitudeA);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }
        #endregion

        #region Special Functions
        /// <summary>
        /// Is Solar Max Approx.
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool IsSolarMaxApprox(double date, double epsilon) {
            SolarSystem.Singleton.Jupiter.SetJulianDate(date);
            SolarSystem.Singleton.Uranus.SetJulianDate(date);
            SolarSystem.Singleton.Neptune.SetJulianDate(date);
            var jjp = Angles.Mod360(SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Jupiter.LP - 90);
            var un = Angles.Mod360(SolarSystem.Singleton.Uranus.Longitude - SolarSystem.Singleton.Neptune.Longitude + 90);
            var f = Angles.SymmetricAngle360(jjp + un);
            return Angles.EqualDeg(f, 180, epsilon);
        }

        /// <summary>
        /// A good approximations: SolarMaxApproxValue1, SolarMaxApproxValue5.
        /// </summary>
        /// <param name="valueType">Type of the value.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double SolarMaxApproxValue(int valueType) {
            var j = Angles.Mod360(SolarSystem.Singleton.Jupiter.Longitude);
            var s = Angles.Mod360(SolarSystem.Singleton.Saturn.Longitude);
            var u = Angles.Mod360(SolarSystem.Singleton.Uranus.Longitude);
            var n = Angles.Mod360(SolarSystem.Singleton.Neptune.Longitude);
            //// if (Math.Abs(Angles.Sinus(J - S) * Angles.Sinus(J - N)) < 0.1) {
            //// return 0; } 
            var gJS = Angles.Sinus(j - s) * Angles.Cosin(j - s);
            var gJU = Angles.Sinus(j - u) * Angles.Cosin(j - u);
            var gJN = Angles.Sinus(j - n) * Angles.Cosin(j - n);
            var gSU = Angles.Sinus(s - u) * Angles.Cosin(s - u);
            var gSN = Angles.Sinus(s - n) * Angles.Cosin(s - n);
            var gUN = Angles.Sinus(u - n) * Angles.Cosin(u - n);
            var vJS = 10.00 * (1 - Math.Abs(gJS));
            var vJU = 10.00 * (1 - Math.Abs(gJU)); //// 0
            var vJN = 10.00 * (1 - Math.Abs(gJN)); //// 2
            var vSU = 10.00 * (1 - Math.Abs(gSU)); //// 0
            var vSN = 10.00 * (1 - Math.Abs(gSN)); //// 2
            var vUN = 10.00 * (1 - Math.Abs(gUN)); //// 2
            double value = 0; //// vJS + vJU + vJN + vSU + vSN + vUN;
            switch (valueType) {
                case 1:
                    value = vJS;
                    break;
                case 2:
                    value = vJU;
                    break;
                case 3:
                    value = vJN;
                    break;
                case 4:
                    value = vSU;
                    break;
                case 5:
                    value = vSN;
                    break;
                case 6:
                    value = vUN;
                    break;
                //// Resharper default: break;
            }

            return value;
        }

        /* Some previous versions of the SolarMaxApproxValue1
         * public double SolarMaxApproxValue1(double date) {
            double J = Angles.Mod360(SolarSystem.Jupiter.Longitude);
            double S = Angles.Mod360(SolarSystem.Saturn.Longitude);
            double U = Angles.Mod360(SolarSystem.Uranus.Longitude);
            double N = Angles.Mod360(SolarSystem.Neptune.Longitude);
            double gJS = Angles.Sinus(J - S) * Angles.Cosin(J - S);
            double gJU = Angles.Sinus(J - U) * Angles.Cosin(J - U);
            double gJN = Angles.Sinus(J - N) * Angles.Cosin(J - N);
            double gSU = Angles.Sinus(S - U) * Angles.Cosin(S - U);
            double gSN = Angles.Sinus(S - N) * Angles.Cosin(S - N);
            double gUN = Angles.Sinus(U - N) * Angles.Cosin(U - N);
            double vJS = 8.00 * (1 - Math.Abs(gJS));
            double vJU = 0.00 * (1 - Math.Abs(gJU));
            double vJN = 4.00 * (1 - Math.Abs(gJN));
            double vSU = 0.00 * (1 - Math.Abs(gSU));
            double vSN = 4.00 * (1 - Math.Abs(gSN));
            double vUN = 4.00 * (1 - Math.Abs(gUN));
            double value = vJS + vJU + vJN + vSU + vSN + vUN;
            return value;
        }
         
        public double SolarMaxApproxValue2(double date) {
            double J = Angles.Mod360(SolarSystem.Jupiter.Longitude);
            double S = Angles.Mod360(SolarSystem.Saturn.Longitude);
            double U = Angles.Mod360(SolarSystem.Uranus.Longitude);
            double N = Angles.Mod360(SolarSystem.Neptune.Longitude);
            double gJS = Angles.Sinus(J - S) * Angles.Cosin(J - S);
            double gJU = Angles.Sinus(J - U) * Angles.Cosin(J - U);
            double gJN = Angles.Sinus(J - N) * Angles.Cosin(J - N);
            double gSU = Angles.Sinus(S - U) * Angles.Cosin(S - U);
            double gSN = Angles.Sinus(S - N) * Angles.Cosin(S - N);
            double gUN = Angles.Sinus(U - N) * Angles.Cosin(U - N);
            double vJS = 8.00 * (Math.Abs(gJS));
            double vJU = 0.00 * (Math.Abs(gJU));
            double vJN = 4.00 * (Math.Abs(gJN));
            double vSU = 0.00 * (Math.Abs(gSU));
            double vSN = 4.00 * (Math.Abs(gSN));
            double vUN = 4.00 * (Math.Abs(gUN));
            double value = vJS + vJU + vJN + vSU + vSN + vUN;
            return value;
        }
         * 
        public double SolarMaxApproxValue3(double date) {
            double J = Angles.Mod360(SolarSystem.Jupiter.Longitude);
            double S = Angles.Mod360(SolarSystem.Saturn.Longitude);
            double U = Angles.Mod360(SolarSystem.Uranus.Longitude);
            double N = Angles.Mod360(SolarSystem.Neptune.Longitude);
            double gJS = Angles.Sinus(J - S);
            double gJU = Angles.Sinus(J - U);
            double gJN = Angles.Sinus(J - N);
            double gSU = Angles.Sinus(S - U);
            double gSN = Angles.Sinus(S - N);
            double gUN = Angles.Sinus(U - N);
            double vJS = 8.00 * (Math.Abs(gJS));
            double vJU = 0.00 * (Math.Abs(gJU));
            double vJN = 4.00 * (Math.Abs(gJN));
            double vSU = 0.00 * (Math.Abs(gSU));
            double vSN = 4.00 * (Math.Abs(gSN));
            double vUN = 4.00 * (Math.Abs(gUN));
            double value = vJS + vJU + vJN + vSU + vSN + vUN;
            return value;
        }* 
         * 
        public double SolarMaxApproxValue4(double date) {
            double J = Angles.Mod360(SolarSystem.Jupiter.Longitude);
            double S = Angles.Mod360(SolarSystem.Saturn.Longitude);
            double U = Angles.Mod360(SolarSystem.Uranus.Longitude);
            double N = Angles.Mod360(SolarSystem.Neptune.Longitude);
            double gJS = Angles.Sinus(J - S);
            double gJU = Angles.Sinus(J - U);
            double gJN = Angles.Sinus(J - N);
            double gSU = Angles.Sinus(S - U);
            double gSN = Angles.Sinus(S - N);
            double gUN = Angles.Sinus(U - N);
            double vJS = 8.00 * (Math.Pow(gJS,4));
            double vJU = 0.00;
            double vJN = 4.00 * (Math.Pow(gJN,4));
            double vSU = 0.00;
            double vSN = 4.00 * (Math.Pow(gSN,4));
            double vUN = 4.00 * (Math.Pow(gUN,4));
            double value = vJS + vJU + vJN + vSU + vSN + vUN;
            return value;
        }* 
         * 
         
        public double SolarMaxApproxValue5(double date) {
            double J = Angles.Mod360(SolarSystem.Jupiter.Longitude);
            double S = Angles.Mod360(SolarSystem.Saturn.Longitude);
            double U = Angles.Mod360(SolarSystem.Uranus.Longitude);
            double N = Angles.Mod360(SolarSystem.Neptune.Longitude);
            double sJS = Angles.Sinus(J - S); double cJS=Angles.Cosin(J - S);
            double sJU = Angles.Sinus(J - U); double cJU = Angles.Cosin(J - U);
            double sJN = Angles.Sinus(J - N); double cJN = Angles.Cosin(J - N);
            double sSU = Angles.Sinus(S - U); double cSU = Angles.Cosin(S - U);
            double sSN = Angles.Sinus(S - N); double cSN = Angles.Cosin(S - N);
            double sUN = Angles.Sinus(U - N); double cUN = Angles.Cosin(U - N);
            double vJX = 8.00 + 4 * Math.Abs(cJS) + 4 * Math.Abs(cJN);
            double vJY = 4 * Math.Abs(sJS) + 4 * Math.Abs(sJN);
            double value = vJX * vJY;
            return value;
        }* 
         * 
        public double SolarMaxApproxValue6(double date) {
            double J = Angles.Mod360(SolarSystem.Jupiter.Longitude);
            double S = Angles.Mod360(SolarSystem.Saturn.Longitude);
            double U = Angles.Mod360(SolarSystem.Uranus.Longitude);
            double N = Angles.Mod360(SolarSystem.Neptune.Longitude);
            double sJS = Angles.Sinus(J - S); double cJS=Angles.Cosin(J - S);
            double sJU = Angles.Sinus(J - U); double cJU = Angles.Cosin(J - U);
            double sJN = Angles.Sinus(J - N); double cJN = Angles.Cosin(J - N);
            double sSU = Angles.Sinus(S - U); double cSU = Angles.Cosin(S - U);
            double sSN = Angles.Sinus(S - N); double cSN = Angles.Cosin(S - N);
            double sUN = Angles.Sinus(U - N); double cUN = Angles.Cosin(U - N);
            double vJX = 4 * Math.Abs(cJS) + 4 * Math.Abs(cJN);
            double vJY = 4 * Math.Abs(sJS) + 4 * Math.Abs(sJN);
            double value = vJX * vJY;
            return value;
        }* 
         */

        #endregion

        #region Public static

        /// <summary>
        /// Is Conjunction.
        /// </summary>
        /// <param name="length0">The length0.</param>
        /// <param name="length1">The length1.</param>
        /// <param name="length2">The length2.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static bool IsConjunction(double length0, double length1, double length2, double epsilon) {
            return IsConjunction(length0, length1, epsilon) && IsConjunction(length0, length2, epsilon)
                && IsConjunction(length1, length2, epsilon);
        }

        /// <summary>
        /// Determines whether [is equinox solstice point] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        ///   <c>true</c> if [is equinox solstice point] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEquinoxSolsticePoint(double date, double epsilon) { //// Orbit orbitA, 
            //// orbitA.SetJulianDate(date);
            var year = Julian.Year(date);
            var time1 = EquinoxesAndSolstices.EquinoxSolstice(year, EquinoxType.VernalEquinox);
            var time2 = EquinoxesAndSolstices.EquinoxSolstice(year, EquinoxType.SummerSolstice);
            var time3 = EquinoxesAndSolstices.EquinoxSolstice(year, EquinoxType.AutumnalEquinox);
            var time4 = EquinoxesAndSolstices.EquinoxSolstice(year, EquinoxType.WinterSolstice);
            var e1 = AstroMath.Equal(date, time1, epsilon);
            var e2 = AstroMath.Equal(date, time2, epsilon);
            var e3 = AstroMath.Equal(date, time3, epsilon);
            var e4 = AstroMath.Equal(date, time4, epsilon);
            return e1 || e2 || e3 || e4;
            //// return Angles.EqualDeg(orbitA.Longitude, -10, epsilon) || Angles.EqualDeg(orbitA.Longitude, 80, epsilon)
            ////       || Angles.EqualDeg(orbitA.Longitude, 170, epsilon) || Angles.EqualDeg(orbitA.Longitude, 260, epsilon); 
        }

        /// <summary>
        /// Determines whether [is full moon] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        ///   <c>true</c> if [is full moon] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFullMoon(double date, double epsilon) {
            var year = Julian.Year(date);
            var list = MoonPhases.ListOfMoonPhases(MoonPhase.FullMoon, (int)year);
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var dtime in list) {
                var time1 = Julian.Date2Julian(dtime);
                var e1 = AstroMath.Equal(date, time1, epsilon);
                if (e1) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Is Aspect.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static bool IsAspect(Orbit orbitA, Orbit orbitB, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            var rAB = Angles.Mod180(orbitA.Longitude - orbitB.Longitude);
            return Angles.EqualDeg180(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Conjunction.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static bool IsConjunction(Orbit orbitA, Orbit orbitB, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            var rAB = Angles.Mod360(orbitA.Longitude - orbitB.Longitude);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }
        #endregion

        #region Protected static

        /// <summary>
        /// Is Opposition.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        protected static bool IsOpposition(Orbit orbitA, Orbit orbitB, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            var rAB = Angles.Mod360(orbitA.Longitude - orbitB.Longitude + 180);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }

        /// <summary>
        /// Is Right Angle.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <param name="date">The given date.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        protected static bool IsRightAngle(Orbit orbitA, Orbit orbitB, double date, double epsilon) {
            orbitA.SetJulianDate(date);
            orbitB.SetJulianDate(date);
            var rAB = Angles.Mod180(orbitA.Longitude - orbitB.Longitude + 90);
            return Angles.EqualDeg(rAB, 0, epsilon);
        }
        #endregion

        #region Private static methods

        /// <summary>
        /// Real Axis.
        /// </summary>
        /// <param name="orbitA">The orbit A.</param>
        /// <param name="orbitB">The orbit B.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double RealAxis(Orbit orbitA, Orbit orbitB) {
            var xa = ((orbitA.Point.XH * orbitA.Body.Mass) + (orbitB.Point.XH * orbitB.Body.Mass)) / (orbitA.Body.Mass + orbitB.Body.Mass);
            var ya = ((orbitA.Point.YH * orbitA.Body.Mass) + (orbitB.Point.YH * orbitB.Body.Mass)) / (orbitA.Body.Mass + orbitB.Body.Mass);
            var fia = Angles.ArcTan2(ya, xa);
            fia = Angles.NormalSharpAngle(fia);
            return fia;
        }
        #endregion
    }
}
