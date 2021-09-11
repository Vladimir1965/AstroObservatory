// <copyright file="PhysicalDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Planets
{
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Coordinates;
    using AstroSharedClasses.Records;
    using AstroSharedOrbits.OrbitalData;
    using JetBrains.Annotations;
    using System;

    /// <summary>
    /// Physical Details.
    /// </summary>
    [UsedImplicitly]
    public static class PhysicalDetails {
        /// <summary>
        /// Times the of sunrise.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double TimeOfSunrise(double julianDay, double longitude, double latitude) {
            return SunriseSunsetHelper(julianDay, longitude, latitude, true);
        }

        /// <summary>
        /// Times the of sunset.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double TimeOfSunset(double julianDay, double longitude, double latitude) {
            return SunriseSunsetHelper(julianDay, longitude, latitude, false);
        }

        #region Sun

        /// <summary>
        /// Suns the details.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static PhysicalSunDetails SunDetails(double julianDay) {
            var theta = Angles.Mod360((julianDay - 2398220) * 360 / 25.38);
            var inclinI = 7.25;
            var k = 73.6667 + 1.3958333 * (julianDay - 2396758) / 36525;

            //// Calculate the apparent longitude of the sun (excluding the effect of nutation)
            var longL = BodyEarth.EclipticLongitude(julianDay);
            var r = BodyEarth.RadiusVector(julianDay);
            var sunLong = longL + 180 - CoordinateTransformation.DmsToDegrees(0, 0, 20.4898 / r);
            //// double SunLongDash = SunLong + CoordinateTransformation.DMSToDegrees(0, 0, Nutation.NutationInLongitude(julianDay));

            var epsilon = Nutation.TrueObliquityOfEcliptic(julianDay);

            //// Convert to radians
            epsilon = Angles.DegRad(epsilon);
            sunLong = Angles.DegRad(sunLong);
            //// SunLongDash = Angles.DegRad(SunLongDash);
            k = Angles.DegRad(k);
            inclinI = Angles.DegRad(inclinI);
            theta = Angles.DegRad(theta);

            var x = Math.Atan(-Math.Cos(sunLong) * Math.Tan(epsilon));
            var y = Math.Atan(-Math.Cos(sunLong - k) * Math.Tan(inclinI));

            var details = new PhysicalSunDetails {
                P = Angles.RadDeg(x + y),
                B0 = Angles.RadDeg(Math.Asin(Math.Sin(sunLong - k) * Math.Sin(inclinI)))
            };

            var eta = Math.Atan(Math.Tan(sunLong - k) * Math.Cos(inclinI));
            details.L0 = Angles.Mod360(Angles.RadDeg(eta - theta));

            return details;
        }
        #endregion

        #region Planets
        /// <summary>
        /// Calculates the specified julianDay.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static PhysicalMarsDetails MarsDetails(double julianDay) {
            //// What will be the return value
            var details = new PhysicalMarsDetails();

            //// Step 1
            var timeT = (julianDay - 2451545) / 36525;
            var lambda0 = 352.9065 + 1.17330 * timeT;
            var lambda0rad = Angles.DegRad(lambda0);
            var beta0 = 63.2818 - 0.00394 * timeT;
            var beta0rad = Angles.DegRad(beta0);

            //// Step 2
            var l0 = BodyEarth.EclipticLongitude(julianDay);
            var l0rad = Angles.DegRad(l0);
            var b0 = BodyEarth.EclipticLatitude(julianDay);
            var b0rad = Angles.DegRad(b0);
            var r1 = BodyEarth.RadiusVector(julianDay);

            double previousLightTravelTime = 0;
            double lightTravelTime = 0;
            double x = 0;
            double y = 0;
            double z = 0;
            var bIterate = true;
            double delta = 0;
            double l = 0;
            double longitudeRadian = 0;
            double b = 0;
            double r = 0;
            while (bIterate) {
                var julianDay2 = julianDay - lightTravelTime;

                //// Step 3
                l = BodyMars.EclipticLongitude(julianDay2);
                longitudeRadian = Angles.DegRad(l);
                b = BodyMars.EclipticLatitude(julianDay2);
                var latitudeRadian = Angles.DegRad(b);
                r = BodyMars.RadiusVector(julianDay2);

                //// Step 4
                x = r * Math.Cos(latitudeRadian) * Math.Cos(longitudeRadian) - r1 * Math.Cos(l0rad);
                y = r * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian) - r1 * Math.Sin(l0rad);
                z = r * Math.Sin(latitudeRadian) - r1 * Math.Sin(b0rad);
                delta = Math.Sqrt(x * x + y * y + z * z);
                lightTravelTime = Elliptical.DistanceToLightTime(delta);

                //// Prepare for the next loop around
                bIterate = Math.Abs(lightTravelTime - previousLightTravelTime) > 2E-6; //// 2E-6 correponds to 0.17 of a second
                if (bIterate) {
                    previousLightTravelTime = lightTravelTime;
                }
            }

            //// Step 5
            var lambdaRad = Math.Atan2(y, x);
            var lambda = Angles.RadDeg(lambdaRad);
            var betaRad = Math.Atan2(z, Math.Sqrt(x * x + y * y));
            var beta = Angles.RadDeg(betaRad);

            //// Step 6
            details.DE = Angles.RadDeg(Math.Asin(-Math.Sin(beta0rad) * Math.Sin(betaRad) - Math.Cos(beta0rad) * Math.Cos(betaRad) * Math.Cos(lambda0rad - lambdaRad)));

            //// Step 7
            var N = 49.5581 + 0.7721 * timeT;
            var nrad = Angles.DegRad(N);

            var ldash = l - 0.00697 / r;
            var ldashrad = Angles.DegRad(ldash);
            var bdash = b - 0.000225 * (Math.Cos(longitudeRadian - nrad) / r);
            var bdashrad = Angles.DegRad(bdash);

            //// Step 8
            details.DS = Angles.RadDeg(Math.Asin(-Math.Sin(beta0rad) * Math.Sin(bdashrad) - Math.Cos(beta0rad) * Math.Cos(bdashrad) * Math.Cos(lambda0rad - ldashrad)));

            //// Step 9
            var argumentW = Angles.Mod360(11.504 + 350.89200025 * (julianDay - lightTravelTime - 2433282.5));

            //// Step 10
            var e0 = Nutation.MeanObliquityOfEcliptic(julianDay);
            var e0rad = Angles.DegRad(e0);

            var ecliptic0 = new CoordinateEcliptic2D { Lambda = lambda0, Beta = beta0 };
            var poleEquatorial = ecliptic0.ToEquatorial(e0);
            var alpha0rad = poleEquatorial.AlphaRadians;
            var delta0rad = poleEquatorial.DeltaRadians;

            //// Step 11
            var u = y * Math.Cos(e0rad) - z * Math.Sin(e0rad);
            var v = y * Math.Sin(e0rad) + z * Math.Cos(e0rad);
            var alpharad = Math.Atan2(u, x);
            var deltarad = Math.Atan2(v, Math.Sqrt(x * x + u * u));
            //// double alpha = Angles.RadiansToHours(alpharad);
            //// double delta = Angles.RadDeg(deltarad);
            var coord = new CoordinateEquatorial2D {
                AlphaRadians = alpharad,
                DeltaRadians = deltarad
            };

            var xi = Math.Atan2(Math.Sin(delta0rad) * Math.Cos(deltarad) * Math.Cos(alpha0rad - alpharad) - Math.Sin(deltarad) * Math.Cos(delta0rad), Math.Cos(deltarad) * Math.Sin(alpha0rad - alpharad));

            //// Step 12
            details.W = Angles.Mod360(argumentW - Angles.RadDeg(xi));

            //// Step 13
            var nutationInLongitude = Nutation.NutationInLongitude(julianDay);
            var nutationInObliquity = Nutation.NutationInObliquity(julianDay);

            //// Step 14
            lambda += 0.005693 * Math.Cos(l0rad - lambdaRad) / Math.Cos(betaRad);
            beta += 0.005693 * Math.Sin(l0rad - lambdaRad) * Math.Sin(betaRad);

            //// Step 15
            lambda0 += nutationInLongitude / 3600;
            //// Lambda0rad = Angles.DegRad(Lambda0);
            lambda += nutationInLongitude / 3600;
            //// lambdaRad = Angles.DegRad(lambda);
            e0 += nutationInObliquity / 3600;
            //// e0rad = Angles.DegRad(e0rad);

            //// Step 16
            var ecliptic0dash = new CoordinateEcliptic2D { Lambda = lambda0, Beta = beta0 };

            var apparentPoleEquatorial = ecliptic0dash.ToEquatorial(e0);
            var alpha0dash = apparentPoleEquatorial.AlphaRadians;
            var delta0dash = apparentPoleEquatorial.DeltaRadians;

            var ecliptic = new CoordinateEcliptic2D {
                Lambda = lambda,
                Beta = beta
            };

            var apparentMars = ecliptic.ToEquatorial(e0);
            var alphadash = apparentMars.AlphaRadians;
            var deltadash = apparentMars.DeltaRadians;

            //// Step 17
            details.P = Angles.Mod360(Angles.RadDeg(Math.Atan2(Math.Cos(delta0dash) * Math.Sin(alpha0dash - alphadash), Math.Sin(delta0dash) * Math.Cos(deltadash) - Math.Cos(delta0dash) * Math.Sin(deltadash) * Math.Cos(alpha0dash - alphadash))));

            //// Step 18
            var sunLambda = Systems.BodySun.GeometricEclipticLongitude(julianDay);
            var sunBeta = Systems.BodySun.GeometricEclipticLatitude(julianDay);
            var eclipticSun = new CoordinateEcliptic2D { Lambda = sunLambda, Beta = sunBeta };

            var sunEquatorial = eclipticSun.ToEquatorial(e0);
            details.X = Moons.MoonIllumination.PositionAngle(sunEquatorial, coord);

            //// Step 19
            details.D = 9.36 / delta;
            details.K = Moons.IlluminatedFraction.ConvertToIlluminatedFraction(r, r1, delta);
            details.Q = (1 - details.K) * details.D;

            return details;
        }

        /// <summary>
        /// Jupiter the details.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static PhysicalJupiterDetails JupiterDetails(double julianDay) {
            //// What will be the return value
            var details = new PhysicalJupiterDetails();

            //// Step 1
            var d = julianDay - 2433282.5;
            var T1 = d / 36525;
            var alpha0 = 268.00 + 0.1061 * T1;
            var alpha0rad = Angles.DegRad(alpha0);
            var delta0 = 64.50 - 0.0164 * T1;
            var delta0rad = Angles.DegRad(delta0);

            //// Step 2
            var w1 = Angles.Mod360(17.710 + 877.90003539 * d);
            var w2 = Angles.Mod360(16.838 + 870.27003539 * d);

            //// Step 3
            var l0 = BodyEarth.EclipticLongitude(julianDay);
            var l0rad = Angles.DegRad(l0);
            var b0 = BodyEarth.EclipticLatitude(julianDay);
            var b0rad = Angles.DegRad(b0);
            var radiusR = BodyEarth.RadiusVector(julianDay);

            //// Step 4
            var l = BodyJupiter.EclipticLongitude(julianDay);
            var longitudeRadian = Angles.DegRad(l);
            var b = BodyJupiter.EclipticLatitude(julianDay);
            var latitudeRadian = Angles.DegRad(b);
            var r = BodyJupiter.RadiusVector(julianDay);

            //// Step 5
            var x = r * Math.Cos(latitudeRadian) * Math.Cos(longitudeRadian) - radiusR * Math.Cos(l0rad);
            var y = r * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian) - radiusR * Math.Sin(l0rad);
            var z = r * Math.Sin(latitudeRadian) - radiusR * Math.Sin(b0rad);
            var delta1 = Math.Sqrt(x * x + y * y + z * z);

            //// Step 6
            l -= 0.012990 * delta1 / (r * r);
            longitudeRadian = Angles.DegRad(l);

            //// Step 7
            x = r * Math.Cos(latitudeRadian) * Math.Cos(longitudeRadian) - radiusR * Math.Cos(l0rad);
            y = r * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian) - radiusR * Math.Sin(l0rad);
            z = r * Math.Sin(latitudeRadian) - radiusR * Math.Sin(b0rad);
            delta1 = Math.Sqrt(x * x + y * y + z * z);

            //// Step 8
            var e0 = Nutation.MeanObliquityOfEcliptic(julianDay);
            var e0rad = Angles.DegRad(e0);

            //// Step 9
            var alphas = Math.Atan2(Math.Cos(e0rad) * Math.Sin(longitudeRadian) - Math.Sin(e0rad) * Math.Tan(latitudeRadian), Math.Cos(longitudeRadian));
            var deltas = Math.Asin(Math.Cos(e0rad) * Math.Sin(latitudeRadian) + Math.Sin(e0rad) * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian));

            //// Step 10
            details.DS = Angles.RadDeg(Math.Asin(-Math.Sin(delta0rad) * Math.Sin(deltas) - Math.Cos(delta0rad) * Math.Cos(deltas) * Math.Cos(alpha0rad - alphas)));

            //// Step 11
            var u = y * Math.Cos(e0rad) - z * Math.Sin(e0rad);
            var v = y * Math.Sin(e0rad) + z * Math.Cos(e0rad);
            var alpharad = Math.Atan2(u, x);
            var alpha = Angles.RadDeg(alpharad);
            var deltarad = Math.Atan2(v, Math.Sqrt(x * x + u * u));
            var delta = Angles.RadDeg(deltarad);
            var xi = Math.Atan2(Math.Sin(delta0rad) * Math.Cos(deltarad) * Math.Cos(alpha0rad - alpharad) - Math.Sin(deltarad) * Math.Cos(delta0rad), Math.Cos(deltarad) * Math.Sin(alpha0rad - alpharad));

            //// Step 12
            details.DE = Angles.RadDeg(Math.Asin(-Math.Sin(delta0rad) * Math.Sin(deltarad) - Math.Cos(delta0rad) * Math.Cos(deltarad) * Math.Cos(alpha0rad - alpharad)));

            //// Step 13
            details.GeometricW1 = Angles.Mod360(w1 - Angles.RadDeg(xi) - 5.07033 * delta1);
            details.GeometricW2 = Angles.Mod360(w2 - Angles.RadDeg(xi) - 5.02626 * delta1);

            //// Step 14
            var c = 57.2958 * (2 * r * delta1 + radiusR * radiusR - r * r - delta1 * delta1) / (4 * r * delta1);
            if (Math.Sin(longitudeRadian - l0rad) > 0) {
                details.ApparentW1 = Angles.Mod360(details.GeometricW1 + c);
                details.ApparentW2 = Angles.Mod360(details.GeometricW2 + c);
            }
            else {
                details.ApparentW1 = Angles.Mod360(details.GeometricW1 - c);
                details.ApparentW2 = Angles.Mod360(details.GeometricW2 - c);
            }

            //// Step 15
            var nutationInLongitude = Nutation.NutationInLongitude(julianDay);
            var nutationInObliquity = Nutation.NutationInObliquity(julianDay);
            e0 += nutationInObliquity / 3600;
            e0rad = Angles.DegRad(e0);

            //// Step 16
            alpha += 0.005693 * (Math.Cos(alpharad) * Math.Cos(l0rad) * Math.Cos(e0rad) + Math.Sin(alpharad) * Math.Sin(l0rad)) / Math.Cos(deltarad);
            alpha = Angles.Mod360(alpha);
            alpharad = Angles.DegRad(alpha);
            delta += 0.005693 * (Math.Cos(l0rad) * Math.Cos(e0rad) * (Math.Tan(e0rad) * Math.Cos(deltarad) - Math.Sin(alpharad) * Math.Sin(deltarad)) + Math.Cos(alpharad) * Math.Sin(deltarad) * Math.Sin(l0rad));
            //// deltarad = Angles.DegRad(delta);

            //// Step 17
            var nutationRA = Nutation.NutationInRightAscension(alpha / 15, delta, e0, nutationInLongitude, nutationInObliquity);
            var alphadash = alpha + nutationRA / 3600;
            var alphadashrad = Angles.DegRad(alphadash);
            var nutationDec = Nutation.NutationInDeclination(alpha / 15, e0, nutationInLongitude, nutationInObliquity);
            var deltadash = delta + nutationDec / 3600;
            var deltadashrad = Angles.DegRad(deltadash);
            nutationRA = Nutation.NutationInRightAscension(alpha0 / 15, delta0, e0, nutationInLongitude, nutationInObliquity);
            var alpha0dash = alpha0 + nutationRA / 3600;
            var alpha0dashrad = Angles.DegRad(alpha0dash);
            nutationDec = Nutation.NutationInDeclination(alpha0 / 15, e0, nutationInLongitude, nutationInObliquity);
            var delta0dash = delta0 + nutationDec / 3600;
            var delta0dashrad = Angles.DegRad(delta0dash);

            //// Step 18
            details.P = Angles.Mod360(Angles.RadDeg(Math.Atan2(Math.Cos(delta0dashrad) * Math.Sin(alpha0dashrad - alphadashrad), Math.Sin(delta0dashrad) * Math.Cos(deltadashrad) - Math.Cos(delta0dashrad) * Math.Sin(deltadashrad) * Math.Cos(alpha0dashrad - alphadashrad))));

            return details;
        }
        #endregion

        #region Moon 

        /// <summary>
        /// Calculates the geocentric.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static PhysicalMoonDetails CalculateGeocentric(double julianDay) {
            double lambda;
            double beta;
            double epsilon;
            CoordinateEquatorial2D equatorial;
            return CalculateHelper(julianDay, out lambda, out beta, out epsilon, out equatorial);
        }

        /// <summary>
        /// Calculates the topocentric.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static PhysicalMoonDetails CalculateTopocentric(double julianDay, double longitude, double latitude) {
            //// First convert to radians
            longitude = Angles.DegRad(longitude);
            latitude = Angles.DegRad(latitude);

            double lambda;
            double beta;
            double epsilon;
            var details = CalculateHelper(julianDay, out lambda, out beta, out epsilon, out var equatorial);
            Systems.EarthSystem.Moon.SetJulianDate(julianDay);
            var r = Systems.EarthSystem.Moon.RadiusVector;
            var pi = Moons.BodyMoonMeeus.RadiusVectorToHorizontalParallax(r);
            var alpha = equatorial.AlphaRadians;
            var delta = equatorial.DeltaRadians;

            var ast = SiderealTime.ApparentGreenwichSiderealTime(julianDay);
            var h = Angles.HoursToRadians(ast) - longitude - alpha;

            var q = Math.Atan2(Math.Cos(latitude) * Math.Sin(h), Math.Cos(delta) * Math.Sin(latitude) - Math.Sin(delta) * Math.Cos(latitude) * Math.Cos(h));
            var z = Math.Acos(Math.Sin(delta) * Math.Sin(latitude) + Math.Cos(delta) * Math.Cos(latitude) * Math.Cos(h));
            var pidash = pi * (Math.Sin(z) + 0.0084 * Math.Sin(2 * z));

            var prad = Angles.DegRad(details.P);

            var deltaL = -pidash * Math.Sin(q - prad) / Math.Cos(Angles.DegRad(details.B));
            details.L += deltaL;
            var deltaB = pidash * Math.Cos(q - prad);
            details.B += deltaB;
            details.P += deltaL * Math.Sin(Angles.DegRad(details.B)) - pidash * Math.Sin(q) * Math.Tan(delta);

            return details;
        }
        #endregion

        #region Private static
        /// <summary>
        /// Calculates the selenographic position of sun.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        private static SelenographicMoonDetails CalculateSelenographicPositionOfSun(double julianDay) {
            Systems.EarthSystem.Moon.SetJulianDate(julianDay);
            var r = BodyEarth.RadiusVector(julianDay) * 149597970;
            var delta = Systems.EarthSystem.Moon.RadiusVector;
            var lambda0 = Systems.BodySun.ApparentEclipticLongitude(julianDay);
            var lambda = Systems.EarthSystem.Moon.EclipticLongitude;
            var beta = Systems.EarthSystem.Moon.EclipticLatitude;

            var lambdah = Angles.Mod360(lambda0 + 180 + delta / r * 57.296 * Math.Cos(Angles.DegRad(beta)) * Math.Sin(Angles.DegRad(lambda0 - lambda)));
            var betah = delta / r * beta;

            //// What will be the return value
            var details = new SelenographicMoonDetails();

            //// Calculate the optical libration
            double omega;
            double deltaU;
            double sigma;
            double inclinI;
            double rho;
            double epsilon;
            CalculateOpticalLibration(julianDay, lambdah, betah, out var ldash0, out var bdash0, out var ldash20, out var bdash20, out epsilon, out omega, out deltaU, out sigma, out inclinI, out rho);

            details.L0 = ldash0 + ldash20;
            details.B0 = bdash0 + bdash20;
            details.C0 = Angles.Mod360(450 - details.L0);
            return details;
        }

        /// <summary>
        /// Altitudes the of sun.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double AltitudeOfSun(double julianDay, double longitude, double latitude) {
            //// Calculate the selenographic details
            var selenographicDetails = CalculateSelenographicPositionOfSun(julianDay);

            //// convert to radians
            latitude = Angles.DegRad(latitude);
            longitude = Angles.DegRad(longitude);
            selenographicDetails.B0 = Angles.DegRad(selenographicDetails.B0);
            selenographicDetails.C0 = Angles.DegRad(selenographicDetails.C0);

            return Angles.RadDeg(Math.Asin(Math.Sin(selenographicDetails.B0) * Math.Sin(latitude) + Math.Cos(selenographicDetails.B0) * Math.Cos(latitude) * Math.Sin(selenographicDetails.C0 + longitude)));
        }

        /// <summary>
        /// Sunrises the sunset helper.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="bSunrise">The b sunrise.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double SunriseSunsetHelper(double julianDay, double longitude, double latitude, bool bSunrise) {
            var julianDayResult = julianDay;
            var latituderad = Angles.DegRad(latitude);
            double h;
            do {
                h = AltitudeOfSun(julianDayResult, longitude, latitude);
                var deltaJulianDay = h / (12.19075 * Math.Cos(latituderad));
                julianDayResult = bSunrise ? julianDayResult - deltaJulianDay : julianDayResult + deltaJulianDay;
            }
            while (Math.Abs(h) > 0.001);

            return julianDayResult;
        }

        /// <summary>
        /// Calculates the optical libration.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="lambda">The lambda.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="ldash">The ldash.</param>
        /// <param name="bdash">The bdash.</param>
        /// <param name="ldash2">The ldash2.</param>
        /// <param name="bdash2">The bdash2.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <param name="omega">The omega.</param>
        /// <param name="deltaU">The delta u.</param>
        /// <param name="sigma">The sigma.</param>
        /// <param name="inclinI">The inclinI.</param>
        /// <param name="rho">The rho.</param>
        private static void CalculateOpticalLibration(double julianDay, double lambda, double beta, out double ldash, out double bdash, out double ldash2, out double bdash2, out double epsilon, out double omega, out double deltaU, out double sigma, out double inclinI, out double rho) {
            Systems.EarthSystem.Moon.SetJulianDate(julianDay);
            //// Calculate the initial quantities
            var lambdaRad = Angles.DegRad(lambda);
            var betaRad = Angles.DegRad(beta);
            inclinI = Angles.DegRad(1.54242);
            deltaU = Angles.DegRad(Nutation.NutationInLongitude(julianDay) / 3600);
            var latitudeF = Angles.DegRad(Moons.BodyMoonMeeus.ArgumentOfLatitude(julianDay));
            omega = Angles.DegRad(Systems.EarthSystem.Moon.LW); //// MeanLongitudeAscendingNode
            epsilon = Nutation.MeanObliquityOfEcliptic(julianDay) + Nutation.NutationInObliquity(julianDay) / 3600;

            //// Calculate the optical librations
            var argumentW = lambdaRad - deltaU / 3600 - omega;
            var angleA = Math.Atan2(Math.Sin(argumentW) * Math.Cos(betaRad) * Math.Cos(inclinI) - Math.Sin(betaRad) * Math.Sin(inclinI), Math.Cos(argumentW) * Math.Cos(betaRad));
            ldash = Angles.Mod360(Angles.RadDeg(angleA) - Angles.RadDeg(latitudeF));
            if (ldash > 180) {
                ldash -= 360;
            }

            bdash = Math.Asin(-Math.Sin(argumentW) * Math.Cos(betaRad) * Math.Sin(inclinI) - Math.Sin(betaRad) * Math.Cos(inclinI));

            //// Calculate the physical librations
            var timeT = (julianDay - 2451545.0) / 36525;
            var k1 = 119.75 + 131.849 * timeT;
            k1 = Angles.DegRad(k1);
            var k2 = 72.56 + 20.186 * timeT;
            k2 = Angles.DegRad(k2);

            var anomalyM = BodyEarth.SunMeanAnomaly(julianDay);
            anomalyM = Angles.DegRad(anomalyM);
            var mdash = Systems.EarthSystem.Moon.MeanAnomaly;
            mdash = Angles.DegRad(mdash);
            var elongD = Systems.EarthSystem.Moon.MeanElongation;
            elongD = Angles.DegRad(elongD);
            var eccentricE = BodyEarth.Eccentricity(julianDay);

            rho = -0.02752 * Math.Cos(mdash) +
                  -0.02245 * Math.Sin(latitudeF) +
                  0.00684 * Math.Cos(mdash - 2 * latitudeF) +
                  -0.00293 * Math.Cos(2 * latitudeF) +
                  -0.00085 * Math.Cos(2 * latitudeF - 2 * elongD) +
                  -0.00054 * Math.Cos(mdash - 2 * elongD) +
                  -0.00020 * Math.Sin(mdash + latitudeF) +
                  -0.00020 * Math.Cos(mdash + 2 * latitudeF) +
                  -0.00020 * Math.Cos(mdash - latitudeF) +
                  0.00014 * Math.Cos(mdash + 2 * latitudeF - 2 * elongD);

            sigma = -0.02816 * Math.Sin(mdash) +
                    0.02244 * Math.Cos(latitudeF) +
                    -0.00682 * Math.Sin(mdash - 2 * latitudeF) +
                    -0.00279 * Math.Sin(2 * latitudeF) +
                    -0.00083 * Math.Sin(2 * latitudeF - 2 * elongD) +
                    0.00069 * Math.Sin(mdash - 2 * elongD) +
                    0.00040 * Math.Cos(mdash + latitudeF) +
                    -0.00025 * Math.Sin(2 * mdash) +
                    -0.00023 * Math.Sin(mdash + 2 * latitudeF) +
                    0.00020 * Math.Cos(mdash - latitudeF) +
                    0.00019 * Math.Sin(mdash - latitudeF) +
                    0.00013 * Math.Sin(mdash + 2 * latitudeF - 2 * elongD) +
                    -0.00010 * Math.Cos(mdash - 3 * latitudeF);

            var tau = 0.02520 * eccentricE * Math.Sin(anomalyM) +
                         0.00473 * Math.Sin(2 * mdash - 2 * latitudeF) +
                         -0.00467 * Math.Sin(mdash) +
                         0.00396 * Math.Sin(k1) +
                         0.00276 * Math.Sin(2 * mdash - 2 * elongD) +
                         0.00196 * Math.Sin(omega) +
                         -0.00183 * Math.Cos(mdash - latitudeF) +
                         0.00115 * Math.Sin(mdash - 2 * elongD) +
                         -0.00096 * Math.Sin(mdash - elongD) +
                         0.00046 * Math.Sin(2 * latitudeF - 2 * elongD) +
                         -0.00039 * Math.Sin(mdash - latitudeF) +
                         -0.00032 * Math.Sin(mdash - anomalyM - elongD) +
                         0.00027 * Math.Sin(2 * mdash - anomalyM - 2 * elongD) +
                         0.00023 * Math.Sin(k2) +
                         -0.00014 * Math.Sin(2 * elongD) +
                         0.00014 * Math.Cos(2 * mdash - 2 * latitudeF) +
                         -0.00012 * Math.Sin(mdash - 2 * latitudeF) +
                         -0.00012 * Math.Sin(2 * mdash) +
                         0.00011 * Math.Sin(2 * mdash - 2 * anomalyM - 2 * elongD);

            ldash2 = -tau + (rho * Math.Cos(angleA) + sigma * Math.Sin(angleA)) * Math.Tan(bdash);
            bdash = Angles.RadDeg(bdash);
            bdash2 = sigma * Math.Cos(angleA) - rho * Math.Sin(angleA);
        }

        /// <summary>
        /// Calculates the helper.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="lambda">The lambda.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <param name="equatorial">The equatorial.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static PhysicalMoonDetails CalculateHelper(double julianDay, out double lambda, out double beta, out double epsilon, out CoordinateEquatorial2D equatorial) {
            //// What will be the return value
            var details = new PhysicalMoonDetails();
            Systems.EarthSystem.Moon.SetJulianDate(julianDay);
            //// Calculate the initial quantities
            lambda = Systems.EarthSystem.Moon.EclipticLongitude;
            beta = Systems.EarthSystem.Moon.EclipticLatitude;

            //// Calculate the optical libration
            CalculateOpticalLibration(julianDay, lambda, beta, out var ldash, out var bdash, out var ldash2, out var bdash2, out epsilon, out var omega, out var deltaU, out var sigma, out var inclinI, out var rho);
            details.Ldash = ldash;
            details.Bdash = bdash;
            details.Ldash2 = ldash2;
            details.Bdash2 = bdash2;
            var epsilonrad = Angles.DegRad(epsilon);

            //// Calculate the total libration
            details.L = details.Ldash + details.Ldash2;
            details.B = details.Bdash + details.Bdash2;
            var b = Angles.DegRad(details.B);

            //// Calculate the position angle
            var v = omega + deltaU + Angles.DegRad(sigma) / Math.Sin(inclinI);
            var iRho = inclinI + Angles.DegRad(rho);
            var x = Math.Sin(iRho) * Math.Sin(v);
            var y = Math.Sin(iRho) * Math.Cos(v) * Math.Cos(epsilonrad) - Math.Cos(iRho) * Math.Sin(epsilonrad);
            var w = Math.Atan2(x, y);

            var ecliptic = new CoordinateEcliptic2D { Lambda = lambda, Beta = beta };

            equatorial = ecliptic.ToEquatorial(epsilon);
            var alpha = equatorial.AlphaRadians;
            details.P = Angles.RadDeg(Math.Asin(Math.Sqrt(x * x + y * y) * Math.Cos(alpha - w) / Math.Cos(b)));

            return details;
        }
        #endregion
    }
}
