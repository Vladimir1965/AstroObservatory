// <copyright file="PhysicalMarsDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Physical Mars Details.
    /// </summary>
    public sealed class PhysicalMarsDetails
    {
        /// <summary>
        /// Gets or sets the DE.
        /// </summary>
        /// <value>The DE.</value>
        public double DE { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the DS.
        /// </summary>
        /// <value>The DS.</value>
        public double DS { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the w.
        /// </summary>
        /// <value>The w.</value>
        public double W { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the P.
        /// </summary>
        /// <value>The P.</value>
        public double P { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the X.
        /// </summary>
        /// <value>The X.</value>
        public double X { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the k.
        /// </summary>
        /// <value>The k.</value>
        public double K { get; set; }

        /// <summary>
        /// Gets or sets the q.
        /// </summary>
        /// <value>The q.</value>
        public double Q { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the d.
        /// </summary>
        /// <value>The d.</value>
        public double D { get; set; }
    }
}
