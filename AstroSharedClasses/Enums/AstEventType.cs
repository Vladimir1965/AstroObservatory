// <copyright file="AstEventType.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Enums {
    using JetBrains.Annotations;

    #region Astronomical Enums
    /// <summary> Event types. </summary>
    [UsedImplicitly]
    public enum AstEventType {
        /// <summary> Event types. </summary>
        [UsedImplicitly] None = 0,

        /// <summary> Event types. </summary>
        [UsedImplicitly] StandardSolarMax = 1,

        /// <summary> Event types. </summary>
        [UsedImplicitly] StandardSolarMin = 2,

        /// <summary> Event types. </summary>
        [UsedImplicitly] SchoveSolarMax = 3,

        /// <summary> Event types. </summary>
        [UsedImplicitly] SchoveSolarMin = 4,

        /// <summary> Event types. </summary>
        [UsedImplicitly] VitinskijFlareMax = 5,

        /// <summary> Event types. </summary>
        [UsedImplicitly] ProtonEventsMax = 6,

        /// <summary> Event types. </summary>
        [UsedImplicitly] Volcanoes = 7,

        /// <summary> Event types. </summary>
        [UsedImplicitly] Earthquake = 8
    }

    #endregion
}
