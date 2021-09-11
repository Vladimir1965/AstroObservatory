// <copyright file="AstCharacteristic.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Enums {
    using JetBrains.Annotations;

    /// <summary>
    /// Astronomical Characteristic.
    /// </summary>
    public enum AstCharacteristic {
        /// <summary>
        /// Characteristic None.
        /// </summary>
        [UsedImplicitly] None = 0,

        /// <summary>
        /// Date Diffs.
        /// </summary>
        DateDiffs = 1,

        /// <summary>
        /// Longitude Outer.
        /// </summary>
        LongitudesOuter = 2,

        /// <summary>
        /// Longitude Inner.
        /// </summary>
        LongitudesInner = 3,

        /// <summary>
        /// Longitude Sun.
        /// </summary>
        LongitudesSun = 4,

        /// <summary>
        /// Display distances.
        /// </summary>
        Distances = 5,

        /// <summary>
        /// Sun Influences.
        /// </summary>
        SunInfluences = 6, //// XSunInfluences=7,

        /// <summary>
        /// Oriented BaryAxis.
        /// </summary>
        OrientedBaryAxis = 7,

        /// <summary>
        /// Experimental variant.
        /// </summary>
        Conjunctions = 8,

        /// <summary>
        /// Longitude Inner.
        /// </summary>
        LongitudesToExcel = 9,

        /// <summary>
        /// Experimental variant.
        /// </summary>
        EarthSystem = 10,

        /// <summary>
        /// Experimental variant.
        /// </summary>
        Experiment = 11,

        /// <summary>
        /// Experimental variant.
        /// </summary>
        DateDiffsOuter = 12,

        /// <summary>
        /// Date Diffs.
        /// </summary>
        DateDiffsStandard = 13,

        /// <summary>
        /// Date Diffs.
        /// </summary>
        DateDiffsZharkova = 14
    }
}
