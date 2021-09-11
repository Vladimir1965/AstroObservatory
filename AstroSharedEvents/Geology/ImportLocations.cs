// <copyright file="ImportLocations.cs" company="Traced-Ideas, Czech republic">
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
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Import Locations.
    /// </summary>
    public static class ImportLocations {
        /// <summary>
        /// Gets or sets the list.
        /// </summary>
        /// <value>
        /// The list.
        /// </value>
        public static List<EarthLocation> List { get; set; }

        /// <summary>
        /// Loads the locations.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        public static void LoadLocations(string folderPath) {
            //// string rname = @"geo-lgh" + slghx + "_lat" + slatx + ".xml";
            var files = Directory.GetFiles(folderPath);
            if (List == null) {
                List = new List<EarthLocation>();
            }

            foreach (var f in files) {
                var location = GetLocation(f);
                List.Add(location);
            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="givenId">The given identifier.</param>
        /// <returns> Returns value. </returns>
        public static EarthLocation GetLocation(int givenId) {
            return null;
        }

        /// <summary>
        /// Inserts the location.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns> Returns value. </returns>
        public static EarthLocation GetLocation(string filePath) {
            //// for example: d:\Solutions\PrivateWPF\AstroData2016\Locations\Earth\geo-lgh-117_5_lat40_5.xml 
            int idxlgh = filePath.IndexOf("lgh", StringComparison.Ordinal);
            int idxlat = filePath.IndexOf("lat", StringComparison.Ordinal);
            int idxxml = filePath.IndexOf(".xml", StringComparison.Ordinal);
            string strlgh = filePath.Substring(idxlgh + 3, idxlat - idxlgh - 4);
            string strlat = filePath.Substring(idxlat + 3, idxxml - idxlat - 3);
            double longitude = double.Parse(strlgh.Replace('_', ','));
            double latitude = double.Parse(strlat.Replace('_', ','));
            EarthLocation loc = new EarthLocation { Latitude = latitude, Longitude = longitude };
            var root1 = XmlSupport.GetXDocRoot(filePath);
            var ocean = root1.Element("ocean");
            if (ocean != null) {
                string oceanName = (string)ocean.Element("name");
                loc.Ocean = oceanName;
                return loc;
            }

            var results = root1.Elements("result");
            foreach (var result in results) {
                var addrComp = result.Element("address_component");
                if (addrComp != null)
                {
                    string longName = (string)addrComp.Element("long_name");

                    var types = result.Elements("type");

                    bool isCountry = false, isArea1 = false, isArea2 = false, isRoute = false, isSublocality = false;
                    foreach (var type in types) {
                        if (type.Value == "country") {
                            isCountry = true;
                        }

                        if (type.Value == "route") {
                            isRoute = true;
                        }

                        if (type.Value == "administrative_area_level_1") {
                            isArea1 = true;
                        }

                        if (type.Value == "administrative_area_level_2") {
                            isArea2 = true;
                        }

                        if (type.Value == "sublocality") {
                            isSublocality = true;
                        }
                    }

                    if (isCountry) {
                        loc.Country = longName;
                    }
                    else {
                        if (isRoute) {
                            //// loc.Route = longName;
                        }
                        else {
                            if (isArea1) {
                                loc.Area1 = longName;
                            }
                            else {
                                if (isArea2) {
                                    loc.Area2 = longName;
                                }
                                else {
                                    if (isSublocality) {
                                        continue;
                                    }

                                    loc.Regions = string.IsNullOrEmpty(loc.Regions) ? longName : $"{loc.Regions}, {longName}";
                                }
                            }
                        }
                    }
                }
            }

            return loc;
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static EarthLocation GetLocation(double longitude, double latitude) {
            EarthLocation loc = (from x in List
                                 where Math.Abs(x.Latitude - latitude) < 0.001 && Math.Abs(x.Longitude - longitude) < 0.001
                                 select x).FirstOrDefault();
            return loc;
        }

        /* DownloadLocation
        public static void DownloadLocation() {
                    //// http://www.latlong.net/c/?lat=54.874&long=153.281
                    //// string web = "http://www.latlong.net/c/?lat="+r.Latitude.ToString().Replace(",",".")+"&long="+r.Longitude.ToString().Replace(",",".");
                    ////string web = "http://latitude-longitude.net/?lat=" + r.Latitude.ToString().Replace(",", ".") + "&long=" + r.Longitude.ToString().Replace(",", ".");
                    ////string slat = r.Latitude.ToString().Replace(",", ".");
                    ////string slgh = r.Longitude.ToString().Replace(",", ".");
                    ////string slatx = r.Latitude.ToString().Replace(",", "_");
                    ////string slghx = r.Longitude.ToString().Replace(",", "_");
                    ////string web = "http://www.whatsmygps.com/index.php?lat=" + slat + "&lng=" + slgh;

                    //// r.Location = "<a href=\"" + web + "\">Location</a>";
                    //// r.Area = string.Empty;
                    //// https://maps.googleapis.com/maps/api/geocode/xml?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&sensor=true_or_false&key=API_KEY
                    //// string webAddress = "https://maps.googleapis.com/maps/api/geocode/json" +
                    ////string webAddress1 = "https://maps.googleapis.com/maps/api/geocode/xml" +
                    ////                   "?latlng=" + slat + "," + slgh + "&sensor=true"; //// &key=API_KEY
                    ////string webAddress2 = "http://www.geocodezip.com/example_geo2.asp" +
                    ////                    "?addr1=" + slat + "," + slgh + "&geocode=1";

                    ////string webAddress3 = "http://api.geonames.org/extendedFindNearby" +
                                        "?lat=" + slat + "&lng=" + slgh + "&username=demo";
                    #endregion

                    //// string rerr = Path.Combine(rpatherr, rname);
                    
                    //// if (File.Exists(rerr)) {
                    ////     this.DownloadFile(webAddress3, r1, null);
                    //// }
        } */
    }
}