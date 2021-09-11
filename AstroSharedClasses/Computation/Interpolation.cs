// <copyright file="Interpolation.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation
{
    using System;
    using System.Diagnostics;
    using JetBrains.Annotations;

    /// <summary>
    /// Arithmetic Interpolation.
    /// </summary>
    public static class Interpolation
    {
        /// <summary>
        /// Interpolates the specified n.
        /// </summary>
        /// <param name="n">The given n.</param>
        /// <param name="y1">The given y1.</param>
        /// <param name="y2">The given y2.</param>
        /// <param name="y3">The given y3.</param>
        /// <returns> Returns value. </returns>
        public static double Interpolate(double n, double y1, double y2, double y3)
        {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = y1 + y3 - 2 * y2;

            return y2 + n / 2 * (a + b + n * c);
        }

        /// <summary>
        /// Interpolates to halves.
        /// </summary>
        /// <param name="y1">The y1.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="y4">The y4.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double InterpolateToHalves(double y1, double y2, double y3, double y4)
        {
            return (9 * (y2 + y3) - y1 - y4) / 16;
        }

        /// <summary>
        /// Lagrange interpolate.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="n">The given n.</param>
        /// <param name="pX">The given p X.</param>
        /// <param name="pY">The given p Y.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double LagrangeInterpolate(double x, int n, double[] pX, double[] pY)
        {
            Debug.Assert(pX != null, "Reason of the assert");
            Debug.Assert(pY != null, "Reason of the assert");

            double v = 0;

            for (var i = 1; i <= n; i++) {
                double c = 1;
                for (var j = 1; j <= n; j++) {
                    if (j != i) {
                        c = c * (x - pX[j - 1]) / (pX[i - 1] - pX[j - 1]);
                    }
                }

                v += c * pY[i - 1];
            }

            return v;
        }

        /// <summary>
        /// Extrema the specified y1.
        /// </summary>
        /// <param name="y1">The given y1.</param>
        /// <param name="y2">The given y2.</param>
        /// <param name="y3">The y3.</param>
        /// <param name="nm">The given nm.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double Extreme(double y1, double y2, double y3, out double nm)
        {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = y1 + y3 - 2 * y2;

            var ab = a + b;

            nm = -ab / (2 * c);
            return y2 - ((ab * ab) / (8 * c));
        }

        /// <summary>
        /// Extrema the specified y1.
        /// </summary>
        /// <param name="y1">The given y1.</param>
        /// <param name="y2">The given y2.</param>
        /// <param name="y3">The given y3.</param>
        /// <param name="y4">The given y4.</param>
        /// <param name="y5">The given y5.</param>
        /// <param name="nm">The given nm.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Extreme(double y1, double y2, double y3, double y4, double y5, out double nm)
        {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = y4 - y3;
            var d = y5 - y4;
            var e = b - a;
            var f = c - b;
            var g = d - c;
            var h = f - e;
            var j = g - f;
            var k = j - h;

            var bRecalc = true;
            double nmprev = 0;
            nm = nmprev;
            while (bRecalc) {
                var nMprev2 = nmprev * nmprev;
                var nMprev3 = nMprev2 * nmprev;
                nm = (6 * b + 6 * c - h - j + 3 * nMprev2 * (h + j) + 2 * nMprev3 * k) / (k - 12 * f);

                bRecalc = Math.Abs(nm - nmprev) > 1E-12;
                if (bRecalc) {
                    nmprev = nm;
                }
            }

            return Interpolate(nm, y1, y2, y3, y4, y5);
        }

        /// <summary>
        /// Zeroes the specified y1.
        /// </summary>
        /// <param name="y1">The given y1.</param>
        /// <param name="y2">The given y2.</param>
        /// <param name="y3">The given y3.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Zero(double y1, double y2, double y3)
        {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = y1 + y3 - 2 * y2;

            var bRecalc = true;
            double n0prev = 0;
            var n0 = n0prev;
            while (bRecalc) {
                n0 = -2 * y2 / (a + b + c * n0prev);

                bRecalc = Math.Abs(n0 - n0prev) > 1E-12;
                if (bRecalc)
                {
                    n0prev = n0;
                }
            }

            return n0;
        }

        /// <summary>
        /// Zeroes the specified y1.
        /// </summary>
        /// <param name="y1">The given y1.</param>
        /// <param name="y2">The given y2.</param>
        /// <param name="y3">The given y3.</param>
        /// <param name="y4">The given y4.</param>
        /// <param name="y5">The given y5.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Zero(double y1, double y2, double y3, double y4, double y5)
        {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = y4 - y3;
            var d = y5 - y4;
            var e = b - a;
            var f = c - b;
            var g = d - c;
            var h = f - e;
            var j = g - f;
            var k = j - h;

            var bRecalculate = true;
            double n0prev = 0;
            var n0 = n0prev;
            while (bRecalculate) {
                var n0prev2 = n0prev * n0prev;
                var n0prev3 = n0prev2 * n0prev;
                var n0prev4 = n0prev3 * n0prev;

                n0 = (-24 * y3 + n0prev2 * (k - 12 * f) - 2 * n0prev3 * (h + j) - n0prev4 * k) / (2 * (6 * b + 6 * c - h - j));

                bRecalculate = Math.Abs(n0 - n0prev) > 1E-12;
                if (bRecalculate)
                {
                    n0prev = n0;
                }
            }

            return n0;
        }

        /// <summary>
        /// Zero2s the specified y1.
        /// </summary>
        /// <param name="y1">The given y1.</param>
        /// <param name="y2">The given y2.</param>
        /// <param name="y3">The given y3.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Zero2(double y1, double y2, double y3)
        {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = y1 + y3 - 2 * y2;

            var bRecalculate = true;
            double n0prev = 0;
            var n0 = n0prev;
            while (bRecalculate) {
                var deltan0 = -(2 * y2 + n0prev * (a + b + c * n0prev)) / (a + b + 2 * c * n0prev);
                n0 = n0prev + deltan0;

                bRecalculate = Math.Abs(deltan0) > 1E-12;
                if (bRecalculate) {
                    n0prev = n0;
                }
            }

            return n0;
        }

        /// <summary>
        /// Zero2s the specified y1.
        /// </summary>
        /// <param name="y1">The given y1.</param>
        /// <param name="y2">The given y2.</param>
        /// <param name="y3">The given y3.</param>
        /// <param name="y4">The given y4.</param>
        /// <param name="y5">The given y5.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Zero2(double y1, double y2, double y3, double y4, double y5)
        {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = y4 - y3;
            var d = y5 - y4;
            var e = b - a;
            var f = c - b;
            var g = d - c;
            var h = f - e;
            var j = g - f;
            var k = j - h;
            var m = k / 24;
            var n = (h + j) / 12;
            var p = f / 2 - m;
            var q = (b + c) / 2 - n;

            var bRecalculate = true;
            double n0prev = 0;
            var n0 = n0prev;
            while (bRecalculate) {
                var n0prev2 = n0prev * n0prev;
                var n0prev3 = n0prev2 * n0prev;
                var n0prev4 = n0prev3 * n0prev;

                var deltan0 = -(m * n0prev4 + n * n0prev3 + p * n0prev2 + q * n0prev + y3) / (4 * m * n0prev3 + 3 * n * n0prev2 + 2 * p * n0prev + q);
                n0 = n0prev + deltan0;

                bRecalculate = Math.Abs(deltan0) > 1E-12;
                if (bRecalculate) {
                    n0prev = n0;
                }
            }

            return n0;
        }

        #region Private static
        /// <summary>
        /// Interpolates the specified n.
        /// </summary>
        /// <param name="n">The given n.</param>
        /// <param name="y1">The given y1.</param>
        /// <param name="y2">The given y2.</param>
        /// <param name="y3">The given y3.</param>
        /// <param name="y4">The given y4.</param>
        /// <param name="y5">The given y5.</param>
        /// <returns> Returns value. </returns>
        private static double Interpolate(double n, double y1, double y2, double y3, double y4, double y5) {
            var a = y2 - y1;
            var b = y3 - y2;
            var c = y4 - y3;
            var d = y5 - y4;
            var e = b - a;
            var f = c - b;
            var g = d - c;
            var h = f - e;
            var j = g - f;
            var k = j - h;

            var n2 = n * n;
            var n3 = n2 * n;
            var n4 = n3 * n;

            return y3 + n * ((b + c) / 2 - (h + j) / 12) + n2 * (f / 2 - k / 24) + n3 * ((h + j) / 12) + n4 * (k / 24);
        }
        #endregion
    }
}
