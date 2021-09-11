// <copyright file="Vsop87.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.OrbitalElements {
    using AstroSharedClasses.Records;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Vsop 87 Method.
    /// </summary>
    public sealed class Vsop87 {
        /// <summary>
        /// Raw Vsop Data.
        /// </summary>
        private List<VsopRecord> rawData;

        /// <summary>
        /// Current Line Num.
        /// </summary>
        private int currentLineNum;
        
        /// <summary>
        /// Max Count.
        /// </summary>
        private int maxCount;
        
        /// <summary>
        /// Time record.
        /// </summary>
        private double[] time;

        #region Public Properties
        /// <summary>
        /// Gets the value A.
        /// </summary>
        /// <value> Property description. </value>
        public double A { get; private set; }

        /// <summary>
        /// Gets the value LM.
        /// </summary>
        /// <value> Property description. </value>
        public double LM { get; private set; }

        /// <summary>
        /// Gets the value K0.
        /// </summary>
        /// <value> Property description. </value>
        public double K0 { get; private set; }

        /// <summary>
        /// Gets the value H0.
        /// </summary>
        /// <value> Property description. </value>
        public double H0 { get; private set; }

        /// <summary>
        /// Gets the value Q0.
        /// </summary>
        /// <value> Property description. </value>
        public double Q0 { get; private set; }

        /// <summary>
        /// Gets the value P0. 
        /// </summary>
        /// <value> Property description. </value>
        public double P0 { get; private set; }
        #endregion

        #region Private Properties
        /// <summary>
        /// Gets or sets CurrentJulianDate.
        /// </summary>
        private double CurrentJulianDate { get; set; }

        /// <summary>
        /// Gets or sets File Name.
        /// </summary>
        private string FileName { get; set; }

        /// <summary>
        /// Gets or sets Precision.
        /// </summary>
        private double Precision { get; set; }

        /// <summary>
        /// Gets or sets Element Number.
        /// </summary>
        /// <value> Property description. </value>
        private int ElemNum { get; set; }

        /// <summary>
        /// Gets or sets Parameter K.
        /// </summary>
        /// <value> Property description. </value>
        private int K { get; set; }

        /// <summary>
        /// Gets or sets Count.
        /// </summary>
        /// <value> Property description. </value>
        private int Count { get; set; }

        /// <summary>
        /// Gets or sets Sumv.
        /// </summary>
        /// <value> Property description. </value>
        private double Sumv { get; set; }
        #endregion

        /// <summary>
        /// Init With.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="precision">The precision.</param>
        public void InitWith(string fileName, double precision) {
            this.Precision = precision;
            this.FileName = fileName;
            this.maxCount = 10000; // !!! 10000 limitation 100 or 20
            this.time = new double[6];
            this.time[0] = 1; 
            this.time[1] = 0; 
            this.time[2] = 0; 
            this.time[3] = 0; 
            this.time[4] = 0; 
            this.time[5] = 0;
            this.rawData = new List<VsopRecord>();
            try {
                //// TextReader sr
                using (var sr = new StreamReader(this.FileName)) {
                    string line; //// this.CurrentLineNum = 0;
                    while ((line = sr.ReadLine()) != null) {
                        this.AddRecord(line);
                    }
                }
            } catch (IOException e) {
                Console.WriteLine("The Vsop file could not be read:");
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }

        /// <summary>
        /// Compute all blocks.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        public void Compute(double givenJulianDay) {
            if (Computation.AstroMath.Equal(givenJulianDay, this.CurrentJulianDate, 1e-10)) {
                return;
            }

            this.CurrentJulianDate = givenJulianDay;
            this.ComputeTime(this.CurrentJulianDate);
            this.ElemNum = -1;
            this.currentLineNum = 0;
            while (this.ScanHeader()) {
                this.ComputeBlock();
            }

            switch (this.ElemNum) {
                case 1:
                    this.A = this.Sumv;
                    break;
                case 2:
                    this.LM = Computation.Angles.Mod2Pi(this.Sumv);
                    break;
                case 3:
                    this.K0 = this.Sumv;
                    break;
                case 4:
                    this.H0 = this.Sumv;
                    break;
                case 5:
                    this.Q0 = this.Sumv;
                    break;
                case 6:
                    this.P0 = this.Sumv;
                    break;
                //// Resharper default: break;
            }
        }

        /// <summary>
        /// Compute Time.
        /// </summary>
        /// <param name="givenJulianDay">The given julianDay.</param>
        private void ComputeTime(double givenJulianDay) {
            this.time[1] = (givenJulianDay - 2451545.0) / 365250;
            for (var i = 2; i < 6; i++) {
                this.time[i] = this.time[i - 1] * this.time[1];
            }
        }

        /// <summary>
        /// Scan Header.
        /// </summary>
        /// <returns> Returns value. </returns>
        private bool ScanHeader() { //// StreamReader
            this.K = -1; 
            this.Count = -1;
            if (this.currentLineNum >= this.rawData.Count) {
                return false;
            }

            var rec = this.rawData[this.currentLineNum++];
            //// string line = rec.this.Line;
            this.K = rec.K; 
            this.Count = rec.Count; 
            var newElemNum = rec.ElemNum;
            if (newElemNum != this.ElemNum) {
                switch (this.ElemNum) { 
                    case 1: 
                        this.A = this.Sumv; 
                        break;
                    case 2: 
                        this.LM = Computation.Angles.Mod2Pi(this.Sumv); 
                        break;
                    case 3: 
                        this.K0 = this.Sumv; 
                        break;
                    case 4: 
                        this.H0 = this.Sumv; 
                        break;
                    case 5: 
                        this.Q0 = this.Sumv; 
                        break;
                    case 6: 
                        this.P0 = this.Sumv; 
                        break;
                    //// Resharper default: break;
                }

                this.Sumv = 0;
            }

            if (this.Count == -1) {
                return false;
            }

            //// if (newElemNum != this.ElemNum) {
            this.ElemNum = newElemNum;
            //// }

            return true;
        }

        /// <summary>
        /// Compute Block.
        /// </summary>
        private void ComputeBlock() { //// StreamReader
            for (var i = 0; i < this.Count; i++) {
                if (i < this.maxCount)
                {
                    var rec = this.rawData[this.currentLineNum++];
                    if (!(Math.Abs(rec.Na) > this.Precision))
                    {
                        continue;
                    }

                    var v = this.time[this.K] * rec.Na * Math.Cos(rec.Nb + (rec.Nc * this.time[1]));
                    this.Sumv += v;
                }
                else {
                    this.currentLineNum++;
                }
            }
        }

        /// <summary>
        /// Add Record.
        /// </summary>
        /// <param name="line">The Vsop line.</param>
        private void AddRecord(string line) {
            var rec = new VsopRecord();
            //// rec._Line = line;
            var ctst = new char[2]; 
            line.CopyTo(0, ctst, 0, 2);
            var stst = new string(ctst);
            if (stst != " 0") {
                //// char[] cVersion = new char[1];    line.CopyTo(17,cVersion,0,1);
                //// char[] cBody = new char[7];       line.CopyTo(22,cBody,0,7);
                var celemNum = new char[2];
                line.CopyTo(41, celemNum, 0, 1);
                var selemNum = new string(celemNum);
                var cK = new char[2]; 
                line.CopyTo(59, cK, 0, 1);
                var sK = new string(cK);
                var ccount = new char[5]; 
                line.CopyTo(62, ccount, 0, 5);
                var scount = new string(ccount);
                rec.K = int.Parse(sK, CultureInfo.CurrentCulture.NumberFormat);
                rec.Count = int.Parse(scount, CultureInfo.CurrentCulture.NumberFormat);
                rec.ElemNum = int.Parse(selemNum, CultureInfo.CurrentCulture.NumberFormat);
            }
            else {
                ////  char[] cVar = new char[4]; line.CopyTo(7, cVar, 0, 4);
                var cA = new char[18]; 
                line.CopyTo(79, cA, 0, 18);
                var cB = new char[15]; 
                line.CopyTo(97, cB, 0, 15);
                var cC = new char[18]; 
                line.CopyTo(113, cC, 0, 18);
                var sA = new string(cA);
                var s = new StringBuilder(sA); 
                s.Replace(".", ",");
                sA = s.ToString();
                rec.Na = double.Parse(sA, CultureInfo.CurrentCulture.NumberFormat);
                var sB = new string(cB);
                s = new StringBuilder(sB); 
                s.Replace(".", ",");
                sB = s.ToString();
                rec.Nb = double.Parse(sB, CultureInfo.CurrentCulture.NumberFormat);
                var sC = new string(cC);
                s = new StringBuilder(sC); 
                s.Replace(".", ",");
                sC = s.ToString();
                rec.Nc = double.Parse(sC, CultureInfo.CurrentCulture.NumberFormat);
            }

            this.rawData.Add(rec); ////  this.RawData[this.CurrentLineNum++] = line;        
        }
    }
}
