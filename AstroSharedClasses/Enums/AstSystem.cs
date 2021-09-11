// <copyright file="AstSystem.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Enums {
    using JetBrains.Annotations;

    /// <summary>
    /// Astronomical system.
    /// </summary>
    public enum AstSystem {
        /// <summary>
        /// System Solar.
        /// </summary>
        Solar = 0,

        /// <summary>
        /// System Earth.
        /// </summary>
        Earth = 1,

        /// <summary>
        /// System Jupiter.
        /// </summary>
        [UsedImplicitly] Jupiter = 2
    }
}
