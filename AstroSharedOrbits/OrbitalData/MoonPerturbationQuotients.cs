// <copyright file="MoonPerturbationQuotients.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>
using AstroSharedClasses.Records;

namespace AstroSharedOrbits.OrbitalData {
    /// <summary>
    /// Moon Perturbation Quotients.
    /// </summary>
    public static class MoonPerturbationQuotients {
        #region MoonLongitudeQuotients
        /// <summary>
        /// MoonLongitude Quotient.
        /// </summary>
        public static readonly MoonLongitudeQuotient[] MoonLongitudeQuotients =
        { 
          new MoonLongitudeQuotient(0,  0,  1,  0, 6288774,	-20905355),
          new MoonLongitudeQuotient(2,  0, -1,  0, 1274027,	 -3699111),
          new MoonLongitudeQuotient(2,  0,  0,  0,  658314,	 -2955968),
          new MoonLongitudeQuotient(0,  0,  2,  0,  213618,	  -569925),
          new MoonLongitudeQuotient(0,  1,  0,  0, -185116,	    48888),
          new MoonLongitudeQuotient(0,  0,  0,  2, -114332,	    -3149),
          new MoonLongitudeQuotient(2,  0, -2,  0,   58793,	   246158),
          new MoonLongitudeQuotient(2, -1, -1,  0,   57066,	  -152138),
          new MoonLongitudeQuotient(2,  0,  1,  0,   53322,	  -170733),
          new MoonLongitudeQuotient(2, -1,  0,  0, 45758,	  -204586),
          new MoonLongitudeQuotient(0,  1, -1,  0, -40923,	 -129620),
          new MoonLongitudeQuotient(1,  0,  0,  0, -34720,	108743),
          new MoonLongitudeQuotient(0,  1,  1,  0, -30383,	104755),
          new MoonLongitudeQuotient(2,  0,  0, -2, 15327,	10321),
          new MoonLongitudeQuotient(0,  0,  1,  2, -12528, 0),
          new MoonLongitudeQuotient(0,  0,  1, -2, 10980,  79661),
          new MoonLongitudeQuotient(4,  0, -1,  0, 10675,  -34782),
          new MoonLongitudeQuotient(0,  0,  3,  0, 10034,  -23210),
          new MoonLongitudeQuotient(4,  0, -2,  0,  8548,    -21636),
          new MoonLongitudeQuotient(2,  1, -1,  0, -7888,  24208),
          new MoonLongitudeQuotient(2,  1,  0,  0, -6766,  30824),
          new MoonLongitudeQuotient(1,  0, -1,  0, -5163,  -8379),
          new MoonLongitudeQuotient(1,  1,  0,  0, 4987,  -16675),
          new MoonLongitudeQuotient(2, -1,  1,  0, 4036,  -12831 ),
          new MoonLongitudeQuotient(2,  0,  2,  0, 3994,  -10445),
          new MoonLongitudeQuotient(4,  0,  0,  0, 3861,  -11650),
          new MoonLongitudeQuotient(2,  0, -3,  0, 3665,  14403),
          new MoonLongitudeQuotient(0,  1, -2,  0, -2689, -7003),
          new MoonLongitudeQuotient(2,  0, -1,  2, -2602, 0),
          new MoonLongitudeQuotient(2, -1, -2,  0,  2390,   10056),
          new MoonLongitudeQuotient(1,  0,  1,  0, -2348, 6322),
          new MoonLongitudeQuotient(2, -2,  0,  0, 2236,   -9884),
          new MoonLongitudeQuotient(0,  1,  2,  0, -2120, 5751),
          new MoonLongitudeQuotient(0,  2,  0,  0, -2069,  0),
          new MoonLongitudeQuotient(2, -2, -1,  0, 2048,   -4950),
          new MoonLongitudeQuotient(2,  0,  1, -2, -1773,  4130 ),
          new MoonLongitudeQuotient(2,  0,  0,  2, -1595,  0),
          new MoonLongitudeQuotient(4, -1, -1,  0, 1215,   -3958),
          new MoonLongitudeQuotient(0,  0,  2,  2, -1110, 0),
          new MoonLongitudeQuotient(3,  0, -1,  0, -892,   3258),
          new MoonLongitudeQuotient(2,  1,  1,  0, -810,   2616),
          new MoonLongitudeQuotient(4, -1, -2,  0, 759,	   -1897),
          new MoonLongitudeQuotient(0,  2, -1,  0, -713,   -2117),
          new MoonLongitudeQuotient(2,  2, -1,  0, -700,   2354),
          new MoonLongitudeQuotient(2,  1, -2,  0,  691,   0),
          new MoonLongitudeQuotient(2, -1,  0, -2, 596,	    0),
          new MoonLongitudeQuotient(4,  0,  1,  0, 549,	-1423),
          new MoonLongitudeQuotient(0,  0,  4,  0, 537,	-1117),
          new MoonLongitudeQuotient(4, -1,  0,  0, 520,	-1571),
          new MoonLongitudeQuotient(1,  0, -2,  0, -487,-1739),
          new MoonLongitudeQuotient(2,  1,  0, -2, -399, 0),
          new MoonLongitudeQuotient(0,  0,  2, -2, -381,-4421),
          new MoonLongitudeQuotient(1,  1,  1,  0,  351, 0),
          new MoonLongitudeQuotient(3,  0, -2,  0, -340, 0),
          new MoonLongitudeQuotient(4,  0, -3,  0, 330,	 0),
          new MoonLongitudeQuotient(2, -1,  2,  0, 327,	 0),
          new MoonLongitudeQuotient(0,  2,  1,  0, -323, 1165),
          new MoonLongitudeQuotient(1,  1, -1,  0, 299,	 0),
          new MoonLongitudeQuotient(2,  0,  3,  0, 294,	 0),
          new MoonLongitudeQuotient(2,  0, -1, -2, 0,	 8752)
        };
        #endregion

        #region MoonLatitudeQuotients
        /// <summary>
        /// MoonLatitude Quotient.
        /// </summary>
        public static readonly MoonLatitudeQuotient[] MoonLatitudeQuotients =
        { 
          new MoonLatitudeQuotient(0,  0,  0,  1, 5128122 ),
          new MoonLatitudeQuotient(0,  0,  1,  1,  280602),
          new MoonLatitudeQuotient(0,  0,  1, -1,  277693),
          new MoonLatitudeQuotient(2,  0,  0, -1,  173237),
          new MoonLatitudeQuotient(2,  0, -1,  1,  55413),
          new MoonLatitudeQuotient(2,  0, -1, -1, 46271),
          new MoonLatitudeQuotient(2,  0,  0,  1,  32573),
          new MoonLatitudeQuotient(0,  0,  2,  1, 17198),
          new MoonLatitudeQuotient(2,  0,  1, -1,  9266),
          new MoonLatitudeQuotient(0,  0,  2, -1, 8822),
          new MoonLatitudeQuotient(2, -1,  0, -1, 8216),
          new MoonLatitudeQuotient(2,  0, -2, -1, 4324),
          new MoonLatitudeQuotient(2,  0,  1,  1, 4200),
          new MoonLatitudeQuotient(2,  1,  0, -1,  -3359),
          new MoonLatitudeQuotient(2, -1, -1,  1, 2463),
          new MoonLatitudeQuotient(2, -1,  0,  1, 2211 ),
          new MoonLatitudeQuotient(2, -1, -1, -1,  2065),
          new MoonLatitudeQuotient(0,  1, -1, -1, -1870),
          new MoonLatitudeQuotient(4,  0, -1, -1,  1828),
          new MoonLatitudeQuotient(0,  1,  0,  1,  -1794),
          new MoonLatitudeQuotient(0,  0,  0,  3, -1749),
          new MoonLatitudeQuotient(0,  1, -1,  1,  -1565),
          new MoonLatitudeQuotient(1,  0,  0,  1, -1491),
          new MoonLatitudeQuotient(0,  1,  1,  1,  -1475),
          new MoonLatitudeQuotient(0,  1,  1, -1,  -1410),
          new MoonLatitudeQuotient(0,  1,  0, -1,  -1344),
          new MoonLatitudeQuotient(1,  0,  0, -1,  -1335),
          new MoonLatitudeQuotient(0,  0,  3,  1,  1107),
          new MoonLatitudeQuotient(4,  0,  0, -1,  1021),
          new MoonLatitudeQuotient(4,  0, -1,  1, 833),
          new MoonLatitudeQuotient(0,  0,  1, -3, 777),
          new MoonLatitudeQuotient(4,  0, -2,  1,  671),
          new MoonLatitudeQuotient(2,  0,  0, -3, 607),
          new MoonLatitudeQuotient(2,  0,  2, -1, 596),
          new MoonLatitudeQuotient(2, -1,  1, -1, 491),
          new MoonLatitudeQuotient(2,  0, -2,  1,  -451),
          new MoonLatitudeQuotient(0,  0,  3, -1, 439),
          new MoonLatitudeQuotient(2,  0,  2,  1,  422),
          new MoonLatitudeQuotient(2,  0, -3, -1, 421),
          new MoonLatitudeQuotient(2,  1, -1,  1,   -366),
          new MoonLatitudeQuotient(2,  1,  0,  1,   -351),  
          new MoonLatitudeQuotient(4,  0,  0,  1,  331),
          new MoonLatitudeQuotient(2, -1,  1,  1,  315),
          new MoonLatitudeQuotient(2, -2,  0, -1, 302),
          new MoonLatitudeQuotient(0,  0,  1,  3,  -283),
          new MoonLatitudeQuotient(2,  1,  1, -1, -229),
          new MoonLatitudeQuotient(1,  1,  0, -1, 223),
          new MoonLatitudeQuotient(1,  1,  0,  1,  223),        
          new MoonLatitudeQuotient(0,  1, -2, -1, -220),
          new MoonLatitudeQuotient(2,  1, -1, -1,   -220),
          new MoonLatitudeQuotient(1,  0,  1,  1,  -185),
          new MoonLatitudeQuotient(2, -1, -2, -1, 181),
          new MoonLatitudeQuotient(0,  1,  2,  1,  -177),
          new MoonLatitudeQuotient(4,  0, -2, -1, 176),
          new MoonLatitudeQuotient(4, -1, -1, -1, 166),
          new MoonLatitudeQuotient(1,  0,  1, -1, -164),
          new MoonLatitudeQuotient(4,  0,  1, -1, 132),
          new MoonLatitudeQuotient(1,  0, -1, -1, -119),
          new MoonLatitudeQuotient(4, -1,  0, -1, 115),
          new MoonLatitudeQuotient(2, -2,  0,  1,  107)
        };
        #endregion
    }
}
