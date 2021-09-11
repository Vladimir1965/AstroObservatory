// <copyright file="FlareDay.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records
{
    /// <summary>
    /// Flare Day.
    /// </summary>
    public class FlareDay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlareDay" /> class.
        /// </summary>
        public FlareDay() {
        }

        public FlareDay(string record) {
            var snum = record.Substring(13, 9).Trim();
            var snth = record.Substring(22, 8).Replace('.',',').Trim();
            var ssth = record.Substring(31, 8).Replace('.', ',').Trim();
            var stot = record.Substring(40, 7).Replace('.', ',').Trim();
            this.DayInfo = record.Substring(1, 12).Trim();
            this.DayNumber = int.Parse(snum);
            this.North = float.Parse(snth);
            this.South = float.Parse(ssth);
            this.Total = float.Parse(stot);
        }

        /// <summary>
        /// Gets or sets the day number.
        /// </summary>
        /// <value>
        /// The day number.
        /// </value>
        public int DayNumber { get; set; }

        /// <summary>
        /// Gets or sets the day information.
        /// </summary>
        /// <value>
        /// The day information.
        /// </value>
        public string DayInfo { get; set; }

        /// <summary>
        /// Gets or sets the north.
        /// </summary>
        /// <value>
        /// The north.
        /// </value>
        public float North { get; set; }

        /// <summary>
        /// Gets or sets the south.
        /// </summary>
        /// <value>
        /// The south.
        /// </value>
        public float South { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public float Total { get; set; }

        public override string ToString() {
            return string.Format(@"{0,8:F0} {1,10}: {2,7:F2} +  {3,7:F2} = {4,7:F2}", 
                                    this.DayNumber, this.DayInfo, this.North, this.South, this.Total);
        }
    }
}
