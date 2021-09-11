// <copyright file="JupiterSystem.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Systems {
    using System.Globalization;
    using System.Text;
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using JetBrains.Annotations;

    /// <summary> Galilean Moons. </summary>
    [UsedImplicitly]
    public sealed class JupiterSystem {
        /// <summary>
        ///  Epoch of orbital elements.
        /// </summary>
        private readonly double epochOrbit; 
        
        /// <summary>
        /// Initializes a new instance of the JupiterSystem class.
        /// </summary>
        public JupiterSystem() {
            this.epochOrbit = 0.0; //// ???
        }

        /// <summary>
        /// Compute Conjunctions.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public string Conjunctions() {
            double julianDate, lastJulianDay = 0;
            var dateFrom = Julian.JulYear(1952.023);  // 1976.474);
            var dateTo = Julian.JulYear(2000.0);
            const double stepDays = 0.01;
            var sb = new StringBuilder();
            for (julianDate = dateFrom; julianDate <= dateTo; julianDate = julianDate + stepDays) {
                var jeday = julianDate - this.epochOrbit;
                var l0 = LongitudeIO(jeday);
                var l1 = LongitudeEuropa(jeday);
                var l2 = LongitudeGanymed(jeday);
                var l3 = LongitudeKallisto(jeday);
                if (!Angles.EqualDeg(l2, l3, 1))
                {
                    continue;
                }

                if (!Angles.EqualDeg180(l1, l2, 1))
                {
                    continue;
                }

                if (!Angles.EqualDeg180(l0, l1, 1))
                {
                    continue;
                }

                var s = string.Format(CultureInfo.InvariantCulture, "{0} {1} \n", (julianDate - lastJulianDay) / Julian.TropicalYear, Julian.Year(julianDate));
                sb.Append(s);
                ////  printf("(%8.3f) %8.3f   ",(julianDate-last_JulianDay)/TropicalYear, Year(julianDate));
                ////  PRINT_CALENDAR_DATE(julianDate); printf("\n");
                lastJulianDay = julianDate;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Position of the moons.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public string Positions() {
            double julianDate;
            var dateFrom = Julian.JulYear(1963.509); //// 1952.023
            var dateTo = Julian.JulYear(2005.0);
            const double stepDays = 839.04;
            var sb = new StringBuilder();
            for (julianDate = dateFrom; julianDate <= dateTo; julianDate = julianDate + stepDays) {
                var jeday = julianDate - this.epochOrbit;
                var l0 = LongitudeIO(jeday);
                var l1 = LongitudeEuropa(jeday);
                var l2 = LongitudeGanymed(jeday);
                var l3 = LongitudeKallisto(jeday);
                var s = string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3}\n", l0, l1, l2, l3);
                sb.Append(s);
                //// printf("%8.3f ", Year(julianDate));
                //// PRINT_CALENDAR_DATE(julianDate);
                //// printf("  %5.1f %5.1f %5.1f %5.1f ",L0,L1,L2,L3);  printf("\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Longitude Io.
        /// </summary>
        /// <param name="t">The value t.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double LongitudeIO(double t) {
            ////   double L = Mod360(106.07719 + 203.488955790*t);
            var l = Angles.Mod360(163.8067 + (203.4058643 * t));
            return l;
        }

        /// <summary>
        /// Longitude Europa.
        /// </summary>
        /// <param name="t">The value t.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double LongitudeEuropa(double t) {
            ////   double L = Mod360(175.73161 + 101.374724735*t);
            var l = Angles.Mod360(358.4108 + (101.2916334 * t));
            return l;
        }

        /// <summary>
        /// Longitude Ganymedes.
        /// </summary>
        /// <param name="t">The value t.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double LongitudeGanymed(double t) {
            ////   double L = Mod360(120.55883 + 50.317609207*t);
            var l = Angles.Mod360(5.7129 + (50.2345179 * t));
            return l;
        }

        /// <summary>
        /// Longitude Kallisto.
        /// </summary>
        /// <param name="t">The value t.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double LongitudeKallisto(double t) {
            ////   double L = Mod360(84.44459 + 21.571071177*t);
            var l = Angles.Mod360(224.8151 + (21.4879801 * t));
            return l;
        }
    }
}
