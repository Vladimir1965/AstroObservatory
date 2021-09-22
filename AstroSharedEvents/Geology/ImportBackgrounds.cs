// <copyright file="ImportBackgrounds.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Geology
{
    using JetBrains.Annotations;

    /// <summary>
    /// Import Backgrounds.
    /// </summary>
    [UsedImplicitly]
    public static class ImportBackgrounds {
        /*
        /// <summary>
        /// Inserts the earthquake backgrounds.
        /// </summary>
        [UsedImplicitly]
        public static void InsertEarthquakeBackgrounds() {
            var earthquakes = (from te in XAstro.Astro.SolveEarthquakes.EarthquakeList
                               orderby te.EventTime ascending, te.Latitude, te.Longitude
                               select te).ToList(); //// te.EventTime

            earthquakes.ForEach(eq => {
                DateTime dt = eq.EventTime;
                //// if (dt.Year != 2007) { continue; } 
                EarthLocation loc = eq.EarthLocation;
                string place = !string.IsNullOrEmpty(loc.Country) ? loc.Country : loc.Ocean;
                var tqb = NewEventBackground(dt, place, eq.Latitude, eq.Longitude);
                tqb.EarthquakeId = eq.Id;
                XAstro.Astro.SolveEarthquakes.EventBackgroundList.Add(tqb);
                //// dc.SaveChanges();
            });
        } */

        /*
        /// <summary>
        /// Inserts the eruption backgrounds.
        /// </summary>
        [UsedImplicitly]
        public static void InsertEruptionBackgrounds() {
            var eruptions = (from te in XAstro.Astro.SolveVolcanoes.EruptionRecordList
                             join tv in XAstro.Astro.SolveVolcanoes.VolcanoRecordList on te.VolcanoNumber equals tv.VolcanoNumber
                             where te.Duration < 10
                             orderby te.StartTime ascending, tv.Latitude, tv.Longitude
                             select te).ToList(); //// te.EventTime

            foreach (var te in eruptions) {
                LargoBaseAstronomy.VolcanoRecord volcano = (from vo in XAstro.Astro.SolveVolcanoes.VolcanoRecordList 
                                          where vo.VolcanoNumber == te.VolcanoNumber 
                                          select vo).FirstOrDefault();
                if (volcano == null) {
                    continue;
                }

                DateTime? dt = te.StartTime;
                //// if (dt == null) { continue; }

                //// if (dt.Year != 2007) { continue; } 
                string place = te.VolcanoName;
                {
                    var tqb = NewEventBackground((DateTime)dt, place, (decimal)volcano.Latitude, (decimal)volcano.Longitude);
                    tqb.EruptionId = te.Id;
                    XAstro.Astro.SolveEarthquakes.EventBackgroundList.Add(tqb);
                }

                //// dc.SaveChanges();
            }
        }

        /// <summary>
        /// News the event background.
        /// </summary>
        /// <param name="dt">The data time.</param>
        /// <param name="place">The place.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns> Returns value. </returns>
        private static EventBackground NewEventBackground(DateTime dt, string place, decimal latitude, decimal longitude) {
            double tyear = dt.Year + ((dt.DayOfYear - 1 + (dt.Hour / 24.0)) / LargoBaseAstronomy.Julian.TropicalYear);
            double julianDate = LargoBaseAstronomy.Julian.JulYear(tyear);

            SolarSystem.Singleton.Jupiter.SetJulianDate(this.JulianDate);
            SolarSystem.Singleton.Earth.SetJulianDate(this.JulianDate);
            //// SolarSystem.Mars.SetJulianDate(this.JulianDate);

            EarthStatus st = MoonInfluence.GetEarthStatus(dt.Year, dt.DayOfYear, dt.Hour);
            string description = string.Empty;
            const double tolerance = 30;
            const double strictTolerance = 15;
            const double exactTolerance = 5;

            //// Characteristics

            double value = LargoBaseAstronomy.Angles.Mod360Sym(SolarSystem.Singleton.Earth.Longitude - SolarSystem.Singleton.Jupiter.Longitude);
            double absValue = Math.Abs(LargoBaseAstronomy.Angles.Mod180Sym(value));
            if (absValue < tolerance) {
                description += ",Aspect EJ";
                if (absValue < strictTolerance) {
                    description += "*";
                    if (absValue < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value, 0)})";
            }

            value = Math.Abs(LargoBaseAstronomy.Angles.Mod360Sym(SolarSystem.Singleton.Jupiter.Longitude - SolarSystem.Singleton.Jupiter.LP));
            absValue = Math.Abs(value);
            if (absValue < tolerance) {
                description += ",Peri J";
                if (absValue < strictTolerance) {
                    description += "*";
                    if (absValue < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value, 0)})";
            }

            value = Math.Abs(LargoBaseAstronomy.Angles.Mod360Sym(SolarSystem.Singleton.Earth.Longitude - SolarSystem.Singleton.Earth.LP));
            absValue = Math.Abs(value);
            if (absValue < tolerance) {
                description += ",Peri E";
                if (absValue < strictTolerance) {
                    description += "*";
                    if (absValue < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value, 0)})";
            }

            value = Math.Abs(LargoBaseAstronomy.Angles.Mod360Sym((double)(st.MoonAscension - st.SunAscension)));
            if (value < tolerance) {
                description += ",new";
                if (value < strictTolerance) {
                    description += "*";
                    if (value < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value, 0)})";
            }

            value = Math.Abs(LargoBaseAstronomy.Angles.Mod360Sym((double)(st.MoonAscension - st.SunAscension + 180)));
            if (value < tolerance) {
                description += ",full";
                if (value < strictTolerance) {
                    description += "*";
                    if (value < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value, 0)})";
            }

            value = 2 * Math.Abs(LargoBaseAstronomy.Angles.Mod360Sym((double)(st.MoonDeclination - st.SunDeclination)));
            if (value < tolerance) {
                description += ",sun-dec";
                if (value < strictTolerance) {
                    description += "*";
                    if (value < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value / 2, 0)})";
            }

            value = Math.Abs(LargoBaseAstronomy.Angles.Mod360Sym((double)st.MoonPericentre));
            if (value < tolerance) {
                description += ",perigee";
                if (value < strictTolerance) {
                    description += "*";
                    if (value < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value, 0)})";
            }

            value = Math.Abs(LargoBaseAstronomy.Angles.Mod360Sym((double)st.MoonPericentre + 180));
            if (value < tolerance) {
                description += ",apogee";
                if (value < strictTolerance) {
                    description += "*";
                    if (value < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value, 0)})";
            }

            value = Math.Abs(LargoBaseAstronomy.Angles.Mod180Sym((double)st.MoonNode));
            if (value < tolerance) {
                description += ",node";
                if (value < strictTolerance) {
                    description += "*";
                    if (value < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value, 0)})";
            }

            value = 2 * Math.Abs(LargoBaseAstronomy.Angles.Mod360Sym((double)(latitude - st.MoonDeclination)));
            if (value < tolerance) {
                description += ",eq-lati";
                if (value < strictTolerance) {
                    description += "*";
                    if (value < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value / 2, 0)})";
            }

            value = Math.Abs(LargoBaseAstronomy.Angles.Mod360Sym((double)(longitude - st.MoonAscension)));
            if (value < tolerance) {
                description += ",eq-long";
                if (value < strictTolerance) {
                    description += "*";
                    if (value < exactTolerance) {
                        description += "*";
                    }
                }

                description += $"({Math.Round(value, 0)})";
            }

            if (description.StartsWith(",")) {
                description = description.Substring(1);
            }

            EventBackground tqb = new EventBackground {
                MoonDeclination = (decimal)Angles.Mod180Sym((double)st.MoonDeclination),
                MoonAscension = st.MoonAscension,
                SunDeclination = (decimal)Angles.Mod180Sym((double)st.SunDeclination),
                SunAscension = st.SunAscension,
                Characteristic = description,
                Place = place,
                EventTime = dt,
                AngleVE = (decimal)Angles.Mod360Sym(SolarSystem.Singleton.Earth.Longitude - SolarSystem.Singleton.Venus.Longitude),
                AngleJE = (decimal)Angles.Mod360Sym(SolarSystem.Singleton.Earth.Longitude - SolarSystem.Singleton.Jupiter.Longitude),
                AngleER = (decimal)Angles.Mod360Sym(SolarSystem.Singleton.Earth.Longitude - SolarSystem.Singleton.Mars.Longitude)
            };

            return tqb;
        }
        */
    }
}
