// <copyright file="AlgVariant.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Enums {
    using JetBrains.Annotations;

    /// <summary>
    /// Alg Variant.
    /// </summary>
    public enum AlgVariant {
        /// <summary>
        /// None variant.
        /// </summary>
        [UsedImplicitly] None = 0,

        /// <summary>
        /// Var Bretagnon87.
        /// </summary>
        VarBretagnon87 = 1,

        /// <summary>
        /// Var Bretagnon82.
        /// </summary>
        VarBretagnon82 = 2,

        /// <summary>
        /// Var Schlyter.
        /// </summary>
        VarSchlyter = 3,

        /// <summary>
        /// Var Chapront.
        /// </summary>
        VarChapront = 4,

        /// <summary>
        /// Var Normal.
        /// </summary>
        VarNormal = 5,

        /// <summary>
        /// Var Normal.
        /// </summary>
        VarMeeus = 6,

                /// <summary>
        /// Var Normal.
        /// </summary>
        VarNaughter = 7
    }
}
