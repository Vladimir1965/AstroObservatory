// <copyright file="PlanetaryPhenomena.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Crossing
{
    using System;
    using System.Diagnostics;
    using AstroSharedClasses.Computation;
    using AstroSharedClasses.Enums;
    using AstroSharedOrbits.OrbitalData;
    using AstroSharedOrbits.Planets;
    using JetBrains.Annotations;

    /// <summary>
    /// Planetary Phenomena.
    /// </summary>
    [UsedImplicitly]
    public static class PlanetaryPhenomena {
        /// <summary>
        /// Ks the specified year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="obj">The object.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double K(double year, SolarSystemObject obj, EventType type) {
            int coefficient; //// = -1;
            if (obj >= SolarSystemObject.Mars) {
                Debug.Assert(type == EventType.Opposition || type == EventType.Conjunction, "Reason for the assert");

                coefficient = type == EventType.Opposition ? (int)obj * 2 : (int)obj * 2 + 1;
            }
            else {
                Debug.Assert(type == EventType.InferiorConjunction || type == EventType.SuperiorConjunction, "Reason for the assert");

                coefficient = type == EventType.InferiorConjunction ? (int)obj * 2 : (int)obj * 2 + 1;
            }

            var k = (365.2425 * year + 1721060 - PlanetaryPhenomenaQuotients.PlanetaryPhenomenaCoefficient1[coefficient].A) / PlanetaryPhenomenaQuotients.PlanetaryPhenomenaCoefficient1[coefficient].B;
            return Math.Floor(k + 0.5);
        }

        /// <summary>
        /// Trues the specified k.
        /// </summary>
        /// <param name="givenK">The given K.</param>
        /// <param name="obj">The object.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static double True(double givenK, SolarSystemObject obj, EventType type) {
            var julianDayE0 = type == EventType.WesternElongation || type == EventType.EasternElongation || type == EventType.Station1 || type == EventType.Station2 ? Mean(givenK, obj, obj >= SolarSystemObject.Mars ? EventType.Opposition : EventType.InferiorConjunction) : Mean(givenK, obj, type);

            int coefficient; //// = -1;
            if (obj >= SolarSystemObject.Mars) {
                Debug.Assert(type == EventType.Opposition || type == EventType.Conjunction || type == EventType.Station1 || type == EventType.Station2, "Reason for the assert");

                coefficient = type == EventType.Opposition || type == EventType.Station1 || type == EventType.Station2 ? (int)obj * 2 : (int)obj * 2 + 1;
            }
            else {
                Debug.Assert(
                            type == EventType.InferiorConjunction || type == EventType.SuperiorConjunction || type == EventType.EasternElongation ||
                            type == EventType.WesternElongation || type == EventType.Station1 || type == EventType.Station2,
                            "Reason for the assert");

                coefficient = type == EventType.InferiorConjunction || type == EventType.EasternElongation || type == EventType.WesternElongation || type == EventType.Station1 || type == EventType.Station2 ? (int)obj * 2 : (int)obj * 2 + 1;
            }

            var anomalyM = Angles.Mod360(PlanetaryPhenomenaQuotients.PlanetaryPhenomenaCoefficient1[coefficient].M0 + PlanetaryPhenomenaQuotients.PlanetaryPhenomenaCoefficient1[coefficient].M1 * givenK);
            anomalyM = Angles.DegRad(anomalyM);   //// convert anomalyM to radians

            var julianCentury = (julianDayE0 - 2451545) / 36525;
            var timeT2 = julianCentury * julianCentury;

            double delta;
            switch (obj) {
                case SolarSystemObject.Mercury:
                    delta = BodyMercury.PlanetaryPhenomenaDelta(type, anomalyM, julianCentury, timeT2);
                    break;
                case SolarSystemObject.Venus:
                    delta = BodyVenus.PlanetaryPhenomenaDelta(type, anomalyM, julianCentury, timeT2);
                    break;
                case SolarSystemObject.Mars:
                    delta = BodyMars.PlanetaryPhenomenaDelta(type, anomalyM, julianCentury, timeT2);
                    break;
                case SolarSystemObject.Jupiter:
                    delta = BodyJupiter.PlanetaryPhenomenaDelta(type, anomalyM, julianCentury, timeT2);
                    break;
                case SolarSystemObject.Saturn:
                    delta = BodySaturn.PlanetaryPhenomenaDelta(type, anomalyM, julianCentury, timeT2);
                    break;
                case SolarSystemObject.Uranus:
                    delta = BodyUranus.PlanetaryPhenomenaDelta(type, anomalyM, julianCentury, timeT2);
                    break;
                default:
                    delta = BodyNeptune.PlanetaryPhenomenaDelta(type, anomalyM, julianCentury, timeT2);
                    break;
            }

            return julianDayE0 + delta;
        }

        /// <summary>
        /// Elongations the value.
        /// </summary>
        /// <param name="givenK">The given k.</param>
        /// <param name="obj">The given obj.</param>
        /// <param name="bEastern">The b eastern.</param>
        /// <returns> Returns value. </returns>
        [UsedImplicitly]
        public static double ElongationValue(double givenK, SolarSystemObject obj, bool bEastern) {
            var julianDayE0 = Mean(givenK, obj, EventType.InferiorConjunction);

            Debug.Assert(obj < SolarSystemObject.Mars, "Reason for the assert");

            var coefficient = (int)obj * 2;

            var anomalyM = Angles.Mod360(PlanetaryPhenomenaQuotients.PlanetaryPhenomenaCoefficient1[coefficient].M0 + PlanetaryPhenomenaQuotients.PlanetaryPhenomenaCoefficient1[coefficient].M1 * givenK);
            anomalyM = Angles.DegRad(anomalyM);   //// convert anomalyM to radians

            var julianCentury = (julianDayE0 - 2451545) / 36525;
            var timeT2 = julianCentury * julianCentury;

            double value = 0;
            switch (obj) {
                case SolarSystemObject.Mercury:
                    value = BodyMercury.PlanetaryElongationValue(bEastern, anomalyM, julianCentury, timeT2);
                    break;
                case SolarSystemObject.Venus:
                    value = BodyMercury.PlanetaryElongationValue(bEastern, anomalyM, julianCentury, timeT2);
                    break;
                case SolarSystemObject.Mars:
                    break;
                case SolarSystemObject.Jupiter:
                    break;
                case SolarSystemObject.Saturn:
                    break;
                case SolarSystemObject.Uranus:
                    break;
                case SolarSystemObject.Neptune:
                    break;
                case SolarSystemObject.Sun:
                    break;
                case SolarSystemObject.Pluto:
                    break;
            }

            return value;
        }

        /// <summary>
        /// Means the specified k.
        /// </summary>
        /// <param name="givenK">The givenK.</param>
        /// <param name="obj">The object.</param>
        /// <param name="type">The type.</param>
        /// <returns> Returns value. </returns>
        private static double Mean(double givenK, SolarSystemObject obj, EventType type) {
            int coefficient; //// = -1;
            if (obj >= SolarSystemObject.Mars) {
                Debug.Assert(type == EventType.Opposition || type == EventType.Conjunction, "Reason for the assert");

                coefficient = type == EventType.Opposition ? (int)obj * 2 : (int)obj * 2 + 1;
            }
            else {
                Debug.Assert(type == EventType.InferiorConjunction || type == EventType.SuperiorConjunction, "Reason for the assert");

                coefficient = type == EventType.InferiorConjunction ? (int)obj * 2 : (int)obj * 2 + 1;
            }

            return PlanetaryPhenomenaQuotients.PlanetaryPhenomenaCoefficient1[coefficient].A + PlanetaryPhenomenaQuotients.PlanetaryPhenomenaCoefficient1[coefficient].B * givenK;
        }
    }
}
