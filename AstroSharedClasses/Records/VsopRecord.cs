// <copyright file="VsopRecord.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    /// <summary>
    /// Vsop Record.
    /// </summary>
    public sealed class VsopRecord {
        // public string this.Line;

        /// <summary>
        /// Gets or sets Elem Num.
        /// </summary>
        /// <value> Property description. </value>
        public int ElemNum { get; set; }

        /// <summary>
        /// Gets or sets K.
        /// </summary>
        /// <value> Property description. </value>
        public int K { get; set; }

        /// <summary>
        /// Gets or sets Count.
        /// </summary>
        /// <value> Property description. </value>
        public int Count { get; set; }  //// Headers

        /// <summary>
        /// Gets or sets Na.
        /// </summary>
        /// <value> Property description. </value>
        public double Na { get; set; }

        /// <summary>
        /// Gets or sets Nb.
        /// </summary>
        /// <value> Property description. </value>
        public double Nb { get; set; }

        /// <summary>
        /// Gets or sets Nc.
        /// </summary>
        /// <value> Property description. </value>
        public double Nc { get; set; }  //// Quotients
    }
}
