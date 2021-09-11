// <copyright file="ImportEarthquakes.cs" company="Traced-Ideas, Czech republic">
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
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Import Earthquakes.
    /// </summary>
    public static class ImportEarthquakes {
        /// <summary>
        /// Gets or sets the list.
        /// </summary>
        /// <value>
        /// The list.
        /// </value>
        public static List<EarthquakeRecord> List { get; set; }

        #region Data repository
        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Returns value.</returns>
        public static bool LoadData(string path)
        {
            var root = XmlSupport.GetXDocRoot(path);
            if (root == null || root.Name != "Earthquakes")
            {
                return false;
            }

            var xlist = root;
            ImportEarthquakes.List = new List<EarthquakeRecord>();
            foreach (var xe in xlist.Elements())
            {
                var record = new EarthquakeRecord(xe);
                ImportEarthquakes.List.Add(record); 
            }

            return true;
        }

        /// <summary>
        /// Saves the musical setup.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void SaveData(string path)
        {
            var root = new XElement("Earthquakes");
            var xdoc = new XDocument(new XDeclaration("1.0", "utf-8", null), root);

            foreach (var xrecord in ImportEarthquakes.List)
            {
                var eq = xrecord.GetXElement; 
                root.Add(eq);
            }

            xdoc.Save(path);
        }
        #endregion

        /// <summary>
        /// Loads the file of earthquakes.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static void LoadQuakeml(string path) {
            var root = XmlSupport.GetXDocRoot(path);
            //// var eventParameters = root.Elements("eventParameters");
            if (root == null) {
                return;
            }

            if (ImportEarthquakes.List == null) {
                ImportEarthquakes.List = new List<EarthquakeRecord>();
            }

            var elements = root.Elements();  //// var sx = elements.ToString();
            foreach (var element in elements) {
                var xevents = element.Elements();

                foreach (var xevent in xevents) {
                    DateTime dateTime = new DateTime();
                    double longitude = 0, latitude = 0, magnitude = 0;

                    var xsections = xevent.Elements();    //// Origin, Magnitude
                    foreach (var xsection in xsections) {
                        var xdatas = xsection.Elements();
                        foreach (var xdata in xdatas) {
                            var name = xdata.Name.LocalName;
                            if (name == "time") {     //// var time = xdata.Element("value");
                                dateTime = (DateTime)xdata;
                            }

                            if (name == "longitude") {
                                longitude = (double)xdata;
                            }

                            if (name == "latitude") {
                                latitude = (double)xdata;
                            }

                            if (name == "mag") {
                                ////var mag = xorigin.Element("value");
                                magnitude = (double)xdata;
                            }
                        }
                    }

                    EarthLocation loc = ImportLocations.GetLocation(longitude, latitude);
                    if (loc != null) {
                        EarthquakeRecord r = new EarthquakeRecord(dateTime, "UTC", longitude, latitude, magnitude, loc.Area1 ?? loc.Area2, loc.Country ?? loc.Ocean);
                        ImportEarthquakes.List.Add(r);
                    }
                    else {
                        //// MessageBox.Show("err");
                    }
                }
            }
        }
    }
}
