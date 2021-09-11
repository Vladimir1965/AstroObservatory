// <copyright file="MoonNodes.cs" company="Traced-Ideas, Czech republic">
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
    /// Moon Nodes.
    /// </summary>
    [UsedImplicitly]
    public static class MoonNodes {
        /// <summary>
        /// Ks the specified year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double K(double year) {
            return 13.4223 * (year - 2000.05);
        }

        /// <summary>
        /// Passages the through node.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double PassageThroughNode(double givenK) {
            //// convert from K to T
            var timeT = givenK / 1342.23;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;
            var dT4 = timeCubed * timeT;

            var elongD = Angles.Mod360(183.6380 + 331.73735682 * givenK + 0.0014852 * timeSquared + 0.00000209 * timeCubed - 0.000000010 * dT4);
            var anomalyM = Angles.Mod360(17.4006 + 26.82037250 * givenK + 0.0001186 * timeSquared + 0.00000006 * timeCubed);
            var mdash = Angles.Mod360(38.3776 + 355.52747313 * givenK + 0.0123499 * timeSquared + 0.000014627 * timeCubed - 0.000000069 * dT4);
            var omega = Angles.Mod360(123.9767 - 1.44098956 * givenK + 0.0020608 * timeSquared + 0.00000214 * timeCubed - 0.000000016 * dT4);
            var v = Angles.Mod360(299.75 + 132.85 * timeT - 0.009173 * timeSquared);
            var angleP = Angles.Mod360(omega + 272.75 - 2.3 * timeT);
            var eccentricE = 1 - 0.002516 * timeT - 0.0000074 * timeSquared;

            //// convert to radians
            elongD = Angles.DegRad(elongD);
            var d2 = 2 * elongD;
            var d4 = d2 * d2;
            anomalyM = Angles.DegRad(anomalyM);
            mdash = Angles.DegRad(mdash);
            var mdash2 = 2 * mdash;
            omega = Angles.DegRad(omega);
            v = Angles.DegRad(v);
            angleP = Angles.DegRad(angleP);

            var julianDay = 2451565.1619 + 27.212220817 * givenK
                        + 0.0002762 * timeSquared
                        + 0.000000021 * timeCubed
                        - 0.000000000088 * dT4
                        - 0.4721 * Math.Sin(mdash)
                        - 0.1649 * Math.Sin(d2)
                        - 0.0868 * Math.Sin(d2 - mdash)
                        + 0.0084 * Math.Sin(d2 + mdash)
                        - eccentricE * 0.0083 * Math.Sin(d2 - anomalyM)
                        - eccentricE * 0.0039 * Math.Sin(d2 - anomalyM - mdash)
                        + 0.0034 * Math.Sin(mdash2)
                        - 0.0031 * Math.Sin(d2 - mdash2)
                        + eccentricE * 0.0030 * Math.Sin(d2 + anomalyM)
                        + eccentricE * 0.0028 * Math.Sin(anomalyM - mdash)
                        + eccentricE * 0.0026 * Math.Sin(anomalyM)
                        + 0.0025 * Math.Sin(d4)
                        + 0.0024 * Math.Sin(elongD)
                        + eccentricE * 0.0022 * Math.Sin(anomalyM + mdash)
                        + 0.0017 * Math.Sin(omega)
                        + 0.0014 * Math.Sin(d4 - mdash)
                        + eccentricE * 0.0005 * Math.Sin(d2 + anomalyM - mdash)
                        + eccentricE * 0.0004 * Math.Sin(d2 - anomalyM + mdash)
                        - eccentricE * 0.0003 * Math.Sin(d2 - anomalyM * anomalyM)
                        + eccentricE * 0.0003 * Math.Sin(d4 - anomalyM)
                        + 0.0003 * Math.Sin(v)
                        + 0.0003 * Math.Sin(angleP);

            return julianDay;
        }
    }
}
