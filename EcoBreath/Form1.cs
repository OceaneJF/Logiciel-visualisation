namespace EcoBreath
{
    public partial class Form1 : Form
    {
        string ImageDirectory;
        string ScriptDirectory;
        AllScripts myScript;
        public Form1()
        {
            InitializeComponent();
            // Récupérer le répertoire de l'exécutable
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            baseDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\.."));

            // Naviguer vers le répertoire de projet en remontant de deux niveaux
            ImageDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"Resources\"));
            ScriptDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"ScriptPython\"));
            myScript = new AllScripts(baseDirectory);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SuprAllPicture();
        }

        //LES BOOLEENS
        //Filtre 1
        bool MondeCheck = false;
        bool PaysCheck = false;
        bool ZoneCheck = false;
        //Filtre 2
        bool GESCheck = false;
        bool PopulationCheck = false;
        bool TemperatureCheck = false;
        bool PrecipitationCheck = false;
        bool MerCheck = false;
        bool PIBCheck = false;
        //Filtre 3
        bool ParPaysCheck = false;
        bool ParContinentCheck = false;
        bool MoyenneCheck = false;
        bool NombreJoursCheck = false;
        bool VariationCheck = false;
        bool ParSecteurCheck = false;
        bool ParSourceCheck = false;

        //GESTION DES CLICKS
        private void B_Monde_Click(object sender, EventArgs e)
        {
            if (MondeCheck == false)
            {
                Close_All_Filter();
                B_Monde_Gestion(true);
                //Filtre 2
                B_GES_Gestion(true, false);
                B_Population_Gestion(true, false);
                B_PIB_Gestion(true, false);
                B_Temperature_Gestion(true, false);
                B_Precipitation_Gestion(true, false);
                //B_Mer_Gestion(true, false);
            }
            else
            {
                Close_All_Filter();
            }
        }
        private void B_Pays_Click(object sender, EventArgs e)
        {
            if (PaysCheck == false)
            {
                Close_All_Filter();
                B_Pays_Gestion(true);
                //Filtre 2     
                B_GES_Gestion(true, false);
                B_Population_Gestion(true, false);
                B_PIB_Gestion(true, false);
                L_Pays_Zone.Visible = true;
                L_Pays_Zone.Text = "Choisir un pays";
                C_Pays.Visible = true;
                C_Pays_SelectedIndexChanged(sender, e);
            }
            else
            {
                Close_All_Filter();
            }
        }
        private void B_Zone_Click(object sender, EventArgs e)
        {
            if(ZoneCheck == false)
            {
                Close_All_Filter();
                B_Zone_Gestion(true);
                B_GES_Gestion(true, false);
                B_Population_Gestion(true, false);
                B_PIB_Gestion(true, false);
                C_Zone.Visible = true;
                L_Pays_Zone.Visible = true;
                L_Pays_Zone.Text = "Choisir une zone";
                C_Zone_SelectedIndexChanged(sender, e);
            }
            else
            {
                Close_All_Filter();
            }
        }

        private void B_GES_Click(object sender, EventArgs e)
        {
            if(GESCheck == false)
            {
                B_GES_Gestion(true, true);
                if (MondeCheck)
                {
                    //Filtre même hauteur
                    B_Population_Gestion(true, false);
                    B_Temperature_Gestion(true, false);
                    B_PIB_Gestion(true, false);
                    B_Precipitation_Gestion(true, false);
                    //B_Mer_Gestion(true, false);
                    //Filtre 3
                    B_ParPays_Gestion(true, false);
                    B_ParContinent_Gestion(true, false);
                    B_Moyenne_Gestion(false, false);
                    B_NombreJours_Gestion(false, false);
                    B_Variation_Gestion(false, false);
                    B_Valider_gestion(false);
                }
                else if (PaysCheck)
                {
                    //Filtre même hauteur
                    B_Population_Gestion(true, false);
                    B_PIB_Gestion(true, false);
                    //Filtre 3
                    B_ParSecteur_Gestion(true, false);
                    B_ParSource_Gestion(true, false);
                    //Valider bouton
                    B_Valider_gestion(false);
                }
                else if (ZoneCheck)
                {
                    //Filtre même hauteur
                    B_Population_Gestion(true, false);
                    B_PIB_Gestion(true, false);
                    B_Valider_gestion(true);
                }
            }
            else
            {
                B_GES_Gestion(true, false);
                //Filtre 3
                B_ParPays_Gestion(false, false);
                B_ParContinent_Gestion(false, false);
                B_ParSecteur_Gestion(false, false);
                B_ParSource_Gestion(false, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        private void B_Population_Click(object sender, EventArgs e)
        {
            if (PopulationCheck == false)
            {
                B_Population_Gestion(true, true);
                if (MondeCheck)
                {
                    //Filtre même hauteur
                    B_GES_Gestion(true, false);
                    B_Temperature_Gestion(true, false);
                    B_PIB_Gestion(true, false);
                    B_Precipitation_Gestion(true, false);
                    //B_Mer_Gestion(true, false);
                    //Filtre 3
                    B_ParPays_Gestion(true, false);
                    B_ParContinent_Gestion(true, false);
                    B_Moyenne_Gestion(false, false);
                    B_NombreJours_Gestion(false, false);
                    B_Variation_Gestion(false, false);
                    B_Valider_gestion(false);
                }
                else if (PaysCheck)
                {
                    //Filtre même niveau
                    B_GES_Gestion(true, false);
                    B_PIB_Gestion(true, false);
                    //Filtre 3
                    B_ParSecteur_Gestion(false, false);
                    B_ParSource_Gestion(false, false);
                    //Valider bouton
                    B_Valider_gestion(true);
                }
                else if (ZoneCheck)
                {
                    //Filtre même hauteur
                    B_GES_Gestion(true, false);
                    B_PIB_Gestion(true, false);
                    //Valider bouton
                    B_Valider_gestion(true);
                }
            }
            else
            {
                B_Population_Gestion(true, false);
                //Filtre 3
                B_ParPays_Gestion(false, false);
                B_ParContinent_Gestion(false, false);
                B_Valider_gestion(false);
            }
        }
        private void B_Température_Click(object sender, EventArgs e)
        {
            if (TemperatureCheck == false)
            {
                B_Temperature_Gestion(true, true);
                //Filtre même hauteur
                B_GES_Gestion(true, false);
                B_Population_Gestion(true, false);
                B_PIB_Gestion(true, false);
                B_Precipitation_Gestion(true, false);
                //B_Mer_Gestion(true, false);
                //Filtre 3
                B_ParPays_Gestion(false, false);
                B_ParContinent_Gestion(false, false);
                B_Moyenne_Gestion(true, false);
                B_NombreJours_Gestion(true, false);
                B_Variation_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
            else
            {
                B_Temperature_Gestion(true, false);
                B_Moyenne_Gestion(false, false);
                B_NombreJours_Gestion(false, false);
                B_Variation_Gestion(false, false);
                B_Valider_gestion(false);
            }
        }
        private void B_Precipitation_Click(object sender, EventArgs e)
        {
            if(PrecipitationCheck == false)
            {
                B_Precipitation_Gestion(true, true);
                //Filtre même hauteur
                B_GES_Gestion(true, false);
                B_Population_Gestion(true, false);
                B_Temperature_Gestion(true, false);
                B_PIB_Gestion(true, false);
                //B_Mer_Gestion(true, false);
                //Filtre 3
                B_ParPays_Gestion(false, false);
                B_ParContinent_Gestion(false, false);
                B_Moyenne_Gestion(false, false);
                B_NombreJours_Gestion(false, false);
                B_Variation_Gestion(false, false);
                //Valider bouton
                B_Valider_gestion(true);
            }
            else
            {
                B_Precipitation_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        private void B_Mer_Click(object sender, EventArgs e)
        {
            if (MerCheck == false)
            {
                //B_Mer_Gestion(true, true);
                //Filtre même hauteur
                B_GES_Gestion(true, false);
                B_Population_Gestion(true, false);
                B_Temperature_Gestion(true, false);
                B_PIB_Gestion(true, false);
                B_Precipitation_Gestion(true, false);
                //Filtre 3
                B_ParPays_Gestion(false, false);
                B_ParContinent_Gestion(false, false);
                B_Moyenne_Gestion(false, false);
                B_NombreJours_Gestion(false, false);
                B_Variation_Gestion(false, false);
                //Valider bouton
                B_Valider_gestion(true);
            }
            else
            {
                //B_Mer_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        private void B_PIB_Click(object sender, EventArgs e)
        {
            if(PIBCheck == false)
            {
                B_PIB_Gestion(true, true);
                if (MondeCheck)
                {
                    //Filtre même hauteur
                    B_GES_Gestion(true, false);
                    B_Population_Gestion(true, false);
                    B_Temperature_Gestion(true, false);
                    B_Precipitation_Gestion(true, false);
                    //B_Mer_Gestion(true, false);
                    //Filtre 3
                    B_ParPays_Gestion(true, false);
                    B_ParContinent_Gestion(true, false);
                    B_Moyenne_Gestion(false, false);
                    B_NombreJours_Gestion(false, false);
                    B_Variation_Gestion(false, false);
                }
                else if (PaysCheck || ZoneCheck)
                {
                    //Filtre même hauteur
                    B_GES_Gestion(true, false);
                    B_Population_Gestion(true, false);
                    //Filtre 3
                    B_ParSource_Gestion(false, false);
                    B_ParSecteur_Gestion(false, false);
                    //Valider bouton
                    B_Valider_gestion(true);
                }   
            }
            else
            {
                B_PIB_Gestion(true, false);
                if (MondeCheck)
                {
                    //Filtre 3
                    B_ParPays_Gestion(false, false);
                    B_ParContinent_Gestion(false, false);
                    B_Moyenne_Gestion(false, false);
                    B_NombreJours_Gestion(false, false);
                    B_Variation_Gestion(false, false);
                    //Valider bouton
                    B_Valider_gestion(false);
                }
                else if (PaysCheck || ZoneCheck)
                {
                    //Valider bouton
                    B_Valider_gestion(false);
                }
            }
        }
        private void B_ParPays_Click(object sender, EventArgs e)
        {
            if (ParPaysCheck == false)
            {
                B_ParPays_Gestion(true, true);
                //Filtre même hauteur
                B_ParContinent_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(true);
            }
            else
            {
                B_ParPays_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        private void B_ParContinent_Click(object sender, EventArgs e)
        {
            if (ParContinentCheck == false)
            {
                B_ParContinent_Gestion(true, true);
                //Filtre même hauteur
                B_ParPays_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(true);
            }
            else
            {
                B_ParContinent_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        private void B_Moyenne_Click(object sender, EventArgs e)
        {
            if (MoyenneCheck == false)
            {
                B_Moyenne_Gestion(true, true);
                //Filtre même hauteur
                B_NombreJours_Gestion(true, false);
                B_Variation_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(true);
            }
            else
            {
                B_Moyenne_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        private void B_NombreJours_Click(object sender, EventArgs e)
        {
            if (NombreJoursCheck == false)
            {
                B_NombreJours_Gestion(true, true);
                //Filtre même hauteur
                B_Moyenne_Gestion(true, false);
                B_Variation_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(true);
            }
            else {
                B_NombreJours_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        private void B_Variation_Click(object sender, EventArgs e)
        {
            if(VariationCheck == false)
            {
                B_Variation_Gestion(true, true);
                //Filtre même hauteur
                B_Moyenne_Gestion(true, false);
                B_NombreJours_Gestion(true, false);
                //Valider Bouton
                B_Valider_gestion(true);
            }
            else
            {
                B_Variation_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        private void B_ParSecteur_Click(object sender, EventArgs e)
        {
            if (ParSecteurCheck == false)
            {
                B_ParSecteur_Gestion(true, true);
                //Filtre même hauteur
                B_ParSource_Gestion(true, false);
                //Valider Bouton
                B_Valider_gestion(true);
            }
            else
            {
                B_ParSecteur_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        private void B_ParSource_Click(object sender, EventArgs e)
        {
            if (ParSourceCheck == false)
            {
                B_ParSource_Gestion(true, true);
                //Filtre même hauteur
                B_ParSecteur_Gestion(true, false);
                //Valider Bouton
                B_Valider_gestion(true);
            }
            else
            {
                B_ParSource_Gestion(true, false);
                //Valider bouton
                B_Valider_gestion(false);
            }
        }
        //Envoie de la demande
        private void B_Valider_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            if (MondeCheck)
            {
                if (GESCheck)
                {
                    ChoixAnnee(f2);
                    if (ParPaysCheck)
                    {
                        Use_Script(f2, "map", "indicMondePays", "2020", "GHG");
                        Use_Script(f2, "box", "boxplotScript", "GHG", "2020");
                        f2.L_PasDeDetails.Visible = false;
                        f2.P_Graph.Visible = false;
                        f2.N_Année.Tag = 0;
                        f2.Text = "Carte choroplèthe des émissions de Gaz à Effet de Serre (GES)";
                    }
                    else if (ParContinentCheck)
                    {
                        Use_Script(f2, "map", "CarteMondeRegion", "2020", "GHG");
                        Use_Script(f2, "box", "statIndicator", "2020", "GHG");
                        f2.L_PasDeDetails.Visible = false;
                        f2.P_Graph.Visible = false;
                        f2.N_Année.Tag = 1;
                    }
                }
                else if (PopulationCheck)
                {
                    ChoixAnnee(f2);
                    Regression(f2, "Pop");
                    if (ParPaysCheck)
                    {
                        Use_Script(f2, "map", "indicMondePays", "2020", "POPULATION");
                        Use_Script(f2, "box", "boxplotScript", "POPULATION", "2020");
                        f2.L_PasDeDetails.Visible = false;
                        f2.P_Graph.Visible = false;
                        f2.N_Année.Tag = 2;
                    }
                    else if (ParContinentCheck)
                    {
                        Use_Script(f2, "map", "CarteMondeRegion", "2020", "POPULATION");
                        Use_Script(f2, "box", "statIndicator", "2020", "POPULATION");
                        f2.L_PasDeDetails.Visible = false;
                        f2.P_Graph.Visible = false;
                        f2.N_Année.Tag = 3;
                    }
                }
                else if (TemperatureCheck)
                {
                    if (MoyenneCheck)
                    {
                        Use_Script(f2, "map", "scriptGeoData", "MEANTEMP", "");
                        f2.P_Graph.Visible = false;
                    }
                    else if (NombreJoursCheck)
                    {
                        Use_Script(f2, "map", "scriptGeoData", "TX35", "");
                        f2.P_Graph.Visible = false;
                    }
                    else if (VariationCheck)
                    {
                        Use_Script(f2, "map", "scriptGeoData", "MEANTEMPCHANGE", "");
                        f2.P_Graph.Visible = false;
                    }
                }
                else if (PIBCheck)
                {
                    ChoixAnnee(f2);
                    Regression(f2, "PIB");
                    if (ParPaysCheck)
                    {
                        Use_Script(f2, "map", "indicMondePays", "2020", "GDP");
                        Use_Script(f2, "box", "boxplotScript", "GDP", "2020");
                        f2.L_PasDeDetails.Visible = false;
                        f2.P_Graph.Visible = false;
                        f2.N_Année.Tag = 4;
                    }
                    else if (ParContinentCheck)
                    {
                        Use_Script(f2, "map", "CarteMondeRegion", "2020", "GDP");
                        Use_Script(f2, "box", "statIndicator", "2020", "GDP");
                        f2.L_PasDeDetails.Visible = false;
                        f2.P_Graph.Visible = false;
                        f2.N_Année.Tag = 5;
                    }
                }
                else if (PrecipitationCheck)
                {
                    Use_Script(f2, "map", "scriptGeoData", "TOTALPRECIPIT", "");
                    f2.P_Graph.Visible = false;
                }
                else if (MerCheck)
                {
                    Use_Script(f2, "map", "scriptGeoData", "SEALVL", "");
                    f2.P_Graph.Visible = false;
                }
            }
            else if (ZoneCheck)
            {
                if (GESCheck)
                {
                    switch (C_Zone.Text)
                    {
                        case "Europe":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GHG", "Europe");
                            break;
                        case "Asie":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GHG", "Asia");
                            break;
                        case "Afrique":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GHG", "Africa");
                            break;
                        case "Océanie + Chine":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GHG", "Oceania");
                            break;
                        case "Amérique du nord":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GHG", "North_America");
                            break;
                        case "Amérique du sud":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GHG", "South_America");
                            break;
                    }
                }
                else if (PopulationCheck)
                {
                    switch (C_Zone.Text)
                    {
                        case "Europe":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "POPULATION", "Europe");
                            break;
                        case "Asie":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "POPULATION", "Asia");
                            break;
                        case "Afrique":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "POPULATION", "Africa");
                            break;
                        case "Océanie + Chine":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "POPULATION", "Oceania");
                            break;
                        case "Amérique du nord":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "POPULATION", "North_America");
                            break;
                        case "Amérique du sud":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "POPULATION", "South_America");
                            break;
                    }
                }
                else if (PIBCheck)
                {
                    switch (C_Zone.Text)
                    {
                        case "Europe":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GDP", "Europe");
                            break;
                        case "Asie":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GDP", "Asia");
                            break;
                        case "Afrique":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GDP", "Africa");
                            break;
                        case "Océanie + Chine":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GDP", "Oceania");
                            break;
                        case "Amérique du nord":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GDP", "North_America");
                            break;
                        case "Amérique du sud":
                            Use_Script(f2, "graph", "graphIndicateurRegion", "GDP", "South_America");
                            break;
                    }
                }
            }
            else if (PaysCheck)
            {
                if (GESCheck)
                {
                    if (ParSecteurCheck)
                    {
                        switch (C_Pays.Text)
                        {
                            case "France":
                                Use_Script(f2, "graph", "emissionSector", "FRA", "");
                                break;
                            case "Allemagne":
                                Use_Script(f2, "graph", "emissionSector", "DEU", "");
                                break;
                            case "Côte d'Ivoire":
                                Use_Script(f2, "graph", "emissionSector", "CIV", "");
                                break;
                            case "Chine":
                                Use_Script(f2, "graph", "emissionSector", "CHN", "");
                                break;
                            case "Inde":
                                Use_Script(f2, "graph", "emissionSector", "IND", "");
                                break;
                            case "Etats-Unis":
                                Use_Script(f2, "graph", "emissionSector", "USA", "");
                                break;
                            case "Danemark":
                                Use_Script(f2, "graph", "emissionSector", "DNK", "");
                                break;
                        }
                    }
                    else if (ParSourceCheck)
                    {
                        ChoixEmission(f2);
                        f2.L_PasDeDetails.Visible = false;
                        switch (C_Pays.Text)
                        {
                            case "France":
                                Use_Script(f2, "graph", "emissionSources", "FRA", "");
                                f2.PaysNom = "FRA";
                                break;
                            case "Allemagne":
                                Use_Script(f2, "graph", "emissionSources", "DEU", "");
                                f2.PaysNom = "DEU";
                                break;
                            case "Côte d'Ivoire":
                                Use_Script(f2, "graph", "emissionSources", "CIV", "");
                                f2.PaysNom = "CIV";
                                break;
                            case "Chine":
                                Use_Script(f2, "graph", "emissionSources", "CHN", "");
                                f2.PaysNom = "CHN";
                                break;
                            case "Inde":
                                Use_Script(f2, "graph", "emissionSources", "IND", "");
                                f2.PaysNom = "IND";
                                break;
                            case "Etats-Unis":
                                Use_Script(f2, "graph", "emissionSources", "USA", "");
                                f2.PaysNom = "USA";
                                break;
                            case "Danemark":
                                Use_Script(f2, "graph", "emissionSources", "DNK", "");
                                f2.PaysNom = "DNK";
                                break;
                        }
                    }
                }
                else if (PopulationCheck)
                {
                    switch (C_Pays.Text)
                    {
                        case "France":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "POPULATION", "FRA");
                            break;
                        case "Allemagne":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "POPULATION", "DEU");
                            break;
                        case "Côte d'Ivoire":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "POPULATION", "CIV");
                            break;
                        case "Chine":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "POPULATION", "CHN");
                            break;
                        case "Inde":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "POPULATION", "IND");
                            break;
                        case "Etats-Unis":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "POPULATION", "USA");
                            break;
                        case "Danemark":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "POPULATION", "DNK");
                            break;
                    }
                }
                else if (PIBCheck)
                {
                    switch (C_Pays.Text)
                    {
                        case "France":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "GDP", "FRA");
                            break;
                        case "Allemagne":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "GDP", "DEU");
                            break;
                        case "Côte d'Ivoire":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "GDP", "CIV");
                            break;
                        case "Chine":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "GDP", "CHN");
                            break;
                        case "Inde":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "GDP", "IND");
                            break;
                        case "Etats-Unis":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "GDP", "USA");
                            break;
                        case "Danemark":
                            Use_Script(f2, "graph", "scriptGraphIndicPaysYear", "GDP", "DNK");
                            break;
                    }
                }
            }
            f2.TopMost = false;
        }
        public void Use_Script(Form2 f2, string type, string script,string arg1, string arg2)
        {
            if (type == "map")
            {
                f2.P_Map.BackgroundImage = Image.FromFile(Path.Combine(ScriptDirectory, myScript.Appel_Script(script, arg1, arg2, ScriptDirectory)));
            }
            else if (type == "graph")
            {
                f2.P_Graph.BackgroundImage = Image.FromFile(Path.Combine(ScriptDirectory, myScript.Appel_Script(script, arg1, arg2, ScriptDirectory)));
            }
            else if(type == "box")
            {
                f2.P_Details.BackgroundImage = Image.FromFile(Path.Combine(ScriptDirectory, myScript.Appel_Script(script, arg1, arg2, ScriptDirectory)));
            }
        }

        private void C_Pays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(C_Pays.Text == "France" || C_Pays.Text == "Allemagne" || C_Pays.Text == "Côte d'Ivoire" || C_Pays.Text == "Chine" || C_Pays.Text == "Inde" || C_Pays.Text == "Etats-Unis"|| C_Pays.Text == "Danemark"))
            {
                B_GES_Gestion(false, false);
                B_Population_Gestion(false, false);
                B_PIB_Gestion(false, false);
                B_ParSecteur_Gestion(false, false);
                B_ParSource_Gestion(false, false);
                B_Valider_gestion(false);
            }
        }
        private void C_Zone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(C_Zone.Text == "Europe" || C_Zone.Text == "Afrique" || C_Zone.Text == "Asie" || C_Zone.Text == "Océanie + Chine" || C_Zone.Text == "Amérique du nord" || C_Zone.Text == "Amérique du sud"))
            {
                B_GES_Gestion(false, false);
                B_Population_Gestion(false, false);
                B_PIB_Gestion(false, false);
                B_Valider_gestion(false);
            }
        }


        //GESTION DES BOUTONS
        //Filtre 1
        private void B_Monde_Gestion(bool activate)
        {
            if (activate)
            {
                MondeCheck = true;
                B_Monde.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_Monde.png"));
            }
            else
            {
                MondeCheck = false;
                B_Monde.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "Monde.png"));

            }
        }
        private void B_Pays_Gestion(bool activate)
        {
            if (activate)
            {
                PaysCheck = true;
                B_Pays.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_Pays.png"));
            }
            else
            {
                PaysCheck = false;
                B_Pays.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "Pays.png"));

            }
        }
        private void B_Zone_Gestion(bool activate)
        {
            if (activate)
            {
                ZoneCheck = true;
                B_Zone.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_ZoneSpecifique.png"));
            }
            else
            {
                ZoneCheck = false;
                B_Zone.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "ZoneSpecifique.png"));

            }
        }


        //Filtre 2
        private void B_GES_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_GES.Visible = true;
            }
            else
            {
                B_GES.Visible = false;
            }
            if (activate)
            {
                GESCheck = true;
                B_GES.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_GES.png"));
            }
            else
            {
                GESCheck = false;
                B_GES.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "GES.png"));
            }
        }
        private void B_Population_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_Population.Visible = true;
            }
            else
            {
                B_Population.Visible = false;
            }
            if (activate)
            {
                PopulationCheck = true;
                B_Population.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_Population.png"));
            }
            else
            {
                PopulationCheck = false;
                B_Population.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "Population.png"));
            }
        }
        private void B_Temperature_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_Température.Visible = true;
            }
            else
            {
                B_Température.Visible = false;
            }
            if (activate)
            {
                TemperatureCheck = true;
                B_Température.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_Temperature.png"));
            }
            else
            {
                TemperatureCheck = false;
                B_Température.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "Temperature.png"));
            }
        }
        private void B_Precipitation_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_Precipitation.Visible = true;
            }
            else
            {
                B_Precipitation.Visible = false;
            }
            if (activate)
            {
                PrecipitationCheck = true;
                B_Precipitation.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_Precipitation.png"));
            }
            else
            {
                PrecipitationCheck = false;
                B_Precipitation.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "Precipitation.png"));
            }
        }
        private void B_Mer_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_Mer.Visible = true;
            }
            else
            {
                B_Mer.Visible = false;
            }
            if (activate)
            {
                MerCheck = true;
                B_Mer.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_Mer.png"));
            }
            else
            {
                MerCheck = false;
                B_Mer.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "Mer.png"));
            }
        }
        private void B_PIB_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_PIB.Visible = true;
            }
            else
            {
                B_PIB.Visible = false;
            }
            if (activate)
            {
                PIBCheck = true;
                B_PIB.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_PIB.png"));
            }
            else
            {
                PIBCheck = false;
                B_PIB.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "PIB.png"));
            }
        }


        //Filtre 3
        private void B_ParPays_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_ParPays.Visible = true;
            }
            else
            {
                B_ParPays.Visible = false;
            }
            if (activate)
            {
                ParPaysCheck = true;
                B_ParPays.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_ParPays.png"));
            }
            else
            {
                ParPaysCheck = false;
                B_ParPays.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "ParPays.png"));
            }
        }
        private void B_ParContinent_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_ParContinent.Visible = true;
            }
            else
            {
                B_ParContinent.Visible = false;
            }
            if (activate)
            {
                ParContinentCheck = true;
                B_ParContinent.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_ParContinent.png"));
            }
            else
            {
                ParContinentCheck = false;
                B_ParContinent.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "ParContinent.png"));
            }
        }
        private void B_Moyenne_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_Moyenne.Visible = true;
            }
            else
            {
                B_Moyenne.Visible = false;
            }
            if (activate)
            {
                MoyenneCheck = true;
                B_Moyenne.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_Moyenne.png"));
            }
            else
            {
                MoyenneCheck = false;
                B_Moyenne.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "Moyenne.png"));
            }
        }
        private void B_NombreJours_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_NombreJours.Visible = true;
            }
            else
            {
                B_NombreJours.Visible = false;
            }
            if (activate)
            {
                NombreJoursCheck = true;
                B_NombreJours.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_NombreJours.png"));
            }
            else
            {
                NombreJoursCheck = false;
                B_NombreJours.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "NombreJours.png"));
            }
        }
        private void B_Variation_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_Variation.Visible = true;
            }
            else
            {
                B_Variation.Visible = false;
            }
            if (activate)
            {
                VariationCheck = true;
                B_Variation.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_variation.png"));
            }
            else
            {
                VariationCheck = false;
                B_Variation.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "Variation.png"));
            }
        }
        private void B_ParSecteur_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_ParSecteur.Visible = true;
            }
            else
            {
                B_ParSecteur.Visible = false;
            }
            if (activate)
            {
                ParSecteurCheck = true;
                B_ParSecteur.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_ParSecteur.png"));
            }
            else
            {
                ParSecteurCheck = false;
                B_ParSecteur.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "ParSecteur.png"));
            }
        }
        private void B_ParSource_Gestion(bool visibility, bool activate)
        {
            if (visibility)
            {
                B_ParSource.Visible = true;
            }
            else
            {
                B_ParSource.Visible = false;
            }
            if (activate)
            {
                ParSourceCheck = true;
                B_ParSource.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "C_ParSource.png"));
            }
            else
            {
                ParSourceCheck = false;
                B_ParSource.BackgroundImage = Image.FromFile(Path.Combine(ImageDirectory, "ParSource.png"));
            }
        }

        //Valider
        private void B_Valider_gestion(bool activate)
        {
            if (activate)
            {
                B_Valider.Visible = true;
            }
            else
            {
                B_Valider.Visible = false;
            }
        }

        //Global
        private void Close_All_Filter()
        {
            B_Monde_Gestion(false);
            B_Pays_Gestion(false);
            B_Zone_Gestion(false);
            B_GES_Gestion(false, false);
            B_Population_Gestion(false, false);
            B_Temperature_Gestion(false, false);
            B_Precipitation_Gestion(false, false);
            B_Mer_Gestion(false, false);
            B_PIB_Gestion(false, false);
            B_ParPays_Gestion(false,false);
            B_ParContinent_Gestion(false, false);
            B_Moyenne_Gestion(false, false);
            B_NombreJours_Gestion(false, false);
            B_Variation_Gestion(false, false);
            B_ParSecteur_Gestion(false, false);
            B_ParSource_Gestion(false, false);
            B_Valider_gestion(false);
            C_Pays.Visible = false;
            C_Pays.Text = "France";
            C_Zone.Visible = false;
            C_Zone.Text = "Europe";
            L_Pays_Zone.Visible = false;
        }

        //Filtre de la Page 2
        private void ChoixAnnee(Form2 f2)
        {
            f2.N_Année.Visible = true;
            f2.B_ValiderAnnée.Visible = true;
            f2.ChoixAnneeCheck = true;
            f2.L_FiltreSup.Visible = true;
            f2.L_FiltreSup.Text = "Choix de l'année";
        }
        private void ChoixEmission(Form2 f2)
        {
            f2.C_FiltreSup.Visible = true;
            f2.B_ValiderAnnée.Visible = true;
            f2.ChoixDonneeCheck = true;
            f2.L_FiltreSup.Visible = true;
            f2.L_FiltreSup.Text = "Choix de la donnée";
        }
        private void Regression(Form2 f2, string value)
        {
            f2.B_Regression.Visible = true;
            switch (value)
            {
                case "Pop":
                    f2.RegPop = true;
                    break;
                case "PIB":
                    f2.RegPIB = true;
                    break;
            }
        }

        //Supprime les photos au lancement
        public void SuprAllPicture()
        {
            string imageExtensions = "*.png";
            string[] files = Directory.GetFiles(ScriptDirectory, imageExtensions);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
    }
}