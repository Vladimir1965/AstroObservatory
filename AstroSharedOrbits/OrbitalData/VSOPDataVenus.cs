// <copyright file="VsopDataVenus.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>
using AstroSharedClasses.Records;

namespace AstroSharedOrbits.OrbitalData {
    /// <summary>
    /// Vsop Data for planets.
    /// </summary>
    public static partial class VsopData
    {
        #region Venus

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L0VenusCoefficients =
{ 
  new Vsop87Coefficient( 317614667, 0,         0  ), 
  new Vsop87Coefficient( 1353968,   5.5931332, 10213.2855462  ), 
  new Vsop87Coefficient( 89892,     5.30650,   20426.57109  ), 
  new Vsop87Coefficient( 5477,      4.4163,    7860.4194  ), 
  new Vsop87Coefficient( 3456,      2.6996,    11790.6291  ), 
  new Vsop87Coefficient( 2372,      2.9938,    3930.2097  ), 
  new Vsop87Coefficient( 1664,      4.2502,    1577.3435  ), 
  new Vsop87Coefficient( 1438,      4.1575,    9683.5946  ), 
  new Vsop87Coefficient( 1317,      5.1867,    26.2983  ), 
  new Vsop87Coefficient( 1201,      6.1536,    30639.8566  ), 
  new Vsop87Coefficient( 769,       0.816,     9437.763  ), 
  new Vsop87Coefficient( 761,       1.950,     529.691  ), 
  new Vsop87Coefficient( 708,       1.065,     775.523  ), 
  new Vsop87Coefficient( 585,       3.998,     191.448  ), 
  new Vsop87Coefficient( 500,       4.123,     15720.839  ), 
  new Vsop87Coefficient( 429,       3.586,     19367.189  ), 
  new Vsop87Coefficient( 327,       5.677,     5507.553  ), 
  new Vsop87Coefficient( 326,       4.591,     10404.734  ), 
  new Vsop87Coefficient( 232,       3.163,     9153.904  ), 
  new Vsop87Coefficient( 180,       4.653,     1109.379  ), 
  new Vsop87Coefficient( 155,       5.570,     19651.048  ), 
  new Vsop87Coefficient( 128,       4.226,     20.775  ), 
  new Vsop87Coefficient( 128,       0.962,     5661.332  ), 
  new Vsop87Coefficient( 106,       1.537,     801.821  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L1VenusCoefficients =
{ 
  new Vsop87Coefficient( 1021352943053.0, 0,       0  ), 
  new Vsop87Coefficient( 95708,           2.46424, 10213.28555  ), 
  new Vsop87Coefficient( 14445,           0.51625, 20426.57109  ), 
  new Vsop87Coefficient( 213,             1.795,   30639.857  ), 
  new Vsop87Coefficient( 174,             2.655,   26.298  ), 
  new Vsop87Coefficient( 152,             6.106,   1577.344  ), 
  new Vsop87Coefficient( 82,              5.70,    191.45  ), 
  new Vsop87Coefficient( 70,              2.68,    9437.76  ),   
  new Vsop87Coefficient( 52,              3.60,    775.52  ),    
  new Vsop87Coefficient( 38,              1.03,    529.69  ), 
  new Vsop87Coefficient( 30,              1.25,    5507.55  ), 
  new Vsop87Coefficient( 25,              6.11,    10404.73  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L2VenusCoefficients =
{ 
  new Vsop87Coefficient( 54127, 0,      0  ), 
  new Vsop87Coefficient( 3891,  0.3451, 10213.2855  ), 
  new Vsop87Coefficient( 1338,  2.0201, 20426.5711  ), 
  new Vsop87Coefficient( 24,    2.05,   26.30  ), 
  new Vsop87Coefficient( 19,    3.54,   30639.86  ), 
  new Vsop87Coefficient( 10,    3.97,   775.52  ), 
  new Vsop87Coefficient( 7,     1.52,   1577.34  ), 
  new Vsop87Coefficient( 6,     1.00,   191.45  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L3VenusCoefficients =
{ 
  new Vsop87Coefficient( 136, 4.804, 10213.286  ), 
  new Vsop87Coefficient( 78,  3.67,  20426.57 ),
  new Vsop87Coefficient( 26,  0,     0  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L4VenusCoefficients =
{ 
  new Vsop87Coefficient( 114, 3.1416, 0  ), 
  new Vsop87Coefficient( 3,   5.21,   20426.57  ), 
  new Vsop87Coefficient( 2,   2.51,   10213.29  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L5VenusCoefficients =
{ 
  new Vsop87Coefficient( 1, 3.14, 0  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B0VenusCoefficients =
{ 
  new Vsop87Coefficient( 5923638, 0.2670278, 10213.2855462  ), 
  new Vsop87Coefficient( 40108,   1.14737,   20426.57109  ), 
  new Vsop87Coefficient( 32815,   3.14737,   0  ), 
  new Vsop87Coefficient( 1011,    1.0895,    30639.8566  ), 
  new Vsop87Coefficient( 149,     6.254,     18073.705  ), 
  new Vsop87Coefficient( 138,     0.860,     1577.344  ), 
  new Vsop87Coefficient( 130,     3.672,     9437.763  ), 
  new Vsop87Coefficient( 120,     3.705,     2352.866  ), 
  new Vsop87Coefficient( 108,     4.539,     22003.915  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B1VenusCoefficients =
{ 
  new Vsop87Coefficient( 513348, 1.803643, 10213.285546  ), 
  new Vsop87Coefficient( 4380,   3.3862,   20426.5711  ),  
  new Vsop87Coefficient( 199,    0,        0  ), 
  new Vsop87Coefficient( 197,    2.530,    30639.857  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B2VenusCoefficients =
{ 
  new Vsop87Coefficient( 22378, 3.38509, 10213.28555  ), 
  new Vsop87Coefficient( 282,   0,       0  ), 
  new Vsop87Coefficient( 173,   5.256,   20426.571  ), 
  new Vsop87Coefficient( 27,    3.87,    30639.86  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B3VenusCoefficients =
{ 
  new Vsop87Coefficient( 647, 4.992, 10213.286  ), 
  new Vsop87Coefficient( 20,  3.14,  0  ), 
  new Vsop87Coefficient( 6,   0.77,  20426.57  ), 
  new Vsop87Coefficient( 3,   5.44,  30639.86  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B4VenusCoefficients =
{ 
  new Vsop87Coefficient( 14, 0.32, 10213.29  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R0VenusCoefficients =
{ 
  new Vsop87Coefficient( 72334821, 0,        0  ), 
  new Vsop87Coefficient( 489824,   4.021518, 10213.285546  ), 
  new Vsop87Coefficient( 1658,     4.9021,   20426.5711  ), 
  new Vsop87Coefficient( 1632,     2.8455,   7860.4194  ), 
  new Vsop87Coefficient( 1378,     1.1285,   11790.6291  ), 
  new Vsop87Coefficient( 498,      2.587,    9683.595  ), 
  new Vsop87Coefficient( 374,      1.423,    3930.210  ), 
  new Vsop87Coefficient( 264,      5.529,    9437.763  ), 
  new Vsop87Coefficient( 237,      2.551,    15720.839  ), 
  new Vsop87Coefficient( 222,      2.013,    19367.189  ), 
  new Vsop87Coefficient( 126,      2.728,    1577.344  ), 
  new Vsop87Coefficient( 119,      3.020,    10404.734  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R1VenusCoefficients =
{ 
  new Vsop87Coefficient( 34551, 0.89199, 10213.28555  ), 
  new Vsop87Coefficient( 234,   1.772,   20426.571  ), 
  new Vsop87Coefficient( 234,   3.142,   0  )  
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R2VenusCoefficients =
{ 
  new Vsop87Coefficient( 1407, 5.0637, 10213.2855  ), 
  new Vsop87Coefficient( 16,   5.47,   20426.57  ), 
  new Vsop87Coefficient( 13,   0,      0  )  
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R3VenusCoefficients =
{ 
  new Vsop87Coefficient( 50, 3.22, 10213.29  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R4VenusCoefficients =
{ 
  new Vsop87Coefficient( 1, 0.92, 10213.29  )
};
        #endregion
    }
}
