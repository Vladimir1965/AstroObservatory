// <copyright file="DateListSolar.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Lists
{
    using JetBrains.Annotations;

    /// <summary>
    /// Solar extension of DateList.
    /// </summary>
    public partial class EventList
    {
        #region Solar extreme dates

        /// <summary>
        /// Solar Dates.
        /// </summary>
        [UsedImplicitly] public static readonly float[] SolarMaxDates =
        { 
            1615.50F,1626.00F,1639.50F,1649.00F,1660.00F,1675.00F,1685.00F,
            1693.00F,1705.50F,1718.20F,1727.50F,1738.70F,1750.30F,1761.50F,
            1769.70F,1778.40F,1788.10F,1805.20F,1816.40F,1829.90F,1837.20F,
            1848.10F,1860.10F,1870.60F,1883.90F,1894.10F,1907.00F,1917.60F,
            1928.40F,1937.40F,1947.50F,1957.90F,1968.90F,1979.90F,1989.60F,2000.3F
        };

        /// <summary>
        /// Solar Dates.
        /// </summary>
        [UsedImplicitly] public static readonly float[] SolarMinDates =
        { 
            1610.80F,1619.00F,1634.00F,1645.00F,1655.00F,1666.00F,1679.50F,
            1689.50F,1698.00F,1712.00F,1723.50F,1734.00F,1745.00F,1755.20F,
            1766.50F,1775.50F,1784.70F,1798.30F,1810.60F,1823.30F,1833.90F,
            1843.50F,1856.00F,1867.20F,1878.90F,1889.60F,1901.70F,1913.60F,
            1923.60F,1933.80F,1944.20F,1954.30F,1964.70F,1976.50F,1986.00F,1996.9F,2008.9F
        };
        #endregion

        #region Schove dates

        /// <summary>
        /// Solar Dates.
        /// </summary>
        [UsedImplicitly] public static readonly float[] SchoveMaxDates =
        { 
            -648.0F,-522.0F,-512.0F,-501.0F,-491.0F,-481.0F,-471.0F,-461.0F,
            -393.0F,-349.0F,-340.0F,-293.0F,-283.0F,-272.0F,-261.0F,-249.0F,
            -236.0F,-223.0F,-214.0F,-205.0F,-192.0F,-182.0F,-172.0F,-163.0F,
            -149.0F,-135.0F,-125.0F,-113.0F,-104.0F, -91.0F, -82.0F, -72.0F,
            -62.0F, -53.0F, -42.0F, -27.0F, -16.0F,  -5.0F,   8.0F,  20.0F,
            31.0F,  42.0F,  53.0F,  65.0F,  76.0F,  86.0F,  96.0F, 105.0F,
            118.0F, 130.0F, 141.0F, 152.0F, 163.0F, 175.0F, 186.0F, 196.0F,
            208.0F, 219.0F, 230.0F, 240.0F, 252.0F, 265.0F, 277.0F,
            290.0F, 302.0F, 311.0F, 321.0F, 330.0F, 342.0F, 354.0F, 362.0F,
            372.0F, 387.0F, 396.0F, 410.0F, 421.0F, 430.0F, 441.0F, 452.0F,
            465.0F, 479.0F, 490.0F, 501.0F, 511.0F, 522.0F, 531.0F, 542.0F,
            557.0F, 567.0F, 578.0F, 585.0F, 597.0F, 607.0F, 618.0F, 628.0F,
            642.0F, 654.0F, 665.0F, 677.0F, 689.0F, 699.0F, 714.0F, 724.0F,
            735.0F, 745.0F, 754.0F, 765.0F, 776.0F, 787.0F, 798.0F, 809.0F,
            821.0F, 829.0F, 840.0F, 850.0F, 862.0F, 872.0F, 887.0F, 898.0F,
            907.0F, 917.0F, 926.0F, 938.0F, 950.0F, 963.0F, 974.0F, 986.0F,
            994.0F,1003.0F,1016.0F,1027.0F,1038.0F,1052.0F,1067.0F,1078.0F,
            1088.0F,1098.0F,1110.0F,1118.0F,1129.0F,1138.0F,1151.0F,1160.0F,
            1173.0F,1185.0F,1193.0F,1202.0F,1219.0F,1228.0F,1239.0F,1249.0F,
            1259.0F,1276.0F,1288.0F,1296.0F,1308.0F,1316.0F,1324.0F,1337.0F,
            1353.0F,1362.0F,1372.0F,1382.0F,1391.0F,1402.0F,1413.0F,1429.0F,
            1439.0F,1449.0F,1461.0F,1472.0F,1480.0F,1492.0F,1505.0F,1519.0F,
            1528.0F,1539.0F,1548.0F,1558.0F,1572.0F,1581.0F,1591.0F,1604.5F,
            1615.5F,1626.0F,1639.5F,1649.0F,1660.0F,1675.0F,1685.0F,1693.0F,
            1708.5F,1718.2F,1727.5F,1738.7F,1750.3F,1761.5F,1769.7F,1778.4F,
            1788.1F,1805.2F,1816.4F,1829.9F,1837.2F,1848.1F,1860.1F,1870.6F,
            1883.9F,1894.1F,1907.0F,1917.6F,1928.4F,1937.4F,1947.5F,1957.9F,
            1968.90F,1979.90F,1989.60F,2000.3F  //// 1958.5F, 1972.5F,1984.5F,1994.5F,2004.5F,2014.5F,2025.5
        };

        /// <summary>
        /// Solar Dates.
        /// </summary>
        [UsedImplicitly]
        public static readonly float[] SchoveMinDates =
        {
            -653.0F,-527.0F,-516.0F,-505.0F,-496.0F,-486.0F,-474.0F,-465.0F,
            -397.0F,-386.0F,-375.0F,-365.0F,-354.0F,-344.0F,-332.0F,-298.0F,
            -288.0F,-277.0F,-266.0F,-254.0F,-243.0F,-230.0F,-219.0F,-210.0F,
            -199.0F,-187.0F,-177.0F,-167.0F,-154.0F,-141.0F,-129.0F,-119.0F,
            -108.0F, -96.0F, -86.0F, -77.0F, -69.0F, -58.0F, -46.0F, -32.0F,
            -21.0F, -11.0F,   3.0F,  15.0F,  26.0F,  37.0F,  47.0F,  60.0F,
            70.0F,  80.0F,  91.0F, 101.0F, 112.0F, 124.0F, 135.0F, 146.0F,
            157.0F, 170.0F, 182.0F, 192.0F, 203.0F, 214.0F, 225.0F, 235.0F,
            247.0F, 260.0F, 272.0F, 284.0F, 296.0F, 307.0F, 317.0F, 326.0F,
            336.0F, 348.0F, 358.0F, 368.0F, 380.0F, 391.0F, 404.0F, 416.0F,
            426.0F, 437.0F, 448.0F, 459.0F, 472.0F, 484.0F, 495.0F, 507.0F,
            517.0F, 526.0F, 538.0F, 551.0F, 562.0F, 573.0F, 582.0F, 592.0F,
            602.0F, 613.0F, 623.0F, 637.0F, 649.0F, 660.0F, 671.0F, 684.0F,
            693.0F, 707.0F, 719.0F, 730.0F, 739.0F, 749.0F, 761.0F, 770.0F,
            782.0F, 793.0F, 804.0F, 815.0F, 825.0F, 836.0F, 846.0F, 856.0F,
            868.0F, 882.0F, 893.0F, 902.0F, 912.0F, 921.0F, 934.0F, 945.0F,
            959.0F, 970.0F, 982.0F, 990.0F, 998.0F,1010.0F,1022.0F,1034.0F,
            1047.0F,1060.0F,1071.0F,1082.0F,1092.0F,1106.0F,1115.0F,1124.0F,
            1134.0F,1145.0F,1155.0F,1167.0F,1180.0F,1190.0F,1199.0F,1212.0F,
            1224.0F,1233.0F,1244.0F,1256.0F,1269.0F,1282.0F,1291.0F,1301.0F,
            1311.0F,1319.0F,1332.0F,1346.0F,1358.0F,1368.0F,1378.0F,1386.0F,
            1396.0F,1407.0F,1421.0F,1434.0F,1443.0F,1457.0F,1468.0F,1476.0F,
            1488.0F,1498.0F,1512.0F,1525.0F,1535.0F,1543.0F,1553.0F,1567.0F,
            1578.0F,1587.0F,1599.5F,1610.8F,1619.0F,1634.0F,1645.0F,1655.0F,
            1666.0F,1679.5F,1689.5F,1698.0F,1712.0F,1723.5F,1734.0F,1745.0F,
            1755.2F,1766.5F,1775.5F,1784.7F,1798.3F,1810.6F,1823.3F,1833.9F,
            1843.5F,1856.0F,1867.2F,1878.9F,1889.6F,1901.7F,1913.6F,1923.6F,
            1933.8F,1944.2F,1954.5F,
            1964.70F,1976.50F,1986.00F,1996.9F,2008.9F
        }; //// 1966.5F,1978.5F,1989.5F,2000.5F,2009.5

        /// <summary>
        /// The schove maximum dates0
        /// </summary>
        [UsedImplicitly]
        public static readonly float[] SchoveMaxDates0 =
{
            8.0F,  20.0F,
            31.0F,  42.0F,  53.0F,  65.0F,  76.0F,  86.0F,  96.0F, 105.0F,
            118.0F, 130.0F, 141.0F, 152.0F, 163.0F, 175.0F, 186.0F, 196.0F,
            208.0F, 219.0F, 230.0F, 240.0F, 252.0F, 265.0F, 277.0F,
            290.0F, 302.0F, 311.0F, 321.0F, 330.0F, 342.0F, 354.0F, 362.0F,
            372.0F, 387.0F, 396.0F, 410.0F, 421.0F, 430.0F, 441.0F, 452.0F,
            465.0F, 479.0F, 490.0F, 501.0F, 511.0F, 522.0F, 531.0F, 542.0F,
            557.0F, 567.0F, 578.0F, 585.0F, 597.0F, 607.0F, 618.0F, 628.0F,
            642.0F, 654.0F, 665.0F, 677.0F, 689.0F, 699.0F, 714.0F, 724.0F,
            735.0F, 745.0F, 754.0F, 765.0F, 776.0F, 787.0F, 798.0F, 809.0F,
            821.0F, 829.0F, 840.0F, 850.0F, 862.0F, 872.0F, 887.0F, 898.0F,
            907.0F, 917.0F, 926.0F, 938.0F, 950.0F, 963.0F, 974.0F, 986.0F,
            994.0F,1003.0F,1016.0F,1027.0F,1038.0F,1052.0F,1067.0F,1078.0F,
            1088.0F,1098.0F,1110.0F,1118.0F,1129.0F,1138.0F,1151.0F,1160.0F,
            1173.0F,1185.0F,1193.0F,1202.0F,1219.0F,1228.0F,1239.0F,1249.0F,
            1259.0F,1276.0F,1288.0F,1296.0F,1308.0F,1316.0F,1324.0F,1337.0F,
            1353.0F,1362.0F,1372.0F,1382.0F,1391.0F,1402.0F,1413.0F,1429.0F,
            1439.0F,1449.0F,1461.0F,1472.0F,1480.0F,1492.0F,1505.0F,1519.0F,
            1528.0F,1539.0F,1548.0F,1558.0F,1572.0F,1581.0F,1591.0F,1604.5F,
            1615.5F,1626.0F,1639.5F,1649.0F,1660.0F,1675.0F,1685.0F,1693.0F,
            1708.5F,1718.2F,1727.5F,1738.7F,1750.3F,1761.5F,1769.7F,1778.4F,
            1788.1F,1805.2F,1816.4F,1829.9F,1837.2F,1848.1F,1860.1F,1870.6F,
            1883.9F,1894.1F,1907.0F,1917.6F,1928.4F,1937.4F,1947.5F,1958.5F,
            1968.90F,1979.90F,1989.60F,2000.3F  //// 1972.5F,1984.5F,1994.5F,2004.5F,2014.5F,2025.5
        };

        /// <summary>
        /// Solar Dates.
        /// </summary>
        [UsedImplicitly] public static readonly float[] SchoveMinDates0 =
        { 
             3.0F,  15.0F,  26.0F,  37.0F,  47.0F,  60.0F,
            70.0F,  80.0F,  91.0F, 101.0F, 112.0F, 124.0F, 135.0F, 146.0F,
            157.0F, 170.0F, 182.0F, 192.0F, 203.0F, 214.0F, 225.0F, 235.0F,
            247.0F, 260.0F, 272.0F, 284.0F, 296.0F, 307.0F, 317.0F, 326.0F,
            336.0F, 348.0F, 358.0F, 368.0F, 380.0F, 391.0F, 404.0F, 416.0F,
            426.0F, 437.0F, 448.0F, 459.0F, 472.0F, 484.0F, 495.0F, 507.0F,
            517.0F, 526.0F, 538.0F, 551.0F, 562.0F, 573.0F, 582.0F, 592.0F,
            602.0F, 613.0F, 623.0F, 637.0F, 649.0F, 660.0F, 671.0F, 684.0F,
            693.0F, 707.0F, 719.0F, 730.0F, 739.0F, 749.0F, 761.0F, 770.0F,
            782.0F, 793.0F, 804.0F, 815.0F, 825.0F, 836.0F, 846.0F, 856.0F,
            868.0F, 882.0F, 893.0F, 902.0F, 912.0F, 921.0F, 934.0F, 945.0F,
            959.0F, 970.0F, 982.0F, 990.0F, 998.0F,1010.0F,1022.0F,1034.0F,
            1047.0F,1060.0F,1071.0F,1082.0F,1092.0F,1106.0F,1115.0F,1124.0F,
            1134.0F,1145.0F,1155.0F,1167.0F,1180.0F,1190.0F,1199.0F,1212.0F,
            1224.0F,1233.0F,1244.0F,1256.0F,1269.0F,1282.0F,1291.0F,1301.0F,
            1311.0F,1319.0F,1332.0F,1346.0F,1358.0F,1368.0F,1378.0F,1386.0F,
            1396.0F,1407.0F,1421.0F,1434.0F,1443.0F,1457.0F,1468.0F,1476.0F,
            1488.0F,1498.0F,1512.0F,1525.0F,1535.0F,1543.0F,1553.0F,1567.0F,
            1578.0F,1587.0F,1599.5F,1610.8F,1619.0F,1634.0F,1645.0F,1655.0F,
            1666.0F,1679.5F,1689.5F,1698.0F,1712.0F,1723.5F,1734.0F,1745.0F,
            1755.2F,1766.5F,1775.5F,1784.7F,1798.3F,1810.6F,1823.3F,1833.9F,
            1843.5F,1856.0F,1867.2F,1878.9F,1889.6F,1901.7F,1913.6F,1923.6F,
            1933.8F,1944.2F,1954.5F,
            1964.70F,1976.50F,1986.00F,1996.9F,2008.9F 
        }; //// 1966.5F,1978.5F,1989.5F,2000.5F,2009.5
        #endregion

        #region Flare dates (Vitinskij)

        /// <summary>
        /// Solar Dates.
        /// </summary>
        [UsedImplicitly] 
        public static readonly float[] SolarFlareDates =
        { 
            //// CYCLE 3
            1778.042F,1778.375F,1781.042F,1781.375F,
            //// CYCLE 14
            1902.208F,1902.79F,1903.875F,1904.625F,1905.125F,1905.875F,
            1906.542F,1907.125F,1907.708F,1908.625F,1909.208F,1909.958F,
            1910.792F,1911.292F,1912.708F,1912.958F,
            //// CYCLE 15
            1914.292F,1915.458F,1916.375F,1917.625F,1917.958F,1918.542F,
            1919.458F,1920.208F,1920.792F,1921.542F,1922.208F,
            //// CYCLE 16
            1923.708F,1924.542F,1925.792F,1925.958F,1926.458F,1927.125F,
            1927.292F,1928.542F,1928.708F,1929.958F,1931.125F,1932.458F,
            1933.125F,
            //// CYCLE 17
            1934.375F, 1937.042F,1937.542F,1938.542F,1939.375F,1939.708F,
            1940.625F, 1941.542F,1942.292F,
            //// CYCLE 18
            1947.375F,1947.625F,1948.292F,1949.125F,1951.375F,1953.625F,
            //// CYCLE 19
            1957.792F,1957.958F,1959.042F,1959.542F,1960.625F,1961.458F,
            1962.708F,1963.375F,1963.708F  
        };
        #endregion
    }
}
