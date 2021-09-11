// <copyright file="AstPlanet.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Enums {
    /// <summary>
    /// Astronomical Planet.
    /// </summary>
    public enum AstPlanet {
        /// <summary>
        /// Planet Mercury.
        /// </summary>
        Mercury = 0,

        /// <summary>
        /// Planet Venus.
        /// </summary>
        [JetBrains.Annotations.UsedImplicitlyAttribute] Venus = 1,

        /// <summary>
        /// Planet Earth.
        /// </summary>
        [JetBrains.Annotations.UsedImplicitlyAttribute] Earth = 2,

        /// <summary>
        /// Planet Mars.
        /// </summary>
        Mars = 3,

        /// <summary>
        /// Planet Jupiter.
        /// </summary>
        Jupiter = 4,

        /// <summary>
        /// Planet Saturn.
        /// </summary>
        [JetBrains.Annotations.UsedImplicitlyAttribute] Saturn = 5,

        /// <summary>
        /// Planet Uranus.
        /// </summary>
        [JetBrains.Annotations.UsedImplicitlyAttribute] Uranus = 6,

        /// <summary>
        /// Planet Neptune.
        /// </summary>
        Neptune = 7,

        /// <summary>
        /// Planet hypothetical X.
        /// </summary>
        X = 8,

        /// <summary>
        /// Count of 
        /// </summary>
        Count = 9
    }
}
