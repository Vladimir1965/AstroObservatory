// <copyright file="RecordTidal.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Records
{
    using AstroSharedClasses.Calendars;
    using AstroSharedClasses.Computation;
    using AstroSharedOrbits.Systems;
    using System;
    using System.Globalization;

    /// <summary>
    /// Record Tidal.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordTidal : AbstractRecord
    {
        /// <summary>
        /// Outputs the tidal excell.
        /// </summary>
        public override void OutputRecord()
        {
            var M = SolarSystem.Singleton.Mercury;
            var V = SolarSystem.Singleton.Venus;
            var E = SolarSystem.Singleton.Earth;
            var J = SolarSystem.Singleton.Jupiter;

            this.Text.AppendFormat("{0,10:F4} ", Julian.Year(this.JulianDate));
            this.Text.Append("\t" + Julian.CalendarDate(this.JulianDate, false));

            this.Text.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tL \t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t",
                    M.Longitude,
                    V.Longitude,
                    E.Longitude,
                    J.Longitude);

            this.Text.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tR \t{0,15:F1}\t{1,15:F1}\t{2,15:F1}\t{3,15:F1}\t",
                    M.Point.RT,
                    V.Point.RT,
                    E.Point.RT,
                    J.Point.RT);

            var gM = M.Body.Mass / M.Point.RT / M.Point.RT / M.Point.RT * 1e12;
            var gV = V.Body.Mass / V.Point.RT / V.Point.RT / V.Point.RT * 1e12;
            var gE = E.Body.Mass / E.Point.RT / E.Point.RT / E.Point.RT * 1e12;
            var gJ = J.Body.Mass / J.Point.RT / J.Point.RT / J.Point.RT * 1e12;

            this.Text.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tM/R3 \t{0,12:F3}\t{1,12:F3}\t{2,12:F3}\t{3,12:F3}\t",
                    gM,
                    gV,
                    gE,
                    gJ);

            this.Text.AppendFormat(
                                    CultureInfo.InvariantCulture,
                                    "\tBary\t{0,5:F1}\t{1,5:F1}",
                                    Angles.Mod360(SolarSystem.Singleton.Barycentre.Longitude),
                                    SolarSystem.Singleton.Barycentre.RT);

            this.Text.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\tGravi\t{0,5:F1}\t{1,5:F1}",
                    Angles.Mod360(SolarSystem.Singleton.Gravicentre.Longitude),
                    SolarSystem.Singleton.Gravicentre.RT);

            this.Text.AppendFormat(
                CultureInfo.InvariantCulture,
                "\tIdx \t{0,6:F2} ",
                SolarSystem.Singleton.TotalAlignmentIndex);

            this.Text.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t\t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t",
                    M.AlignmentIndex,
                    V.AlignmentIndex,
                    E.AlignmentIndex,
                    J.AlignmentIndex);

            //// var angle1 = Angles.CorrectAngle(V.Longitude - J.Longitude); revert
            var angle1 = Angles.CorrectAngle(J.Longitude - V.Longitude);
            var y1 = gV + gJ * Angles.Cosin(2 * angle1);
            var x1 = gJ * Angles.Sinus(2 * angle1);
            var g1 = Math.Sqrt(x1 * x1 + y1 * y1);
            var delta1 = Angles.ArcSinus(x1 / g1) / 2;
            var dip1 = V.Longitude + delta1;
            this.Text.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "\t(1) \t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t{4,6:F2}\t{5,6:F2}\t",
                    angle1,
                    y1,
                    x1,
                    g1,
                    delta1,
                    dip1);

            //// var angle2 = Angles.CorrectAngle(dip1 - M.Longitude); revert
            var angle2 = Angles.CorrectAngle(M.Longitude - dip1);
            var y2 = g1 + gM * Angles.Cosin(2 * angle2);
            var x2 = gM * Angles.Sinus(2 * angle2);
            var g2 = Math.Sqrt(x2 * x2 + y2 * y2);
            var delta2 = Angles.ArcSinus(x2 / g2) / 2;
            var dip2 = dip1 + delta2;

            this.Text.AppendFormat(
                   CultureInfo.InvariantCulture,
                   "\t(2) \t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t{4,6:F2}\t{5,6:F2}\t",
                   angle2,
                   y2,
                   x2,
                   g2,
                   delta2,
                   dip2);

            //// var angle3 = Angles.CorrectAngle(dip2 - E.Longitude); revert
            var angle3 = Angles.CorrectAngle(E.Longitude - dip2);
            var y3 = g2 + gE * Angles.Cosin(2 * angle3);
            var x3 = gE * Angles.Sinus(2 * angle3);
            var g3 = Math.Sqrt(x3 * x3 + y3 * y3);
            var delta3 = Angles.ArcSinus(x3 / g3) / 2;
            var dip3 = dip2 + delta3;

            this.Text.AppendFormat(
                   CultureInfo.InvariantCulture,
                    "\t(3) \t{0,6:F2}\t{1,6:F2}\t{2,6:F2}\t{3,6:F2}\t{4,6:F2}\t{5,6:F2}\t",
                    angle3,
                    y3,
                    x3,
                    g3,
                    delta3,
                    dip3);

            this.IsFinished = true;
        }
    }
}
