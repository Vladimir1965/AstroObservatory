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
        /// <summary> Record characteristic. </summary>
        [UsedImplicitly] None = 0,

        /// <summary> Record characteristic. </summary>
        Barycentre,

        /// <summary> Record characteristic. </summary>
        Bruckner,

        /// <summary> Record characteristic. </summary>
        DateDiffs,

        /// <summary> Record characteristic. </summary>
        Dislocation,

        /// <summary> Record characteristic. </summary>
        Dwarfs,

        /// <summary> Record characteristic. </summary>
        EarthSystem,

        /// <summary> Record characteristic. </summary>
        MainEnergy,

        /// <summary> Record characteristic. </summary>
        Outercentre,

        /// <summary> Record characteristic. </summary>
        OuterPerihelion,

        /// <summary> Record characteristic. </summary>
        OuterResonances,

        /// <summary> Record characteristic. </summary>
        PlanetCentre,

        /// <summary> Record characteristic. </summary>
        PlanetRadius,

        /// <summary> Record characteristic. </summary>
        PlanetsInner,

        /// <summary> Record characteristic. </summary>
        PlanetsMiddle,

        /// <summary> Record characteristic. </summary>
        PlanetsOuter,

        /// <summary> Record characteristic. </summary>
        PlanetXAspects,

        /// <summary> Record characteristic. </summary>
        SunBehavior,

        /// <summary> Record characteristic. </summary>
        SunInfluence,

        /// <summary> Record characteristic. </summary>
        Tidal,

        /// <summary> Record characteristic. </summary>
        TidalExtreme,

        /// <summary> Record characteristic. </summary>
        Vukcevic,

        /// <summary> Record characteristic. </summary>
        Zharkova
    }
}
