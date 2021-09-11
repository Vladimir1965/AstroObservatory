// <copyright file="EarthLocation.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology
{
    /// <summary>
    /// Earth Location.
    /// </summary>
    public class EarthLocation {
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the ocean.
        /// </summary>
        /// <value>
        /// The ocean.
        /// </value>
        public string Ocean { get; set; }

        /// <summary>
        /// Gets or sets the area1.
        /// </summary>
        /// <value>
        /// The area1.
        /// </value>
        public string Area1 { get; set; }

        /// <summary>
        /// Gets or sets the area2.
        /// </summary>
        /// <value>
        /// The area2.
        /// </value>
        public string Area2 { get; set; }

        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        /// <value>
        /// The regions.
        /// </value>
        public string Regions { get; set; }  
    }
}
