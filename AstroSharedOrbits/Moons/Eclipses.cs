// <copyright file="Eclipses.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Moons {
    using System;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Records;
    using JetBrains.Annotations;

    /// <summary>
    /// Eclipses object.
    /// </summary>
    [UsedImplicitly]
    public static class Eclipses {
        /// <summary>
        /// Calculates the solar.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static SolarEclipseDetails CalculateSolar(double givenK) {
            //// #if DEBUG   double intp = 0;   bool bSolarEclipse = (MathExtra.Mod(givenK, out intp) == 0);
            //// Debug.Assert(bSolarEclipse);  #endif 
            double mdash;
            return Calculate(givenK, out mdash);
        }

        /// <summary>
        /// Calculates the lunar.
        /// </summary>
        /// <param name="givenK">The given k.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static LunarEclipseDetails CalculateLunar(double givenK) {
            //// #if DEBUG    double intp = 0;  bool bSolarEclipse = (MathExtra.Mod(givenK, out intp) == 0);
            //// Debug.Assert(!bSolarEclipse);  #endif 
            var solarDetails = Calculate(givenK, out var mdash);

            //// What will be the return value
            var details = new LunarEclipseDetails {
                BEclipse = solarDetails.BEclipse,
                LatitudeF = solarDetails.LatitudeF,
                Gamma = solarDetails.Gamma,
                TimeOfMaximumEclipse = solarDetails.TimeOfMaximumEclipse,
                U = solarDetails.U
            };

            if (!details.BEclipse) {
                return details;
            }

            details.PenumbralRadii = 1.2848 + details.U;
            details.UmbralRadii = 0.7403 - details.U;
            var fgamma = Math.Abs(details.Gamma);
            details.PenumbralMagnitude = (1.5573 + details.U - fgamma) / 0.5450;
            details.UmbralMagnitude = (1.0128 - details.U - fgamma) / 0.5450;

            var p = 1.0128 - details.U;
            var t = 0.4678 - details.U;
            var n = 0.5458 + 0.0400 * Math.Cos(mdash);

            var gamma2 = details.Gamma * details.Gamma;
            var p2 = p * p;
            if (p2 >= gamma2) {
                details.PartialPhaseSemiDuration = 60 / n * Math.Sqrt(p2 - gamma2);
            }

            var t2 = t * t;
            if (t2 >= gamma2) {
                details.TotalPhaseSemiDuration = 60 / n * Math.Sqrt(t2 - gamma2);
            }

            var h = 1.5573 + details.U;
            var h2 = h * h;
            if (h2 >= gamma2) {
                details.PartialPhasePenumbraSemiDuration = 60 / n * Math.Sqrt(h2 - gamma2);
            }

            return details;
        }

        /// <summary>
        /// Calculates the specified givenK.
        /// </summary>
        /// <param name="givenK">The given k.</param>
        /// <param name="mdash">The mdash.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        internal static SolarEclipseDetails Calculate(double givenK, out double mdash) {
            //// Are we looking for a solar or lunar eclipse
            double intp;
            const double tolerance = 0.00001;
            var bSolarEclipse = Math.Abs(AstroMath.Mod(givenK, out intp)) < tolerance;

            //// What will be the return value
            var details = new SolarEclipseDetails();

            //// convert from K to T
            var timeT = givenK / 1236.85;
            var timeT2 = timeT * timeT;
            var timeT3 = timeT2 * timeT;
            var dT4 = timeT3 * timeT;

            var eccentricE = 1 - 0.002516 * timeT - 0.0000074 * timeT2;

            var anomalyM = Angles.Mod360(2.5534 + 29.10535670 * givenK - 0.0000014 * timeT2 - 0.00000011 * timeT3);
            anomalyM = Angles.DegRad(anomalyM);

            mdash = Angles.Mod360(201.5643 + 385.81693528 * givenK + 0.0107582 * timeT2 + 0.00001238 * timeT3 - 0.000000058 * dT4);
            mdash = Angles.DegRad(mdash);

            var omega = Angles.Mod360(124.7746 - 1.56375588 * givenK + 0.0020672 * timeT2 + 0.00000215 * timeT3);
            omega = Angles.DegRad(omega);

            var latitudeF = Angles.Mod360(160.7108 + 390.67050284 * givenK - 0.0016118 * timeT2 - 0.00000227 * timeT3 + 0.00000001 * dT4);
            details.LatitudeF = latitudeF;
            var fdash = latitudeF - 0.02665 * Math.Sin(omega);

            latitudeF = Angles.DegRad(latitudeF);
            fdash = Angles.DegRad(fdash);

            //// Do the first check to see if we have an eclipse
            if (Math.Abs(Math.Sin(latitudeF)) > 0.36) {
                return details;
            }

            var a1 = Angles.Mod360(299.77 + 0.107408 * givenK - 0.009173 * timeT2);
            a1 = Angles.DegRad(a1);

            details.TimeOfMaximumEclipse = MoonPhases.MeanPhase(givenK);

            double deltaJulianDay = 0;
            deltaJulianDay += bSolarEclipse ?
                  -0.4075 * Math.Sin(mdash) + 0.1721 * eccentricE * Math.Sin(anomalyM)
                : -0.4065 * Math.Sin(mdash) + 0.1727 * eccentricE * Math.Sin(anomalyM);

            deltaJulianDay += 0.0161 * Math.Sin(2 * mdash) +
                       -0.0097 * Math.Sin(2 * fdash) +
                       0.0073 * eccentricE * Math.Sin(mdash - anomalyM) +
                       -0.0050 * eccentricE * Math.Sin(mdash + anomalyM) +
                       -0.0023 * Math.Sin(mdash - 2 * fdash) +
                       0.0021 * eccentricE * Math.Sin(2 * anomalyM) +
                       0.0012 * Math.Sin(mdash + 2 * fdash) +
                       0.0006 * eccentricE * Math.Sin(2 * mdash + anomalyM) +
                       -0.0004 * Math.Sin(3 * mdash) +
                       -0.0003 * eccentricE * Math.Sin(anomalyM + 2 * fdash) +
                       0.0003 * Math.Sin(a1) +
                       -0.0002 * eccentricE * Math.Sin(anomalyM - 2 * fdash) +
                       -0.0002 * eccentricE * Math.Sin(2 * mdash - anomalyM) +
                       -0.0002 * Math.Sin(omega);

            details.TimeOfMaximumEclipse += deltaJulianDay;

            var p = 0.2070 * eccentricE * Math.Sin(anomalyM) +
                       0.0024 * eccentricE * Math.Sin(2 * anomalyM) +
                       -0.0392 * Math.Sin(mdash) +
                       0.0116 * Math.Sin(2 * mdash) +
                       -0.0073 * eccentricE * Math.Sin(mdash + anomalyM) +
                       0.0067 * eccentricE * Math.Sin(mdash - anomalyM) +
                       0.0118 * Math.Sin(2 * fdash);

            var q = 5.2207 +
                       -0.0048 * eccentricE * Math.Cos(anomalyM) +
                       0.0020 * eccentricE * Math.Cos(2 * anomalyM) +
                       -0.3299 * Math.Cos(mdash) +
                       -0.0060 * eccentricE * Math.Cos(mdash + anomalyM) +
                       0.0041 * eccentricE * Math.Cos(mdash - anomalyM);

            var w = Math.Abs(Math.Cos(fdash));

            details.Gamma = (p * Math.Cos(fdash) + q * Math.Sin(fdash)) * (1 - 0.0048 * w);

            details.U = 0.0059 +
                       0.0046 * eccentricE * Math.Cos(anomalyM) +
                       -0.0182 * Math.Cos(mdash) +
                       0.0004 * Math.Cos(2 * mdash) +
                       -0.0005 * Math.Cos(anomalyM + mdash);

            //// Check to see if the eclipse is visible from the Earth's surface
            if (Math.Abs(details.Gamma) > (1.5433 + details.U)) {
                return details;
            }

            //// We have an eclipse at this time
            details.BEclipse = true;

            //// In the case of a partial eclipse, calculate its magnitude
            var fgamma = Math.Abs(details.Gamma);
            if ((fgamma > 0.9972) && (fgamma < 1.5433 + details.U)) {
                details.GreatestMagnitude = (1.5433 + details.U - fgamma) / (0.5461 + 2 * details.U);
            }

            return details;
        }
    }
}
