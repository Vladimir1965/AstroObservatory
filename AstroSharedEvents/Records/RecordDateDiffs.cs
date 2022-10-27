// <copyright file="RecordDateDiffs.cs" company="Traced-Ideas, Czech republic">
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
    /// Record Date Diffs.
    /// </summary>
    /// <seealso cref="AstroSharedEvents.Records.AbstractRecord" />
    public class RecordDateDiffs : AbstractRecord
    {

        public override void OutputRecord()
        {
            //// this.OutputSolarModelRecord();
            this.OutputNormalRecord();
        }

        public void OutputNormalRecord()
        {
            this.IsFinished = false;
            //// this.Text.AppendFormat("{0,9:F3}\t", Math.Round(this.LastDateDiff / this.TimeUnit, 3));
            //// this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));

            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;
            this.Text.AppendFormat(CultureInfo.CurrentCulture,
                        "\t{0,5:F0}\t{1,5:F0}\t{2,5:F0}\t{3,5:F0} ",
                                    Lj, Ls, Lu, Ln);

            //// var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            //// var Ej = SolarSystem.Singleton.Jupiter.E;
            //// this.Text.AppendFormat(CultureInfo.CurrentCulture, "\t{0,12:F8} ", Ej);
            //// this.Text.AppendFormat(CultureInfo.CurrentCulture, \t{0,6:F2}\t{1,12:F8} ", Lj, Ej);

            this.IsFinished = true;
        }

        /// <summary>
        /// Outputs the date diffs.
        /// </summary>
        public void OutputSolarModelRecord()
        {
            this.IsFinished = false;
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Lsp = SolarSystem.Singleton.Saturn.LP;
            /*
            var dJp = Angles.Mod360((Lj - Ljp)/2);
            */
            var dUN = Angles.Mod360((Ln - Lu));
            var dJS = Angles.Mod360((Ls - Lj));
            var dJp = Angles.Mod360((Lj - Ljp) / 2);
            var dSp = Angles.Mod360((Ls - Lsp) / 2);

            //// Main
            var sUN = -Angles.Cosin(dUN * 2) + 1;
            var sJS = -Angles.Cosin(dJS * 2) + 1;
            var sJp = -Angles.Cosin(dJp * 2) + 1;
            var sSp = -Angles.Cosin(dSp * 2) + 1;

            //// Auxiliary
            //// var sJS = Math.Abs(Angles.Sinus(dJS));
            //// var sJp = Math.Abs(Angles.Sinus(dJp));

            var total = sUN + sJS + sJp + sSp;

            //// if (Math.Abs(delta) < 20) {
            //// this.Text.AppendFormat("{0,9:F3}\t", Math.Round(this.LastDateDiff / this.TimeUnit, 3));
            //// this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            //// this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));

            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,6:F2}\t{1,5:F2}\t{2,5:F2}\t{3,5:F2}\t{4,5:F2} ",
                                    total, sUN,  sJS, sJp, sSp);
            this.IsFinished = true;
        }

        /// <summary>
        /// Outputs the date diffs.
        /// </summary>
        public void OutputSolarJSModelRecord()
        {
            this.IsFinished = false;
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            /*
            var dJS = Angles.Mod360((Ls - Lj));
            var dJp = Angles.Mod360((Lj - Ljp)/2);
            */
            var dJS = Angles.Mod360((Ls - Lj));
            var dJp = Angles.Mod360((Lj - Ljp) / 2);

            //// var sJS = Math.Abs(Angles.Sinus(dJS));
            //// var sJp = Math.Abs(Angles.Sinus(dJp));
            
            var sJS = -Angles.Cosin(dJS*2) + 1;
            var sJp = -Angles.Cosin(dJp*2) + 1;


            var total = sJS + sJp;

            //// if (Math.Abs(delta) < 20) {
            //// this.Text.AppendFormat("{0,9:F3}\t", Math.Round(this.LastDateDiff / this.TimeUnit, 3));
            //// this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            //// this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));


            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,6:F2}\t{1,5:F2}\t{2,5:F2} ", 
                                    total, sJS, sJp);
            this.IsFinished = true;
        }

        /// <summary>
        /// Outputs the date diffs.
        /// </summary>
        public void OutputSolarDescriptionRecord()
        {
            this.IsFinished = false;
            var Lj = SolarSystem.Singleton.Jupiter.Longitude;
            var Ls = SolarSystem.Singleton.Saturn.Longitude;
            var Lu = SolarSystem.Singleton.Uranus.Longitude;
            var Ln = SolarSystem.Singleton.Neptune.Longitude;

            var Ljp = SolarSystem.Singleton.Jupiter.LP;
            var Lsp = SolarSystem.Singleton.Saturn.LP;
            var Lup = SolarSystem.Singleton.Uranus.LP;
            var Lnp = SolarSystem.Singleton.Neptune.LP;

            var dJS = Angles.Mod360(Ls - Lj);
            var dUN = Angles.Mod360(Lu - Ln);
            var dJN = Angles.Mod360(Lj - Ln);
            var dSN = Angles.Mod360(Ls - Ln);
            var dJU = Angles.Mod360(Lj - Lu);
            var dSU = Angles.Mod360(Ls - Lu);
            var dJ = Angles.Mod360(Lj - Ljp);
            var dN = Angles.Mod360(Ln - Lnp);

            //// Extremy v kvadraturach
            var sJS = Math.Abs(Angles.Sinus(dJS));
            var sUN = Math.Abs(Angles.Sinus(dUN));
            var sJN = Math.Abs(Angles.Sinus(dJN));
            var sSN = Math.Abs(Angles.Sinus(dSN));
            var sJU = Math.Abs(Angles.Sinus(dJU));
            var sSU = Math.Abs(Angles.Sinus(dSU));

            //// Extremy v aphelech
            var cJ = -Angles.Cosin(dJ);
            var cN = -Angles.Cosin(dN);

            var aphel = cJ > 0.9;
            var quadra = sJS > 0.9;

            var total = Math.Max(sJS, cJ);
            /*if (total < 0.97) {
                return;
            }*/

            //// if (Math.Abs(delta) < 20) {
            //// this.Text.AppendFormat("{0,9:F3}\t", Math.Round(this.LastDateDiff / this.TimeUnit, 3));
            //// this.Text.AppendFormat("{0}\t", Julian.CalendarDate(this.JulianDate, false));
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "{0,7:F2}", Julian.Year(this.JulianDate));

            var low = Angles.Cosin(dUN) > 0.5 && Angles.Sinus(dUN) < 0.5;
            var free = sUN > 0.9;
            var dense = (sJS + sUN + sJN + sSN + sJU + sSU) < 4.0;
            var extra = Angles.Cosin(dUN) > 0.8 && Angles.Sinus(dUN) < 0.2;
            ////  sJS > 0.9; ////  sJN > 0.9 || sSN > 0.9 || sJU > 0.9 || sSU > 0.9;

            //// perihel Jupitera
            var strong = cJ < -0.5;

            var text = string.Empty;
            if (quadra) {
                if (strong) {
                    text += " strong quadra";
                } else {
                    text += " quadra";
                }
            }

            if (aphel) {
                text += " aphel";
                if (sJS > 0.9 && strong) {
                    text += " (strong quadra)";                    
                }
            }

            if (extra) {
                text += " extra";
            }

            if (dense) {
                text += " dense";
            }

            if (low) {
                text += " low";
            }

            if (free) {
                text += " free";
            }

            //// {0,6:F2} 
            this.Text.AppendFormat(
                CultureInfo.CurrentCulture,
                "  dJS={0,5:F0} dJ={1,5:F0}, dUN={2,5:F0}  {3}",
                dJS, dJ, dUN, text);

            /*
             this.Text.AppendFormat(
                CultureInfo.CurrentCulture,
                "  {0,6:F2} dJS={1,5:F0} dJ={2,5:F0}, dN={3,5:F0}, dUN={4,5:F0}   {5,5:F2}, {6,5:F2} {7,5:F2} {8,5:F2} {9}",
                total, dJS, dJ, dN, dUN, sJS, cJ, cN, sUN, text);
                
             * * 
            var d1 = Angles.Mod180(Lu - Lj);
            var d2 = Angles.Mod180(Lj - Ln);
            var d3 = Angles.Mod180(Ln - Ls);
            
            var d1 = Angles.Mod180(Ls - Lj);
            var d2 = Angles.Mod180(Lj - Lu);
            var d3 = Angles.Mod180(Lu - Ln);
            */
            /* Aphelia - Perihelia */
            /*
            var dJ = Angles.Mod360(Lj - Ljp + 180);
            var dS = Angles.Mod360(Ls - Lsp + 180);
            var dU = Angles.Mod360(Lu - Lup + 180);
            var dN = Angles.Mod360(Ln - Lnp + 180);

            var sJ = -Angles.Cosin(dJ);
            var sS = -Angles.Cosin(dS);
            var sU = -Angles.Cosin(dU);
            var sN = -Angles.Cosin(dN);
            var total = sJ + sS;

            var rtB = SolarSystem.Singleton.Barycentre.RT / 1000000000;

            this.Text.AppendFormat(CultureInfo.CurrentCulture, "  {0,6:F2} J={1,5:F2} S={2,5:F2}", total* rtB, sJ, sS);
            
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "  U={0,5:F2} N={1,5:F2}", sU, sN);
            this.Text.AppendFormat(CultureInfo.CurrentCulture, "  RT={0,5:F2} ", rtB);            
            */
            /*
            var dJS = Angles.Mod360(Lj - Ls);
            var dJN = Angles.Mod360(Lj - Ln);
            var dUS = Angles.Mod360(Lu - Ls);
            var dNS = Angles.Mod360(Ln - Ls);

            var sJS = Math.Abs(Angles.Sinus(dJS));
            var sJN = Math.Abs(Angles.Sinus(dJN));
            var sUS = Math.Abs(Angles.Sinus(dUS));
            var sNS = Math.Abs(Angles.Sinus(dNS));

            var total = sJS + sJN + sUS + sNS;

            this.Text.AppendFormat(CultureInfo.CurrentCulture, "  {0,6:F2} JS={1,5:F2} JN={2,5:F2} US={3,5:F2} NS={4,5:F2}", 
                                    total, sJS, sJN, sUS, sNS);
            */
            this.IsFinished = true;
        }
    }
}
