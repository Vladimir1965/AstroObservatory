// <copyright file="SpaceBody.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author> vl </author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

using JetBrains.Annotations;

namespace AstroSharedOrbits.Orbits
{
    /// <summary>
    /// Space Body.
    /// </summary>
    public class SpaceBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceBody"/> class.
        /// </summary>
        /// <param name="givenAbbreviation">The given abbreviation.</param>
        /// <param name="givenName">Name of the given.</param>
        public SpaceBody(string givenAbbreviation, string givenName)
        {
            //// initJ2000();
            this.Abbreviation = givenAbbreviation;
            this.Name = givenName;
        }

        /// <summary>
        /// Gets or sets Name of the body.
        /// </summary>
        /// <value> Property description. </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets Abbreviation of name.
        /// </summary>
        /// <value> Property description. </value>
        public string Abbreviation { get; }

        /// <summary>
        /// Gets or sets Mass [kg].
        /// </summary>
        /// <value> Property description. </value>
        public double Mass { get; set; }   //// 

        /// <summary>
        /// Gets or sets Radius [m].
        /// </summary>
        /// <value> Property description. </value>
        public double Radius { get; set; }   //// 

        /// <summary>
        /// Gets or sets Rotational axis inclination.
        /// </summary>
        /// <value> Property description. </value>
        public double J { get; set; }   //// 

        /// <summary>
        /// Mass, unit = earth mass.
        /// </summary>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public double MassTerrestrial()
        {
            return this.Mass / 5.9736e24;
        }
    }
}
