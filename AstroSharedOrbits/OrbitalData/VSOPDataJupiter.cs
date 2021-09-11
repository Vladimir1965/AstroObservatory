// <copyright file="VsopDataJupiter.cs" company="Traced-Ideas, Czech republic">
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
        #region Jupiter

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L0JupiterCoefficients = 
{ 
  new Vsop87Coefficient( 59954691, 0,          0 ),
  new Vsop87Coefficient(  9695899,  5.0619179,  529.6909651 ),
  new Vsop87Coefficient(  573610,   1.444062,   7.113547 ),
  new Vsop87Coefficient(  306389,   5.417347,   1059.381930 ),
  new Vsop87Coefficient(  97178,    4.14265,    632.78374 ),
  new Vsop87Coefficient(  72903,    3.64043,    522.57742 ),
  new Vsop87Coefficient(  64264,    3.41145,    103.09277 ),
  new Vsop87Coefficient(  39806,    2.29377,    419.48464 ),
  new Vsop87Coefficient(  38858,    1.27232,    316.39187 ),
  new Vsop87Coefficient(  27965,    1.78455,    536.80451 ),
  new Vsop87Coefficient(  13590,    5.77481,    1589.07290 ),
  new Vsop87Coefficient(  8769,     3.6300,     949.1756 ),
  new Vsop87Coefficient(  8246,     3.5823,     206.1855 ),
  new Vsop87Coefficient(  7368,     5.0810,     735.8765 ),
  new Vsop87Coefficient(  6263,     0.0250,     213.2991 ),
  new Vsop87Coefficient(  6114,     4.5132,     1162.4747 ),
  new Vsop87Coefficient(  5305,     4.1863,     1052.2684 ),
  new Vsop87Coefficient(  5305,     1.3067,     14.2271 ),
  new Vsop87Coefficient(  4905,     1.3208,     110.2063 ),
  new Vsop87Coefficient(  4647,     4.6996,     3.9322 ),
  new Vsop87Coefficient(  3045,     4.3168,     426.5982 ),
  new Vsop87Coefficient(  2610,     1.5667,     846.0828 ),
  new Vsop87Coefficient(  2028,     1.0638,     3.1814 ),
  new Vsop87Coefficient(  1921,     0.9717,     639.8973 ),
  new Vsop87Coefficient(  1765,     2.1415,     1066.4955 ),
  new Vsop87Coefficient(  1723,     3.8804,     1265.5675 ),
  new Vsop87Coefficient(  1633,     3.5820,     515.4639 ),
  new Vsop87Coefficient(  1432,     4.2968,     625.6702 ),
  new Vsop87Coefficient(  973,      4.098,      95.979 ),
  new Vsop87Coefficient(  884,      2.437,      412.371 ),
  new Vsop87Coefficient(  733,      6.085,      838.969 ),
  new Vsop87Coefficient(  731,      3.806,      1581.959 ),
  new Vsop87Coefficient(  709,      1.293,      742.990 ),
  new Vsop87Coefficient(  692,      6.134,      2118.764 ),
  new Vsop87Coefficient(  614,      4.109,      1478.867 ),
  new Vsop87Coefficient(  582,      4.540,      309.278 ),
  new Vsop87Coefficient(  495,      3.756,      323.505 ),
  new Vsop87Coefficient(  441,      2.958,      454.909 ),
  new Vsop87Coefficient(  417,      1.036,      2.488 ),
  new Vsop87Coefficient(  390,      4.897,      1692.166 ),
  new Vsop87Coefficient(  376,      4.703,      1368.660 ),
  new Vsop87Coefficient(  341,      5.715,      533.623 ),
  new Vsop87Coefficient(  330,      4.740,      0.048 ),
  new Vsop87Coefficient(  262,      1.877,      0.963 ),
  new Vsop87Coefficient(  261,      0.820,      380.128 ),
  new Vsop87Coefficient(  257,      3.724,      199.072 ),
  new Vsop87Coefficient(  244,      5.220,      728.763 ),
  new Vsop87Coefficient(  235,      1.227,      909.819 ),
  new Vsop87Coefficient(  220,      1.651,      543.918 ),
  new Vsop87Coefficient(  207,      1.855,      525.759 ),
  new Vsop87Coefficient(  202,      1.807,      1375.774 ),
  new Vsop87Coefficient(  197,      5.293,      1155.361 ),
  new Vsop87Coefficient(  175,      3.730,      942.062 ),
  new Vsop87Coefficient(  175,      3.226,      1898.351 ),
  new Vsop87Coefficient(  175,      5.910,      956.289 ),
  new Vsop87Coefficient(  158,      4.365,      1795.258 ),
  new Vsop87Coefficient(  151,      3.906,      74.782 ),
  new Vsop87Coefficient(  149,      4.377,      1685.052 ),
  new Vsop87Coefficient(  141,      3.136,      491.558 ),
  new Vsop87Coefficient(  138,      1.318,      1169.588 ),
  new Vsop87Coefficient(  131,      4.169,      1045.155 ),
  new Vsop87Coefficient(  117,      2.500,      1596.186 ),
  new Vsop87Coefficient(  117,      3.389,      0.521 ),
  new Vsop87Coefficient(  106,      4.554,      526.510) 
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L1JupiterCoefficients =
        { 
            new Vsop87Coefficient(  52993480757.0, 0,          0 ),
            new Vsop87Coefficient(  489741,        4.220667,   529.690965 ),
            new Vsop87Coefficient(  228919,        6.026475,   7.113547 ),
            new Vsop87Coefficient(  27655,         4.57266,    1059.38193 ),
            new Vsop87Coefficient(  20721,         5.45939,    522.57742 ),
            new Vsop87Coefficient(  12106,         0.16986,    536.80451 ),
            new Vsop87Coefficient(  6068,          4.4242,     103.0928 ),
            new Vsop87Coefficient(  5434,          3.9848,     419.4846 ),
            new Vsop87Coefficient(  4238,          5.8901,     14.2271 ),
            new Vsop87Coefficient(  2212,          5.2677,     206.1855 ),
            new Vsop87Coefficient(  1746,          4.9267,     1589.0729 ),
            new Vsop87Coefficient(  1296,          5.5513,     3.1814 ),
            new Vsop87Coefficient(  1173,          5.8565,     1052.2684 ),
            new Vsop87Coefficient(  1163,          0.5145,     3.9322 ),
            new Vsop87Coefficient(  1099,          5.3070,     515.4639 ),
            new Vsop87Coefficient(  1007,          0.4648,     735.8765 ),
            new Vsop87Coefficient(  1004,          3.1504,     426.5982 ),
            new Vsop87Coefficient(  848,           5.758,      110.206 ),
            new Vsop87Coefficient(  827,           4.803,      213.299 ),
            new Vsop87Coefficient(  816,           0.586,      1066.495 ),
            new Vsop87Coefficient(  725,           5.518,      639.897 ),
            new Vsop87Coefficient(  568,           5.989,      625.670 ),
            new Vsop87Coefficient(  474,           4.132,      412.371 ),
            new Vsop87Coefficient(  413,           5.737,      95.979 ),
            new Vsop87Coefficient(  345,           4.242,      632.784 ),
            new Vsop87Coefficient(  336,           3.732,      1162.475 ),
            new Vsop87Coefficient(  234,           4.035,      949.176 ),
            new Vsop87Coefficient(  234,           6.243,      309.278 ),
            new Vsop87Coefficient(  199,           1.505,      838.969 ),
            new Vsop87Coefficient(  195,           2.219,      323.505 ),
            new Vsop87Coefficient(  187,           6.086,      742.990 ),
            new Vsop87Coefficient(  184,           6.280,      543.918 ),
            new Vsop87Coefficient(  171,           5.417,      199.072 ),
            new Vsop87Coefficient(  131,           0.626,      728.763 ),
            new Vsop87Coefficient(  115,           0.680,      846.083 ),
            new Vsop87Coefficient(  115,           5.286,      2118.764 ),
            new Vsop87Coefficient(  108,           4.493,      956.289 ),
            new Vsop87Coefficient(  80,            5.82,       1045.15 ),
            new Vsop87Coefficient(  72,            5.34,       942.06 ),
            new Vsop87Coefficient(  70,            5.97,       532.87 ),
            new Vsop87Coefficient(  67,            5.73,       21.34 ),
            new Vsop87Coefficient(  66,            0.13,       526.51 ),
            new Vsop87Coefficient(  65,            6.09,       1581.96 ),
            new Vsop87Coefficient(  59,            0.59,       1155.36 ),
            new Vsop87Coefficient(  58,            0.99,       1596.19 ),
            new Vsop87Coefficient(  57,            5.97,       1169.59 ),
            new Vsop87Coefficient(  57,            1.41,       533.62 ),
            new Vsop87Coefficient(  55,            5.43,       10.29 ),
            new Vsop87Coefficient(  52,            5.73,       117.32 ),
            new Vsop87Coefficient(  52,            0.23,       1368.66 ),
            new Vsop87Coefficient(  50,            6.08,       525.76 ),
            new Vsop87Coefficient(  47,            3.63,       1478.87 ),
            new Vsop87Coefficient(  47,            0.51,       1265.57 ),
            new Vsop87Coefficient(  40,            4.16,       1692.17 ),
            new Vsop87Coefficient(  34,            0.10,       302.16 ),
            new Vsop87Coefficient(  33,            5.04,       220.41 ),
            new Vsop87Coefficient(  32,            5.37,       508.35 ),
            new Vsop87Coefficient(  29,            5.42,       1272.68 ),
            new Vsop87Coefficient(  29,            3.36,       4.67 ),
            new Vsop87Coefficient(  29,            0.76,       88.87 ),
            new Vsop87Coefficient(  25,            1.61,       831.86 )
        };

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L2JupiterCoefficients =
{ 
  new Vsop87Coefficient(  47234,  4.32148,  7.11355 ),
  new Vsop87Coefficient(  38966,  0,        0 ),
  new Vsop87Coefficient(  30629,  2.93021,  529.69097 ),
  new Vsop87Coefficient(  3189,   1.0550,   522.5774 ),
  new Vsop87Coefficient(  2729,   4.8455,   536.8045 ),
  new Vsop87Coefficient(  2723,   3.4141,   1059.3819 ),
  new Vsop87Coefficient(  1721,   4.1873,   14.2271 ),
  new Vsop87Coefficient(  383,    5.768,    419.485 ),
  new Vsop87Coefficient(  378,    0.760,    515.464 ),
  new Vsop87Coefficient(  367,    6.055,    103.093 ),
  new Vsop87Coefficient(  337,    3.786,    3.181 ),
  new Vsop87Coefficient(  308,    0.694,    206.186 ),
  new Vsop87Coefficient(  218,    3.814,    1589.073 ),
  new Vsop87Coefficient(  199,    5.340,    1066.495 ),
  new Vsop87Coefficient(  197,    2.484,    3.932 ),
  new Vsop87Coefficient(  156,    1.406,    1052.268 ),
  new Vsop87Coefficient(  146,    3.814,    639.897 ),
  new Vsop87Coefficient(  142,    1.634,    426.598 ),
  new Vsop87Coefficient(  130,    5.837,    412.371 ),
  new Vsop87Coefficient(  117,    1.414,    625.670 ),
  new Vsop87Coefficient(  97,     4.03,     110.21 ),
  new Vsop87Coefficient(  91,     1.11,     95.98 ),
  new Vsop87Coefficient(  87,     2.52,     632.78 ),
  new Vsop87Coefficient(  79,     4.64,     543.92 ),
  new Vsop87Coefficient(  72,     2.22,     735.88 ),
  new Vsop87Coefficient(  58,     0.83,     199.07 ),
  new Vsop87Coefficient(  57,     3.12,     213.30 ),
  new Vsop87Coefficient(  49,     1.67,     309.28 ),
  new Vsop87Coefficient(  40,     4.02,     21.34 ),
  new Vsop87Coefficient(  40,     0.62,     323.51 ),
  new Vsop87Coefficient(  36,     2.33,     728.76 ),
  new Vsop87Coefficient(  29,     3.61,     10.29 ),
  new Vsop87Coefficient(  28,     3.24,     838.97 ),
  new Vsop87Coefficient(  26,     4.50,     742.99 ),
  new Vsop87Coefficient(  26,     2.51,     1162.47 ),
  new Vsop87Coefficient(  25,     1.22,     1045.15 ),
  new Vsop87Coefficient(  24,     3.01,     956.29 ),
  new Vsop87Coefficient(  19,     4.29,     532.87 ),
  new Vsop87Coefficient(  18,     0.81,     508.35 ),
  new Vsop87Coefficient(  17,     4.20,     2118.76 ),
  new Vsop87Coefficient(  17,     1.83,     526.51 ),
  new Vsop87Coefficient(  15,     5.81,     1596.19 ),
  new Vsop87Coefficient(  15,     0.68,     942.06 ),
  new Vsop87Coefficient(  15,     4.00,     117.32 ),
  new Vsop87Coefficient(  14,     5.95,     316.39 ),
  new Vsop87Coefficient(  14,     1.80,     302.16 ),
  new Vsop87Coefficient(  13,     2.52,     88.87 ),
  new Vsop87Coefficient(  13,     4.37,     1169.59 ),
  new Vsop87Coefficient(  11,     4.44,     525.76 ),
  new Vsop87Coefficient(  10,     1.72,     1581.96 ),
  new Vsop87Coefficient(  9,      2.18,     1155.36 ),
  new Vsop87Coefficient(  9,      3.29,     220.41 ),
  new Vsop87Coefficient(  9,      3.32,     831.86 ),
  new Vsop87Coefficient(  8,      5.76,     846.08 ),
  new Vsop87Coefficient(  8,      2.71,     533.62 ),
  new Vsop87Coefficient(  7,      2.18,     1265.57 ),
  new Vsop87Coefficient(  6,      0.50,     949.18 ) 
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L3JupiterCoefficients =
{ 
  new Vsop87Coefficient(  6502, 2.5986, 7.1135 ),
  new Vsop87Coefficient(  1357, 1.3464, 529.6910 ),
  new Vsop87Coefficient(  471,  2.475,  14.227 ),
  new Vsop87Coefficient(  417,  3.245,  536.805 ),
  new Vsop87Coefficient(  353,  2.974,  522.577 ),
  new Vsop87Coefficient(  155,  2.076,  1059.382 ),
  new Vsop87Coefficient(  87,   2.51,   515.46 ),
  new Vsop87Coefficient(  44,   0,      0 ),
  new Vsop87Coefficient(  34,   3.83,   1066.50 ),
  new Vsop87Coefficient(  28,   2.45,   206.19 ),
  new Vsop87Coefficient(  24,   1.28,   412.37 ),
  new Vsop87Coefficient(  23,   2.98,   543.92 ),
  new Vsop87Coefficient(  20,   2.10,   639.90 ),
  new Vsop87Coefficient(  20,   1.40,   419.48 ),
  new Vsop87Coefficient(  19,   1.59,   103.09 ),
  new Vsop87Coefficient(  17,   2.30,   21.34 ),
  new Vsop87Coefficient(  17,   2.60,   1589.07 ),
  new Vsop87Coefficient(  16,   3.15,   625.67 ),
  new Vsop87Coefficient(  16,   3.36,   1052.27 ),
  new Vsop87Coefficient(  13,   2.76,   95.98 ),
  new Vsop87Coefficient(  13,   2.54,   199.07 ),
  new Vsop87Coefficient(  13,   6.27,   426.60 ),
  new Vsop87Coefficient(  9,    1.76,   10.29 ),
  new Vsop87Coefficient(  9,    2.27,   110.21 ),
  new Vsop87Coefficient(  7,    3.43,   309.28 ),
  new Vsop87Coefficient(  7,    4.04,   728.76 ),
  new Vsop87Coefficient(  6,    2.52,   508.35 ),
  new Vsop87Coefficient(  5,    2.91,   1045.15 ),
  new Vsop87Coefficient(  5,    5.25,   323.51 ),
  new Vsop87Coefficient(  4,    4.30,   88.87 ),
  new Vsop87Coefficient(  4,    3.52,   302.16 ),
  new Vsop87Coefficient(  4,    4.09,   735.88 ),
  new Vsop87Coefficient(  3,    1.43,   956.29 ),
  new Vsop87Coefficient(  3,    4.36,   1596.19 ),
  new Vsop87Coefficient(  3,    1.25,   213.30 ),
  new Vsop87Coefficient(  3,    5.02,   838.97 ),
  new Vsop87Coefficient(  3,    2.24,   117.32 ),
  new Vsop87Coefficient(  2,    2.90,   742.99 ),
  new Vsop87Coefficient(  2,    2.36,   942.06 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L4JupiterCoefficients =
{ 
  new Vsop87Coefficient(  669,  0.853,  7.114 ),
  new Vsop87Coefficient(  114,  3.142,  0 ),
  new Vsop87Coefficient(  100,  0.743,  14.227 ),
  new Vsop87Coefficient(  50,   1.65,   536.80 ),
  new Vsop87Coefficient(  44,   5.82,   529.69 ),
  new Vsop87Coefficient(  32,   4.86,   522.58 ),
  new Vsop87Coefficient(  15,   4.29,   515.46 ),
  new Vsop87Coefficient(  9,    0.71,   1059.38 ),
  new Vsop87Coefficient(  5,    1.30,   543.92 ),
  new Vsop87Coefficient(  4,    2.32,   1066.50 ),
  new Vsop87Coefficient(  4,    0.48,   21.34 ),
  new Vsop87Coefficient(  3,    3.00,   412.37 ),
  new Vsop87Coefficient(  2,    0.40,   639.90 ),
  new Vsop87Coefficient(  2,    4.26,   199.07 ),
  new Vsop87Coefficient(  2,    4.91,   625.67 ),
  new Vsop87Coefficient(  2,    4.26,   206.19 ),
  new Vsop87Coefficient(  1,    5.26,   1052.27 ),
  new Vsop87Coefficient(  1,    4.72,   95.98 ),
  new Vsop87Coefficient(  1,    1.29,   1589.07 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] L5JupiterCoefficients =
{ 
  new Vsop87Coefficient(  50, 5.26, 7.11 ),
  new Vsop87Coefficient(  16, 5.25, 14.23 ),
  new Vsop87Coefficient(  4,  0.01, 536.80 ),
  new Vsop87Coefficient(  2,  1.10, 522.58 ),
  new Vsop87Coefficient(  1,  3.14, 0 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B0JupiterCoefficients =
{ 
  new Vsop87Coefficient(  2268616,  3.5585261,  529.6909651 ),
  new Vsop87Coefficient(  110090,   0,          0 ),
  new Vsop87Coefficient(  109972,   3.908093,   1059.381930 ),
  new Vsop87Coefficient(  8101,     3.6051,     522.5774 ),
  new Vsop87Coefficient(  6438,     0.3063,     536.8045 ),
  new Vsop87Coefficient(  6044,     4.2588,     1589.0729 ),
  new Vsop87Coefficient(  1107,     2.9853,     1162.4747 ),
  new Vsop87Coefficient(  944,      1.675,      426.598 ),
  new Vsop87Coefficient(  942,      2.936,      1052.268 ),
  new Vsop87Coefficient(  894,      1.754,      7.114 ),
  new Vsop87Coefficient(  836,      5.179,      103.093 ),
  new Vsop87Coefficient(  767,      2.155,      632.784 ),
  new Vsop87Coefficient(  684,      3.678,      213.299 ),
  new Vsop87Coefficient(  629,      0.643,      1066.495 ),
  new Vsop87Coefficient(  559,      0.014,      846.083 ),
  new Vsop87Coefficient(  532,      2.703,      110.206 ),
  new Vsop87Coefficient(  464,      1.173,      949.176 ),
  new Vsop87Coefficient(  431,      2.608,      419.485 ),
  new Vsop87Coefficient(  351,      4.611,      2118.764 ),
  new Vsop87Coefficient(  132,      4.778,      742.990 ),
  new Vsop87Coefficient(  123,      3.350,      1692.166 ),
  new Vsop87Coefficient(  116,      1.387,      323.505 ),
  new Vsop87Coefficient(  115,      5.049,      316.392 ),
  new Vsop87Coefficient(  104,      3.701,      515.464 ),
  new Vsop87Coefficient(  103,      2.319,      1478.867 ),
  new Vsop87Coefficient(  102,      3.153,      1581.959 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B1JupiterCoefficients =
{ 
  new Vsop87Coefficient(  177352, 5.701665, 529.690965 ),
  new Vsop87Coefficient(  3230,   5.7794,   1059.3819 ),
  new Vsop87Coefficient(  3081,   5.4746,   522.5774 ),
  new Vsop87Coefficient(  2212,   4.7348,   536.8045 ),
  new Vsop87Coefficient(  1694,   3.1416,   0 ),
  new Vsop87Coefficient(  346,    4.746,    1052.268 ),
  new Vsop87Coefficient(  234,    5.189,    1066.495 ),
  new Vsop87Coefficient(  196,    6.186,    7.114 ),
  new Vsop87Coefficient(  150,    3.927,    1589.073 ),
  new Vsop87Coefficient(  114,    3.439,    632.784 ),
  new Vsop87Coefficient(  97,     2.91,     949.18 ),
  new Vsop87Coefficient(  82,     5.08,     1162.47 ),
  new Vsop87Coefficient(  77,     2.51,     103.09 ),
  new Vsop87Coefficient(  77,     0.61,     419.48 ),
  new Vsop87Coefficient(  74,     5.50,     515.46 ),
  new Vsop87Coefficient(  61,     5.45,     213.30 ),
  new Vsop87Coefficient(  50,     3.95,     735.88 ),
  new Vsop87Coefficient(  46,     0.54,     110.21 ),
  new Vsop87Coefficient(  45,     1.90,     846.08 ),
  new Vsop87Coefficient(  37,     4.70,     543.92 ),
  new Vsop87Coefficient(  36,     6.11,     316.39 ),
  new Vsop87Coefficient(  32,     4.92,     1581.96 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B2JupiterCoefficients =
{ 
  new Vsop87Coefficient(  8094, 1.4632, 529.6910 ),
  new Vsop87Coefficient(  813,  3.1416, 0 ),
  new Vsop87Coefficient(  742,  0.957,  522.577 ),
  new Vsop87Coefficient(  399,  2.899,  536.805 ),
  new Vsop87Coefficient(  342,  1.447,  1059.382 ),
  new Vsop87Coefficient(  74,   0.41,   1052.27 ),
  new Vsop87Coefficient(  46,   3.48,   1066.50 ),
  new Vsop87Coefficient(  30,   1.93,   1589.07 ),
  new Vsop87Coefficient(  29,   0.99,   515.46 ),
  new Vsop87Coefficient(  23,   4.27,   7.11 ),
  new Vsop87Coefficient(  14,   2.92,   543.92 ),
  new Vsop87Coefficient(  12,   5.22,   632.78 ),
  new Vsop87Coefficient(  11,   4.88,   949.18 ),
  new Vsop87Coefficient(  6,    6.21,   1045.15 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B3JupiterCoefficients =
{ 
  new Vsop87Coefficient(  252,  3.381,  529.691 ),
  new Vsop87Coefficient(  122,  2.733,  522.577 ),
  new Vsop87Coefficient(  49,   1.04,   536.80 ),
  new Vsop87Coefficient(  11,   2.31,   1052.27 ),
  new Vsop87Coefficient(  8,    2.77,   515.46 ),
  new Vsop87Coefficient(  7,    4.25,   1059.38 ),
  new Vsop87Coefficient(  6,    1.78,   1066.50 ),
  new Vsop87Coefficient(  4,    1.13,   543.92 ),
  new Vsop87Coefficient(  3,    3.14,   0 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B4JupiterCoefficients =
{ 
  new Vsop87Coefficient(  15, 4.53, 522.58 ),
  new Vsop87Coefficient(  5,  4.47, 529.69 ),
  new Vsop87Coefficient(  4,  5.44, 536.80 ),
  new Vsop87Coefficient(  3,  0,    0 ),
  new Vsop87Coefficient(  2,  4.52, 515.46 ),
  new Vsop87Coefficient(  1,  4.20, 1052.27 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] B5JupiterCoefficients =
{ 
  new Vsop87Coefficient(  1,  0.09, 522.58 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R0JupiterCoefficients =
{ 
  new Vsop87Coefficient(  520887429,  0,          0 ),
  new Vsop87Coefficient(  25209327,   3.49108640, 529.69096509 ),
  new Vsop87Coefficient(  610600,     3.841154,   1059.381930 ),
  new Vsop87Coefficient(  282029,     2.574199,   632.783739 ),
  new Vsop87Coefficient(  187647,     2.075904,   522.577418 ),
  new Vsop87Coefficient(  86793,      0.71001,    419.48464 ),
  new Vsop87Coefficient(  72063,      0.21466,    536.80451 ),
  new Vsop87Coefficient(  65517,      5.97996,    316.39187 ),
  new Vsop87Coefficient(  30135,      2.16132,    949.17561 ),
  new Vsop87Coefficient(  29135,      1.67759,    103.09277 ),
  new Vsop87Coefficient(  23947,      0.27458,    7.11355 ),
  new Vsop87Coefficient(  23453,      3.54023,    735.87651 ),
  new Vsop87Coefficient(  22284,      4.19363,    1589.07290 ),
  new Vsop87Coefficient(  13033,      2.96043,    1162.47470 ),
  new Vsop87Coefficient(  12749,      2.71550,    1052.26838 ),
  new Vsop87Coefficient(  9703,       1.9067,     206.1855 ),
  new Vsop87Coefficient(  9161,       4.4135,     213.2991 ),
  new Vsop87Coefficient(  7895,       2.4791,     426.5982 ),
  new Vsop87Coefficient(  7058,       2.1818,     1265.5675 ),
  new Vsop87Coefficient(  6138,       6.2642,     846.0828 ),
  new Vsop87Coefficient(  5477,       5.6573,     639.8973 ),
  new Vsop87Coefficient(  4170,       2.0161,     515.4639 ),
  new Vsop87Coefficient(  4137,       2.7222,     625.6702 ),
  new Vsop87Coefficient(  3503,       0.5653,     1066.4955 ),
  new Vsop87Coefficient(  2617,       2.0099,     1581.9593 ),
  new Vsop87Coefficient(  2500,       4.5518,     838.9693 ),
  new Vsop87Coefficient(  2128,       6.1275,     742.9901 ),
  new Vsop87Coefficient(  1912,       0.8562,     412.3711 ),
  new Vsop87Coefficient(  1611,       3.0887,     1368.6603 ),
  new Vsop87Coefficient(  1479,       2.6803,     1478.8666 ),
  new Vsop87Coefficient(  1231,       1.8904,     323.5054 ),
  new Vsop87Coefficient(  1217,       1.8017,     110.2063 ),
  new Vsop87Coefficient(  1015,       1.3867,     454.9094 ),
  new Vsop87Coefficient(  999,        2.872,      309.278 ),
  new Vsop87Coefficient(  961,        4.549,      2118.764 ),
  new Vsop87Coefficient(  886,        4.148,      533.623 ),
  new Vsop87Coefficient(  821,        1.593,      1898.351 ),
  new Vsop87Coefficient(  812,        5.941,      909.819 ),
  new Vsop87Coefficient(  777,        3.677,      728.763 ),
  new Vsop87Coefficient(  727,        3.988,      1155.361 ),
  new Vsop87Coefficient(  655,        2.791,      1685.052 ),
  new Vsop87Coefficient(  654,        3.382,      1692.166 ),
  new Vsop87Coefficient(  621,        4.823,      956.289 ),
  new Vsop87Coefficient(  615,        2.276,      942.062 ),
  new Vsop87Coefficient(  562,        0.081,      543.918 ),
  new Vsop87Coefficient(  542,        0.284,      525.759 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R1JupiterCoefficients =
{ 
  new Vsop87Coefficient(  1271802,2.6493751,  529.6909651 ),
  new Vsop87Coefficient(  61662,  3.00076,    1059.38193 ),
  new Vsop87Coefficient(  53444,  3.89718,    522.57742 ),
  new Vsop87Coefficient(  41390,  0,          0 ),
  new Vsop87Coefficient(  31185,  4.88277,    536.80451 ),
  new Vsop87Coefficient(  11847,  2.41330,    419.48464 ),
  new Vsop87Coefficient(  9166,   4.7598,     7.1135 ),
  new Vsop87Coefficient(  3404,   3.3469,     1589.0729 ),
  new Vsop87Coefficient(  3203,   5.2108,     735.8765 ),
  new Vsop87Coefficient(  3176,   2.7930,     103.0928 ),
  new Vsop87Coefficient(  2806,   3.7422,     515.4639 ),
  new Vsop87Coefficient(  2677,   4.3305,     1052.2684 ),
  new Vsop87Coefficient(  2600,   3.6344,     206.1855 ),
  new Vsop87Coefficient(  2412,   1.4695,     426.5982 ),
  new Vsop87Coefficient(  2101,   3.9276,     639.8973 ),
  new Vsop87Coefficient(  1646,   4.4163,     1066.4955 ),
  new Vsop87Coefficient(  1641,   4.4163,     625.6702 ),
  new Vsop87Coefficient(  1050,   3.1611,     213.2991 ),
  new Vsop87Coefficient(  1025,   2.5543,     412.3711 ),
  new Vsop87Coefficient(  806,    2.678,      632.784 ),
  new Vsop87Coefficient(  741,    2.171,      1162.475 ),
  new Vsop87Coefficient(  677,    6.250,      838.969 ),
  new Vsop87Coefficient(  567,    4.577,      742.990 ),
  new Vsop87Coefficient(  485,    2.469,      949.176 ),
  new Vsop87Coefficient(  469,    4.710,      543.918 ),
  new Vsop87Coefficient(  445,    0.403,      323.505 ),
  new Vsop87Coefficient(  416,    5.368,      728.763 ),
  new Vsop87Coefficient(  402,    4.605,      309.278 ),
  new Vsop87Coefficient(  347,    4.681,      14.227 ),
  new Vsop87Coefficient(  338,    3.168,      956.289 ),
  new Vsop87Coefficient(  261,    5.343,      846.083 ),
  new Vsop87Coefficient(  247,    3.923,      942.062 ),
  new Vsop87Coefficient(  220,    4.842,      1368.660 ),
  new Vsop87Coefficient(  203,    5.600,      1155.361 ),
  new Vsop87Coefficient(  200,    4.439,      1045.155 ),
  new Vsop87Coefficient(  197,    3.706,      2118.764 ),
  new Vsop87Coefficient(  196,    3.759,      199.072 ),
  new Vsop87Coefficient(  184,    4.265,      95.979 ),
  new Vsop87Coefficient(  180,    4.402,      532.872 ),
  new Vsop87Coefficient(  170,    4.846,      526.510 ),
  new Vsop87Coefficient(  146,    6.130,      533.623 ),
  new Vsop87Coefficient(  133,    1.322,      110.206 ),
  new Vsop87Coefficient(  132,    4.512,      525.759 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R2JupiterCoefficients =
{ 
  new Vsop87Coefficient(  79645,  1.35866,  529.69097 ),
  new Vsop87Coefficient(  8252,   5.7777,   522.5774 ),
  new Vsop87Coefficient(  7030,   3.2748,   536.8045 ),
  new Vsop87Coefficient(  5314,   1.8384,   1059.3819 ),
  new Vsop87Coefficient(  1861,   2.9768,   7.1135 ),
  new Vsop87Coefficient(  964,    5.480,    515.464 ),
  new Vsop87Coefficient(  836,    4.199,    419.485 ),
  new Vsop87Coefficient(  498,    3.142,    0 ),
  new Vsop87Coefficient(  427,    2.228,    639.897 ),
  new Vsop87Coefficient(  406,    3.783,    1066.495 ),
  new Vsop87Coefficient(  377,    2.242,    1589.073 ),
  new Vsop87Coefficient(  363,    5.368,    206.186 ),
  new Vsop87Coefficient(  342,    6.099,    1052.268 ),
  new Vsop87Coefficient(  339,    6.127,    625.670 ),
  new Vsop87Coefficient(  333,    0.003,    426.598 ),
  new Vsop87Coefficient(  280,    4.262,    412.371 ),
  new Vsop87Coefficient(  257,    0.963,    632.784 ),
  new Vsop87Coefficient(  230,    0.705,    735.877 ),
  new Vsop87Coefficient(  201,    3.069,    543.918 ),
  new Vsop87Coefficient(  200,    4.429,    103.093 ),
  new Vsop87Coefficient(  139,    2.932,    14.227 ),
  new Vsop87Coefficient(  114,    0.787,    728.763 ),
  new Vsop87Coefficient(  95,     1.70,     838.97 ),
  new Vsop87Coefficient(  86,     5.14,     323.51 ),
  new Vsop87Coefficient(  83,     0.06,     309.28 ),
  new Vsop87Coefficient(  80,     2.98,     742.99 ),
  new Vsop87Coefficient(  75,     1.60,     956.29 ),
  new Vsop87Coefficient(  70,     1.51,     213.30 ),
  new Vsop87Coefficient(  67,     5.47,     199.07 ),
  new Vsop87Coefficient(  62,     6.10,     1045.15 ),
  new Vsop87Coefficient(  56,     0.96,     1162.47 ),
  new Vsop87Coefficient(  52,     5.58,     942.06 ),
  new Vsop87Coefficient(  50,     2.72,     532.87 ),
  new Vsop87Coefficient(  45,     5.52,     508.35 ),
  new Vsop87Coefficient(  44,     0.27,     526.51 ),
  new Vsop87Coefficient(  40,     5.95,     95.98 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R3JupiterCoefficients =
{ 
  new Vsop87Coefficient(  3519, 6.0580, 529.6910 ),
  new Vsop87Coefficient(  1073, 1.6732, 536.8045 ),
  new Vsop87Coefficient(  916,  1.413,  522.577 ),
  new Vsop87Coefficient(  342,  0.523,  1059.382 ),
  new Vsop87Coefficient(  255,  1.196,  7.114 ),
  new Vsop87Coefficient(  222,  0.952,  515.464 ),
  new Vsop87Coefficient(  90,   3.14,   0 ),
  new Vsop87Coefficient(  69,   2.27,   1066.50 ),
  new Vsop87Coefficient(  58,   1.41,   543.92 ),
  new Vsop87Coefficient(  58,   0.53,   639.90 ),
  new Vsop87Coefficient(  51,   5.98,   412.37 ),
  new Vsop87Coefficient(  47,   1.58,   625.67 ),
  new Vsop87Coefficient(  43,   6.12,   419.48 ),
  new Vsop87Coefficient(  37,   1.18,   14.23 ),
  new Vsop87Coefficient(  34,   1.67,   1052.27 ),
  new Vsop87Coefficient(  34,   0.85,   206.19 ),
  new Vsop87Coefficient(  31,   1.04,   1589.07 ),
  new Vsop87Coefficient(  30,   4.63,   426.60 ),
  new Vsop87Coefficient(  21,   2.50,   728.76 ),
  new Vsop87Coefficient(  15,   0.89,   199.07 ),
  new Vsop87Coefficient(  14,   0.96,   508.35 ),
  new Vsop87Coefficient(  13,   1.50,   1045.15 ),
  new Vsop87Coefficient(  12,   2.61,   735.88 ),
  new Vsop87Coefficient(  12,   3.56,   323.51 ),
  new Vsop87Coefficient(  11,   1.79,   309.28 ),
  new Vsop87Coefficient(  11,   6.28,   956.29 ),
  new Vsop87Coefficient(  10,   6.26,   103.09 ),
  new Vsop87Coefficient(  9,    3.45,   838.97 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R4JupiterCoefficients =
{ 
  new Vsop87Coefficient(  129,  0.084,  536.805 ),
  new Vsop87Coefficient(  113,  4.249,  529.691 ),
  new Vsop87Coefficient(  83,   3.30,   522.58 ),
  new Vsop87Coefficient(  38,   2.73,   515.46 ), 
  new Vsop87Coefficient(  27,   5.69,   7.11 ),
  new Vsop87Coefficient(  18,   5.40,   1059.38 ),
  new Vsop87Coefficient(  13,   6.02,   543.92 ),
  new Vsop87Coefficient(  9,    0.77,   1066.50 ),
  new Vsop87Coefficient(  8,    5.68,   14.23 ),
  new Vsop87Coefficient(  7,    1.43,   412.37 ),
  new Vsop87Coefficient(  6,    5.12,   639.90 ),
  new Vsop87Coefficient(  5,    3.34,   625.67 ),
  new Vsop87Coefficient(  3,    3.40,   1052.27 ),
  new Vsop87Coefficient(  3,    4.16,   728.76 ),
  new Vsop87Coefficient(  3,    2.90,   426.60 )
};

        /// <summary>
        /// Vsop87 Coefficients.
        /// </summary>
        public static readonly Vsop87Coefficient[] R5JupiterCoefficients =
{ 
  new Vsop87Coefficient(  11, 4.75, 536.80 ),
  new Vsop87Coefficient(  4,  5.92, 522.58 ),
  new Vsop87Coefficient(  2,  5.57, 515.46 ),
  new Vsop87Coefficient(  2,  4.30, 543.92 ),
  new Vsop87Coefficient(  2,  3.69, 7.11 ),
  new Vsop87Coefficient(  2,  4.13, 1059.38 ),
  new Vsop87Coefficient(  2,  5.49, 1066.50 )
};
        #endregion
    }
}
