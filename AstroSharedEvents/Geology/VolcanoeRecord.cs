// <copyright file="VolcanoRecord.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology
{
    using AstroSharedClasses.Abstract;
    using System;
    using System.Diagnostics.Contracts;
    using System.Xml.Linq;

    /// <summary>
    /// Earthquake Record.
    /// </summary>
    public sealed class VolcanoRecord {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VolcanoRecord"/> class.
        /// </summary>
        public VolcanoRecord() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VolcanoRecord"/> class.
        /// </summary>
        /// <param name="markRecord">The mark record.</param>
        public VolcanoRecord(XElement markRecord)
        {
            Contract.Requires(markRecord != null);

            this.Country = XmlSupport.ReadStringAttribute(markRecord.Attribute("Country"));
            this.Region = XmlSupport.ReadStringAttribute(markRecord.Attribute("Region"));
            this.Subregion = XmlSupport.ReadStringAttribute(markRecord.Attribute("Subregion"));
            this.VolcanoName = XmlSupport.ReadStringAttribute(markRecord.Attribute("VolcanoName"));
            this.VolcanoType = XmlSupport.ReadStringAttribute(markRecord.Attribute("VolcanoType"));
            this.Id = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("Id"));
            this.Elevation = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("Elevation"));
            this.LastEruption = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("LastEruption"));
            this.VolcanoNumber = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("VolcanoNumber"));
            this.Longitude = XmlSupport.ReadDoubleAttribute(markRecord.Attribute("Longitude"));
            this.Latitude = XmlSupport.ReadDoubleAttribute(markRecord.Attribute("Latitude"));
        }

        #endregion

        #region Properties - Xml

        /// <summary>
        /// Gets the get x element.
        /// </summary>
        /// <value>
        /// The get x element.
        /// </value>
        public XElement GetXElement
        {
            get
            {
                var xe = new XElement(
                                "VolcanoRecord",
                                new XAttribute("Country", this.Country ?? string.Empty),
                                new XAttribute("Region", this.Region ?? string.Empty),
                                new XAttribute("SubRegion", this.Subregion ?? string.Empty),
                                new XAttribute("VolcanoName", this.VolcanoName),
                                new XAttribute("VolcanoType", this.VolcanoType),
                                new XAttribute("Id", this.Id),
                                new XAttribute("Elevation", this.Elevation),
                                new XAttribute("LastEruption", this.LastEruption ?? throw new InvalidOperationException()),
                                new XAttribute("VolcanoNumber", this.VolcanoNumber),
                                new XAttribute("Longitude", this.Longitude),
                                new XAttribute("Latitude", this.Latitude));
                return xe;
            }
        }
        #endregion 

        #region Properties
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the elevation.
        /// </summary>
        /// <value>
        /// The elevation.
        /// </value>
        public int Elevation { get; set; }

        /// <summary>
        /// Gets or sets the last eruption.
        /// </summary>
        /// <value>
        /// The last eruption.
        /// </value>
        public int? LastEruption { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the subregion.
        /// </summary>
        /// <value>
        /// The subregion.
        /// </value>
        public string Subregion { get; set; }

        /// <summary>
        /// Gets or sets the name of the volcano.
        /// </summary>
        /// <value>
        /// The name of the volcano.
        /// </value>
        public string VolcanoName { get; set; }

        /// <summary>
        /// Gets or sets the volcano number.
        /// </summary>
        /// <value>
        /// The volcano number.
        /// </value>
        public int VolcanoNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the volcano.
        /// </summary>
        /// <value>
        /// The type of the volcano.
        /// </value>
        public string VolcanoType { get; set; }

        public int VEI { get; set; }
        #endregion
    }
}
