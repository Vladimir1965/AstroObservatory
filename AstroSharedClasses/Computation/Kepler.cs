// <copyright file="Kepler.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation
{
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Equation of Kepler - solution.
    /// </summary>
    public static class Kepler {
        /// <summary>
        /// Kepler function.
        /// </summary>
        /// <param name="vm">The element vm.</param>
        /// <param name="keplerE">The kepler E.</param>
        /// <param name="numIterations">The num iterations.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double KeplerFunction(double vm, double keplerE, int numIterations) {
            var uu = vm;
            var edeg = keplerE * AstroMath.Angle180Deg / AstroMath.ConstPi;
            for (var k = 0; k <= numIterations; k++) {
                uu = vm + (edeg * Angles.Sinus(uu));
            }

            return uu;
        }

        /// <summary>
        /// Calculates the specified anomalyM.
        /// </summary>
        /// <param name="anomalyM">The anomalyM.</param>
        /// <param name="e">The e.</param>
        /// <param name="nIterations">The n iterations.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Calculate(double anomalyM, double e, int nIterations = 53) {
            //// Convert from degrees to radians
            anomalyM = Angles.DegRad(anomalyM);
            var pI = Angles.PI();

            double f = anomalyM < 0 ? -1 : 1;

            anomalyM = Math.Abs(anomalyM) / (2 * pI);
            anomalyM = (anomalyM - (int)anomalyM) * 2 * pI * f;
            if (anomalyM < 0) {
                anomalyM += 2 * pI;
            }

            f = anomalyM > pI ? -1 : 1;
            if (anomalyM > pI) {
                anomalyM = 2 * pI - anomalyM;
            }

            var eccentricE = pI / 2;
            var scale = pI / 4;
            for (var i = 0; i < nIterations; i++) {
                var r = eccentricE - e * Math.Sin(eccentricE);
                eccentricE = anomalyM > r ? eccentricE + scale : eccentricE - scale;
                scale /= 2;
            }

            //// Convert the result back to degrees
            return Angles.RadDeg(eccentricE) * f;
        }
    }
}
