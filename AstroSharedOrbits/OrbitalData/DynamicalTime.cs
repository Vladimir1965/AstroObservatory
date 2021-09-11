// <copyright file="DynamicalTime.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.OrbitalData
{
    using System.Diagnostics;
    using AstroSharedClasses.Calendars;
    using JetBrains.Annotations;

    /// <summary>
    /// Dynamical Time.
    /// </summary>
    [UsedImplicitly]
    public sealed class DynamicalTime
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicalTime" /> class.
        /// </summary>
        public DynamicalTime()
        {
        }

        /// <summary>
        /// Deltas the T.
        /// </summary>
        /// <param name="julianDay">The julianDay.</param>
        /// <returns> Returns value. </returns>
        public static double DeltaT(double julianDay)
        {
            //// Construct a CAADate from the julian day
            var date = new SpecialDate(julianDay, Date.AfterPapalReform(julianDay));

            var y = date.FractionalYear();
            var timeT = (y - 2000) / 100;

            double delta;
            if (y < 948) {
                delta = 2177 + (497 * timeT) + (44.1 * timeT * timeT);
            }
            else if (y < 1620) {
                delta = 102 + (102 * timeT) + (25.3 * timeT * timeT);
            }
            else if (y < 1998) {
                var index = (int)((y - 1620) / 2);
                Debug.Assert(index < DynamicalTimeDeltas.DeltaTTable.Length, "Reason for the assert");
                Debug.Assert(index >= 0, "Reason for the assert");

                y = y / 2 - index - 810;
                delta = DynamicalTimeDeltas.DeltaTTable[index] + (DynamicalTimeDeltas.DeltaTTable[index + 1] - DynamicalTimeDeltas.DeltaTTable[index]) * y;
            }
            else if (y <= 2000) {
                var nLookupSize = DynamicalTimeDeltas.DeltaTTable.Length;
                delta = DynamicalTimeDeltas.DeltaTTable[nLookupSize - 1];
            }
            else if (y < 2100) {
                delta = 102 + (102 * timeT) + (25.3 * timeT * timeT) + 0.37 * (y - 2100);
            }
            else {
                delta = 102 + (102 * timeT) + (25.3 * timeT * timeT);
            }

            return delta;
        }
    }
}
