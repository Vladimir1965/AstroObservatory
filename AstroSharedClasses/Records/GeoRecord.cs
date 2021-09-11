// <copyright file="GeoRecord.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records
{
    /// <summary>
    /// Geo Record.
    /// </summary>
    public class GeoRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoRecord"/> class.
        /// </summary>
        /// <param name="givenGeoType">Type of the given geo.</param>
        /// <param name="givenDay">The given day.</param>
        /// <param name="givenMonth">The given month.</param>
        /// <param name="givenYear">The given year.</param>
        /// <param name="givenDescription">The given description.</param>
        public GeoRecord(char givenGeoType, int givenDay, int givenMonth, int givenYear, string givenDescription) {
            this.GeoType = givenGeoType;
            this.JulianDate = Calendars.Julian.JulianDay(givenDay, givenMonth, givenYear);
            this.Description = givenDescription;
        }

        /// <summary>
        /// Gets or sets the type of the geo.
        /// </summary>
        /// <value>
        /// The type of the geo.
        /// </value>
        public char GeoType { get; set; }

        /// <summary>
        /// Gets or sets the vei.
        /// </summary>
        /// <value>
        /// The vei.
        /// </value>
        public int VEI { get; set; }

        /// <summary>
        /// Gets or sets the magnitude.
        /// </summary>
        /// <value>
        /// The magnitude.
        /// </value>
        public double Magnitude { get; set; }

        /// <summary>
        /// Gets or sets the julian date.
        /// </summary>
        /// <value>
        /// The julian date.
        /// </value>
        public double JulianDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
