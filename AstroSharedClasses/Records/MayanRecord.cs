// <copyright file="MayanRecord.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records
{
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Enums;
    using JetBrains.Annotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Earthquake Record.
    /// </summary>
    public sealed class MayanRecord
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MayanRecord" /> class.
        /// </summary>
        /// <param name="givenBaktun">The given baktun.</param>
        /// <param name="givenKatun">The given katun.</param>
        /// <param name="givenTun">The given tun.</param>
        /// <param name="givenUinal">The given uinal.</param>
        /// <param name="givenKin">The given kin.</param>
        /// <param name="givenInfo">The given info.</param>
        public MayanRecord(int givenBaktun, int givenKatun, int givenTun, int givenUinal, int givenKin, string givenInfo)
        {
            this.Baktun = (byte)givenBaktun;
            this.Katun = (byte)givenKatun;
            this.Tun = (byte)givenTun;
            this.Uinal = (byte)givenUinal;
            this.Kin = (byte)givenKin;
            this.Info = givenInfo;
            this.MayanDay = this.CalculateMayanDay();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MayanRecord"/> class.
        /// </summary>
        /// <param name="givenBaktun">The given baktun.</param>
        /// <param name="givenKatun">The given katun.</param>
        /// <param name="givenTun">The given tun.</param>
        /// <param name="givenUinal">The given uinal.</param>
        /// <param name="givenKin">The given kin.</param>
        /// <param name="givenInfo">The given info.</param>
        /// <param name="serpent">If set to <c>true</c> [serpent].</param>
        public MayanRecord(int givenBaktun, int givenKatun, int givenTun, int givenUinal, int givenKin, string givenInfo, bool serpent)
        {
            if (!serpent) {
                return;
            }
            //// MayanRecord baseRecord = new MayanRecord(3,16,14,11,4,"");  //// 9 Kan 12 Kayab 
            //// long baseNumber = baseRecord.MayanDay();
            const long baseNumber = 10967536; //// baseRecord.MayanDay();
            //// MayanRecord baseRecord = new MayanRecord(16,3,5,6,16,"");  //// 9 Kan 12 Kayab 
            //// long baseNumber = baseRecord.MayanDay();
            var serpentRecord = new MayanRecord(givenBaktun, givenKatun, givenTun, givenUinal, givenKin, string.Empty);
            var serpentNumber = serpentRecord.MayanDay;
            var r = new MayanRecord(4 * 2880000 + serpentNumber - baseNumber);
            this.Baktun = r.Baktun;
            this.Katun = r.Katun;
            this.Tun = r.Tun;
            this.Uinal = r.Uinal;
            this.Kin = r.Kin;
            this.Info = givenInfo;
            this.MayanDay = this.CalculateMayanDay();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MayanRecord"/> class.
        /// </summary>
        /// <param name="mayanDay">The mayan day.</param>
        public MayanRecord(long mayanDay)
        {
            this.MayanDay = mayanDay;
            //// mayanDay = Math.Floor(((mayanDay / Julian.Tzolkin) * 260.0) + 0.5);
            this.Kin = (byte)(mayanDay % 20);
            mayanDay = mayanDay / 20;
            this.Uinal = (byte)(mayanDay % 18);
            mayanDay = mayanDay / 18;
            this.Tun = (byte)(mayanDay % 20);
            mayanDay = mayanDay / 20;
            this.Katun = (byte)(mayanDay % 20);
            mayanDay = mayanDay / 20;
            this.Baktun = (int)mayanDay; //// (byte)(mayanDay % 13); //// 20
        }
        #endregion 

        #region Properties - Xml
        /// <summary>
        /// Gets the get x element.
        /// </summary>
        /// <value>
        /// The get x element.
        /// </value>
        public XElement GetXElement {
            get {
                var xe = new XElement(
                        "Date",
                        new XAttribute("LongCount", this.LongCountBaseString),
                        new XAttribute("HaabDay", this.HaabDayName(0)), //// 508392
                        new XAttribute("TzolkinDay", this.TzolkinDayName()),
                        new XElement(
                            "LC",
                            new XAttribute("Baktun", this.Baktun),
                            new XAttribute("Katun", this.Katun),
                            new XAttribute("Tun", this.Tun),
                            new XAttribute("Uinal", this.Uinal),
                            new XAttribute("Kin", this.Kin)),
                        new XElement("Description", this.Info));

                return xe;
            }
        }
        #endregion

        #region Properties
        /*
        /// <summary>
        /// Gets the baktun.
        /// </summary>
        /// <value>The baktun.</value>
        //// public int Piktun { get; private set; }
        */

        /// <summary>
        /// Gets the baktun.
        /// </summary>
        /// <value>The baktun.</value>
        public int Baktun { get; }

        /// <summary>
        /// Gets the katun.
        /// </summary>
        /// <value>The katun.</value>
        public byte Katun { get; }

        /// <summary>
        /// Gets the tun.
        /// </summary>
        /// <value>The tun.</value>
        public byte Tun { get; }

        /// <summary>
        /// Gets the uinal.
        /// </summary>
        /// <value>The uinal.</value>
        public byte Uinal { get; }

        /// <summary>
        /// Gets the kin.
        /// </summary>
        /// <value>The kin.</value>
        public byte Kin { get; }

        /// <summary>
        /// Gets the mayan day.
        /// </summary>
        /// <value>
        /// The mayan day.
        /// </value>
        public long MayanDay { get; }

        /// <summary>
        /// Gets the info.
        /// </summary>
        /// <value>The info.</value>
        public string Info { get; }

        /// <summary>
        /// Gets the long count base string.
        /// </summary>
        /// <value>
        /// The long count base string.
        /// </value>
        public string LongCountBaseString {
            get {
                var s = string.Format(
                                CultureInfo.InvariantCulture,
                                "{0}.{1}.{2}.{3}.{4}",
                                this.Baktun,
                                this.Katun,
                                this.Tun,
                                this.Uinal,
                                this.Kin);
                return s;
            }
        }
        #endregion

        #region String representation
        /// <summary> String representation of the object. </summary>
        /// <returns> Returns value. </returns>
        public override string ToString()
        {
            var s = new StringBuilder();
            s.AppendFormat(
                "{0,-20} {1,-20} {2,-12} {3}",
                this.LongCountBaseString,
                this.HaabDayName(0) + " " + this.TzolkinDayName(),
                string.Empty,
                this.Info);

            return s.ToString();
        }

        /// <summary>
        /// Mayan Date To String.
        /// </summary>
        /// <param name="correlationNumber">The correlation number.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public string ToString(long correlationNumber)
        {
            var mayanDay = this.MayanDay;
            double julianDate = correlationNumber + mayanDay;
            var s = this.LongCountBaseString;
            var r = string.Format(
                            CultureInfo.InvariantCulture,
                            "{0,-15}; {1} {2}",
                            s,
                            this.TzolkinDayName(),
                            this.HaabDayName(correlationNumber));

            return string.Format(
                            CultureInfo.InvariantCulture,
                            " {0,-36}; ###;{1}",
                            r,
                            this.Info);
            /*
            return string.Format(
                            CultureInfo.InvariantCulture,
                            " {0,-36};({1,7});{2,9};###;{3}",
                            r,
                            mayanDay,
                            julianDate,
                            this.Info); */
        }
        #endregion

        #region Mayans
        /// <summary>
        /// Mayan Corrected Day.
        /// </summary>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public double MayanCorrectedDay()
        {
            var d = this.MayanDay;
            return d / 260.0 * Julian.Tzolkin;
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Mayan Day.
        /// </summary>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        private long CalculateMayanDay()
        {
            long d;
            checked {
                long k = (this.Baktun * 20) + this.Katun;
                d = (((((k * 20) + this.Tun) * 18) + this.Uinal) * 20) + this.Kin;
            }

            return d;
        }

        /// <summary>
        /// Tzolkin the name of the day.
        /// </summary>
        /// <returns> Returns value. </returns>
        private string TzolkinDayName()
        {
            var d = this.MayanDay;
            var z = (int)(1 + (d + 3) % 13);
            var kinName = (KinName)this.Kin;
            return $"{z} {kinName}";
        }

        /// <summary>
        /// Haab name of the day.
        /// </summary>
        /// <param name="correlationNumber">The correlation number.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        private string HaabDayName(long correlationNumber)
        {
            //// int haabShift = (int)((correlationNumber - 348) % 365); //// 63 for 584285
            //// int haabShift = (int)((correlationNumber - 329) % 365); //// 17 for 508392 ?!?
            const int haabShift = 348;
            var d = this.MayanDay;
            var haabDay = (int)((d + haabShift) % 365);
            var day = haabDay % 20; //// -1
            var month = haabDay / 20; //// +1
            var monthName = (HaabMonth)month;
            return $"{day} {monthName}";
        }

        #endregion
    }
}
