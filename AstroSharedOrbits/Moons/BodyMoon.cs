// <copyright file="BodyMoon.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Moons {
    using System;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Coordinates;
    using AstroSharedOrbits.Orbits;
    using JetBrains.Annotations;

    /// <summary>
    /// Initializes a new instance of the BodyMoon class.
    /// </summary>
    [UsedImplicitly]
    public class BodyMoon : Orbit {
        #region Fields

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyMoon" /> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="name">The name.</param>
        public BodyMoon(string code, string name)
            : base(code, name) {
        }

        #region Properties
        /// <summary>
        /// Gets Mean longitude of the Moon.
        /// </summary>
        /// <value> Property description. </value>
        [UsedImplicitly]
        public double MeanLongitude => this.Ld;

        /// <summary>
        /// Gets Mean elongation of the Moon.
        /// </summary>
        /// <value> Property description. </value>
        public double MeanElongation => this.D;

        /// <summary>
        /// Gets the sun mean anomaly.
        /// </summary>
        /// <value>The sun mean anomaly.</value>
        [UsedImplicitly]
        public double SunMeanAnomaly => this.M;

        /// <summary>
        /// Gets the mean anomaly.
        /// </summary>
        /// <value>The mean anomaly.</value>
        public double MeanAnomaly => this.Md;

        /// <summary>
        /// Gets the mean latitude F.
        /// </summary>
        /// <value>The mean latitude.</value>
        [UsedImplicitly]
        public double MeanLatitude => this.LatitudeF;

        /// <summary>
        /// Gets or sets the right ascension.
        /// </summary>
        /// <value>
        /// The right ascension.
        /// </value>
        public double RightAscension { get; protected set; }

        /// <summary>
        /// Gets or sets the declination.
        /// </summary>
        /// <value>
        /// The declination.
        /// </value>
        public double Declination { get; protected set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        [UsedImplicitly]
        public double Distance { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets the sigma L.
        /// </summary>
        /// <value>The sigma L.</value>
        protected double SigmaL {
            get {
                var earthEccentricity = Planets.BodyEarth.Eccentricity(this.Time.CurrentJulianDate);
                var esquared = earthEccentricity * earthEccentricity;

                double value = 0;
                foreach (var q in OrbitalData.MoonPerturbationQuotients.MoonLongitudeQuotients) {
                    var thisSigma = q.A * Angles.Sinus(q.D * this.D + q.M * this.M + q.Mdash * this.Md + q.LatitudeF * this.LatitudeF);

                    switch (q.M)
                    {
                        case -1:
                        case 1:
                            thisSigma *= earthEccentricity;
                            break;
                        case -2:
                        case 2:
                            thisSigma *= esquared;
                            break;
                    }

                    value += thisSigma;
                }

                //// Finally the additive terms
                value += 3958 * Angles.Sinus(this.A1);
                value += 1962 * Angles.Sinus(this.Ld - this.LatitudeF);
                value += 318 * Angles.Sinus(this.A2);
                return value / 1000000;
            }
        }

        /// <summary>
        /// Gets the sigma B.
        /// </summary>
        /// <value>The sigma B.</value>
        protected double SigmaB {
            get {
                double value = 0;
                var earthEccentricity = Planets.BodyEarth.Eccentricity(this.Time.CurrentJulianDate);
                foreach (var q in OrbitalData.MoonPerturbationQuotients.MoonLatitudeQuotients) {
                    var thisSigma = q.A * Angles.Sinus(q.D * this.D + q.M * this.M + q.Mdash * this.Md + q.LatitudeF * this.LatitudeF);
                    if (q.M != 0) {
                        thisSigma *= earthEccentricity;
                    }

                    value += thisSigma;
                }

                //// Finally the additive terms
                value -= 2235 * Angles.Sinus(this.Ld);
                value += 382 * Angles.Sinus(this.A3);
                value += 175 * Angles.Sinus(this.A1 - this.LatitudeF);
                value += 175 * Angles.Sinus(this.A1 + this.LatitudeF);
                value += 127 * Angles.Sinus(this.Ld - this.Md);
                value -= 115 * Angles.Sinus(this.Ld + this.Md);

                return value / 1000000;
            }
        }

        /// <summary>
        /// Gets or sets the a1.
        /// </summary>
        /// <value>The a1.</value>
        protected double A1 { private get; set; }

        /// <summary>
        /// Gets or sets the a2.
        /// </summary>
        /// <value>The a2.</value>
        protected double A2 { private get; set; }

        /// <summary>
        /// Gets or sets the a3.
        /// </summary>
        /// <value>The a3.</value>
        protected double A3 { private get; set; }

        /// <summary>
        /// Gets or sets Mean longitude of the Moon.
        /// </summary>
        /// <value> Property description. </value>
        protected double Ld { get; set; }   //// 

        /// <summary>
        /// Gets or sets Mean elongation of the Moon.
        /// </summary>
        /// <value> Property description. </value>
        protected double D { get; set; }   //// 

        /// <summary>
        /// Gets or sets Moon's mean anomaly.
        /// </summary>
        /// <value> Property description. </value>
        protected double M { private get; set; }   //// 

        /// <summary>
        /// Gets or sets Sun's mean anomaly.
        /// </summary>
        /// <value> Property description. </value>
        protected double Md { get; set; }   //// 

        /// <summary>
        /// Gets or sets Moon's  argument of latitude.
        /// </summary>
        /// <value> Property description. </value>
        protected double LatitudeF { get; set; }   //// 

        /// <summary>
        /// Gets the sigma R.
        /// </summary>
        /// <value>The sigma value.</value>
        protected double SigmaR {
            get {
                //// int nRCoefficients = sizeof(MoonCoefficients1) / sizeof(MoonCoefficient1);
                //// assert(sizeof(MoonCoefficients2) / sizeof(MoonCoefficient2) == nRCoefficients);
                double value = 0;
                foreach (var q in OrbitalData.MoonPerturbationQuotients.MoonLongitudeQuotients) {
                    var thisSigma = q.B * Angles.Cosin(q.D * this.D + q.M * this.M + q.Mdash * this.Md + q.LatitudeF * this.LatitudeF);
                    if (q.M != 0) {
                        thisSigma *= this.E;
                    }

                    value += thisSigma;
                }

                return value / 1000;
            }
        }
        #endregion

        #region Naughter
        /// <summary>
        /// Geocentric the moon semidiameter.
        /// </summary>
        /// <param name="givenDelta">The delta.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double GeocentricMoonSemidiameter(double givenDelta) {
            return Angles.RadDeg(0.272481 * 6378.14 / givenDelta) * 3600;
        }

        /// <summary>
        /// Topocentric the moon semidiameter.
        /// </summary>
        /// <param name="distanceDelta">The distance delta.</param>
        /// <param name="delta">The delta.</param>
        /// <param name="h">The h.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="height">The height.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double TopocentricMoonSemidiameter(double distanceDelta, double delta, double h, double latitude, double height) {
            //// Convert to radians
            h = Angles.HoursToRadians(h);
            delta = Angles.DegRad(delta);

            var pi = Math.Asin(6378.14 / distanceDelta);
            var a = Math.Cos(delta) * Math.Sin(h);
            var b = Math.Cos(delta) * Math.Cos(h) - Globe.RhoCosThetaPrime(latitude, height) * Math.Sin(pi);
            var c = Math.Sin(delta) - Globe.RhoSinThetaPrime(latitude, height) * Math.Sin(pi);
            var q = Math.Sqrt(a * a + b * b + c * c);

            var s = Angles.DegRad(GeocentricMoonSemidiameter(distanceDelta) / 3600);
            return Angles.RadDeg(Math.Asin(Math.Sin(s) / q)) * 3600;
        }

        #endregion
    }
}