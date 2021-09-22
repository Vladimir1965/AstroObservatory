// <copyright file="ImportEruptions.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology
{
    using AstroSharedClasses.Abstract;
    using JetBrains.Annotations;
    using Microsoft.Office.Interop.Excel;
    //// using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Import Eruptions.
    /// </summary>
    public class ImportEruptions
    {
        /// <summary>
        /// Gets or sets the list eruptions.
        /// </summary>
        /// <value>
        /// The list eruptions.
        /// </value>
        public static List<EruptionRecord> List { get; set; }

        #region Data repository
        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Returns value.</returns>
        public static bool LoadData(string path)
        {
            var root = XmlSupport.GetXDocRoot(path);
            if (root == null || root.Name != "Eruptions")
            {
                return false;
            }

            var xlist = root;
            ImportEruptions.List = new List<EruptionRecord>();
            foreach (var xe in xlist.Elements())
            {
                var record = new EruptionRecord(xe);
                ImportEruptions.List.Add(record);
            }

            return true;
        }

        /// <summary>
        /// Saves the musical setup.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void SaveData(string path)
        {
            var root = new XElement("Eruptions");
            var xdoc = new XDocument(new XDeclaration("1.0", "utf-8", null), root);

            foreach (var xrecord in ImportEruptions.List)
            {
                var eq = xrecord.GetXElement;
                root.Add(eq);
            }

            xdoc.Save(path);
        }
        #endregion

        /// <summary>
        /// Inserts the volcanoes data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="givenVolcanoName">Name of the given volcano.</param>
        public static void InsertEruptions(string path, string givenVolcanoName)
        {
            if (ImportEruptions.List == null)
            {
                ImportEruptions.List = new List<EruptionRecord>();
            }

            _Application xlapp = new Application();
            int rcnt;

            //// xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            Workbook workBook = xlapp.Workbooks.Open(path, 0, true, 5, string.Empty, string.Empty, true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Worksheet workSheet = (Worksheet)workBook.Worksheets.Item[1];
            Range range = workSheet.UsedRange;

            //// 3
            var totalCnt = range.Rows.Count;
            for (rcnt = 3; rcnt <= totalCnt; rcnt++)
            {
                ////x var rowcolumns = new List<string>();
                //// unused var o = range.Cells[rcnt, 1] as Range;
                //// if (o != null) { object objectCell1 = o.Value2; }
                //// string textCell1 = objectCell1.ToString();

                //// if (!string.IsNullOrEmpty(givenVolcanoName)) {
                ////     var range1 = range.Cells[rcnt, 2] as Range;
                ////     if (range1 != null) {
                ////         object objectCell2 = range1.Value2;
                ////         string textCell2 = objectCell2.ToString();
                ////         if (textCell2 != givenVolcanoName) {
                ////             continue;
                ////         }
                ////     }
                //// }

                if (range.Columns.Count < 10)
                { //// 21
                    continue;
                }

                string volcanoName = string.Empty;
                string eruptionType = string.Empty;
                int volcanoNumberNum = 0;
                int eruptionNumberNum = 0;
                byte startDayNum = 0;
                byte startMonthNum = 0;
                int startYearNum = 0;
                byte endDayNum = 0;
                byte endMonthNum = 0;
                int endYearNum = 0;
                int vei = 0;
                
                int columnNumber;
                for (columnNumber = 1; columnNumber <= range.Columns.Count; columnNumber++)
                {
                    var o1 = range.Cells[rcnt, columnNumber] as Range;
                    if (o1 != null)
                    {
                        object objectCell = o1.Value2;
                        if (objectCell == null)
                        {
                            ////x rowColumns.Add(string.Empty);
                            continue;
                        }

                        string textCell = objectCell.ToString();
                        if (string.IsNullOrEmpty(textCell))
                        {
                            textCell = "0";
                        }
                        //// MessageBox.Show(str);
                        ////x rowColumns.Add(textCell);

                        switch (columnNumber)
                        {
                            case 1: volcanoNumberNum = int.Parse(textCell); break;
                            case 2: volcanoName = textCell; break;
                            case 3: eruptionNumberNum = int.Parse(textCell); break;
                            //// case 4: eruptionType = textCell; break;
                            //// case 5: activityArea = textCell; break;
                            case 6: startYearNum = int.Parse(textCell); break;
                            case 7: startMonthNum = byte.Parse(textCell); break;
                            case 8: startDayNum = byte.Parse(textCell); break;
                            //// case 9: evidenceMethod = textCell; break;
                            case 10: endYearNum = int.Parse(textCell); break;
                            case 11: endMonthNum = byte.Parse(textCell); break;
                            case 12: endDayNum = byte.Parse(textCell); break;
                            case 13: vei = byte.Parse(textCell); break;
                        }
                    }
                }

                if (startMonthNum == 0)
                {
                    startMonthNum = 1;
                }

                if (endMonthNum == 0)
                {
                    endMonthNum = startMonthNum;
                }

                if (startDayNum == 0)
                {
                    startDayNum = 1;
                }

                if (endDayNum == 0)
                {
                    endDayNum = 1;
                }

                if ((startMonthNum == 2) && (startDayNum > 28))
                {
                    startDayNum = 28;
                }

                if ((endMonthNum == 2) && (endDayNum > 28))
                {
                    endDayNum = 28;
                }

                if ((startMonthNum == 4 || startMonthNum == 6 || startMonthNum == 9 || startMonthNum == 11) &&
                    (startDayNum > 30))
                {
                    startDayNum = 30;
                }

                if ((endMonthNum == 4 || endMonthNum == 6 || endMonthNum == 9 || endMonthNum == 11) &&
                    (endDayNum > 30))
                {
                    endDayNum = 30;
                }

                var teruption = new EruptionRecord
                {
                    VolcanoNumber = volcanoNumberNum,
                    VolcanoName = volcanoName,
                    EruptionType = eruptionType,
                    EruptionNumber = eruptionNumberNum,
                    StartDay = startDayNum,
                    StartMonth = startMonthNum,
                    StartYear = startYearNum,
                    EndDay = endDayNum,
                    EndMonth = endMonthNum,
                    EndYear = endYearNum,
                    VEI = vei
                };

                if (startYearNum > 0 && endYearNum > 0)
                {
                    DateTime startTime = new DateTime(startYearNum, startMonthNum, startDayNum);
                    DateTime endTime = new DateTime(endYearNum, endMonthNum, endDayNum);
                    TimeSpan timeSpan = endTime.Subtract(startTime);
                    double duration = timeSpan.TotalDays + 1;
                    teruption.StartTime = startTime;
                    teruption.EndTime = endTime;
                    teruption.Duration = (int)Math.Round(duration);
                }

                ImportEruptions.List.Add(teruption);
            }
        }
    }
}
