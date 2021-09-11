// <copyright file="DateListMayan.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedEvents.Lists { 
    using System.Collections.Generic;
    using AstroSharedClasses.Records;
    using JetBrains.Annotations;

    /// <summary> Mayan extension of DateList. </summary>
    public partial class EventList
{
        #region Particular Mayan Dates
        /// <summary>
        /// Mayan Dates Serpent.
        /// </summary>
        public static readonly MayanRecord[] MayanDatesSerpent =
        {
            new MayanRecord(9, 16, 8, 5, 12, "Serpent-9, Mercury west"),
            new MayanRecord(9, 17, 8, 8, 5, "Serpent-1*3120, Mercury east, Paris lunation"),
            new MayanRecord(9, 17, 15, 6, 14, "Serpent-10, Mercury east"),
            new MayanRecord(9, 18, 4, 8, 4, "Serpent-7,  Mercury up"),
            new MayanRecord(9, 18, 5, 16, 4, "Serpent-4?3120, Mercury low"),
            new MayanRecord(10, 4, 6, 15, 4, "Serpent-6?3120, Mercury east?"),
            new MayanRecord(10, 6, 10, 6, 3, "Serpent-8*3120, Mercury east, Sh"),
            new MayanRecord(10, 7, 4, 3, 5, "Serpent-3, Mercury east, Paris lunation"),
            new MayanRecord(10, 8, 5, 0, 6, "Serpent-5*3120, Mercury up"),
            new MayanRecord(10, 11, 5, 14, 5, "Serpent-2*3120, Mercury up")
        };

        /// <summary>
        /// Mayan Dates Fires.
        /// </summary>
        public static readonly MayanRecord[] MayanDatesFires =
        {
            new MayanRecord(6, 4, 2, 12, 0, "Olmec, New Fire?"),
            new MayanRecord(6, 9, 8, 2, 0,  "Zapotec, year?, Round?"),
            new MayanRecord(6, 19, 19, 0, 0,"Olmec Round, Long Count?"),
            new MayanRecord(9, 10, 15, 11, 12, "260 let?"),
            new MayanRecord(9, 14, 14, 13, 17, "fire, M30d"),
            new MayanRecord(9, 15, 6, 13, 1, "V morning, fire, M30d"),
            new MayanRecord(10, 0, 12, 3, 2, "Yucunudahui, Fire?"),
            new MayanRecord(10, 3, 19, 4, 12, "260 years?"),
            new MayanRecord(10, 17, 2, 15, 12, "260 years?"),
            new MayanRecord(11, 10, 6, 8, 12, "52 years?,260 years?"),
            new MayanRecord(11, 12, 19, 3, 12, "52 years?"),           
            new MayanRecord(11, 15, 11, 16, 12, "52 years?")
        };

        /// <summary>
        /// MayanDates RJS.
        /// </summary>
        [UsedImplicitly]
        public static readonly MayanRecord[] MayanDatesRjs =
        {
            new MayanRecord(6,1,11,3,1, "RJS-a",true),  
            new MayanRecord(6,13,13,15,1, "RJS-b",true),  
            new MayanRecord(6,1,9,15,0, "(R)JS-c",true),  
            new MayanRecord(6,9,16,10,1, "(RJS)-d",true),  
            new MayanRecord(6,7,12,4,10, "(RJS)-e",true),  
            new MayanRecord(6,11,10,7,2, "RJS-f",true),
            new MayanRecord(6,9,15,12,19, "R(J)S-g",true),  
            new MayanRecord(6,1,9,15,0, "(RJS)-h",true)  
            //// new MayanRecord(9, 18, 4, 8, 4, "(R)JS"),  //// 4.6.1.9.15.0 c
            //// new MayanRecord(10, 8, 5, 0, 6, "(R)JS"),  //// 4.6.11.10.7.2 f
        };

        /// <summary>
        /// Mayan Dates Equinox.
        /// </summary>
        public static readonly MayanRecord[] MayanDatesEquinox =
        {
            new MayanRecord(9, 11, 12, 7, 2, "equinox"),
            new MayanRecord(9, 14, 13, 4, 17, "equinox"),
            new MayanRecord(9, 16, 12, 5, 17, "equinox")
        };

        /// <summary>
        /// Mayan Dates 819.
        /// </summary>
        public static readonly MayanRecord[] MayanDates819 =
        {
            new MayanRecord(9, 13, 16, 10, 13, "819 d"),
            new MayanRecord(9, 15, 19, 14, 14, "Yaxchilan 819 d"),
            new MayanRecord(9, 16, 8, 16, 10, "819 d"),
            new MayanRecord(9, 17, 4, 15, 3, "819 d")
        };

        /// <summary>
        /// Mayan Dates GodK.
        /// </summary>
        public static readonly MayanRecord[] MayanDatesGodK =
        {
            new MayanRecord(9, 16, 1, 8, 8, "god K?"),
            new MayanRecord(9, 16, 5, 0, 0, "god K?, Moon 5"),
            new MayanRecord(9, 16, 15, 0, 0, "god K?")
        };

        /// <summary>
        /// Mayan Dates Moon.
        /// </summary>
        [UsedImplicitly]
        public static readonly MayanRecord[] MayanDatesMoon =
        { 
            new MayanRecord(8, 16, 4, 8, 8, "eclipse,(V-R)"),
            new MayanRecord(9, 0, 19, 2, 4, "R7, M29d"),
            new MayanRecord(9, 1, 10, 0, 0, "Moon Age 25"),
            new MayanRecord(9, 6, 10, 0, 0, "Moon Age 25"),
            new MayanRecord(9, 7, 5, 0, 8, "Moon age 2"),
            new MayanRecord(9, 9, 0, 0, 0, "Moon Age 13"),
            new MayanRecord(9, 9, 10, 0, 0, "Moon Age 9"),
            new MayanRecord(9, 9, 14, 17, 5, "Moon Age 23"),
            new MayanRecord(9, 10, 15, 0, 0, "Moon Age 3"),
            new MayanRecord(9, 10, 18, 12, 8, "Moon Age 5"),
            new MayanRecord(9, 10, 19, 13, 0, "Moon Age 23"),
            new MayanRecord(9, 10, 19, 15, 0, "Moon Age 4"),
            new MayanRecord(9, 11, 0, 0, 0, "Moon Age 5"),
            new MayanRecord(9, 11, 15, 0, 0, "Moon Age 28"),
            new MayanRecord(9, 11, 15, 14, 0, "Moon Age 12"),
            new MayanRecord(9, 11, 16, 10, 13, "Complete 2k, M29d"),
            new MayanRecord(9, 12, 3, 14, 0, "Moon age 0"),
            new MayanRecord(9, 12, 8, 3, 9, "Moon Age 22"),
            new MayanRecord(9, 12, 8, 14, 1, "Yaxchilan, M29d"),
            new MayanRecord(9, 12, 10, 0, 0, "Moon Age 22"),
            new MayanRecord(9, 12, 16, 7, 8, "Moon age 0"),
            new MayanRecord(9, 13, 10, 0, 0, "half katun, Moon 18"),
            new MayanRecord(9, 13, 15, 1, 0, "Moon Age 8"),
            new MayanRecord(9, 13, 17, 12, 10, "M30d"),
            new MayanRecord(9, 14, 19, 8, 0, "Moon Age 15"),
            new MayanRecord(9, 15, 5, 0, 0, "Moon Age 9"),
            new MayanRecord(9, 15, 12, 10, 10, "Moon Age 24"), 
            new MayanRecord(9, 16, 1, 0, 0, "Yaxchilan, M30d"),
            new MayanRecord(9, 16, 4, 10, 8, "eclipse"),
            new MayanRecord(9, 16, 4, 11, 3, "eclipse!,(Moon)"),
            new MayanRecord(9, 16, 4, 11, 18, "eclipse!,(Moon)"),
            new MayanRecord(9, 16, 5, 0, 0, "god K?, Moon 5"), 
            new MayanRecord(9, 17, 0, 0, 15, "Linda Schele eclipse?"),
            new MayanRecord(9, 17, 19, 13, 16, "Malstrom eclipse?"),
            new MayanRecord(9, 19, 5, 7, 8, "eclipse,(V-R)"),
            new MayanRecord(10, 19, 6, 1, 8, "eclipse,(V-R),discounted?")
        };

        /// <summary>
        /// Mayan Dates EJS.
        /// </summary>
        public static readonly MayanRecord[] MayanDatesEjs =
        {
            new MayanRecord(8, 11,  7, 13, 5, "E-S, Sh, Mercury west"),
            new MayanRecord(8, 11,  8,  7, 0, "E-J, Jh, Mercury west"),
            new MayanRecord(8, 16,  3, 13, 0, "E-J"),
            //// new MayanRecord(8, 16, 14, 15, 4, "E-J-S"),
            //// new MayanRecord(8, 16, 15, 16, 1, "E-J-S"),
            new MayanRecord(8, 19,  0,  4, 4, "E-J"),
            //// new MayanRecord(10, 6, 10,  6, 3, "E-S"),
            new MayanRecord(10, 13, 13, 3, 2, "E-S")
        };

        /// <summary>
        /// Mayan Dates JS.
        /// </summary>
        public static readonly MayanRecord[] MayanDatesJS =
        {
            ////new MayanRecord(8, 16, 14, 9, 3, "Mercury East(JS?)"),
            new MayanRecord(8, 16, 14, 15, 4, "JS1: Jh-Sh, Mercury east"),
            new MayanRecord(8, 16, 15, 16, 1, "JS1: J-Sh, Mercury west"),
            new MayanRecord(9, 0, 15, 11, 0,  "JS1: J-S (?)"),
            new MayanRecord(9, 12, 18, 5, 16, "JS1: J-S (!?)"),
            new MayanRecord(9, 12, 19, 5, 19, "JS1: J-S (?)"),
            new MayanRecord(9, 13, 17, 12, 10,"JS1: J-S (?)"),
            new MayanRecord(9, 13, 17, 15, 12,"JS1: Yaxchilan (JS?)"),
            new MayanRecord(9, 14, 17, 15, 11,"JS1: Yaxchilan (JS)"),
            new MayanRecord(8, 17, 11, 1, 10, "JS2: J-S (?) Bohm"),
            new MayanRecord(9, 1, 11, 17, 10, "JS2: J-S (?) Bohm"),
            new MayanRecord(9, 16, 13, 0, 0,  "JS2: J-S (?)"),
            new MayanRecord(9, 10, 3, 2, 12,  "JS3: J-S (?)"),
            new MayanRecord(9, 13, 3, 9, 18,  "JS3: J-S (?)"),
            new MayanRecord(10, 8, 3, 16, 4,  "JS3: Mercury west,(JS?)"),
            new MayanRecord(9, 10, 6, 2, 1,   "JS4: J-S (?)"),
            new MayanRecord(9, 12, 7, 16, 17, "JS4: J-S (!?)")
            //// new MayanRecord(9, 12, 9, 8, 1,   "JS4: J-S (!?)"),
            //// new MayanRecord(9, 16, 10, 0, 0,  "JS4: J-S (?)"),
        };

        /// <summary>
        /// Mayan Grid Dates.
        /// </summary>
        public static readonly MayanRecord[] MayanGridDates =
        { 
            new MayanRecord(0, 0, 0, 0, 0, "Start of dating"),
            new MayanRecord(1, 0, 0, 0, 0, " 1.baktun"),
            new MayanRecord(2, 0, 0, 0, 0, " 2.baktun"),
            new MayanRecord(3, 0, 0, 0, 0, " 3.baktun"),
            new MayanRecord(4, 0, 0, 0, 0, " 4.baktun"),
            new MayanRecord(5, 0, 0, 0, 0, " 5.baktun"),
            new MayanRecord(6, 0, 0, 0, 0, " 6.baktun"),
            new MayanRecord(7, 0, 0, 0, 0, " 7.baktun"),
            new MayanRecord(8, 0, 0, 0, 0, " 8.baktun"),
            new MayanRecord(9, 0, 0, 0, 0, " 9.baktun"),
            new MayanRecord(10, 0, 0, 0, 0, "10.baktun"),
            new MayanRecord(11, 0, 0, 0, 0, "11.baktun"),
            new MayanRecord(12, 0, 0, 0, 0, "12.baktun"),
            new MayanRecord(13, 0, 0, 0, 0, "13.baktun")
        };

        /// <summary>
        /// Mayan Dates 6.
        /// </summary>
        public static readonly MayanRecord[] MayanDates6 =
        { 
            new MayanRecord(6, 3, 10, 9, 0, "Olmec"),
            new MayanRecord(6, 7, 16, 2, 9, "Zapotec, year?"),
            new MayanRecord(6, 11, 3, 2, 11,"Zapotec, capture?")
        };

        /// <summary>
        /// Mayan Dates 7.
        /// </summary>
        public static readonly MayanRecord[] MayanDates7 =
        { 
            new MayanRecord(7, 6, 0, 0, 0, "Tikal calendar"),
            new MayanRecord(7, 6, 6, 16, 3, "Tikal"),
            new MayanRecord(7, 7, 7, 8, 14, "Tikal"),
            new MayanRecord(7, 10, 10, 8, 2, "Kaminaljuyu"),
            new MayanRecord(7, 16, 3, 2, 13, "Kaminaljuyu"),
            new MayanRecord(7, 16, 6, 16, 18, "Kaminaljuyu"),
            new MayanRecord(7, 19, 15, 7, 12, "Stelae, Kaminaljuyu")
        };

        /// <summary>
        /// Mayan Dates 8.
        /// </summary>
        public static readonly MayanRecord[] MayanDates8 =
        { 
            new MayanRecord(8, 0, 6, 6, 6, "Kaminaljuyu"),
            new MayanRecord(8, 4, 5, 17, 11, "Kaminaljuyu"),
            new MayanRecord(8, 6, 2, 4, 17, "Kaminaljuyu"),
            new MayanRecord(8, 6, 16, 7, 14, "Mup, Dresden ring"),
            new MayanRecord(8, 6, 16, 12, 0, "Mercury west"),
            new MayanRecord(8, 7, 13, 5, 5, "Stelae"),
            new MayanRecord(8, 8, 0, 7, 0, "Kaminaljuyu, his blood"),
            new MayanRecord(8, 12, 14, 8, 15, "Kaminaljuyu, Long Count"),
            new MayanRecord(8, 14, 3, 1, 12, "Leyden plate"),
            new MayanRecord(8, 16, 3, 12, 3, "Mercury west"),
            //// new MayanRecord(8, 16, 3, 13, 0, "Jh"),
            new MayanRecord(8, 16, 4, 8, 0, "?"),
            new MayanRecord(8, 16, 14, 9, 3, "Mercury East(JS?)"),
            new MayanRecord(8, 16, 14, 11, 5, "Mercury west"),
            //// new MayanRecord(8, 16, 14, 15, 4, "Jh-Sh, Mercury East"),
            //// new MayanRecord(8, 16, 15, 16, 1, "Sh, Mercury west"),
            new MayanRecord(8, 16, 19, 0, 12, "Mercury East"),
            new MayanRecord(8, 16, 19, 10, 0, "Mup"),
            //// new MayanRecord(8, 17, 11, 1, 10, "J-S (?)"),
            new MayanRecord(8, 17, 11, 3, 0, "dresden"),
            new MayanRecord(8, 17, 13, 6, 0, "mod 3120"),
            new MayanRecord(8, 18, 9, 17, 18, "Stelae"),
            //// new MayanRecord(8, 19, 0, 4, 4, "Jh, Mercury East"),
            new MayanRecord(8, 19, 10, 0, 0, "Yucunudahui, year?")
        };

        /// <summary>
        /// Mayan Dates 9.
        /// </summary>
        public static readonly MayanRecord[] MayanDates9 =
        { 
            new MayanRecord(9, 1, 12, 14, 10, "Yucunudahui"),
            new MayanRecord(9, 3, 0, 0, 0, "-"),
            new MayanRecord(9, 4, 8, 8, 15, "Stelae"),
            new MayanRecord(9, 4, 16, 8, 12, "Mercury low"),
            new MayanRecord(9, 4, 15, 16, 8, "Yucunudahui"),
            new MayanRecord(9, 6, 11, 14, 0, "Yucunudahui"),
            new MayanRecord(9, 9, 9, 16, 0, "Vh!,M-E,E-Moon"),
            new MayanRecord(9, 9, 16, 0, 0, "M-E"),
            new MayanRecord(9,10, 15, 0, 0, "?"),
            new MayanRecord(9,10, 15, 3, 0, "E-Moon, Venus low"),
            new MayanRecord(9,10, 16, 10, 13, "Complete 1k"),

            new MayanRecord(9, 11, 3, 10,13, "Stelae"),
            new MayanRecord(9, 11, 11,15,14, "?M"),
            new MayanRecord(9, 11, 12, 9, 6, "Stelae"),
            new MayanRecord(9, 11, 12,10,14, "ball court ring"),
            new MayanRecord(9, 11, 16,10,13, "?"),

            new MayanRecord(9, 12, 0, 0, 0, "Campeche"),
            new MayanRecord(9, 12, 8, 9, 9, "Stelae"),
            new MayanRecord(9, 12, 9, 8, 1, "Yaxchilan"),
            new MayanRecord(9, 12, 10, 3, 9, "(V-R)"),
            new MayanRecord(9, 12, 11, 11, 0, "(V-R)"),
            new MayanRecord(9, 12, 16, 7, 8, "?"),
            new MayanRecord(9, 12, 17, 12, 0, "Yaxchilan"),
            new MayanRecord(9, 13, 0, 0, 0, "Yaxchilan, Yucatecan"),
            new MayanRecord(9, 13, 3, 6, 8, "Moon"),
            new MayanRecord(9, 13, 7, 3, 8, "Stelae"),
            new MayanRecord(9, 13, 9, 14, 14, "Yaxchilan"),
            new MayanRecord(9, 13, 10, 15, 14, "Mercury east"),
            new MayanRecord(9, 13, 11, 14, 17, "Farmer Almanac"),
            new MayanRecord(9, 13, 12, 10, 0, "Vh, Mercury low"),
            new MayanRecord(9, 13, 13, 12, 5, "Death"),
            new MayanRecord(9, 13, 17, 15, 12, "Yaxchilan"),

            new MayanRecord(9, 14, 1, 3, 19, "Stelae"),
            new MayanRecord(9, 14, 2, 0, 14, "E-V"),
            new MayanRecord(9, 14, 2, 6, 0, "Vh"),
            new MayanRecord(9, 14, 2, 12, 16, "Stelae"),
            new MayanRecord(9, 14, 5, 3, 4, "Stelae"),
            new MayanRecord(9, 14, 10, 4, 0, "Stelae"),
            new MayanRecord(9, 14, 15, 0, 0, "Yaxchilan"),

            new MayanRecord(9, 15, 1, 15, 18, "Yucunudahui month"),
            new MayanRecord(9, 15, 0, 1, 5, "Yaxchilan"),
            new MayanRecord(9, 15, 4, 6, 4, "Stelae"),

            new MayanRecord(9, 15, 6, 13, 17, "Yaxchilan"),
            new MayanRecord(9, 15, 9, 15, 14, "Vh, Mercury low"),
            new MayanRecord(9, 15, 10, 0, 1, "Yaxchilan V morning"),
            new MayanRecord(9, 15, 13, 6, 9, "Yaxchilan J, ball, rok"),
            new MayanRecord(9, 15, 14, 16, 17, "Campeche"),
            new MayanRecord(9, 15, 15, 0, 0, "Yaxchilan rok"),
            new MayanRecord(9, 15, 15, 12, 16, "Martin 24 y"),
            new MayanRecord(9, 15, 17, 15, 14, "death"),
            new MayanRecord(9, 15, 19, 1, 1, "Yaxchilan V evening, rok"),
            new MayanRecord(9, 16, 0, 13, 17, "Yaxchilan capture of Q"),
            new MayanRecord(9, 16, 0, 0, 0, "zenith passage"),
            new MayanRecord(9, 16, 1, 0, 9, "zenith passage"),
            new MayanRecord(9, 16, 4, 6, 17, "Yaxchilan"),
            new MayanRecord( 9,16, 4,10, 8, "?"),
            new MayanRecord( 9,16, 5, 0, 0, "?"),
            new MayanRecord(9, 16, 10, 0, 0, "Yaxchilan, Moon 1?, M30d"),
            new MayanRecord(9, 16, 16, 6, 7, "Palenque"),
            new MayanRecord(9, 16, 17, 2, 18, "Yucunudahui"),
            new MayanRecord(9, 16, 17, 6, 12, "Yucunudahui,Palenque,Yaxchilan"),
            new MayanRecord(9, 17, 0, 0, 16, "Martin 24 y"),
            new MayanRecord(9, 17, 5, 8, 12, "Palenque"),
            new MayanRecord(9, 17, 9, 0, 13, "Stelae"),
            new MayanRecord(9, 17, 9, 1, 7, "Palenque"),
            new MayanRecord(9, 17, 10, 9, 17, "Palenque"),
            new MayanRecord(9, 17, 12, 6, 2, "Stelae"),
            new MayanRecord(9, 17, 19, 17, 7, "Yucunudahui, 16 y"),
            new MayanRecord(9, 18, 1, 7, 9, "(V-R)"),
            new MayanRecord(9, 18, 1, 2, 12, "Palenque"),
            new MayanRecord(9, 18, 2, 2, 0, "(V-R)"),
            new MayanRecord(9, 18, 4, 8, 4, "?"),
            new MayanRecord(9, 18, 13, 3, 13, "Stelae"),
            new MayanRecord(9, 18, 17, 5, 18, "Stelae"),
            new MayanRecord(9, 19, 1, 5, 0, "Vh!"),
            new MayanRecord(9, 19, 7, 2, 14, "Mercury low"),
            new MayanRecord(9, 19, 7, 15, 8, "Rh,(M?)(equinox?)"),
            new MayanRecord(9, 19, 8, 15, 0, "E-R"),
            new MayanRecord(9, 19, 11, 13, 0, "Mercury west")
        };

        /// <summary>
        /// Maya nDates 10.
        /// </summary>
        public static readonly MayanRecord[] MayanDates10 =
        { 
            new MayanRecord(10, 0, 18, 13, 15, "Yucunudahui"),
            new MayanRecord(10, 3, 0, 0, 0, "Chichen Itza fall?"),
            new MayanRecord(10, 4, 0, 0, 0, "end pamatniku"),
            new MayanRecord(10, 4, 6, 15,14, "?"),
            new MayanRecord(10, 5, 0, 0, 0, "stone monument"),
            new MayanRecord(10, 5, 6, 7, 0, "Vh"),
            new MayanRecord(10, 5, 13, 14, 1, "last monumental use"),
            new MayanRecord(10, 7, 5, 4, 4, "Tilantogo began"),
            new MayanRecord(10, 8, 5, 0, 6, "?"),
            //// new MayanRecord(10, 8, 3, 16, 4, "Mercury west,(JS?)"),
            new MayanRecord(10, 10, 0, 0, 0, "Correlation"),
            new MayanRecord(10, 10, 9, 9, 13, "Tilantogo"),
            new MayanRecord(10, 11, 3, 18, 14, "Mercury low"),
            new MayanRecord(10,11, 4, 0, 14, "?"),
            //// new MayanRecord(10, 13, 13, 3, 2, "Sh"),
            new MayanRecord(10,13,13, 3, 2, "?"),
            new MayanRecord(10, 14, 2, 16, 12, "Vh, Mercury low"),
            new MayanRecord(10, 14, 18, 3, 13, "Tilantogo"),
            new MayanRecord(10, 15, 1, 11, 18, "Tilantogo"),
            new MayanRecord(10, 15, 1, 13, 8, "Tilantogo"),
            new MayanRecord(10, 16, 4, 13, 3, "Tilantogo"),
            new MayanRecord(10, 16, 5, 13, 8, "Tilantogo (king died)"),
            new MayanRecord(10, 16, 7, 1, 13, "Tilantogo"),
            new MayanRecord(10, 17, 6, 0, 8, "Tilantogo"),
            new MayanRecord(10, 17, 11, 1, 13, "Tilantogo"),
            new MayanRecord(10, 17, 13, 12, 12, "Mercury east, Dresden latest"),
            new MayanRecord(10, 19, 18, 14, 5, "Tilantogo")
        };

        /// <summary>
        /// Mayan 
        /// </summary>
        public static readonly MayanRecord[] MayanDates11 =
        { 
            new MayanRecord(11, 3, 0, 0, 0, "Correlation"),
            new MayanRecord(11, 3, 12, 13, 13, "Tilantogo"),
            new MayanRecord(11, 3, 13, 10, 18, "Tilantogo"),
            new MayanRecord(11, 3, 14, 16, 3, "Tilantogo"),
            new MayanRecord(11, 3, 18, 14, 3, "Tilantogo"),
            new MayanRecord(11, 7, 6, 17, 18, "Tilantogo"),
            new MayanRecord(11, 7, 7, 1, 18, "Tilantogo"),
            new MayanRecord(11, 7, 7, 2, 18, "Tilantogo"),
            new MayanRecord(11, 7, 7, 15, 3, "Tilantogo"),
            new MayanRecord(11, 7, 7, 16, 3, "Tilantogo"),
            new MayanRecord(11, 7, 8, 0, 3, "Tilantogo"),
            new MayanRecord(11, 7, 8, 14, 8, "Tilantogo (Mexican)"),
            new MayanRecord(11, 7, 8, 15, 8, "Tilantogo"),
            new MayanRecord(11, 7, 8, 16, 8, "Tilantogo"),
            new MayanRecord(11, 7, 9, 0, 8, "Tilantogo"),
            new MayanRecord(11, 7, 9, 2, 8, "Tilantogo"),
            new MayanRecord(11, 7, 10, 0, 13, "Tilantogo"),
            new MayanRecord(11, 7, 10, 2, 13, "Tilantogo"),
            new MayanRecord(11, 9, 14, 7, 13, "Tilantogo"),
            new MayanRecord(11, 10, 2, 16, 13, "Tilantogo"),
            new MayanRecord(11, 10, 13, 13, 18, "Tilantogo"),
            new MayanRecord(11, 12, 0, 0, 0, "Tilantogo"),
            new MayanRecord(11, 12, 5, 1, 2, "Tilantogo"),
            new MayanRecord(11, 12, 8, 13, 4, "Tilantogo"),
            new MayanRecord(11, 13, 0, 0, 0, "Tilantogo"),
            new MayanRecord(11, 13, 5, 13, 7, "Tilantogo"),
            new MayanRecord(11, 13, 6, 0, 0, "Tilantogo"),
            new MayanRecord(11, 13, 12, 15, 13, "Tilantogo"),
            new MayanRecord(11, 14, 0, 0, 0, "Tilantogo"),
            new MayanRecord(11, 14, 7, 11, 13, "Tilantogo"),
            new MayanRecord(11, 14, 13, 0, 0, "Tilantogo"),
            new MayanRecord(11, 14, 19, 13, 2, "Tilantogo"),
            new MayanRecord(11, 15, 0, 14, 18, "Tilantogo"),
            new MayanRecord(11, 15, 0, 6, 0, "Tilantogo"),
            new MayanRecord(11, 15, 1, 4, 2, "Tilantogo"),
            new MayanRecord(11, 15, 1, 9, 5, "Tilantogo"),
            new MayanRecord(11, 15, 1, 13, 3, "Tilantogo"),
            new MayanRecord(11, 15, 2, 1, 3, "Tilantogo"),
            new MayanRecord(11, 15, 2, 1, 5, "Tilantogo"),
            new MayanRecord(11, 15, 2, 8, 8, "Tilantogo"),
            new MayanRecord(11, 15, 2, 14, 8, "Tilantogo"),
            new MayanRecord(11, 15, 3, 6, 8, "Tilantogo"),
            new MayanRecord(11, 15, 4, 4, 0, "Tilantogo"),
            new MayanRecord(11, 15, 10, 16, 13, "Tilantogo"),
            new MayanRecord(11, 15, 11, 10, 13, "1.month Pop"),
            new MayanRecord(11, 15, 11, 15, 18, "Tilantogo"),
            new MayanRecord(11, 15, 13, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 15, 14, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 15, 15, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 15, 16, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 15, 17, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 15, 17, 5, 1, "Tilantogo"),
            new MayanRecord(11, 15, 18, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 15, 18, 5, 9, "Tilantogo"),
            new MayanRecord(11, 15, 19, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 15, 19, 14, 0, "Mayapan"),
            new MayanRecord(11, 16, 0, 0, 0, "Correlation(katun end)"),
            new MayanRecord(11, 16, 0, 0, 14, "Mayapan"),
            new MayanRecord(11, 16, 1, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 16, 1, 15, 18, "Mayapan"),
            new MayanRecord(11, 16, 2, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 16, 2, 2, 8, "Mayapan"),
            new MayanRecord(11, 16, 3, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 16, 4, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 16, 4, 11, 14, "Mayapan"),
            new MayanRecord(11, 16, 4, 13, 19, "Mayapan, tun-haab"),
            new MayanRecord(11, 16, 5, 0, 0, "Mayapan Tun"),
            new MayanRecord(11, 16, 5, 6, 18, "Mayapan"),
            new MayanRecord(11, 16, 12, 4, 13, "Mayapan"),
            new MayanRecord(11, 16, 13, 9, 12, "Mayapan"),
            new MayanRecord(11, 16, 13, 11, 4, "Mayapan"),
            new MayanRecord(11, 16, 13, 16, 4, "Mayapan"),
            new MayanRecord(11, 16, 15, 10, 13, "Mayapan"),
            new MayanRecord(11, 16, 15, 15, 5, "Mayapan"),
            new MayanRecord(11, 16, 17, 17, 15, "Mayapan"),
            new MayanRecord(11, 16, 19, 14, 0, "Mayapan"),
            new MayanRecord(11, 17, 3, 7, 8, "Mayapan"),
            new MayanRecord(11, 17, 7, 11, 14, "Mayapan"),
            new MayanRecord(11, 17, 13, 12, 4, "Mayapan"),
            new MayanRecord(11, 17, 19, 15, 14, "Mayapan"),
            new MayanRecord(11, 18, 4, 15, 13, "Gregorian?"),
            new MayanRecord(11, 18, 10, 14, 3, "Gregorian?"),
            new MayanRecord(11, 18, 14, 8, 4, "Gregorian?"),
            new MayanRecord(11, 18, 17, 1, 11, "Gregorian?"),
            new MayanRecord(11, 18, 17, 6, 18, "Gregorian?"),
            new MayanRecord(11, 19, 7, 3, 3, "Gregorian?"),
            new MayanRecord(11, 19, 12, 4, 14, "Gregorian?"),
            new MayanRecord(11, 19, 13, 7, 19, "Gregorian?"),
            new MayanRecord(11, 19, 14, 4, 4, "Gregorian?"),
            new MayanRecord(11, 19, 19, 14, 0, "Mayapan Baktun Ceremonial")
        };

        /// <summary>
        /// Mayan 
        /// </summary>
        public static readonly MayanRecord[] MayanDates12 =
        { 
            new MayanRecord(12, 0, 12, 17, 12, "Gregorian?"),
            new MayanRecord(12, 4, 9, 11, 6, "Gregorian?"),
            new MayanRecord(12, 5, 5, 2, 7, "Gregorian?"),
            new MayanRecord(12, 6, 15, 11, 19, "Gregorian?"),
            new MayanRecord(12, 7, 13, 12, 8, "Gregorian?"),
            new MayanRecord(12, 9, 0, 0, 0, "Correlation"),
            new MayanRecord(12, 11, 18, 17, 7, "Gregorian?"),
            new MayanRecord(12, 11, 19, 4, 9, "Gregorian?"),
            new MayanRecord(12, 15, 12, 17, 13, "Gregorian?"),
            new MayanRecord(12, 15, 16, 11, 19, "Gregorian?"),
            new MayanRecord(12, 15, 16, 15, 11, "Gregorian?"),
            new MayanRecord(12, 15, 18, 0, 18, "Gregorian?"),
            new MayanRecord(12, 16, 5, 3, 1, "Gregorian?"),
            new MayanRecord(12, 16, 6, 2, 17, "Gregorian?"),
            new MayanRecord(12, 16, 12, 4, 7, "Gregorian?"),
            new MayanRecord(12, 16, 15, 14, 7, "Gregorian?"),
            new MayanRecord(12, 16, 15, 14, 9, "Gregorian?"),
            new MayanRecord(12, 16, 2, 6, 17, "Gregorian?"),
            new MayanRecord(12, 17, 6, 9, 11, "Gregorian?"),
            ////   AddMayanDate(c,12,17, 8, 1, 5,  "Test Date"),
            new MayanRecord(12, 17, 13, 9, 12, "Gregorian?"),
            new MayanRecord(12, 18, 3, 12, 2, "Gregorian?"),
            new MayanRecord(12, 18, 5, 5, 14, "Gregorian?"),
            new MayanRecord(12, 18, 7, 13, 2, "Gregorian?"),
            new MayanRecord(12, 19, 13, 16, 0, "Round"),
            new MayanRecord(13, 2, 0, 0, 0, "Correlation")
        };

        #endregion

        /// <summary>
        /// Gets all mayan dates.
        /// </summary>
        /// <value>All mayan dates.</value>
        [UsedImplicitly]
        public static IEnumerable<MayanRecord> AllMayanDates {
            get {
                var list = new List<MayanRecord>();
                list.AddRange(MayanDatesSerpent);
                list.AddRange(MayanDatesFires);
                list.AddRange(MayanDatesRjs);
                list.AddRange(MayanDatesEquinox);
                list.AddRange(MayanDates819);
                list.AddRange(MayanDatesGodK);
                list.AddRange(MayanGridDates);
                list.AddRange(MayanDatesEjs);
                list.AddRange(MayanDatesJS);
                list.AddRange(MayanDates6);
                list.AddRange(MayanDates7);
                list.AddRange(MayanDates8);
                list.AddRange(MayanDates9);
                list.AddRange(MayanDates10);
                list.AddRange(MayanDates11);
                list.AddRange(MayanDates12);
                list.AddRange(MayanDatesMoon);

                return list;
            }
        }
    }
}

/* Jupiter-Saturn Triple Conjunctions (in Longitude) 563 B.C. to 3000 A.D
Year of Triple Years Until Next Conjunction Order of conjunction
563 - 562 B.C. 40
523 - 522 B.C. 377
146 - 145 B.C. 139 1 (146/145 BC)       1
7 B.C.         338      1 (0) 7 BC (17) 2
332 - 333 A.D.  79      2 (1)           3
411 - 412 A.D.  41      3               4
452 A.D.       257      4               5
709 - 710 A.D. 258      5               6
967 - 968 A.D.  40      6               7
1007 - 1008 A.D. 298     7               8
1305 - 1306 A.D. 20      8               9
1425 A.D. 257            9               10
1682 - 1683 A.D. 258     10              11
1940 - 1941 A.D.  40     11              12
1980 - 1981 A.D. 258     12(11)   (28)   13
2238 - 2239 A.D. 41      13              14
2279 A.D. 376            14              15
2655 - 2656 A.D. 139     15              16
2794 - 2795 A.D. 119     16              17
2913 - 2914 A.D. --      17              18
Reproduced from the   Planetarian , Vol. 10 #3, Third Quarter 1981.   Copyright 1981 International Planetarium Society. 
 */