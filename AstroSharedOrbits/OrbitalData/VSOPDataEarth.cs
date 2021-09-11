// <copyright file="VsopDataEarth.cs" company="Traced-Ideas, Czech republic">
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
        #region Earth

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
		public static readonly Vsop87Coefficient[] L0EarthCoefficients =
		{
		    new Vsop87Coefficient(175347046, 0,         0 ),
		    new Vsop87Coefficient(3341656,   4.6692568,  6283.0758500 ),
		    new Vsop87Coefficient(34894,     4.62610,   12566.15170 ),
		    new Vsop87Coefficient(3497,      2.7441,    5753.3849 ),
		    new Vsop87Coefficient(3418,      2.8289,    3.5231 ),
		    new Vsop87Coefficient(3136,      3.6277,    77713.7715 ),
		    new Vsop87Coefficient(2676,      4.4181,    7860.4194 ),
		    new Vsop87Coefficient(2343,      6.1352,     3930.2097 ),
		    new Vsop87Coefficient(1324,      0.7425,    11506.7698 ),
		    new Vsop87Coefficient(1273,      2.0371,     529.6910 ),
		    new Vsop87Coefficient(1199,      1.1096,    1577.3435 ),
		    new Vsop87Coefficient(990,       5.233,     5884.927 ),
		    new Vsop87Coefficient(902,       2.045,     26.298 ),
		    new Vsop87Coefficient(857,       3.508,     398.149 ),
		    new Vsop87Coefficient(780,       1.179,     5223.694 ),
		    new Vsop87Coefficient(753,       2.533,     5507.553 ),
		    new Vsop87Coefficient(505,       4.583,     18849.228 ),
		    new Vsop87Coefficient(492,       4.205,     775.523 ),
		    new Vsop87Coefficient(357,       2.920,     0.067 ),
		    new Vsop87Coefficient(317,       5.849,     11790.629 ),
		    new Vsop87Coefficient(284,       1.899,     796.288 ),
		    new Vsop87Coefficient(271,       0.315,     10977.079 ),
		    new Vsop87Coefficient(243,       0.345,     5486.778 ),
		    new Vsop87Coefficient(206,       4.806,     2544.314 ),
		    new Vsop87Coefficient(205,       1.869,     5573.143 ),
		    new Vsop87Coefficient(202,       2.458,     6069.777 ),
		    new Vsop87Coefficient(156,       0.833,     213.299 ),
		    new Vsop87Coefficient(132,       3.411,     2942.463 ),
		    new Vsop87Coefficient(126,       1.083,     20.775 ),
		    new Vsop87Coefficient(115,       0.645,     0.980 ),
		    new Vsop87Coefficient(103,       0.636,     4694.003 ),
		    new Vsop87Coefficient(102,       0.976,     15720.839 ),
		    new Vsop87Coefficient(102,       4.267,     7.114 ),
		    new Vsop87Coefficient(99,        6.21,      2146.17 ),
		    new Vsop87Coefficient(98,        0.68,      155.42 ),
		    new Vsop87Coefficient(86,        5.98,      161000.69 ),
		    new Vsop87Coefficient(85,        1.30,      6275.96 ),
		    new Vsop87Coefficient(85,        3.67,      71430.70 ),
		    new Vsop87Coefficient(80,        1.81,      17260.15 ),
		    new Vsop87Coefficient(79,        3.04,      12036.46 ),
		    new Vsop87Coefficient(75,        1.76,      5088.63 ),
		    new Vsop87Coefficient(74,        3.50,      3154.69 ),
		    new Vsop87Coefficient(74,        4.68,      801.82 ),
		    new Vsop87Coefficient(70,        0.83,      9437.76 ),
		    new Vsop87Coefficient(62,        3.98,      8827.39 ),
		    new Vsop87Coefficient(61,        1.82,      7084.90 ),
		    new Vsop87Coefficient(57,        2.78,      6286.60 ),
		    new Vsop87Coefficient(56,        4.39,      14143.50 ),
		    new Vsop87Coefficient(56,        3.47,      6279.55 ),
		    new Vsop87Coefficient(52,        0.19,      12139.55 ),
		    new Vsop87Coefficient(52,        1.33,      1748.02 ),
		    new Vsop87Coefficient(51,        0.28,      5856.48 ),
		    new Vsop87Coefficient(49,        0.49,      1194.45 ),
		    new Vsop87Coefficient(41,        5.37,      8429.24 ),
		    new Vsop87Coefficient(41,        2.40,      19651.05 ),
		    new Vsop87Coefficient(39,        6.17,      10447.39 ),
		    new Vsop87Coefficient(37,        6.04,      10213.29 ),
		    new Vsop87Coefficient(37,        2.57,      1059.38 ),
		    new Vsop87Coefficient(36,        1.71,      2352.87 ),
		    new Vsop87Coefficient(36,        1.78,      6812.77 ),
		    new Vsop87Coefficient(33,        0.59,      17789.85 ),
		    new Vsop87Coefficient(30,        0.44,      83996.85 ),
		    new Vsop87Coefficient(30,        2.74,      1349.87 ),
		    new Vsop87Coefficient(25,        3.16,      4690.48 )
		};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
		public static readonly Vsop87Coefficient[] L1EarthCoefficients =
		{
		    new Vsop87Coefficient(628331966747,   0,          0 ),
		    new Vsop87Coefficient(206059,         2.678235,   6283.075850 ),
		    new Vsop87Coefficient(4303,           2.6351,     12566.1517 ),
		    new Vsop87Coefficient(425,            1.590,      3.523 ),
		    new Vsop87Coefficient(119,            5.796,      26.298 ),
		    new Vsop87Coefficient(109,            2.966,      1577.344 ),
		    new Vsop87Coefficient(93,             2.59,       18849.23 ),
		    new Vsop87Coefficient(72,             1.14,       529.69 ),
		    new Vsop87Coefficient(68,             1.87,       398.15 ),
		    new Vsop87Coefficient(67,             4.41,       5507.55 ),
		    new Vsop87Coefficient(59,             2.89,       5223.69 ),
		    new Vsop87Coefficient(56,             2.17,       155.42 ),
		    new Vsop87Coefficient(45,             0.40,       796.30 ),
		    new Vsop87Coefficient(36,             0.47,       775.52 ),
		    new Vsop87Coefficient(29,             2.65,       7.11 ),
		    new Vsop87Coefficient(21,             5.43,       0.98 ),
		    new Vsop87Coefficient(19,             1.85,       5486.78 ),
		    new Vsop87Coefficient(19,             4.97,       213.30 ),
		    new Vsop87Coefficient(17,             2.99,       6275.96 ),
		    new Vsop87Coefficient(16,             0.03,       2544.31 ),
		    new Vsop87Coefficient(16,             1.43,       2146.17 ),
		    new Vsop87Coefficient(15,             1.21,       10977.08 ),
		    new Vsop87Coefficient(12,             2.83,       1748.02 ),
		    new Vsop87Coefficient(12,             3.26,       5088.63 ),
		    new Vsop87Coefficient(12,             5.27,       1194.45 ),
		    new Vsop87Coefficient(12,             2.08,       4694.00 ),
		    new Vsop87Coefficient(11,             0.77,       553.57 ),
		    new Vsop87Coefficient(10,             1.30,       6286.60 ),
		    new Vsop87Coefficient(10,             4.24,       1349.87 ),
		    new Vsop87Coefficient(9,              2.70,       242.73 ),
		    new Vsop87Coefficient(9,              5.64,       951.72 ),
		    new Vsop87Coefficient(8,              5.30,       2352.87 ),
		    new Vsop87Coefficient(6,              2.65,       9437.76 ),
		    new Vsop87Coefficient(6,              4.67,       4690.48 )
		};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L2EarthCoefficients =
        {
            new Vsop87Coefficient(52919,  0,      0 ),
            new Vsop87Coefficient(8720,   1.0721, 6283.0758 ),
            new Vsop87Coefficient(309,    0.867,  12566.152 ),
            new Vsop87Coefficient(27,     0.05,   3.52 ),
            new Vsop87Coefficient(16,     5.19,   26.30 ),
            new Vsop87Coefficient(16,     3.68,   155.42 ),
            new Vsop87Coefficient(10,     0.76,   18849.23 ),
            new Vsop87Coefficient(9,      2.06,   77713.77 ),
            new Vsop87Coefficient(7,      0.83,   775.52 ),
            new Vsop87Coefficient(5,      4.66,   1577.34 ),
            new Vsop87Coefficient(4,      1.03,   7.11 ),
            new Vsop87Coefficient(4,      3.44,   5573.14 ),
            new Vsop87Coefficient(3,      5.14,   796.30 ),
            new Vsop87Coefficient(3,      6.05,   5507.55 ),
            new Vsop87Coefficient(3,      1.19,   242.73 ),
            new Vsop87Coefficient(3,      6.12,   529.69 ),
            new Vsop87Coefficient(3,      0.31,   398.15 ),
            new Vsop87Coefficient(3,      2.28,   553.57 ),
            new Vsop87Coefficient(2,      4.38,   5223.69 ),
            new Vsop87Coefficient(2,      3.75,   0.98 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L3EarthCoefficients =
        {
            new Vsop87Coefficient(289, 5.844, 6283.076 ),
            new Vsop87Coefficient(35,  0,     0 ),
            new Vsop87Coefficient(17,  5.49,  12566.15 ),
            new Vsop87Coefficient(3,   5.20,  155.42 ),
            new Vsop87Coefficient(1,   4.72,  3.52 ),
            new Vsop87Coefficient(1,   5.30,  18849.23 ),
            new Vsop87Coefficient(1,   5.97,  242.73 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L4EarthCoefficients =
        {
            new Vsop87Coefficient(114, 3.142,  0 ), 
            new Vsop87Coefficient(8,   4.13,   6283.08 ),
            new Vsop87Coefficient(1,   3.84,   12566.15 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L5EarthCoefficients =
        {
            new Vsop87Coefficient(1, 3.14, 0 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B0EarthCoefficients =
        {
            new Vsop87Coefficient(280, 3.199, 84334.662 ),
            new Vsop87Coefficient(102, 5.422, 5507.553 ),
            new Vsop87Coefficient(80,  3.88,  5223.69),
            new Vsop87Coefficient(44,  3.70,  2352.87 ),
            new Vsop87Coefficient(32,  4.00,  1577.34 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B1EarthCoefficients =
        {
            new Vsop87Coefficient(9, 3.90, 5507.55 ),
            new Vsop87Coefficient(6, 1.73, 5223.69)
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B2EarthCoefficients =
        {
            new Vsop87Coefficient(22378, 3.38509, 10213.28555 ),
            new Vsop87Coefficient(282,   0,       0 ),
            new Vsop87Coefficient(173,   5.256,   20426.571 ),
            new Vsop87Coefficient(27,    3.87,    30639.86 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B3EarthCoefficients =
        {
            new Vsop87Coefficient(647, 4.992, 10213.286 ),
            new Vsop87Coefficient(20,  3.14,  0 ),
            new Vsop87Coefficient(6,   0.77,  20426.57 ),
            new Vsop87Coefficient(3,   5.44,  30639.86 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B4EarthCoefficients =
        {
            new Vsop87Coefficient(14, 0.32, 10213.29 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R0EarthCoefficients =
        {
            new Vsop87Coefficient(100013989,  0,          0 ),
            new Vsop87Coefficient(1670700,    3.0984635,  6283.0758500 ),
            new Vsop87Coefficient(13956,      3.05525,    12566.15170 ),
            new Vsop87Coefficient(3084,       5.1985,     77713.7715 ),
            new Vsop87Coefficient(1628,       1.1739,     5753.3849 ),
            new Vsop87Coefficient(1576,       2.8469,     7860.4194 ),
            new Vsop87Coefficient(925,        5.453,      11506.770 ),
            new Vsop87Coefficient(542,        4.564,      3930.210 ),
            new Vsop87Coefficient(472,        3.661,      5884.927 ),
            new Vsop87Coefficient(346,        0.964,      5507.553 ),
            new Vsop87Coefficient(329,        5.900,      5223.694 ),
            new Vsop87Coefficient(307,        0.299,      5573.143 ),
            new Vsop87Coefficient(243,        4.273,      11790.629 ),
            new Vsop87Coefficient(212,        5.847,      1577.344 ),
            new Vsop87Coefficient(186,        5.022,      10977.079 ),
            new Vsop87Coefficient(175,        3.012,      18849.228 ),
            new Vsop87Coefficient(110,        5.055,      5486.778 ),
            new Vsop87Coefficient(98,         0.89,       6069.78 ),
            new Vsop87Coefficient(86,         5.69,       15720.84 ),
            new Vsop87Coefficient(86,         1.27,       161000.69),
            new Vsop87Coefficient(65,         0.27,       17260.15 ),
            new Vsop87Coefficient(63,         0.92,       529.69 ),
            new Vsop87Coefficient(57,         2.01,       83996.85 ),
            new Vsop87Coefficient(56,         5.24,       71430.70 ),
            new Vsop87Coefficient(49,         3.25,       2544.31 ),
            new Vsop87Coefficient(47,         2.58,       775.52 ),
            new Vsop87Coefficient(45,         5.54,       9437.76 ),
            new Vsop87Coefficient(43,         6.01,       6275.96 ),
            new Vsop87Coefficient(39,         5.36,       4694.00 ),
            new Vsop87Coefficient(38,         2.39,       8827.39 ),
            new Vsop87Coefficient(37,         0.83,       19651.05 ),
            new Vsop87Coefficient(37,         4.90,       12139.55 ),
            new Vsop87Coefficient(36,         1.67,       12036.46 ),
            new Vsop87Coefficient(35,         1.84,       2942.46 ),
            new Vsop87Coefficient(33,         0.24,       7084.90 ),
            new Vsop87Coefficient(32,         0.18,       5088.63 ),
            new Vsop87Coefficient(32,         1.78,       398.15 ),
            new Vsop87Coefficient(28,         1.21,       6286.60 ),
            new Vsop87Coefficient(28,         1.90,       6279.55 ),
            new Vsop87Coefficient(26,         4.59,       10447.39 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R1EarthCoefficients =
        {
            new Vsop87Coefficient(103019, 1.107490, 6283.075850 ),
            new Vsop87Coefficient(1721,   1.0644,   12566.1517 ),
            new Vsop87Coefficient(702,    3.142,    0 ),
            new Vsop87Coefficient(32,     1.02,     18849.23 ),
            new Vsop87Coefficient(31,     2.84,     5507.55 ),
            new Vsop87Coefficient(25,     1.32,     5223.69 ),
            new Vsop87Coefficient(18,     1.42,     1577.34 ),
            new Vsop87Coefficient(10,     5.91,     10977.08 ),
            new Vsop87Coefficient(9,      1.42,     6275.96 ),
            new Vsop87Coefficient(9,      0.27,     5486.78 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R2EarthCoefficients =
        {
            new Vsop87Coefficient(4359, 5.7846, 6283.0758 ),
            new Vsop87Coefficient(124,  5.579,  12566.152 ),
            new Vsop87Coefficient(12,   3.14,   0 ),
            new Vsop87Coefficient(9,    3.63,   77713.77 ),
            new Vsop87Coefficient(6,    1.87,   5573.14 ),
            new Vsop87Coefficient(3,    5.47,   18849.23 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R3EarthCoefficients =
        {
            new Vsop87Coefficient(145,  4.273,  6283.076 ),
            new Vsop87Coefficient(7,    3.92,   12566.15 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R4EarthCoefficients =
        {
            new Vsop87Coefficient(4, 2.56, 6283.08 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L1EarthCoefficientsJ2000 =
        {
            new Vsop87Coefficient(628307584999,   0,          0 ),
            new Vsop87Coefficient(206059,         2.678235,   6283.075850 ),
            new Vsop87Coefficient(4303,           2.6351,     12566.1517 ),
            new Vsop87Coefficient(425,            1.590,      3.523 ),
            new Vsop87Coefficient(119,            5.796,      26.298 ),
            new Vsop87Coefficient(109,            2.966,      1577.344 ),
            new Vsop87Coefficient(93,             2.59,       18849.23 ),
            new Vsop87Coefficient(72,             1.14,       529.69 ),
            new Vsop87Coefficient(68,             1.87,       398.15 ),
            new Vsop87Coefficient(67,             4.41,       5507.55 ),
            new Vsop87Coefficient(59,             2.89,       5223.69 ),
            new Vsop87Coefficient(56,             2.17,       155.42 ),
            new Vsop87Coefficient(45,             0.40,       796.30 ),
            new Vsop87Coefficient(36,             0.47,       775.52 ),
            new Vsop87Coefficient(29,             2.65,       7.11 ),
            new Vsop87Coefficient(21,             5.43,       0.98 ),
            new Vsop87Coefficient(19,             1.85,       5486.78 ),
            new Vsop87Coefficient(19,             4.97,       213.30 ),
            new Vsop87Coefficient(17,             2.99,       6275.96 ),
            new Vsop87Coefficient(16,             0.03,       2544.31 ),
            new Vsop87Coefficient(16,             1.43,       2146.17 ),
            new Vsop87Coefficient(15,             1.21,       10977.08 ),
            new Vsop87Coefficient(12,             2.83,       1748.02 ),
            new Vsop87Coefficient(12,             3.26,       5088.63 ),
            new Vsop87Coefficient(12,             5.27,       1194.45 ),
            new Vsop87Coefficient(12,             2.08,       4694.00 ),
            new Vsop87Coefficient(11,             0.77,       553.57 ),
            new Vsop87Coefficient(10,             1.30,       6286.60 ),
            new Vsop87Coefficient(10,             4.24,       1349.87 ),
            new Vsop87Coefficient(9,              2.70,       242.73 ),
            new Vsop87Coefficient(9,              5.64,       951.72 ),
            new Vsop87Coefficient(8,              5.30,       2352.87 ),
            new Vsop87Coefficient(6,              2.65,       9437.76 ),
            new Vsop87Coefficient(6,              4.67,       4690.48 )            
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L2EarthCoefficientsJ2000 =
        {
            new Vsop87Coefficient(8722, 1.0725, 6283.0758 ),
            new Vsop87Coefficient(991,  3.1416, 0 ),
            new Vsop87Coefficient(295,  0.437,  12566.152 ),
            new Vsop87Coefficient(27,   0.05,   3.52 ),
            new Vsop87Coefficient(16,   5.19,   26.30 ),
            new Vsop87Coefficient(16,   3.69,   155.42 ),
            new Vsop87Coefficient(9,    0.30,   18849.23 ),
            new Vsop87Coefficient(9,    2.06,   77713.77 ),
            new Vsop87Coefficient(7,    0.83,   775.52 ),
            new Vsop87Coefficient(5,    4.66,   1577.34 ),
            new Vsop87Coefficient(4,    1.03,   7.11 ),
            new Vsop87Coefficient(4,    3.44,   5573.14 ),
            new Vsop87Coefficient(3,    5.14,   796.30 ),
            new Vsop87Coefficient(3,    6.05,   5507.55 ),
            new Vsop87Coefficient(3,    1.19,   242.73 ),
            new Vsop87Coefficient(3,    6.12,   529.69 ),
            new Vsop87Coefficient(3,    0.30,   398.15 ),
            new Vsop87Coefficient(3,    2.28,   553.57 ),
            new Vsop87Coefficient(2,    4.38,   5223.69 ),
            new Vsop87Coefficient(2,    3.75,   0.98 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L3EarthCoefficientsJ2000 =
        {
            new Vsop87Coefficient(289,  5.842,  6283.076 ),
            new Vsop87Coefficient(21,   6.05,   12566.15 ),
            new Vsop87Coefficient(3,    5.20,   155.42 ),
            new Vsop87Coefficient(3,    3.14,   0 ),
            new Vsop87Coefficient(1,    4.72,   3.52 ),
            new Vsop87Coefficient(1,    5.97,   242.73 ),
            new Vsop87Coefficient(1,    5.54,   18849.23 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L4EarthCoefficientsJ2000 =
        {
            new Vsop87Coefficient(8,  4.14, 6283.08 ),
            new Vsop87Coefficient(1,  3.28, 12566.15 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B1EarthCoefficientsJ2000 =
        {
            new Vsop87Coefficient(227778, 3.413766, 6283.075850 ),
            new Vsop87Coefficient(3806,   3.3706,   12566.1517 ),
            new Vsop87Coefficient(3620,   0,        0 ),
            new Vsop87Coefficient(72,     3.33,     18849.23 ),
            new Vsop87Coefficient(8,      3.89,     5507.55 ),
            new Vsop87Coefficient(8,      1.79,     5223.69 ),
            new Vsop87Coefficient(6,      5.20,     2352.87 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B2EarthCoefficientsJ2000 =
        {
            new Vsop87Coefficient(9721, 5.1519, 6283.07585 ),
            new Vsop87Coefficient(233,  3.1416, 0 ),
            new Vsop87Coefficient(134,  0.644,  12566.152 ),
            new Vsop87Coefficient(7,    1.07,   18849.23 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B3EarthCoefficientsJ2000 =
        {
            new Vsop87Coefficient(276,  0.595,  6283.076 ),
            new Vsop87Coefficient(17,   3.14,   0 ),
            new Vsop87Coefficient(4,    0.12,   12566.15 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B4EarthCoefficientsJ2000 =
        {
            new Vsop87Coefficient(6,  2.27, 6283.08 ),
            new Vsop87Coefficient(1,  0,    0 )
        };
        #endregion
    }
}
