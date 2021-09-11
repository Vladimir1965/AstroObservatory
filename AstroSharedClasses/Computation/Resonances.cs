// <copyright file="Resonances.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation {
    using System;
    using System.Globalization;
    using System.Text;
    using JetBrains.Annotations;

    /// <summary> Resonances of periods. </summary>
    [UsedImplicitly]
    public sealed class Resonances {
        /// <summary>
        /// Limit number.
        /// </summary>
        private const int Limit = 5; ////9;
        //// public const double mRatio = 1.0/1.9;

        /// <summary>
        /// Test of resonance.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static string Test() {
            const double period = 1767.9295404377 * 7 / 8;
            double[] t = { 0.2408467, 0.6151973, 1.0000174, 1.8808480,
                            11.861983, 29.457159, 84.0204730, 164.770132 
                         };
            char[] b = { 'M', 'V', 'E', 'R', 'J', 'S', 'U', 'N' };
            //// new double[7]
            var s = new StringBuilder();
            for (var i = 0; i < 8; i++) {
                for (var j = i + 1; j < 8; j++) {
                    if (i == j) {
                        continue;
                    }

                    var ts = 1 / ((1 / t[i]) - (1 / t[j]));
                    s.AppendFormat("{0,2}-{1,2}", b[i], b[j]);
                    s.AppendFormat("{0,12:F3}, {1,12:F3}, \n", ts, period / ts);
                }
            }

            return s.ToString();
        }

        /// <summary>
        /// Resonant period.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="stable">If set to <c>true</c> [stable].</param>
        /// <param name="modFrom">The mod from.</param>
        /// <param name="modTo">The mod to.</param>
        /// <param name="period1">The period1.</param>
        /// <param name="period2">The period2.</param>
        /// <param name="period3">The period3.</param>
        /// <param name="period4">The period4.</param>
        /// <param name="result">The result.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static string Resonant(
                                int count,
                                bool stable,
                                double modFrom,
                                double modTo,
                                double period1,
                                double period2,
                                double period3,
                                double period4,
                                double result) {
            int i1;
            double vOd = 1.0 / modFrom, vDo = 1.0 / modTo;
            var s = new StringBuilder();

            for (i1 = 0; i1 <= Limit; i1++) {
                var v1 = i1 * 1.0 / period1;
                int i2;
                for (i2 = -Limit; i2 <= Limit; i2++) {
                    var v2 = v1 + (i2 * 1.0 / period2);
                    bool ok;
                    if (count == 2) {
                        ok = (Math.Abs(v2) > vDo) && (Math.Abs(v2) < vOd);
                        if (ok) {
                            s.AppendFormat("{0,3:F0}{1,3:F0}", i1, i2);
                            s.AppendFormat(CultureInfo.CurrentCulture, "{0,10:F1}\n", 1 / v2);
                        }

                        continue;
                    }

                    int i3;
                    double v3;
                    if (count == 3 && stable) {
                        i3 = -(i1 + i2);
                        v3 = v2 + (i3 * 1.0 / period3);
                        ok = (Math.Abs(v3) > vDo) && (Math.Abs(v3) < vOd);
                        if (ok) {
                            s.AppendFormat("{0,3:F0}{1,3:F0}{2,3:F0}", i1, i2, i3);
                            s.AppendFormat(CultureInfo.CurrentCulture, "{0,10:F1}\n", 1 / v3);
                        }

                        continue;
                    }

                    for (i3 = -Limit; i3 <= Limit; i3++) {
                        v3 = v2 + (i3 * 1.0 / period3);
                        if (count == 3) {
                            ok = (Math.Abs(v3) > vDo) && (Math.Abs(v3) < vOd);
                            if (ok) {
                                s.AppendFormat("{0,3:F0}{1,3:F0}{2,3:F0}", i1, i2, i3);
                                s.AppendFormat(CultureInfo.CurrentCulture, "{0,10:F1}\n", 1 / v3);
                            }

                            continue;
                        }

                        int i4;
                        double v4;
                        if (count == 4 && stable) {
                            i4 = -(i1 + i2 + i3);
                            v4 = v3 + (i4 * 1.0 / period4);
                            var x = v4 - 1.0 / result;
                            ok = (Math.Abs(x) > vDo) && (Math.Abs(x) < vOd);
                            if (!ok) {
                                continue;
                            }

                            s.AppendFormat(CultureInfo.InvariantCulture, "{0,3:F0}{1,3:F0}{2,3:F0}{3,3:F0}", i1, i2, i3, i4);
                            s.AppendFormat(CultureInfo.CurrentCulture, "{0,12:F1} {1,12:F1} \n", 1 / v4, 1 / x);
                        }
                        else {
                            for (i4 = -Limit; i4 <= Limit; i4++) {
                                v4 = v3 + (i4 * 1.0 / period4);

                                var x = v4 - 1.0 / result;
                                ok = (Math.Abs(x) > vDo) && (Math.Abs(x) < vOd);
                                if (!ok) {
                                    continue;
                                }

                                s.AppendFormat(CultureInfo.InvariantCulture, "{0,3:F0}{1,3:F0}{2,3:F0}{3,3:F0}", i1, i2, i3, i4);
                                s.AppendFormat(CultureInfo.CurrentCulture, "{0,12:F1} {1,12:F1} \n", 1 / v4, 1 / x);
                            } // for
                        } // stable
                    } // Count=4
                }
            }

            return s.ToString();
        }
    }
}

/* Integer Ratios - Test
void integerRatios(int Count, NormalArray *arr) {
for (double B=1.0; B<30; B=B+0.001) {         // inner
  double sumDif = 0;
  for (int i=0; i<Count; i++) {
    double p = (*arr)[i];    double r = B/p;
    double f = r-floor(r);
      if (f>0.5) f= 1-f;
      sumDif = sumDif+f;    // sqrt(f) // f*f
    }
    if ((sumDif<0.20)) { // (sumDif<0.3,1.6)
      print(out,"(dif=%6.4f) B=%7.3f (",sumDif,B);
      for (i=0; i<Count; i++) {
        double p = (*arr)[i];   double r = B/p;
        print(out,"%6.0f,",r);
      }
      print(out,")\n");
    }
}
}
  fclose(out);
  return;
}

// double v2 = v1 - (k+2*n)*1.0/t2 + n*1.0/t3+n*1.0/t4;
*/