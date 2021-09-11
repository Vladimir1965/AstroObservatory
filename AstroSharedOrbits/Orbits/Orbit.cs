// <copyright file="Orbit.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Orbits
{
    using JetBrains.Annotations;
    using AstroSharedClasses.Enums;
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedOrbits.Systems;
    using System;
    using System.Text;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Calendars;

    /// <summary>
    /// Data structure containing orbital elements of objects that orbit the sun.
    /// </summary>
    public class Orbit {
        /// <summary>
        /// Initializes a new instance of the <see cref="Orbit"/> class.
        /// </summary>
        /// <param name="givenAbbreviation">The given abbreviation.</param>
        /// <param name="givenName">Name of the given.</param>
        public Orbit(string givenAbbreviation, string givenName) {
            this.Vsop87 = new Vsop87();
            this.Variant = AlgVariant.VarBretagnon82;
            this.Point = new SpacePoint();
            this.Body = new SpaceBody(givenAbbreviation, givenName);
            this.Bretagnon = new Bretagnon();
            this.Time = new AstroTime();
            this.Enabled = true;
            //// _NormElements = new NormalElements(...);
            //// _BretElements = new BretagnonElements(...);
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public AstroTime Time { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public SpaceBody Body { get; set; }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        /// <value>
        /// The point.
        /// </value>
        public SpacePoint Point { get; set; }

        /// <summary>
        /// Gets or sets the bretagnon.
        /// </summary>
        /// <value>
        /// The bretagnon.
        /// </value>
        public Bretagnon Bretagnon { get; set; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude => this.Point.Longitude;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Orbit" /> is enabled.
        /// </summary>
        /// <value>
        /// Property description.
        /// </value>
        public bool Enabled { get; set; }           ////

        /// <summary>
        /// Gets or sets the index of the alignment.
        /// </summary>
        /// <value>
        /// The index of the alignment.
        /// </value>
        public double AlignmentIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the quadrature.
        /// </summary>
        /// <value>
        /// The index of the quadrature.
        /// </value>
        public double QuadratureIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the perihelion.
        /// </summary>
        /// <value>
        /// The index of the perihelion.
        /// </value>
        public double PerihelionIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the biangular.
        /// </summary>
        /// <value>
        /// The index of the biangular.
        /// </value>
        public double BiangularIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the triangular.
        /// </summary>
        /// <value>
        /// The index of the triangular.
        /// </value>
        public double TriangularIndex { get; set; }
        
        /// <summary>
        /// Gets or sets Variant of algorithm.
        /// </summary>
        /// <value> Property description. </value>
        public AlgVariant Variant { protected get; set; }  //// 

        /// <summary>
        /// Gets Mean distance (semimajor axis).
        /// </summary>
        /// <value> Property description. </value>
        public double A { get; private set; }

        /// <summary>
        /// Gets Mean anomaly.
        /// </summary>
        /// <value> Property description. </value>
        public double VM { get; private set; }

        /// <summary>
        /// Gets Mean Longitude of pseudo planet.
        /// </summary>
        /// <value> Property description. </value>
        public double LM { get; private set; }

        /// <summary>
        /// Gets or sets Longitude of the ascending node.
        /// </summary>
        /// <value> Property description. </value>
        public double LW { get; protected set; }

        /// <summary>
        ///  Gets or sets Longitude of the perihelion.
        /// </summary>
        /// <value> Property description. </value>
        public double LP { get; protected set; }

        /// <summary>
        /// Gets or sets the mean period.
        /// </summary>
        /// <value>
        /// The mean period.
        /// </value>
        public double MeanPeriod { get; protected set; }

        /// <summary>
        /// Gets Qper.
        /// </summary>
        /// <value> Property description. </value>
        [UsedImplicitly]
        public double Qper => this.A * (1 - this.E);

        /// <summary>
        /// Gets Qapo.
        /// </summary>
        /// <value> Property description. </value>
        [UsedImplicitly]
        public double Qapo => this.A * (1 + this.E);

        /// <summary>
        /// Gets the intensity.
        /// </summary>
        /// <value>
        /// The intensity.
        /// </value>
        [UsedImplicitly]
        public double Intensity => this.Body.Mass / this.Point.RT / this.Point.RT;

        /// <summary>
        /// Gets the potential.
        /// </summary>
        /// <value>
        /// The potential.
        /// </value>
        [UsedImplicitly]
        public double Potential => this.Body.Mass / this.Point.RT;

        /// <summary>
        /// Gets or sets The obliquity of the ecliptic.
        /// </summary>
        /// <value>
        /// The ecliptic obliquity.
        /// </value>
        public double EclipticObliquity { get; protected set; }

        /// <summary>
        /// Gets or sets the sun right ascension.
        /// </summary>
        /// <value>
        /// The sun right ascension.
        /// </value>
        public double SunRightAscension { get; protected set; }

        /// <summary>
        /// Gets or sets the sun declination.
        /// </summary>
        /// <value>
        /// The sun declination.
        /// </value>
        public double SunDeclination { get; protected set; }

        /// <summary>
        /// Gets or sets Nombre de pas Kepler equation.
        /// </summary>
        /// <value> Property description. </value>
        public int Knke { private get; set; }   ////

        /// <summary>
        /// Gets Eccentricity.
        /// </summary>
        /// <value> Property description. </value>
        public double E { get; private set; }
        #endregion

        #region Protected Properties
        /// <summary>
        /// Gets or sets Normal Elements.
        /// </summary>
        /// <value> Property description. </value>
        protected NormalElements NormElements { private get; set; }

        /// <summary>
        /// Gets or sets Bretagnon Elements.
        /// </summary>
        /// <value> Property description. </value>
        protected BretagnonElements BretElements { private get; set; }

        /// <summary>
        /// Gets Vsop87.
        /// </summary>
        /// <value> Property description. </value>
        protected Vsop87 Vsop87 { get;  }

        /// <summary>
        ///  Gets or sets Perihelion time.    
        /// </summary>
        /// <value> Property description. </value>
        protected double PerTime { [UsedImplicitly] private get; set; }   ////  
        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets Inclination of orbit (eclip.).
        /// </summary>
        /// <value> Property description. </value>
        private double I { get; set; }   //// 

        /// <summary>
        /// Gets or sets Argument of the perihelion.
        /// </summary>
        /// <value> Property description. </value>
        private double W { get; set; }   
        
        /// <summary>
        /// Gets or sets Excentrique anomaly.
        /// </summary>
        /// <value> Property description. </value>
        private double VE { get; set; }  

        /// <summary>
        /// Gets or sets True anomaly.
        /// </summary>
        /// <value> Property description. </value>
        private double VT { get; set; }  

        /// <summary>
        /// Gets or sets Argument de latitude.
        /// </summary>
        /// <value> Property description. </value>
        private double AC { get; set; }   

        /// <summary>
        /// Gets or sets Declination angle.
        /// </summary>
        /// <value> Property description. </value>
        private double DC { get; set; }  

        /// <summary>
        /// Gets or sets Coefficient sqrt ((1+E)/(1-E)).
        /// </summary>
        private double Coex { get; set; }                        

        /// <summary>
        /// Gets or sets Half eccentric anomaly.
        /// </summary>
        private double VE2 { get; set; }

        #endregion

        //// private double RE;            //// distance soleilthis.planet
        //// private double Lwh;           //// nodal latitude heliocentric

        #region Public static methods (Elliptical)
        /// <summary>
        /// Instantaneouses the velocity.
        /// </summary>
        /// <param name="r">The radius.</param>
        /// <param name="a">The value A.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double InstantaneousVelocity(double r, double a) {
            return 42.1219 * Math.Sqrt((1 / r) - (1 / (2 * a)));
        }

        /// <summary>
        /// Velocities at perihelion.
        /// </summary>
        /// <param name="e">The eccentricity e.</param>
        /// <param name="a">The value A.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VelocityAtPerihelion(double e, double a) {
            return 29.7847 / Math.Sqrt(a) * Math.Sqrt((1 + e) / (1 - e));
        }

        /// <summary>
        /// Velocities at aphelion.
        /// </summary>
        /// <param name="e">The value e.</param>
        /// <param name="a">The value A.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double VelocityAtAphelion(double e, double a) {
            return 29.7847 / Math.Sqrt(a) * Math.Sqrt((1 - e) / (1 + e));
        }

        /// <summary>
        /// Length of the ellipse.
        /// </summary>
        /// <param name="e">The value e.</param>
        /// <param name="a">The value A.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double LengthOfEllipse(double e, double a) {
            var b = a * Math.Sqrt(1 - e * e);
            return Angles.PI() * (3 * (a + b) - Math.Sqrt((a + 3 * b) * (3 * a + b)));
        }

        /// <summary>
        /// Semis the major axis from perihelion distance.
        /// </summary>
        /// <param name="q">The value  q.</param>
        /// <param name="e">The value  e.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SemiMajorAxisFromPerihelionDistance(double q, double e) {
            return q / (1 - e);
        }

        /// <summary>
        /// Means the motion from semi major axis.
        /// </summary>
        /// <param name="a">The value A.</param>
        /// <returns> Returns value. </returns>
        public static double MeanMotionFromSemiMajorAxis(double a) {
            return 0.9856076686 / (a * Math.Sqrt(a));
        }
        #endregion

        /// <summary>
        /// Schlyter or Chapront.
        /// </summary>
        public virtual void Init() { 
        }

        /// <summary>
        /// Set Julian Date.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        public virtual void SetJulianDate(double givenJulianDay) {
            if (Math.Abs(this.Time.CurrentJulianDate - givenJulianDay) < 0.00000001) { ////0.000001
                return;
            }

            this.Time.CurrentJulianDate = givenJulianDay;
            this.Time.JYear = Julian.Year(givenJulianDay);
            this.Time.JEDay = this.Time.CurrentJulianDate - this.Time.EpochOrbit;
            this.Time.Jecy = this.Time.JEDay / 36525; // [JCy]
            switch (this.Variant) {
                case AlgVariant.VarBretagnon82: 
                    this.PrepareBretagnon82();
                    this.CalculateDependentProperties();
                    //// this.Perturbate();
                    break;
                case AlgVariant.VarBretagnon87: 
                    this.PrepareBretagnon87(); 
                    this.CalculateDependentProperties();
                    break;
                case AlgVariant.VarSchlyter: 
                    this.PrepareNormal();
                    this.CalculateDependentProperties();
                    this.Perturbate();
                    break;
                case AlgVariant.VarChapront: 
                    this.Prepare(); 
                    this.CalculateDependentProperties();
                    break;
                case AlgVariant.VarNormal:
                    this.PrepareNormal();
                    this.CalculateDependentProperties();
                    break;
                case AlgVariant.VarMeeus:
                    this.Prepare();
                    break;
                case AlgVariant.VarNaughter:
                    this.Prepare();
                    break;
                case AlgVariant.None:
                    break;
                //// Resharper default: break;
            }
        }

        #region Perturbations
        /// <summary>
        /// Compute perturbations.
        /// </summary>
        public virtual void Perturbate() {
        }
        #endregion

        #region To String
        /// <summary>Generate a string representation of the event.</summary>
        /// <returns>A string representation of the event.</returns>
        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append(this.Body.Name);
            return sb.ToString();
        }
        #endregion

        #region Basic Orbital Elements At Given Date
        /// <summary>
        /// Prepare Normal.
        /// </summary>
        protected void PrepareNormal() {
            this.LW = this.NormElements.LW(this.Time.JEDay);
            this.I = this.NormElements.I(this.Time.JEDay);
            this.W = this.NormElements.W(this.Time.JEDay);
            this.A = this.NormElements.A(this.Time.JEDay);
            this.E = this.NormElements.E(this.Time.JEDay);
            this.VM = this.NormElements.VM(this.Time.JEDay);
            this.LP = Angles.Mod360(this.LW + this.W);     // Longitude perihelie
            this.LM = Angles.Mod360(this.LP + this.VM);    // Longitude moyenne
        }

        /// <summary>
        /// Prepare Chapront.
        /// </summary>
        protected virtual void Prepare() {
        }

        #endregion

        /// <summary>
        /// Calculates the dependent properties.
        /// </summary>
        protected virtual void CalculateDependentProperties() {
            ////  #ifdef COMPUTE_POSITION
            this.Coex = Math.Sqrt((1 + this.E) / (1 - this.E));
            this.VE = Kepler.KeplerFunction(this.VM, this.E, this.Knke);   // anomalie excentrique (voir Bouiges p. 26)
            this.VE2 = this.VE / 2;
            //// Calcul optimis‚ en vitesse de la Longitude h‚liocentrique
            this.VT = 2 * Angles.ArcTan2(Angles.Sinus(this.VE2) * this.Coex, Angles.Cosin(this.VE2)); // anomalie vraie
            ////> this.RE  = this.A * (1 - this.E * Angles.Cosin(this.VE));         // distance soleil planet
            this.Point.RT = this.A * (1 - (this.E * this.E)) / (1 + (this.E * Angles.Cosin(this.VT)));       // radius
            this.AC = this.VT + this.LP - this.LW;                    ////  Argument de latitude
            //// Longitude heliocentric
            this.Point.Longitude = Angles.Mod360(this.LW + Angles.ArcTan2(Angles.Sinus(this.AC) * Angles.Cosin(this.I), Angles.Cosin(this.AC)));
            ////     #ifdef RECTANGULAR
            this.DC = Angles.ArcTan2(Angles.Sinus(this.AC) * Angles.Cosin(this.I), Angles.Cosin(this.AC)); // declination
            //// this.Lwh = Angles.Mod360(this.DC + this.LW);    // nodal latitude heliocentr
            //// latitude heliocentrique
            this.Point.Latitude = Angles.ArcTan2(Angles.Sinus(this.DC) * Angles.Sinus(this.I), Angles.Cosin(this.I));
            this.Point.RecomputeRectangulars();
            //// else DC  = 0; Lwh = 0;  Latitude = 0;  XH =  0;  YH =  0; ZH =  0;

            //// Precess the longtitude and Latitutude from J2000 (2451545.0) to julianDay !?!
            if (SolarSystem.Singleton.PrecessEcliptic) {
                var julianDay = this.Time.CurrentJulianDate;
                var julian2000 = 2451545.0;
                var p = Precession.PrecessEcliptic(this.Point.Longitude, this.Point.Latitude, julian2000, julianDay);
                this.Point.ActualLongitude = p.X;
                this.Point.ActualLatitude = p.Y;
            }
            //// var lambda0rad = Angles.DegRad(lambda0);
            //// var beta0rad = Angles.DegRad(beta0);
        }

        #region Core of Elements
        /// <summary>
        /// Prepare Bretagnon82.
        /// </summary>
        private void PrepareBretagnon82() {
            this.A = this.BretElements.A(this.Time.Jecy);
            this.LM = this.BretElements.LM(this.Time.Jecy);
            this.Bretagnon.K0 = this.BretElements.K0(this.Time.Jecy);
            this.Bretagnon.H0 = this.BretElements.K0(this.Time.Jecy);
            this.Bretagnon.Q0 = this.BretElements.K0(this.Time.Jecy);
            this.Bretagnon.P0 = this.BretElements.K0(this.Time.Jecy);
            this.CompleteBretagnon();
        }

        /// <summary>
        /// Prepare Bretagnon87.
        /// </summary>
        private void PrepareBretagnon87() {
            this.Vsop87.Compute(this.Time.CurrentJulianDate);
            this.A = this.Vsop87.A * AstroMath.AstroUnit;
            this.LM = Angles.RadDeg(this.Vsop87.LM);
            this.Bretagnon.K0 = this.Vsop87.K0;
            this.Bretagnon.H0 = this.Vsop87.H0;
            this.Bretagnon.Q0 = this.Vsop87.Q0;
            this.Bretagnon.P0 = this.Vsop87.P0;
            this.CompleteBretagnon();
        }

        /// <summary>
        /// Complete Bretagnon.
        /// </summary>
        private void CompleteBretagnon() {
            this.E = Math.Sqrt((this.Bretagnon.K0 * this.Bretagnon.K0) + (this.Bretagnon.H0 * this.Bretagnon.H0));                     ////  eccentricity
            this.LP = Angles.RadDeg(Angles.Mod2Pi(Math.Atan2(this.Bretagnon.H0, this.Bretagnon.K0)));              //// Longitude perihelie
            this.I = Angles.RadDeg(Angles.Mod2Pi(2 * Math.Asin(Math.Sqrt((this.Bretagnon.Q0 * this.Bretagnon.Q0) + (this.Bretagnon.P0 * this.Bretagnon.P0))))); //// inclination
            this.LW = Angles.RadDeg(Angles.Mod2Pi(Math.Atan2(this.Bretagnon.P0, this.Bretagnon.Q0)));              //// Longitude noeud ascendant
            this.VM = Angles.Mod360(this.LM - this.LP);                              ////  anomalie moyenne
            this.W = Angles.Mod360(this.LP - this.LW);                              ////  argument p‚rih‚lie
        }

        #endregion
    }
}
