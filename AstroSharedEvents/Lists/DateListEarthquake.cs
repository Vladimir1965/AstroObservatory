// <copyright file="DateListEarthquake.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Lists
{
    using AstroSharedClasses.Computation;
    using AstroSharedEvents.Geology;
    using JetBrains.Annotations;

    /// <summary>
    /// Date List.
    /// </summary>
    public partial class EventList : DateList {
        /// <summary>
        /// The earthquake dates australia.
        /// </summary>
        [UsedImplicitly] public static readonly EarthquakeRecord[] EarthquakeDatesAustralia =
        {
                new EarthquakeRecord(21,11, 1982, 0, 0, "UTC",    0F,   0F,  5.4F, "Australia", string.Empty),
                new EarthquakeRecord(30, 3, 1986, 0, 0, "UTC",    0F,   0F,  5.9F, "Australia", string.Empty),
                new EarthquakeRecord(22, 1, 1988, 0, 0, "UTC",    0F,   0F,  6.7F, "Australia", string.Empty),
                new EarthquakeRecord(28, 5, 1989, 0, 0, "UTC",    0F,   0F,  5.7F, "Australia", string.Empty),
                new EarthquakeRecord(28,12, 1989, 0, 0, "UTC",    0F,   0F,  5.6F, "Australia", string.Empty),
                new EarthquakeRecord(30, 9, 1992, 0, 0, "UTC",    0F,   0F,  5.1F, "Australia", string.Empty),
                new EarthquakeRecord( 4, 1, 1994, 0, 0, "UTC",    0F,   0F,  6.8F, "Australia", string.Empty),
                new EarthquakeRecord( 6, 8, 1994, 0, 0, "UTC",    0F,   0F,  5.4F, "Australia", string.Empty),
                new EarthquakeRecord(25, 9, 1996, 0, 0, "UTC",    0F,   0F,  5.0F, "Australia", string.Empty),
                new EarthquakeRecord( 5, 3, 1997, 0, 0, "UTC",    0F,   0F,  5.0F, "Australia", string.Empty),
                new EarthquakeRecord(10, 8, 1997, 0, 0, "UTC",    0F,   0F,  6.3F, "Australia", string.Empty),
                new EarthquakeRecord(17, 3, 1999, 0, 0, "UTC",    0F,   0F,  4.8F, "Australia", string.Empty),
                new EarthquakeRecord(16,12, 1999, 0, 0, "UTC",    0F,   0F,  5.8F, "Australia", string.Empty),
                new EarthquakeRecord(18, 6, 2000, 0, 0, "UTC",    0F,   0F,  7.5F, "Australia", string.Empty),
                new EarthquakeRecord(29, 8, 2000, 0, 0, "UTC",    0F,   0F,  5.0F, "Australia", string.Empty),
                new EarthquakeRecord(11,10, 2000, 0, 0, "UTC",    0F,   0F,  5.5F, "Australia", string.Empty),
                new EarthquakeRecord(25,12, 2000, 0, 0, "UTC",    0F,   0F,  5.7F, "Australia", string.Empty),
                new EarthquakeRecord(28, 9, 2001, 0, 0, "UTC",    0F,   0F,  5.1F, "Australia", string.Empty),
                new EarthquakeRecord(27,10, 2001, 0, 0, "UTC",    0F,   0F,  4.8F, "Australia", string.Empty),
                new EarthquakeRecord(12,12, 2001, 0, 0, "UTC",    0F,   0F,  7.0F, "Australia", string.Empty),
                new EarthquakeRecord(23,12, 2004, 0, 0, "UTC",    0F,   0F,  8.1F, "Australia", string.Empty),
                new EarthquakeRecord(14,12, 2006, 0, 0, "UTC",    0F,   0F,  5.0F, "Australia", string.Empty),
                new EarthquakeRecord( 6, 3, 2009, 0, 0, "UTC",    0F,   0F,  4.7F, "Australia", string.Empty),
                new EarthquakeRecord(18, 3, 2009, 0, 0, "UTC",    0F,   0F,  4.7F, "Australia", string.Empty),
                new EarthquakeRecord(26, 3, 2010, 0, 0, "UTC",    0F,   0F,  5.5F, "Australia", string.Empty),
                new EarthquakeRecord(20, 4, 2010, 0, 0, "UTC",    0F,   0F,  5.0F, "Australia", string.Empty),
                new EarthquakeRecord( 5, 6, 2010, 0, 0, "UTC",    0F,   0F,  5.0F, "Australia", string.Empty),
                new EarthquakeRecord(13, 4, 2011, 0, 0, "UTC",    0F,   0F,  7.1F, "Australia", string.Empty),
                new EarthquakeRecord(17, 4, 2011, 0, 0, "UTC",    0F,   0F,  7.2F, "Australia", string.Empty),
                new EarthquakeRecord( 6,12, 2011, 0, 0, "UTC",    0F,   0F,  5.1F, "Australia", string.Empty),
                new EarthquakeRecord(23, 3, 2012, 0, 0, "UTC",    0F,   0F,  5.7F, "Australia", string.Empty),
                new EarthquakeRecord(19, 6, 2012, 0, 0, "UTC",    0F,   0F,  5.4F, "Australia", string.Empty)
        };

        /// <summary>
        /// Earthquake 
        /// </summary>
        [UsedImplicitly] 
        public static readonly EarthquakeRecord[] EarthquakeDates =
        {
            /* Eclipses for test
            new EarthquakeRecord(23, 3, 1951, 10, 37, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Lunar eclipse"),
            new EarthquakeRecord(07, 3, 1951, 21, 00, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Solar eclipse"),
            new EarthquakeRecord(17, 8, 1951, 03, 14, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Lunar eclipse"),

            new EarthquakeRecord(02,10, 1959, 12, 00, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Solar eclipse"),
            new EarthquakeRecord(15,02, 1961,  8, 00, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Solar eclipse"),

            new EarthquakeRecord(29, 4, 2014, 06, 00, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Solar eclipse"),
            new EarthquakeRecord(20, 3, 2015, 10, 00, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Solar eclipse"),
            new EarthquakeRecord(04, 4, 2015, 12, 00, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Lunar eclipse"),
            new EarthquakeRecord(13, 9, 2015, 07, 00, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Partial solar eclipse"),
            new EarthquakeRecord(28, 9, 2015, 02, 47, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Lunar eclipse"),
            new EarthquakeRecord( 9, 3, 2016, 02, 00, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Solar eclipse"),
            new EarthquakeRecord(23, 3, 2016, 11, 47, "UTC",     0.00F,   0.00F,  0.0F, "Test", "Lunar eclipse"),
            */
            new EarthquakeRecord(18, 9, 1737, 23, 59, "IST",    72.25F,   7.29F,  7.6F, "India", "Kolkata, West Bengal"),
            new EarthquakeRecord(16, 6, 1819, 18, 45, "LOCAL",  71.00F,   23.0F,  8.2F, "India", "Gujarat, Rann of Kutch"),
            new EarthquakeRecord(31,12, 1881, 07, 49, "IST",    92.43F,   8.52F,  7.9F, "India", "Andaman Islands, Nicobar Islands"),
            new EarthquakeRecord(12, 6, 1897, 15, 30, "IST",    91.00F,  26.00F,  8.1F, "India", "Shillong, India, Assam"),
            new EarthquakeRecord(04, 4, 1905, 01, 19, "IST",    76.03F,  32.01F,  7.8F, "India", "Shillong, India, Assam"),
            new EarthquakeRecord(15, 1, 1934, 14, 13, "IST",    87.09F,  27.55F,  8.7F, "India", "Nepal, Bihar, Mt. Everest"),
            new EarthquakeRecord(31, 5, 1935, 03, 02, "IST",    66.383F, 28.866F, 7.7F, "India", "Quetta, Baluchistan"),
            new EarthquakeRecord(26, 6, 1941, 08, 50, "IST",    92.57F,  12.50F,  8.1F, "India", "Andaman Islands"),
            new EarthquakeRecord(15, 8, 1950, 19, 22, "IST",    96.70F,  28.50F,  8.5F, "India", "Arunachal Pradesh, Assam"),
            new EarthquakeRecord(26, 1, 2001, 08, 50, "IST",    69.80F,  23.60F,  7.7F, "India", "Gujarat"),
            new EarthquakeRecord(26,12, 2004, 09, 28, "IST",    95.87F,  3.30F,   9.3F, "India", "Sumatra, India, Sri Lanka, Maldives"),
            new EarthquakeRecord( 8,10, 2005, 08, 50, "IST",    73.629F, 34.493F, 7.6F, "India", "Kashmir"),
            new EarthquakeRecord(10, 8, 2009, 01, 21, "IST",    92.80F,  14.10F,  7.7F, "India", "Andaman Islands"),
            new EarthquakeRecord(11, 3, 2011, 05, 46, "UTC",   142.792F, 38.510F, 9.0F, "Japan", "Tōhoku"),
            new EarthquakeRecord(12, 4, 1910, 08, 22, "UTC+8", 122.9F,   25.10F,  8.3F, "Taiwan", "Keelung"),
            new EarthquakeRecord( 5, 6, 1920, 12, 21, "UTC+8", 121.9F,   24.60F,  8.3F, "Taiwan", "Hualien"),
            new EarthquakeRecord( 2, 9, 1922, 03, 16, "UTC+8", 122.0F,   24.50F,  7.6F, "Taiwan", "Hualien"),
            new EarthquakeRecord(27, 4, 1959, 04, 41, "UTC+8", 123.0F,   24.10F,  7.7F, "Taiwan", "Northeast Taiwan"),
            new EarthquakeRecord(13, 3, 1966, 00, 31, "UTC+8", 122.7F,   24.20F,  7.8F, "Taiwan", "Hualien"),
            new EarthquakeRecord(21, 9, 1999, 01, 47, "UTC+8", 120.8F,   23.90F,  7.3F, "Taiwan", "Island-wide"),
            new EarthquakeRecord(22, 4, 1991, 21, 56, "UTC",   -83.073F,   9.685F, 7.6F, "Costa Rica", "Limon-Pandora"),
            new EarthquakeRecord( 5, 9, 2012, 14, 42, "UTC",   -85.347F,  10.12F,  7.6F, "Costa Rica", "Nicoya"),
            new EarthquakeRecord( 6, 8, 1942, 23, 37, "UTC",   -90.800F,  13.90F,  7.9F, "Guatemala", "Western Guatemala"),
            new EarthquakeRecord( 7,11, 2012, 16, 35, "UTC",   -91.965F,  13.987F, 7.4F, "Guatemala", "Guatemala"),
            new EarthquakeRecord(26, 1, 1700, 21, 00, "LOCAL",-125.00F,   48.50F,  9.0F, "Canada", "Cascadia"),
            //// new EarthquakeRecord( 4, 9, 1899, 00, 22, "LOCAL?",-140.00F,   60.00F,  8.2F, "Canada", "Yukon-Alaska"),
            //// new EarthquakeRecord(27,10, 2012, 20, 04, "LOCAL", ?F,   ?F,  7.7F, "Canada", "Haida Gwaii Islands"),

            new EarthquakeRecord( 8, 2, 1570, 09, 00, "LOCAL", -73.00F,  -36.80F,  8.3F, "Chile", "Concepción"),
            new EarthquakeRecord(16,12, 1575, 14, 30, "LOCAL", -73.20F,  -39.80F,  8.5F, "Chile", "Valdivia"),
            new EarthquakeRecord(24,11, 1604, 12, 30, "LOCAL", -70.40F,  -18.50F,  8.5F, "Chile", "Offshore Arica"),
            new EarthquakeRecord(16, 9, 1615, 23, 30, "LOCAL", -70.35F,  -18.50F,  8.8F, "Chile", "Offshore Arica"),
            new EarthquakeRecord(13, 5, 1647, 22, 30, "LOCAL", -72.00F,  -35.00F,  8.5F, "Chile", "Santiago"),
            new EarthquakeRecord(15, 3, 1657, 19, 30, "LOCAL", -73.03F,  -36.83F,  8.0F, "Chile", string.Empty),
            new EarthquakeRecord( 8, 7, 1730, 04, 45, "LOCAL", -71.63F,  -33.05F,  8.7F, "Chile", "Valparaíso"),
            new EarthquakeRecord(25, 5, 1751, 01, 00, "LOCAL", -73.03F,  -36.83F,  8.5F, "Chile", "Concepción"),
            new EarthquakeRecord(11, 4, 1819, 10, 00, "LOCAL", -70.35F,  -27.35F,  8.3F, "Chile", string.Empty),
            new EarthquakeRecord(19,11, 1822, 22, 30, "LOCAL", -71.63F,  -33.05F,  8.5F, "Chile", "Valparaíso"),
            new EarthquakeRecord(20, 2, 1835, 11, 30, "LOCAL", -73.03F,  -36.83F,  8.5F, "Chile", "Concepción"),
            new EarthquakeRecord( 7,11, 1837, 08, 00, "LOCAL", -73.20F,  -39.80F,  8.0F, "Chile", string.Empty),
            new EarthquakeRecord(16, 8, 1906, 19, 48, "LOCAL", -72.00F,  -33.00F,  8.2F, "Chile", "Valparaíso"),
            new EarthquakeRecord(29, 1, 1914, 23, 30, "LOCAL", -73.00F,  -35.00F,  8.2F, "Chile", string.Empty),
            new EarthquakeRecord( 4,12, 1918, 07, 47, "LOCAL", -71.00F,  -26.00F,  8.2F, "Chile", string.Empty),
            new EarthquakeRecord(10,11, 1922, 23, 53, "LOCAL", -70.00F,  -28.50F,  8.5F, "Chile", "Vallenar"),
            new EarthquakeRecord( 1,12, 1928, 00, 06, "LOCAL", -72.00F,  -35.00F,  8.3F, "Chile", "Talca"),
            new EarthquakeRecord(24,01, 1939, 23, 32, "LOCAL", -72.20F,  -36.20F,  8.3F, "Chile", "Chillán"),
            new EarthquakeRecord( 6, 4, 1943, 12, 07, "LOCAL", -72.00F,  -30.75F,  8.2F, "Chile", "Ovalle"),
            new EarthquakeRecord( 9,12, 1950, 17, 38, "LOCAL", -67.50F,  -23.50F,  8.3F, "Chile", string.Empty),
            new EarthquakeRecord(22, 5, 1960, 06, 32, "LOCAL", -73.00F,  -37.50F,  7.3F, "Chile", string.Empty),
            new EarthquakeRecord(22, 5, 1960, 15, 11, "LOCAL", -74.50F,  -39.50F,  8.3F, "Chile", "Valdivia, *Strongest earthquake in history*"),
            new EarthquakeRecord(19, 6, 1960, 22, 01, "LOCAL", -74.50F,  -39.50F,  7.3F, "Chile", string.Empty),
            new EarthquakeRecord( 3, 3, 1985, 19, 46, "LOCAL", -71.85F,  -33.24F,  7.8F, "Chile", "Santiago"),
            new EarthquakeRecord(30, 6, 1995, 01, 11, "LOCAL", -70.31F,  -23.36F,  8.0F, "Chile", "Antofagasta"),
            new EarthquakeRecord(27, 2, 2010, 03, 34, "LOCAL", -73.239F, -36.290F, 8.8F, "Chile", "Offshore Maule/Biobío"),
            new EarthquakeRecord(27, 2, 2010, 03, 34, "LOCAL", -72.733F, -35.909F, 8.8F, "Chile", "Offshore Maule/Biobío"),
            new EarthquakeRecord(13, 8, 1868, 16, 45, "LOCAL", -70.35F,  -18.50F,  8.5F, "Chile", "Arica (Peru)"),
            new EarthquakeRecord( 9, 5, 1877, 21, 16, "LOCAL", -70.23F,  -19.60F,  8.5F, "Chile", "Iquique"),
            new EarthquakeRecord(16, 4, 2013, 10, 44, "UTC",    62.08F,  -28.06F,  7.8F, "Iran", "Saravan, Sistan and Baluchestan")
        };
    }
}

           //// new EarthquakeRecord(25, 1, 1348, 13, 00, "UTC",  0F, 0F, 0F, "Italy", "Friuli")
