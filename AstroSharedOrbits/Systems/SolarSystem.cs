// <copyright file="SolarSystem.cs" company="Traced-Ideas, Czech republic">
// Copyright (c) 1990-2021 All Right Reserved
// </copyright>
// <author> vl </author>
// <email></email>
// <date>2021-09-01</date>
// <summary>Part of Astro Observatory</summary>

namespace AstroSharedOrbits.Systems
{
    using AstroSharedClasses.Enums;
    using AstroSharedOrbits.Dwarfs;
    using AstroSharedOrbits.Planets;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>
    /// Solar System.
    /// </summary>
    /// <seealso cref="AstroSharedOrbits.PlanetarySystem" />
    public class SolarSystem : PlanetarySystem
    {
        #region Fields
        /// <summary>
        /// Singleton variable.
        /// </summary>
        private static SolarSystem singleton;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SolarSystem"/> class.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        public SolarSystem(string rootPath) : base()
        {
            Singleton = this;
            SystemManager.VsopPath = rootPath + "\\Data\\Vsop87\\";
            this.AddPlanets(AlgVariant.VarBretagnon87);
            this.ComputeTotalMass();

            //// 2018 OrbitPlanet = new Orbit[(int)AstPlanet.Count];
            //// 2018 OrbitMoon = new Orbit[(int)AstMoon.Count];
            this.Influences = false; //// Kalenda           
            this.Perturbations = false;
        }
        #endregion

        #region Static properties
        /// <summary>
        /// Gets the EditorLine Singleton.
        /// </summary>
        /// <value> Property description. </value>
        public static SolarSystem Singleton
        {
            get
            {
                Contract.Ensures(Contract.Result<SolarSystem>() != null);
                return singleton;
            }

            private set => singleton = value;
        }
        #endregion

        #region Public properties - planets 
        /// <summary>
        /// Gets Mercury.
        /// </summary>
        /// <value> Property description. </value>
        public BodyMercury Mercury { get; set; }

        /// <summary>
        /// Gets Venus.
        /// </summary>
        /// <value> Property description. </value>
        public BodyVenus Venus { get; set; }

        /// <summary>
        /// Gets Earth.
        /// </summary>
        /// <value> Property description. </value>
        public BodyEarth Earth { get; set; }

        /// <summary>
        /// Gets Mars.
        /// </summary>
        /// <value> Property description. </value>
        public BodyMars Mars { get; set; }

        /// <summary>
        /// Gets Jupiter.
        /// </summary>
        /// <value> Property description. </value>
        public BodyJupiter Jupiter { get; set; }

        /// <summary>
        /// Gets Saturn.
        /// </summary>
        /// <value> Property description. </value>
        public BodySaturn Saturn { get; set; }

        /// <summary>
        /// Gets Uranus.
        /// </summary>
        /// <value> Property description. </value>
        public BodyUranus Uranus { get; set; }

        /// <summary>
        /// Gets Neptune.
        /// </summary>
        /// <value> Property description. </value>
        public BodyNeptune Neptune { get; set; }

        //// public BodyPluto Pluto { get; set; }

        /// <summary>
        /// Gets the hypothetical X.
        /// </summary>
        /// <value> Property description. </value>
        public BodyHypos PlanetX { get; set; }

        #endregion

        #region Public properties - Dwarfs 
        /// <summary>
        /// Gets or sets the eris.
        /// </summary>
        /// <value>
        /// The eris.
        /// </value>
        public BodyEris Eris { get; set; }

        /// <summary>
        /// Gets or sets the haumea.
        /// </summary>
        /// <value>
        /// The haumea.
        /// </value>
        public BodyHaumea Haumea { get; set; }

        /// <summary>
        /// Gets or sets the makemake.
        /// </summary>
        /// <value>
        /// The makemake.
        /// </value>
        public BodyMakemake Makemake { get; set; }

        /// <summary>
        /// Gets or sets the orcus.
        /// </summary>
        /// <value>
        /// The orcus.
        /// </value>
        public BodyOrcus Orcus { get; set; }

        /// <summary>
        /// Gets or sets the quaoar.
        /// </summary>
        /// <value>
        /// The quaoar.
        /// </value>
        public BodyQuaoar Quaoar { get; set; }

        /// <summary>
        /// Gets or sets the salacia.
        /// </summary>
        /// <value>
        /// The salacia.
        /// </value>
        public BodySalacia Salacia { get; set; }

        /// <summary>
        /// Gets or sets the sedna.
        /// </summary>
        /// <value>
        /// The sedna.
        /// </value>
        public BodySedna Sedna { get; set; }

        /// <summary>
        /// Gets or sets the tn o1.
        /// </summary>
        /// <value>
        /// The tn o1.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public Body2012VP113 TNO1 { get; set; }

        /// <summary>
        /// Gets or sets the oileus.
        /// </summary>
        /// <value>
        /// The oileus.
        /// </value>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public Body9907Oileus Oileus { get; set; }

        #endregion

        /// <summary>
        /// Adjusts the x.
        /// </summary>
        /// <param name="period">The period.</param>
        /// <param name="phase">The phase.</param>
        /// <param name="massCoefficient">The mass coefficient.</param>
        /// <returns>Returns value.</returns>
        [JetBrains.Annotations.UsedImplicitlyAttribute]
        public BodyHypos AdjustX(float period, float phase, float massCoefficient)
        {
            var xo = (from o in this.Orbit where o.Body.Abbreviation == "X" select o).FirstOrDefault();
            if (xo != null)
            {
                this.Orbit.Remove(xo);
            }

            var x = new BodyHypos("X", "X", period, phase, (float) (massCoefficient * 5.975e24))
            {
                Enabled = true, Variant = AlgVariant.VarNormal
            };
            this.Orbit.Add(x);
            this.PlanetX = x;

            return x;
        }

        /// <summary>
        /// Adds the planets.
        /// </summary>
        /// <param name="variant">The variant.</param>
        private void AddPlanets(AlgVariant variant)
        {
            var m = new BodyMercury { Variant = variant};
            m.Init();
            this.Mercury = m;
            this.Orbit.Add(m);

            var v = new BodyVenus { Variant = variant};
            v.Init();
            this.Venus = v;
            this.Orbit.Add(v);

            var e = new BodyEarth { Variant = variant};
            e.Init();
            this.Earth = e;
            this.Orbit.Add(e);

            var r = new BodyMars { Variant = variant};
            r.Init();
            this.Mars = r;
            this.Orbit.Add(r);

            var j = new BodyJupiter { Variant = variant};
            j.Init();
            this.Jupiter = j;
            this.Orbit.Add(j);

            var s = new BodySaturn { Variant = variant};
            s.Init();
            this.Saturn = s;
            this.Orbit.Add(s);

            var u = new BodyUranus { Variant = variant};
            u.Init();
            this.Uranus = u;
            this.Orbit.Add(u);

            var n = new BodyNeptune { Variant = variant};
            n.Init();
            this.Neptune = n;
            this.Orbit.Add(n);

            //// 387.3
            this.AdjustX(385.5f, 102.0f, 6.0f); //// 575.5 # 323, 320, 335

            //// this.AdjustX(18918f, 67.0f, 4.65f); 

            /*
            var eris = new BodyEris {AlgVariant = AlgVariant.VarNormal};
            eris.Init();
            this.Eris = eris;
            this.Orbit.Add(eris);

            var haumea = new BodyHaumea();
            haumea.AlgVariant = AlgVariant.VarNormal;
            haumea.Init();
            this.Haumea = haumea;
            this.Orbit.Add(haumea);

            var makemake = new BodyMakemake();
            makemake.AlgVariant = AlgVariant.VarNormal;
            makemake.Init();
            this.Makemake = makemake;
            this.Orbit.Add(makemake);

            var orcus = new BodyOrcus();
            orcus.AlgVariant = AlgVariant.VarNormal;
            orcus.Init();
            this.Orcus = orcus;
            this.Orbit.Add(orcus);

            var quaoar = new BodyQuaoar();
            quaoar.AlgVariant = AlgVariant.VarNormal;
            quaoar.Init();
            this.Quaoar = quaoar;
            this.Orbit.Add(quaoar);

            var salacia = new BodySalacia();
            salacia.AlgVariant = AlgVariant.VarNormal;
            salacia.Init();
            this.Salacia = salacia;
            this.Orbit.Add(salacia);

            var sedna = new BodySedna();
            sedna.AlgVariant = AlgVariant.VarNormal;
            sedna.Init();
            this.Sedna = sedna;
            this.Orbit.Add(sedna);

            var tno1 = new Body2012VP113();
            tno1.AlgVariant = AlgVariant.VarNormal;
            tno1.Init();
            this.TNO1 = tno1;
            this.Orbit.Add(tno1);

            var oileus = new Body9907Oileus();
            oileus.AlgVariant = AlgVariant.VarNormal;
            oileus.Init();
            this.Oileus = oileus;
            this.Orbit.Add(oileus);
            */
            /*
            var p = new BodyPluto();
            p.AlgVariant = AlgVariant.VarNormal;
            p.Init();
            this.Pluto = p;
            this.Orbit.Add(p);

            this.OrbitForDipoles = new List<Orbit>();
            this.OrbitForDipoles.Add(j);
            this.OrbitForDipoles.Add(s);
            this.OrbitForDipoles.Add(n);
            this.OrbitForDipoles.Add(u);
            */
        }
    }
}

/*
//// this.AdjustX(387.0f, 157.0f, 10.0f); //// orig
//// this.AdjustX(387.0f, 97.0f, 10.0f); //// kalenda
//// this.AdjustX(387.0f, 52.0f, 10.0f); //// vukcevic
            
//// var x = new BodyHypos("X", "X", 387.30f, 157.3f, 8.8e25f);
//// 80.0 dg original graph, no 19.0 correction because of 1990 symmetry
//// 25 dg - like Kalenda
//// 350 dg = 90 dg back from 80 dg
//// this.AdjustX(385.47f, 350.0f, 4.0f);
//// this.AdjustX(385.47f, 60.0f, 4.0f); //// 3*385.5

//// this.AdjustX(387.5f, 110.0f, 4.0f);
//// this.AdjustX(711.0f, 110.0f, 4.0f);
//// this.AdjustX(805.0f, 110.0f, 4.0f);
//// this.AdjustX(372.0f, 240.0f, 4.0f);
//// this.AdjustX(651.0f, 160.0f, 4.0f);

//// AdjustX(300.0f, 70.0f, 4.0f);
//// AdjustX(310.0f, 60.0f, 5.0f);
//// AdjustX(490.0f, 170.0f, 5.0f);
//// AdjustX(460.0f, 160.0f, 5.0f);
//// AdjustX(16100.0f, 120.0f, 1.0f);
//// AdjustX(1990.0f, 90.0f, 10.0f);
*/

//// KALENDA BODY
//// var x = new BodyHypos("X", "X", 25725, 62.3f, (float)( * 5.975e24));
//// var x = new BodyHypos("X", "X", 25725, 169.8f, (float)(5 * 5.975e24));
//// var x = new BodyHypos("X", "X", 25725, -10.2f, (float)(4 * 5.975e24));

//// 158f
//// My BODY
//// var x = new BodyHypos("X", "X", 387.30f, -10.2f, (float)(1 * 5.975e24));
//// var x = new BodyHypos("X", "X", 2318.0f, -10.2f, (float)(10 * 5.975e24));
//// Planet X
//// 387.70f, 152.3f, 390.36f, 150.0f,  390.36f, 130.0f, 390.36f, 200.0f, 
//// 717.35f, 200.0f, 392.25f, 240.0f,  395 let 325 deg, 275 let, 202 deg
//// var x = new BodyHypos("X", "X", 387.30f, 157.3f, 8.8e25f);
//// var x = new BodyHypos("X", "X", 25725.0f, 0.0f, (float)(10*5.975e24));
//// var x = new BodyHypos("X", "X", 25725.0f, 0.0f, (float)(10*5.975e24));D:\Solutions\PrivateWPF\Largo2018\LargoWpfAstronomy\Astronomy\WinBarycentre.xaml

//// var sunJS = new BodySun("JS", (int)AstPlanet.Mercury, (int)AstPlanet.X); // AstPlanet.Saturn
//// var sun = new BodySun("US", (int)AstPlanet.Mercury, (int)AstPlanet.Neptune);
//// OrbitSun[(int)AstSun.Sun] = sun;
//// BodySun SunOuter  = new BodySun("OS", (int)AstPlanet.Jupiter, (int)AstPlanet.Neptune);   
//// OrbitSun[(int)AstSun.SunOuter]= SunOuter;
//// BodySun SunX  = new BodySun("XS", (int)AstPlanet.Mercury, (int)AstPlanet.X);
//// OrbitSun[(int)AstSun.SunX]= SunX;
//// Pluto  = new BodyPluto();    Body[9] = Pluto;
