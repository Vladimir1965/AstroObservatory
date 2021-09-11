// <copyright file="MoonMaxDeclinations.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Moons {
    using System;
    using AstroSharedClasses.Computation;
    using JetBrains.Annotations;

    /// <summary>
    /// Moon Max Declinations.
    /// </summary>
    [UsedImplicitly]
    public static class MoonMaxDeclinations {
        /// <summary>
        /// Ks the specified year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double K(double year) {
            return 13.3686 * (year - 2000.03);
        }

        /// <summary>
        /// Means the greatest declination.
        /// </summary>
        /// <param name="givenK">The given k.</param>
        /// <param name="givenNortherlyB">The b northerly.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeanGreatestDeclination(double givenK, bool givenNortherlyB) {
            //// convert from K to T
            var timeT = givenK / 1336.86;
            var timeT2 = timeT * timeT;
            var timeT3 = timeT2 * timeT;

            var value = givenNortherlyB ? 2451562.5897 : 2451548.9289;
            return value + 27.321582247 * givenK + 0.000119804 * timeT2 - 0.000000141 * timeT3;
        }

        /// <summary>
        /// Means the greatest declination value.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double MeanGreatestDeclinationValue(double givenK) {
            //// convert from K to T
            var timeT = givenK / 1336.86;
            return 23.6961 - 0.013004 * timeT;
        }

        /// <summary>
        /// Trues the greatest declination.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <param name="givenNortherlyB">The b northerly.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double TrueGreatestDeclination(double givenK, bool givenNortherlyB) {
            //// convert from K to T
            var timeT = givenK / 1336.86;
            var timeT2 = timeT * timeT;
            var timeT3 = timeT2 * timeT;

            var angleD = givenNortherlyB ? 152.2029 : 345.6676;
            angleD = Angles.Mod360(angleD + 333.0705546 * givenK - 0.0004214 * timeT2 + 0.00000011 * timeT3);
            var anomalyM = givenNortherlyB ? 14.8591 : 1.3951;
            anomalyM = Angles.Mod360(anomalyM + 26.9281592 * givenK - 0.0000355 * timeT2 - 0.00000010 * timeT3);
            var mdash = givenNortherlyB ? 4.6881 : 186.2100;
            mdash = Angles.Mod360(mdash + 356.9562794 * givenK + 0.0103066 * timeT2 + 0.00001251 * timeT3);
            var latitudeF = givenNortherlyB ? 325.8867 : 145.1633;
            latitudeF = Angles.Mod360(latitudeF + 1.4467807 * givenK - 0.0020690 * timeT2 - 0.00000215 * timeT3);
            var eccentricE = 1 - 0.002516 * timeT - 0.0000074 * timeT2;

            //// convert to radians
            angleD = Angles.DegRad(angleD);
            anomalyM = Angles.DegRad(anomalyM);
            mdash = Angles.DegRad(mdash);
            latitudeF = Angles.DegRad(latitudeF);

            double deltaJulianDay;
            if (givenNortherlyB) {
                deltaJulianDay = 0.8975 * Math.Cos(latitudeF) +
                          -0.4726 * Math.Sin(mdash) +
                          -0.1030 * Math.Sin(2 * latitudeF) +
                          -0.0976 * Math.Sin(2 * angleD - mdash) +
                          -0.0462 * Math.Cos(mdash - latitudeF) +
                          -0.0461 * Math.Cos(mdash + latitudeF) +
                          -0.0438 * Math.Sin(2 * angleD) +
                          0.0162 * eccentricE * Math.Sin(anomalyM) +
                          -0.0157 * Math.Cos(3 * latitudeF) +
                          0.0145 * Math.Sin(mdash + 2 * latitudeF) +
                          0.0136 * Math.Cos(2 * angleD - latitudeF) +
                          -0.0095 * Math.Cos(2 * angleD - mdash - latitudeF) +
                          -0.0091 * Math.Cos(2 * angleD - mdash + latitudeF) +
                          -0.0089 * Math.Cos(2 * angleD + latitudeF) +
                          0.0075 * Math.Sin(2 * mdash) +
                          -0.0068 * Math.Sin(mdash - 2 * latitudeF) +
                          0.0061 * Math.Cos(2 * mdash - latitudeF) +
                          -0.0047 * Math.Sin(mdash + 3 * latitudeF) +
                          -0.0043 * eccentricE * Math.Sin(2 * angleD - anomalyM - mdash) +
                          -0.0040 * Math.Cos(mdash - 2 * latitudeF) +
                          -0.0037 * Math.Sin(2 * angleD - 2 * mdash) +
                          0.0031 * Math.Sin(latitudeF) +
                          0.0030 * Math.Sin(2 * angleD + mdash) +
                          -0.0029 * Math.Cos(mdash + 2 * latitudeF) +
                          -0.0029 * eccentricE * Math.Sin(2 * angleD - anomalyM) +
                          -0.0027 * Math.Sin(mdash + latitudeF) +
                          0.0024 * eccentricE * Math.Sin(anomalyM - mdash) +
                          -0.0021 * Math.Sin(mdash - 3 * latitudeF) +
                          0.0019 * Math.Sin(2 * mdash + latitudeF) +
                          0.0018 * Math.Cos(2 * angleD - 2 * mdash - latitudeF) +
                          0.0018 * Math.Sin(3 * latitudeF) +
                          0.0017 * Math.Cos(mdash + 3 * latitudeF) +
                          0.0017 * Math.Cos(2 * mdash) +
                          -0.0014 * Math.Cos(2 * angleD - mdash) +
                          0.0013 * Math.Cos(2 * angleD + mdash + latitudeF) +
                          0.0013 * Math.Cos(mdash) +
                          0.0012 * Math.Sin(3 * mdash + latitudeF) +
                          0.0011 * Math.Sin(2 * angleD - mdash + latitudeF) +
                          -0.0011 * Math.Cos(2 * angleD - 2 * mdash) +
                          0.0010 * Math.Cos(angleD + latitudeF) +
                          0.0010 * eccentricE * Math.Sin(anomalyM + mdash) +
                          -0.0009 * Math.Sin(2 * angleD - 2 * latitudeF) +
                          0.0007 * Math.Cos(2 * mdash + latitudeF) +
                          -0.0007 * Math.Cos(3 * mdash + latitudeF);
            }
            else {
                deltaJulianDay = -0.8975 * Math.Cos(latitudeF) +
                          -0.4726 * Math.Sin(mdash) +
                          -0.1030 * Math.Sin(2 * latitudeF) +
                          -0.0976 * Math.Sin(2 * angleD - mdash) +
                          0.0541 * Math.Cos(mdash - latitudeF) +
                          0.0516 * Math.Cos(mdash + latitudeF) +
                          -0.0438 * Math.Sin(2 * angleD) +
                          0.0112 * eccentricE * Math.Sin(anomalyM) +
                          0.0157 * Math.Cos(3 * latitudeF) +
                          0.0023 * Math.Sin(mdash + 2 * latitudeF) +
                          -0.0136 * Math.Cos(2 * angleD - latitudeF) +
                          0.0110 * Math.Cos(2 * angleD - mdash - latitudeF) +
                          0.0091 * Math.Cos(2 * angleD - mdash + latitudeF) +
                          0.0089 * Math.Cos(2 * angleD + latitudeF) +
                          0.0075 * Math.Sin(2 * mdash) +
                          -0.0030 * Math.Sin(mdash - 2 * latitudeF) +
                          -0.0061 * Math.Cos(2 * mdash - latitudeF) +
                          -0.0047 * Math.Sin(mdash + 3 * latitudeF) +
                          -0.0043 * eccentricE * Math.Sin(2 * angleD - anomalyM - mdash) +
                          0.0040 * Math.Cos(mdash - 2 * latitudeF) +
                          -0.0037 * Math.Sin(2 * angleD - 2 * mdash) +
                          -0.0031 * Math.Sin(latitudeF) +
                          0.0030 * Math.Sin(2 * angleD + mdash) +
                          0.0029 * Math.Cos(mdash + 2 * latitudeF) +
                          -0.0029 * eccentricE * Math.Sin(2 * angleD - anomalyM) +
                          -0.0027 * Math.Sin(mdash + latitudeF) +
                          0.0024 * eccentricE * Math.Sin(anomalyM - mdash) +
                          -0.0021 * Math.Sin(mdash - 3 * latitudeF) +
                          -0.0019 * Math.Sin(2 * mdash + latitudeF) +
                          -0.0006 * Math.Cos(2 * angleD - 2 * mdash - latitudeF) +
                          -0.0018 * Math.Sin(3 * latitudeF) +
                          -0.0017 * Math.Cos(mdash + 3 * latitudeF) +
                          0.0017 * Math.Cos(2 * mdash) +
                          0.0014 * Math.Cos(2 * angleD - mdash) +
                          -0.0013 * Math.Cos(2 * angleD + mdash + latitudeF) +
                          -0.0013 * Math.Cos(mdash) +
                          0.0012 * Math.Sin(3 * mdash + latitudeF) +
                          0.0011 * Math.Sin(2 * angleD - mdash + latitudeF) +
                          0.0011 * Math.Cos(2 * angleD - 2 * mdash) +
                          0.0010 * Math.Cos(angleD + latitudeF) +
                          0.0010 * eccentricE * Math.Sin(anomalyM + mdash) +
                          -0.0009 * Math.Sin(2 * angleD - 2 * latitudeF) +
                          -0.0007 * Math.Cos(2 * mdash + latitudeF) +
                          -0.0007 * Math.Cos(3 * mdash + latitudeF);
            }

            return MeanGreatestDeclination(givenK, givenNortherlyB) + deltaJulianDay;
        }

        /// <summary>
        /// Trues the greatest declination value.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <param name="givenNortherlyB">The b northerly.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double TrueGreatestDeclinationValue(double givenK, bool givenNortherlyB) {
            //// convert from K to T
            var timeT = givenK / 1336.86;
            var timeT2 = timeT * timeT;
            var timeT3 = timeT2 * timeT;

            var angleD = givenNortherlyB ? 152.2029 : 345.6676;
            angleD = Angles.Mod360(angleD + 333.0705546 * givenK - 0.0004214 * timeT2 + 0.00000011 * timeT3);
            var anomalyM = givenNortherlyB ? 14.8591 : 1.3951;
            anomalyM = Angles.Mod360(anomalyM + 26.9281592 * givenK - 0.0000355 * timeT2 - 0.00000010 * timeT3);
            var mdash = givenNortherlyB ? 4.6881 : 186.2100;
            mdash = Angles.Mod360(mdash + 356.9562794 * givenK + 0.0103066 * timeT2 + 0.00001251 * timeT3);
            var latitudeF = givenNortherlyB ? 325.8867 : 145.1633;
            latitudeF = Angles.Mod360(latitudeF + 1.4467807 * givenK - 0.0020690 * timeT2 - 0.00000215 * timeT3);
            var eccentricE = 1 - 0.002516 * timeT - 0.0000074 * timeT2;

            //// convert to radians
            angleD = Angles.DegRad(angleD);
            anomalyM = Angles.DegRad(anomalyM);
            mdash = Angles.DegRad(mdash);
            latitudeF = Angles.DegRad(latitudeF);

            double deltaValue;
            if (givenNortherlyB) {
                deltaValue = 5.1093 * Math.Sin(latitudeF) +
                             0.2658 * Math.Cos(2 * latitudeF) +
                             0.1448 * Math.Sin(2 * angleD - latitudeF) +
                             -0.0322 * Math.Sin(3 * latitudeF) +
                             0.0133 * Math.Cos(2 * angleD - 2 * latitudeF) +
                             0.0125 * Math.Cos(2 * angleD) +
                             -0.0124 * Math.Sin(mdash - latitudeF) +
                             -0.0101 * Math.Sin(mdash + 2 * latitudeF) +
                             0.0097 * Math.Cos(latitudeF) +
                             -0.0087 * eccentricE * Math.Sin(2 * angleD + anomalyM - latitudeF) +
                             0.0074 * Math.Sin(mdash + 3 * latitudeF) +
                             0.0067 * Math.Sin(angleD + latitudeF) +
                             0.0063 * Math.Sin(mdash - 2 * latitudeF) +
                             0.0060 * eccentricE * Math.Sin(2 * angleD - anomalyM - latitudeF) +
                             -0.0057 * Math.Sin(2 * angleD - mdash - latitudeF) +
                             -0.0056 * Math.Cos(mdash + latitudeF) +
                             0.0052 * Math.Cos(mdash + 2 * latitudeF) +
                             0.0041 * Math.Cos(2 * mdash + latitudeF) +
                             -0.0040 * Math.Cos(mdash - 3 * latitudeF) +
                             0.0038 * Math.Cos(2 * mdash - latitudeF) +
                             -0.0034 * Math.Cos(mdash - 2 * latitudeF) +
                             -0.0029 * Math.Sin(2 * mdash) +
                             0.0029 * Math.Sin(3 * mdash + latitudeF) +
                             -0.0028 * eccentricE * Math.Cos(2 * angleD + anomalyM - latitudeF) +
                             -0.0028 * Math.Cos(mdash - latitudeF) +
                             -0.0023 * Math.Cos(3 * latitudeF) +
                             -0.0021 * Math.Sin(2 * angleD + latitudeF) +
                             0.0019 * Math.Cos(mdash + 3 * latitudeF) +
                             0.0018 * Math.Cos(angleD + latitudeF) +
                             0.0017 * Math.Sin(2 * mdash - latitudeF) +
                             0.0015 * Math.Cos(3 * mdash + latitudeF) +
                             0.0014 * Math.Cos(2 * angleD + 2 * mdash + latitudeF) +
                             -0.0012 * Math.Sin(2 * angleD - 2 * mdash - latitudeF) +
                             -0.0012 * Math.Cos(2 * mdash) +
                             -0.0010 * Math.Cos(mdash) +
                             -0.0010 * Math.Sin(2 * latitudeF) +
                             0.0006 * Math.Sin(mdash + latitudeF);
            }
            else {
                deltaValue = -5.1093 * Math.Sin(latitudeF) +
                             0.2658 * Math.Cos(2 * latitudeF) +
                             -0.1448 * Math.Sin(2 * angleD - latitudeF) +
                             0.0322 * Math.Sin(3 * latitudeF) +
                             0.0133 * Math.Cos(2 * angleD - 2 * latitudeF) +
                             0.0125 * Math.Cos(2 * angleD) +
                             -0.0015 * Math.Sin(mdash - latitudeF) +
                             0.0101 * Math.Sin(mdash + 2 * latitudeF) +
                             -0.0097 * Math.Cos(latitudeF) +
                             0.0087 * eccentricE * Math.Sin(2 * angleD + anomalyM - latitudeF) +
                             0.0074 * Math.Sin(mdash + 3 * latitudeF) +
                             0.0067 * Math.Sin(angleD + latitudeF) +
                             -0.0063 * Math.Sin(mdash - 2 * latitudeF) +
                             -0.0060 * eccentricE * Math.Sin(2 * angleD - anomalyM - latitudeF) +
                             0.0057 * Math.Sin(2 * angleD - mdash - latitudeF) +
                             -0.0056 * Math.Cos(mdash + latitudeF) +
                             -0.0052 * Math.Cos(mdash + 2 * latitudeF) +
                             -0.0041 * Math.Cos(2 * mdash + latitudeF) +
                             -0.0040 * Math.Cos(mdash - 3 * latitudeF) +
                             -0.0038 * Math.Cos(2 * mdash - latitudeF) +
                             0.0034 * Math.Cos(mdash - 2 * latitudeF) +
                             -0.0029 * Math.Sin(2 * mdash) +
                             0.0029 * Math.Sin(3 * mdash + latitudeF) +
                             0.0028 * eccentricE * Math.Cos(2 * angleD + anomalyM - latitudeF) +
                             -0.0028 * Math.Cos(mdash - latitudeF) +
                             0.0023 * Math.Cos(3 * latitudeF) +
                             0.0021 * Math.Sin(2 * angleD + latitudeF) +
                             0.0019 * Math.Cos(mdash + 3 * latitudeF) +
                             0.0018 * Math.Cos(angleD + latitudeF) +
                             -0.0017 * Math.Sin(2 * mdash - latitudeF) +
                             0.0015 * Math.Cos(3 * mdash + latitudeF) +
                             0.0014 * Math.Cos(2 * angleD + 2 * mdash + latitudeF) +
                             0.0012 * Math.Sin(2 * angleD - 2 * mdash - latitudeF) +
                             -0.0012 * Math.Cos(2 * mdash) +
                             0.0010 * Math.Cos(mdash) +
                             -0.0010 * Math.Sin(2 * latitudeF) +
                             0.0037 * Math.Sin(mdash + latitudeF);
            }

            return MeanGreatestDeclinationValue(givenK) + deltaValue;
        }
    }
}
