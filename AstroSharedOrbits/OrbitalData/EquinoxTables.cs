// <copyright file="EquinoxTables.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.OrbitalData
{
    using AstroSharedClasses.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Equinox Tables.
    /// </summary>
    public static class EquinoxTables {
        #region Constructors
        /// <summary>
        /// Initializes static members of the <see cref="EquinoxTables"/> class.
        /// </summary>
        static EquinoxTables() {
            TableA = new Dictionary<Season, IList<double>>();
            TableB = new Dictionary<Season, IList<double>>();

            //// For the years -1000 to +1000 
            TableA[Season.Spring] = new List<double> { 1721139.29189, 365242.13740, 0.06134, 0.00111, -0.00071 };
            TableA[Season.Summer] = new List<double> { 1721233.25401, 365241.72562, -0.05323, 0.00907, -0.00025 };
            TableA[Season.Autumn] = new List<double> { 1721325.70455, 365242.49558, -0.11677, -0.00297, 0.00074 };
            TableA[Season.Winter] = new List<double> { 1721414.39987, 365242.88257, -0.00769, -0.00933, -0.00006 };

            //// For the years +1000 to +3000 
            TableB[Season.Spring] = new List<double> { 2451623.80984, 365242.37404, 0.05169, -0.00411, -0.00057 };
            TableB[Season.Summer] = new List<double> { 2451716.56767, 365241.62603, 0.00325, 0.00888, -0.00030 };
            TableB[Season.Autumn] = new List<double> { 2451810.21715, 365242.01767, -0.11575, 0.00337, 0.00078 };
            TableB[Season.Winter] = new List<double> { 2451900.05952, 365242.74049, -0.06223, -0.00823, 0.00032 };

            //// S = Σ[A Cos(B + (C * T))]
            TableC = new IList<double>[] {
                                        new List<double>{ 485, 324.96,    1934.136 },
                                        new List<double>{ 203, 337.23,   32964.467 },
                                        new List<double>{ 199, 342.08,      20.186 },
                                        new List<double>{ 182,  27.85,  445267.112 },
                                        new List<double>{ 156,  73.14,   45036.886 },
                                        new List<double>{ 136, 171.52,   22518.443 },
                                        new List<double>{  77, 222.54,   65928.934 },
                                        new List<double>{  74, 296.72,    3034.906 },
                                        new List<double>{  70, 243.58,    9037.513 },
                                        new List<double>{  58, 119.81,   33718.147 },
                                        new List<double>{  52, 297.17,     150.678 },
                                        new List<double>{  50,  21.02,    2281.226 },
                                        new List<double>{  45, 247.54,   29929.562 },
                                        new List<double>{  44, 325.15,   31555.956 },
                                        new List<double>{  29,  60.93,    4443.417 },
                                        new List<double>{  18, 155.12,   67555.328 },
                                        new List<double>{  17, 288.79,    4562.452 },
                                        new List<double>{  16, 198.04,   62894.029 },
                                        new List<double>{  14, 199.76,   31436.921 },
                                        new List<double>{  12,  95.39,   14577.848 },
                                        new List<double>{  12, 287.11,   31931.756 },
                                        new List<double>{  12, 320.81,   34777.259 },
                                        new List<double>{   9, 227.73,    1222.114 },
                                        new List<double>{   8,  15.45,   16859.074 }
            };
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets For the years -1000 to +1000.
        /// </summary>
        /// <value> Property description. </value>
        public static IDictionary<Season, IList<double>> TableA { get; }

        /// <summary>
        /// Gets For the years +1000 to +3000.
        /// </summary>
        /// <value> Property description. </value>
        public static IDictionary<Season, IList<double>> TableB { get;  }

        /// <summary>
        /// Gets S = Σ[A Cos(B + (C * T))].
        /// </summary>
        /// <value> Property description. </value>
        public static IList<double>[] TableC { get; }
        #endregion
    }
}
