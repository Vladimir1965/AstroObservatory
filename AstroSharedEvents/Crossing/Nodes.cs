// <copyright file="Nodes.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Crossing
{
    using System;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.OrbitalElements;
    using AstroSharedClasses.Records;
    using AstroSharedOrbits.Orbits;
    using JetBrains.Annotations;

    /// <summary>
    /// Passages through Nodes.
    /// </summary>
    [UsedImplicitly]
    public static class Nodes {
        /// <summary>
        /// Passages the through ascending node.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static NodeObjectDetails PassageThroughAscendingNode(EllipticalObjectElements elements) {
            var v = Angles.Mod360(-elements.W);
            v = Angles.DegRad(v);
            var eccentricE = Math.Atan(Math.Sqrt((1 - elements.E) / (1 + elements.E)) * Math.Tan(v / 2)) * 2;
            var anomalyM = eccentricE - elements.E * Math.Sin(eccentricE);
            anomalyM = Angles.RadDeg(anomalyM);
            var n = Orbit.MeanMotionFromSemiMajorAxis(elements.A);

            var details = new NodeObjectDetails {
                t = elements.T + anomalyM / n,
                Radius = elements.A * (1 - elements.E * Math.Cos(eccentricE))
            };

            return details;
        }

        /// <summary>
        /// Passages the through descending node.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static NodeObjectDetails PassageThroughDescendingNode(EllipticalObjectElements elements) {
            var v = Angles.Mod360(180 - elements.W);
            v = Angles.DegRad(v);
            var eccentricE = Math.Atan(Math.Sqrt((1 - elements.E) / (1 + elements.E)) * Math.Tan(v / 2)) * 2;
            var anomalyM = eccentricE - elements.E * Math.Sin(eccentricE);
            anomalyM = Angles.RadDeg(anomalyM);
            var n = Orbit.MeanMotionFromSemiMajorAxis(elements.A);

            var details = new NodeObjectDetails {
                t = elements.T + anomalyM / n,
                Radius = elements.A * (1 - elements.E * Math.Cos(eccentricE))
            };

            return details;
        }

        /// <summary>
        /// Passages the through ascending node.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static NodeObjectDetails PassageThroughAscendingNode(ParabolicObjectElements elements) {
            var v = Angles.Mod360(-elements.W);
            v = Angles.DegRad(v);
            var s = Math.Tan(v / 2);
            var s2 = s * s;

            var details = new NodeObjectDetails {
                t = elements.T + 27.403895 * (s2 * s + 3 * s) * elements.Q * Math.Sqrt(elements.Q),
                Radius = elements.Q * (1 + s2)
            };

            return details;
        }

        /// <summary>
        /// Passages through descending node.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static NodeObjectDetails PassageThroughDescendingNode(ParabolicObjectElements elements) {
            var v = Angles.Mod360(180 - elements.W);
            v = Angles.DegRad(v);

            var s = Math.Tan(v / 2);
            var s2 = s * s;

            var details = new NodeObjectDetails {
                t = elements.T + 27.403895 * (s2 * s + 3 * s) * elements.Q * Math.Sqrt(elements.Q),
                Radius = elements.Q * (1 + s2)
            };

            return details;
        }
    }
}
