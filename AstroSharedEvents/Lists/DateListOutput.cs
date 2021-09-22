// <copyright file="DateListOutput.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Lists
{
    using AstroSharedEvents.Records;
    using AstroSharedOrbits.Dwarfs;
    using AstroSharedOrbits.Systems;
    using global::AstroSharedClasses.Calendars;
    using global::AstroSharedClasses.Computation;
    using global::AstroSharedClasses.Enums;
    using JetBrains.Annotations;
    using System;
    using System.Globalization;

    /// <summary>
    /// Date List.
    /// </summary>
    public partial class EventList : DateList
    {
        #region MayanConstants
        /// <summary>
        /// Mayan Correlation Constant.
        /// </summary>
        [UsedImplicitly]
        public const long MayanCorrelationConstant = 508392;
        //// public const long MayanCorrelationConstant = 584285;
        //// public const long MayanCorrelationConstant = 622261; //// Bohm
        #endregion

        #region Public methods
        /// <summary>
        /// VYPIS POZIC PLANET (TABULKY).
        /// </summary>
        /// <param name="charact">The charact.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public string PrintCharacteristic(AstCharacteristic charact)
        { 
            //// this.List.Append("<HTML>\n\r");  this.List.Append("<PRE>\n\r");
            double lastJulianDate;
            int number = 0;
            var record = this.GetRecord(charact); //// new AbstractRecord();

            foreach (double julianDate in this.Date) {
                //// var info = i < this.Info.Count ? this.Info[i] : string.Empty;
                record.SetData(number, julianDate, julianDate - this.LastJulianDate);
                SolarSystem.Singleton.SetJulianDate(julianDate);
                //// EarthSystem.SetJulianDate(julianDate);
                record.OutputRecord();
                if (record.IsValid) {
                    if (record.IsFinished) {
                        this.List.Append("\n"); // NEW LINE
                    }

                    this.List.Append(record.Text);
                    number++;
                    lastJulianDate = julianDate;
                }
            }

            //// this.List.Append("</PRE>\n\r");  this.List.Append("</HTML>\n\r");
            return this.List.ToString();
        }

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <param name="charact">The charact.</param>
        /// <returns>Returns value.</returns>
        public AbstractRecord GetRecord(AstCharacteristic charact)
        {
            var qualifiedAssemblyName = "AstroSharedEvents.Records.Record" + charact.ToString();
            var recordType = Type.GetType(qualifiedAssemblyName);
            var record = (AbstractRecord)Activator.CreateInstance(recordType);
            return record;
        }

        #endregion
    }
}