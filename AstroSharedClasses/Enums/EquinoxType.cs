// <copyright file="EquinoxType.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Enums {
    /// <summary>
    /// Equinox Type.
    /// </summary>
    public enum EquinoxType : byte {
        /// <summary>  Equinox Type.  </summary>
        None = 4,

        /// <summary>  Equinox Type.  </summary>
        VernalEquinox = 0,

        /// <summary>  Equinox Type.  </summary>
        SummerSolstice = 1,

        /// <summary>  Equinox Type.  </summary>
        AutumnalEquinox = 2,

        /// <summary>  Equinox Type.  </summary>
        WinterSolstice = 3
    }
}
