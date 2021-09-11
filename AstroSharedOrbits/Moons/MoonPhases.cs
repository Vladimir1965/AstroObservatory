// <copyright file="MoonPhases.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Moons {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Enums;
    using JetBrains.Annotations;

    /// <summary>
    /// Moon Phases.
    /// </summary>
    public static class MoonPhases {
        #region Naughter
        /// <summary>
        /// Ks the specified year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double K(double year) {
            return 12.3685 * (year - 2000);
        }

        /// <summary>
        /// Means the phase.
        /// </summary>
        /// <param name="givenK">The given k.</param>
        /// <returns> Returns value. </returns>
        public static double MeanPhase(double givenK) {
            //// convert from K to T
            var timeT = givenK / 1236.85;
            var timeT2 = timeT * timeT;
            var timeT3 = timeT2 * timeT;
            var dT4 = timeT3 * timeT;

            return 2451550.09766 + 29.530588861 * givenK + 0.00015437 * timeT2 - 0.000000150 * timeT3 + 0.00000000073 * dT4;
        }

        /// <summary>
        /// Trues the phase.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double TruePhase(double givenK) {
            const double tolerance = 0.00001;

            //// What will be the return value
            var julianDay = MeanPhase(givenK);

            //// convert from K to T
            var timeT = givenK / 1236.85;
            var timeT2 = timeT * timeT;
            var timeT3 = timeT2 * timeT;
            var dT4 = timeT3 * timeT;

            var eccentricE = 1 - 0.002516 * timeT - 0.0000074 * timeT2;
            var e2 = eccentricE * eccentricE;

            var anomalyM = Angles.Mod360(2.5534 + 29.10535670 * givenK - 0.0000014 * timeT2 - 0.00000011 * timeT3);
            anomalyM = Angles.DegRad(anomalyM);
            var mdash = Angles.Mod360(201.5643 + 385.81693528 * givenK + 0.0107582 * timeT2 + 0.00001238 * timeT3 - 0.000000058 * dT4);
            mdash = Angles.DegRad(mdash);
            var latitudeF = Angles.Mod360(160.7108 + 390.67050284 * givenK - 0.0016118 * timeT2 - 0.00000227 * timeT3 + 0.00000001 * dT4);
            latitudeF = Angles.DegRad(latitudeF);
            var omega = Angles.Mod360(124.7746 - 1.56375588 * givenK + 0.0020672 * timeT2 + 0.00000215 * timeT3);
            omega = Angles.DegRad(omega);
            var a1 = Angles.Mod360(299.77 + 0.107408 * givenK - 0.009173 * timeT2);
            a1 = Angles.DegRad(a1);
            var a2 = Angles.Mod360(251.88 + 0.016321 * givenK);
            a2 = Angles.DegRad(a2);
            var a3 = Angles.Mod360(251.83 + 26.651886 * givenK);
            a3 = Angles.DegRad(a3);
            var a4 = Angles.Mod360(349.42 + 36.412478 * givenK);
            a4 = Angles.DegRad(a4);
            var a5 = Angles.Mod360(84.66 + 18.206239 * givenK);
            a5 = Angles.DegRad(a5);
            var a6 = Angles.Mod360(141.74 + 53.303771 * givenK);
            a6 = Angles.DegRad(a6);
            var a7 = Angles.Mod360(207.14 + 2.453732 * givenK);
            a7 = Angles.DegRad(a7);
            var a8 = Angles.Mod360(154.84 + 7.306860 * givenK);
            a8 = Angles.DegRad(a8);
            var a9 = Angles.Mod360(34.52 + 27.261239 * givenK);
            a9 = Angles.DegRad(a9);
            var a10 = Angles.Mod360(207.19 + 0.121824 * givenK);
            a10 = Angles.DegRad(a10);
            var a11 = Angles.Mod360(291.34 + 1.844379 * givenK);
            a11 = Angles.DegRad(a11);
            var a12 = Angles.Mod360(161.72 + 24.198154 * givenK);
            a12 = Angles.DegRad(a12);
            var a13 = Angles.Mod360(239.56 + 25.513099 * givenK);
            a13 = Angles.DegRad(a13);
            var a14 = Angles.Mod360(331.55 + 3.592518 * givenK);
            a14 = Angles.DegRad(a14);

            //// convert to radians
            double kint;
            var kfrac = AstroMath.Mod(givenK, out kint);
            if (kfrac < 0) {
                kfrac = 1 + kfrac;
            }

            if (Math.Abs(kfrac) < tolerance) { //// New Moon
                var deltaJulianDay = -0.40720 * Math.Sin(mdash) +
                      0.17241 * eccentricE * Math.Sin(anomalyM) +
                      0.01608 * Math.Sin(2 * mdash) +
                      0.01039 * Math.Sin(2 * latitudeF) +
                      0.00739 * eccentricE * Math.Sin(mdash - anomalyM) +
                      -0.00514 * eccentricE * Math.Sin(mdash + anomalyM) +
                      0.00208 * e2 * Math.Sin(2 * anomalyM) +
                      -0.00111 * Math.Sin(mdash - 2 * latitudeF) +
                      -0.00057 * Math.Sin(mdash + 2 * latitudeF) +
                      0.00056 * eccentricE * Math.Sin(2 * mdash + anomalyM) +
                      -0.00042 * Math.Sin(3 * mdash) +
                      0.00042 * eccentricE * Math.Sin(anomalyM + 2 * latitudeF) +
                      0.00038 * eccentricE * Math.Sin(anomalyM - 2 * latitudeF) +
                      -0.00024 * eccentricE * Math.Sin(2 * mdash - anomalyM) +
                      -0.00017 * Math.Sin(omega) +
                      -0.00007 * Math.Sin(mdash + 2 * anomalyM) +
                      0.00004 * Math.Sin(2 * mdash - 2 * latitudeF) +
                      0.00004 * Math.Sin(3 * anomalyM) +
                      0.00003 * Math.Sin(mdash + anomalyM - 2 * latitudeF) +
                      0.00003 * Math.Sin(2 * mdash + 2 * latitudeF) +
                      -0.00003 * Math.Sin(mdash + anomalyM + 2 * latitudeF) +
                      0.00003 * Math.Sin(mdash - anomalyM + 2 * latitudeF) +
                      -0.00002 * Math.Sin(mdash - anomalyM - 2 * latitudeF) +
                      -0.00002 * Math.Sin(3 * mdash + anomalyM) +
                      0.00002 * Math.Sin(4 * mdash);
                julianDay += deltaJulianDay;
            }
            else if ((Math.Abs(kfrac - 0.25) < tolerance) || (Math.Abs(kfrac - 0.75) < tolerance)) { ////First Quarter or Last Quarter
                var deltaJulianDay = -0.62801 * Math.Sin(mdash) +
                      0.17172 * eccentricE * Math.Sin(anomalyM) +
                      -0.01183 * eccentricE * Math.Sin(mdash + anomalyM) +
                      0.00862 * Math.Sin(2 * mdash) +
                      0.00804 * Math.Sin(2 * latitudeF) +
                      0.00454 * eccentricE * Math.Sin(mdash - anomalyM) +
                      0.00204 * e2 * Math.Sin(2 * anomalyM) +
                      -0.00180 * Math.Sin(mdash - 2 * latitudeF) +
                      -0.00070 * Math.Sin(mdash + 2 * latitudeF) +
                      -0.00040 * Math.Sin(3 * mdash) +
                      -0.00034 * eccentricE * Math.Sin(2 * mdash - anomalyM) +
                      0.00032 * eccentricE * Math.Sin(anomalyM + 2 * latitudeF) +
                      0.00032 * eccentricE * Math.Sin(anomalyM - 2 * latitudeF) +
                      -0.00028 * e2 * Math.Sin(mdash + 2 * anomalyM) +
                      0.00027 * eccentricE * Math.Sin(2 * mdash + anomalyM) +
                      -0.00017 * Math.Sin(omega) +
                      -0.00005 * Math.Sin(mdash - anomalyM - 2 * latitudeF) +
                      0.00004 * Math.Sin(2 * mdash + 2 * latitudeF) +
                      -0.00004 * Math.Sin(mdash + anomalyM + 2 * latitudeF) +
                      0.00004 * Math.Sin(mdash - 2 * anomalyM) +
                      0.00003 * Math.Sin(mdash + anomalyM - 2 * latitudeF) +
                      0.00003 * Math.Sin(3 * anomalyM) +
                      0.00002 * Math.Sin(2 * mdash - 2 * latitudeF) +
                      0.00002 * Math.Sin(mdash - anomalyM + 2 * latitudeF) +
                      -0.00002 * Math.Sin(3 * mdash + anomalyM);
                julianDay += deltaJulianDay;

                var w = 0.00306 - 0.00038 * eccentricE * Math.Cos(anomalyM) + 0.00026 * Math.Cos(mdash) - 0.00002 * Math.Cos(mdash - anomalyM) + 0.00002 * Math.Cos(mdash + anomalyM) + 0.00002 * Math.Cos(2 * latitudeF);
                julianDay = Math.Abs(kfrac - 0.25) < tolerance ? julianDay + w : julianDay - w;
            }
            else if (Math.Abs(kfrac - 0.5) < tolerance) { //// Full Moon
                var deltaJulianDay = -0.40614 * Math.Sin(mdash) +
                      0.17302 * eccentricE * Math.Sin(anomalyM) +
                      0.01614 * Math.Sin(2 * mdash) +
                      0.01043 * Math.Sin(2 * latitudeF) +
                      0.00734 * eccentricE * Math.Sin(mdash - anomalyM) +
                      -0.00514 * eccentricE * Math.Sin(mdash + anomalyM) +
                      0.00209 * e2 * Math.Sin(2 * anomalyM) +
                      -0.00111 * Math.Sin(mdash - 2 * latitudeF) +
                      -0.00057 * Math.Sin(mdash + 2 * latitudeF) +
                      0.00056 * eccentricE * Math.Sin(2 * mdash + anomalyM) +
                      -0.00042 * Math.Sin(3 * mdash) +
                      0.00042 * eccentricE * Math.Sin(anomalyM + 2 * latitudeF) +
                      0.00038 * eccentricE * Math.Sin(anomalyM - 2 * latitudeF) +
                      -0.00024 * eccentricE * Math.Sin(2 * mdash - anomalyM) +
                      -0.00017 * Math.Sin(omega) +
                      -0.00007 * Math.Sin(mdash + 2 * anomalyM) +
                      0.00004 * Math.Sin(2 * mdash - 2 * latitudeF) +
                      0.00004 * Math.Sin(3 * anomalyM) +
                      0.00003 * Math.Sin(mdash + anomalyM - 2 * latitudeF) +
                      0.00003 * Math.Sin(2 * mdash + 2 * latitudeF) +
                      -0.00003 * Math.Sin(mdash + anomalyM + 2 * latitudeF) +
                      0.00003 * Math.Sin(mdash - anomalyM + 2 * latitudeF) +
                      -0.00002 * Math.Sin(mdash - anomalyM - 2 * latitudeF) +
                      -0.00002 * Math.Sin(3 * mdash + anomalyM) +
                      0.00002 * Math.Sin(4 * mdash);
                julianDay += deltaJulianDay;
            }
            else {
                Debug.Assert(false, "Reason of the assert");
            }

            //// Additional corrections for all phases
            var deltaJulianDay2 = 0.000325 * Math.Sin(a1) +
                  0.000165 * Math.Sin(a2) +
                  0.000164 * Math.Sin(a3) +
                  0.000126 * Math.Sin(a4) +
                  0.000110 * Math.Sin(a5) +
                  0.000062 * Math.Sin(a6) +
                  0.000060 * Math.Sin(a7) +
                  0.000056 * Math.Sin(a8) +
                  0.000047 * Math.Sin(a9) +
                  0.000042 * Math.Sin(a10) +
                  0.000040 * Math.Sin(a11) +
                  0.000037 * Math.Sin(a12) +
                  0.000035 * Math.Sin(a13) +
                  0.000023 * Math.Sin(a14);
            julianDay += deltaJulianDay2;

            return julianDay;
        }
        #endregion

        #region AstroAlgo
        /// <summary>
        /// Returns a list of dates on which in the input moon phase occurs within the current object's year.  Basically, this method finds all the roots within a given range for a periodic function.
        /// </summary>
        /// <param name="phase">Phase to calculate for. MoonPhases enumeration.</param>
        /// <param name="givenYear">The given year.</param>
        /// <returns>
        /// List of dates phase occurs on.
        /// </returns>
        [UsedImplicitly]
        public static List<DateTime> ListOfMoonPhases(MoonPhase phase, int givenYear) {
            ////  create a new list
            var phaseDates = new List<DateTime>();
            double year = givenYear;
            for (year -= 0.05; year < givenYear + 1; year += 0.05) {
                var d = Julian.Julian2Date(MoonPhaseDate(year, phase));

                ////  if the list already contains the calculated date, do not include it again.
                ////  or if the date is not within the current object's year.
                if (!phaseDates.Contains(d) && d.Year == givenYear) {
                    phaseDates.Add(d);
                }
            }

            return phaseDates;
        }

        /// <summary>Calculates the Julian Day the input phases occurs closets to the input fractional year.</summary>
        /// <param name="year">Year and day as a fraction in which to calculate the phase occurrance.</param>
        /// <param name="phase">Phase to calculate.</param>
        /// <returns>Return a date and time as a fractional Julian Day.</returns>
        [UsedImplicitly]
        public static double MoonPhaseDate(double year, MoonPhase phase) {
            double w = 0;                  //// quarter phase corrections 
            double corrections = 0;        //// sum of corrections 
            ////  init planetary arguments array
            var a = new double[14];
            var k = Math.Floor((year - 2000.0) * 12.3685) + ((double)phase * 0.25);
            //// time in Julian centuries 
            var t = k / 1236.85;
            //// eccentricity of Earth's orbit
            var e = 1.0 - t * (0.002516 - (0.0000074 * t));
            //// Sun's mean anomaly
            var m = Angles.Deg2Radian * (2.5534 + (29.10535669 * k) - t * t * (0.0000218 - (0.00000011 * t)));
            //// Moon's mean anomaly
            var mprime = Angles.Deg2Radian * (201.5643 + (385.81693528 * k) + t * t * (0.0107438 + (0.00001239 * t) - (0.000000058 * t * t)));
            //// Moon's argument of latitude
            var f = Angles.Deg2Radian * (160.7108 + (390.67050274 * k) + t * t * (0.0016341 + (0.00000227 * t) - (0.000000011 * t * t)));
            //// Longitude of the ascending node of the lunar orbit
            var omega = Angles.Deg2Radian * (124.7746 - (1.56375580 * k) + t * t * (0.0020691 + (0.00000215 * t)));

            a[0] = Angles.Deg2Radian * (299.77 + (0.107408 * k) - (0.009173 * t * t));
            a[1] = Angles.Deg2Radian * (251.88 + (0.016321 * k));
            a[2] = Angles.Deg2Radian * (251.83 + (26.651886 * k));
            a[3] = Angles.Deg2Radian * (349.42 + (36.412478 * k));
            a[4] = Angles.Deg2Radian * (84.66 + (18.206239 * k));
            a[5] = Angles.Deg2Radian * (141.74 + (53.303771 * k));
            a[6] = Angles.Deg2Radian * (207.14 + (2.453732 * k));
            a[7] = Angles.Deg2Radian * (154.84 + (7.306860 * k));
            a[8] = Angles.Deg2Radian * (34.52 + (27.261239 * k));
            a[9] = Angles.Deg2Radian * (207.19 + (0.121824 * k));
            a[10] = Angles.Deg2Radian * (291.34 + (1.844379 * k));
            a[11] = Angles.Deg2Radian * (161.72 + (24.198154 * k));
            a[12] = Angles.Deg2Radian * (239.56 + (25.513099 * k));
            a[13] = Angles.Deg2Radian * (331.55 + (3.592518 * k));
            //// sum of planetary arguments
            var atotal = .000001 * ((325 * Math.Sin(a[0]))
                                       + (165 * Math.Sin(a[1]))
                                       + (164 * Math.Sin(a[2]))
                                       + (126 * Math.Sin(a[3]))
                                       + (110 * Math.Sin(a[4]))
                                       + (62 * Math.Sin(a[5]))
                                       + (60 * Math.Sin(a[6]))
                                       + (56 * Math.Sin(a[7]))
                                       + (47 * Math.Sin(a[8]))
                                       + (42 * Math.Sin(a[9]))
                                       + (40 * Math.Sin(a[10]))
                                       + (37 * Math.Sin(a[11]))
                                       + (35 * Math.Sin(a[12]))
                                       + (23 * Math.Sin(a[13])));

            switch (phase) {
                case MoonPhase.NewMoon: {
                        corrections = -(0.40720 * Math.Sin(mprime))
                                        + (0.17241 * e * Math.Sin(m))
                                        + (0.01608 * Math.Sin(2 * mprime))
                                        + (0.01039 * Math.Sin(2 * f))
                                        + (0.00739 * e * Math.Sin(mprime - m))
                                        - (0.00514 * e * Math.Sin(mprime + m))
                                        + (0.00208 * e * e * Math.Sin(2 * m))
                                        - (0.00111 * Math.Sin(mprime - 2 * f))
                                        - (0.00057 * Math.Sin(mprime + 2 * f))
                                        + (0.00056 * e * Math.Sin(2 * mprime + m))
                                        - (0.00042 * Math.Sin(3 * mprime))
                                        + (0.00042 * e * Math.Sin(m + 2 * f))
                                        + (0.00038 * e * Math.Sin(m - 2 * f))
                                        - (0.00024 * e * Math.Sin(2 * mprime - m))
                                        - (0.00017 * Math.Sin(omega))
                                        - (0.00007 * Math.Sin(mprime + 2 * m))
                                        + (0.00004 * Math.Sin(2 * mprime - 2 * f))
                                        + (0.00004 * Math.Sin(3 * m))
                                        + (0.00003 * Math.Sin(mprime + m - 2 * f))
                                        + (0.00003 * Math.Sin(2 * mprime + 2 * f))
                                        - (0.00003 * Math.Sin(mprime + m + 2 * f))
                                        + (0.00003 * Math.Sin(mprime - m + 2 * f))
                                        - (0.00002 * Math.Sin(mprime - m - 2 * f))
                                        - (0.00002 * Math.Sin(3 * mprime + m))
                                        + (0.00002 * Math.Sin(4 * mprime));
                        break;
                    }

                case MoonPhase.FullMoon: {
                        corrections = -(0.40614 * Math.Sin(mprime))
                        + (0.17302 * e * Math.Sin(m))
                        + (0.01614 * Math.Sin(2 * mprime))
                        + (0.01043 * Math.Sin(2 * f))
                        + (0.00734 * e * Math.Sin(mprime - m))
                        - (0.00515 * e * Math.Sin(mprime + m))
                        + (0.00209 * e * e * Math.Sin(2 * m))
                        - (0.00111 * Math.Sin(mprime - 2 * f))
                        - (0.00057 * Math.Sin(mprime + 2 * f))
                        + (0.00056 * e * Math.Sin(2 * mprime + m))
                        - (0.00042 * Math.Sin(3 * mprime))
                        + (0.00042 * e * Math.Sin(m + 2 * f))
                        + (0.00038 * e * Math.Sin(m - 2 * f))
                        - (0.00024 * e * Math.Sin(2 * mprime - m))
                        - (0.00017 * Math.Sin(omega))
                        - (0.00007 * Math.Sin(mprime + 2 * m))
                        + (0.00004 * Math.Sin(2 * mprime - 2 * f))
                        + (0.00004 * Math.Sin(3 * m))
                        + (0.00003 * Math.Sin(mprime + m - 2 * f))
                        + (0.00003 * Math.Sin(2 * mprime + 2 * f))
                        - (0.00003 * Math.Sin(mprime + m + 2 * f))
                        + (0.00003 * Math.Sin(mprime - m + 2 * f))
                        - (0.00002 * Math.Sin(mprime - m - 2 * f))
                        - (0.00002 * Math.Sin(3 * mprime + m))
                        + (0.00002 * Math.Sin(4 * mprime));
                        break;
                    }

                case MoonPhase.FirstQuarter:
                case MoonPhase.LastQuarter: {
                        corrections = -(0.62801 * Math.Sin(mprime))
                        + (0.17172 * e * Math.Sin(m))
                        - (0.01183 * e * Math.Sin(mprime + m))
                        + (0.00862 * Math.Sin(2 * mprime))
                        + (0.00804 * Math.Sin(2 * f))
                        + (0.00454 * e * Math.Sin(mprime - m))
                        + (0.00204 * e * e * Math.Sin(2 * m))
                        - (0.00180 * Math.Sin(mprime - 2 * f))
                        - (0.00070 * Math.Sin(mprime + 2 * f))
                        - (0.00040 * Math.Sin(3 * mprime))
                        - (0.00034 * e * Math.Sin(2 * mprime - m))
                        + (0.00032 * e * Math.Sin(m + 2 * f))
                        + (0.00032 * e * Math.Sin(m - 2 * f))
                        - (0.00028 * e * e * Math.Sin(mprime + 2 * m))
                        + (0.00027 * e * Math.Sin(2 * mprime + m))
                        - (0.00017 * Math.Sin(omega))
                        - (0.00005 * Math.Sin(mprime - m - 2 * f))
                        + (0.00004 * Math.Sin(2 * mprime + 2 * f))
                        - (0.00004 * Math.Sin(mprime + m + 2 * f))
                        + (0.00004 * Math.Sin(mprime - 2 * m))
                        + (0.00003 * Math.Sin(mprime + m - 2 * f))
                        + (0.00003 * Math.Sin(3 * m))
                        + (0.00002 * Math.Sin(2 * mprime - 2 * f))
                        + (0.00002 * Math.Sin(mprime - m + 2 * f))
                        - (0.00002 * Math.Sin(3 * mprime + m));

                        w = .00306 - .00038 * e * Math.Cos(m) + .00026 * Math.Cos(mprime) - .00002 * Math.Cos(mprime - m) + .00002 * Math.Cos(mprime + m) + .00002 * Math.Cos(2 * f);

                        if (phase == MoonPhase.LastQuarter) {
                            w = -w;
                        }

                        break;
                    }
            } //// end switch

            return 2451550.09765 + (29.530588853 * k) + (0.0001337 * Math.Pow(t, 2)) - (0.000000150 * Math.Pow(t, 3)) + (0.00000000073 * Math.Pow(t, 4)) + corrections + atotal + w;
        } //// MoonPhase

        #endregion
    }
}
