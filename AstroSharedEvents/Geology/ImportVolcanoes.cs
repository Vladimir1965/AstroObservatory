// <copyright file="ImportVolcanoes.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology
{
    //// using Microsoft.Office.Interop.Excel;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using AstroSharedClasses.Abstract;
    using JetBrains.Annotations;
    using Microsoft.Office.Interop.Excel;

    /// <summary>
    /// Import Volcanoes.
    /// </summary>
    [UsedImplicitly]
    public static class ImportVolcanoes {
        /// <summary>
        /// Gets or sets the list volcanoes.
        /// </summary>
        /// <value>
        /// The list volcanoes.
        /// </value>
        public static List<VolcanoRecord> List { get; set; }

        #region Data repository
        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Returns value.</returns>
        public static bool LoadData(string path)
        {
            var root = XmlSupport.GetXDocRoot(path);
            if (root == null || root.Name != "Volcanoes")
            {
                return false;
            }

            var xlist = root;
            ImportVolcanoes.List = new List<VolcanoRecord>();
            foreach (var xe in xlist.Elements())
            {
                var record = new VolcanoRecord(xe);
                ImportVolcanoes.List.Add(record);
            }

            return true;
        }

        /// <summary>
        /// Saves the musical setup.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void SaveData(string path)
        {
            var root = new XElement("Volcanoes");
            var xdoc = new XDocument(new XDeclaration("1.0", "utf-8", null), root);

            foreach (var xrecord in ImportVolcanoes.List)
            {
                var vo = xrecord.GetXElement;
                root.Add(vo);
            }

            xdoc.Save(path);
        }
        #endregion


        /// <summary>
        /// Inserts the volcanoes.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void InsertVolcanoes(string path) {
            if (ImportVolcanoes.List == null) {
                ImportVolcanoes.List = new List<VolcanoRecord>();
            }

            _Application app = new Application();
            int rcnt;

            //// xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            Workbook workBook = app.Workbooks.Open(path, 0, true, 5, string.Empty, string.Empty, true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Worksheet workSheet = (Worksheet)workBook.Worksheets.Item[1];

            Range range = workSheet.UsedRange;
            for (rcnt = 3; rcnt <= range.Rows.Count; rcnt++) {
                var rowcolumns = new List<string>();
                int columnNumber;
                for (columnNumber = 1; columnNumber <= range.Columns.Count; columnNumber++) {
                    var o = range.Cells[rcnt, columnNumber] as Range;
                    if (o != null) {
                        object objectCell = o.Value2;
                        if (objectCell == null) {
                            rowcolumns.Add(string.Empty);
                            continue;
                        }

                        string textCell = objectCell.ToString();
                        //// MessageBox.Show(str);
                        rowcolumns.Add(textCell);
                    }
                }

                if (range.Columns.Count < 9) {
                    continue;
                }

                var latitude = rowcolumns[7];
                var longitude = rowcolumns[8];
                if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude)) {
                    continue;
                }

                var volcanoNumber = rowcolumns[0];
                var volcanoName = rowcolumns[1];
                var volcanoType = rowcolumns[2];
                var lastEruption = rowcolumns[3];
                var country = rowcolumns[4];
                var region = rowcolumns[5];
                var subregion = rowcolumns[6];
                var elevation = rowcolumns[9];

                int letst;
                var le = (string.IsNullOrEmpty(lastEruption) || !int.TryParse(lastEruption, out letst)) ? (int?)null : int.Parse(lastEruption);

                var tvolcano = new VolcanoRecord {
                    Country = country,
                    Elevation = int.Parse(elevation),
                    LastEruption = le,
                    Latitude = double.Parse(latitude),
                    Longitude = double.Parse(longitude),
                    Region = region,
                    Subregion = subregion,
                    VolcanoName = volcanoName,
                    VolcanoNumber = int.Parse(volcanoNumber),
                    VolcanoType = volcanoType,
                };

                ImportVolcanoes.List.Add(tvolcano);
            }
        }
    }
}
