using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoBreath
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public bool ChoixAnneeCheck = false;
        public bool ChoixDonneeCheck = false;
        public string PaysNom = "";
        public bool RegPop = false;
        public bool RegPIB = false;
        public bool RegActivated = false;

        private void B_ValiderAnnée_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            decimal value = N_Année.Value;
            if (ChoixAnneeCheck)
            {
                switch (N_Année.Tag)
                {
                    case 0:
                        f1.Use_Script(this, "map", "indicMondePays", value.ToString(), "GHG");
                        f1.Use_Script(this, "box", "boxplotScript", "GHG", value.ToString());
                        break;
                    case 1:
                        f1.Use_Script(this, "map", "CarteMondeRegion", value.ToString(), "GHG");
                        f1.Use_Script(this, "box", "statIndicator", value.ToString(), "GHG");
                        break;
                    case 2:
                        f1.Use_Script(this, "map", "indicMondePays", value.ToString(), "POPULATION");
                        f1.Use_Script(this, "box", "boxplotScript", "POPULATION", value.ToString());
                        break;
                    case 3:
                        f1.Use_Script(this, "map", "CarteMondeRegion", value.ToString(), "POPULATION");
                        f1.Use_Script(this, "box", "statIndicator", value.ToString(), "POPULATION");
                        break;
                    case 4:
                        f1.Use_Script(this, "map", "indicMondePays", value.ToString(), "GDP");
                        f1.Use_Script(this, "box", "boxplotScript", "GDP", value.ToString());
                        break;
                    case 5:
                        f1.Use_Script(this, "map", "CarteMondeRegion", value.ToString(), "GDP");
                        f1.Use_Script(this, "box", "statIndicator", value.ToString(), "GDP");
                        break;
                }
            }
            else if (ChoixDonneeCheck)
            {
                switch (C_FiltreSup.Text)
                {
                    case "Emission":
                        f1.Use_Script(this, "graph", "emissionSources", PaysNom, "");
                        break;
                    case "Production":
                        f1.Use_Script(this, "graph", "soucesProduction", PaysNom, "");
                        break;
                    case "Consommation":
                        f1.Use_Script(this, "graph", "sourcesConsumption", PaysNom, "");
                        break;
                }
            }
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChoixAnneeCheck = false;
            ChoixDonneeCheck = false;
            PaysNom = "";
            RegPop = false;
            RegPIB = false;
        }

        private void B_Regression_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            if (!RegActivated)
            {
                RegActivated = true;
                if (RegPop)
                {
                    P_Map.Visible = false;
                    P_Graph.Visible = true;
                    f1.Use_Script(this, "graph", "regLinPop", "", "");
                }
                else if (RegPIB)
                {
                    P_Map.Visible = false;
                    P_Graph.Visible = true;
                    f1.Use_Script(this, "graph", "regLinPIB", "", "");
                }
            }
            else
            {
                RegActivated = false;
                if (RegPop)
                {
                    P_Map.Visible = true;
                    P_Graph.Visible = false;
                }
                else if (RegPIB)
                {
                    P_Map.Visible = true;
                    P_Graph.Visible = false;
                }
            }
            
        }

        private void B_ChangerFiltres_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void L_FiltreSup_Click(object sender, EventArgs e)
        {

        }
    }
}
