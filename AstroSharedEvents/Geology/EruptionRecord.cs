// <copyright file="EruptionRecord.cs" company="Traced-Ideas, Czech republic">
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
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Eruption Record.
    /// </summary>
    public class EruptionRecord {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EruptionRecord"/> class.
        /// </summary>
        public EruptionRecord() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EruptionRecord"/> class.
        /// </summary>
        /// <param name="markRecord">The mark record.</param>
        public EruptionRecord(XElement markRecord)
        {
            Contract.Requires(markRecord != null);

            this.VolcanoName = XmlSupport.ReadStringAttribute(markRecord.Attribute("VolcanoName"));
            this.EruptionType = XmlSupport.ReadStringAttribute(markRecord.Attribute("EruptionType"));
            this.Id = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("Id"));
            this.VolcanoNumber = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("VolcanoNumber"));
            this.EruptionNumber = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("EruptionNumber"));
            this.VEI = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("VEI"));
            this.StartDay = XmlSupport.ReadByteAttribute(markRecord.Attribute("StartDay"));
            this.StartMonth = XmlSupport.ReadByteAttribute(markRecord.Attribute("StartMonth"));
            this.StartYear = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("StartYear"));
            this.EndDay = XmlSupport.ReadByteAttribute(markRecord.Attribute("EndDay"));
            this.EndMonth = XmlSupport.ReadByteAttribute(markRecord.Attribute("EndMonth"));
            this.EndYear = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("EndYear"));
            this.Duration = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("Duration"));
            this.StartTime = XmlSupport.ReadDateTimeAttribute(markRecord.Attribute("StartTime"));
            this.EndTime = XmlSupport.ReadDateTimeAttribute(markRecord.Attribute("EndTime"));
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
                                "EruptionRecord",
                                new XAttribute("VolcanoName", this.VolcanoName ?? string.Empty),
                                new XAttribute("EruptionType", this.EruptionType ?? string.Empty),
                                new XAttribute("Id", this.Id),
                                new XAttribute("VolcanoNumber", this.VolcanoNumber),
                                new XAttribute("EruptionNumber", this.EruptionNumber),
                                new XAttribute("VEI", this.VEI),
                                new XAttribute("StartDay", this.StartDay),
                                new XAttribute("StartMonth", this.StartMonth),
                                new XAttribute("StartYear", this.StartYear),
                                new XAttribute("EndDay", this.EndDay),
                                new XAttribute("EndMonth", this.EndMonth),
                                new XAttribute("EndYear", this.EndYear),
                                new XAttribute("Duration", this.Duration),
                                new XAttribute("StartTime", this.StartTime ?? DateTime.MinValue),
                                new XAttribute("EndTime", this.EndTime ?? DateTime.MinValue));
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
        /// Gets or sets the volcano number.
        /// </summary>
        /// <value>
        /// The volcano number.
        /// </value>
        public int VolcanoNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the volcano.
        /// </summary>
        /// <value>
        /// The name of the volcano.
        /// </value>
        public string VolcanoName { get; set; }

        /// <summary>
        /// Gets or sets the type of the eruption.
        /// </summary>
        /// <value>
        /// The type of the eruption.
        /// </value>
        public string EruptionType { get; set; }

        /// <summary>
        /// Gets or sets the eruption number.
        /// </summary>
        /// <value>
        /// The eruption number.
        /// </value>
        public int EruptionNumber { get; set; }

        /// <summary>
        /// Gets or sets the start day.
        /// </summary>
        /// <value>
        /// The start day.
        /// </value>
        public byte StartDay { get; set; }

        /// <summary>
        /// Gets or sets the start month.
        /// </summary>
        /// <value>
        /// The start month.
        /// </value>
        public byte StartMonth { get; set; }

        /// <summary>
        /// Gets or sets the start year.
        /// </summary>
        /// <value>
        /// The start year.
        /// </value>
        public int StartYear { get; set; }

        /// <summary>
        /// Gets or sets the end day.
        /// </summary>
        /// <value>
        /// The end day.
        /// </value>
        public byte EndDay { get; set; }

        /// <summary>
        /// Gets or sets the end month.
        /// </summary>
        /// <value>
        /// The end month.
        /// </value>
        public byte EndMonth { get; set; }

        /// <summary>
        /// Gets or sets the end year.
        /// </summary>
        /// <value>
        /// The end year.
        /// </value>
        public int EndYear { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public int Duration { get; set; }

        public int VEI { get; set; }
        #endregion

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() {
            var s = new StringBuilder();
            s.AppendFormat("({0}-{1} {2} {3} ", this.StartYear, this.EndYear, this.VolcanoName, this.EruptionType);
            return s.ToString();
        }
    }
}
