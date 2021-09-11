// <copyright file="AstroMath.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Computation
{
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// Astro Math.
    /// </summary>
    public static class AstroMath {
        #region Fields and fields
        /// <summary>
        /// Constant HalfPI.
        /// </summary>
        [UsedImplicitly]
        public const double CHalfPI = 1.57079632684489662;

        /// <summary>
        /// Constant Pi.
        /// </summary>
        public const double ConstPi = 3.14159265358979324;

        /// <summary>
        /// Constant 2PI.
        /// </summary>
        public const double C2PI = 6.28318530717958648;


        /// <summary>
        /// Constant Angle 30 Degrees.
        /// </summary>
        public const double Angle30Deg = 30.0;

        /// <summary>
        /// Constant Angle 60 Degrees.
        /// </summary>
        public const double Angle60Deg = 60.0;

        /// <summary>
        /// Constant Angle 72 Degrees.
        /// </summary>
        public const double Angle72Deg = 72.0;

        /// <summary>
        /// Constant Angle 90 Degrees.
        /// </summary>
        public const double Angle90Deg = 90.0;

        /// <summary>
        /// Constant Angle 120 Degrees.
        /// </summary>
        public const double Angle120Deg = 120.0;

        /// <summary>
        /// Constant Angle 180 Degrees.
        /// </summary>
        public const double Angle180Deg = 180.0;

        /// <summary>
        /// Constant Angle 360 Degrees.
        /// </summary>
        public const double Angle360Deg = 360.0;

        /// <summary>
        /// Constant Near Zero.
        /// </summary>
        public const double Zero = 0.00001;
        //// const double INFINITY MAXDOUBLE

        /// <summary>
        /// Seconds In Day.
        /// </summary>
        [UsedImplicitly]
        public const int SecondsInDay = 86400;          //// seconds

        /// <summary>
        /// Days In Year.
        /// </summary>
        [UsedImplicitly]
        public const double DaysInYear = 3.652422e2;

        /// <summary>
        /// Solar Kappa.
        /// </summary>
        [UsedImplicitly]
        public const double SolarKappa = 1.326733e20;   //// kappa *M [m^3/s^2]

        /// <summary>
        /// Solar Kappa Sqrt.
        /// </summary>
        public const double SolarKappaSqrt = 5.75919e9; //// 1/2 * sqrt(kappa*M) [m^1.5/s 

        /// <summary>
        /// Kepler Constant.
        /// </summary>
        [UsedImplicitly]
        public const double Kkepler = 5.917e11;         //// T^2/a^3 (M+mi) [kg*s^2/m^3]

        /// <summary>
        /// Gauss Constant.
        /// </summary>
        [UsedImplicitly]
        public const double Kgauss = 1.720209895e-2;

        /// <summary>
        /// Gauss2 Constant.
        /// </summary>
        [UsedImplicitly]
        public const double Kgauss2 = 2.959122083e-4;

        /// <summary>
        /// Sun MassT.
        /// </summary>
        [UsedImplicitly]
        public const double SunMassT = 3.32948e5;        //// EARTH_MassE=1

        /// <summary>
        /// Sun Mass [kg].
        /// </summary>
        [UsedImplicitly]
        public const double SunMass = 1.9890e30;         //// 1.9889-1.9891 kg

        /// <summary>
        /// Constant Kappa.
        /// </summary>
        public const double Kappa = 6.670e-11;           //// [N/m^2/kg^2][m^3/s^2/kg] (6.672,6.6726) Nm^2kg^-2 = m3/s2kg

        /// <summary>
        /// Sun Radius.
        /// </summary>
        [UsedImplicitly]
        public const double SunRadius = 4.65234e-3;

        /// <summary>
        /// Astro Unit.
        /// </summary>
        public const double AstroUnit = 1.49597870e11;   //// [m] J.Q.Jacobs

        /// <summary>
        /// Represents the ratio of the circumference of a circle to its diameter, specified by the constant, ?.
        /// </summary>
        private const double PI = Math.PI;
        #endregion 

#region Public static methods
        /// <summary>
        /// Sum Poly Arr.
        /// </summary>
        /// <param name="arr">The given array.</param>
        /// <param name="quot">The given quotient.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double HornerSum(double[] arr, double quot) {
            double s = 0;
            var q = 1.0;
            var n = arr.GetLength(0);
            for (var i = 0; i < n; i++) {               
                s = s + (arr[i] * q);
                q = q * quot;
            }

            return s;
        }

        /// <summary>
        /// Fractional part of the given number.
        /// </summary>
        /// <param name="givenNumber">The number x.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double Frac(double givenNumber) {
            var y = givenNumber - Math.Floor(givenNumber);
            while (y < 0.0) {
                y += 1.0;
            }

            while (y >= 1) {
                y -= 1.0;
            }

            return y;
        }

        /// <summary>
        /// Mods the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="integerPart">The integer part.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static float Mod(float input, out float integerPart) {
            integerPart = (int)Math.Floor(input);
            var remainder = input - integerPart;
            return remainder;
        }

        /// <summary>
        /// Mods the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="integerPart">The integer part.</param>
        /// <returns> Returns value. </returns>
        public static double Mod(double input, out double integerPart) {
            var integerPart2 = (decimal)Math.Floor(input);
            var remainder = (decimal)input - integerPart2;
            integerPart = (double)integerPart2;
            return (double)remainder;
        }

        /// <summary>
        /// Range- insure 0 less or equal *v less then r.
        /// </summary>
        /// <param name="v">The value v.</param>
        /// <param name="r">The value r.</param>
        [UsedImplicitly]
        public static void Range(ref double v, double r) {
            v -= r * Math.Floor(v / r);
        }

        /// <summary>
        /// Cubic Root.
        /// </summary>
        /// <param name="givenNumber">The value x.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double CubicRoot(double givenNumber) {
            if (givenNumber > 0.0) {
                return Math.Exp(Math.Log(givenNumber) / 3.0);
            }

            if (givenNumber < 0.0) {
                return -CubicRoot(-givenNumber);
            }
            //// givenNumber==0
            return 0;
        }

        /// <summary>
        /// Function Equal.
        /// </summary>
        /// <param name="n1">The number n1.</param>
        /// <param name="n2">The number n2.</param>
        /// <param name="precision">The precision.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static bool Equal(double n1, double n2, double precision) {
            return Math.Abs(n1 - n2) < precision;
        }

        /// <summary>
        /// Evaluate Signum.
        /// </summary>
        /// <param name="givenNumber">The value givenNumber.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double Signum(double givenNumber) {
            return givenNumber / Math.Abs(givenNumber);
        }

        /// <summary>
        /// Function Round.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="precision">The precision.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double Round(double number, int precision) {
            double q;
            switch (precision) {
                case -1:
                    q = 1.0 / 10;
                    break;
                case 0:
                    q = 1;
                    break;
                case 1:
                    q = 10;
                    break;
                default:
                    q = Math.Pow(10, precision);
                    break;
            }

            var x = Math.Floor((number * q) + 0.5);
            return x / q;
        }

        /// <summary>
        /// Evaluates Mod N.
        /// </summary>
        /// <param name="givenNumber">The given number.</param>
        /// <param name="n">The number n.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double ModN(double givenNumber, double n) {
            var y = Math.Floor(givenNumber / n);
            y = givenNumber - (y * n);
            while (y < 0.0) {
                y += n;
            }

            while (y >= n) {
                y -= n;
            }

            return Math.Round(y, 3);
        }

        /// <summary>
        /// Converts from degrees to radians.
        /// </summary>
        /// <param name="degrees">The angle to convert.</param>
        /// <returns>The angle degrees in radians.</returns>
        [UsedImplicitly]
        public static double Deg2Rad(double degrees) {
            return degrees * (PI / 180d);
        }

        /// <summary>
        /// Converts from radians to degrees.
        /// </summary>
        /// <param name="radians">The angle to convert.</param>
        /// <returns>The angle radians in degrees.</returns>
        [UsedImplicitly]
        public static double Rad2Deg(double radians) {
            return radians * (180d / PI);
        }
#endregion
    }
}