namespace EcoBreath
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.B_Monde = new System.Windows.Forms.PictureBox();
            this.B_Pays = new System.Windows.Forms.PictureBox();
            this.B_Zone = new System.Windows.Forms.PictureBox();
            this.B_GES = new System.Windows.Forms.PictureBox();
            this.B_Population = new System.Windows.Forms.PictureBox();
            this.B_Température = new System.Windows.Forms.PictureBox();
            this.B_Precipitation = new System.Windows.Forms.PictureBox();
            this.B_Mer = new System.Windows.Forms.PictureBox();
            this.B_ParPays = new System.Windows.Forms.PictureBox();
            this.B_ParContinent = new System.Windows.Forms.PictureBox();
            this.B_Valider = new System.Windows.Forms.PictureBox();
            this.B_Moyenne = new System.Windows.Forms.PictureBox();
            this.B_NombreJours = new System.Windows.Forms.PictureBox();
            this.B_Variation = new System.Windows.Forms.PictureBox();
            this.B_PIB = new System.Windows.Forms.PictureBox();
            this.B_ParSecteur = new System.Windows.Forms.PictureBox();
            this.B_ParSource = new System.Windows.Forms.PictureBox();
            this.C_Pays = new System.Windows.Forms.ComboBox();
            this.C_Zone = new System.Windows.Forms.ComboBox();
            this.L_Pays_Zone = new System.Windows.Forms.Label();
            this.L_1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.B_Monde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Pays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Zone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_GES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Population)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Température)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Precipitation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Mer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ParPays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ParContinent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Valider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Moyenne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_NombreJours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Variation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_PIB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ParSecteur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ParSource)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Monde
            // 
            this.B_Monde.BackgroundImage = global::EcoBreath.Properties.Resources.Monde;
            this.B_Monde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Monde.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Monde.Location = new System.Drawing.Point(112, 156);
            this.B_Monde.Name = "B_Monde";
            this.B_Monde.Size = new System.Drawing.Size(185, 69);
            this.B_Monde.TabIndex = 0;
            this.B_Monde.TabStop = false;
            this.B_Monde.Click += new System.EventHandler(this.B_Monde_Click);
            // 
            // B_Pays
            // 
            this.B_Pays.BackgroundImage = global::EcoBreath.Properties.Resources.Pays;
            this.B_Pays.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Pays.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Pays.Location = new System.Drawing.Point(112, 255);
            this.B_Pays.Name = "B_Pays";
            this.B_Pays.Size = new System.Drawing.Size(185, 69);
            this.B_Pays.TabIndex = 1;
            this.B_Pays.TabStop = false;
            this.B_Pays.Click += new System.EventHandler(this.B_Pays_Click);
            // 
            // B_Zone
            // 
            this.B_Zone.BackgroundImage = global::EcoBreath.Properties.Resources.ZoneSpecifique;
            this.B_Zone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Zone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Zone.Location = new System.Drawing.Point(112, 352);
            this.B_Zone.Name = "B_Zone";
            this.B_Zone.Size = new System.Drawing.Size(185, 69);
            this.B_Zone.TabIndex = 2;
            this.B_Zone.TabStop = false;
            this.B_Zone.Click += new System.EventHandler(this.B_Zone_Click);
            // 
            // B_GES
            // 
            this.B_GES.BackgroundImage = global::EcoBreath.Properties.Resources.GES;
            this.B_GES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_GES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_GES.Location = new System.Drawing.Point(500, 156);
            this.B_GES.Name = "B_GES";
            this.B_GES.Size = new System.Drawing.Size(185, 69);
            this.B_GES.TabIndex = 3;
            this.B_GES.TabStop = false;
            this.B_GES.Visible = false;
            this.B_GES.Click += new System.EventHandler(this.B_GES_Click);
            // 
            // B_Population
            // 
            this.B_Population.BackgroundImage = global::EcoBreath.Properties.Resources.Population;
            this.B_Population.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Population.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Population.Location = new System.Drawing.Point(500, 242);
            this.B_Population.Name = "B_Population";
            this.B_Population.Size = new System.Drawing.Size(185, 69);
            this.B_Population.TabIndex = 4;
            this.B_Population.TabStop = false;
            this.B_Population.Visible = false;
            this.B_Population.Click += new System.EventHandler(this.B_Population_Click);
            // 
            // B_Température
            // 
            this.B_Température.BackgroundImage = global::EcoBreath.Properties.Resources.Temperature;
            this.B_Température.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Température.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Température.Location = new System.Drawing.Point(500, 410);
            this.B_Température.Name = "B_Température";
            this.B_Température.Size = new System.Drawing.Size(185, 69);
            this.B_Température.TabIndex = 5;
            this.B_Température.TabStop = false;
            this.B_Température.Visible = false;
            this.B_Température.Click += new System.EventHandler(this.B_Température_Click);
            // 
            // B_Precipitation
            // 
            this.B_Precipitation.BackgroundImage = global::EcoBreath.Properties.Resources.Precipitation;
            this.B_Precipitation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Precipitation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Precipitation.Location = new System.Drawing.Point(500, 492);
            this.B_Precipitation.Name = "B_Precipitation";
            this.B_Precipitation.Size = new System.Drawing.Size(185, 69);
            this.B_Precipitation.TabIndex = 6;
            this.B_Precipitation.TabStop = false;
            this.B_Precipitation.Visible = false;
            this.B_Precipitation.Click += new System.EventHandler(this.B_Precipitation_Click);
            // 
            // B_Mer
            // 
            this.B_Mer.BackgroundImage = global::EcoBreath.Properties.Resources.Mer;
            this.B_Mer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Mer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Mer.Location = new System.Drawing.Point(500, 572);
            this.B_Mer.Name = "B_Mer";
            this.B_Mer.Size = new System.Drawing.Size(185, 69);
            this.B_Mer.TabIndex = 7;
            this.B_Mer.TabStop = false;
            this.B_Mer.Visible = false;
            this.B_Mer.Click += new System.EventHandler(this.B_Mer_Click);
            // 
            // B_ParPays
            // 
            this.B_ParPays.BackgroundImage = global::EcoBreath.Properties.Resources.ParPays;
            this.B_ParPays.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_ParPays.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_ParPays.Location = new System.Drawing.Point(894, 156);
            this.B_ParPays.Name = "B_ParPays";
            this.B_ParPays.Size = new System.Drawing.Size(185, 69);
            this.B_ParPays.TabIndex = 8;
            this.B_ParPays.TabStop = false;
            this.B_ParPays.Visible = false;
            this.B_ParPays.Click += new System.EventHandler(this.B_ParPays_Click);
            // 
            // B_ParContinent
            // 
            this.B_ParContinent.BackgroundImage = global::EcoBreath.Properties.Resources.ParContinent;
            this.B_ParContinent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_ParContinent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_ParContinent.Location = new System.Drawing.Point(894, 255);
            this.B_ParContinent.Name = "B_ParContinent";
            this.B_ParContinent.Size = new System.Drawing.Size(185, 69);
            this.B_ParContinent.TabIndex = 9;
            this.B_ParContinent.TabStop = false;
            this.B_ParContinent.Visible = false;
            this.B_ParContinent.Click += new System.EventHandler(this.B_ParContinent_Click);
            // 
            // B_Valider
            // 
            this.B_Valider.BackgroundImage = global::EcoBreath.Properties.Resources.Valider;
            this.B_Valider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Valider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Valider.Location = new System.Drawing.Point(894, 534);
            this.B_Valider.Name = "B_Valider";
            this.B_Valider.Size = new System.Drawing.Size(185, 69);
            this.B_Valider.TabIndex = 10;
            this.B_Valider.TabStop = false;
            this.B_Valider.Visible = false;
            this.B_Valider.Click += new System.EventHandler(this.B_Valider_Click);
            // 
            // B_Moyenne
            // 
            this.B_Moyenne.BackgroundImage = global::EcoBreath.Properties.Resources.Moyenne;
            this.B_Moyenne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Moyenne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Moyenne.Location = new System.Drawing.Point(894, 156);
            this.B_Moyenne.Name = "B_Moyenne";
            this.B_Moyenne.Size = new System.Drawing.Size(185, 69);
            this.B_Moyenne.TabIndex = 11;
            this.B_Moyenne.TabStop = false;
            this.B_Moyenne.Visible = false;
            this.B_Moyenne.Click += new System.EventHandler(this.B_Moyenne_Click);
            // 
            // B_NombreJours
            // 
            this.B_NombreJours.BackgroundImage = global::EcoBreath.Properties.Resources.NombreJours;
            this.B_NombreJours.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_NombreJours.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_NombreJours.Location = new System.Drawing.Point(894, 240);
            this.B_NombreJours.Name = "B_NombreJours";
            this.B_NombreJours.Size = new System.Drawing.Size(185, 97);
            this.B_NombreJours.TabIndex = 12;
            this.B_NombreJours.TabStop = false;
            this.B_NombreJours.Visible = false;
            this.B_NombreJours.Click += new System.EventHandler(this.B_NombreJours_Click);
            // 
            // B_Variation
            // 
            this.B_Variation.BackgroundImage = global::EcoBreath.Properties.Resources.Variation;
            this.B_Variation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Variation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_Variation.Location = new System.Drawing.Point(894, 352);
            this.B_Variation.Name = "B_Variation";
            this.B_Variation.Size = new System.Drawing.Size(185, 97);
            this.B_Variation.TabIndex = 13;
            this.B_Variation.TabStop = false;
            this.B_Variation.Visible = false;
            this.B_Variation.Click += new System.EventHandler(this.B_Variation_Click);
            // 
            // B_PIB
            // 
            this.B_PIB.BackgroundImage = global::EcoBreath.Properties.Resources.PIB;
            this.B_PIB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_PIB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_PIB.Location = new System.Drawing.Point(500, 327);
            this.B_PIB.Name = "B_PIB";
            this.B_PIB.Size = new System.Drawing.Size(185, 69);
            this.B_PIB.TabIndex = 14;
            this.B_PIB.TabStop = false;
            this.B_PIB.Visible = false;
            this.B_PIB.Click += new System.EventHandler(this.B_PIB_Click);
            // 
            // B_ParSecteur
            // 
            this.B_ParSecteur.BackgroundImage = global::EcoBreath.Properties.Resources.ParSecteur;
            this.B_ParSecteur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_ParSecteur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_ParSecteur.Location = new System.Drawing.Point(894, 156);
            this.B_ParSecteur.Name = "B_ParSecteur";
            this.B_ParSecteur.Size = new System.Drawing.Size(185, 69);
            this.B_ParSecteur.TabIndex = 15;
            this.B_ParSecteur.TabStop = false;
            this.B_ParSecteur.Visible = false;
            this.B_ParSecteur.Click += new System.EventHandler(this.B_ParSecteur_Click);
            // 
            // B_ParSource
            // 
            this.B_ParSource.BackgroundImage = global::EcoBreath.Properties.Resources.ParSource;
            this.B_ParSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_ParSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B_ParSource.Location = new System.Drawing.Point(894, 255);
            this.B_ParSource.Name = "B_ParSource";
            this.B_ParSource.Size = new System.Drawing.Size(185, 69);
            this.B_ParSource.TabIndex = 16;
            this.B_ParSource.TabStop = false;
            this.B_ParSource.Visible = false;
            this.B_ParSource.Click += new System.EventHandler(this.B_ParSource_Click);
            // 
            // C_Pays
            // 
            this.C_Pays.FormattingEnabled = true;
            this.C_Pays.Items.AddRange(new object[] {
            "France",
            "Allemagne",
            "Côte d\'Ivoire",
            "Chine",
            "Inde",
            "Etats-Unis",
            "Danemark"});
            this.C_Pays.Location = new System.Drawing.Point(112, 495);
            this.C_Pays.Name = "C_Pays";
            this.C_Pays.Size = new System.Drawing.Size(185, 23);
            this.C_Pays.TabIndex = 17;
            this.C_Pays.Text = "France";
            this.C_Pays.Visible = false;
            this.C_Pays.SelectedIndexChanged += new System.EventHandler(this.C_Pays_SelectedIndexChanged);
            // 
            // C_Zone
            // 
            this.C_Zone.FormattingEnabled = true;
            this.C_Zone.Items.AddRange(new object[] {
            "Europe",
            "Asie",
            "Afrique",
            "Océanie + Chine",
            "Amérique du nord",
            "Amérique du sud"});
            this.C_Zone.Location = new System.Drawing.Point(112, 495);
            this.C_Zone.Name = "C_Zone";
            this.C_Zone.Size = new System.Drawing.Size(185, 23);
            this.C_Zone.TabIndex = 18;
            this.C_Zone.Text = "Europe";
            this.C_Zone.Visible = false;
            this.C_Zone.SelectedIndexChanged += new System.EventHandler(this.C_Zone_SelectedIndexChanged);
            // 
            // L_Pays_Zone
            // 
            this.L_Pays_Zone.AutoSize = true;
            this.L_Pays_Zone.BackColor = System.Drawing.Color.White;
            this.L_Pays_Zone.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_Pays_Zone.Location = new System.Drawing.Point(123, 450);
            this.L_Pays_Zone.Name = "L_Pays_Zone";
            this.L_Pays_Zone.Padding = new System.Windows.Forms.Padding(2);
            this.L_Pays_Zone.Size = new System.Drawing.Size(158, 29);
            this.L_Pays_Zone.TabIndex = 19;
            this.L_Pays_Zone.Text = "Choisir un pays";
            this.L_Pays_Zone.Visible = false;
            // 
            // L_1
            // 
            this.L_1.AutoSize = true;
            this.L_1.BackColor = System.Drawing.Color.Transparent;
            this.L_1.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.L_1.Location = new System.Drawing.Point(146, 104);
            this.L_1.Name = "L_1";
            this.L_1.Padding = new System.Windows.Forms.Padding(2);
            this.L_1.Size = new System.Drawing.Size(111, 41);
            this.L_1.TabIndex = 20;
            this.L_1.Text = "Filtre 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(532, 104);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(114, 41);
            this.label1.TabIndex = 21;
            this.label1.Text = "Filtre 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(927, 104);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(114, 41);
            this.label2.TabIndex = 22;
            this.label2.Text = "Filtre 3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(375, 327);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2);
            this.label3.Size = new System.Drawing.Size(51, 41);
            this.label3.TabIndex = 23;
            this.label3.Text = "->";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(762, 327);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2);
            this.label4.Size = new System.Drawing.Size(51, 41);
            this.label4.TabIndex = 24;
            this.label4.Text = "->";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EcoBreath.Properties.Resources.BackLobby;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.L_1);
            this.Controls.Add(this.L_Pays_Zone);
            this.Controls.Add(this.C_Zone);
            this.Controls.Add(this.C_Pays);
            this.Controls.Add(this.B_ParSource);
            this.Controls.Add(this.B_ParSecteur);
            this.Controls.Add(this.B_PIB);
            this.Controls.Add(this.B_Variation);
            this.Controls.Add(this.B_NombreJours);
            this.Controls.Add(this.B_Moyenne);
            this.Controls.Add(this.B_Valider);
            this.Controls.Add(this.B_ParContinent);
            this.Controls.Add(this.B_ParPays);
            this.Controls.Add(this.B_Mer);
            this.Controls.Add(this.B_Precipitation);
            this.Controls.Add(this.B_Température);
            this.Controls.Add(this.B_Population);
            this.Controls.Add(this.B_GES);
            this.Controls.Add(this.B_Zone);
            this.Controls.Add(this.B_Pays);
            this.Controls.Add(this.B_Monde);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Form1";
            this.Text = "EcoBreath - Choix des filtres";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.B_Monde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Pays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Zone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_GES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Population)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Température)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Precipitation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Mer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ParPays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ParContinent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Valider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Moyenne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_NombreJours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Variation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_PIB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ParSecteur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ParSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox B_Monde;
        private PictureBox B_Pays;
        private PictureBox B_Zone;
        private PictureBox B_GES;
        private PictureBox B_Population;
        private PictureBox B_Température;
        private PictureBox B_Precipitation;
        private PictureBox B_Mer;
        private PictureBox B_ParPays;
        private PictureBox B_ParContinent;
        private PictureBox B_Valider;
        private PictureBox B_Moyenne;
        private PictureBox B_NombreJours;
        private PictureBox B_Variation;
        private PictureBox B_PIB;
        private PictureBox B_ParSecteur;
        private PictureBox B_ParSource;
        public ComboBox C_Pays;
        public ComboBox C_Zone;
        private Label L_Pays_Zone;
        private Label L_1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}