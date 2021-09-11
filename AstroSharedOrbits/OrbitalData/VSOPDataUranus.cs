﻿// <copyright file="VsopDataUranus.cs" company="Traced-Ideas, Czech republic">
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
        #region Uranus

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L0UranusCoefficients =
{ 
  new Vsop87Coefficient( 548129294,	0,        	0  ), 
  new Vsop87Coefficient( 9260408,	  0.8910642,	74.7815986  ), 
  new Vsop87Coefficient( 1504248,    3.6271926,	1.4844727  ), 
  new Vsop87Coefficient( 365982,   	1.899622,	  73.297126  ), 
  new Vsop87Coefficient( 272328,   	3.358237,	  149.563197  ), 
  new Vsop87Coefficient( 70328,  	  5.39254,	  63.73590  ), 
  new Vsop87Coefficient( 68893, 	    6.09292,	  76.26607  ), 
  new Vsop87Coefficient( 61999, 	    2.26952,	  2.96895  ), 
  new Vsop87Coefficient( 61951, 	    2.85099,	  11.04570  ), 
  new Vsop87Coefficient( 26469, 	    3.14152,	  71.81265  ), 
  new Vsop87Coefficient( 25711, 	    6.11380,	  454.90937  ), 
  new Vsop87Coefficient( 21079,	    4.36059,	  148.07872  ), 
  new Vsop87Coefficient( 17819, 	    1.74437,	  36.64856  ), 
  new Vsop87Coefficient( 14613,	    4.73732,	  3.93215  ), 
  new Vsop87Coefficient( 11163, 	    5.82682,	  224.34480  ), 
  new Vsop87Coefficient( 10998,	    0.48865,	  138.51750  ), 
  new Vsop87Coefficient( 9527,	      2.9552,	    35.1641  ), 
  new Vsop87Coefficient( 7546,	      5.2363,	    109.9457  ), 
  new Vsop87Coefficient( 4220,	      3.2333,	    70.8494  ), 
  new Vsop87Coefficient( 4052,	      2.2775,	    151.0477  ), 
  new Vsop87Coefficient( 3490, 	    5.4831,	    146.5943  ), 
  new Vsop87Coefficient( 3355,	      1.0655,	    4.4534  ), 
  new Vsop87Coefficient( 3144,  	    4.7520,	    77.7505  ), 
  new Vsop87Coefficient( 2927,	      4.6290,	    9.5612  ), 
  new Vsop87Coefficient( 2922,	      5.3524,	    85.8273  ), 
  new Vsop87Coefficient( 2273,  	    4.3660,	    70.3282  ), 
  new Vsop87Coefficient( 2149,	      0.6075,	    38.1330  ), 
  new Vsop87Coefficient( 2051,  	    1.5177,	    0.1119  ), 
  new Vsop87Coefficient( 1992,  	    4.9244,	    277.0350  ), 
  new Vsop87Coefficient( 1667,	      3.6274,	    380.1278  ), 
  new Vsop87Coefficient( 1533,  	    2.5859,	    52.6902  ), 
  new Vsop87Coefficient( 1376,	      2.0428,	    65.2204  ), 
  new Vsop87Coefficient( 1372,	      4.1964,	    111.4302  ),  
  new Vsop87Coefficient( 1284,  	    3.1135,	    202.2534  ), 
  new Vsop87Coefficient( 1282,	      0.5427,	    222.8603  ), 
  new Vsop87Coefficient( 1244,	      0.9161,	    2.4477  ), 
  new Vsop87Coefficient( 1221,	      0.1990,	    108.4612  ), 
  new Vsop87Coefficient( 1151,	      4.1790,	    33.6796  ), 
  new Vsop87Coefficient( 1150,	      0.9334,	    3.1814  ), 
  new Vsop87Coefficient( 1090,	      1.7750,	    12.5302  ), 
  new Vsop87Coefficient( 1072,	      0.2356,	    62.2514  ), 
  new Vsop87Coefficient( 946,	      1.192,	    127.472  ), 
  new Vsop87Coefficient( 708,	      5.183,	    213.299  ), 
  new Vsop87Coefficient( 653,	      0.966,	    78.714  ), 
  new Vsop87Coefficient( 628,	      0.182,	    984.600  ), 
  new Vsop87Coefficient( 607,	      5.432,	    529.691  ), 
  new Vsop87Coefficient( 559,	      3.358,	    0.521  ), 
  new Vsop87Coefficient( 524,	      2.013,	    299.126  ), 
  new Vsop87Coefficient( 483,	      2.106,	    0.963  ), 
  new Vsop87Coefficient( 471,	      1.407,	    184.727  ), 
  new Vsop87Coefficient( 467,	      0.415,	    145.110  ), 
  new Vsop87Coefficient( 434,	      5.521,	    183.243  ), 
  new Vsop87Coefficient( 405,	      5.987,	    8.077  ), 
  new Vsop87Coefficient( 399,	      0.338,	    415.552  ), 
  new Vsop87Coefficient( 396,	      5.870,	    351.817  ), 
  new Vsop87Coefficient( 379,	      2.350,	    56.622  ), 
  new Vsop87Coefficient( 310,	      5.833,	    145.631  ), 
  new Vsop87Coefficient( 300,	      5.644,	    22.091  ), 
  new Vsop87Coefficient( 294,	      5.839,	    39.618  ), 
  new Vsop87Coefficient( 252,	      1.637,	    221.376  ), 
  new Vsop87Coefficient( 249,	      4.746,	    225.829  ), 
  new Vsop87Coefficient( 239,	      2.350,	    137.033  ), 
  new Vsop87Coefficient( 224,        0.516,	    84.343  ), 
  new Vsop87Coefficient( 223,	      2.843,	    0.261  ), 
  new Vsop87Coefficient( 220,	      1.922,	    67.668  ), 
  new Vsop87Coefficient( 217,	      6.142,	    5.938  ), 
  new Vsop87Coefficient( 216,	      4.778,	    340.771  ), 
  new Vsop87Coefficient( 208,        5.580,	    68.844  ), 
  new Vsop87Coefficient( 202,	      1.297,	    0.048  ),  
  new Vsop87Coefficient( 199,	      0.956,	    152.532  ), 
  new Vsop87Coefficient( 194,	      1.888,	    456.394  ), 
  new Vsop87Coefficient( 193,	      0.916,	    453.425 ) ,
  new Vsop87Coefficient( 187,        1.319,	    0.160  ), 
  new Vsop87Coefficient( 182,	      3.536,	    79.235  ),  
  new Vsop87Coefficient( 173,	      1.539,	    160.609  ), 
  new Vsop87Coefficient( 172,	      5.680,	    219.891  ), 
  new Vsop87Coefficient( 170,	      3.677,    	5.417  ), 
  new Vsop87Coefficient( 169,	      5.879,	    18.159  ), 
  new Vsop87Coefficient( 165,	      1.424,	    106.977  ), 
  new Vsop87Coefficient( 163,	      3.050,	    112.915  ), 
  new Vsop87Coefficient( 158,	      0.738,	    54.175  ), 
  new Vsop87Coefficient( 147,	      1.263,	    59.804  ), 
  new Vsop87Coefficient( 143,	      1.300,	    35.425  ), 
  new Vsop87Coefficient( 139,	      5.386,	    32.195  ), 
  new Vsop87Coefficient( 139,	      4.260,	    909.819  ), 
  new Vsop87Coefficient( 124,        1.374,	    7.114  ), 
  new Vsop87Coefficient( 110,	      2.027,	    554.070  ), 
  new Vsop87Coefficient( 109,	      5.706,	    77.963  ), 
  new Vsop87Coefficient( 104,	      5.028,	    0.751  ), 
  new Vsop87Coefficient( 104,	      1.458,	    24.379  ), 
  new Vsop87Coefficient( 103,        0.681,	    14.978 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L1UranusCoefficients =
{ 
  new Vsop87Coefficient( 7502543122.0,	0,	      0  ), 
  new Vsop87Coefficient( 154458,   	  5.242017,	74.781599  ), 
  new Vsop87Coefficient( 24456,	      1.71256,	1.48447  ), 
  new Vsop87Coefficient( 9258,	        0.4284,	  11.0457  ), 
  new Vsop87Coefficient( 8266,	        1.5022,	  63.7359  ), 
  new Vsop87Coefficient( 7842,	        1.3198,	  149.5632  ), 
  new Vsop87Coefficient( 3899,	        0.4648,	  3.9322  ), 
  new Vsop87Coefficient( 2284,	        4.1737,	  76.2661  ), 
  new Vsop87Coefficient( 1927,	        0.5301,	  2.9689  ), 
  new Vsop87Coefficient( 1233,	        1.5863,	  70.8494  ), 
  new Vsop87Coefficient( 791,	        5.436,	  3.181  ),  
  new Vsop87Coefficient( 767,	        1.996,	  73.297   ), 
  new Vsop87Coefficient( 482,	        2.984,	  85.827   ), 
  new Vsop87Coefficient( 450,	        4.138,	  138.517   ), 
  new Vsop87Coefficient( 446,	        3.723,	  224.345   ), 
  new Vsop87Coefficient( 427,	        4.731,	  71.813   ), 
  new Vsop87Coefficient( 354,	        2.583,	  148.079   ), 
  new Vsop87Coefficient( 348,	        2.454,	  9.561   ), 
  new Vsop87Coefficient( 317,	        5.579,	  52.690   ), 
  new Vsop87Coefficient( 206,	        2.363,	  2.448   ), 
  new Vsop87Coefficient( 189,	        4.202,	  56.622   ), 
  new Vsop87Coefficient( 184,	        0.284,	  151.048   ), 
  new Vsop87Coefficient( 180,	        5.684,	  12.530   ), 
  new Vsop87Coefficient( 171,	        3.001,	  78.714   ), 
  new Vsop87Coefficient( 158,	        2.909,	  0.963   ), 
  new Vsop87Coefficient( 155,	        5.591,	  4.453   ), 
  new Vsop87Coefficient( 154,	        4.652,	  35.164   ), 
  new Vsop87Coefficient( 152,	        2.942,	  77.751   ), 
  new Vsop87Coefficient( 143,	        2.590,	  62.251   ), 
  new Vsop87Coefficient( 121,	        4.148,	  127.472   ), 
  new Vsop87Coefficient( 116,	        3.732,	  65.220   ), 
  new Vsop87Coefficient( 102,	        4.188,	  145.631   ), 
  new Vsop87Coefficient( 102,	        6.034,	  0.112   ), 
  new Vsop87Coefficient( 88,	          3.99,	    18.16   ), 
  new Vsop87Coefficient( 88,	          6.16,	    202.25   ), 
  new Vsop87Coefficient( 81,	          2.64,	    22.09   ), 
  new Vsop87Coefficient( 72,	          6.05,	    70.33   ), 
  new Vsop87Coefficient( 69,	          4.05,	    77.96   ), 
  new Vsop87Coefficient( 59,	          3.70,	    67.67   ), 
  new Vsop87Coefficient( 47,	          3.54,	    351.82   ), 
  new Vsop87Coefficient( 44,	          5.91,	    7.11   ), 
  new Vsop87Coefficient( 43,	          5.72,	    5.42   ), 
  new Vsop87Coefficient( 39,	          4.92,	    222.86   ), 
  new Vsop87Coefficient( 36,	          5.90,	    33.68   ), 
  new Vsop87Coefficient( 36,	          3.29,	    8.08   ), 
  new Vsop87Coefficient( 36,	          3.33,	    71.60   ), 
  new Vsop87Coefficient( 35,	          5.08,	    38.13   ), 
  new Vsop87Coefficient( 31,	          5.62,	    984.60   ), 
  new Vsop87Coefficient( 31,	          5.50,	    59.80   ), 
  new Vsop87Coefficient( 31,	          5.46,	    160.61   ), 
  new Vsop87Coefficient( 30,	          1.66,	    447.80   ), 
  new Vsop87Coefficient( 29,	          1.15,	    462.02   ), 
  new Vsop87Coefficient( 29,	          4.52,	    84.34   ), 
  new Vsop87Coefficient( 27,	          5.54,	    131.40   ), 
  new Vsop87Coefficient( 27,	          6.15,	    299.13   ), 
  new Vsop87Coefficient( 26,	          4.99,	    137.03   ), 
  new Vsop87Coefficient( 25,	          5.74,	    380.13  )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L2UranusCoefficients =
{ 
  new Vsop87Coefficient( 53033,  0,      0  ), 
  new Vsop87Coefficient( 2358,   2.2601, 74.7816  ), 
  new Vsop87Coefficient( 769,    4.526,  11.046  ), 
  new Vsop87Coefficient( 552,    3.258,  63.736  ), 
  new Vsop87Coefficient( 542,    2.276,  3.932  ), 
  new Vsop87Coefficient( 529,    4.923,  1.484  ), 
  new Vsop87Coefficient( 258,    3.691,  3.181  ), 
  new Vsop87Coefficient( 239,    5.858,  149.563  ), 
  new Vsop87Coefficient( 182,    6.218,  70.849  ), 
  new Vsop87Coefficient( 54,     1.44,   76.27  ), 
  new Vsop87Coefficient( 49,     6.03,   56.62  ), 
  new Vsop87Coefficient( 45,     3.91,   2.45  ), 
  new Vsop87Coefficient( 45,     0.81,   85.83  ), 
  new Vsop87Coefficient( 38,     1.78,   52.69  ), 
  new Vsop87Coefficient( 37,     4.46,   2.97  ), 
  new Vsop87Coefficient( 33,     0.86,   9.56  ), 
  new Vsop87Coefficient( 29,     5.10,   73.30  ), 
  new Vsop87Coefficient( 24,     2.11,   18.16  ), 
  new Vsop87Coefficient( 22,     5.99,   138.52  ), 
  new Vsop87Coefficient( 22,     4.82,   78.71  ), 
  new Vsop87Coefficient( 21,     2.40,   77.96  ), 
  new Vsop87Coefficient( 21,     2.17,   224.34  ), 
  new Vsop87Coefficient( 17,     2.54,   145.63  ), 
  new Vsop87Coefficient( 17,     3.47,   12.53  ), 
  new Vsop87Coefficient( 12,     0.02,   22.09  ), 
  new Vsop87Coefficient( 11,     0.08,   127.47  ), 
  new Vsop87Coefficient( 10,     5.16,   71.60  ), 
  new Vsop87Coefficient( 10,     4.46,   62.25  ), 
  new Vsop87Coefficient( 9,      4.26,   7.11  ), 
  new Vsop87Coefficient( 8,      5.50,   67.67  ), 
  new Vsop87Coefficient( 7,      1.25,   5.42  ), 
  new Vsop87Coefficient( 6,      3.36,   447.80  ), 
  new Vsop87Coefficient( 6,      5.45,   65.22  ), 
  new Vsop87Coefficient( 6,      4.52,   151.05  ), 
  new Vsop87Coefficient( 6,      5.73,   462.02 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L3UranusCoefficients =
{ 
  new Vsop87Coefficient( 121,  0.024,  74.782  ), 
  new Vsop87Coefficient( 68,   4.12,   3.93  ), 
  new Vsop87Coefficient( 53,   2.39,   11.05  ), 
  new Vsop87Coefficient( 46,   0,      0  ), 
  new Vsop87Coefficient( 45,   2.04,   3.18  ), 
  new Vsop87Coefficient( 44,   2.96,   1.48  ), 
  new Vsop87Coefficient( 25,   4.89,   63.74  ), 
  new Vsop87Coefficient( 21,   4.55,   70.85  ), 
  new Vsop87Coefficient( 20,   2.31,   149.56  ), 
  new Vsop87Coefficient( 9,    1.58,   56.62  ), 
  new Vsop87Coefficient( 4,    0.23,   18.16  ), 
  new Vsop87Coefficient( 4,    5.39,   76.27  ), 
  new Vsop87Coefficient( 4,    0.95,   77.96  ), 
  new Vsop87Coefficient( 3,    4.98,   85.83  ), 
  new Vsop87Coefficient( 3,    4.13,   52.69  ), 
  new Vsop87Coefficient( 3,    0.37,   78.71  ), 
  new Vsop87Coefficient( 2,    0.86,   145.63  ), 
  new Vsop87Coefficient( 2,    5.66,   9.56 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L4UranusCoefficients =
{ 
  new Vsop87Coefficient( 114,  3.142,  0  ), 
  new Vsop87Coefficient( 6,    4.58,   74.78  ), 
  new Vsop87Coefficient( 3,    0.35,   11.05  ), 
  new Vsop87Coefficient( 1,    3.42,   56.62 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B0UranusCoefficients =
{ 
  new Vsop87Coefficient( 1346278,  2.6187781,  74.7815986  ), 
  new Vsop87Coefficient( 62341,    5.08111,    149.56320  ), 
  new Vsop87Coefficient( 61601,    3.14159,    0  ), 
  new Vsop87Coefficient( 9964,     1.6160,     76.2661  ), 
  new Vsop87Coefficient( 9926,     0.5763,     73.2971  ), 
  new Vsop87Coefficient( 3259,     1.2612,     224.3448  ), 
  new Vsop87Coefficient( 2972,     2.2437,     1.4845  ), 
  new Vsop87Coefficient( 2010,     6.0555,     148.0787  ), 
  new Vsop87Coefficient( 1522,     0.2796,     63.7359  ), 
  new Vsop87Coefficient( 924,      4.038,      151.048  ), 
  new Vsop87Coefficient( 761,      6.140,      71.813  ), 
  new Vsop87Coefficient( 522,      3.321,      138.517  ), 
  new Vsop87Coefficient( 463,      0.743,      85.827  ), 
  new Vsop87Coefficient( 437,      3.381,      529.691  ), 
  new Vsop87Coefficient( 435,      0.341,      77.751  ), 
  new Vsop87Coefficient( 431,      3.554,      213.299  ), 
  new Vsop87Coefficient( 420,      5.213,      11.046  ), 
  new Vsop87Coefficient( 245,      0.788,      2.969  ), 
  new Vsop87Coefficient( 233,      2.257,      222.860  ), 
  new Vsop87Coefficient( 216,      1.591,      38.133  ), 
  new Vsop87Coefficient( 180,      3.725,      299.126  ), 
  new Vsop87Coefficient( 175,      1.236,      146.594  ), 
  new Vsop87Coefficient( 174,      1.937,      380.128  ), 
  new Vsop87Coefficient( 160,      5.336,      111.430  ), 
  new Vsop87Coefficient( 144,      5.962,      35.164  ), 
  new Vsop87Coefficient( 116,      5.739,      70.849  ), 
  new Vsop87Coefficient( 106,      0.941,      70.328  ), 
  new Vsop87Coefficient( 102,      2.619,      78.714 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B1UranusCoefficients =
{ 
  new Vsop87Coefficient( 206366, 4.123943, 74.781599  ), 
  new Vsop87Coefficient( 8563,   0.3382,   149.5632  ), 
  new Vsop87Coefficient( 1726,   2.1219,   73.2971  ), 
  new Vsop87Coefficient( 1374,   0,        0  ), 
  new Vsop87Coefficient( 1369,   3.0686,   76.2661  ), 
  new Vsop87Coefficient( 451,    3.777,    1.484  ), 
  new Vsop87Coefficient( 400,    2.848,    224.345  ), 
  new Vsop87Coefficient( 307,    1.255,    148.079  ), 
  new Vsop87Coefficient( 154,    3.786,    63.736  ), 
  new Vsop87Coefficient( 112,    5.573,    151.048  ), 
  new Vsop87Coefficient( 111,    5.329,    138.517  ), 
  new Vsop87Coefficient( 83,     3.59,     71.81  ), 
  new Vsop87Coefficient( 56,     3.40,     85.83  ), 
  new Vsop87Coefficient( 54,     1.70,     77.75  ), 
  new Vsop87Coefficient( 42,     1.21,     11.05  ), 
  new Vsop87Coefficient( 41,     4.45,     78.71  ), 
  new Vsop87Coefficient( 32,     3.77,     222.86  ), 
  new Vsop87Coefficient( 30,     2.56,     2.97  ), 
  new Vsop87Coefficient( 27,     5.34,     213.30  ), 
  new Vsop87Coefficient( 26,     0.42,     380.13 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B2UranusCoefficients =
{ 
  new Vsop87Coefficient( 9212, 5.8004, 74.7816  ), 
  new Vsop87Coefficient( 557,  0,      0 ),
  new Vsop87Coefficient( 286,  2.177,  149.563  ), 
  new Vsop87Coefficient( 95,   3.84,   73.30  ), 
  new Vsop87Coefficient( 45,   4.88,   76.27  ), 
  new Vsop87Coefficient( 20,   5.46,   1.48  ), 
  new Vsop87Coefficient( 15,   0.88,   138.52  ), 
  new Vsop87Coefficient( 14,   2.85,   148.08  ), 
  new Vsop87Coefficient( 14,   5.07,   63.74  ), 
  new Vsop87Coefficient( 10,   5.00,   224.34  ), 
  new Vsop87Coefficient( 8,    6.27,   78.71 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B3UranusCoefficients =
{ 
  new Vsop87Coefficient( 268,  1.251,  74.782  ), 
  new Vsop87Coefficient( 11,   3.14,   0  ), 
  new Vsop87Coefficient( 6,    4.01,   149.56  ), 
  new Vsop87Coefficient( 3,    5.78,   73.30 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B4UranusCoefficients =
{ 
  new Vsop87Coefficient( 6,  2.85, 74.78 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R0UranusCoefficients =
{ 
  new Vsop87Coefficient( 1921264848,   0,          0  ), 
  new Vsop87Coefficient( 88784984,     5.60377527, 74.78159857  ), 
  new Vsop87Coefficient( 3440836,      0.3283610,  73.2971259  ), 
  new Vsop87Coefficient( 2055653,      1.7829517,  149.5631971  ), 
  new Vsop87Coefficient( 649322,       4.522473,   76.266071  ), 
  new Vsop87Coefficient( 602248,       3.860038,   63.735898  ), 
  new Vsop87Coefficient( 496404,       1.401399,   454.909367  ), 
  new Vsop87Coefficient( 338526,       1.580027,   138.517497  ), 
  new Vsop87Coefficient( 243508,       1.570866,   71.812653  ), 
  new Vsop87Coefficient( 190522,       1.998094,   1.484473  ), 
  new Vsop87Coefficient( 161858,       2.791379,   148.078724  ), 
  new Vsop87Coefficient( 143706,       1.383686,   11.045700  ), 
  new Vsop87Coefficient( 93192,        0.17437,    36.64856  ), 
  new Vsop87Coefficient( 89806,        3.66105,    109.94569  ), 
  new Vsop87Coefficient( 71424,        4.24509,    224.34480  ), 
  new Vsop87Coefficient( 46677,        1.39977,    35.16409  ), 
  new Vsop87Coefficient( 39026,        3.36235,    277.03499  ), 
  new Vsop87Coefficient( 39010,        1.66971,    70.84945  ), 
  new Vsop87Coefficient( 36755,        3.88649,    146.59425  ), 
  new Vsop87Coefficient( 30349,        0.70100,    151.04767  ), 
  new Vsop87Coefficient( 29156,        3.18056,    77.75054  ), 
  new Vsop87Coefficient( 25786,        3.78538,    85.82730  ), 
  new Vsop87Coefficient( 25620,        5.25656,    380.12777  ), 
  new Vsop87Coefficient( 22637,        0.72519,    529.69097  ), 
  new Vsop87Coefficient( 20473,        2.79640,    70.32818  ), 
  new Vsop87Coefficient( 20472,        1.55589,    202.25340  ), 
  new Vsop87Coefficient( 17901,        0.55455,    2.96895  ), 
  new Vsop87Coefficient( 15503,        5.35405,    38.13304  ), 
  new Vsop87Coefficient( 14702,        4.90434,    108.46122  ), 
  new Vsop87Coefficient( 12897,        2.62154,    111.43016  ), 
  new Vsop87Coefficient( 12328,        5.96039,    127.47180  ), 
  new Vsop87Coefficient( 11959,        1.75044,    984.60033  ), 
  new Vsop87Coefficient( 11853,        0.99343,    52.69020  ), 
  new Vsop87Coefficient( 11696,        3.29826,    3.93215  ), 
  new Vsop87Coefficient( 11495,        0.43774,    65.22037  ), 
  new Vsop87Coefficient( 10793,        1.42105,    213.29910  ), 
  new Vsop87Coefficient( 9111,         4.9964,     62.2514  ), 
  new Vsop87Coefficient( 8421,         5.2535,     222.8603  ), 
  new Vsop87Coefficient( 8402,         5.0388,     415.5525  ), 
  new Vsop87Coefficient( 7449,         0.7949,     351.8166  ), 
  new Vsop87Coefficient( 7329,         3.9728,     183.2428  ), 
  new Vsop87Coefficient( 6046,         5.6796,     78.7138  ), 
  new Vsop87Coefficient( 5524,         3.1150,     9.5612  ), 
  new Vsop87Coefficient( 5445,         5.1058,     145.1098  ), 
  new Vsop87Coefficient( 5238,         2.6296,     33.6796  ), 
  new Vsop87Coefficient( 4079,         3.2206,     340.7709  ), 
  new Vsop87Coefficient( 3919,         4.2502,     39.6175  ), 
  new Vsop87Coefficient( 3802,         6.1099,     184.7273  ), 
  new Vsop87Coefficient( 3781,         3.4584,     456.3938  ), 
  new Vsop87Coefficient( 3687,         2.4872,     453.4249  ), 
  new Vsop87Coefficient( 3102,         4.1403,     219.8914  ), 
  new Vsop87Coefficient( 2963,         0.8298,     56.6224  ), 
  new Vsop87Coefficient( 2942,         0.4239,     299.1264  ), 
  new Vsop87Coefficient( 2940,         2.1464,     137.0330  ), 
  new Vsop87Coefficient( 2938,         3.6766,     140.0020  ), 
  new Vsop87Coefficient( 2865,         0.3100,     12.5302  ), 
  new Vsop87Coefficient( 2538,         4.8546,     131.4039  ), 
  new Vsop87Coefficient( 2364,         0.4425,     554.0700  ), 
  new Vsop87Coefficient( 2183,         2.9404,     305.3462 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R1UranusCoefficients =
{ 
  new Vsop87Coefficient( 1479896,  3.6720571,  74.7815986  ), 
  new Vsop87Coefficient( 71212,    6.22601,    63.73590  ), 
  new Vsop87Coefficient( 68627,    6.13411,    149.56320  ), 
  new Vsop87Coefficient( 24060,    3.14159,    0  ), 
  new Vsop87Coefficient( 21468,    2.60177,    76.26607  ), 
  new Vsop87Coefficient( 20857,    5.24625,    11.04570  ), 
  new Vsop87Coefficient( 11405,    0.01848,    70.84945  ), 
  new Vsop87Coefficient( 7497,     0.4236,     73.2971  ), 
  new Vsop87Coefficient( 4244,     1.4169,     85.8273  ), 
  new Vsop87Coefficient( 3927,     3.1551,     71.8127  ), 
  new Vsop87Coefficient( 3578,     2.3116,     224.3448  ), 
  new Vsop87Coefficient( 3506,     2.5835,     138.5175  ), 
  new Vsop87Coefficient( 3229,     5.2550,     3.9322  ), 
  new Vsop87Coefficient( 3060,     0.1532,     1.4845  ), 
  new Vsop87Coefficient( 2564,     0.9808,     148.0787  ), 
  new Vsop87Coefficient( 2429,     3.9944,     52.6902  ), 
  new Vsop87Coefficient( 1645,     2.6535,     127.4718  ), 
  new Vsop87Coefficient( 1584,     1.4305,     78.7138  ), 
  new Vsop87Coefficient( 1508,     5.0600,     151.0477  ), 
  new Vsop87Coefficient( 1490,     2.6756,     56.6224  ), 
  new Vsop87Coefficient( 1413,     4.5746,     202.2534  ), 
  new Vsop87Coefficient( 1403,     1.3699,     77.7505  ), 
  new Vsop87Coefficient( 1228,     1.0470,     62.2514  ), 
  new Vsop87Coefficient( 1033,     0.2646,     131.4039  ), 
  new Vsop87Coefficient( 992,      2.172,      65.220  ), 
  new Vsop87Coefficient( 862,      5.055,      351.817  ), 
  new Vsop87Coefficient( 744,      3.076,      35.164  ), 
  new Vsop87Coefficient( 687,      2.499,      77.963  ), 
  new Vsop87Coefficient( 647,      4.473,      70.328  ), 
  new Vsop87Coefficient( 624,      0.863,      9.561  ), 
  new Vsop87Coefficient( 604,      0.907,      984.600  ), 
  new Vsop87Coefficient( 575,      3.231,      447.796  ), 
  new Vsop87Coefficient( 562,      2.718,      462.023  ), 
  new Vsop87Coefficient( 530,      5.917,      213.299  ), 
  new Vsop87Coefficient( 528,      5.151,      2.969 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R2UranusCoefficients =
{ 
  new Vsop87Coefficient( 22440,  0.69953,  74.78160  ), 
  new Vsop87Coefficient( 4727,   1.6990,   63.7359  ), 
  new Vsop87Coefficient( 1682,   4.6483,   70.8494  ), 
  new Vsop87Coefficient( 1650,   3.0966,   11.0457  ), 
  new Vsop87Coefficient( 1434,   3.5212,   149.5632  ), 
  new Vsop87Coefficient( 770,    0,        0  ), 
  new Vsop87Coefficient( 500,    6.172,    76.266  ), 
  new Vsop87Coefficient( 461,    0.767,    3.932  ), 
  new Vsop87Coefficient( 390,    4.496,    56.622  ), 
  new Vsop87Coefficient( 390,    5.527,    85.827  ), 
  new Vsop87Coefficient( 292,    0.204,    52.690  ), 
  new Vsop87Coefficient( 287,    3.534,    73.297  ), 
  new Vsop87Coefficient( 273,    3.847,    138.517  ), 
  new Vsop87Coefficient( 220,    1.964,    131.404  ), 
  new Vsop87Coefficient( 216,    0.848,    77.963  ), 
  new Vsop87Coefficient( 205,    3.248,    78.714  ), 
  new Vsop87Coefficient( 149,    4.898,    127.472  ), 
  new Vsop87Coefficient( 129,    2.081,    3.181 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R3UranusCoefficients =
{ 
  new Vsop87Coefficient( 1164,   4.7345, 74.7816  ), 
  new Vsop87Coefficient( 212,    3.343,  63.736  ), 
  new Vsop87Coefficient( 196,    2.980,  70.849  ), 
  new Vsop87Coefficient( 105,    0.958,  11.046  ), 
  new Vsop87Coefficient( 73,     1.00,   149.56  ), 
  new Vsop87Coefficient( 72,     0.03,   56.62  ), 
  new Vsop87Coefficient( 55,     2.59,   3.93  ), 
  new Vsop87Coefficient( 36,     5.65,   77.96  ), 
  new Vsop87Coefficient( 34,     3.82,   76.27  ), 
  new Vsop87Coefficient( 32,     3.60,   131.40 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R4UranusCoefficients =
{ 
  new Vsop87Coefficient( 53, 3.01, 74.78  ), 
  new Vsop87Coefficient( 10, 1.91, 56.62 )
};       
        #endregion
    }
}
