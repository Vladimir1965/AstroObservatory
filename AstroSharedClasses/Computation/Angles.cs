// <copyright file="Angles.cs" company="Traced-Ideas, Czech republic">
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
    /// Angles library.
    /// </summary>
    public static class Angles {
        /// <summary>Degrees to Radians conversion factor.</summary>
        public const double Deg2Radian = Math.PI / 180.0;

        /// <summary>
        /// Radian to Degrees factor.
        /// </summary>
        public const double Radian2Deg = 180.0 / Math.PI;

        #region Conversions
        //// conversions among hours (of ra), degrees and radians. 

        /// <summary>
        /// Radian Degree.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double RadDeg(double alpha) {
            return alpha * AstroMath.Angle180Deg / AstroMath.ConstPi;
        }

        //// public static double RadiansToDegrees(double Radians) {
        ////     return Radians * 57.295779513082320876798154814105;
        //// } 

        /// <summary>
        /// Degree to Radian.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double DegRad(double alpha) {
            //// alpha * 0.017453292519943295769236907684886;
            return alpha * AstroMath.ConstPi / AstroMath.Angle180Deg;
        }

        /// <summary>
        /// Hour to Radian.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double HourRad(double alpha) {
            return DegRad(HourDeg(alpha));
        }

        /// <summary>
        /// Radianses to hours.
        /// </summary>
        /// <param name="radians">The radians.</param>
        /// <returns> Returns value. </returns>
        public static double RadiansToHours(double radians) {
            return radians * 3.8197186342054880584532103209403;
        }

        /// <summary>
        /// Hours to radians.
        /// </summary>
        /// <param name="hours">The hours.</param>
        /// <returns> Returns value. </returns>
        public static double HoursToRadians(double hours) {
            return hours * 0.26179938779914943653855361527329;
        }

        /// <summary>
        /// Hours to degrees.
        /// </summary>
        /// <param name="hours">The hours.</param>
        /// <returns> Returns value. </returns>
        public static double HoursToDegrees(double hours) {
            return hours * 15;
        }

        /// <summary>
        /// Degreeses to hours.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <returns> Returns value. </returns>
        public static double DegreesToHours(double degrees) {
            return degrees / 15;
        }

        /// <summary>
        /// PIs this instance.
        /// </summary>
        /// <returns> Returns value. </returns>
        public static double PI() {
            return 3.1415926535897932384626433832795;
        }

        /// <summary>
        /// Radian to Hour.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double RadHour(double alpha) {
            return DegHour(RadDeg(alpha));
        }

        /// <summary>
        /// Phase Degree.
        /// </summary>
        /// <param name="p">The value p.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double PhaseDeg(double p) {
            return p * 360.0;
        }
        #endregion

        #region Goniometric Functions
        /// <summary>
        /// Evaluate Sinus.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double Sinus(double alpha) {
            return Math.Sin(DegRad(alpha));
        }

        /// <summary>
        /// Evaluate Cosin.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double Cosin(double alpha) {
            return Math.Cos(DegRad(alpha));
        }

        /// <summary>
        /// Evaluate Tangs.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double Tangs(double alpha) {
            return Math.Tan(DegRad(alpha));
        }

        /// <summary>
        /// Evaluate Arc Sinus.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double ArcSinus(double alpha) {
            return RadDeg(Math.Asin(alpha));
        }

        /// <summary>
        /// Evaluate Arc Cosin.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double ArcCosin(double alpha) {
            return RadDeg(Math.Acos(alpha));
        }

        /// <summary>
        /// Evaluate Arc Tangs.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double ArcTangs(double alpha) {
            return RadDeg(Math.Atan(alpha));
        }

        /// <summary>
        /// Evaluate Arc Tan2.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <param name="beta">The value beta.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double ArcTan2(double alpha, double beta) {
            return RadDeg(Math.Atan2(alpha, beta));
        }
        #endregion

        #region Congruent Angles

        /// <summary>
        /// Evaluate Normal 360.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double Normal360(double alpha) {
            return alpha - (Math.Floor(alpha / AstroMath.Angle360Deg) * AstroMath.Angle360Deg);
        }

        /// <summary>
        /// Returns a TimeSpan from an input number of fractional days.  Same as TimeSpan.FromDays().
        /// </summary>
        /// <param name="alpha">Fractional days.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static TimeSpan Fraction2Time(double alpha) {
            //// obtain the fractional part of the input
            var i = alpha - Math.Floor(alpha);

            //// calculate hours, minutes and seconds
            var hour = (int)(i * 24);
            var minute = (int)(((i * 24) - hour) * 60);
            var second = (int)((((i * 24) - hour) * 60 - minute) * 60);
            var millisecond = (int)((((i * 24) - hour) * 60 - minute) * 60 - second) * 1000;

            //// create TimeSpan
            return new TimeSpan((int)Math.Floor(alpha), hour, minute, second, millisecond);
        }

        /// <summary>
        /// Normalizes the input angle to an equivalent positive angle between 0 and 360.
        /// </summary>
        /// <param name="theta">Input angle in degrees.</param>
        /// <returns>
        /// Normalized angle in degrees.
        /// </returns>
        /// <example>An input of -1677831 would return 129.</example>
        public static double Normal360B(double theta) {
            //// if ( theta >= 0 )
            ////     return Math.IEEERemainder(theta, 360.0);
            //// else
            ////     return 360.0 + Math.IEEERemainder(theta, 360.0);

            while (theta < 0.0 || theta > 360.0) {
                if (theta > 360.0) {
                    theta -= 360.0;
                }
                else {
                    if (theta < 0.0) {
                        theta += 360.0;
                    }
                    else {
                        break;
                    }
                }
            }

            return theta;
        }

        /// <summary>Normalizes the input angle to an equivalent angle between +180.0 and -180.0.</summary>
        /// <param name="theta">Input angle in degrees.</param>
        /// <returns>Normalized angle (double) in degrees.</returns>
        public static double Normal180B(double theta) {
            while (theta < -180.0 || theta > 180.0) {
                //// theta = Math.IEEERemainder(theta, 360.0);

                if (theta > 180.0) {
                    theta -= 180.0;
                }
                else if (theta < -180.0) {
                    theta += 180.0;
                }
                else {
                    break;
                }
            }

            return theta;
        }

        /// <summary>
        /// Normalizes the input value to a value between 0 and 1.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Value between 0 and 1 (double).
        /// </returns>
        public static double Normalize0To1(double value) {
            //// Examples: -0.65 => 0.35, -3.45 => 0.55, +1.25 => 0.25.
            while (value < 0 || value > 1) {
                if (value > 1) {
                    --value;
                }
                else {
                    ++value;
                }
            }

            return value;
        }

        /// <summary>
        /// Evaluate Cmod Angle.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <param name="angleDeg">The angle deg.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double CmodAngle(double alpha, double angleDeg) {
            var k = (long)(alpha / angleDeg);
            var y = alpha - (k * angleDeg);
            while (y < -angleDeg) {
                y += angleDeg;
            }

            while (y > angleDeg) {
                y -= angleDeg;
            }

            return y;
        }

        /// <summary>
        /// Evaluate Mod Angle.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <param name="angleDeg">The angle deg.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double ModAngle(double alpha, double angleDeg) {
            var k = (long)(alpha / angleDeg);
            var y = alpha - (k * angleDeg);
            while (y < 0.0) {
                y += angleDeg;
            }

            while (y > angleDeg) {
                y -= angleDeg;
            }

            return y;
        }

        /// <summary>
        /// Evaluate Mod 90.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double Mod90(double alpha) {
            return ModAngle(alpha, AstroMath.Angle90Deg);
        }

        /// <summary>
        /// Calculate Mod 120.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double Mod120(double alpha) {
            return ModAngle(alpha, AstroMath.Angle120Deg);
        }

        /// <summary>
        /// Calculate Mod 180.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double Mod180(double alpha) {
            return ModAngle(alpha, AstroMath.Angle180Deg);
        }

        /// <summary>
        /// Mod60s the specified alpha.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        public static double Mod60(double alpha) {
            return ModAngle(alpha, AstroMath.Angle60Deg);
        }

        public static double Mod60Sym(double alpha) {
            alpha = ModAngle(alpha, AstroMath.Angle60Deg);
            if (alpha > AstroMath.Angle30Deg) {
                alpha -= AstroMath.Angle60Deg;
            }

            if (alpha < -AstroMath.Angle30Deg) {
                alpha += AstroMath.Angle60Deg;
            }

            return alpha;
        }

        /// <summary>
        /// Corrects the angle.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <returns>Returns value.</returns>
        public static double CorrectAngle(double angle)
        {
            if (angle < -180) {
                angle = angle + 360;
            }

            if (angle < 0) {
                angle = angle + 180;
            }

            return angle;
        }

        /// <summary>
        /// Mod180s symmetric.
        /// </summary>
        /// <param name="alpha">The given alpha.</param>
        /// <returns> Returns value. </returns>
        public static double Mod180Sym(double alpha) {
            alpha = ModAngle(alpha, AstroMath.Angle180Deg);
            if (alpha > AstroMath.Angle90Deg) {
                alpha -= AstroMath.Angle180Deg;
            }

            if (alpha < -AstroMath.Angle90Deg) {
                alpha += AstroMath.Angle180Deg;
            }

            return alpha;
        }

        /// <summary>
        /// Calculate Mod 360.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double Mod360(double alpha) {
            return ModAngle(alpha, AstroMath.Angle360Deg);
        }

        /// <summary>
        /// Maps the to0 to24 range.
        /// </summary>
        /// <param name="hourAngle">The hour angle.</param>
        /// <returns> Returns value. </returns>
        public static double MapTo0To24Range(double hourAngle) {
            var value = hourAngle;

            //// map it to the range 0 - 24
            while (value < 0) {
                value += 24;
            }

            while (value > 24) {
                value -= 24;
            }

            return value;
        }

        /// <summary>
        /// Calculate Mod 360 symmetric.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double Mod360Sym(double alpha) {
            alpha = ModAngle(alpha, AstroMath.Angle360Deg);
            if (alpha > AstroMath.Angle180Deg) {
                alpha -= AstroMath.Angle360Deg;
            }

            return alpha;
        }

        /// <summary>
        /// Calculate Mod PI.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double ModPI(double alpha) {
            var y = Math.Floor(alpha / AstroMath.ConstPi);
            y = alpha - (y * AstroMath.ConstPi);
            while (y < 0.0) {
                y += AstroMath.ConstPi;
            }

            while (y >= AstroMath.ConstPi) {
                y -= AstroMath.ConstPi;
            }

            return y;
        }

        /// <summary>
        /// Calculate Mod 2Pi.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double Mod2Pi(double alpha) {
            var y = Math.Floor(alpha / AstroMath.C2PI);
            y = alpha - (y * AstroMath.C2PI);
            while (y < 0.0) {
                y += AstroMath.C2PI;
            }

            while (y >= AstroMath.C2PI) {
                y -= AstroMath.C2PI;
            }

            return y;
        }
        #endregion

        #region Equality Tests
        /// <summary>
        /// Calculate Equal Degrees.
        /// </summary>
        /// <param name="n1">The number n1.</param>
        /// <param name="n2">The number n2.</param>
        /// <param name="precision">The precision.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static bool EqualDeg(double n1, double n2, double precision) {
            var phi = Mod360(n1 - n2);   // Mod360(n1)-Mod360(n2);
            if (phi > AstroMath.Angle180Deg) {
                phi -= AstroMath.Angle360Deg;
            }

            if (phi < -AstroMath.Angle180Deg) {
                phi += AstroMath.Angle360Deg;
            }

            return Math.Abs(phi) < precision;
        }

        /// <summary>
        /// Calculate Equal Degrees 180.
        /// </summary>
        /// <param name="n1">The number n1.</param>
        /// <param name="n2">The number n2.</param>
        /// <param name="precision">The precision.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static bool EqualDeg180(double n1, double n2, double precision) {
            var phi = Mod180(n1 - n2);   // Mod180(n1)-Mod180(n2);
            if (phi > AstroMath.Angle90Deg) {
                phi -= AstroMath.Angle180Deg;
            }

            if (phi < -AstroMath.Angle90Deg) {
                phi += AstroMath.Angle180Deg;
            }

            return Math.Abs(phi) < precision;
        }

        /// <summary>
        /// Calculate Equal Rad.
        /// </summary>
        /// <param name="n1">The number n1.</param>
        /// <param name="n2">The number n2.</param>
        /// <param name="precision">The precision.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool EqualRad(double n1, double n2, double precision) {
            var phi = Mod2Pi(n1) - Mod2Pi(n2);
            if (phi > AstroMath.ConstPi) {
                phi -= AstroMath.C2PI;
            }

            if (phi < -AstroMath.ConstPi) {
                phi += AstroMath.C2PI;
            }

            return Math.Abs(phi) < precision;
        }
        #endregion

        #region Reduced Angles
        /// <summary>
        /// Sharp Angle.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double SharpAngle(double alpha) {
            while (alpha < -90) {
                alpha = alpha + AstroMath.Angle180Deg;
            }

            while (alpha > +90) {
                alpha = alpha - AstroMath.Angle180Deg;
            }

            return Math.Abs(alpha);
        }

        /// <summary>
        /// Normal Sharp Angle.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double NormalSharpAngle(double alpha) {
            while (alpha < 0) {
                alpha = alpha + AstroMath.Angle180Deg;
            }

            while (alpha > AstroMath.Angle180Deg) {
                alpha = alpha - AstroMath.Angle180Deg;
            }

            return alpha;
        }

        /// <summary>
        /// Reduced Angle.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double ReducedAngle(double alpha) {
            alpha = NormalSharpAngle(alpha);
            if (alpha > 90) {
                alpha = alpha - 90;
            }

            return alpha;
        }

        /// <summary>
        /// Normal symmetric Angle 360.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double NormalSymmetricAngle360(double alpha) {
            alpha = Mod360(alpha);
            if (alpha > 180) {
                return alpha - 360;
            }

            return alpha;
        }

        /// <summary>
        /// Absolutes the symmetric angle.
        /// </summary>
        /// <param name="alpha">The value A.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double AbsoluteSymmetricAngle(double alpha) {
            return Math.Abs(NormalSymmetricAngle360(alpha));
        }

        /// <summary>
        /// Symmetric Angle 360.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double SymmetricAngle360(double alpha) {
            alpha = Mod360(alpha);
            if (alpha > 360 - alpha) {
                return 360 - alpha;
            }

            return alpha;
        }

        /// <summary>
        /// Symmetric Angle 180.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double SymmetricAngle180(double alpha) {
            alpha = Mod180(alpha);
            if (alpha > 180 - alpha) {
                return 180 - alpha;
            }

            return alpha;
        }
        #endregion

        #region Axes
        /// <summary>
        /// Evaluate axis Of.
        /// </summary>
        /// <param name="angle1">The angle1.</param>
        /// <param name="angle2">The angle2.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double AxisOf(double angle1, double angle2) {
            var ax1 = (angle1 + angle2) / 2;
            return ax1;
        }

        /// <summary>
        /// Balanced Axis Of.
        /// </summary>
        /// <param name="angle1">The angle1.</param>
        /// <param name="m1">The mass m1.</param>
        /// <param name="angle2">The angle2.</param>
        /// <param name="m2">The mass m2.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        public static double BalancedAxisOf(double angle1, double m1, double angle2, double m2) {
            //// double Q1 = Math.Sqrt(M1);   double Q2 = Math.Sqrt(M2);
            //// double Q1 = Math.Log(M1);    double Q2 = Math.Log(M2);
            var q1 = m1; ////  Math.Pow(m1, 0.25);
            var q2 = m2; //// Math.Pow(m2, 0.25);
            var ax1 = ((angle1 * q1) + (angle2 * q2)) / (q1 + q2);
            return ax1;
        }

        #endregion

        #region AngularSeparation
        /// <summary>
        /// Separations the specified alpha1.
        /// </summary>
        /// <param name="alpha1">The alpha1.</param>
        /// <param name="delta1">The delta1.</param>
        /// <param name="alpha2">The alpha2.</param>
        /// <param name="delta2">The delta2.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double Separation(double alpha1, double delta1, double alpha2, double delta2) {
            delta1 = DegRad(delta1);
            delta2 = DegRad(delta2);

            alpha1 = HoursToRadians(alpha1);
            alpha2 = HoursToRadians(alpha2);

            var alpha = Math.Cos(delta1) * Math.Sin(delta2) - Math.Sin(delta1) * Math.Cos(delta2) * Math.Cos(alpha2 - alpha1);
            var y = Math.Cos(delta2) * Math.Sin(alpha2 - alpha1);
            var z = Math.Sin(delta1) * Math.Sin(delta2) + Math.Cos(delta1) * Math.Cos(delta2) * Math.Cos(alpha2 - alpha1);

            var value = Math.Atan2(Math.Sqrt(alpha * alpha + y * y), z);
            value = RadDeg(value);
            if (value < 0) {
                value += 180;
            }

            return value;
        }

        /// <summary>
        /// Positions the angle.
        /// </summary>
        /// <param name="alpha1">The alpha1.</param>
        /// <param name="delta1">The delta1.</param>
        /// <param name="alpha2">The alpha2.</param>
        /// <param name="delta2">The delta2.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double PositionAngle(double alpha1, double delta1, double alpha2, double delta2) {
            delta1 = DegRad(delta1);
            delta2 = DegRad(delta2);

            alpha1 = HoursToRadians(alpha1);
            alpha2 = HoursToRadians(alpha2);

            var deltaAlpha = alpha1 - alpha2;
            var value = Math.Atan2(
                                    Math.Sin(deltaAlpha),
                                    Math.Cos(delta2) * Math.Tan(delta1) - Math.Sin(delta2) * Math.Cos(deltaAlpha));
            value = RadDeg(value);
            if (value < 0) {
                value += 180;
            }

            return value;
        }

        /// <summary>
        /// Distances from great arc.
        /// </summary>
        /// <param name="alpha1">The alpha1.</param>
        /// <param name="delta1">The delta1.</param>
        /// <param name="alpha2">The alpha2.</param>
        /// <param name="delta2">The delta2.</param>
        /// <param name="alpha3">The alpha3.</param>
        /// <param name="delta3">The delta3.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double DistanceFromGreatArc(double alpha1, double delta1, double alpha2, double delta2, double alpha3, double delta3) {
            delta1 = DegRad(delta1);
            delta2 = DegRad(delta2);
            delta3 = DegRad(delta3);

            alpha1 = HoursToRadians(alpha1);
            alpha2 = HoursToRadians(alpha2);
            alpha3 = HoursToRadians(alpha3);

            var x1 = Math.Cos(delta1) * Math.Cos(alpha1);
            var x2 = Math.Cos(delta2) * Math.Cos(alpha2);

            var y1 = Math.Cos(delta1) * Math.Sin(alpha1);
            var y2 = Math.Cos(delta2) * Math.Sin(alpha2);

            var z1 = Math.Sin(delta1);
            var z2 = Math.Sin(delta2);

            var a = (y1 * z2) - (z1 * y2);
            var b = (z1 * x2) - (x1 * z2);
            var c = (x1 * y2) - (y1 * x2);

            var m = Math.Tan(alpha3);
            var n = Math.Tan(delta3) / Math.Cos(alpha3);

            var value = Math.Asin((a + b * m + c * n) / (Math.Sqrt(a * a + b * b + c * c) * Math.Sqrt(1 + m * m + n * n)));
            value = RadDeg(value);
            if (value < 0) {
                value = Math.Abs(value);
            }

            return value;
        }

        /// <summary>
        /// Smallests the circle.
        /// </summary>
        /// <param name="alpha1">The alpha1.</param>
        /// <param name="delta1">The delta1.</param>
        /// <param name="alpha2">The alpha2.</param>
        /// <param name="delta2">The delta2.</param>
        /// <param name="alpha3">The alpha3.</param>
        /// <param name="delta3">The delta3.</param>
        /// <param name="bType1">The b type1.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double SmallestCircle(double alpha1, double delta1, double alpha2, double delta2, double alpha3, double delta3, out bool bType1) {
            var d1 = Separation(alpha1, delta1, alpha2, delta2);
            var d2 = Separation(alpha1, delta1, alpha3, delta3);
            var d3 = Separation(alpha2, delta2, alpha3, delta3);

            var a = d1;
            var b = d2;
            var c = d3;
            if (b > a) {
                a = d2;
                b = d1;
                c = d3;
            }

            if (c > a) {
                a = d3;
                b = d1;
                c = d2;
            }

            double value;
            if (a > Math.Sqrt(b * b + c * c)) {
                bType1 = true;
                value = a;
            }
            else {
                bType1 = false;
                value = 2 * a * b * c / Math.Sqrt((a + b + c) * (a + b - c) * (b + c - a) * (a + c - b));
            }

            return value;
        }
        #endregion

        #region Private
        /// <summary>
        /// Hour to Degree.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double HourDeg(double alpha) {
            return alpha * 15.0;
        }

        /// <summary>
        /// Degree to Hour.
        /// </summary>
        /// <param name="alpha">The value alpha.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        private static double DegHour(double alpha) {
            return alpha / 15.0;
        }

        #endregion
    }
}
