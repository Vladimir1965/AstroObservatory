// <copyright file="EarthquakeRecord.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Text;
    using System.Xml.Linq;
    using AstroSharedClasses.Abstract;
    using JetBrains.Annotations;

    /// <summary>
    /// Earthquake Record.
    /// </summary>
    public sealed class EarthquakeRecord {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EarthquakeRecord" /> class.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <param name="givenTime">The given time.</param>
        /// <param name="givenLongitude">The given longitude.</param>
        /// <param name="givenLatitude">The given latitude.</param>
        /// <param name="givenMagnitude">The given magnitude.</param>
        /// <param name="givenArea">The given area.</param>
        /// <param name="givenLocation">The given location.</param>
        public EarthquakeRecord(
                    DateTime datetime, 
                    string givenTime,
                    double givenLongitude,
                    double givenLatitude,
                    double givenMagnitude,
                    string givenArea,
                    string givenLocation)
            : this() {
            //// string s = (string)timeval.ToString(); sx += s;
            this.Day = datetime.Day;
            this.Month = datetime.Month;
            this.Year = datetime.Year;
            this.Hour = datetime.Hour;
            this.Minute = datetime.Minute;
            this.Time = givenTime;
            this.Longitude = givenLongitude;
            this.Latitude = givenLatitude;
            this.Magnitude = givenMagnitude;
            this.Area = givenArea;
            this.Location = givenLocation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EarthquakeRecord" /> class.
        /// </summary>
        /// <param name="givenDay">The given day.</param>
        /// <param name="givenMonth">The given month.</param>
        /// <param name="givenYear">The given year.</param>
        /// <param name="givenHour">The given hour.</param>
        /// <param name="givenMinute">The given minute.</param>
        /// <param name="givenTime">The given time.</param>
        /// <param name="givenLongitude">The given longitude.</param>
        /// <param name="givenLatitude">The given latitude.</param>
        /// <param name="givenMagnitude">The given magnitude.</param>
        /// <param name="givenArea">The given area.</param>
        /// <param name="givenLocation">The given location.</param>
        public EarthquakeRecord(
                    int givenDay,
                    int givenMonth,
                    int givenYear,
                    int givenHour,
                    int givenMinute,
                    string givenTime,
                    double givenLongitude,
                    double givenLatitude,
                    double givenMagnitude,
                    string givenArea,
                    string givenLocation)
            : this() {
            this.Day = givenDay;
            this.Month = givenMonth;
            this.Year = givenYear;
            this.Hour = givenHour;
            this.Minute = givenMinute;
            this.Time = givenTime;
            this.Longitude = givenLongitude;
            this.Latitude = givenLatitude;
            this.Magnitude = givenMagnitude;
            this.Area = givenArea;
            this.Location = givenLocation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EarthquakeRecord"/> class.
        /// </summary>
        /// <param name="markRecord">The mark record.</param>
        public EarthquakeRecord(XElement markRecord)
        {
            Contract.Requires(markRecord != null);

            this.Area = XmlSupport.ReadStringAttribute(markRecord.Attribute("Area"));
            this.Location = XmlSupport.ReadStringAttribute(markRecord.Attribute("Location"));
            this.Time = XmlSupport.ReadStringAttribute(markRecord.Attribute("Time"));
            this.Year = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("Year"));
            this.Month = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("Month"));
            this.Day = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("Day"));
            this.Hour = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("Hour"));
            this.Minute = XmlSupport.ReadIntegerAttribute(markRecord.Attribute("Minute"));
            this.Longitude = XmlSupport.ReadDoubleAttribute(markRecord.Attribute("Longitude"));
            this.Latitude = XmlSupport.ReadDoubleAttribute(markRecord.Attribute("Latitude"));
            this.Magnitude = XmlSupport.ReadDoubleAttribute(markRecord.Attribute("Magnitude"));
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="EarthquakeRecord"/> class from being created.
        /// </summary>
        private EarthquakeRecord()
        {
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
                                "EQ",
                                new XAttribute("Area", this.Area ?? string.Empty),
                                new XAttribute("Location", this.Location ?? string.Empty),
                                new XAttribute("Time", this.Time ?? string.Empty),
                                new XAttribute("Year", this.Year),
                                new XAttribute("Month", this.Month),
                                new XAttribute("Day", this.Day),
                                new XAttribute("Hour", this.Hour),
                                new XAttribute("Minute", this.Minute),
                                new XAttribute("Longitude", this.Longitude),
                                new XAttribute("Latitude", this.Latitude),
                                new XAttribute("Magnitude", this.Magnitude));
                return xe;
            }
        }

        #endregion 

        #region Properties
        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <value>The area.</value>
        [UsedImplicitly]
        public string Area { get;  }

        /// <summary>
        /// Gets the day.
        /// </summary>
        /// <value>The day.</value>
        public int Day { get; }

        /// <summary>
        /// Gets the hour.
        /// </summary>
        /// <value>The hour.</value>
        public int Hour { get;  }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        [UsedImplicitly]
        public double Latitude { get; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>The location.</value>
        [UsedImplicitly]
        public string Location { get; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; }

        /// <summary>
        /// Gets the magnitude.
        /// </summary>
        /// <value>The magnitude.</value>
        [UsedImplicitly]
        public double Magnitude { get; }

        /// <summary>
        /// Gets the minute.
        /// </summary>
        /// <value>The minute.</value>
        public int Minute { get; }

        /// <summary>
        /// Gets the month.
        /// </summary>
        /// <value>The month.</value>
        public int Month { get; }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>The time.</value>
        public string Time { get; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year { get; }
        #endregion

        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents the current
        /// <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </returns>
        public override string ToString() {
            var s = new StringBuilder();
            //// s.AppendFormat("{0,-20} - {1}\n\r", this.Area, this.Location);
            s.AppendFormat("({0,7:F2}°, {1,7:F2}°) M:{2,6:F2} ", this.Longitude, this.Latitude, this.Magnitude);
            s.AppendFormat("{0}", this.Location);
            return s.ToString();
        }
    }
}
