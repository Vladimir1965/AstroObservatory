// <copyright file="Elliptical.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>
//// PJN / 05-06-2006 1. Fixed a bug in Calculate(double julianDay, SolarSystemObject object)  where the correction 
//// for nutation was incorrectly using the Mean obliquity of the ecliptic instead of the true value. The results 
//// from the test program now agree much more closely with the example Meeus provides which is the position 
//// of Venus on 1992 Dec. 20 at 0h Dynamical Time. I've also checked the positions against the JPL Horizons web site 
//// and the agreement is much better. Because the True obliquity of the Ecliptic is defined as the mean obliquity 
//// of the ecliptic plus the nutation in obliquity, it is relatively easy to determine the magnitude  of error this was causing. 
//// From the chapter on Nutation in the book, and specifically the table which gives the cosine coefficients for nutation in 
//// obliquity you can see that the absolute worst case error would be the sum of the absolute values of all of the coefficients 
//// and would have been c. 10 arc seconds of degree, which is not a small amount!. This value would be an absolute worst 
//// case and I would expect the average error value to be much much smaller (probably much less than an arc second). 
//// Anyway the bug has now been fixed. Thanks to Patrick Wong for pointing out this rather significant bug. 
//// PJN / 10-11-2008 1. Fixed a bug in Calculate(double julianDay, const CAAEllipticalObjectElements& elements) 
//// in the calculation of the heliocentric rectangular ecliptical, the heliocentric ecliptical latitude and 
//// the heliocentric ecliptical longitude coordinates. The code incorrectly used the value "omega" instead of "w" in its calculation 
//// of the value "u". Unfortunately there is no worked examples in Jean Meeus's book for these particular values, 
//// hence resulting in my coding errors. Thanks to Carsten A. Arnholm for reporting this bug. 

namespace AstroSharedOrbits.OrbitalData
{
    using System;
    using System.Diagnostics;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Coordinates;
    using AstroSharedClasses.Enums;
    using AstroSharedClasses.OrbitalElements;
    using JetBrains.Annotations;

    /// <summary>
    /// Elliptical calculations.
    /// </summary>
    public static class Elliptical {
        /// <summary>
        /// Calculates the specified julianDay.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="obj">The object.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static EllipticalPlanetaryDetails Calculate(double julianDay, SolarSystemObject obj) {
            //// What will the the return value
            var details = new EllipticalPlanetaryDetails();

            var julianDay0 = julianDay;
            double l0 = 0;
            double b0 = 0;
            double r0 = 0;
            double cosB0 = 0;
            if (obj != SolarSystemObject.Sun) {
                l0 = Planets.BodyEarth.EclipticLongitude(julianDay0);
                b0 = Planets.BodyEarth.EclipticLatitude(julianDay0);
                r0 = Planets.BodyEarth.RadiusVector(julianDay0);
                l0 = Angles.DegRad(l0);
                b0 = Angles.DegRad(b0);
                cosB0 = Math.Cos(b0);
            }

            InitialValues(obj, julianDay0, out var longL, out var lattB, out var radiusR);

            var bRecalc = true;
            var bFirstRecalc = true;
            double lPrevious = 0;
            double bPrevious = 0;
            double rPrevious = 0;
            while (bRecalc) {
                CurrentValues(obj, ref longL, julianDay0, ref lattB, ref radiusR);

                if (!bFirstRecalc) {
                    bRecalc = (Math.Abs(longL - lPrevious) > 0.00001) || (Math.Abs(lattB - bPrevious) > 0.00001) || (Math.Abs(radiusR - rPrevious) > 0.000001);
                    lPrevious = longL;
                    bPrevious = lattB;
                    rPrevious = radiusR;
                }
                else {
                    bFirstRecalc = false;
                }

                //// Calculate the new value
                if (!bRecalc) {
                    continue;
                }

                double distance;
                if (obj != SolarSystemObject.Sun) {
                    var longitudeRadian = Angles.DegRad(longL);
                    var latitudeRadian = Angles.DegRad(lattB);
                    var cosB = Math.Cos(latitudeRadian);
                    var cosL = Math.Cos(longitudeRadian);
                    var x = radiusR * cosB * cosL - r0 * cosB0 * Math.Cos(l0);
                    var y = radiusR * cosB * Math.Sin(longitudeRadian) - r0 * cosB0 * Math.Sin(l0);
                    var z = radiusR * Math.Sin(latitudeRadian) - r0 * Math.Sin(b0);
                    distance = Math.Sqrt(x * x + y * y + z * z);
                }
                else {
                    distance = radiusR; //// Distance to the sun from the earth is in fact the radius vector
                }

                //// Prepare for the next loop around
                julianDay0 = julianDay - DistanceToLightTime(distance);
            }

            FinishComputation(julianDay, longL, lattB, radiusR, r0, cosB0, l0, b0, details);
            return details;
        }

        /// <summary>
        /// Calculates the specified julianDay.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="elements">The elements.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static EllipticalObjectDetails Calculate(double julianDay, out EllipticalObjectElements elements) {
            elements = new EllipticalObjectElements();
            var epsilon = Nutation.MeanObliquityOfEcliptic(elements.JulianDayEquinox);

            var julianDay0 = julianDay;

            //// What will be the return value
            var details = new EllipticalObjectDetails();

            epsilon = Angles.DegRad(epsilon);
            var omega = Angles.DegRad(elements.Omega);
            var w = Angles.DegRad(elements.W);
            var i = Angles.DegRad(elements.I);

            var sinEpsilon = Math.Sin(epsilon);
            var cosEpsilon = Math.Cos(epsilon);
            var sinOmega = Math.Sin(omega);
            var cosOmega = Math.Cos(omega);
            var cosi = Math.Cos(i);
            var sini = Math.Sin(i);

            var vF = cosOmega;
            var vG = sinOmega * cosEpsilon;
            var vH = sinOmega * sinEpsilon;
            var vP = -sinOmega * cosi;
            var vQ = cosOmega * cosi * cosEpsilon - sini * sinEpsilon;
            var vR = cosOmega * cosi * sinEpsilon + sini * cosEpsilon;
            var a = Math.Sqrt(vF * vF + vP * vP);
            var b = Math.Sqrt(vG * vG + vQ * vQ);
            var c = Math.Sqrt(vH * vH + vR * vR);
            var vA = Math.Atan2(vF, vP);
            var vB = Math.Atan2(vG, vQ);
            var vC = Math.Atan2(vH, vR);
            var n = Orbits.Orbit.MeanMotionFromSemiMajorAxis(elements.A);

            var sunCoord = Systems.BodySun.EquatorialRectangularCoordinatesAnyEquinox(julianDay, elements.JulianDayEquinox);

            for (var j = 0; j < 2; j++) {
                var vM = n * (julianDay0 - elements.T);
                var vE = Kepler.Calculate(vM, elements.E);
                vE = Angles.DegRad(vE);
                var v = 2 * Math.Atan(Math.Sqrt((1 + elements.E) / (1 - elements.E)) * Math.Tan(vE / 2));
                var radiusR = elements.A * (1 - elements.E * Math.Cos(vE));
                var x = radiusR * a * Math.Sin(vA + w + v);
                var y = radiusR * b * Math.Sin(vB + w + v);
                var z = radiusR * c * Math.Sin(vC + w + v);

                if (j == 0) {
                    details.HeliocentricRectangularEquatorial.X = x;
                    details.HeliocentricRectangularEquatorial.Y = y;
                    details.HeliocentricRectangularEquatorial.Z = z;

                    //// Calculate the heliocentric ecliptic coordinates also
                    var u = w + v;
                    var cosu = Math.Cos(u);
                    var sinu = Math.Sin(u);

                    details.HeliocentricRectangularEcliptical.X = radiusR * (cosOmega * cosu - sinOmega * sinu * cosi);
                    details.HeliocentricRectangularEcliptical.Y = radiusR * (sinOmega * cosu + cosOmega * sinu * cosi);
                    details.HeliocentricRectangularEcliptical.Z = radiusR * sini * sinu;

                    details.HeliocentricEclipticLongitude = Angles.Mod360(Angles.RadDeg(Math.Atan2(details.HeliocentricRectangularEcliptical.Y, details.HeliocentricRectangularEcliptical.X)));
                    details.HeliocentricEclipticLatitude = Angles.RadDeg(Math.Asin(details.HeliocentricRectangularEcliptical.Z / radiusR));
                }

                var psi = sunCoord.X + x;
                var nu = sunCoord.Y + y;
                var sigma = sunCoord.Z + z;

                var alpha = Math.Atan2(nu, psi);
                alpha = Angles.RadDeg(alpha);
                var delta = Math.Atan2(sigma, Math.Sqrt(psi * psi + nu * nu));
                delta = Angles.RadDeg(delta);
                var distance = Math.Sqrt(psi * psi + nu * nu + sigma * sigma);

                if (j == 0) {
                    details.TrueGeocentricRA = Angles.MapTo0To24Range(alpha / 15);
                    details.TrueGeocentricDeclination = delta;
                    details.TrueGeocentricDistance = distance;
                    details.TrueGeocentricLightTime = DistanceToLightTime(distance);
                }
                else {
                    details.AstrometricGeocentricRA = Angles.MapTo0To24Range(alpha / 15);
                    details.AstrometricGeocentricDeclination = delta;
                    details.AstrometricGeocentricDistance = distance;
                    details.AstrometricGeocentricLightTime = DistanceToLightTime(distance);

                    var res = Math.Sqrt(sunCoord.X * sunCoord.X + sunCoord.Y * sunCoord.Y + sunCoord.Z * sunCoord.Z);

                    details.Elongation = Math.Acos((res * res + distance * distance - radiusR * radiusR) / (2 * res * distance));
                    details.Elongation = Angles.RadDeg(details.Elongation);

                    details.PhaseAngle = Math.Acos((radiusR * radiusR + distance * distance - res * res) / (2 * radiusR * distance));
                    details.PhaseAngle = Angles.RadDeg(details.PhaseAngle);
                }

                if (j == 0) {
                    //// Prepare for the next loop around
                    julianDay0 = julianDay - details.TrueGeocentricLightTime;
                }
            }

            return details;
        }

        /// <summary>
        /// Distances to light time.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <returns> Returns value. </returns>
        public static double DistanceToLightTime(double distance) {
            return distance * 0.0057755183;
        }

        /// <summary>
        /// Currents the values.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="longL">The longL.</param>
        /// <param name="julianDay0">The J d0.</param>
        /// <param name="lattB">The lattB.</param>
        /// <param name="radiusR">The R.</param>
        private static void CurrentValues(SolarSystemObject obj, ref double longL, double julianDay0, ref double lattB, ref double radiusR) {
            switch (obj) {
                case SolarSystemObject.Sun: {
                        longL = Systems.BodySun.GeometricEclipticLongitude(julianDay0);
                        lattB = Systems.BodySun.GeometricEclipticLatitude(julianDay0);
                        radiusR = Planets.BodyEarth.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Mercury: {
                        longL = Planets.BodyMercury.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyMercury.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyMercury.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Venus: {
                        longL = Planets.BodyVenus.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyVenus.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyVenus.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Mars: {
                        longL = Planets.BodyMars.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyMars.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyMars.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Jupiter: {
                        longL = Planets.BodyJupiter.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyJupiter.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyJupiter.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Saturn: {
                        longL = Planets.BodySaturn.EclipticLongitude(julianDay0);
                        lattB = Planets.BodySaturn.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodySaturn.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Uranus: {
                        longL = Planets.BodyUranus.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyUranus.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyUranus.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Neptune: {
                        longL = Planets.BodyNeptune.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyNeptune.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyNeptune.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Pluto: {
                        longL = Dwarfs.BodyPluto.EclipticLongitude(julianDay0);
                        lattB = Dwarfs.BodyPluto.EclipticLatitude(julianDay0);
                        radiusR = Dwarfs.BodyPluto.RadiusVector(julianDay0);
                        break;
                    }

                default: {
                        Debug.Assert(false, "Reason for the assert");
                        break;
                    }
            }
        }

        /// <summary>
        /// Finishes the computation.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="longL">The longL.</param>
        /// <param name="givenB">The givenB.</param>
        /// <param name="radiusR">The R.</param>
        /// <param name="r0">The r0.</param>
        /// <param name="cosB0">The cos b0.</param>
        /// <param name="l0">The l0.</param>
        /// <param name="b0">The b0.</param>
        /// <param name="details">The details.</param>
        private static void FinishComputation(double julianDay, double longL, double givenB, double radiusR, double r0, double cosB0, double l0, double b0, EllipticalPlanetaryDetails details) {
            var longitudeRadian = Angles.DegRad(longL);
            var latitudeRadian = Angles.DegRad(givenB);
            var cosB = Math.Cos(latitudeRadian);
            var cosL = Math.Cos(longitudeRadian);
            var x = radiusR * cosB * cosL - r0 * cosB0 * Math.Cos(l0);
            var y = radiusR * cosB * Math.Sin(longitudeRadian) - r0 * cosB0 * Math.Sin(l0);
            var z = radiusR * Math.Sin(latitudeRadian) - r0 * Math.Sin(b0);
            var x2 = x * x;
            var y2 = y * y;

            details.ApparentGeocentricLatitude = Angles.RadDeg(Math.Atan2(z, Math.Sqrt(x2 + y2)));
            details.ApparentGeocentricDistance = Math.Sqrt(x2 + y2 + z * z);
            details.ApparentGeocentricLongitude =
                Angles.Mod360(Angles.RadDeg(Math.Atan2(y, x)));
            details.ApparentLightTime = DistanceToLightTime(details.ApparentGeocentricDistance);

            //// Adjust for Aberration
            //// vl 2014/02  temporarily disabled 
            //// Coordinate2D Aberration = LargoLibAstro.Aberration.EclipticAberration( details.ApparentGeocentricLongitude,
            ////   details.ApparentGeocentricLatitude, julianDay);  details.ApparentGeocentricLongitude += Aberration.X;
            //// details.ApparentGeocentricLatitude += Aberration.Y;

            //// convert to the FK5 system
            var deltaLong = FK5.CorrectionInLongitude(
                details.ApparentGeocentricLongitude,
                details.ApparentGeocentricLatitude,
                julianDay);
            details.ApparentGeocentricLatitude += FK5.CorrectionInLatitude(details.ApparentGeocentricLongitude, julianDay);
            details.ApparentGeocentricLongitude += deltaLong;

            //// Correct for nutation
            var nutationInLongitude = Nutation.NutationInLongitude(julianDay);
            var epsilon = Nutation.TrueObliquityOfEcliptic(julianDay);
            details.ApparentGeocentricLongitude += CoordinateTransformation.DmsToDegrees(0, 0, nutationInLongitude);

            //// Convert to RA and Dec
            var ecliptic = new CoordinateEcliptic2D {
                Lambda = details.ApparentGeocentricLongitude,
                Beta = details.ApparentGeocentricLatitude
            };

            var apparentEqu = ecliptic.ToEquatorial(epsilon);
            details.ApparentGeocentricRA = apparentEqu.AlphaHours;
            details.ApparentGeocentricDeclination = apparentEqu.Delta;
        }

        /// <summary>
        /// Initials the values.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="julianDay0">The J d0.</param>
        /// <param name="longL">The longL.</param>
        /// <param name="lattB">The lattB.</param>
        /// <param name="radiusR">The R.</param>
        private static void InitialValues(SolarSystemObject obj, double julianDay0, out double longL, out double lattB, out double radiusR) {
            //// Calculate the initial values
            longL = 0;
            lattB = 0;
            radiusR = 0;
            switch (obj) {
                case SolarSystemObject.Sun: {
                        longL = Systems.BodySun.GeometricEclipticLongitude(julianDay0);
                        lattB = Systems.BodySun.GeometricEclipticLatitude(julianDay0);
                        radiusR = Planets.BodyEarth.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Mercury: {
                        longL = Planets.BodyMercury.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyMercury.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyMercury.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Venus: {
                        longL = Planets.BodyVenus.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyVenus.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyVenus.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Mars: {
                        longL = Planets.BodyMars.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyMars.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyMars.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Jupiter: {
                        longL = Planets.BodyJupiter.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyJupiter.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyJupiter.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Saturn: {
                        longL = Planets.BodySaturn.EclipticLongitude(julianDay0);
                        lattB = Planets.BodySaturn.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodySaturn.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Uranus: {
                        longL = Planets.BodyUranus.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyUranus.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyUranus.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Neptune: {
                        longL = Planets.BodyNeptune.EclipticLongitude(julianDay0);
                        lattB = Planets.BodyNeptune.EclipticLatitude(julianDay0);
                        radiusR = Planets.BodyNeptune.RadiusVector(julianDay0);
                        break;
                    }

                case SolarSystemObject.Pluto: {
                        longL = Dwarfs.BodyPluto.EclipticLongitude(julianDay0);
                        lattB = Dwarfs.BodyPluto.EclipticLatitude(julianDay0);
                        radiusR = Dwarfs.BodyPluto.RadiusVector(julianDay0);
                        break;
                    }

                default: {
                        Debug.Assert(false, "Reason for the assert");
                        break;
                    }
            }
        }
    }
}
