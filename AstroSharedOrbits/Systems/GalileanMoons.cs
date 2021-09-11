// <copyright file="GalileanMoons.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Systems
{
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedOrbits.OrbitalData;
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Galilean Moons.
    /// </summary>
    [UsedImplicitly]
    public static class GalileanMoons
    {
        /// <summary>
        /// Calculates the specified julianDay.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static GalileanMoonsDetails Calculate(double julianDay)
        {
            //// Calculate the position of the Sun
            var sunlong = BodySun.GeometricEclipticLongitude(julianDay);
            var sunlongrad = Angles.DegRad(sunlong);
            var beta = BodySun.GeometricEclipticLatitude(julianDay);
            var betaRad = Angles.DegRad(beta);
            var radiusR = Planets.BodyEarth.RadiusVector(julianDay);

            //// Calculate the the light travel time from Jupiter to the Earth
            double delta = 5;
            double previousEarthLightTravelTime = 0;
            var earthLightTravelTime = Elliptical.DistanceToLightTime(delta);
            var julianDay1 = julianDay - earthLightTravelTime;
            var bIterate = true;
            double x;
            double y;
            double z;
            while (bIterate)
            {
                //// Calculate the position of Jupiter
                var l = Planets.BodyJupiter.EclipticLongitude(julianDay1);
                var longitudeRadian = Angles.DegRad(l);
                var b = Planets.BodyJupiter.EclipticLatitude(julianDay1);
                var latitudeRadian = Angles.DegRad(b);
                var r = Planets.BodyJupiter.RadiusVector(julianDay1);

                x = r * Math.Cos(latitudeRadian) * Math.Cos(longitudeRadian) + radiusR * Math.Cos(sunlongrad);
                y = r * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian) + radiusR * Math.Sin(sunlongrad);
                z = r * Math.Sin(latitudeRadian) + radiusR * Math.Sin(betaRad);
                delta = Math.Sqrt(x * x + y * y + z * z);
                earthLightTravelTime = Elliptical.DistanceToLightTime(delta);

                //// Prepare for the next loop around
                bIterate = Math.Abs(earthLightTravelTime - previousEarthLightTravelTime) > 2E-6;
                //// 2E-6 corresponds to 0.17 of a second
                if (!bIterate)
                {
                    continue;
                }

                julianDay1 = julianDay - earthLightTravelTime;
                previousEarthLightTravelTime = earthLightTravelTime;
            }

            //// Calculate the details as seen from the earth
            var details1 = CalculateHelper(julianDay, sunlongrad, betaRad, radiusR);
            FillInPhenomenaDetails(details1.Satellite1);
            FillInPhenomenaDetails(details1.Satellite2);
            FillInPhenomenaDetails(details1.Satellite3);
            FillInPhenomenaDetails(details1.Satellite4);
            {
                //// Calculate the the light travel time from Jupiter to the Sun
                julianDay1 = julianDay - earthLightTravelTime;
                var l = Planets.BodyJupiter.EclipticLongitude(julianDay1);
                var longitudeRadian = Angles.DegRad(l);
                var b = Planets.BodyJupiter.EclipticLatitude(julianDay1);
                var latitudeRadian = Angles.DegRad(b);
                var r = Planets.BodyJupiter.RadiusVector(julianDay1);
                x = r * Math.Cos(latitudeRadian) * Math.Cos(longitudeRadian);
                y = r * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian);
                z = r * Math.Sin(latitudeRadian);
                delta = Math.Sqrt(x * x + y * y + z * z);
                var sunLightTravelTime = Elliptical.DistanceToLightTime(delta);

                //// Calculate the details as seen from the Sun
                var details2 = CalculateHelper(julianDay + sunLightTravelTime - earthLightTravelTime, sunlongrad, betaRad, 0);

                FillInPhenomenaDetails(details2.Satellite1);
                FillInPhenomenaDetails(details2.Satellite2);
                FillInPhenomenaDetails(details2.Satellite3);
                FillInPhenomenaDetails(details2.Satellite4);

                //// Finally transfer the required values from details2 to details1
                details1.Satellite1.BInEclipse = details2.Satellite1.BInOccultation;
                details1.Satellite2.BInEclipse = details2.Satellite2.BInOccultation;
                details1.Satellite3.BInEclipse = details2.Satellite3.BInOccultation;
                details1.Satellite4.BInEclipse = details2.Satellite4.BInOccultation;
                details1.Satellite1.BInShadowTransit = details2.Satellite1.BInTransit;
                details1.Satellite2.BInShadowTransit = details2.Satellite2.BInTransit;
                details1.Satellite3.BInShadowTransit = details2.Satellite3.BInTransit;
                details1.Satellite4.BInShadowTransit = details2.Satellite4.BInTransit;
            }

            return details1;
        }

        /// <summary>
        /// Calculates the helper.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="sunlongrad">The sunlongrad.</param>
        /// <param name="betaRad">The betaRad.</param>
        /// <param name="radiusR">The R.</param>
        /// <returns> Returns value. </returns>
        private static GalileanMoonsDetails CalculateHelper(double julianDay, double sunlongrad, double betaRad, double radiusR) {
            //// What will be the return value
            var details = new GalileanMoonsDetails();

            //// Calculate the position of Jupiter decreased by the light travel time from Jupiter to the specified position
            double delta = 5;
            double previousLightTravelTime = 0;
            var lightTravelTime = Elliptical.DistanceToLightTime(delta);
            double x = 0;
            double y = 0;
            var julianDay1 = julianDay - lightTravelTime;
            var bIterate = true;
            while (bIterate) {
                //// Calculate the position of Jupiter
                var l = Planets.BodyJupiter.EclipticLongitude(julianDay1);
                var longitudeRadian = Angles.DegRad(l);
                var b = Planets.BodyJupiter.EclipticLatitude(julianDay1);
                var latitudeRadian = Angles.DegRad(b);
                var r = Planets.BodyJupiter.RadiusVector(julianDay1);

                x = r * Math.Cos(latitudeRadian) * Math.Cos(longitudeRadian) + radiusR * Math.Cos(sunlongrad);
                y = r * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian) + radiusR * Math.Sin(sunlongrad);
                var z = r * Math.Sin(latitudeRadian) + radiusR * Math.Sin(betaRad);
                delta = Math.Sqrt(x * x + y * y + z * z);
                lightTravelTime = Elliptical.DistanceToLightTime(delta);

                //// Prepare for the next loop around
                bIterate = Math.Abs(lightTravelTime - previousLightTravelTime) > 2E-6; //// 2E-6 corresponds to 0.17 of a second
                if (!bIterate) {
                    continue;
                }

                julianDay1 = julianDay - lightTravelTime;
                previousLightTravelTime = lightTravelTime;
            }

            //// Calculate Jupiter's Longitude and Latitude
            var lambda0 = Math.Atan2(y, x);
            //// unused?!? var beta0 = Math.Atan(z / Math.Sqrt(x * x + y * y));

            var t = julianDay - 2443000.5 - lightTravelTime;

            //// Calculate the mean longitudes 
            var l1 = 106.07719 + 203.488955790 * t;
            var l1rad = Angles.DegRad(l1);
            var l2 = 175.73161 + 101.374724735 * t;
            var l2rad = Angles.DegRad(l2);
            var l3 = 120.55883 + 50.317609207 * t;
            var l3rad = Angles.DegRad(l3);
            var l4 = 84.44459 + 21.571071177 * t;
            var l4rad = Angles.DegRad(l4);

            //// Calculate the perijoves
            var pi1 = Angles.DegRad(Angles.Mod360(97.0881 + 0.16138586 * t));
            var pi2 = Angles.DegRad(Angles.Mod360(154.8663 + 0.04726307 * t));
            var pi3 = Angles.DegRad(Angles.Mod360(188.1840 + 0.00712734 * t));
            var pi4 = Angles.DegRad(Angles.Mod360(335.2868 + 0.00184000 * t));

            //// Calculate the nodes on the equatorial plane of jupiter
            var w1 = 312.3346 - 0.13279386 * t;
            var w1rad = Angles.DegRad(w1);
            var w2 = 100.4411 - 0.03263064 * t;
            var w2rad = Angles.DegRad(w2);
            var w3 = 119.1942 - 0.00717703 * t;
            var w3rad = Angles.DegRad(w3);
            var w4 = 322.6186 - 0.00175934 * t;
            var w4rad = Angles.DegRad(w4);

            //// Calculate the Principal inequality in the longitude of Jupiter
            var gamma = 0.33033 * Math.Sin(Angles.DegRad(163.679 + 0.0010512 * t)) +
                           0.03439 * Math.Sin(Angles.DegRad(34.486 - 0.0161731 * t));

            //// Calculate the "phase of free libration"
            var philambda = Angles.DegRad(199.6766 + 0.17379190 * t);

            //// Calculate the longitude of the node of the equator of Jupiter on the ecliptic
            var psi = Angles.DegRad(316.5182 - 0.00000208 * t);

            //// Calculate the mean anomalies of Jupiter and Saturn
            var g = Angles.DegRad(30.23756 + 0.0830925701 * t + gamma);
            var gdash = Angles.DegRad(31.97853 + 0.0334597339 * t);

            //// Calculate the longitude of the perihelion of Jupiter
            var PI = Angles.DegRad(13.469942);

            //// Calculate the periodic terms in the longitudes of the satellites
            var sigma1 = 0.47259 * Math.Sin(2 * (l1rad - l2rad)) +
                            -0.03478 * Math.Sin(pi3 - pi4) +
                            0.01081 * Math.Sin(l2rad - 2 * l3rad + pi3) +
                            0.00738 * Math.Sin(philambda) +
                            0.00713 * Math.Sin(l2rad - 2 * l3rad + pi2) +
                            -0.00674 * Math.Sin(pi1 + pi3 - 2 * PI - 2 * g) +
                            0.00666 * Math.Sin(l2rad - 2 * l3rad + pi4) +
                            0.00445 * Math.Sin(l1rad - pi3) +
                            -0.00354 * Math.Sin(l1rad - l2rad) +
                            -0.00317 * Math.Sin(2 * psi - 2 * PI) +
                            0.00265 * Math.Sin(l1rad - pi4) +
                            -0.00186 * Math.Sin(g) +
                            0.00162 * Math.Sin(pi2 - pi3) +
                            0.00158 * Math.Sin(4 * (l1rad - l2rad)) +
                            -0.00155 * Math.Sin(l1rad - l3rad) +
                            -0.00138 * Math.Sin(psi + w3rad - 2 * PI - 2 * g) +
                            -0.00115 * Math.Sin(2 * (l1rad - 2 * l2rad + w2rad)) +
                            0.00089 * Math.Sin(pi2 - pi4) +
                            0.00085 * Math.Sin(l1rad + pi3 - 2 * PI - 2 * g) +
                            0.00083 * Math.Sin(w2rad - w3rad) +
                            0.00053 * Math.Sin(psi - w2rad);

            var sigma2 = 1.06476 * Math.Sin(2 * (l2rad - l3rad)) +
                            0.04256 * Math.Sin(l1rad - 2 * l2rad + pi3) +
                            0.03581 * Math.Sin(l2rad - pi3) +
                            0.02395 * Math.Sin(l1rad - 2 * l2rad + pi4) +
                            0.01984 * Math.Sin(l2rad - pi4) +
                            -0.01778 * Math.Sin(philambda) +
                            0.01654 * Math.Sin(l2rad - pi2) +
                            0.01334 * Math.Sin(l2rad - 2 * l3rad + pi2) +
                            0.01294 * Math.Sin(pi3 - pi4) +
                            -0.01142 * Math.Sin(l2rad - l3rad) +
                            -0.01057 * Math.Sin(g) +
                            -0.00775 * Math.Sin(2 * (psi - PI)) +
                            0.00524 * Math.Sin(2 * (l1rad - l2rad)) +
                            -0.00460 * Math.Sin(l1rad - l3rad) +
                            0.00316 * Math.Sin(psi - 2 * g + w3rad - 2 * PI) +
                            -0.00203 * Math.Sin(pi1 + pi3 - 2 * PI - 2 * g) +
                            0.00146 * Math.Sin(psi - w3rad) +
                            -0.00145 * Math.Sin(2 * g) +
                            0.00125 * Math.Sin(psi - w4rad) +
                            -0.00115 * Math.Sin(l1rad - 2 * l3rad + pi3) +
                            -0.00094 * Math.Sin(2 * (l2rad - w2rad)) +
                            0.00086 * Math.Sin(2 * (l1rad - 2 * l2rad + w2rad)) +
                            -0.00086 * Math.Sin(5 * gdash - 2 * g + Angles.DegRad(52.225)) +
                            -0.00078 * Math.Sin(l2rad - l4rad) +
                            -0.00064 * Math.Sin(3 * l3rad - 7 * l4rad + 4 * pi4) +
                            0.00064 * Math.Sin(pi1 - pi4) +
                            -0.00063 * Math.Sin(l1rad - 2 * l3rad + pi4) +
                            0.00058 * Math.Sin(w3rad - w4rad) +
                            0.00056 * Math.Sin(2 * (psi - PI - g)) +
                            0.00056 * Math.Sin(2 * (l2rad - l4rad)) +
                            0.00055 * Math.Sin(2 * (l1rad - l3rad)) +
                            0.00052 * Math.Sin(3 * l3rad - 7 * l4rad + pi3 + 3 * pi4) +
                            -0.00043 * Math.Sin(l1rad - pi3) +
                            0.00041 * Math.Sin(5 * (l2rad - l3rad)) +
                            0.00041 * Math.Sin(pi4 - PI) +
                            0.00032 * Math.Sin(w2rad - w3rad) +
                            0.00032 * Math.Sin(2 * (l3rad - g - PI));

            var sigma3 = 0.16490 * Math.Sin(l3rad - pi3) +
                            0.09081 * Math.Sin(l3rad - pi4) +
                            -0.06907 * Math.Sin(l2rad - l3rad) +
                            0.03784 * Math.Sin(pi3 - pi4) +
                            0.01846 * Math.Sin(2 * (l3rad - l4rad)) +
                            -0.01340 * Math.Sin(g) +
                            -0.01014 * Math.Sin(2 * (psi - PI)) +
                            0.00704 * Math.Sin(l2rad - 2 * l3rad + pi3) +
                            -0.00620 * Math.Sin(l2rad - 2 * l3rad + pi2) +
                            -0.00541 * Math.Sin(l3rad - l4rad) +
                            0.00381 * Math.Sin(l2rad - 2 * l3rad + pi4) +
                            0.00235 * Math.Sin(psi - w3rad) +
                            0.00198 * Math.Sin(psi - w4rad) +
                            0.00176 * Math.Sin(philambda) +
                            0.00130 * Math.Sin(3 * (l3rad - l4rad)) +
                            0.00125 * Math.Sin(l1rad - l3rad) +
                            -0.00119 * Math.Sin(5 * gdash - 2 * g + Angles.DegRad(52.225)) +
                            0.00109 * Math.Sin(l1rad - l2rad) +
                            -0.00100 * Math.Sin(3 * l3rad - 7 * l4rad + 4 * pi4) +
                            0.00091 * Math.Sin(w3rad - w4rad) +
                            0.00080 * Math.Sin(3 * l3rad - 7 * l4rad + pi3 + 3 * pi4) +
                            -0.00075 * Math.Sin(2 * l2rad - 3 * l3rad + pi3) +
                            0.00072 * Math.Sin(pi1 + pi3 - 2 * PI - 2 * g) +
                            0.00069 * Math.Sin(pi4 - PI) +
                            -0.00058 * Math.Sin(2 * l3rad - 3 * l4rad + pi4) +
                            -0.00057 * Math.Sin(l3rad - 2 * l4rad + pi4) +
                            0.00056 * Math.Sin(l3rad + pi3 - 2 * PI - 2 * g) +
                            -0.00052 * Math.Sin(l2rad - 2 * l3rad + pi1) +
                            -0.00050 * Math.Sin(pi2 - pi3) +
                            0.00048 * Math.Sin(l3rad - 2 * l4rad + pi3) +
                            -0.00045 * Math.Sin(2 * l2rad - 3 * l3rad + pi4) +
                            -0.00041 * Math.Sin(pi2 - pi4) +
                            -0.00038 * Math.Sin(2 * g) +
                            -0.00037 * Math.Sin(pi3 - pi4 + w3rad - w4rad) +
                            -0.00032 * Math.Sin(3 * l3rad - 7 * l4rad + 2 * pi3 + 2 * pi4) +
                            0.00030 * Math.Sin(4 * (l3rad - l4rad)) +
                            0.00029 * Math.Sin(l3rad + pi4 - 2 * PI - 2 * g) +
                            -0.00028 * Math.Sin(w3rad + psi - 2 * PI - 2 * g) +
                            0.00026 * Math.Sin(l3rad - PI - g) +
                            0.00024 * Math.Sin(l2rad - 3 * l3rad + 2 * l4rad) +
                            0.00021 * Math.Sin(l3rad - PI - g) +
                            -0.00021 * Math.Sin(l3rad - pi2) +
                            0.00017 * Math.Sin(2 * (l3rad - pi3));

            var sigma4 = 0.84287 * Math.Sin(l4rad - pi4) +
                            0.03431 * Math.Sin(pi4 - pi3) +
                            -0.03305 * Math.Sin(2 * (psi - PI)) +
                            -0.03211 * Math.Sin(g) +
                            -0.01862 * Math.Sin(l4rad - pi3) +
                            0.01186 * Math.Sin(psi - w4rad) +
                            0.00623 * Math.Sin(l4rad + pi4 - 2 * g - 2 * PI) +
                            0.00387 * Math.Sin(2 * (l4rad - pi4)) +
                            -0.00284 * Math.Sin(5 * gdash - 2 * g + Angles.DegRad(52.225)) +
                            -0.00234 * Math.Sin(2 * (psi - pi4)) +
                            -0.00223 * Math.Sin(l3rad - l4rad) +
                            -0.00208 * Math.Sin(l4rad - PI) +
                            0.00178 * Math.Sin(psi + w4rad - 2 * pi4) +
                            0.00134 * Math.Sin(pi4 - PI) +
                            0.00125 * Math.Sin(2 * (l4rad - g - PI)) +
                            -0.00117 * Math.Sin(2 * g) +
                            -0.00112 * Math.Sin(2 * (l3rad - l4rad)) +
                            0.00107 * Math.Sin(3 * l3rad - 7 * l4rad + 4 * pi4) +
                            0.00102 * Math.Sin(l4rad - g - PI) +
                            0.00096 * Math.Sin(2 * l4rad - psi - w4rad) +
                            0.00087 * Math.Sin(2 * (psi - w4rad)) +
                            -0.00085 * Math.Sin(3 * l3rad - 7 * l4rad + pi3 + 3 * pi4) +
                            0.00085 * Math.Sin(l3rad - 2 * l4rad + pi4) +
                            -0.00081 * Math.Sin(2 * (l4rad - psi)) +
                            0.00071 * Math.Sin(l4rad + pi4 - 2 * PI - 3 * g) +
                            0.00061 * Math.Sin(l1rad - l4rad) +
                            -0.00056 * Math.Sin(psi - w3rad) +
                            -0.00054 * Math.Sin(l3rad - 2 * l4rad + pi3) +
                            0.00051 * Math.Sin(l2rad - l4rad) +
                            0.00042 * Math.Sin(2 * (psi - g - PI)) +
                            0.00039 * Math.Sin(2 * (pi4 - w4rad)) +
                            0.00036 * Math.Sin(psi + PI - pi4 - w4rad) +
                            0.00035 * Math.Sin(2 * gdash - g + Angles.DegRad(188.37)) +
                            -0.00035 * Math.Sin(l4rad - pi4 + 2 * PI - 2 * psi) +
                            -0.00032 * Math.Sin(l4rad + pi4 - 2 * PI - g) +
                            0.00030 * Math.Sin(2 * gdash - 2 * g + Angles.DegRad(149.15)) +
                            0.00029 * Math.Sin(3 * l3rad - 7 * l4rad + 2 * pi3 + 2 * pi4) +
                            0.00028 * Math.Sin(l4rad - pi4 + 2 * psi - 2 * PI) +
                            -0.00028 * Math.Sin(2 * (l4rad - w4rad)) +
                            -0.00027 * Math.Sin(pi3 - pi4 + w3rad - w4rad) +
                            -0.00026 * Math.Sin(5 * gdash - 3 * g + Angles.DegRad(188.37)) +
                            0.00025 * Math.Sin(w4rad - w3rad) +
                            -0.00025 * Math.Sin(l2rad - 3 * l3rad + 2 * l4rad) +
                            -0.00023 * Math.Sin(3 * (l3rad - l4rad)) +
                            0.00021 * Math.Sin(2 * l4rad - 2 * PI - 3 * g) +
                            -0.00021 * Math.Sin(2 * l3rad - 3 * l4rad + pi4) +
                            0.00019 * Math.Sin(l4rad - pi4 - g) +
                            -0.00019 * Math.Sin(2 * l4rad - pi3 - pi4) +
                            -0.00018 * Math.Sin(l4rad - pi4 + g) +
                            -0.00016 * Math.Sin(l4rad + pi3 - 2 * PI - 2 * g);

            details.Satellite1.MeanLongitude = Angles.Mod360(l1);
            details.Satellite1.TrueLongitude = Angles.Mod360(l1 + sigma1);
            var longL1 = Angles.DegRad(details.Satellite1.TrueLongitude);

            details.Satellite2.MeanLongitude = Angles.Mod360(l2);
            details.Satellite2.TrueLongitude = Angles.Mod360(l2 + sigma2);
            var longL2 = Angles.DegRad(details.Satellite2.TrueLongitude);

            details.Satellite3.MeanLongitude = Angles.Mod360(l3);
            details.Satellite3.TrueLongitude = Angles.Mod360(l3 + sigma3);
            var longL3 = Angles.DegRad(details.Satellite3.TrueLongitude);

            details.Satellite4.MeanLongitude = Angles.Mod360(l4);
            details.Satellite4.TrueLongitude = Angles.Mod360(l4 + sigma4);
            var longL4 = Angles.DegRad(details.Satellite4.TrueLongitude);

            //// Calculate the periodic terms in the latitudes of the satellites
            var b1 = Math.Atan(0.0006393 * Math.Sin(longL1 - w1rad) +
                             0.0001825 * Math.Sin(longL1 - w2rad) +
                             0.0000329 * Math.Sin(longL1 - w3rad) +
                             -0.0000311 * Math.Sin(longL1 - psi) +
                             0.0000093 * Math.Sin(longL1 - w4rad) +
                             0.0000075 * Math.Sin(3 * longL1 - 4 * l2rad - 1.9927 * sigma1 + w2rad) +
                             0.0000046 * Math.Sin(longL1 + psi - 2 * PI - 2 * g));
            details.Satellite1.EquatorialLatitude = Angles.RadDeg(b1);

            var b2 = Math.Atan(0.0081004 * Math.Sin(longL2 - w2rad) +
                             0.0004512 * Math.Sin(longL2 - w3rad) +
                             -0.0003284 * Math.Sin(longL2 - psi) +
                             0.0001160 * Math.Sin(longL2 - w4rad) +
                             0.0000272 * Math.Sin(l1rad - 2 * l3rad + 1.0146 * sigma2 + w2rad) +
                             -0.0000144 * Math.Sin(longL2 - w1rad) +
                             0.0000143 * Math.Sin(longL2 + psi - 2 * PI - 2 * g) +
                             0.0000035 * Math.Sin(longL2 - psi + g) +
                             -0.0000028 * Math.Sin(l1rad - 2 * l3rad + 1.0146 * sigma2 + w3rad));
            details.Satellite2.EquatorialLatitude = Angles.RadDeg(b2);

            var b3 = Math.Atan(0.0032402 * Math.Sin(longL3 - w3rad) +
                             -0.0016911 * Math.Sin(longL3 - psi) +
                             0.0006847 * Math.Sin(longL3 - w4rad) +
                             -0.0002797 * Math.Sin(longL3 - w2rad) +
                             0.0000321 * Math.Sin(longL3 + psi - 2 * PI - 2 * g) +
                             0.0000051 * Math.Sin(longL3 - psi + g) +
                             -0.0000045 * Math.Sin(longL3 - psi - g) +
                             -0.0000045 * Math.Sin(longL3 + psi - 2 * PI) +
                             0.0000037 * Math.Sin(longL3 + psi - 2 * PI - 3 * g) +
                             0.0000030 * Math.Sin(2 * l2rad - 3 * longL3 + 4.03 * sigma3 + w2rad) +
                             -0.0000021 * Math.Sin(2 * l2rad - 3 * longL3 + 4.03 * sigma3 + w3rad));
            details.Satellite3.EquatorialLatitude = Angles.RadDeg(b3);

            var b4 = Math.Atan(-0.0076579 * Math.Sin(longL4 - psi) +
                             0.0044134 * Math.Sin(longL4 - w4rad) +
                             -0.0005112 * Math.Sin(longL4 - w3rad) +
                             0.0000773 * Math.Sin(longL4 + psi - 2 * PI - 2 * g) +
                             0.0000104 * Math.Sin(longL4 - psi + g) +
                             -0.0000102 * Math.Sin(longL4 - psi - g) +
                             0.0000088 * Math.Sin(longL4 + psi - 2 * PI - 3 * g) +
                             -0.0000038 * Math.Sin(longL4 + psi - 2 * PI - g));
            details.Satellite4.EquatorialLatitude = Angles.RadDeg(b4);

            //// Calculate the periodic terms for the radius vector
            details.Satellite1.R = 5.90569 * (1 + (-0.0041339 * Math.Cos(2 * (l1rad - l2rad)) +
                                                   -0.0000387 * Math.Cos(l1rad - pi3) +
                                                   -0.0000214 * Math.Cos(l1rad - pi4) +
                                                   0.0000170 * Math.Cos(l1rad - l2rad) +
                                                   -0.0000131 * Math.Cos(4 * (l1rad - l2rad)) +
                                                   0.0000106 * Math.Cos(l1rad - l3rad) +
                                                   -0.0000066 * Math.Cos(l1rad + pi3 - 2 * PI - 2 * g)));

            details.Satellite2.R = 9.39657 * (1 + (0.0093848 * Math.Cos(l1rad - l2rad) +
                                                   -0.0003116 * Math.Cos(l2rad - pi3) +
                                                   -0.0001744 * Math.Cos(l2rad - pi4) +
                                                   -0.0001442 * Math.Cos(l2rad - pi2) +
                                                   0.0000553 * Math.Cos(l2rad - l3rad) +
                                                   0.0000523 * Math.Cos(l1rad - l3rad) +
                                                   -0.0000290 * Math.Cos(2 * (l1rad - l2rad)) +
                                                   0.0000164 * Math.Cos(2 * (l2rad - w2rad)) +
                                                   0.0000107 * Math.Cos(l1rad - 2 * l3rad + pi3) +
                                                   -0.0000102 * Math.Cos(l2rad - pi1) +
                                                   -0.0000091 * Math.Cos(2 * (l1rad - l3rad))));

            details.Satellite3.R = 14.98832 * (1 + (-0.0014388 * Math.Cos(l3rad - pi3) +
                                                    -0.0007919 * Math.Cos(l3rad - pi4) +
                                                    0.0006342 * Math.Cos(l2rad - l3rad) +
                                                    -0.0001761 * Math.Cos(2 * (l3rad - l4rad)) +
                                                    0.0000294 * Math.Cos(l3rad - l4rad) +
                                                    -0.0000156 * Math.Cos(3 * (l3rad - l4rad)) +
                                                    0.0000156 * Math.Cos(l1rad - l3rad) +
                                                    -0.0000153 * Math.Cos(l1rad - l2rad) +
                                                    0.0000070 * Math.Cos(2 * l2rad - 3 * l3rad + pi3) +
                                                    -0.0000051 * Math.Cos(l3rad + pi3 - 2 * PI - 2 * g)));

            details.Satellite4.R = 26.36273 * (1 + (-0.0073546 * Math.Cos(l4rad - pi4) +
                                                    0.0001621 * Math.Cos(l4rad - pi3) +
                                                    0.0000974 * Math.Cos(l3rad - l4rad) +
                                                    -0.0000543 * Math.Cos(l4rad + pi4 - 2 * PI - 2 * g) +
                                                    -0.0000271 * Math.Cos(2 * (l4rad - pi4)) +
                                                    0.0000182 * Math.Cos(l4rad - PI) +
                                                    0.0000177 * Math.Cos(2 * (l3rad - l4rad)) +
                                                    -0.0000167 * Math.Cos(2 * l4rad - psi - w4rad) +
                                                    0.0000167 * Math.Cos(psi - w4rad) +
                                                    -0.0000155 * Math.Cos(2 * (l4rad - PI - g)) +
                                                    0.0000142 * Math.Cos(2 * (l4rad - psi)) +
                                                    0.0000105 * Math.Cos(l1rad - l4rad) +
                                                    0.0000092 * Math.Cos(l2rad - l4rad) +
                                                    -0.0000089 * Math.Cos(l4rad - PI - g) +
                                                    -0.0000062 * Math.Cos(l4rad + pi4 - 2 * PI - 3 * g) +
                                                    0.0000048 * Math.Cos(2 * (l4rad - w4rad))));

            //// Calculate T0
            var dT0 = (julianDay - 2433282.423) / 36525;

            //// Calculate the precession in longitude from Epoch B1950 to the date
            var p = Angles.DegRad(1.3966626 * dT0 + 0.0003088 * dT0 * dT0);

            //// Add it to L1 - L4 and psi
            longL1 += p;
            details.Satellite1.TropicalLongitude = Angles.Mod360(Angles.RadDeg(longL1));
            longL2 += p;
            details.Satellite2.TropicalLongitude = Angles.Mod360(Angles.RadDeg(longL2));
            longL3 += p;
            details.Satellite3.TropicalLongitude = Angles.Mod360(Angles.RadDeg(longL3));
            longL4 += p;
            details.Satellite4.TropicalLongitude = Angles.Mod360(Angles.RadDeg(longL4));
            psi += p;

            //// Calculate the inclination of Jupiter's axis of rotation on the orbital plane
            var timeT = (julianDay - 2415020.5) / 36525;
            var inclinI = 3.120262 + 0.0006 * timeT;
            var irad = Angles.DegRad(inclinI);

            var x1 = details.Satellite1.R * Math.Cos(longL1 - psi) * Math.Cos(b1);
            var x2 = details.Satellite2.R * Math.Cos(longL2 - psi) * Math.Cos(b2);
            var x3 = details.Satellite3.R * Math.Cos(longL3 - psi) * Math.Cos(b3);
            var x4 = details.Satellite4.R * Math.Cos(longL4 - psi) * Math.Cos(b4);
            const double x5 = 0;

            var y1 = details.Satellite1.R * Math.Sin(longL1 - psi) * Math.Cos(b1);
            var y2 = details.Satellite2.R * Math.Sin(longL2 - psi) * Math.Cos(b2);
            var y3 = details.Satellite3.R * Math.Sin(longL3 - psi) * Math.Cos(b3);
            var y4 = details.Satellite4.R * Math.Sin(longL4 - psi) * Math.Cos(b4);
            const double y5 = 0;

            var z1 = details.Satellite1.R * Math.Sin(b1);
            var z2 = details.Satellite2.R * Math.Sin(b2);
            var z3 = details.Satellite3.R * Math.Sin(b3);
            var z4 = details.Satellite4.R * Math.Sin(b4);
            const double z5 = 1;

            //// Now do the rotations, first for the fictive 5th satellite, so that we can calculate elongD
            var omega = Angles.DegRad(Planets.BodyJupiter.JupiterLongitudeAscendingNode(julianDay));
            var i = Angles.DegRad(Planets.BodyJupiter.JupiterInclination(julianDay));
            Rotations(x5, y5, z5, irad, psi, i, omega, lambda0, x5, out var a6, out var b6, out var c6);
            var elongD = Math.Atan2(a6, c6);

            //// Now calculate the values for satellite 1
            Rotations(x1, y1, z1, irad, psi, i, omega, lambda0, x5, out a6, out b6, out c6);
            details.Satellite1.TrueRectangularCoordinates.X = a6 * Math.Cos(elongD) - c6 * Math.Sin(elongD);
            details.Satellite1.TrueRectangularCoordinates.Y = a6 * Math.Sin(elongD) + c6 * Math.Cos(elongD);
            details.Satellite1.TrueRectangularCoordinates.Z = b6;

            //// Now calculate the values for satellite 2
            Rotations(x2, y2, z2, irad, psi, i, omega, lambda0, x5, out a6, out b6, out c6);
            details.Satellite2.TrueRectangularCoordinates.X = a6 * Math.Cos(elongD) - c6 * Math.Sin(elongD);
            details.Satellite2.TrueRectangularCoordinates.Y = a6 * Math.Sin(elongD) + c6 * Math.Cos(elongD);
            details.Satellite2.TrueRectangularCoordinates.Z = b6;

            //// Now calculate the values for satellite 3
            Rotations(x3, y3, z3, irad, psi, i, omega, lambda0, x5, out a6, out b6, out c6);
            details.Satellite3.TrueRectangularCoordinates.X = a6 * Math.Cos(elongD) - c6 * Math.Sin(elongD);
            details.Satellite3.TrueRectangularCoordinates.Y = a6 * Math.Sin(elongD) + c6 * Math.Cos(elongD);
            details.Satellite3.TrueRectangularCoordinates.Z = b6;

            //// And finally for satellite 4
            Rotations(x4, y4, z4, irad, psi, i, omega, lambda0, x5, out a6, out b6, out c6);
            details.Satellite4.TrueRectangularCoordinates.X = a6 * Math.Cos(elongD) - c6 * Math.Sin(elongD);
            details.Satellite4.TrueRectangularCoordinates.Y = a6 * Math.Sin(elongD) + c6 * Math.Cos(elongD);
            details.Satellite4.TrueRectangularCoordinates.Z = b6;

            //// apply the differential light-time correction
            details.Satellite1.ApparentRectangularCoordinates.X = details.Satellite1.TrueRectangularCoordinates.X + Math.Abs(details.Satellite1.TrueRectangularCoordinates.Z) / 17295 * Math.Sqrt(1 - (details.Satellite1.TrueRectangularCoordinates.X / details.Satellite1.R) * (details.Satellite1.TrueRectangularCoordinates.X / details.Satellite1.R));
            details.Satellite1.ApparentRectangularCoordinates.Y = details.Satellite1.TrueRectangularCoordinates.Y;
            details.Satellite1.ApparentRectangularCoordinates.Z = details.Satellite1.TrueRectangularCoordinates.Z;

            details.Satellite2.ApparentRectangularCoordinates.X = details.Satellite2.TrueRectangularCoordinates.X + Math.Abs(details.Satellite2.TrueRectangularCoordinates.Z) / 21819 * Math.Sqrt(1 - (details.Satellite2.TrueRectangularCoordinates.X / details.Satellite2.R) * (details.Satellite2.TrueRectangularCoordinates.X / details.Satellite2.R));
            details.Satellite2.ApparentRectangularCoordinates.Y = details.Satellite2.TrueRectangularCoordinates.Y;
            details.Satellite2.ApparentRectangularCoordinates.Z = details.Satellite2.TrueRectangularCoordinates.Z;

            details.Satellite3.ApparentRectangularCoordinates.X = details.Satellite3.TrueRectangularCoordinates.X + Math.Abs(details.Satellite3.TrueRectangularCoordinates.Z) / 27558 * Math.Sqrt(1 - (details.Satellite3.TrueRectangularCoordinates.X / details.Satellite3.R) * (details.Satellite3.TrueRectangularCoordinates.X / details.Satellite3.R));
            details.Satellite3.ApparentRectangularCoordinates.Y = details.Satellite3.TrueRectangularCoordinates.Y;
            details.Satellite3.ApparentRectangularCoordinates.Z = details.Satellite3.TrueRectangularCoordinates.Z;

            details.Satellite4.ApparentRectangularCoordinates.X = details.Satellite4.TrueRectangularCoordinates.X + Math.Abs(details.Satellite4.TrueRectangularCoordinates.Z) / 36548 * Math.Sqrt(1 - (details.Satellite4.TrueRectangularCoordinates.X / details.Satellite4.R) * (details.Satellite4.TrueRectangularCoordinates.X / details.Satellite4.R));
            details.Satellite4.ApparentRectangularCoordinates.Y = details.Satellite4.TrueRectangularCoordinates.Y;
            details.Satellite4.ApparentRectangularCoordinates.Z = details.Satellite4.TrueRectangularCoordinates.Z;

            //// apply the perspective effect correction
            var w = delta / (delta + details.Satellite1.TrueRectangularCoordinates.Z / 2095);
            details.Satellite1.ApparentRectangularCoordinates.X *= w;
            details.Satellite1.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite2.TrueRectangularCoordinates.Z / 2095);
            details.Satellite2.ApparentRectangularCoordinates.X *= w;
            details.Satellite2.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite3.TrueRectangularCoordinates.Z / 2095);
            details.Satellite3.ApparentRectangularCoordinates.X *= w;
            details.Satellite3.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite4.TrueRectangularCoordinates.Z / 2095);
            details.Satellite4.ApparentRectangularCoordinates.X *= w;
            details.Satellite4.ApparentRectangularCoordinates.Y *= w;

            return details;
        }

        /// <summary>
        /// Rotations of the specified X.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="inclinI">The I.</param>
        /// <param name="psi">The psi.</param>
        /// <param name="i">The i.</param>
        /// <param name="omega">The omega.</param>
        /// <param name="lambda0">The lambda0.</param>
        /// <param name="beta0">The beta0.</param>
        /// <param name="a6">The a6.</param>
        /// <param name="b6">The b6.</param>
        /// <param name="c6">The c6.</param>
        private static void Rotations(double x, double y, double z, double inclinI, double psi, double i, double omega, double lambda0, double beta0, out double a6, out double b6, out double c6)
        {
            var phi = psi - omega;

            //// Rotation towards Jupiter's orbital plane
            var a1 = x;
            var b1 = y * Math.Cos(inclinI) - z * Math.Sin(inclinI);
            var c1 = y * Math.Sin(inclinI) + z * Math.Cos(inclinI);

            //// Rotation towards the ascending node of the orbit of jupiter
            var a2 = a1 * Math.Cos(phi) - b1 * Math.Sin(phi);
            var b2 = a1 * Math.Sin(phi) + b1 * Math.Cos(phi);
            var c2 = c1;

            //// Rotation towards the plane of the ecliptic
            var a3 = a2;
            var b3 = b2 * Math.Cos(i) - c2 * Math.Sin(i);
            var c3 = b2 * Math.Sin(i) + c2 * Math.Cos(i);

            //// Rotation towards the vernal equinox
            var a4 = a3 * Math.Cos(omega) - b3 * Math.Sin(omega);
            var b4 = a3 * Math.Sin(omega) + b3 * Math.Cos(omega);
            var c4 = c3;

            var a5 = a4 * Math.Sin(lambda0) - b4 * Math.Cos(lambda0);
            var b5 = a4 * Math.Cos(lambda0) + b4 * Math.Sin(lambda0);
            var c5 = c4;

            a6 = a5;
            b6 = c5 * Math.Sin(beta0) + b5 * Math.Cos(beta0);
            c6 = c5 * Math.Cos(beta0) - b5 * Math.Sin(beta0);
        }

        /// <summary>
        /// Fills the in phenomena details.
        /// </summary>
        /// <param name="detail">The detail.</param>
        private static void FillInPhenomenaDetails(GalileanMoonDetail detail)
        {
            var y1 = 1.071374 * detail.ApparentRectangularCoordinates.Y;
            var r = y1 * y1 + detail.ApparentRectangularCoordinates.X * detail.ApparentRectangularCoordinates.X;

            if (r < 1)
            {
                if (detail.ApparentRectangularCoordinates.Z < 0)
                {
                    //// Satellite nearer to Earth than Jupiter, so it must be a transit not an occultation
                    detail.BInTransit = true;
                    detail.BInOccultation = false;
                }
                else
                {
                    detail.BInTransit = false;
                    detail.BInOccultation = true;
                }
            }
            else
            {
                detail.BInTransit = false;
                detail.BInOccultation = false;
            }
        }
    }
}
