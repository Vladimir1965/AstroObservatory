// <copyright file="NodeObjectDetails.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedClasses.Records {
    using JetBrains.Annotations;

    /// <summary>
    /// Node Object Details.
    /// </summary>
    public sealed class NodeObjectDetails {
        /// <summary>
        /// Gets or sets the t.
        /// </summary>
        /// <value>The t.</value>
        public double t { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        public double Radius { [UsedImplicitly] get; set; }
    }
}
