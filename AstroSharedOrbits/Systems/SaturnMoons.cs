// <copyright file="SaturnMoons.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>
//// History: PJN / 09-02-2004 1. Updated the values used in the calculation of the a1 and a2 constants 
////  for Rhea (satellite V) following an email from Jean Meeus confirming that these constants 
//// are indeed incorrect as published in the book. 

namespace AstroSharedOrbits.Systems {
    using System;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedOrbits.OrbitalData;
    using JetBrains.Annotations;

    /// <summary>
    /// Saturn Moons.
    /// </summary>
    [UsedImplicitly]
    public static class SaturnMoons {
        /// <summary>
        /// Calculates the specified julianDay.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static SaturnMoonsDetails Calculate(double julianDay) {
            //// Calculate the position of the Sun
            var sunlong = BodySun.GeometricEclipticLongitude(julianDay);
            var sunlongrad = Angles.DegRad(sunlong);
            var beta = BodySun.GeometricEclipticLatitude(julianDay);
            var betaRad = Angles.DegRad(beta);
            var radiusR = Planets.BodyEarth.RadiusVector(julianDay);

            //// Calculate the the light travel time from Saturn to the Earth
            double delta = 9;
            double previousEarthLightTravelTime = 0;
            var earthLightTravelTime = Elliptical.DistanceToLightTime(delta);
            var julianDay1 = julianDay - earthLightTravelTime;
            var bIterate = true;
            double x;
            double y;
            double z;
            while (bIterate) {
                //// Calculate the position of Jupiter
                var l = Planets.BodySaturn.EclipticLongitude(julianDay1);
                var longitudeRadian = Angles.DegRad(l);
                var b = Planets.BodySaturn.EclipticLatitude(julianDay1);
                var latitudeRadian = Angles.DegRad(b);
                var r = Planets.BodySaturn.RadiusVector(julianDay1);

                x = r * Math.Cos(latitudeRadian) * Math.Cos(longitudeRadian) + radiusR * Math.Cos(sunlongrad);
                y = r * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian) + radiusR * Math.Sin(sunlongrad);
                z = r * Math.Sin(latitudeRadian) + radiusR * Math.Sin(betaRad);
                delta = Math.Sqrt(x * x + y * y + z * z);
                earthLightTravelTime = Elliptical.DistanceToLightTime(delta);

                //// Prepare for the next loop around
                bIterate = Math.Abs(earthLightTravelTime - previousEarthLightTravelTime) > 2E-6; //// 2E-6 corresponds to 0.17 of a second
                if (!bIterate) {
                    continue;
                }

                julianDay1 = julianDay - earthLightTravelTime;
                previousEarthLightTravelTime = earthLightTravelTime;
            }

            //// Calculate the details as seen from the earth
            var details1 = SaturnDetailsFromTheEarth(julianDay, sunlongrad, betaRad, radiusR);
            {
                //// Calculate the the light travel time from Saturn to the Sun
                julianDay1 = julianDay - earthLightTravelTime;
                var l = Planets.BodySaturn.EclipticLongitude(julianDay1);
                var longitudeRadian = Angles.DegRad(l);
                var b = Planets.BodySaturn.EclipticLatitude(julianDay1);
                var latitudeRadian = Angles.DegRad(b);
                var r = Planets.BodySaturn.RadiusVector(julianDay1);
                x = r * Math.Cos(latitudeRadian) * Math.Cos(longitudeRadian);
                y = r * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian);
                z = r * Math.Sin(latitudeRadian);
                delta = Math.Sqrt(x * x + y * y + z * z);
            }

            var sunLightTravelTime = Elliptical.DistanceToLightTime(delta);

            //// Calculate the details as seen from the Sun
            var details2 = SaturnDetailsFromTheSun(julianDay, sunlongrad, betaRad, earthLightTravelTime, sunLightTravelTime);

            //// Finally transfer the required values from details2 to details1
            TransferDetailValues(details1, details2);

            return details1;
        }

        /// <summary>
        /// Helpers the subroutine.
        /// </summary>
        /// <param name="e">The element e.</param>
        /// <param name="lambdadash">The lambda dash.</param>
        /// <param name="p">The element p.</param>
        /// <param name="a">The element A.</param>
        /// <param name="omega">The omega.</param>
        /// <param name="i">The element i.</param>
        /// <param name="c1">The number c1.</param>
        /// <param name="s1">The number s1.</param>
        /// <param name="r">The element r.</param>
        /// <param name="lambda">The lambda.</param>
        /// <param name="gamma">The gamma.</param>
        /// <param name="w">The number w.</param>
        private static void HelperSubroutine(double e, double lambdadash, double p, double a, double omega, double i, double c1, double s1, out double r, out double lambda, out double gamma, out double w) {
            var e2 = e * e;
            var e3 = e2 * e;
            var e4 = e3 * e;
            var e5 = e4 * e;
            var anomalyM = Angles.DegRad(lambdadash - p);

            var crad = (2 * e - 0.25 * e3 + 0.0520833333 * e5) * Math.Sin(anomalyM) +
                       (1.25 * e2 - 0.458333333 * e4) * Math.Sin(2 * anomalyM) +
                       (1.083333333 * e3 - 0.671875 * e5) * Math.Sin(3 * anomalyM) +
                       1.072917 * e4 * Math.Sin(4 * anomalyM) + 1.142708 * e5 * Math.Sin(5 * anomalyM);
            var c = Angles.RadDeg(crad);
            r = a * (1 - e2) / (1 + e * Math.Cos(anomalyM + crad));
            var g = omega - 168.8112;
            var grad = Angles.DegRad(g);
            var irad = Angles.DegRad(i);
            var a1 = Math.Sin(irad) * Math.Sin(grad);
            var a2 = c1 * Math.Sin(irad) * Math.Cos(grad) - s1 * Math.Cos(irad);
            gamma = Angles.RadDeg(Math.Asin(Math.Sqrt(a1 * a1 + a2 * a2)));
            var urad = Math.Atan2(a1, a2);
            var u = Angles.RadDeg(urad);
            w = Angles.Mod360(168.8112 + u);
            var h = c1 * Math.Sin(irad) - s1 * Math.Cos(irad) * Math.Cos(grad);
            var psirad = Math.Atan2(s1 * Math.Sin(grad), h);
            var psi = Angles.RadDeg(psirad);
            lambda = lambdadash + c + u - g - psi;
        }

        /// <summary>
        /// Calculates the helper.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="sunlongrad">The sunlongrad.</param>
        /// <param name="betaRad">The betaRad.</param>
        /// <param name="radiusR">The R.</param>
        /// <returns> Returns value. </returns>
        private static SaturnMoonsDetails CalculateHelper(double julianDay, double sunlongrad, double betaRad, double radiusR) {
            //// What will be the return value
            var details = new SaturnMoonsDetails();

            //// Calculate the position of Saturn decreased by the light travel time from Saturn to the specified position
            double delta = 9;
            double previousLightTravelTime = 0;
            var lightTravelTime = Elliptical.DistanceToLightTime(delta);
            double x = 0;
            double y = 0;
            double z = 0;
            double l;
            var julianDay1 = julianDay - lightTravelTime;
            var bIterate = true;
            while (bIterate) {
                //// Calculate the position of Saturn
                l = Planets.BodySaturn.EclipticLongitude(julianDay1);
                var longitudeRadian = Angles.DegRad(l);
                var b = Planets.BodySaturn.EclipticLatitude(julianDay1);
                var latitudeRadian = Angles.DegRad(b);
                var r = Planets.BodySaturn.RadiusVector(julianDay1);

                x = r * Math.Cos(latitudeRadian) * Math.Cos(longitudeRadian) + radiusR * Math.Cos(sunlongrad);
                y = r * Math.Cos(latitudeRadian) * Math.Sin(longitudeRadian) + radiusR * Math.Sin(sunlongrad);
                z = r * Math.Sin(latitudeRadian) + radiusR * Math.Sin(betaRad);
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

            //// Calculate Saturn's Longitude and Latitude
            var lambda0 = Math.Atan2(y, x);
            lambda0 = Angles.RadDeg(lambda0);
            var beta0 = Math.Atan(z / Math.Sqrt(x * x + y * y));
            beta0 = Angles.RadDeg(beta0);

            //// Precess the longitude and Latitude to B1950.0
            var saturn1950 = Precession.PrecessEcliptic(lambda0, beta0, julianDay, 2433282.4235);
            lambda0 = saturn1950.X;
            var lambda0rad = Angles.DegRad(lambda0);
            beta0 = saturn1950.Y;
            var beta0rad = Angles.DegRad(beta0);

            var julianDayE = julianDay - lightTravelTime;

            var t1 = julianDayE - 2411093.0;
            var t2 = t1 / 365.25;
            var t3 = ((julianDayE - 2433282.423) / 365.25) + 1950.0;
            var t4 = julianDayE - 2411368.0;
            var t5 = t4 / 365.25;
            var t6 = julianDayE - 2415020.0;
            var t7 = t6 / 36525.0;
            var t8 = t6 / 365.25;
            var t9 = (julianDayE - 2442000.5) / 365.25;
            var t10 = julianDayE - 2409786.0;
            var t11 = t10 / 36525.0;
            var t112 = t11 * t11;
            var t113 = t112 * t11;

            var w0 = Angles.Mod360(5.095 * (t3 - 1866.39));
            var w0rad = Angles.DegRad(w0);
            var w1 = Angles.Mod360(74.4 + 32.39 * t2);
            var w1rad = Angles.DegRad(w1);
            var w2 = Angles.Mod360(134.3 + 92.62 * t2);
            var w2rad = Angles.DegRad(w2);
            var w3 = Angles.Mod360(42.0 - 0.5118 * t5);
            var w3rad = Angles.DegRad(w3);
            var w4 = Angles.Mod360(276.59 + 0.5118 * t5);
            var w4rad = Angles.DegRad(w4);
            var w5 = Angles.Mod360(267.2635 + 1222.1136 * t7);
            var w5rad = Angles.DegRad(w5);
            var w6 = Angles.Mod360(175.4762 + 1221.5515 * t7);
            var w6rad = Angles.DegRad(w6);
            var w7 = Angles.Mod360(2.4891 + 0.002435 * t7);
            var w7rad = Angles.DegRad(w7);
            var w8 = Angles.Mod360(113.35 - 0.2597 * t7);
            var w8rad = Angles.DegRad(w8);

            var s1 = Math.Sin(Angles.DegRad(28.0817));
            var s2 = Math.Sin(Angles.DegRad(168.8112));
            var c1 = Math.Cos(Angles.DegRad(28.0817));
            var c2 = Math.Cos(Angles.DegRad(168.8112));
            var e1 = 0.05589 - 0.000346 * t7;

            //// Satellite 1
            var longL = Angles.Mod360(127.64 + 381.994497 * t1 - 43.57 * Math.Sin(w0rad) - 0.720 * Math.Sin(3 * w0rad) - 0.02144 * Math.Sin(5 * w0rad));
            var p = 106.1 + 365.549 * t2;
            var anomalyM = longL - p;
            var mrad = Angles.DegRad(anomalyM);
            var c = 2.18287 * Math.Sin(mrad) + 0.025988 * Math.Sin(2 * mrad) + 0.00043 * Math.Sin(3 * mrad);
            var crad = Angles.DegRad(c);
            var lambda1 = Angles.Mod360(longL + c);
            var r1 = 3.06879 / (1 + 0.01905 * Math.Cos(mrad + crad));
            const double gamma1 = 1.563;
            var omega1 = Angles.Mod360(54.5 - 365.072 * t2);

            //// Satellite 2
            longL = Angles.Mod360(200.317 + 262.7319002 * t1 + 0.25667 * Math.Sin(w1rad) + 0.20883 * Math.Sin(w2rad));
            p = 309.107 + 123.44121 * t2;
            anomalyM = longL - p;
            mrad = Angles.DegRad(anomalyM);
            c = 0.55577 * Math.Sin(mrad) + 0.00168 * Math.Sin(2 * mrad);
            crad = Angles.DegRad(c);
            var lambda2 = Angles.Mod360(longL + c);
            var r2 = 3.94118 / (1 + 0.00485 * Math.Cos(mrad + crad));
            const double gamma2 = 0.0262;
            var omega2 = Angles.Mod360(348 - 151.95 * t2);

            //// Satellite 3
            var lambda3 = Angles.Mod360(285.306 + 190.69791226 * t1 + 2.063 * Math.Sin(w0rad) + 0.03409 * Math.Sin(3 * w0rad) + 0.001015 * Math.Sin(5 * w0rad));
            const double r3 = 4.880998;
            const double gamma3 = 1.0976;
            var omega3 = Angles.Mod360(111.33 - 72.2441 * t2);

            //// Satellite 4
            longL = Angles.Mod360(254.712 + 131.53493193 * t1 - 0.0215 * Math.Sin(w1rad) - 0.01733 * Math.Sin(w2rad));
            p = 174.8 + 30.820 * t2;
            anomalyM = longL - p;
            mrad = Angles.DegRad(anomalyM);
            c = 0.24717 * Math.Sin(mrad) + 0.00033 * Math.Sin(2 * mrad);
            crad = Angles.DegRad(c);
            var lambda4 = Angles.Mod360(longL + c);
            var r4 = 6.24871 / (1 + 0.002157 * Math.Cos(mrad + crad));
            const double gamma4 = 0.0139;
            var omega4 = Angles.Mod360(232 - 30.27 * t2);

            //// Satellite 5
            var pdash = 342.7 + 10.057 * t2;
            var pdashrad = Angles.DegRad(pdash);
            var a1 = 0.000265 * Math.Sin(pdashrad) + 0.001 * Math.Sin(w4rad); //// Note the book uses the incorrect constant 0.01*Math.Sin(w4rad);
            var a2 = 0.000265 * Math.Cos(pdashrad) + 0.001 * Math.Cos(w4rad); //// Note the book uses the incorrect constant 0.01*Math.Cos(w4rad);
            var e = Math.Sqrt(a1 * a1 + a2 * a2);
            p = Angles.RadDeg(Math.Atan2(a1, a2));
            var angleN = 345 - 10.057 * t2;
            var angleNrad = Angles.DegRad(angleN);
            var lambdadash = Angles.Mod360(359.244 + 79.69004720 * t1 + 0.086754 * Math.Sin(angleNrad));
            var i = 28.0362 + 0.346898 * Math.Cos(angleNrad) + 0.01930 * Math.Cos(w3rad);
            var omega = 168.8034 + 0.736936 * Math.Sin(angleNrad) + 0.041 * Math.Sin(w3rad);
            var a = 8.725924;
            HelperSubroutine(e, lambdadash, p, a, omega, i, c1, s1, out var r5, out var lambda5, out var gamma5, out var omega5);

            //// Satellite 6
            longL = 261.1582 + 22.57697855 * t4 + 0.074025 * Math.Sin(w3rad);
            var idash = 27.45141 + 0.295999 * Math.Cos(w3rad);
            var idashrad = Angles.DegRad(idash);
            var omegaDash = 168.66925 + 0.628808 * Math.Sin(w3rad);
            var omegadashrad = Angles.DegRad(omegaDash);
            a1 = Math.Sin(w7rad) * Math.Sin(omegadashrad - w8rad);
            a2 = Math.Cos(w7rad) * Math.Sin(idashrad) - Math.Sin(w7rad) * Math.Cos(idashrad) * Math.Cos(omegadashrad - w8rad);
            var g0 = Angles.DegRad(102.8623);
            var psi = Math.Atan2(a1, a2);
            if (a2 < 0) {
                psi += Angles.PI();
            }

            var psideg = Angles.RadDeg(psi);
            var s = Math.Sqrt(a1 * a1 + a2 * a2);
            var g = w4 - omegaDash - psideg;
            double argumentW = 0;
            for (var j = 0; j < 3; j++) {
                argumentW = w4 + 0.37515 * (Math.Sin(2 * Angles.DegRad(g)) - Math.Sin(2 * g0));
                g = argumentW - omegaDash - psideg;
            }

            var grad = Angles.DegRad(g);
            var edash = 0.029092 + 0.00019048 * (Math.Cos(2 * grad) - Math.Cos(2 * g0));
            var q = Angles.DegRad(2 * (w5 - argumentW));
            var b1 = Math.Sin(idashrad) * Math.Sin(omegadashrad - w8rad);
            var b2 = Math.Cos(w7rad) * Math.Sin(idashrad) * Math.Cos(omegadashrad - w8rad) - Math.Sin(w7rad) * Math.Cos(idashrad);
            var atanb1b2 = Math.Atan2(b1, b2);
            var theta = atanb1b2 + w8rad;
            e = edash + 0.002778797 * edash * Math.Cos(q);
            p = argumentW + 0.159215 * Math.Sin(q);
            var u = 2 * w5rad - 2 * theta + psi;
            var h = 0.9375 * edash * edash * Math.Sin(q) + 0.1875 * s * s * Math.Sin(2 * (w5rad - theta));
            lambdadash = Angles.Mod360(longL - 0.254744 * (e1 * Math.Sin(w6rad) + 0.75 * e1 * e1 * Math.Sin(2 * w6rad) + h));
            i = idash + 0.031843 * s * Math.Cos(u);
            omega = omegaDash + (0.031843 * s * Math.Sin(u)) / Math.Sin(idashrad);
            a = 20.216193;
            HelperSubroutine(e, lambdadash, p, a, omega, i, c1, s1, out var r6, out var lambda6, out var gamma6, out var omega6);

            //// Satellite 7
            var eta = 92.39 + 0.5621071 * t6;
            var etarad = Angles.DegRad(eta);
            var zeta = 148.19 - 19.18 * t8;
            var zetarad = Angles.DegRad(zeta);
            theta = Angles.DegRad(184.8 - 35.41 * t9);
            var thetadash = theta - Angles.DegRad(7.5);
            var asValue = Angles.DegRad(176 + 12.22 * t8);
            var bsValue = Angles.DegRad(8 + 24.44 * t8);
            var csValue = bsValue + Angles.DegRad(5);
            argumentW = 69.898 - 18.67088 * t8;
            var phi = 2 * (argumentW - w5);
            var phirad = Angles.DegRad(phi);
            var chi = 94.9 - 2.292 * t8;
            var chirad = Angles.DegRad(chi);
            a = 24.50601 - 0.08686 * Math.Cos(etarad) - 0.00166 * Math.Cos(zetarad + etarad) + 0.00175 * Math.Cos(zetarad - etarad);
            e = 0.103458 - 0.004099 * Math.Cos(etarad) - 0.000167 * Math.Cos(zetarad + etarad) + 0.000235 * Math.Cos(zetarad - etarad) +
                0.02303 * Math.Cos(zetarad) - 0.00212 * Math.Cos(2 * zetarad) + 0.000151 * Math.Cos(3 * zetarad) + 0.00013 * Math.Cos(phirad);
            p = argumentW + 0.15648 * Math.Sin(chirad) - 0.4457 * Math.Sin(etarad) - 0.2657 * Math.Sin(zetarad + etarad) +
                -0.3573 * Math.Sin(zetarad - etarad) - 12.872 * Math.Sin(zetarad) + 1.668 * Math.Sin(2 * zetarad) +
                -0.2419 * Math.Sin(3 * zetarad) - 0.07 * Math.Sin(phirad);
            lambdadash = Angles.Mod360(177.047 + 16.91993829 * t6 + 0.15648 * Math.Sin(chirad) + 9.142 * Math.Sin(etarad) +
                         0.007 * Math.Sin(2 * etarad) - 0.014 * Math.Sin(3 * etarad) + 0.2275 * Math.Sin(zetarad + etarad) +
                         0.2112 * Math.Sin(zetarad - etarad) - 0.26 * Math.Sin(zetarad) - 0.0098 * Math.Sin(2 * zetarad) +
                         -0.013 * Math.Sin(asValue) + 0.017 * Math.Sin(bsValue) - 0.0303 * Math.Sin(phirad));
            i = 27.3347 + 0.643486 * Math.Cos(chirad) + 0.315 * Math.Cos(w3rad) + 0.018 * Math.Cos(theta) - 0.018 * Math.Cos(csValue);
            omega = 168.6812 + 1.40136 * Math.Cos(chirad) + 0.68599 * Math.Sin(w3rad) - 0.0392 * Math.Sin(csValue) + 0.0366 * Math.Sin(thetadash);
            HelperSubroutine(e, lambdadash, p, a, omega, i, c1, s1, out var r7, out var lambda7, out var gamma7, out var omega7);

            //// Satellite 8
            longL = Angles.Mod360(261.1582 + 22.57697855 * t4);
            var w_dash = 91.796 + 0.562 * t7;
            psi = 4.367 - 0.195 * t7;
            var psirad = Angles.DegRad(psi);
            theta = 146.819 - 3.198 * t7;
            phi = 60.470 + 1.521 * t7;
            phirad = Angles.DegRad(phi);
            var PHI = 205.055 - 2.091 * t7;
            edash = 0.028298 + 0.001156 * t11;
            var argumentW0 = 352.91 + 11.71 * t11;
            //// double mu = Angles.Mod360(76.3852 + 4.53795125 * t10);
            var mu = Angles.Mod360(189097.71668440815);
            idash = 18.4602 - 0.9518 * t11 - 0.072 * t112 + 0.0054 * t113;
            idashrad = Angles.DegRad(idash);
            omegaDash = 143.198 - 3.919 * t11 + 0.116 * t112 + 0.008 * t113;
            l = Angles.DegRad(mu - argumentW0);
            g = Angles.DegRad(argumentW0 - omegaDash - psi);
            var g1 = Angles.DegRad(argumentW0 - omegaDash - phi);
            var ls = Angles.DegRad(w5 - w_dash);
            var gs = Angles.DegRad(w_dash - theta);
            var lt = Angles.DegRad(longL - w4);
            var gt = Angles.DegRad(w4 - PHI);
            var u1 = 2 * (l + g - ls - gs);
            var u2 = l + g1 - lt - gt;
            var u3 = l + 2 * (g - ls - gs);
            var u4 = lt + gt - g1;
            var u5 = 2 * (ls + gs);
            a = 58.935028 + 0.004638 * Math.Cos(u1) + 0.058222 * Math.Cos(u2);
            e = edash - 0.0014097 * Math.Cos(g1 - gt) + 0.0003733 * Math.Cos(u5 - 2 * g) +
                0.0001180 * Math.Cos(u3) + 0.0002408 * Math.Cos(l) +
                0.0002849 * Math.Cos(l + u2) + 0.0006190 * Math.Cos(u4);
            var w = 0.08077 * Math.Sin(g1 - gt) + 0.02139 * Math.Sin(u5 - 2 * g) - 0.00676 * Math.Sin(u3) +
                0.01380 * Math.Sin(l) + 0.01632 * Math.Sin(l + u2) + 0.03547 * Math.Sin(u4);
            p = argumentW0 + w / edash;
            lambdadash = mu - 0.04299 * Math.Sin(u2) - 0.00789 * Math.Sin(u1) - 0.06312 * Math.Sin(ls) +
                         -0.00295 * Math.Sin(2 * ls) - 0.02231 * Math.Sin(u5) + 0.00650 * Math.Sin(u5 + psirad);
            i = idash + 0.04204 * Math.Cos(u5 + psirad) + 0.00235 * Math.Cos(l + g1 + lt + gt + phirad) +
                0.00360 * Math.Cos(u2 + phirad);
            var wdash = 0.04204 * Math.Sin(u5 + psirad) + 0.00235 * Math.Sin(l + g1 + lt + gt + phirad) +
                 0.00358 * Math.Sin(u2 + phirad);
            omega = omegaDash + wdash / Math.Sin(idashrad);
            HelperSubroutine(e, lambdadash, p, a, omega, i, c1, s1, out var r8, out var lambda8, out var gamma8, out var omega8);

            u = Angles.DegRad(lambda1 - omega1);
            w = Angles.DegRad(omega1 - 168.8112);
            var gamma1rad = Angles.DegRad(gamma1);
            var x1 = r1 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma1rad) * Math.Sin(w));
            var y1 = r1 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma1rad) + Math.Cos(u) * Math.Sin(w));
            var z1 = r1 * Math.Sin(u) * Math.Sin(gamma1rad);

            u = Angles.DegRad(lambda2 - omega2);
            w = Angles.DegRad(omega2 - 168.8112);
            var gamma2rad = Angles.DegRad(gamma2);
            var x2 = r2 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma2rad) * Math.Sin(w));
            var y2 = r2 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma2rad) + Math.Cos(u) * Math.Sin(w));
            var z2 = r2 * Math.Sin(u) * Math.Sin(gamma2rad);

            u = Angles.DegRad(lambda3 - omega3);
            w = Angles.DegRad(omega3 - 168.8112);
            var gamma3rad = Angles.DegRad(gamma3);
            var x3 = r3 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma3rad) * Math.Sin(w));
            var y3 = r3 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma3rad) + Math.Cos(u) * Math.Sin(w));
            var z3 = r3 * Math.Sin(u) * Math.Sin(gamma3rad);

            u = Angles.DegRad(lambda4 - omega4);
            w = Angles.DegRad(omega4 - 168.8112);
            var gamma4rad = Angles.DegRad(gamma4);
            var x4 = r4 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma4rad) * Math.Sin(w));
            var y4 = r4 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma4rad) + Math.Cos(u) * Math.Sin(w));
            var z4 = r4 * Math.Sin(u) * Math.Sin(gamma4rad);

            u = Angles.DegRad(lambda5 - omega5);
            w = Angles.DegRad(omega5 - 168.8112);
            var gamma5rad = Angles.DegRad(gamma5);
            var x5 = r5 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma5rad) * Math.Sin(w));
            var y5 = r5 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma5rad) + Math.Cos(u) * Math.Sin(w));
            var z5 = r5 * Math.Sin(u) * Math.Sin(gamma5rad);

            u = Angles.DegRad(lambda6 - omega6);
            w = Angles.DegRad(omega6 - 168.8112);
            var gamma6rad = Angles.DegRad(gamma6);
            var x6 = r6 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma6rad) * Math.Sin(w));
            var y6 = r6 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma6rad) + Math.Cos(u) * Math.Sin(w));
            var z6 = r6 * Math.Sin(u) * Math.Sin(gamma6rad);

            u = Angles.DegRad(lambda7 - omega7);
            w = Angles.DegRad(omega7 - 168.8112);
            var gamma7rad = Angles.DegRad(gamma7);
            var x7 = r7 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma7rad) * Math.Sin(w));
            var y7 = r7 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma7rad) + Math.Cos(u) * Math.Sin(w));
            var z7 = r7 * Math.Sin(u) * Math.Sin(gamma7rad);

            u = Angles.DegRad(lambda8 - omega8);
            w = Angles.DegRad(omega8 - 168.8112);
            var gamma8rad = Angles.DegRad(gamma8);
            var x8 = r8 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma8rad) * Math.Sin(w));
            var y8 = r8 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma8rad) + Math.Cos(u) * Math.Sin(w));
            var z8 = r8 * Math.Sin(u) * Math.Sin(gamma8rad);

            const double x9 = 0;
            const double y9 = 0;
            const double z9 = 1;

            //// Now do the rotations, first for the ficticious 9th satellite, so that we can calculate angleD
            Rotations(x9, y9, z9, c1, s1, c2, s2, lambda0rad, beta0rad, out var a4, out var b4, out var c4);
            var elongationD = Math.Atan2(a4, c4);

            //// Now calculate the values for satellite 1
            Rotations(x1, y1, z1, c1, s1, c2, s2, lambda0rad, beta0rad, out a4, out b4, out c4);
            details.Satellite1.TrueRectangularCoordinates.X = a4 * Math.Cos(elongationD) - c4 * Math.Sin(elongationD);
            details.Satellite1.TrueRectangularCoordinates.Y = a4 * Math.Sin(elongationD) + c4 * Math.Cos(elongationD);
            details.Satellite1.TrueRectangularCoordinates.Z = b4;

            //// Now calculate the values for satellite 2
            Rotations(x2, y2, z2, c1, s1, c2, s2, lambda0rad, beta0rad, out a4, out b4, out c4);
            details.Satellite2.TrueRectangularCoordinates.X = a4 * Math.Cos(elongationD) - c4 * Math.Sin(elongationD);
            details.Satellite2.TrueRectangularCoordinates.Y = a4 * Math.Sin(elongationD) + c4 * Math.Cos(elongationD);
            details.Satellite2.TrueRectangularCoordinates.Z = b4;

            //// Now calculate the values for satellite 3
            Rotations(x3, y3, z3, c1, s1, c2, s2, lambda0rad, beta0rad, out a4, out b4, out c4);
            details.Satellite3.TrueRectangularCoordinates.X = a4 * Math.Cos(elongationD) - c4 * Math.Sin(elongationD);
            details.Satellite3.TrueRectangularCoordinates.Y = a4 * Math.Sin(elongationD) + c4 * Math.Cos(elongationD);
            details.Satellite3.TrueRectangularCoordinates.Z = b4;

            //// Now calculate the values for satellite 4
            Rotations(x4, y4, z4, c1, s1, c2, s2, lambda0rad, beta0rad, out a4, out b4, out c4);
            details.Satellite4.TrueRectangularCoordinates.X = a4 * Math.Cos(elongationD) - c4 * Math.Sin(elongationD);
            details.Satellite4.TrueRectangularCoordinates.Y = a4 * Math.Sin(elongationD) + c4 * Math.Cos(elongationD);
            details.Satellite4.TrueRectangularCoordinates.Z = b4;

            //// Now calculate the values for satellite 5
            Rotations(x5, y5, z5, c1, s1, c2, s2, lambda0rad, beta0rad, out a4, out b4, out c4);
            details.Satellite5.TrueRectangularCoordinates.X = a4 * Math.Cos(elongationD) - c4 * Math.Sin(elongationD);
            details.Satellite5.TrueRectangularCoordinates.Y = a4 * Math.Sin(elongationD) + c4 * Math.Cos(elongationD);
            details.Satellite5.TrueRectangularCoordinates.Z = b4;

            //// Now calculate the values for satellite 6
            Rotations(x6, y6, z6, c1, s1, c2, s2, lambda0rad, beta0rad, out a4, out b4, out c4);
            details.Satellite6.TrueRectangularCoordinates.X = a4 * Math.Cos(elongationD) - c4 * Math.Sin(elongationD);
            details.Satellite6.TrueRectangularCoordinates.Y = a4 * Math.Sin(elongationD) + c4 * Math.Cos(elongationD);
            details.Satellite6.TrueRectangularCoordinates.Z = b4;

            //// Now calculate the values for satellite 7
            Rotations(x7, y7, z7, c1, s1, c2, s2, lambda0rad, beta0rad, out a4, out b4, out c4);
            details.Satellite7.TrueRectangularCoordinates.X = a4 * Math.Cos(elongationD) - c4 * Math.Sin(elongationD);
            details.Satellite7.TrueRectangularCoordinates.Y = a4 * Math.Sin(elongationD) + c4 * Math.Cos(elongationD);
            details.Satellite7.TrueRectangularCoordinates.Z = b4;

            //// Now calculate the values for satellite 8
            Rotations(x8, y8, z8, c1, s1, c2, s2, lambda0rad, beta0rad, out a4, out b4, out c4);
            details.Satellite8.TrueRectangularCoordinates.X = a4 * Math.Cos(elongationD) - c4 * Math.Sin(elongationD);
            details.Satellite8.TrueRectangularCoordinates.Y = a4 * Math.Sin(elongationD) + c4 * Math.Cos(elongationD);
            details.Satellite8.TrueRectangularCoordinates.Z = b4;

            //// apply the differential light-time correction
            details.Satellite1.ApparentRectangularCoordinates.X = details.Satellite1.TrueRectangularCoordinates.X + Math.Abs(details.Satellite1.TrueRectangularCoordinates.Z) / 20947 * Math.Sqrt(1 - (details.Satellite1.TrueRectangularCoordinates.X / r1) * (details.Satellite1.TrueRectangularCoordinates.X / r1));
            details.Satellite1.ApparentRectangularCoordinates.Y = details.Satellite1.TrueRectangularCoordinates.Y;
            details.Satellite1.ApparentRectangularCoordinates.Z = details.Satellite1.TrueRectangularCoordinates.Z;

            details.Satellite2.ApparentRectangularCoordinates.X = details.Satellite2.TrueRectangularCoordinates.X + Math.Abs(details.Satellite2.TrueRectangularCoordinates.Z) / 23715 * Math.Sqrt(1 - (details.Satellite2.TrueRectangularCoordinates.X / r2) * (details.Satellite2.TrueRectangularCoordinates.X / r2));
            details.Satellite2.ApparentRectangularCoordinates.Y = details.Satellite2.TrueRectangularCoordinates.Y;
            details.Satellite2.ApparentRectangularCoordinates.Z = details.Satellite2.TrueRectangularCoordinates.Z;

            details.Satellite3.ApparentRectangularCoordinates.X = details.Satellite3.TrueRectangularCoordinates.X + Math.Abs(details.Satellite3.TrueRectangularCoordinates.Z) / 26382 * Math.Sqrt(1 - (details.Satellite3.TrueRectangularCoordinates.X / r3) * (details.Satellite3.TrueRectangularCoordinates.X / r3));
            details.Satellite3.ApparentRectangularCoordinates.Y = details.Satellite3.TrueRectangularCoordinates.Y;
            details.Satellite3.ApparentRectangularCoordinates.Z = details.Satellite3.TrueRectangularCoordinates.Z;

            details.Satellite4.ApparentRectangularCoordinates.X = details.Satellite4.TrueRectangularCoordinates.X + Math.Abs(details.Satellite4.TrueRectangularCoordinates.Z) / 29876 * Math.Sqrt(1 - (details.Satellite4.TrueRectangularCoordinates.X / r4) * (details.Satellite4.TrueRectangularCoordinates.X / r4));
            details.Satellite4.ApparentRectangularCoordinates.Y = details.Satellite4.TrueRectangularCoordinates.Y;
            details.Satellite4.ApparentRectangularCoordinates.Z = details.Satellite4.TrueRectangularCoordinates.Z;

            details.Satellite5.ApparentRectangularCoordinates.X = details.Satellite5.TrueRectangularCoordinates.X + Math.Abs(details.Satellite5.TrueRectangularCoordinates.Z) / 35313 * Math.Sqrt(1 - (details.Satellite5.TrueRectangularCoordinates.X / r5) * (details.Satellite5.TrueRectangularCoordinates.X / r5));
            details.Satellite5.ApparentRectangularCoordinates.Y = details.Satellite5.TrueRectangularCoordinates.Y;
            details.Satellite5.ApparentRectangularCoordinates.Z = details.Satellite5.TrueRectangularCoordinates.Z;

            details.Satellite6.ApparentRectangularCoordinates.X = details.Satellite6.TrueRectangularCoordinates.X + Math.Abs(details.Satellite6.TrueRectangularCoordinates.Z) / 53800 * Math.Sqrt(1 - (details.Satellite6.TrueRectangularCoordinates.X / r6) * (details.Satellite6.TrueRectangularCoordinates.X / r6));
            details.Satellite6.ApparentRectangularCoordinates.Y = details.Satellite6.TrueRectangularCoordinates.Y;
            details.Satellite6.ApparentRectangularCoordinates.Z = details.Satellite6.TrueRectangularCoordinates.Z;

            details.Satellite7.ApparentRectangularCoordinates.X = details.Satellite7.TrueRectangularCoordinates.X + Math.Abs(details.Satellite7.TrueRectangularCoordinates.Z) / 59222 * Math.Sqrt(1 - (details.Satellite7.TrueRectangularCoordinates.X / r7) * (details.Satellite7.TrueRectangularCoordinates.X / r7));
            details.Satellite7.ApparentRectangularCoordinates.Y = details.Satellite7.TrueRectangularCoordinates.Y;
            details.Satellite7.ApparentRectangularCoordinates.Z = details.Satellite7.TrueRectangularCoordinates.Z;

            details.Satellite8.ApparentRectangularCoordinates.X = details.Satellite8.TrueRectangularCoordinates.X + Math.Abs(details.Satellite8.TrueRectangularCoordinates.Z) / 91820 * Math.Sqrt(1 - (details.Satellite8.TrueRectangularCoordinates.X / r8) * (details.Satellite8.TrueRectangularCoordinates.X / r8));
            details.Satellite8.ApparentRectangularCoordinates.Y = details.Satellite8.TrueRectangularCoordinates.Y;
            details.Satellite8.ApparentRectangularCoordinates.Z = details.Satellite8.TrueRectangularCoordinates.Z;

            //// apply the perspective effect correction (here was uppercased W...)
            w = delta / (delta + details.Satellite1.TrueRectangularCoordinates.Z / 2475);
            details.Satellite1.ApparentRectangularCoordinates.X *= w;
            details.Satellite1.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite2.TrueRectangularCoordinates.Z / 2475);
            details.Satellite2.ApparentRectangularCoordinates.X *= w;
            details.Satellite2.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite3.TrueRectangularCoordinates.Z / 2475);
            details.Satellite3.ApparentRectangularCoordinates.X *= w;
            details.Satellite3.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite4.TrueRectangularCoordinates.Z / 2475);
            details.Satellite4.ApparentRectangularCoordinates.X *= w;
            details.Satellite4.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite5.TrueRectangularCoordinates.Z / 2475);
            details.Satellite5.ApparentRectangularCoordinates.X *= w;
            details.Satellite5.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite6.TrueRectangularCoordinates.Z / 2475);
            details.Satellite6.ApparentRectangularCoordinates.X *= w;
            details.Satellite6.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite7.TrueRectangularCoordinates.Z / 2475);
            details.Satellite7.ApparentRectangularCoordinates.X *= w;
            details.Satellite7.ApparentRectangularCoordinates.Y *= w;

            w = delta / (delta + details.Satellite8.TrueRectangularCoordinates.Z / 2475);
            details.Satellite8.ApparentRectangularCoordinates.X *= w;
            details.Satellite8.ApparentRectangularCoordinates.Y *= w;

            return details;
        }

        /// <summary>
        /// Transfers the detail values.
        /// </summary>
        /// <param name="details1">The details1.</param>
        /// <param name="details2">The details2.</param>
        private static void TransferDetailValues(SaturnMoonsDetails details1, SaturnMoonsDetails details2) {
            details1.Satellite1.BInEclipse = details2.Satellite1.BInOccultation;
            details1.Satellite2.BInEclipse = details2.Satellite2.BInOccultation;
            details1.Satellite3.BInEclipse = details2.Satellite3.BInOccultation;
            details1.Satellite4.BInEclipse = details2.Satellite4.BInOccultation;
            details1.Satellite5.BInEclipse = details2.Satellite5.BInOccultation;
            details1.Satellite6.BInEclipse = details2.Satellite6.BInOccultation;
            details1.Satellite7.BInEclipse = details2.Satellite7.BInOccultation;
            details1.Satellite8.BInEclipse = details2.Satellite8.BInOccultation;
            details1.Satellite1.BInShadowTransit = details2.Satellite1.BInTransit;
            details1.Satellite2.BInShadowTransit = details2.Satellite2.BInTransit;
            details1.Satellite3.BInShadowTransit = details2.Satellite3.BInTransit;
            details1.Satellite4.BInShadowTransit = details2.Satellite4.BInTransit;
            details1.Satellite5.BInShadowTransit = details2.Satellite5.BInTransit;
            details1.Satellite6.BInShadowTransit = details2.Satellite6.BInTransit;
            details1.Satellite7.BInShadowTransit = details2.Satellite7.BInTransit;
            details1.Satellite8.BInShadowTransit = details2.Satellite8.BInTransit;
        }

        /// <summary>
        /// Saturn the details from the sun.
        /// </summary>
        /// <param name="julianDay">The julian day.</param>
        /// <param name="sunlongrad">The sunlongrad.</param>
        /// <param name="betaRad">The betaRad.</param>
        /// <param name="earthLightTravelTime">The earth light travel time.</param>
        /// <param name="sunLightTravelTime">The sun light travel time.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static SaturnMoonsDetails SaturnDetailsFromTheSun(double julianDay, double sunlongrad, double betaRad, double earthLightTravelTime, double sunLightTravelTime) {
            var details2 = CalculateHelper(julianDay + sunLightTravelTime - earthLightTravelTime, sunlongrad, betaRad, 0);
            FillInPhenomenaDetails(details2.Satellite1);
            FillInPhenomenaDetails(details2.Satellite2);
            FillInPhenomenaDetails(details2.Satellite3);
            FillInPhenomenaDetails(details2.Satellite4);
            FillInPhenomenaDetails(details2.Satellite5);
            FillInPhenomenaDetails(details2.Satellite6);
            FillInPhenomenaDetails(details2.Satellite7);
            FillInPhenomenaDetails(details2.Satellite8);
            return details2;
        }

        /// <summary>
        /// Saturn the details from the earth.
        /// </summary>
        /// <param name="julianDay">The julian day.</param>
        /// <param name="sunlongrad">The sunlongrad.</param>
        /// <param name="betaRad">The betaRad.</param>
        /// <param name="radiusR">The R.</param>
        /// <returns> Returns value. </returns>
        private static SaturnMoonsDetails SaturnDetailsFromTheEarth(double julianDay, double sunlongrad, double betaRad, double radiusR) {
            var details1 = CalculateHelper(julianDay, sunlongrad, betaRad, radiusR);
            FillInPhenomenaDetails(details1.Satellite1);
            FillInPhenomenaDetails(details1.Satellite2);
            FillInPhenomenaDetails(details1.Satellite3);
            FillInPhenomenaDetails(details1.Satellite4);
            FillInPhenomenaDetails(details1.Satellite5);
            FillInPhenomenaDetails(details1.Satellite6);
            FillInPhenomenaDetails(details1.Satellite7);
            FillInPhenomenaDetails(details1.Satellite8);
            return details1;
        }

        /// <summary>
        /// Rotations of the specified X.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="s1">The s1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="s2">The s2.</param>
        /// <param name="lambda0">The lambda0.</param>
        /// <param name="beta0">The beta0.</param>
        /// <param name="a4">The a4.</param>
        /// <param name="b4">The b4.</param>
        /// <param name="c4">The c4.</param>
        private static void Rotations(double x, double y, double z, double c1, double s1, double c2, double s2, double lambda0, double beta0, out double a4, out double b4, out double c4) {
            //// Rotation towards the plane of the ecliptic
            var a1 = x;
            var b1 = c1 * y - s1 * z;
            var c11 = s1 * y + c1 * z;

            //// Rotation towards the vernal equinox
            var a2 = c2 * a1 - s2 * b1;
            var b2 = s2 * a1 + c2 * b1;
            var c21 = c11;

            var a3 = a2 * Math.Sin(lambda0) - b2 * Math.Cos(lambda0);
            var b3 = a2 * Math.Cos(lambda0) + b2 * Math.Sin(lambda0);
            var c3 = c21;

            a4 = a3;
            b4 = b3 * Math.Cos(beta0) + c3 * Math.Sin(beta0);
            c4 = c3 * Math.Cos(beta0) - b3 * Math.Sin(beta0);
        }

        /// <summary>
        /// Fills the in phenomena details.
        /// </summary>
        /// <param name="detail">The detail.</param>
        private static void FillInPhenomenaDetails(SaturnMoonDetail detail) {
            var y1 = 1.108601 * detail.ApparentRectangularCoordinates.Y;

            var r = y1 * y1 + detail.ApparentRectangularCoordinates.X * detail.ApparentRectangularCoordinates.X;

            if (r < 1) {
                if (detail.ApparentRectangularCoordinates.Z < 0) {
                    //// Satellite nearer to Earth than Saturn, so it must be a transit not an occultation
                    detail.BInTransit = true;
                    detail.BInOccultation = false;
                }
                else {
                    detail.BInTransit = false;
                    detail.BInOccultation = true;
                }
            }
            else {
                detail.BInTransit = false;
                detail.BInOccultation = false;
            }
        }
    }
}
