// <copyright file="PlanetarySystem.cs" company="Traced-Ideas, Czech republic">
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
    using System.Collections.Generic;
    using AstroSharedClasses.Computation;

    /// <summary>
    /// Solar Sys.
    /// </summary>
    public class PlanetarySystem {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanetarySystem"/> class.
        /// </summary>
        public PlanetarySystem()
        {
            this.Time = new AstroTime();
            this.Sun = new BodySun(string.Empty);
            this.Orbit = new List<Orbits.Orbit>();

            this.Barycentre = new SpacePoint();
            this.Planetcentre = new SpacePoint();            
            this.BarycentreBehavior = new PeriodicBehavior();
            this.Gravicentre = new SpacePoint();
            this.Outercentre = new SpacePoint();
            this.TidalExtreme = new SpacePoint();

            this.PrecessEcliptic = false;
            /*
            this.DipoleExtreme = new SpacePoint() { };
            this.GravicentreBehavior= new PeriodicBehavior();
            this.TidalExtremeBehavior = new PeriodicBehavior();
            this.DipoleExtremeBehavior = new PeriodicBehavior();
            */
        }
        #endregion

        //// public double planetXmass;
        //// public double planetXdist;

        #region Public Properties
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public AstroTime Time { get; set; }

        /// <summary>
        /// Gets or sets Orbit Sun.
        /// </summary>
        /// <value>
        /// Property description.
        /// </value>
        public BodySun Sun { get; set; }

        /// <summary>
        /// Gets Orbit Planet.
        /// </summary>
        /// <value>
        /// Property description.
        /// </value>
        public List<Orbit> Orbit { get; set; }

        /// <summary>
        /// Gets or sets the orbit for dipoles.
        /// </summary>
        /// <value>
        /// The orbit for dipoles.
        /// </value>
        [UsedImplicitly]
        public List<Orbit> OrbitForDipoles { get; set; }

        /// <summary>
        /// Gets Total Mass.
        /// </summary>
        /// <value>
        /// Property description.
        /// </value>
        public double TotalMass { get; private set; }

        /// <summary>
        /// Gets the planet mass.
        /// </summary>
        /// <value>
        /// The planet mass.
        /// </value>
        public double PlanetMass { get; private set; }

        #endregion

        #region Public Properties
        public bool PrecessEcliptic { get; private set; }

        /// <summary>
        /// Gets the total index of the alignment.
        /// </summary>
        /// <value>
        /// The total index of the alignment.
        /// </value>
        public double TotalAlignmentIndex { get; private set; }

        /// <summary>
        /// Gets the total index of the quadrature.
        /// </summary>
        /// <value>
        /// The total index of the quadrature.
        /// </value>
        public double TotalQuadratureIndex { get; private set; }

        /// <summary>
        /// Gets the total index of the perihelion.
        /// </summary>
        /// <value>
        /// The total index of the perihelion.
        /// </value>
        public double TotalPerihelionIndex { get; private set; }

        /// <summary>
        /// Gets the total index of the biangular.
        /// </summary>
        /// <value>
        /// The total index of the biangular.
        /// </value>
        public double TotalBiangularIndex { get; private set; }

        /// <summary>
        /// Gets the total index of the triangular.
        /// </summary>
        /// <value>
        /// The total index of the triangular.
        /// </value>
        public double TotalTriangularIndex { get; private set; }

        /// <summary>
        /// Gets or sets the mean alignment longitude.
        /// </summary>
        /// <value>
        /// The mean alignment longitude.
        /// </value>
        public double MeanAlignmentLongitude { get; set; }

        /// <summary>
        /// Gets the barycentre.
        /// </summary>
        /// <value>
        /// The barycentre.
        /// </value>
        public SpacePoint Barycentre { get; }

        /// <summary>
        /// Gets the planetcentre.
        /// </summary>
        /// <value>
        /// The planetcentre.
        /// </value>
        public SpacePoint Planetcentre { get; }

        /// <summary>
        /// Gets or sets the moment sum.
        /// </summary>
        /// <value>
        /// The moment sum.
        /// </value>
        public double MomentSum { get; set; }

        /// <summary>
        /// Gets the gravicentre.
        /// </summary>
        /// <value>
        /// The gravicentre.
        /// </value>
        public SpacePoint Gravicentre { get; }

        /// <summary>
        /// Gets the outercentre.
        /// </summary>
        /// <value>
        /// The outercentre.
        /// </value>
        public SpacePoint Outercentre { get; }
        
        /// <summary>
        /// Gets the tidal extreme.
        /// </summary>
        /// <value>
        /// The tidal extreme.
        /// </value>
        public SpacePoint TidalExtreme { get; }

        /*
        public SpacePoint DipoleExtreme { get; private set; }
        */
        #endregion

        #region Properties for analysis of periods
        /// <summary>
        /// Gets the bary sun behavior.
        /// </summary>
        /// <value>
        /// The bary sun behavior.
        /// </value>
        public PeriodicBehavior BarycentreBehavior { get; }

        /*
        /// <summary>
        /// Gets the gravi sun behavior.
        /// </summary>
        /// <value>
        /// The gravi sun behavior.
        /// </value>
        public PeriodicBehavior GravicentreBehavior { get; private set; }

        /// <summary>
        /// Gets the tidal extreme behavior.
        /// </summary>
        /// <value>
        /// The tidal extreme behavior.
        /// </value>
        public PeriodicBehavior TidalExtremeBehavior { get; private set; }

        public PeriodicBehavior DipoleExtremeBehavior { get; private set; }
        */
        #endregion

        #region Private Properties       
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SolarSystem"/> is influences.
        /// </summary>
        /// <value>
        /// Property description.
        /// </value>
        protected bool Influences { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SolarSystem"/> is perturbations.
        /// </summary>
        /// <value>
        /// Property description.
        /// </value>
        protected bool Perturbations { get; set; }

        /// <summary>
        /// Gets or sets Orbit Moon.
        /// </summary>
        /// <value> Property description. </value>
        [UsedImplicitly]
        private Orbit[] OrbitMoon { [UsedImplicitly] get; set; }
        #endregion

        /// <summary>
        /// Set Enabled.
        /// </summary>
        /// <param name="flag">If set to <c>true</c> [flag].</param>
        public void SetEnabled(bool flag) {
            foreach (var body in this.Orbit)
            {
                if (body == null) { continue; }
                body.Enabled = flag;
            }
        }

        /// <summary>
        /// Set Julian Date.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        public void SetJulianDate(double givenJulianDay) {
            ////  SpacePoint c = GetBarycentre();
            //// this.previousState.GraviLongitude = this.Gravicentre.Longitude;
            //// this.previousState.ActualAngleSpeed = this.BarySunBehavior.ActualAngleSpeed;
            this.Time.CurrentJulianDate = givenJulianDay;
            if (this.Time.PreviousJulianDate != null)
            {
                this.Time.DeltaJulianDate = this.Time.CurrentJulianDate - this.Time.PreviousJulianDate ?? 0;
            }

            foreach (var orbit in this.Orbit)
            {
                if (orbit == null) {
                    continue;
                }

                if (orbit.Enabled) {
                    orbit.SetJulianDate(givenJulianDay);
                }
            }

            if (this.Perturbations) {
                this.Perturbate();
            }

            this.Sun.SetJulianDate(givenJulianDay);

            this.DetermineAlignmentIndexes();
            this.DetermineQuadratureIndexes();
            this.DeterminePerihelionIndexes();
            this.DetermineBiangularIndexes();
            this.DetermineTriangularIndexes();

            //// Centers    
            this.DetermineBarycentre();
            this.DeterminePlanetcentre();            
            this.DetermineMomentSum();

            //// this.DetermineOutercentreByMoments();
            //// this.DetermineTidalExtreme();
            this.DetermineGravicentre();
            //// this.DetermineOutercentre();
            //// this.DetermineStaticcentre();
            /*
            this.DetermineGravicentre();
            this.DetermineTidalExtreme();
            this.DetermineDipoleExtreme();
            */

            //// The Sun    
            this.Sun.Point.XH = -this.Barycentre.XH;
            this.Sun.Point.YH = -this.Barycentre.YH;
            this.Sun.Point.ZH = -this.Barycentre.ZH;
            this.Sun.Point.RT = this.Barycentre.RT;
            this.Sun.Point.Longitude = Angles.Mod360(180 + this.Barycentre.Longitude);
            this.Sun.Point.Latitude = -this.Barycentre.Latitude;

            var dt = this.Time.DeltaJulianDate;
            if (this.Sun.Point.PreviousPoint != null)
            {
                var d = new SpaceDifference(this.Sun.Point.PreviousPoint, this.Sun.Point);
                this.Sun.Point.ActualSpeed = d.DS / dt;
                var dv = this.Sun.Point.ActualSpeed - this.Sun.Point.PreviousPoint.ActualSpeed;
                this.Sun.Point.ActualAcceleration = dv / dt;

                this.DetermineBaryPeriod(dt);

                /*
                this.DetermineGraviPeriod(dt);
                this.DetermineTidalPeriod(dt);
                this.DetermineDipolePeriod(dt);
                */
            }

            //// Save state to previous
            this.Time.PreviousJulianDate = this.Time.CurrentJulianDate;
            this.Sun.Point.SavePointAsPrevious();
            this.Barycentre.SavePointAsPrevious();
            /*
            this.Gravicentre.SavePointAsPrevious();
            this.TidalExtreme.SavePointAsPrevious();
            this.DipoleExtreme.SavePointAsPrevious();
            */

            //// this.DeterminePeriod(dt);
            /*
            if (this.Influences) {
                this.Sun.ComputeInfluences();
            } */
        }

        /// <summary>
        /// Determines the gravicentre.
        /// </summary>
        public void DetermineGravicentre()
        {
            var c = this.Gravicentre;
            c.Reset();
            //// Compute gravicentre
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }
                if (orbit.Body.Name == "PLUTON") {
                    continue;
                }

                //// Intensities
                orbit.Point.RecomputeIntensities(orbit.Body.Mass);
                c.FX = c.FX + orbit.Point.FX;
                c.FY = c.FY + orbit.Point.FY;
                c.FZ = 0;
            }

            c.XH = c.FX / 1000;
            c.YH = c.FY / 1000;
            c.ZH = c.FZ / 1000;
            c.RecomputeSphericals();
        }

        /// <summary>
        /// Determines the outercentre by moments.
        /// </summary>
        [UsedImplicitly]
        public void DetermineOutercentreByMoments()
        {
            var c = this.Outercentre;
            c.Reset();
            //// Compute outercentre
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }
                var list = new List<string>(new string[] { "Jupiter", "Saturn", "Uranus", "Neptune", "X" });
                if (!list.Contains(orbit.Body.Name)) {
                    continue;
                }

                //// Moments
                c.XH = c.XH + (orbit.Point.XH * orbit.Body.Mass);
                c.YH = c.YH + (orbit.Point.YH * orbit.Body.Mass);
                c.ZH = c.ZH + (orbit.Point.ZH * orbit.Body.Mass);
            }

            c.XH = c.XH / this.TotalMass;
            c.YH = c.YH / this.TotalMass;
            c.ZH = c.ZH / this.TotalMass;
            c.RecomputeSphericals();
        }

        /// <summary>
        /// Determines the outercentre.
        /// </summary>
        [UsedImplicitly]
        public void DetermineOutercentre()
        {
            var c = this.Outercentre;
            c.Reset();
            //// Compute outercentre
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }
                var list = new List<string>(new string[] { "Saturn", "Uranus", "Neptune" }); //// "Saturn", "Uranus", "Neptune"
                if (!list.Contains(orbit.Body.Name)) {
                    continue;
                }

                //// Intensities
                var E = orbit.Body.Mass / orbit.Point.RT / orbit.Point.RT;
                c.FX = c.FX + E * Angles.Cosin(orbit.Point.Longitude);
                c.FY = c.FY + E * Angles.Sinus(orbit.Point.Longitude);
                c.FZ = 0;
            }

            c.XH = c.FX / 1000;
            c.YH = c.FY / 1000;
            c.ZH = c.FZ / 1000;
            c.RecomputeSphericals();
        }

        /// <summary>
        /// Determines the tidal extreme.
        /// </summary>
        [UsedImplicitly]
        public void DetermineTidalExtreme()
        {
            var c = this.TidalExtreme;
            c.Reset();

            //// Compute tides
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }

                //// Tides
                var E = orbit.Body.Mass / orbit.Point.RT / orbit.Point.RT / orbit.Point.RT;
                var longitude = Angles.Mod180(orbit.Longitude);
                c.FX = c.FX + E * Angles.Cosin(longitude);
                c.FY = c.FY + E * Angles.Sinus(longitude);
                c.FZ = 0;
            }

            c.XH = c.FX * 10;
            c.YH = c.FY * 10;
            c.ZH = c.FZ * 10;
            c.RecomputeSphericals();
        }

        /// <summary>
        /// Compute Total Mass.
        /// </summary>
        protected void ComputeTotalMass()
        {
            this.PlanetMass = 0;
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }
                {
                    this.PlanetMass += orbit.Body.Mass;
                }
            }

            //// this.PlanetMass += this.planetXmass;
            this.TotalMass = this.Sun.Body.Mass + this.PlanetMass;  //// Solar System 
        }

        /// <summary>
        /// Determines the alignment indexes.
        /// </summary>
        private void DetermineAlignmentIndexes()
        {
            //// var listOfPlanets = new List<string> { "J", "S" };
            //// var listOfPlanets = new List<string> { "J", "Oileus" };
            //// var listOfPlanets = new List<string> { "V", "J", "S" };
            //// var listOfPlanets = new List<string> { "U", "N", "TNO1" };
            //// var listOfPlanets = new List<string> { "M", "V", "E", "R" };
            //// var listOfPlanets = new List<string> { "J", "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "M", "V", "E", "J", "S" };
            //// var listOfPlanets = new List<string> { "V", "E", "R", "J", "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "U", "N", "M", "V", "E", "R" };
            //// var listOfPlanets = new List<string> { "V", "R", "S", "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "V", "R", "S" };
            //// var listOfPlanets = new List<string> { "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "R", "S", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "N" };
            //// var listOfPlanets = new List<string> { "V", "R", "J" };
            //// var listOfPlanets = new List<string> { "J", "S", "U" };
            //// var listOfPlanets = new List<string> { "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "M", "V", "E", "R" };
            //// var listOfPlanets = new List<string> { "V", "J" };
            //// var listOfPlanets = new List<string> { "M", "V", "E", "R", "J", "S", "U", "N" };
            var listOfPlanets = new List<string> { "V", "E", "J" };
            //// var listOfPlanets = new List<string> { "M", "V", "E", "J" };

            //// Individual alignments of each planet
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                orbit.AlignmentIndex = 0;

                if (!orbit.Enabled) { continue; }
                if (!listOfPlanets.Contains(orbit.Body.Abbreviation)) {
                    continue;
                }

                orbit.AlignmentIndex = 0;
                foreach (var orbit2 in this.Orbit) {
                    if (orbit2 == null) { continue; }
                    if (!orbit2.Enabled) { continue; }
                    if (!listOfPlanets.Contains(orbit2.Body.Abbreviation)) {
                        continue;
                    }

                    if (orbit2.Body.Name == orbit.Body.Name) {
                        continue;
                    }

                    double angle = orbit.Longitude - orbit2.Longitude;
                    //// double value = Math.Abs(Angles.Cosin(angle));
                    double value = Math.Pow(Angles.Cosin(angle),2);
                    orbit.AlignmentIndex += value;
                }
            }

            double totalIndex = 0, totalLongitude = 0;
            int cnt = 0;
            this.MeanAlignmentLongitude = 0;
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (orbit.AlignmentIndex > 0) {
                    totalIndex += orbit.AlignmentIndex;
                    totalLongitude += Angles.Mod180(orbit.Longitude);
                    cnt++;
                }
            }

            this.TotalAlignmentIndex = totalIndex;
            this.MeanAlignmentLongitude = totalLongitude/cnt;
        }

        /// <summary>
        /// Determines the quadrature indexes.
        /// </summary>
        private void DetermineQuadratureIndexes()
        {
            //// var listOfPlanets = new List<string> { "V", "R", "S", "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "V", "R", "S" };
            //// var listOfPlanets = new List<string> { "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "R", "S", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "N" };
            //// var listOfPlanets = new List<string> { "V", "R", "J" };
            //// var listOfPlanets = new List<string> { "J", "S", "U" };
            //// var listOfPlanets = new List<string> { "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "M", "V", "E", "R" };
            //// var listOfPlanets = new List<string> { "V", "J" };
            var listOfPlanets = new List<string> { "M", "V", "E", "R", "J", "S", "U", "N" };

            //// Individual alignments of each planet
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                orbit.QuadratureIndex = 0;

                if (!orbit.Enabled) { continue; }
                if (!listOfPlanets.Contains(orbit.Body.Abbreviation)) {
                    continue;
                }

                orbit.QuadratureIndex = 0;
                foreach (var orbit2 in this.Orbit) {
                    if (orbit2 == null) { continue; }
                    if (!orbit2.Enabled) { continue; }
                    if (!listOfPlanets.Contains(orbit2.Body.Abbreviation)) {
                        continue;
                    }

                    if (orbit2.Body.Name == orbit.Body.Name) {
                        continue;
                    }

                    double angle = orbit.Longitude - orbit2.Longitude;
                    double value = Math.Pow(Angles.Sinus(angle),2);
                    orbit.QuadratureIndex += value;
                }
            }

            double totalIndex = 0;
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                totalIndex += orbit.QuadratureIndex;
            }

            this.TotalQuadratureIndex = totalIndex;
        }

        /// <summary>
        /// Determines the perihelion indexes.
        /// </summary>
        private void DeterminePerihelionIndexes()
        {
            //// var listOfPlanets = new List<string> { "V", "R", "S", "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "V", "R", "S" };
            //// var listOfPlanets = new List<string> { "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "R", "S", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "N" };
            //// var listOfPlanets = new List<string> { "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "M", "V", "E", "R" };
            //// var listOfPlanets = new List<string> { "V", "R", "J" };
            //// var listOfPlanets = new List<string> { "J", "S", "U" };
            //// var listOfPlanets = new List<string> { "V", "J" };
            var listOfPlanets = new List<string> { "M", "V", "E", "R", "J", "S", "U", "N" };

            //// Individual alignments of each planet
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                orbit.PerihelionIndex = 0;

                if (!orbit.Enabled) { continue; }
                if (!listOfPlanets.Contains(orbit.Body.Abbreviation)) {
                    continue;
                }

                orbit.PerihelionIndex = 0;
                double angle = orbit.Longitude - orbit.LP;
                var value = Angles.Cosin(angle);
                if (value > 0) {
                    orbit.PerihelionIndex += value;
                } else {
                    //// Perihel-Aphel index
                    orbit.PerihelionIndex += -value;
                }
            }

            double totalIndex = 0;
            int cnt = 0;
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (orbit.PerihelionIndex > 0) {
                    totalIndex += orbit.PerihelionIndex;
                    cnt++;
                }
            }

            this.TotalPerihelionIndex = totalIndex;
        }

        /// <summary>
        /// Determines the biangular indexes.
        /// </summary>
        private void DetermineBiangularIndexes()
        {
            //// var listOfPlanets = new List<string> { "V", "R", "S", "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "V", "R", "S" };
            //// var listOfPlanets = new List<string> { "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "R", "S", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "N" };
            //// var listOfPlanets = new List<string> { "V", "R", "J" };
            //// var listOfPlanets = new List<string> { "J", "S", "U" };
            //// var listOfPlanets = new List<string> { "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "M", "V", "E", "R" };
            //// var listOfPlanets = new List<string> { "V", "J" };
            var listOfPlanets = new List<string> { "M", "V", "E", "R", "J", "S", "U", "N" };

            //// Individual alignments of each planet
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                orbit.BiangularIndex = 0;

                if (!orbit.Enabled) { continue; }
                if (!listOfPlanets.Contains(orbit.Body.Abbreviation)) {
                    continue;
                }

                orbit.BiangularIndex = 0;
                foreach (var orbit2 in this.Orbit) {
                    if (orbit2 == null) { continue; }
                    if (!orbit2.Enabled) { continue; }
                    if (!listOfPlanets.Contains(orbit2.Body.Abbreviation)) {
                        continue;
                    }

                    if (orbit2.Body.Name == orbit.Body.Name) {
                        continue;
                    }

                    double angle = orbit.Longitude - orbit2.Longitude;
                    //// double value = Math.Abs(Angles.Cosin(angle));
                    double value = Math.Pow(Angles.Cosin(2 * angle), 2);
                    orbit.BiangularIndex += value;
                }
            }

            double totalIndex = 0;
            int cnt = 0;
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (orbit.BiangularIndex > 0) {
                    totalIndex += orbit.BiangularIndex;
                    cnt++;
                }
            }

            this.TotalBiangularIndex = totalIndex;
        }

        /// <summary>
        /// Determines the triangular indexes.
        /// </summary>
        private void DetermineTriangularIndexes()
        {
            //// var listOfPlanets = new List<string> { "V", "R", "S", "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "V", "R", "S" };
            //// var listOfPlanets = new List<string> { "E", "J", "U" };
            //// var listOfPlanets = new List<string> { "R", "S", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "J", "S", "N" };
            //// var listOfPlanets = new List<string> { "V", "R", "J" };
            //// var listOfPlanets = new List<string> { "J", "S", "U" };
            //// var listOfPlanets = new List<string> { "S", "U", "N" };
            //// var listOfPlanets = new List<string> { "M", "V", "E", "R" };
            //// var listOfPlanets = new List<string> { "V", "J" };
            var listOfPlanets = new List<string> { "M", "V", "E", "R", "J", "S", "U", "N" };

            //// Individual alignments of each planet
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                orbit.TriangularIndex = 0;

                if (!orbit.Enabled) { continue; }
                if (!listOfPlanets.Contains(orbit.Body.Abbreviation)) {
                    continue;
                }

                orbit.TriangularIndex = 0;
                foreach (var orbit2 in this.Orbit) {
                    if (orbit2 == null) { continue; }
                    if (!orbit2.Enabled) { continue; }
                    if (!listOfPlanets.Contains(orbit2.Body.Abbreviation)) {
                        continue;
                    }

                    if (orbit2.Body.Name == orbit.Body.Name) {
                        continue;
                    }

                    double angle = orbit.Longitude - orbit2.Longitude;
                    //// double value = Math.Abs(Angles.Cosin(angle));
                    double value = Math.Pow(Angles.Cosin(3*angle), 2);
                    orbit.TriangularIndex += value;
                }
            }

            double totalIndex = 0;
            int cnt = 0;
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (orbit.TriangularIndex > 0) {
                    totalIndex += orbit.TriangularIndex;
                    cnt++;
                }
            }

            this.TotalTriangularIndex = totalIndex;
        }

        #region Private determine centers
        /// <summary>
        /// Determines the barycentre.
        /// </summary>
        /// <returns>Returns value.</returns>
        private SpacePoint DetermineBarycentre()
        {
            var c = this.Barycentre;
            c.Reset();
            //// Compute barycentre
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }
                if (orbit.Body.Name == "PLUTON")
                {
                    continue;
                }

                if (orbit.MeanPeriod == 0) {
                    continue;
                }

                //// Moments
                c.XH = c.XH + (orbit.Point.XH * orbit.Body.Mass);
                c.YH = c.YH + (orbit.Point.YH * orbit.Body.Mass);
                c.ZH = c.ZH + (orbit.Point.ZH * orbit.Body.Mass);
            }

            var mass = this.TotalMass;
            c.XH = c.XH / mass;
            c.YH = c.YH / mass;
            c.ZH = c.ZH / mass;
            c.RecomputeSphericals();
            return c;
        }

        /// <summary>
        /// Determines the planetcentre.
        /// </summary>
        /// <returns></returns>
        private SpacePoint DeterminePlanetcentre() {
            var c = this.Planetcentre;
            c.Reset();
            //// Compute barycentre
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }
                if (orbit.Body.Name == "PLUTON") {
                    continue;
                }

                if (orbit.MeanPeriod == 0) {
                    continue;
                }

                //// Moments
                c.XH += (orbit.Point.XH * orbit.Body.Mass);
                c.YH += (orbit.Point.YH * orbit.Body.Mass);
                c.ZH += (orbit.Point.ZH * orbit.Body.Mass);
            }

            var mass = this.PlanetMass;
            //// c.ZH += this.planetXmass * this.planetXdist;

            c.XH = c.XH / mass;
            c.YH = c.YH / mass;
            c.ZH = c.ZH / mass;

            c.RecomputeSphericals();
            return c;
        }

        private void DetermineMomentSum() {
            this.MomentSum = 0;
            foreach (var orbit in this.Orbit) {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }
                if (orbit.Body.Name == "PLUTON") {
                    continue;
                }

                if (orbit.MeanPeriod == 0) {
                    continue;
                }

                var energy = new OrbitEnergy();
                energy.SetOrbit(orbit, this.Sun);
                var m1 = energy.Carea;
                var m2 = energy.AngularMomentum;
                //// var x = energy.Carea / energy.AngularMomentum;

                //// Moments
                this.MomentSum += m2;

                //// var omega = 2 * Math.PI / 19000 / AstroMath.SecondsInDay / 365.25;
                //// this.MomentSum += this.planetXmass * this.planetXdist * this.planetXdist * omega;
            }
        }

        /// <summary>
        /// Determines the staticcentre.
        /// </summary>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        private SpacePoint DetermineStaticcentre()
        {
            var c = this.Barycentre;
            c.Reset();
            //// Compute barycentre
            foreach (var orbit in this.Orbit)
            {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }
                if (orbit.Body.Name == "PLUTON")
                {
                    continue;
                }

                //// Moments
                c.XH = c.XH + (orbit.Point.XH* orbit.Point.XH * orbit.Body.Mass);
                c.YH = c.YH + (orbit.Point.YH* orbit.Point.YH * orbit.Body.Mass);
                c.ZH = c.ZH + (orbit.Point.ZH* orbit.Point.ZH * orbit.Body.Mass);
            }

            c.XH = Math.Sqrt(c.XH / this.TotalMass);
            c.YH = Math.Sqrt(c.YH / this.TotalMass);
            c.ZH = Math.Sqrt(c.ZH / this.TotalMass);
            c.RecomputeSphericals();
            return c;
        }

        /*
        public void DetermineDipoleExtreme()
        {
            var c = this.DipoleExtreme;
            c.Reset();

            Orbit lastOrbit = null;
            //// Compute tides
            foreach (var orbit in this.OrbitForDipoles)
            {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }

                //// Dipoles
                if (lastOrbit != null)
                {
                    var delta = (orbit.Longitude - lastOrbit.Longitude);
                    var E = lastOrbit.Body.Mass + orbit.Body.Mass * Angles.Cosin(2*delta); ;
                    c.FX = c.FX + E * Angles.Cosin(lastOrbit.Longitude);
                    c.FY = c.FY + E * Angles.Sinus(lastOrbit.Longitude);
                    c.FZ = 0;
                }

                lastOrbit = orbit;
            }

            c.XH = c.FX * 1e-27;
            c.YH = c.FY * 1e-27;
            c.ZH = c.FZ * 1e-27;
            c.RecomputeSphericals();
        }
        */

        /// <summary>
        /// Determines the bary period.
        /// </summary>
        /// <param name="dt">The dt.</param>
        private void DetermineBaryPeriod(double dt)
        {
            //// -90 + 90 dg    
            double dLongitude = Angles.Mod180Sym(this.Barycentre.Longitude - this.Barycentre.PreviousPoint.Longitude);
            this.BarycentreBehavior.Retrograde = dLongitude < 0;

            this.BarycentreBehavior.ActualAngleSpeed = dLongitude / dt;
            this.BarycentreBehavior.ActualPeriod = 360 / this.BarycentreBehavior.ActualAngleSpeed / 365.25;

            if (!this.Barycentre.ZeroState)
            {
                this.BarycentreBehavior.TotalJulianDay += dt;
                this.BarycentreBehavior.TotalLgh += dLongitude;
            }

            this.BarycentreBehavior.MeanAngleSpeed = this.BarycentreBehavior.TotalLgh / this.BarycentreBehavior.TotalJulianDay;
            this.BarycentreBehavior.MeanAngularPeriod = 360 / this.BarycentreBehavior.MeanAngleSpeed / 365.25;
            return;
        }

        /*
        /// <summary>
        /// Determines the gravi period.
        /// </summary>
        /// <param name="dt">The dt.</param>
        private void DetermineGraviPeriod(double dt)
        {
            //// -180 + 180 dg    
            double dLongitude = Angles.Mod180Sym(this.Gravicentre.Longitude - this.Gravicentre.PreviousPoint.Longitude);
            this.GravicentreBehavior.Retrograde = dLongitude < 0;

            this.GravicentreBehavior.ActualAngleSpeed = dLongitude / dt;
            this.GravicentreBehavior.ActualPeriod = 360 / this.GravicentreBehavior.ActualAngleSpeed / 365.25;

            if (!this.Gravicentre.ZeroState)
            {
                this.GravicentreBehavior.TotalJulianDay += dt;
                this.GravicentreBehavior.TotalLgh += dLongitude;
            }

            this.GravicentreBehavior.MeanAngleSpeed = this.GravicentreBehavior.TotalLgh / this.GravicentreBehavior.TotalJulianDay;
            this.GravicentreBehavior.MeanAngularPeriod = 360 / this.GravicentreBehavior.MeanAngleSpeed / 365.25;
            return;
        }

        private void DetermineTidalPeriod(double dt)
        {
            //// -180 + 180 dg    
            double dLongitude = Angles.Mod180Sym(this.TidalExtreme.Longitude - this.TidalExtreme.PreviousPoint.Longitude);
            this.TidalExtremeBehavior.Retrograde = dLongitude < 0;

            this.TidalExtremeBehavior.ActualAngleSpeed = dLongitude / dt;
            this.TidalExtremeBehavior.ActualPeriod = 360 / this.TidalExtremeBehavior.ActualAngleSpeed / 365.25;

            if (!this.TidalExtreme.ZeroState)
            {
                this.TidalExtremeBehavior.TotalJulianDay += dt;
                this.TidalExtremeBehavior.TotalLgh += dLongitude;
            }

            this.TidalExtremeBehavior.MeanAngleSpeed = this.TidalExtremeBehavior.TotalLgh / this.TidalExtremeBehavior.TotalJulianDay;
            this.TidalExtremeBehavior.MeanAngularPeriod = 360 / this.TidalExtremeBehavior.MeanAngleSpeed / 365.25;
            return;
        }

        private void DetermineDipolePeriod(double dt)
        {
            //// -180 + 180 dg    
            double dLongitude = Angles.Mod180Sym(this.DipoleExtreme.Longitude - this.DipoleExtreme.PreviousPoint.Longitude);
            this.DipoleExtremeBehavior.Retrograde = dLongitude < 0;

            this.DipoleExtremeBehavior.ActualAngleSpeed = dLongitude / dt;
            this.DipoleExtremeBehavior.ActualPeriod = 360 / this.DipoleExtremeBehavior.ActualAngleSpeed / 365.25;

            if (!this.DipoleExtreme.ZeroState)
            {
                this.DipoleExtremeBehavior.TotalJulianDay += dt;
                this.DipoleExtremeBehavior.TotalLgh += dLongitude;
            }

            this.DipoleExtremeBehavior.MeanAngleSpeed = this.DipoleExtremeBehavior.TotalLgh / this.DipoleExtremeBehavior.TotalJulianDay;
            this.DipoleExtremeBehavior.MeanAngularPeriod = 360 / this.DipoleExtremeBehavior.MeanAngleSpeed / 365.25;
            return;
        }
        */

        /// <summary>
        /// Compute perturbation.
        /// </summary>
        private void Perturbate() {
            foreach (var orbit in this.Orbit)
            {
                if (orbit == null) { continue; }
                if (!orbit.Enabled) { continue; }
                {
                    orbit.Perturbate();
                    }
            }
        }

        #endregion

        /* Radial Wobbling - Not used now.
        double radialWobbling(ref Orbit aBody) {
            int i, j; Relation rA, rB, rC;
            double cosx, q1, q2, q3, quotient;
            double dF, F_rad = 0;
            rA.SetBodies(SolarSystem.Sun, aBody);
            for (i = 1; i < Count; i++)
                if (Planet[i] != aBody) {
                    Orbit iBody = Planet[i];
                    rB.SetBodies(SolarSystem.Sun, iBody);
                    rC.SetBodies(aBody, iBody);
                    cosx = Angles.Cosin(Angles.SharpAngle(rC.dLongitude));
                    q1 = +cosx / rB.dR2;
                    q2 = -rB.dR * cosx / rC.dR2 / rC.dR;
                    q3 = +rA.dR / rC.dR2 / rC.dR;
                    quotient = q1 + q2 + q3;
                    dF = AstroMath.Kappa * (aBody.Mass) * (iBody.Mass) * quotient;
                    F_rad = F_rad + dF;
                }
            return F_rad;
        }

        // napø. Fi=SUN->totalWobbling( Earth )/1e16-F0;
        double totalWobbling(ref Orbit aBody) {
            int i, j; Relation rA, rB, rC;
            double cosx, q1, q2, q3, quotient;
            double dF, F_tot = 0;
            rA.SetBodies(SolarSystem.Sun, aBody);
            //   for (i=2; i<6; i++)
            //     if (Planet[i]!=Mars)
            for (i = 1; i < Count; i++)
                if (Planet[i] != aBody) {
                    Orbit iBody = Planet[i];
                    rB.SetBodies(SolarSystem.Sun, iBody);
                    rC.SetBodies(aBody, iBody);
                    cosx = Angles.Cosin(Angles.SharpAngle(rC.dLongitude));
                    q1 = +1 / rB.dR2 / rB.dR2;
                    q2 = +1 / rC.dR2 / rC.dR2;
                    q3 = -2 * (rB.dR - rA.dR * cosx) / rB.dR2 / rC.dR2 / rC.dR;
                    quotient = Math.Sqrt(q1 + q2 + q3);
                    dF = AstroMath.Kappa * (aBody.Mass) * (iBody.Mass) * quotient;
                    F_tot = F_tot + dF;
                }
            return F_tot;
        }
        //// -----------------------------------------------------
        void testRelations()    {
           int i,j;   Relation Q;
           for (i=0; i<_Count; i++) {
              Orbit orbitA = Planet[i];
              for (j=0; j<_Count; j++,j!=i) {
                  Orbit orbitB = Planet[j];
                  Q.SetBodies(orbitA,orbitB);
              }
           }
        }        */
    }
}