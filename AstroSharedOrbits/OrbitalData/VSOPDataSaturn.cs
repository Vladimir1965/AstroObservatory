// <copyright file="VsopDataSaturn.cs" company="Traced-Ideas, Czech republic">
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
        #region Saturn

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L0SaturnCoefficients =
{ 
  new Vsop87Coefficient( 87401354,	  0,	        0 ), 
  new Vsop87Coefficient( 11107660,	  3.96205090,	213.29909544 ), 
  new Vsop87Coefficient( 1414151,	  4.5858152,	7.1135470 ), 
  new Vsop87Coefficient( 398379,	    0.521120,	  206.185548 ), 
  new Vsop87Coefficient( 350769,	    3.303299,	  426.598191 ), 
  new Vsop87Coefficient( 206816,	    0.246584,	  103.092774 ), 
  new Vsop87Coefficient( 79271,	    3.84007,	  220.41264 ), 
  new Vsop87Coefficient( 23990,	    4.66977,	  110.20632 ), 
  new Vsop87Coefficient( 16574,	    0.43719,	  419.48464 ), 
  new Vsop87Coefficient( 15820,	    0.93809,	  632.78374 ), 
  new Vsop87Coefficient( 15054,	    2.71670,	  639.89729 ), 
  new Vsop87Coefficient( 14907,	    5.76903,	  316.39187 ), 
  new Vsop87Coefficient( 14610,	    1.56519,	  3.93215 ), 
  new Vsop87Coefficient( 13160,	    4.44891,	  14.22709 ), 
  new Vsop87Coefficient( 13005,	    5.98119,	  11.04570 ), 
  new Vsop87Coefficient( 10725,	    3.12940,	  202.25340 ), 
  new Vsop87Coefficient( 6126,	      1.7633,	    277.0350 ), 
  new Vsop87Coefficient( 5863,	      0.2366,	    529.6910 ), 
  new Vsop87Coefficient( 5228,	      4.2078,	    3.1814 ), 
  new Vsop87Coefficient( 5020,	      3.1779,	    433.7117 ), 
  new Vsop87Coefficient( 4593,	      0.6198,	    199.0720 ), 
  new Vsop87Coefficient( 4006,	      2.2448,	    63.7359 ), 
  new Vsop87Coefficient( 3874,	      3.2228,	    138.5175 ), 
  new Vsop87Coefficient( 3269,	      0.7749,	    949.1756 ), 
  new Vsop87Coefficient( 2954,	      0.9828,	    95.9792 ), 
  new Vsop87Coefficient( 2461,	      2.0316,	    735.8765 ), 
  new Vsop87Coefficient( 1758,	      3.2658,	    522.5774 ), 
  new Vsop87Coefficient( 1640,	      5.5050,	    846.0828 ), 
  new Vsop87Coefficient( 1581,	      4.3727,	    309.2783 ), 
  new Vsop87Coefficient( 1391,	      4.0233,	    323.5054 ), 
  new Vsop87Coefficient( 1124,	      2.8373,	    415.5525 ), 
  new Vsop87Coefficient( 1087,	      4.1834,	    2.4477 ), 
  new Vsop87Coefficient( 1017,	      3.7170,	    227.5262 ), 
  new Vsop87Coefficient( 957,	      0.507,	    1265.567 ), 
  new Vsop87Coefficient( 853,	      3.421,	    175.166 ), 
  new Vsop87Coefficient( 849,	      3.191,	    209.367 ), 
  new Vsop87Coefficient( 789,	      5.007,	    0.963 ), 
  new Vsop87Coefficient( 749,	      2.144,	    853.196 ), 
  new Vsop87Coefficient( 744,	      5.253,	    224.345 ), 
  new Vsop87Coefficient( 687,	      1.747,	    1052.268 ), 
  new Vsop87Coefficient( 654,	      1.599,	    0.048 ), 
  new Vsop87Coefficient( 634,	      2.299,	    412.371 ), 
  new Vsop87Coefficient( 625,	      0.970,	    210.118 ), 
  new Vsop87Coefficient( 580,	      3.093,	    74.782 ), 
  new Vsop87Coefficient( 546,	      2.127,	    350.332 ), 
  new Vsop87Coefficient( 543,	      1.518,	    9.561 ), 
  new Vsop87Coefficient( 530,	      4.449,	    117.320 ), 
  new Vsop87Coefficient( 478,	      2.965,	    137.033 ), 
  new Vsop87Coefficient( 474,	      5.475,	    742.990 ), 
  new Vsop87Coefficient( 452,	      1.044,	    490.334 ), 
  new Vsop87Coefficient( 449,	      1.290,	    127.472 ), 
  new Vsop87Coefficient( 372,	      2.278,	    217.231 ), 
  new Vsop87Coefficient( 355,	      3.013,	    838.969 ), 
  new Vsop87Coefficient( 347,	      1.539,	    340.771 ), 
  new Vsop87Coefficient( 343,	      0.246,	    0.521 ), 
  new Vsop87Coefficient( 330,	      0.247,	    1581.959 ), 
  new Vsop87Coefficient( 322,	      0.961,	    203.738 ), 
  new Vsop87Coefficient( 322,	      2.572,	    647.011 ), 
  new Vsop87Coefficient( 309,	      3.495,	    216.480 ), 
  new Vsop87Coefficient( 287,	      2.370,	    351.817 ), 
  new Vsop87Coefficient( 278,	      0.400,	    211.815 ), 
  new Vsop87Coefficient( 249,	      1.470,	    1368.660 ), 
  new Vsop87Coefficient( 227,	      4.910,	    12.530 ), 
  new Vsop87Coefficient( 220,	      4.204,	    200.769 ), 
  new Vsop87Coefficient( 209,	      1.345,	    625.670 ), 
  new Vsop87Coefficient( 208,	      0.483,	    1162.475 ), 
  new Vsop87Coefficient( 208,	      1.283,	    39.357 ), 
  new Vsop87Coefficient( 204,	      6.011,	    265.989 ), 
  new Vsop87Coefficient( 185,	      3.503,	    149.563 ), 
  new Vsop87Coefficient( 184,	      0.973,	    4.193 ), 
  new Vsop87Coefficient( 182,	      5.491,	    2.921 ), 
  new Vsop87Coefficient( 174,	      1.863,	    0.751 ), 
  new Vsop87Coefficient( 165,	      0.440,	    5.417 ), 
  new Vsop87Coefficient( 149,	      5.736,	    52.690 ), 
  new Vsop87Coefficient( 148,	      1.535,	    5.629 ), 
  new Vsop87Coefficient( 146,	      6.231,	    195.140 ), 
  new Vsop87Coefficient( 140,	      4.295,	    21.341 ), 
  new Vsop87Coefficient( 131,	      4.068,	    10.295 ), 
  new Vsop87Coefficient( 125,	      6.277,	    1898.351 ), 
  new Vsop87Coefficient( 122,	      1.976,	    4.666 ), 
  new Vsop87Coefficient( 118,	      5.341,	    554.070 ), 
  new Vsop87Coefficient( 117,	      2.679,	    1155.361 ), 
  new Vsop87Coefficient( 114,	      5.594,	    1059.382 ), 
  new Vsop87Coefficient( 112,	      1.105,	    191.208 ), 
  new Vsop87Coefficient( 110,	      0.166,	    1.484 ), 
  new Vsop87Coefficient( 109,	      3.438,	    536.805 ), 
  new Vsop87Coefficient( 107,	      4.012,	    956.289 ), 
  new Vsop87Coefficient( 104,	      2.192,	    88.866 ), 
  new Vsop87Coefficient( 103,	      1.197,	    1685.052 ), 
  new Vsop87Coefficient( 101,	      4.965,	    269.921 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L1SaturnCoefficients =
{ 
  new Vsop87Coefficient( 21354295596.0, 0,        	0 ), 
  new Vsop87Coefficient( 1296855,    	 1.8282054,	213.2990954 ), 
  new Vsop87Coefficient( 564348,	       2.885001,	7.113547 ), 
  new Vsop87Coefficient( 107679,	       2.277699,	206.185548 ), 
  new Vsop87Coefficient( 98323,	       1.08070,	  426.59819 ), 
  new Vsop87Coefficient( 40255,	       2.04128,	  220.41264 ), 
  new Vsop87Coefficient( 19942,	       1.27955,	  103.09277 ), 
  new Vsop87Coefficient( 10512,	       2.74880,	  14.22709 ), 
  new Vsop87Coefficient( 6939,	         0.4049,	  639.8973 ), 
  new Vsop87Coefficient( 4803,	         2.4419,	  419.4846 ), 
  new Vsop87Coefficient( 4056,	         2.9217,	  110.2063 ), 
  new Vsop87Coefficient( 3769,	         3.6497,	  3.9322 ), 
  new Vsop87Coefficient( 3385,	         2.4169,	  3.1814 ), 
  new Vsop87Coefficient( 3302,	         1.2626,	  433.7117 ), 
  new Vsop87Coefficient( 3071,	         2.3274,	  199.0720 ), 
  new Vsop87Coefficient( 1953,	         3.5639,	  11.0457 ), 
  new Vsop87Coefficient( 1249,	         2.6280,	  95.9792 ), 
  new Vsop87Coefficient( 922,	         1.961,	    227.526 ), 
  new Vsop87Coefficient( 706,	         4.417,	    529.691 ), 
  new Vsop87Coefficient( 650,	         6.174,	    202.253 ), 
  new Vsop87Coefficient( 628,	         6.111,	    309.278 ), 
  new Vsop87Coefficient( 487,	         6.040,	    853.196 ), 
  new Vsop87Coefficient( 479,	         4.988,	    522.577 ), 
  new Vsop87Coefficient( 468,	         4.617,	    63.736 ), 
  new Vsop87Coefficient( 417,	         2.117,	    323.505 ), 
  new Vsop87Coefficient( 408,	         1.299,	    209.367 ), 
  new Vsop87Coefficient( 352,	         2.317,	    632.784 ), 
  new Vsop87Coefficient( 344,	         3.959,	    412.371 ), 
  new Vsop87Coefficient( 340,	         3.634,	    316.392 ), 
  new Vsop87Coefficient( 336,	         3.772,	    735.877 ), 
  new Vsop87Coefficient( 332,	         2.861,	    210.118 ), 
  new Vsop87Coefficient( 289,	         2.733,	    117.320 ), 
  new Vsop87Coefficient( 281,	         5.744,	    2.448 ), 
  new Vsop87Coefficient( 266,	         0.543,	    647.011 ), 
  new Vsop87Coefficient( 230,	         1.644,	    216.480 ), 
  new Vsop87Coefficient( 192,	         2.965,	    224.345 ), 
  new Vsop87Coefficient( 173,	         4.077,	    846.083 ), 
  new Vsop87Coefficient( 167,	         2.597,	    21.341 ), 
  new Vsop87Coefficient( 136,	         2.286,	    10.295 ), 
  new Vsop87Coefficient( 131,	         3.441,	    742.990 ), 
  new Vsop87Coefficient( 128,	         4.095,	    217.231 ), 
  new Vsop87Coefficient( 109,	         6.161,	    415.552 ), 
  new Vsop87Coefficient( 98,	           4.73,	    838.97 ), 
  new Vsop87Coefficient( 94,	           3.48,	    1052.27 ), 
  new Vsop87Coefficient( 92,	           3.95,	    88.87 ), 
  new Vsop87Coefficient( 87,	           1.22,	    440.83 ), 
  new Vsop87Coefficient( 83,	           3.11,	    625.67 ), 
  new Vsop87Coefficient( 78,	           6.24,	    302.16 ), 
  new Vsop87Coefficient( 67,	           0.29,	    4.67 ), 
  new Vsop87Coefficient( 66,	           5.65,	    9.56 ), 
  new Vsop87Coefficient( 62,	           4.29,	    127.47 ), 
  new Vsop87Coefficient( 62,	           1.83,	    195.14 ), 
  new Vsop87Coefficient( 58,	           2.48,	    191.96 ), 
  new Vsop87Coefficient( 57,	           5.02,	    137.03 ), 
  new Vsop87Coefficient( 55,	           0.28,	    74.78 ), 
  new Vsop87Coefficient( 54,	           5.13,	    490.33 ), 
  new Vsop87Coefficient( 51,	           1.46,	    536.80 ), 
  new Vsop87Coefficient( 47,	           1.18,	    149.56 ), 
  new Vsop87Coefficient( 47,	           5.15,	    515.46 ), 
  new Vsop87Coefficient( 46,	           2.23,	    956.29 ), 
  new Vsop87Coefficient( 44,	           2.71,	    5.42 ), 
  new Vsop87Coefficient( 40,	           0.41,	    269.92 ), 
  new Vsop87Coefficient( 40,	           3.89,	    728.76 ), 
  new Vsop87Coefficient( 38,	           0.65,	    422.67 ), 
  new Vsop87Coefficient( 38,	           2.53,	    12.53 ), 
  new Vsop87Coefficient( 37,	           3.78,	    2.92 ), 
  new Vsop87Coefficient( 35,	           6.08,	    5.63 ), 
  new Vsop87Coefficient( 34,	           3.21,	    1368.66 ), 
  new Vsop87Coefficient( 33,	           4.64,	    277.03 ), 
  new Vsop87Coefficient( 33,	           5.43,	    1066.50 ), 
  new Vsop87Coefficient( 33,	           0.30,	    351.82 ), 
  new Vsop87Coefficient( 32,	           4.39,	    1155.36 ), 
  new Vsop87Coefficient( 31,	           2.43,	    52.69 ), 
  new Vsop87Coefficient( 30,	           2.84,	    203.00 ), 
  new Vsop87Coefficient( 30,	           6.19,	    284.15 ), 
  new Vsop87Coefficient( 30,	           3.39,	    1059.38 ), 
  new Vsop87Coefficient( 29,	           2.03,	    330.62 ), 
  new Vsop87Coefficient( 28,	           2.74,	    265.99 ), 
  new Vsop87Coefficient( 26,	           4.51,	    340.77 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L2SaturnCoefficients =
{ 
  new Vsop87Coefficient( 116441,	1.179879,	7.113547 ), 
  new Vsop87Coefficient( 91921,	0.07425,	213.29910 ), 
  new Vsop87Coefficient( 90592,	0,	      0 ), 
  new Vsop87Coefficient( 15277,	4.06492,	206.18555 ), 
  new Vsop87Coefficient( 10631,	0.25778,	220.41264 ), 
  new Vsop87Coefficient( 10605,	5.40964,	426.59819 ), 
  new Vsop87Coefficient( 4265,	  1.0460,	  14.2271 ), 
  new Vsop87Coefficient( 1216,	  2.9186,	  103.0928 ), 
  new Vsop87Coefficient( 1165,	  4.6094,	  639.8973 ), 
  new Vsop87Coefficient( 1082,	  5.6913,	  433.7117 ), 
  new Vsop87Coefficient( 1045,	  4.0421,	  199.0720 ), 
  new Vsop87Coefficient( 1020,	  0.6337,	  3.1814 ), 
  new Vsop87Coefficient( 634,	  4.388,	  419.485 ), 
  new Vsop87Coefficient( 549,	  5.573,	  3.932 ), 
  new Vsop87Coefficient( 457,	  1.268,	  110.206 ), 
  new Vsop87Coefficient( 425,	  0.209,	  227.526 ), 
  new Vsop87Coefficient( 274,	  4.288,	  95.979 ), 
  new Vsop87Coefficient( 162,	  1.381,	  11.046 ), 
  new Vsop87Coefficient( 129,	  1.566,	  309.278 ), 
  new Vsop87Coefficient( 117,	  3.881,	  853.196 ), 
  new Vsop87Coefficient( 105,	  4.900,	  647.011 ), 
  new Vsop87Coefficient( 101,	  0.893,	  21.341 ), 
  new Vsop87Coefficient( 96,	    2.91,	    316.39 ), 
  new Vsop87Coefficient( 95,	    5.63,	    412.37 ), 
  new Vsop87Coefficient( 85,	    5.73,	    209.37 ), 
  new Vsop87Coefficient( 83,	    6.05,	    216.48 ), 
  new Vsop87Coefficient( 82,	    1.02,	    117.32 ), 
  new Vsop87Coefficient( 75,	    4.76,	    210.12 ), 
  new Vsop87Coefficient( 67,	    0.46,	    522.58 ), 
  new Vsop87Coefficient( 66,	    0.48,	    10.29 ), 
  new Vsop87Coefficient( 64,	    0.35,	    323.51 ), 
  new Vsop87Coefficient( 61,	    4.88,	    632.78 ), 
  new Vsop87Coefficient( 53,	    2.75,	    529.69 ), 
  new Vsop87Coefficient( 46,	    5.69,	    440.83 ), 
  new Vsop87Coefficient( 45,	    1.67,	    202.25 ), 
  new Vsop87Coefficient( 42,	    5.71,	    88.87 ), 
  new Vsop87Coefficient( 32,	    0.07,	    63.74 ), 
  new Vsop87Coefficient( 32,	    1.67,	    302.16 ), 
  new Vsop87Coefficient( 31,	    4.16,	    191.96 ), 
  new Vsop87Coefficient( 27,	    0.83,	    224.34 ), 
  new Vsop87Coefficient( 25,	    5.66,	    735.88 ), 
  new Vsop87Coefficient( 20,	    5.94,	    217.23 ), 
  new Vsop87Coefficient( 18,	    4.90,	    625.67 ), 
  new Vsop87Coefficient( 17,	    1.63,	    742.99 ), 
  new Vsop87Coefficient( 16,	    0.58,	    515.46 ), 
  new Vsop87Coefficient( 14,	    0.21,	    838.97 ), 
  new Vsop87Coefficient( 14,	    3.76,	    195.14 ), 
  new Vsop87Coefficient( 12,	    4.72,	    203.00 ), 
  new Vsop87Coefficient( 12,	    0.13,	    234.64 ), 
  new Vsop87Coefficient( 12,	    3.12,	    846.08 ), 
  new Vsop87Coefficient( 11,	    5.92,	    536.80 ), 
  new Vsop87Coefficient( 11,	    5.60,	    728.76 ), 
  new Vsop87Coefficient( 11,	    3.20,	    1066.50 ), 
  new Vsop87Coefficient( 10,	    4.99,	    422.67 ), 
  new Vsop87Coefficient( 10,	    0.26,	    330.62 ), 
  new Vsop87Coefficient( 10,	    4.15,	    860.31 ), 
  new Vsop87Coefficient( 9,	    0.46,	    956.29 ), 
  new Vsop87Coefficient( 8,	    2.14,	    269.92 ), 
  new Vsop87Coefficient( 8,	    5.25,	    429.78 ), 
  new Vsop87Coefficient( 8,	    4.03,	    9.56 ), 
  new Vsop87Coefficient( 7,	    5.40,	    1052.27 ), 
  new Vsop87Coefficient( 6,	    4.46,	    284.15 ), 
  new Vsop87Coefficient( 6,	    5.93,	    405.26 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L3SaturnCoefficients =
{ 
  new Vsop87Coefficient( 16039,	5.73945,	7.11355 ), 
  new Vsop87Coefficient( 4250,	  4.5854,	  213.2991 ), 
  new Vsop87Coefficient( 1907,	  4.7608,	  220.4126 ), 
  new Vsop87Coefficient( 1466,	  5.9133,	  206.1855 ), 
  new Vsop87Coefficient( 1162,	  5.6197,	  14.2271 ), 
  new Vsop87Coefficient( 1067,	  3.6082,	  426.5982 ), 
  new Vsop87Coefficient( 239,	  3.861,	  433.712 ), 
  new Vsop87Coefficient( 237,	  5.768,	  199.072 ), 
  new Vsop87Coefficient( 166,	  5.116,	  3.181 ), 
  new Vsop87Coefficient( 151,	  2.736,	  639.897 ), 
  new Vsop87Coefficient( 131,	  4.743,	  227.526 ), 
  new Vsop87Coefficient( 63,	    0.23,	    419.48 ), 
  new Vsop87Coefficient( 62,	    4.74,	    103.09 ), 
  new Vsop87Coefficient( 40,	    5.47,	    21.34 ), 
  new Vsop87Coefficient( 40,	    5.96,	    95.98 ), 
  new Vsop87Coefficient( 39,	    5.83,	    110.21 ),  
  new Vsop87Coefficient( 28,	    3.01,	    647.01 ),  
  new Vsop87Coefficient( 25,	    0.99,	    3.93 ), 
  new Vsop87Coefficient( 19,	    1.92,	    853.20 ),  
  new Vsop87Coefficient( 18,	    4.97,	    10.29 ), 
  new Vsop87Coefficient( 18,	    1.03,	    412.37 ), 
  new Vsop87Coefficient( 18,	    4.20,	    216.48 ), 
  new Vsop87Coefficient( 18,	    3.32,	    309.28 ),  
  new Vsop87Coefficient( 16,	    3.90,	    440.83 ),  
  new Vsop87Coefficient( 16,	    5.62,	    117.32 ),  
  new Vsop87Coefficient( 13,	    1.18,	    88.87 ),  
  new Vsop87Coefficient( 11,	    5.58,	    11.05 ),  
  new Vsop87Coefficient( 11,	    5.93,	    191.96 ),  
  new Vsop87Coefficient( 10,	    3.95,	    209.37 ),  
  new Vsop87Coefficient( 9,	    3.39,	    302.16 ),  
  new Vsop87Coefficient( 8,	    4.88,	    323.51 ),  
  new Vsop87Coefficient( 7,	    0.38,	    632.78 ),  
  new Vsop87Coefficient( 6,	    2.25,	    522.58 ),  
  new Vsop87Coefficient( 6,	    1.06,	    210.12 ),  
  new Vsop87Coefficient( 5,	    4.64,	    234.64 ),  
  new Vsop87Coefficient( 4,	    3.14,	    0 ), 
  new Vsop87Coefficient( 4,	    2.31,	    515.46 ), 
  new Vsop87Coefficient( 3,	    2.20,	    860.31 ),  
  new Vsop87Coefficient( 3,	    0.59,	    529.69 ),  
  new Vsop87Coefficient( 3,	    4.93,	    224.34 ),  
  new Vsop87Coefficient( 3,	    0.42,	    625.67 ),  
  new Vsop87Coefficient( 2,	    4.77,	    330.62 ),  
  new Vsop87Coefficient( 2,	    3.35,	    429.78 ),  
  new Vsop87Coefficient( 2,	    3.20,	    202.25 ),  
  new Vsop87Coefficient( 2,	    1.19,	    1066.50 ),  
  new Vsop87Coefficient( 2,	    1.35,	    405.26 ),  
  new Vsop87Coefficient( 2,	    4.16,	    223.59 ),  
  new Vsop87Coefficient( 2,	    3.07,	    654.12 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L4SaturnCoefficients =
{ 
  new Vsop87Coefficient( 1662,	3.9983,	7.1135 ), 
  new Vsop87Coefficient( 257,	2.984,	220.413 ), 
  new Vsop87Coefficient( 236,	3.902,	14.227 ), 
  new Vsop87Coefficient( 149,	2.741,	213.299 ), 
  new Vsop87Coefficient( 114,	3.142,	0 ), 
  new Vsop87Coefficient( 110,	1.515,	206.186 ), 
  new Vsop87Coefficient( 68,	  1.72,	  426.60  ),  
  new Vsop87Coefficient( 40,	  2.05,	  433.71 ),  
  new Vsop87Coefficient( 38,	  1.24,	  199.07 ),  
  new Vsop87Coefficient( 31,	  3.01,	  227.53 ),  
  new Vsop87Coefficient( 15,	  0.83,	  639.90 ),  
  new Vsop87Coefficient( 9,	  3.71,	  21.34 ),  
  new Vsop87Coefficient( 6,	  2.42,	  419.48 ),  
  new Vsop87Coefficient( 6,	  1.16,	  647.01 ),  
  new Vsop87Coefficient( 4,	  1.45,	  95.98 ),  
  new Vsop87Coefficient( 4,	  2.12,	  440.83 ),  
  new Vsop87Coefficient( 3,	  4.09,	  110.21 ),  
  new Vsop87Coefficient( 3,	  2.77,	  412.37 ),  
  new Vsop87Coefficient( 3,	  3.01,	  88.87 ),  
  new Vsop87Coefficient( 3,	  0.00,	  853.20 ),  
  new Vsop87Coefficient( 3,	  0.39,	  103.09 ),  
  new Vsop87Coefficient( 2,	  3.78,	  117.32 ),  
  new Vsop87Coefficient( 2,	  2.83,	  234.64 ),  
  new Vsop87Coefficient( 2,	  5.08,	  309.28 ),  
  new Vsop87Coefficient( 2,	  2.24,	  216.48 ),  
  new Vsop87Coefficient( 2,	  5.19,	  302.16 ),  
  new Vsop87Coefficient( 1,	  1.55,	  191.96 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] L5SaturnCoefficients =
{ 
  new Vsop87Coefficient( 124,	2.259,	7.114 ), 
  new Vsop87Coefficient( 34,	  2.16,	  14.23 ), 
  new Vsop87Coefficient( 28,	  1.20,	  220.41 ), 
  new Vsop87Coefficient( 6,	  1.22,	  227.53 ), 
  new Vsop87Coefficient( 5,	  0.24,	  433.71 ), 
  new Vsop87Coefficient( 4,	  6.23,	  426.60 ), 
  new Vsop87Coefficient( 3,	  2.97,	  199.07 ), 
  new Vsop87Coefficient( 3,	  4.29,	  206.19 ), 
  new Vsop87Coefficient( 2,	  6.25,	  213.30 ), 
  new Vsop87Coefficient( 1,	  5.28,	  639.90 ), 
  new Vsop87Coefficient( 1,	  0.24,	  440.83 ), 
  new Vsop87Coefficient( 1,	  3.14,	  0 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B0SaturnCoefficients =
{ 
  new Vsop87Coefficient( 4330678,	3.6028443,	213.2990954 ), 
  new Vsop87Coefficient( 240348,	  2.852385,	  426.598191 ), 
  new Vsop87Coefficient( 84746,	  0,	        0 ), 
  new Vsop87Coefficient( 34116,	  0.57297,	  206.18555 ), 
  new Vsop87Coefficient( 30863,	  3.48442,	  220.41264 ), 
  new Vsop87Coefficient( 14734,	  2.11847,	  639.89729 ), 
  new Vsop87Coefficient( 9917,	    5.7900,	    419.4846 ), 
  new Vsop87Coefficient( 6994,	    4.7360,	    7.1135 ), 
  new Vsop87Coefficient( 4808,	    5.4331,	    316.3919 ), 
  new Vsop87Coefficient( 4788,	    4.9651,	    110.2063 ), 
  new Vsop87Coefficient( 3432,	    2.7326,	    433.7117 ), 
  new Vsop87Coefficient( 1506,	    6.0130,	    103.0928 ), 
  new Vsop87Coefficient( 1060,	    5.6310,	    529.6910 ), 
  new Vsop87Coefficient( 969,	    5.204,	    632.784 ), 
  new Vsop87Coefficient( 942,	    1.396,	    853.196 ), 
  new Vsop87Coefficient( 708,	    3.803,	    323.505 ), 
  new Vsop87Coefficient( 552,	    5.131,	    202.253 ), 
  new Vsop87Coefficient( 400,	    3.359,	    227.526 ), 
  new Vsop87Coefficient( 319,	    3.626,	    209.367 ), 
  new Vsop87Coefficient( 316,	    1.997,	    647.011 ), 
  new Vsop87Coefficient( 314,	    0.465,	    217.231 ), 
  new Vsop87Coefficient( 284,	    4.886,	    224.345 ), 
  new Vsop87Coefficient( 236,	    2.139,	    11.046 ), 
  new Vsop87Coefficient( 215,	    5.950,	    846.083  ), 
  new Vsop87Coefficient( 209,	    2.120,	    415.552 ), 
  new Vsop87Coefficient( 207,	    0.730,	    199.072 ), 
  new Vsop87Coefficient( 179,	    2.954,	    63.736 ), 
  new Vsop87Coefficient( 141,	    0.644,	    490.334 ), 
  new Vsop87Coefficient( 139,	    4.595,	    14.227 ), 
  new Vsop87Coefficient( 139,	    1.998,	    735.877 ), 
  new Vsop87Coefficient( 135,	    5.245,	    742.990 ), 
  new Vsop87Coefficient( 122,	    3.115,	    522.577 ), 
  new Vsop87Coefficient( 116,	    3.109,	    216.480 ), 
  new Vsop87Coefficient( 114,	    0.963,	    210.118 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B1SaturnCoefficients =
{ 
  new Vsop87Coefficient( 397555,	5.332900,	213.299095 ), 
  new Vsop87Coefficient( 49479,	3.14159,	0 ), 
  new Vsop87Coefficient( 18572,	6.09919,	426.59819 ), 
  new Vsop87Coefficient( 14801,	2.30586,	206.18555 ), 
  new Vsop87Coefficient( 9644,	  1.6967,	  220.4126 ), 
  new Vsop87Coefficient( 3757,	  1.2543,	  419.4846 ), 
  new Vsop87Coefficient( 2717,	  5.9117,	  639.8973 ), 
  new Vsop87Coefficient( 1455,	  0.8516,	  433.7117 ), 
  new Vsop87Coefficient( 1291,	  2.9177,	  7.1135 ), 
  new Vsop87Coefficient( 853,	  0.436,	  316.392 ), 
  new Vsop87Coefficient( 298,	  0.919,	  632.784 ), 
  new Vsop87Coefficient( 292,	  5.316,	  853.196 ), 
  new Vsop87Coefficient( 284,	  1.619,	  227.526 ), 
  new Vsop87Coefficient( 275,	  3.889,	  103.093 ), 
  new Vsop87Coefficient( 172,	  0.052,	  647.011 ), 
  new Vsop87Coefficient( 166,	  2.444,	  199.072 ), 
  new Vsop87Coefficient( 158,	  5.209,	  110.206 ), 
  new Vsop87Coefficient( 128,	  1.207,	  529.691 ), 
  new Vsop87Coefficient( 110,	  2.457,	  217.231 ), 
  new Vsop87Coefficient( 82,	    2.76,	    210.12 ), 
  new Vsop87Coefficient( 81,	    2.86,	    14.23 ), 
  new Vsop87Coefficient( 69,	    1.66,	    202.25 ), 
  new Vsop87Coefficient( 65,	    1.26,	    216.48 ), 
  new Vsop87Coefficient( 61,	    1.25,	    209.37 ), 
  new Vsop87Coefficient( 59,	    1.82,	    323.51 ), 
  new Vsop87Coefficient( 46,	    0.82,	    440.83 ), 
  new Vsop87Coefficient( 36,	    1.82,	    224.34 ), 
  new Vsop87Coefficient( 34,	    2.84,	    117.32 ), 
  new Vsop87Coefficient( 33,	    1.31,	    412.37 ), 
  new Vsop87Coefficient( 32,	    1.19,	    846.08 ), 
  new Vsop87Coefficient( 27,	    4.65,	    1066.50 ), 
  new Vsop87Coefficient( 27,	    4.44,	    11.05 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B2SaturnCoefficients =
{ 
  new Vsop87Coefficient( 20630,	0.50482,	213.29910 ),  
  new Vsop87Coefficient( 3720,	  3.9983,	  206.1855 ), 
  new Vsop87Coefficient( 1627,	  6.1819,	  220.4126 ), 
  new Vsop87Coefficient( 1346,	  0,	      0 ), 
  new Vsop87Coefficient( 706,	  3.039,	  419.485 ), 
  new Vsop87Coefficient( 365,	  5.099,	  426.598 ), 
  new Vsop87Coefficient( 330,	  5.279,	  433.712 ), 
  new Vsop87Coefficient( 219,	  3.828,	  639.897 ), 
  new Vsop87Coefficient( 139,	  1.043,	  7.114 ), 
  new Vsop87Coefficient( 104,	  6.157,	  227.526 ), 
  new Vsop87Coefficient( 93,	    1.98,	    316.39 ), 
  new Vsop87Coefficient( 71,	    4.15,	    199.07 ), 
  new Vsop87Coefficient( 52,	    2.88,	    632.78 ), 
  new Vsop87Coefficient( 49,	    4.43,	    647.01 ), 
  new Vsop87Coefficient( 41,	    3.16,	    853.20 ), 
  new Vsop87Coefficient( 29,	    4.53,	    210.12 ), 
  new Vsop87Coefficient( 24,	    1.12,	    14.23 ), 
  new Vsop87Coefficient( 21,	    4.35,	    217.23 ), 
  new Vsop87Coefficient( 20,	    5.31,	    440.83 ), 
  new Vsop87Coefficient( 18,	    0.85,	    110.21 ), 
  new Vsop87Coefficient( 17,	    5.68,	    216.48 ), 
  new Vsop87Coefficient( 16,	    4.26,	    103.09 ), 
  new Vsop87Coefficient( 14,	    3.00,	    412.37 ), 
  new Vsop87Coefficient( 12,	    2.53,	    529.69 ), 
  new Vsop87Coefficient( 8,	    3.32,	    202.25 ), 
  new Vsop87Coefficient( 7,	    5.56,	    209.37 ), 
  new Vsop87Coefficient( 7,	    0.29,	    323.51 ), 
  new Vsop87Coefficient( 6,	    1.16,	    117.32 ), 
  new Vsop87Coefficient( 6,	    3.61,	    869.31 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B3SaturnCoefficients =
{ 
  new Vsop87Coefficient( 666,	1.990,	213.299 ), 
  new Vsop87Coefficient( 632,	5.698,	206.186 ), 
  new Vsop87Coefficient( 398,	0,	    0 ), 
  new Vsop87Coefficient( 188,	4.338,	220.413 ), 
  new Vsop87Coefficient( 92,	  4.84,	  419.48 ), 
  new Vsop87Coefficient( 52,	  3.42,	  433.71 ), 
  new Vsop87Coefficient( 42,	  2.38,	  426.60 ), 
  new Vsop87Coefficient( 26,	  4.40,	  227.53 ), 
  new Vsop87Coefficient( 21,	  5.85,	  199.07 ), 
  new Vsop87Coefficient( 18,	  1.99,	  639.90 ), 
  new Vsop87Coefficient( 11,	  5.37,	  7.11 ), 
  new Vsop87Coefficient( 10,	  2.55,	  647.01 ), 
  new Vsop87Coefficient( 7,	  3.46,	  316.39 ), 
  new Vsop87Coefficient( 6,	  4.80,	  632.78 ), 
  new Vsop87Coefficient( 6,	  0.02,	  210.12 ), 
  new Vsop87Coefficient( 6,	  3.52,	  440.83 ), 
  new Vsop87Coefficient( 5,	  5.64,	  14.23 ), 
  new Vsop87Coefficient( 5,	  1.22,	  853.20 ), 
  new Vsop87Coefficient( 4,	  4.71,	  412.37 ), 
  new Vsop87Coefficient( 3,	  0.63,	  103.09 ), 
  new Vsop87Coefficient( 2,	  3.72,	  216.48 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B4SaturnCoefficients =
{ 
  new Vsop87Coefficient( 80,	1.12,	206.19 ), 
  new Vsop87Coefficient( 32,	3.12,	213.30 ), 
  new Vsop87Coefficient( 17,	2.48,	220.41 ), 
  new Vsop87Coefficient( 12,	3.14,	0 ), 
  new Vsop87Coefficient( 9,	0.38,	419.48 ), 
  new Vsop87Coefficient( 6,	1.56,	433.71 ), 
  new Vsop87Coefficient( 5,	2.63,	227.53 ), 
  new Vsop87Coefficient( 5,	1.28,	199.07 ), 
  new Vsop87Coefficient( 1,	1.43,	426.60 ), 
  new Vsop87Coefficient( 1,	0.67,	647.01 ), 
  new Vsop87Coefficient( 1,	1.72,	440.83 ), 
  new Vsop87Coefficient( 1,	6.18,	639.90 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] B5SaturnCoefficients =
{ 
  new Vsop87Coefficient( 8,	2.82,	206.19 ), 
  new Vsop87Coefficient( 1,	0.51,	220.41 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R0SaturnCoefficients =
{ 
  new Vsop87Coefficient( 955758136,	  0,	        0 ), 
  new Vsop87Coefficient( 52921382,	    2.39226220,	213.29909544 ), 
  new Vsop87Coefficient( 1873680,	    5.2354961,	206.1855484 ), 
  new Vsop87Coefficient( 1464664,	    1.6476305,	426.5981909 ), 
  new Vsop87Coefficient( 821891,	      5.935200,	  316.391870 ), 
  new Vsop87Coefficient( 547507,	      5.015326,	  103.092774 ), 
  new Vsop87Coefficient( 371684,	      2.271148,	  220.412642 ), 
  new Vsop87Coefficient( 361778,       3.139043,	  7.113547 ), 
  new Vsop87Coefficient( 140618,	      5.704067,	  632.783739 ), 
  new Vsop87Coefficient( 108975,	      3.293136,	  110.206321 ), 
  new Vsop87Coefficient( 69007,	      5.94100,	  419.48464 ), 
  new Vsop87Coefficient( 61053,	      0.94038,	  639.89729 ), 
  new Vsop87Coefficient( 48913,	      1.55733,	  202.25340 ), 
  new Vsop87Coefficient( 34144,	      0.19519,	  277.03499 ), 
  new Vsop87Coefficient( 32402,	      5.47085,	  949.17561 ), 
  new Vsop87Coefficient( 20937,	      0.46349,	  735.87651 ), 
  new Vsop87Coefficient( 20839,	      1.52103,	  433.71174 ), 
  new Vsop87Coefficient( 20747,	      5.33256,	  199.07200 ), 
  new Vsop87Coefficient( 15298,	      3.05944,	  529.69097 ), 
  new Vsop87Coefficient( 14296,	      2.60434,	  323.50542 ), 
  new Vsop87Coefficient( 12884,	      1.64892,	  138.51750 ), 
  new Vsop87Coefficient( 11993,	      5.98051,	  846.08283 ), 
  new Vsop87Coefficient( 11380,	      1.73106,	  522.57742 ), 
  new Vsop87Coefficient( 9796,	        5.2048,	    1265.5675 ), 
  new Vsop87Coefficient( 7753,	        5.8519,	    95.9792 ), 
  new Vsop87Coefficient( 6771,	        3.0043,	    14.2271 ), 
  new Vsop87Coefficient( 6466,	        0.1773,	    1052.2684 ), 
  new Vsop87Coefficient( 5850,	        1.4552,	    415.5525 ), 
  new Vsop87Coefficient( 5307,	        0.5974,	    63.7359 ), 
  new Vsop87Coefficient( 4696,	        2.1492,	    227.5262 ), 
  new Vsop87Coefficient( 4044,	        1.6401,	    209.3669 ), 
  new Vsop87Coefficient( 3688,	        0.7802,	    412.3711 ), 
  new Vsop87Coefficient( 3461,	        1.8509,	    175.1661 ), 
  new Vsop87Coefficient( 3420,	        4.9455,	    1581.9593 ), 
  new Vsop87Coefficient( 3401,	        0.5539,	    350.3321 ), 
  new Vsop87Coefficient( 3376,	        3.6953,	    224.3448 ), 
  new Vsop87Coefficient( 2976,	        5.6847,	    210.1177 ), 
  new Vsop87Coefficient( 2885,	        1.3876,	    838.9693 ), 
  new Vsop87Coefficient( 2881,	        0.1796,	    853.1964 ), 
  new Vsop87Coefficient( 2508,	        3.5385,	    742.9901 ), 
  new Vsop87Coefficient( 2448,	        6.1841,	    1368.6603 ), 
  new Vsop87Coefficient( 2406,	        2.9656,	    117.3199 ), 
  new Vsop87Coefficient( 2174,	        0.0151,	    340.7709 ), 
  new Vsop87Coefficient( 2024,	        5.0541,	    11.0457 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R1SaturnCoefficients =
{ 
  new Vsop87Coefficient( 6182981,	0.2584352,	213.2990954 ), 
  new Vsop87Coefficient( 506578,	  0.711147,	  206.185548 ), 
  new Vsop87Coefficient( 341394,	  5.796358,	  426.598191 ), 
  new Vsop87Coefficient( 188491,	  0.472157,	  220.412642 ), 
  new Vsop87Coefficient( 186262,	  3.141593,	  0 ), 
  new Vsop87Coefficient( 143891,	  1.407449, 	7.113547 ),  
  new Vsop87Coefficient( 49621,	  6.01744,  	103.09277 ), 
  new Vsop87Coefficient( 20928,	  5.09246,  	639.89729 ), 
  new Vsop87Coefficient( 19953,	  1.17560,  	419.48464 ), 
  new Vsop87Coefficient( 18840,	  1.60820,  	110.20632 ), 
  new Vsop87Coefficient( 13877,	  0.75886,  	199.07200 ), 
  new Vsop87Coefficient( 12893,	  5.94330,  	433.71174 ), 
  new Vsop87Coefficient( 5397,	    1.2885,	    14.2271 ), 
  new Vsop87Coefficient( 4869,	    0.8679,	    323.5054 ), 
  new Vsop87Coefficient( 4247,	    0.3930,	    227.5262 ), 
  new Vsop87Coefficient( 3252,	    1.2585,	    95.9792 ), 
  new Vsop87Coefficient( 3081,	    3.4366,	    522.5774 ), 
  new Vsop87Coefficient( 2909,	    4.6068,	    202.2534 ), 
  new Vsop87Coefficient( 2856,	    2.1673,	    735.8765 ), 
  new Vsop87Coefficient( 1988,	    2.4505,	    412.3711 ), 
  new Vsop87Coefficient( 1941,	    6.0239,	    209.3669 ), 
  new Vsop87Coefficient( 1581,	    1.2919,	    210.1177 ), 
  new Vsop87Coefficient( 1340,	    4.3080,	    853.1964 ), 
  new Vsop87Coefficient( 1316,	    1.2530,	    117.3199 ), 
  new Vsop87Coefficient( 1203,	    1.8665,	    316.3919 ), 
  new Vsop87Coefficient( 1091,	    0.0753,	    216.4805 ), 
  new Vsop87Coefficient( 966,	    0.480,	    632.784 ), 
  new Vsop87Coefficient( 954,	    5.152,	    647.011 ), 
  new Vsop87Coefficient( 898,	    0.983,	    529.691 ), 
  new Vsop87Coefficient( 882,	    1.885,	    1052.268 ), 
  new Vsop87Coefficient( 874,	    1.402,	    224.345 ), 
  new Vsop87Coefficient( 785,	    3.064,	    838.969 ), 
  new Vsop87Coefficient( 740,	    1.382,	    625.670 ), 
  new Vsop87Coefficient( 658,	    4.144,	    309.278 ), 
  new Vsop87Coefficient( 650,	    1.725,	    742.990 ), 
  new Vsop87Coefficient( 613,	    3.033,	    63.736 ), 
  new Vsop87Coefficient( 599,	    2.549,	    217.231 ), 
  new Vsop87Coefficient( 503,	    2.130,	    3.932 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R2SaturnCoefficients =
{ 
  new Vsop87Coefficient( 436902,	4.786717,	213.299095 ), 
  new Vsop87Coefficient( 71923,	2.50070,	206.18555 ), 
  new Vsop87Coefficient( 49767,	4.97168,	220.41264 ), 
  new Vsop87Coefficient( 43221,	3.86940,	426.59819 ), 
  new Vsop87Coefficient( 29646,	5.96310,	7.11355 ), 
  new Vsop87Coefficient( 4721,	  2.4753,	  199.0720 ), 
  new Vsop87Coefficient( 4142,	  4.1067,	  433.7117 ), 
  new Vsop87Coefficient( 3789,	  3.0977,	  639.8973 ), 
  new Vsop87Coefficient( 2964,	  1.3721,	  103.0928 ), 
  new Vsop87Coefficient( 2556,	  2.8507,	  419.4846 ), 
  new Vsop87Coefficient( 2327,	  0,	      0 ), 
  new Vsop87Coefficient( 2208,	  6.2759,	  110.2063 ), 
  new Vsop87Coefficient( 2188,	  5.8555,	  14.2271 ), 
  new Vsop87Coefficient( 1957,	  4.9245,	  227.5262 ), 
  new Vsop87Coefficient( 924,	  5.464,	  323.505 ), 
  new Vsop87Coefficient( 706,	  2.971,	  95.979 ), 
  new Vsop87Coefficient( 546,	  4.129,	  412.371 ), 
  new Vsop87Coefficient( 431,	  5.178,	  522.577 ), 
  new Vsop87Coefficient( 405,	  4.173,	  209.367 ), 
  new Vsop87Coefficient( 391,	  4.481,	  216.480 ), 
  new Vsop87Coefficient( 374,	  5.834,	  117.320 ), 
  new Vsop87Coefficient( 361,	  3.277,	  647.011 ), 
  new Vsop87Coefficient( 356,	  3.192,	  210.118 ), 
  new Vsop87Coefficient( 326,	  2.269,	  853.196 ), 
  new Vsop87Coefficient( 207,	  4.022,	  735.877 ), 
  new Vsop87Coefficient( 204,	  0.088,	  202.253 ), 
  new Vsop87Coefficient( 180,	  3.597,	  632.784 ), 
  new Vsop87Coefficient( 178,	  4.097,	  440.825 ), 
  new Vsop87Coefficient( 154,	  3.135,	  625.670 ), 
  new Vsop87Coefficient( 148,	  0.136,	  302.165 ), 
  new Vsop87Coefficient( 133,	  2.594,	  191.958 ), 
  new Vsop87Coefficient( 132,	  5.933,	  309.278 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R3SaturnCoefficients =
{ 
  new Vsop87Coefficient( 20315,	3.02187,	213.29910 ), 
  new Vsop87Coefficient( 8924,	  3.1914, 	220.4126 ), 
  new Vsop87Coefficient( 6909,	  4.3517, 	206.1855 ), 
  new Vsop87Coefficient( 4087,	  4.2241, 	7.1135 ), 
  new Vsop87Coefficient( 3879,	  2.0106, 	426.5982 ), 
  new Vsop87Coefficient( 1071,	  4.2036, 	199.0720 ), 
  new Vsop87Coefficient( 907,	  2.283,  	433.712 ), 
  new Vsop87Coefficient( 606,	  3.175,  	227.526 ), 
  new Vsop87Coefficient( 597,	  4.135,  	14.227 ), 
  new Vsop87Coefficient( 483,	  1.173,  	639.897 ), 
  new Vsop87Coefficient( 393,	  0,      	0 ), 
  new Vsop87Coefficient( 229,	  4.698,	  419.485 ),  
  new Vsop87Coefficient( 188,	  4.590,	  110.206 ), 
  new Vsop87Coefficient( 150,	  3.202,	  103.093 ), 
  new Vsop87Coefficient( 121,	  3.768,	  323.505 ), 
  new Vsop87Coefficient( 102,	  4.710,	  95.979 ), 
  new Vsop87Coefficient( 101,	  5.819,	  412.371 ), 
  new Vsop87Coefficient( 93,	    1.44,	    647.01 ), 
  new Vsop87Coefficient( 84,	    2.63,	    216.48 ), 
  new Vsop87Coefficient( 73,	    4.15,	    117.32 ), 
  new Vsop87Coefficient( 62,	    2.31,	    440.83 ), 
  new Vsop87Coefficient( 55,	    0.31,	    853.20 ), 
  new Vsop87Coefficient( 50,	    2.39,	    209.37 ), 
  new Vsop87Coefficient( 45,	    4.37,	    191.96 ), 
  new Vsop87Coefficient( 41,	    0.69,	    522.58 ), 
  new Vsop87Coefficient( 40,	    1.84,	    302.16 ), 
  new Vsop87Coefficient( 38,	    5.94,	    88.87 ), 
  new Vsop87Coefficient( 32,	    4.01,	    21.34 )               
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R4SaturnCoefficients =
{ 
  new Vsop87Coefficient( 1202,	1.4150,	220.4126 ), 
  new Vsop87Coefficient( 708,	1.162,	213.299 ), 
  new Vsop87Coefficient( 516,	6.240,	206.186 ), 
  new Vsop87Coefficient( 427,	2.469,	7.114 ), 
  new Vsop87Coefficient( 268,	0.187,	426.598 ), 
  new Vsop87Coefficient( 170,	5.959,	199.072 ), 
  new Vsop87Coefficient( 150,	0.480,	433.712 ), 
  new Vsop87Coefficient( 145,	1.442,	227.526 ), 
  new Vsop87Coefficient( 121,	2.405,	14.227 ), 
  new Vsop87Coefficient( 47,	  5.57,	  639.90 ), 
  new Vsop87Coefficient( 19,	  5.86,	  647.01 ), 
  new Vsop87Coefficient( 17,	  0.53,	  440.83 ), 
  new Vsop87Coefficient( 16,	  2.90,	  110.21 ), 
  new Vsop87Coefficient( 15,	  0.30,	  419.48 ), 
  new Vsop87Coefficient( 14,	  1.30,	  412.37 ), 
  new Vsop87Coefficient( 13,	  2.09,	  323.51 ), 
  new Vsop87Coefficient( 11,	  0.22,	  95.98 ), 
  new Vsop87Coefficient( 11,	  2.46,	  117.32 ), 
  new Vsop87Coefficient( 10,	  3.14,	  0 ), 
  new Vsop87Coefficient( 9,	  1.56,	  88.87 ), 
  new Vsop87Coefficient( 9,	  2.28,	  21.34 ), 
  new Vsop87Coefficient( 9,	  0.68,	  216.48 ), 
  new Vsop87Coefficient( 8,	  1.27,	  234.64 )
};

        /// <summary>
        /// Vsop87 Coefficient.
        /// </summary>
        public static readonly Vsop87Coefficient[] R5SaturnCoefficients =
{ 
  new Vsop87Coefficient( 129,	5.913,	220.413 ), 
  new Vsop87Coefficient( 32,	  0.69,	  7.11 ), 
  new Vsop87Coefficient( 27,	  5.91,	  227.53 ), 
  new Vsop87Coefficient( 20,	  4.95,	  433.71 ), 
  new Vsop87Coefficient( 20,	  0.67,	  14.23 ), 
  new Vsop87Coefficient( 14,	  2.67,	  206.19 ), 
  new Vsop87Coefficient( 14,	  1.46,	  199.07 ), 
  new Vsop87Coefficient( 13,	  4.59,	  426.60 ), 
  new Vsop87Coefficient( 7,	  4.63,	  213.30 ), 
  new Vsop87Coefficient( 5,	  3.61,	  639.90 ), 
  new Vsop87Coefficient( 4,	  4.90,	  440.83 ), 
  new Vsop87Coefficient( 3,	  4.07,	  647.01 ), 
  new Vsop87Coefficient( 3,	  4.66,	  191.96 ), 
  new Vsop87Coefficient( 3,	  0.49,	  323.51 ), 
  new Vsop87Coefficient( 3,	  3.18,	  419.48 ), 
  new Vsop87Coefficient( 2,	  3.70,	  88.87 ), 
  new Vsop87Coefficient( 2,	  3.32,	  95.98 ), 
  new Vsop87Coefficient( 2,	  0.56,	  117.32 )
};
        #endregion
    }
}
