// <copyright file="BodySun.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Systems
{
    using JetBrains.Annotations;
    using AstroSharedOrbits.Orbits;
    using System;
    using AstroSharedClasses.Coordinates;
    using AstroSharedClasses.Computation;
    using AstroSharedOrbits.OrbitalData;

    /// <summary> Body Sun Orbit. </summary>
    public sealed class BodySun : Orbit {
        /// <summary>
        /// Initializes a new instance of the BodySun class.
        /// </summary>
        /// <param name="code">Shortcut of the name.</param>
        public BodySun(string code)
            : base(code, "Sun" + code) {
            this.Time.EpochOrbit = 2451543.5;  //// (2451545.0)
            this.Time.EpochEquinox = 2451543.5;
            this.Body.Mass = 1.9891e30;    //// Sun 
            this.Body.Radius = 0.46523e-5 * AstroMath.AstroUnit * 1000;
            //// this.previousState = new SunState();
        }

        #region Public Properties

        /// <summary>
        /// Gets Influence Value.
        /// </summary>
        /// <value> Property description. </value>
        public double InfluenceValue { get; private set; }

        /// <summary>
        /// Gets Influence Longitude.
        /// </summary>
        /// <value> Property description. </value>
        public double InfluenceLgh { get; private set; }

        /// <summary>
        /// Gets Influence Radial.
        /// </summary>
        /// <value> Property description. </value>
        public double InfluenceRadial { get; private set; }

        /// <summary>
        /// Gets Influence Tangential.
        /// </summary>
        /// <value> Property description. </value>
        public double InfluenceTangential { get; private set; }

        /// <summary>
        /// Gets Influence Phi.
        /// </summary>
        /// <value> Property description. </value>
        public double InfluencePhi { get; private set; }
        ////public double _XH { get { return _XH; } set { _XH=value; } }

        #endregion

        #region Protected Properties
        #endregion

        #region Private Properties

        /// <summary>
        /// Gets First Body Num.
        /// </summary>
        /// <value> Property description. </value>
        [UsedImplicitly]
        private int FirstBodyNum { get; }

        /// <summary>
        /// Gets Last Body Num.
        /// </summary>
        /// <value> Property description. </value>
        [UsedImplicitly]
        private int LastBodyNum { get; }

        #endregion

        #region Naughter
        /// <summary>
        /// Times the of start of rotation.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double TimeOfStartOfRotation(long c) {
            var jed = 2398140.2270 + 27.2752316 * c;

            var m = Angles.Mod360(281.96 + 26.882476 * c);
            m = Angles.DegRad(m);

            jed += 0.1454 * Math.Sin(m) - 0.0085 * Math.Sin(2 * m) - 0.0141 * Math.Cos(2 * m);

            return jed;
        }

        /// <summary>
        /// Suns the semidiameter A.
        /// </summary>
        /// <param name="delta">The delta.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double SunSemidiameterA(double delta) {
            return 959.63 / delta;
        }

        /// <summary>
        /// Geometric the ecliptic longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double GeometricEclipticLongitude(double julianDay) {
            return Angles.Mod360(Planets.BodyEarth.EclipticLongitude(julianDay) + 180);
        }

        /// <summary>
        /// Geometric the ecliptic latitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double GeometricEclipticLatitude(double julianDay) {
            return -Planets.BodyEarth.EclipticLatitude(julianDay);
        }

        /// <summary>
        /// Geometric the ecliptic longitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double GeometricEclipticLongitudeJ2000(double julianDay) {
            return Angles.Mod360(Planets.BodyEarth.EclipticLongitudeJ2000(julianDay) + 180);
        }

        /// <summary>
        /// Geometric the ecliptic latitude J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double GeometricEclipticLatitudeJ2000(double julianDay) {
            return -Planets.BodyEarth.EclipticLatitudeJ2000(julianDay);
        }

        /// <summary>
        /// Geometric the F k5 ecliptic longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double GeometricFK5EclipticLongitude(double julianDay) {
            //// Convert to the FK5 system
            var longitude = GeometricEclipticLongitude(julianDay);
            var latitude = GeometricEclipticLatitude(julianDay);
            longitude += FK5.CorrectionInLongitude(longitude, latitude, julianDay);

            return longitude;
        }

        /// <summary>
        /// Geometric the F k5 ecliptic latitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double GeometricFK5EclipticLatitude(double julianDay) {
            //// Convert to the FK5 system
            var longitude = GeometricEclipticLongitude(julianDay);
            var latitude = GeometricEclipticLatitude(julianDay);
            var sunLatCorrection = FK5.CorrectionInLatitude(longitude, julianDay);
            latitude += sunLatCorrection;

            return latitude;
        }

        /// <summary>
        /// Apparent ecliptic longitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double ApparentEclipticLongitude(double julianDay) {
            var longitude = GeometricFK5EclipticLongitude(julianDay);

            //// Apply the correction in longitude due to nutation
            longitude += CoordinateTransformation.DmsToDegrees(0, 0, Nutation.NutationInLongitude(julianDay));

            //// Apply the correction in longitude due to aberration
            var r = Planets.BodyEarth.RadiusVector(julianDay);
            longitude -= CoordinateTransformation.DmsToDegrees(0, 0, 20.4898 / r);

            return longitude;
        }

        /// <summary>
        /// Apparent ecliptic latitude.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double ApparentEclipticLatitude(double julianDay) {
            return GeometricFK5EclipticLatitude(julianDay);
        }

        /// <summary>
        /// Equatorial the rectangular coordinates mean equinox.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Coordinate3D EquatorialRectangularCoordinatesMeanEquinox(double julianDay) {
            var longitude = Angles.DegRad(GeometricFK5EclipticLongitude(julianDay));
            var latitude = Angles.DegRad(GeometricFK5EclipticLatitude(julianDay));
            var r = Planets.BodyEarth.RadiusVector(julianDay);
            var epsilon = Angles.DegRad(Nutation.MeanObliquityOfEcliptic(julianDay));

            var value = new Coordinate3D {
                X = r * Math.Cos(latitude) * Math.Cos(longitude),
                Y = r * (Math.Cos(latitude) * Math.Sin(longitude) * Math.Cos(epsilon) - Math.Sin(latitude) * Math.Sin(epsilon)),
                Z = r * (Math.Cos(latitude) * Math.Sin(longitude) * Math.Sin(epsilon) + Math.Sin(latitude) * Math.Cos(epsilon))
            };

            return value;
        }

        /// <summary>
        /// Ecliptic rectangular coordinates J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Coordinate3D EclipticRectangularCoordinatesJ2000(double julianDay) {
            var longitude = GeometricEclipticLongitudeJ2000(julianDay);
            longitude = Angles.DegRad(longitude);
            var latitude = GeometricEclipticLatitudeJ2000(julianDay);
            latitude = Angles.DegRad(latitude);
            var r = Planets.BodyEarth.RadiusVector(julianDay);

            var value = new Coordinate3D();
            var coslatitude = Math.Cos(latitude);
            value.X = r * coslatitude * Math.Cos(longitude);
            value.Y = r * coslatitude * Math.Sin(longitude);
            value.Z = r * Math.Sin(latitude);

            return value;
        }

        /// <summary>
        /// Equatorial the rectangular coordinates J2000.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Coordinate3D EquatorialRectangularCoordinatesJ2000(double julianDay) {
            var value = EclipticRectangularCoordinatesJ2000(julianDay);
            value = FK5.ConvertVsopToFK5J2000(value);

            return value;
        }

        /// <summary>
        /// Equatorial the rectangular coordinates B1950.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static Coordinate3D EquatorialRectangularCoordinatesB1950(double julianDay) {
            var value = EclipticRectangularCoordinatesJ2000(julianDay);
            value = FK5.ConvertVsopToFK5B1950(value);

            return value;
        }

        /// <summary>
        /// Equatorial the rectangular coordinates any equinox.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <param name="julianDayEquinox">The julian day equinox.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static Coordinate3D EquatorialRectangularCoordinatesAnyEquinox(double julianDay, double julianDayEquinox) {
            var value = EquatorialRectangularCoordinatesJ2000(julianDay);
            value = FK5.ConvertVsopToFK5AnyEquinox(value, julianDayEquinox);

            return value;
        }
        #endregion

        /* Temporarily not used
        /// <summary>
        /// Solars the coordinates low precision.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SolarCoordinatesLowPrecision(double julianDay) {
            throw new NotImplementedException();
            double T; double L0; double M; double e; double C;
            double Θ; double ν;  double R; double Ω; double λ;
            T = (julianDay - 2451545.0) / 36525;
            L0 = 280.46646 + (36000.76983 * T) + (0.0003032 * Math.Pow(T, 2));
            M = 357.52911 + (35999.05029 * T) - (0.0001537 * Math.Pow(T, 2));
            e = 0.016708634 - (0.000042037 * T) - (0.0000001267 * Math.Pow(T, 2));
            C = (1.914602 - (0.004817 * T) - 0.000014 * Math.Pow(T, 2)) * Math.Sin(M);
            C += (0.019993 - (0.000101 * T)) * Math.Sin(2 * M);
            C += 0.000289 * Math.Sin(3 * M);
            Θ = L0 + C;
            ν = M + C;
            R = (1.000001018 * (1 - Math.Pow(e, 2))) / 1 + (e * Math.Cos(ν));
            Ω = 125.04 - (1934.136 * T);
            λ = Θ - 0.00569 - (0.00478 * Math.Sin(Ω));
            Debug.WriteLine("T\t= " + T);         Debug.WriteLine("L0\t= " + L0);
            Debug.WriteLine("M\t= " + M);         Debug.WriteLine("e\t= " + e);
            Debug.WriteLine("C\t= " + C);         Debug.WriteLine("Θ\t= " + Θ);
            Debug.WriteLine("ν\t= " + ν);         Debug.WriteLine("R\t= " + R);
            return 0.0;
        }
        */

        /// <summary>
        /// Set Julian Date.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        public override void SetJulianDate(double givenJulianDay)
        {
            this.Time.CurrentJulianDate = givenJulianDay;
            /*
            SpacePoint c = GetBarycentre();
            this.previousState.GraviLongitude = this.Gravicentre.Longitude;
            this.previousState.ActualAngleSpeed = this.BarySunBehavior.ActualAngleSpeed;

            this.Point.XH = -c.XH;
            this.Point.YH = -c.YH;
            this.Point.ZH = -c.ZH;
            this.Point.RT = c.RT;
            this.Point.Longitude = Angles.Mod360(180 + c.Longitude);
            this.Point.Latitude = 180 + c.Latitude;
            double dX = this.Point.XH - this.previousState.XH,
                   dY = this.Point.YH - this.previousState.YH,
                   dZ = this.Point.ZH - this.previousState.ZH;
            var ds = Math.Sqrt((dX * dX) + (dY * dY) + (dZ * dZ));
            var dt = this.Time.CurrentJulianDate - this.previousState.CurrentJulianDate;
            this.ActualSpeed = ds / dt;
            var dv = this.ActualSpeed - this.previousState.ActualSpeed;
            this.ActualAcceleration = dv / dt;
            //// this.DeterminePeriod(dt);

            this.previousState.CurrentJulianDate = this.Time.CurrentJulianDate; 

            this.Point.SavePointAsPrevious(); */
        }

        /*
        private void DeterminePeriod(double dt)
        {
            double dLongitude;
            if (true)
            {
                dLongitude = (this.Longitude >= this.previousState.Longitude) ? this.Longitude - this.previousState.Longitude : this.Longitude + 360 - this.previousState.Longitude;
            }

            this.ActualAngleSpeed = dLongitude / dt;
            this.ActualPeriod = 360 / this.ActualAngleSpeed / 365.25;
            ////xx if (PreviousState.XH!=0 && ActualPeriod>0.5 && ActualPeriod<1000) {
            if (ActualPeriod < 11.00) //// 2018/02
            {
                return;
            }

            if (!this.previousState.ZeroState)
            {
                this.TotalJulianDay += dt;
                this.TotalLgh += dLongitude;
            }

            this.MeanAngleSpeed = this.TotalLgh / this.TotalJulianDay;
            this.MeanAngularPeriod = 360 / this.MeanAngleSpeed / 365.25;
            return;
        } 

            /// <summary>
            /// Compute Influences.
            /// </summary>
            public void ComputeInfluences() {
            double totalXV = 0, totalYV = 0;
            for (var i = this.FirstBodyNum; i <= this.LastBodyNum; i++) {
                //// if (i!=(int)AstPlanet.Mars) // tmp
                var orbitB = SolarSystem.Singleton.Orbit[i];
                var v = orbitB.Body.Mass / orbitB.Point.RT / orbitB.Point.RT;
                //// V = 1e10*orbitB.Mass/orbitB.RT/orbitB.RT/orbitB.RT;
                var l = orbitB.Longitude;
                //// *** mod 180 test ***
                //// L = Angles.Mod180(L);
                var xv = v * Angles.Cosin(l);
                var yv = v * Angles.Sinus(l);
                totalXV = totalXV + xv;
                totalYV = totalYV + yv;
            }

            this.InfluenceValue = Math.Sqrt((totalXV * totalXV) + (totalYV * totalYV));
            this.InfluenceLgh = Angles.Mod360(Angles.ArcTan2(totalYV, totalXV));
            this.InfluencePhi = Angles.NormalSymmetricAngle360(this.InfluenceLgh - this.Longitude - 180);
            ////_InfluencePhi = Angles.NormalSymmetricAngle360(SolarSystem.Jupiter.Longitude-_Lgh);
            this.InfluenceRadial = this.InfluenceValue * Angles.Cosin(this.InfluencePhi);
            this.InfluenceTangential = this.InfluenceValue * Angles.Sinus(this.InfluencePhi);
        }
        */
    }
}
