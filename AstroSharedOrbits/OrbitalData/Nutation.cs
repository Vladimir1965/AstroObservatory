// <copyright file="Nutation.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.OrbitalData
{
    using System;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Coordinates;
    using JetBrains.Annotations;

    /// <summary>
    /// Support for Nutation.
    /// </summary>
    [UsedImplicitly]
    public sealed class Nutation {
        /// <summary>
        /// Initializes a new instance of the <see cref="Nutation" /> class.
        /// </summary>
        public Nutation() {
        }

        #region Naughter
        /// <summary>
        /// Nutation the in longitude.
        /// </summary>
        /// <param name="julianDay">The given julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double NutationInLongitude(double julianDay) {
            var julianCentury = (julianDay - 2451545) / 36525;
            var timeSquared = julianCentury * julianCentury;
            var timeCubed = timeSquared * julianCentury;

            var elongD = 297.85036 + 445267.111480 * julianCentury - 0.0019142 * timeSquared + timeCubed / 189474;
            elongD = Angles.Mod360(elongD);

            var anomalyM = 357.52772 + 35999.050340 * julianCentury - 0.0001603 * timeSquared - timeCubed / 300000;
            anomalyM = Angles.Mod360(anomalyM);

            var anomalyMprime = 134.96298 + 477198.867398 * julianCentury + 0.0086972 * timeSquared + timeCubed / 56250;
            anomalyMprime = Angles.Mod360(anomalyMprime);

            var latitudeF = 93.27191 + 483202.017538 * julianCentury - 0.0036825 * timeSquared + timeCubed / 327270;
            latitudeF = Angles.Mod360(latitudeF);

            var omega = 125.04452 - 1934.136261 * julianCentury + 0.0020708 * timeSquared + timeCubed / 450000;
            omega = Angles.Mod360(omega);

            var nCoefficients = OrbitalData.NutationQuotients.NutationCoefficients.Length;
            double value = 0;
            for (var i = 0; i < nCoefficients; i++) {
                var argument = OrbitalData.NutationQuotients.NutationCoefficients[i].D * elongD + OrbitalData.NutationQuotients.NutationCoefficients[i].M * anomalyM +
                                OrbitalData.NutationQuotients.NutationCoefficients[i].Mprime * anomalyMprime + OrbitalData.NutationQuotients.NutationCoefficients[i].LatitudeF * latitudeF +
                                OrbitalData.NutationQuotients.NutationCoefficients[i].Omega * omega;
                var radargument = Angles.DegRad(argument);
                value += (OrbitalData.NutationQuotients.NutationCoefficients[i].Sincoeff1 + OrbitalData.NutationQuotients.NutationCoefficients[i].Sincoeff2 * julianCentury) * Math.Sin(radargument) * 0.0001;
            }

            return value;
        }

        /// <summary>
        /// Nutation the in obliquity.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double NutationInObliquity(double julianDay) {
            var julianCentury = (julianDay - 2451545) / 36525;
            var timeSquared = julianCentury * julianCentury;
            var timeCubed = timeSquared * julianCentury;

            var elongD = 297.85036 + 445267.111480 * julianCentury - 0.0019142 * timeSquared + timeCubed / 189474;
            elongD = Angles.Mod360(elongD);

            var anomalyM = 357.52772 + 35999.050340 * julianCentury - 0.0001603 * timeSquared - timeCubed / 300000;
            anomalyM = Angles.Mod360(anomalyM);

            var mprime = 134.96298 + 477198.867398 * julianCentury + 0.0086972 * timeSquared + timeCubed / 56250;
            mprime = Angles.Mod360(mprime);

            var latitudeF = 93.27191 + 483202.017538 * julianCentury - 0.0036825 * timeSquared + timeCubed / 327270;
            latitudeF = Angles.Mod360(latitudeF);

            var omega = 125.04452 - 1934.136261 * julianCentury + 0.0020708 * timeSquared + timeCubed / 450000;
            omega = Angles.Mod360(omega);

            var nCoefficients = OrbitalData.NutationQuotients.NutationCoefficients.Length;
            double value = 0;
            for (var i = 0; i < nCoefficients; i++) {
                var argument = OrbitalData.NutationQuotients.NutationCoefficients[i].D * elongD + OrbitalData.NutationQuotients.NutationCoefficients[i].M * anomalyM +
                                OrbitalData.NutationQuotients.NutationCoefficients[i].Mprime * mprime + OrbitalData.NutationQuotients.NutationCoefficients[i].LatitudeF * latitudeF +
                                OrbitalData.NutationQuotients.NutationCoefficients[i].Omega * omega;
                var radargument = Angles.DegRad(argument);
                value += (OrbitalData.NutationQuotients.NutationCoefficients[i].Coscoeff1 + OrbitalData.NutationQuotients.NutationCoefficients[i].Coscoeff2 * julianCentury) * Math.Cos(radargument) * 0.0001;
            }

            return value;
        }

        /// <summary>
        /// Means the obliquity of ecliptic.
        /// </summary>
        /// <param name="julianDay">The given julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double MeanObliquityOfEcliptic(double julianDay) {
            var u = (julianDay - 2451545) / 3652500;
            var usquared = u * u;
            var ucubed = usquared * u;
            var u4 = ucubed * u;
            var u5 = u4 * u;
            var u6 = u5 * u;
            var u7 = u6 * u;
            var u8 = u7 * u;
            var u9 = u8 * u;
            var u10 = u9 * u;

            return CoordinateTransformation.DmsToDegrees(23, 26, 21.448) - CoordinateTransformation.DmsToDegrees(0, 0, 4680.93) * u
                                                                            - CoordinateTransformation.DmsToDegrees(0, 0, 1.55) * usquared
                                                                            + CoordinateTransformation.DmsToDegrees(0, 0, 1999.25) * ucubed
                                                                            - CoordinateTransformation.DmsToDegrees(0, 0, 51.38) * u4
                                                                            - CoordinateTransformation.DmsToDegrees(0, 0, 249.67) * u5
                                                                            - CoordinateTransformation.DmsToDegrees(0, 0, 39.05) * u6
                                                                            + CoordinateTransformation.DmsToDegrees(0, 0, 7.12) * u7
                                                                            + CoordinateTransformation.DmsToDegrees(0, 0, 27.87) * u8
                                                                            + CoordinateTransformation.DmsToDegrees(0, 0, 5.79) * u9
                                                                            + CoordinateTransformation.DmsToDegrees(0, 0, 2.45) * u10;
        }

        /// <summary>
        /// Trues the obliquity of ecliptic.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double TrueObliquityOfEcliptic(double julianDay) {
            return MeanObliquityOfEcliptic(julianDay) + CoordinateTransformation.DmsToDegrees(0, 0, NutationInObliquity(julianDay));
        }

        /// <summary>
        /// Nutation the in right ascension.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="obliquity">The obliquity.</param>
        /// <param name="nutationInLongitude">The nutation in longitude.</param>
        /// <param name="nutationInObliquity">The nutation in obliquity.</param>
        /// <returns> Returns value. </returns>
        public static double NutationInRightAscension(double alpha, double delta, double obliquity, double nutationInLongitude, double nutationInObliquity) {
            //// Convert to radians
            alpha = Angles.HoursToRadians(alpha);
            delta = Angles.DegRad(delta);
            obliquity = Angles.DegRad(obliquity);

            return (Math.Cos(obliquity) + Math.Sin(obliquity) * Math.Sin(alpha) * Math.Tan(delta)) * nutationInLongitude - Math.Cos(alpha) * Math.Tan(delta) * nutationInObliquity;
        }

        /// <summary>
        /// Nutation the in declination.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="obliquity">The obliquity.</param>
        /// <param name="nutationInLongitude">The nutation in longitude.</param>
        /// <param name="nutationInObliquity">The nutation in obliquity.</param>
        /// <returns> Returns value. </returns>
        public static double NutationInDeclination(double alpha, double obliquity, double nutationInLongitude, double nutationInObliquity) {
            //// Convert to radians
            alpha = Angles.HoursToRadians(alpha);
            //// Delta = Angles.DegRad(Delta);
            obliquity = Angles.DegRad(obliquity);

            return Math.Sin(obliquity) * Math.Cos(alpha) * nutationInLongitude + Math.Sin(alpha) * nutationInObliquity;
        }

        #endregion

        #region AstroAlgo
        /// <summary>Computes the mean and true obliquity of the ecliptic.</summary>
        /// <param name="julianCentury">Julian Centuries.</param>
        /// <param name="epsilon">True obliquity of the ecliptic in degrees.</param>
        /// <param name="epsilonNull">Mean obliquity of the ecliptic in arc seconds.</param>
        public static void Obliquity(double julianCentury, out double epsilon, out double epsilonNull) {
            double deltaPsi;           //// nutation of longitude in arc seconds 

            ////  calculate mean obliquity of the ecliptic in arc seconds, 21.2
            epsilonNull = ((23 * 60) + 26) * 60 + 21.448 - 46.8150 * julianCentury - 0.00059 * julianCentury * julianCentury + 0.001813 * julianCentury * julianCentury * julianCentury;
            ////  convert back to degrees
            epsilonNull /= 3600;

            ////  calculate nutation of obliquity
            NutationOfLongitudeAndObliquity(julianCentury, out deltaPsi, out var deltaEpsilon);

            ////  calculate true obliquity of the ecliptic
            epsilon = epsilonNull + deltaEpsilon / 3600;
        }

        /// <summary>Computes the nutation of longitude and nutation of obliquity of the ecliptic.</summary>
        /// <param name="julianCentury">Julian Centuries.</param>
        /// <param name="deltaPsi">Nutation of longitude in arc seconds.</param>
        /// <param name="deltaEpsilon">Nutation of obliquity in arc seconds.</param>
        public static void NutationOfLongitudeAndObliquity(double julianCentury, out double deltaPsi, out double deltaEpsilon) {
            ////  calculate the five local variables described on pg. 132
            //// longitude of the ascending node of the moon's mean orbit
            //// double elongD = 297.85036 + 445267.111480 * T - 0.0019142 * T * T + (T * T * T) / 189474;

            //// mean anomaly of the Sun (Earth) 
            //// double m = 357.52772 + 35999.050340 * T - 0.0001603 * T * T - (T * T * T) / 300000;

            //// mean anomaly of the moon
            //// double mprime = 134.96298 + 477198.867398 * T + 0.0086972 * T * T + (T * T * T) / 56250;

            //// moon's argument of latitude
            //// double LatitudeF = 93.27191 + 483202.017538 * T - 0.0036825 * T * T + (T * T * T) / 327270;

            ////  calculate mean longitudes
            //// Mean longitude of the sun
            var longL = 280.4665 + 36000.7698 * julianCentury;
            //// Mean longitude of the moon
            var longLprime = 218.3165 + 481267.8813 * julianCentury;

            ////  only need omega for simplified calculation
            //// longitude of the ascending node of the moon's mean orbit
            //// double omega;  = 125.04452 - 1934.136261 * T + 0.0020708 * T * T + (T * T * T) / 450000; 
            var omega = 125.04452 - 1934.136261 * julianCentury;

            ////  calculate nutation of longitude in arc seconds
            deltaPsi = -17.20 * Math.Sin(omega * Angles.Deg2Radian) - 1.32 * Math.Sin(2 * longL * Angles.Deg2Radian)
                - 0.23 * Math.Sin(2 * longLprime * Angles.Deg2Radian) + 0.21 * Math.Sin(2 * omega * Angles.Deg2Radian);
            deltaEpsilon = 9.20 * Math.Cos(omega * Angles.Deg2Radian) + 0.57 * Math.Cos(2 * longL * Angles.Deg2Radian)
                + 0.10 * Math.Cos(2 * longLprime * Angles.Deg2Radian) - 0.09 * Math.Cos(2 * omega * Angles.Deg2Radian);

            ////  coefficients are in units of 0".0001 so convert
            //// deltaPsi *= 0.0001;                  
            //// deltaEpsilon *= 0.0001;
        }        
        #endregion
    }
}
