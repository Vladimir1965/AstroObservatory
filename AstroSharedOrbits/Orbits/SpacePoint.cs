// <copyright file="SpacePoint.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author> vl </author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Orbits
{
    using AstroSharedClasses.Computation;
    using System;

    /// <summary>
    /// Space Point.
    /// </summary>
    public class SpacePoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpacePoint"/> class.
        /// </summary>
        public SpacePoint()
        {
        }

        /// <summary>
        /// Gets or sets the previous State.
        /// </summary>
        /// <value>
        /// The previous point.
        /// </value>
        public SpacePoint PreviousPoint { get; set; }

        #region Spherical coordinates
        /// <summary>
        /// Gets or sets Radius of the body.
        /// </summary>
        /// <value> Property description. </value>
        public double RT { get; set; }

        /// <summary>
        /// Gets or sets Longitude heliocentric.
        /// </summary>
        /// <value> Property description. </value>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets Latitude heliocentric.
        /// </summary>
        /// <value> Property description. </value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the actual longitude.
        /// </summary>
        /// <value>
        /// The actual longitude.
        /// </value>
        public double ActualLongitude { get; set; }

        /// <summary>
        /// Gets or sets the actual latitude.
        /// </summary>
        /// <value>
        /// The actual latitude.
        /// </value>
        public double ActualLatitude { get; set; }
        #endregion

        #region Rectangular coordinates
        /// <summary>
        /// Gets or sets X heliocentric.
        /// </summary>
        /// <value> Property description. </value>
        public double XH { get; set; }

        /// <summary>
        /// Gets or sets Y heliocentric.
        /// </summary>
        /// <value> Property description. </value>
        public double YH { get; set; }

        /// <summary>
        /// Gets or sets Z heliocentric.
        /// </summary>
        /// <value> Property description. </value>
        public double ZH { get; set; }
        #endregion

        #region Central forces 
        /// <summary>
        /// Gets or sets X force.
        /// </summary>
        /// <value> Property description. </value>
        public double FX { get; set; }

        /// <summary>
        /// Gets or sets Y force.
        /// </summary>
        /// <value> Property description. </value>
        public double FY { get; set; }

        /// <summary>
        /// Gets or sets Z force.
        /// </summary>
        /// <value> Property description. </value>
        public double FZ { get; set; }

        /// <summary>
        /// Gets a value indicating whether [zero state].
        /// </summary>
        /// <value>
        ///   <c>True</c> if [zero state]; otherwise, <c>false</c>.
        /// </value>
        public bool ZeroState
        {
            get
            {
                const float epsilon = 0.001f;
                return Math.Abs(this.XH - 0) < epsilon && Math.Abs(this.YH - 0) < epsilon && Math.Abs(this.ZH - 0) < epsilon;
            }
        }
        #endregion

        #region Speed
        /// <summary>
        /// Gets or sets Actual Speed.
        /// </summary>
        /// <value> Property description. </value>
        public double ActualSpeed { get; set; }

        /// <summary>
        /// Gets or sets the Actual Acceleration.
        /// </summary>
        /// <value> Property description. </value>
        public double ActualAcceleration { get; set; }
        #endregion

        /// <summary>
        /// Recomputes the rectangulars.
        /// </summary>
        public void RecomputeRectangulars()
        {
            this.XH = this.RT * Angles.Cosin(this.Longitude) * Angles.Cosin(this.Latitude);
            this.YH = this.RT * Angles.Sinus(this.Longitude) * Angles.Cosin(this.Latitude);
            this.ZH = this.RT * Angles.Sinus(this.Latitude);
        }

        /// <summary>
        /// Recomputes the intensities.
        /// </summary>
        /// <param name="bodyMass">The body mass.</param>
        public void RecomputeIntensities(double bodyMass)
        {
            //// Intensities
            var E = bodyMass / this.RT / this.RT;
            this.FX = E * Angles.Cosin(this.Longitude);
            this.FY = E * Angles.Sinus(this.Longitude);
            this.FZ = 0;
        }

        /// <summary>
        /// Recomputes the sphericals.
        /// </summary>
        public void RecomputeSphericals()
        {
            this.RT = Math.Sqrt((this.XH * this.XH) + (this.YH * this.YH) + (this.ZH * this.ZH));
            this.Longitude = Angles.ArcTan2(this.YH, this.XH);
            this.Latitude = Angles.ArcSinus(this.ZH / this.RT);
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            this.FX = 0;
            this.FY = 0;
            this.FZ = 0;
            this.XH = 0;
            this.YH = 0;
            this.ZH = 0;
        }

        /// <summary>
        /// Saves the point as previous.
        /// </summary>
        public void SavePointAsPrevious() { 
            if (this.PreviousPoint == null)
            {
                this.PreviousPoint = new SpacePoint();
            }

            this.PreviousPoint.XH = this.XH;
            this.PreviousPoint.YH = this.YH;
            this.PreviousPoint.ZH = this.ZH;
            this.PreviousPoint.Longitude = this.Longitude;
            this.PreviousPoint.ActualSpeed = this.ActualSpeed;
            //// this.PreviousPoint.CurrentJulianDate = this.Time.CurrentJulianDate;
        }
    }
}