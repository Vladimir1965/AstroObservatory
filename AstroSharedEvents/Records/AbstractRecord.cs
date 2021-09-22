// <copyright file="AbstractRecord.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Records
{
    using System.Text;

    /// <summary>
    /// Abstract Record.
    /// </summary>
    public class AbstractRecord
    {
        #region Properties
        /// <summary>
        /// Gets or sets the julian date
        /// </summary>
        public double JulianDate { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is IsValid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is finished.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is finished; otherwise, <c>false</c>.
        /// </value>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Gets or sets the last date difference.
        /// </summary>
        /// <value>
        /// The last date difference.
        /// </value>
        public double LastDateDiff { get; set; }

        /// <summary>
        /// Gets or sets the time unit.
        /// </summary>
        /// <value>
        /// The time unit.
        /// </value>
        public double TimeUnit { get; set; }

        /// <summary>
        /// Gets or sets List.
        /// </summary>
        /// <value>
        /// The list.
        /// </value>
        public StringBuilder Text { get; set; }
        #endregion

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="givenNumber">The given number.</param>
        /// <param name="givenJulianDate">The given julian date.</param>
        /// <param name="givenLastDateDiff">The given last date difference.</param>
        public void SetData(int givenNumber, double givenJulianDate, double givenLastDateDiff)
        {
            this.Number = givenNumber;
            this.JulianDate = givenJulianDate;
            this.LastDateDiff = givenLastDateDiff;
            this.Text = new StringBuilder();
            this.IsValid = true;
        }

        /// <summary>
        /// Outputs the record.
        /// </summary>
        public virtual void OutputRecord()
        {
        }
    }
}
