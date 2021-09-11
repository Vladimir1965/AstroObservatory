// <copyright file="BodyMoonMeeus.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>
//// In order to calculate an accurate position of the Moon, it is necessary to take into account hundreds of periodic terms 
//// in the Moon's longitude, latitude and parallax. 
//// In his book, Jean Meeus presents a rigorous method for calculating the Moon's position, 
//// however he limits his solution to about 100 of the most important periodic terms, being satisfied with a small inaccuracy. 
//// However, even this less accurate solution is too cumbersome to present here. 
//// Fortunately, Meeus provides suggestions to simplify the method to produce a low accuracy solution. 
//// The accuracy appears to be about ± 0.3o in longitude, ± 0.1o in latitude, and ± 0.01o in parallax.

namespace AstroSharedOrbits.Moons {
    using System;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Coordinates;
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedOrbits.OrbitalData;
    using JetBrains.Annotations;

    /// <summary>
    /// Initializes a new instance of the BodyMoon class.
    /// </summary>
    [UsedImplicitly]
    public sealed class BodyMoonMeeus : BodyMoon {
        #region Series
        /// <summary>
        /// Mean longitude of the Moon.
        /// </summary>
        private readonly double[] ldv = { 218.3164477, 481267.88123421, -0.0015786, 1.0 / 538841, -1.0 / 65194000 };

        /// <summary>
        /// Mean elongation of the Moon.
        /// </summary>
        private readonly double[] dv = { 297.8501921, 445267.1114034, -0.0018819, 1.0 / 545868, -1.0 / 113065000 }; //// [Deg/Jdi]

        /// <summary>
        ///  Sun's mean anomaly.
        /// </summary>
        private readonly double[] mv = { 357.5291092, 35999.0502909, -0.0001536, 0, 0 };   //// [Deg/Jdi]

        /// <summary>
        /// Moon's  mean argument of latitude (Mean distance of Moon from its ascending node).
        /// </summary>
        private readonly double[] fv = { 93.2720950, 483202.0175233, -0.0036539, 1.0 / 3526000, 1.0 / 863310000 };    //// [Deg/Jdi]

        /// <summary>
        /// Moon's mean anomaly.
        /// </summary>
        private readonly double[] mdv = { 134.9633964, 477198.8675055, 0.0087414, 1.0 / 69699, -1.0 / 14712000 };   //// [Deg/Jdi]

        /// <summary>
        /// Ascending node.
        /// </summary>
        private readonly double[] lw = { 125.0445479, -1934.1362891, +0.0020754, +1.0 / 467441, -1.0 / 60616000 };

        /// <summary>
        /// Longitude of the perigee.
        /// </summary>
        private readonly double[] lp = { 83.3532465, +4069.0137287, -0.0103200, -1.0 / 80053, +1.0 / 18999000 };
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyMoonMeeus"/> class.
        /// </summary>
        public BodyMoonMeeus()
            : base("MO", "Meeus") {
            this.PerTime = 0.0;             ////
            this.Body.Mass = 7.349e22;           //// [kg]
            this.Body.Radius = 1.7380e6;         //// [m]
            ////  timeT=2.73217e1;
            this.Body.J = 0.00;                  //// // [deg]
            this.Knke = 5;                 //// //
        }

        #region Properties
        /// <summary>
        /// Gets Ecliptic the longitude.
        /// </summary>
        /// <value> Property description. </value>
        /// <returns> Returns value. </returns>
        public double EclipticLongitude {
            get {
                //// And finally apply the nutation in longitude
                var nutationInLong = Nutation.NutationInLongitude(this.Time.CurrentJulianDate);
                return Angles.Mod360(this.Longitude + nutationInLong / 3600);
            }
        }

        /// <summary>
        /// Gets Ecliptic the latitude.
        /// </summary>
        /// <value> Property description. </value>
        /// <returns> Returns value. </returns>
        public double EclipticLatitude => this.Point.Latitude;

        /// <summary>
        /// Gets Radius vector.
        /// </summary>
        /// <value> Property description. </value>
        /// <returns> Returns value. </returns>
        public double RadiusVector => (385000.56 + this.SigmaR) * 1000;

        #endregion

        #region Public static
        /// <summary>
        /// Arguments the of latitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double ArgumentOfLatitude(double julianDay) {
            var timeT = (julianDay - 2451545) / 36525;
            var timeSquared = timeT * timeT;
            var timeCubed = timeSquared * timeT;
            var dT4 = timeCubed * timeT;
            return Angles.Mod360(93.2720950 + 483202.0175233 * timeT - 0.0036539 * timeSquared - timeCubed / 3526000 + dT4 / 863310000);
        }

        /// <summary>
        /// Radiuses the vector to horizontal parallax.
        /// </summary>
        /// <param name="radiusVector">The radius vector.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double RadiusVectorToHorizontalParallax(double radiusVector) {
            return Angles.RadDeg(Math.Asin(6378.14 / radiusVector));
        }

        /// <summary>
        /// Horizontals the parallax to radius vector.
        /// </summary>
        /// <param name="parallax">The parallax.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double HorizontalParallaxToRadiusVector(double parallax) {
            return 6378.14 / Math.Sin(Angles.DegRad(parallax));
        }
        #endregion

        /// <summary>
        /// Init Schlyter.
        /// </summary>
        public override void Init() {
            this.Time.EpochOrbit = 2451545.0;
            this.Time.EpochEquinox = 2451545.0;
            //// According to Chapront:
            double[] lw1 = { 125.0445479, -0.052953766, 1.555684e-12, 0.0 };
            double[] i = { 5.1454, 0.0, 0.0, 0.0 };
            double[] w = { 318.3086986, 0.16435729, -9.291377e-12, 0.0 };
            double[] a = { 384747981, 0.0, 0.0, 0.0 };
            double[] e = { 0.054900, 0.0, 0.0, 0.0 };
            double[] vm = { 134.9633964, 13.06499295, 6.552402e-12, 0.0 };
            this.NormElements = new NormalElements(lw1, i, w, a, e, vm);
        }

        /// <summary>
        /// Prepare Chapront.
        /// </summary>
        protected override void Prepare() {
            this.A1 = Angles.Mod360(119.75 + (131.849 * this.Time.Jecy));
            this.A2 = Angles.Mod360(53.09 + (479264.290 * this.Time.Jecy));
            this.A3 = Angles.Mod360(313.45 + (481266.484 * this.Time.Jecy));

            this.PrepareNormal();
            this.EclipticObliquity = Systems.EarthSystem.Earth.EclipticObliquity;

            //// Then calculate the angles L', M, M', D and F by means of the following formulae, 
            //// in which the various constants are expressed in degrees and decimals.
            this.Ld = Angles.Mod360(AstroMath.HornerSum(this.ldv, this.Time.Jecy));  //// Moon's mean longitude 
            this.D = Angles.Mod360(AstroMath.HornerSum(this.dv, this.Time.Jecy));    //// Moon's mean elongation
            this.M = Angles.Mod360(AstroMath.HornerSum(this.mv, this.Time.Jecy));    //// Sun's mean anomaly
            this.Md = Angles.Mod360(AstroMath.HornerSum(this.mdv, this.Time.Jecy));  //// Moon's mean anomaly
            this.LatitudeF = Angles.Mod360(AstroMath.HornerSum(this.fv, this.Time.Jecy));    //// Moon's mean argument of latitude

            //// this.LW = Moon.MeanLongitudeAscendingNode(this.CurrentJulianDate); 
            this.LW = Angles.Mod360(AstroMath.HornerSum(this.lw, this.Time.Jecy));    //// Ascending node
            this.LP = Angles.Mod360(AstroMath.HornerSum(this.lp, this.Time.Jecy));    //// Perigee

            //// double timeT = this.JECY;

            //// double EarthExcentricity = BodyEarth.Eccentricity(this.CurrentJulianDate);
            this.CalculateDependentProperties();

            //// With the values of L', M, M', D and LatitudeF calculated, 
            //// l, b and p can be obtained by means of the following expressions where, 
            //// again, all the coefficients are given in degrees and decimals.
            //// double sla = 6.288750 * Angles.Sinus(Md) + 1.274018 * Angles.Sinus(2 * this.D - Md) + 0.658309 * Angles.Sinus(2 * this.D)
            ////    + 0.213616 * Angles.Sinus(2 * Md) - 0.185596 * Angles.Sinus(this.M) - 0.114336 * Angles.Sinus(2 * LatitudeF);
            //// double sl = this.SigmaL;
            var l = Ld + this.SigmaL;

            //// double slb = 5.128189 * Angles.Sinus(LatitudeF) + 0.280606 * Angles.Sinus(Md + LatitudeF) + 0.277693 * Angles.Sinus(Md - LatitudeF)
            ////    + 0.173238 * Angles.Sinus(2 * this.D - LatitudeF) + 0.055413 * Angles.Sinus(2 * this.D + LatitudeF - Md) + 0.046272 * Angles.Sinus(2 * this.D - LatitudeF - Md);*/
            //// double sb = this.SigmaB;
            var b = this.SigmaB;

            this.Point.Longitude = l;
            this.Point.Latitude = b;

            //// this.RT = LargoLibAstro.Moon.RadiusVector(this.CurrentJulianDate) * 1000;
            this.Point.RT = this.RadiusVector;

            this.Point.XH = this.Point.RT * Angles.Cosin(this.Point.Longitude) * Angles.Cosin(this.Point.Latitude);
            this.Point.YH = this.Point.RT * Angles.Sinus(this.Point.Longitude) * Angles.Cosin(this.Point.Latitude);
            this.Point.ZH = this.Point.RT * Angles.Sinus(this.Point.Latitude);

            var ecliptic = new CoordinateEcliptic2D {
                Lambda = this.Point.Longitude,
                Beta = this.Point.Latitude
            };

            var equatorial = ecliptic.ToEquatorial(this.EclipticObliquity);
            this.RightAscension = equatorial.Alpha;
            this.Declination = equatorial.Delta;
            
            //// If necessary, l and b can be converted to right ascension a and declination d using the following formulae.
            //// double tana1 = Angles.Sinus(l) * Angles.Cosin(this.EclipticObliquity) - Angles.Tangs(b) * Angles.Sinus(this.EclipticObliquity);
            //// double tana2 = Angles.Cosin(l);
            //// double a = Angles.ArcTan2(tana1, tana2);
            //// this.RightAscension = Angles.Mod360(a);
            //// double sind = Angles.Sinus(b) * Angles.Cosin(this.EclipticObliquity) + Angles.Cosin(b) * Angles.Sinus(this.EclipticObliquity) * Angles.Sinus(l);
            //// double d = Angles.ArcSinus(sind);
            //// this.Declination = Angles.Mod360(d);            
            //// The equatorial horizontal parallax p of the Moon too is obtained. When the parallax p is known, 
            //// the distance between the centers of Earth and Moon, in kilometers, can be found from.
            var p = 0.950724 + 0.051818 * Angles.Cosin(Md) + 0.009531 * Angles.Cosin(2 * this.D - Md)
                       + 0.007843 * Angles.Cosin(2 * this.D) + 0.002824 * Angles.Cosin(2 * Md) + 0.000857 * Angles.Cosin(2 * this.D + Md);
            var distance = 6378.14 / Angles.Sinus(p);
            this.Distance = distance;
        }
    }
}

//// http://www.braeunig.us/space/plntpos.htm#moon
