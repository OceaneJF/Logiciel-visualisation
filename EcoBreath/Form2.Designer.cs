namespace EcoBreath
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.P_Map = new System.Windows.Forms.PictureBox();
            this.P_Details = new System.Windows.Forms.PictureBox();
            this.P_Graph = new System.Windows.Forms.PictureBox();
            this.N_Année = new System.Windows.Forms.NumericUpDown();
            this.B_ValiderAnnée = new System.Windows.Forms.PictureBox();
            this.B_ChangerFiltres = new System.Windows.Forms.PictureBox();
            this.L_FiltreSup = new System.Windows.Forms.Label();
            this.C_FiltreSup = new System.Windows.Forms.ComboBox();
            this.B_Regression = new System.Windows.Forms.PictureBox();
            this.L_PasDeDetails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.P_Map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_Details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_Graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_Année)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ValiderAnnée)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ChangerFiltres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Regression)).BeginInit();
            this.SuspendLayout();
            // 
            // P_Map
            // 
            this.P_Map.BackColor = System.Drawing.Color.Transparent;
            this.P_Map.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_Map.Location = new System.Drawing.Point(208, -47);
            this.P_Map.Name = "P_Map";
            this.P_Map.Size = new System.Drawing.Size(1053, 664);
            this.P_Map.TabIndex = 0;
            this.P_Map.TabStop = false;
            // 
            // P_Details
            // 
            this.P_Details.BackColor = System.Drawing.Color.Transparent;
            this.P_Details.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_Details.Location = new System.Drawing.Point(55, 166);
            this.P_Details.Name = "P_Details";
            this.P_Details.Size = new System.Drawing.Size(296, 296);
            this.P_Details.TabIndex = 1;
            this.P_Details.TabStop = false;
            // 
            // P_Graph
            // 
            this.P_Graph.BackColor = System.Drawing.Color.Transparent;
            this.P_Graph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_Graph.Location = new System.Drawing.Point(379, 166);
            this.P_Graph.Name = "P_Graph";
            this.P_Graph.Size = new System.Drawing.Size(740, 427);
            this.P_Graph.TabIndex = 2;
            this.P_Graph.TabStop = false;
            // 
            // N_Année
            // 
            this.N_Année.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.N_Année.Location = new System.Drawing.Point(81, 496);
            this.N_Année.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.N_Année.Minimum = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.N_Année.Name = "N_Année";
            this.N_Année.Size = new System.Drawing.Size(121, 29);
            this.N_Année.TabIndex = 4;
            this.N_Année.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.N_Année.Visible = false;
            // 
            // B_ValiderAnnée
            // 
            this.B_ValiderAnnée.BackgroundImage = global::EcoBreath.Properties.Resources.Valider;
            this.B_ValiderAnnée.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_ValiderAnnée.Location = new System.Drawing.Point(223, 488);
            this.B_ValiderAnnée.Name = "B_ValiderAnnée";
            this.B_ValiderAnnée.Size = new System.Drawing.Size(112, 42);
            this.B_ValiderAnnée.TabIndex = 5;
            this.B_ValiderAnnée.TabStop = false;
            this.B_ValiderAnnée.Visible = false;
            this.B_ValiderAnnée.Click += new System.EventHandler(this.B_ValiderAnnée_Click);
            // 
            // B_ChangerFiltres
            // 
            this.B_ChangerFiltres.BackgroundImage = global::EcoBreath.Properties.Resources.FermerLaPage;
            this.B_ChangerFiltres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_ChangerFiltres.Location = new System.Drawing.Point(987, 15);
            this.B_ChangerFiltres.Name = "B_ChangerFiltres";
            this.B_ChangerFiltres.Size = new System.Drawing.Size(185, 69);
            this.B_ChangerFiltres.TabIndex = 7;
            this.B_ChangerFiltres.TabStop = false;
            this.B_ChangerFiltres.Click += new System.EventHandler(this.B_ChangerFiltres_Click);
            // 
            // L_FiltreSup
            // 
            this.L_FiltreSup.AutoSize = true;
            this.L_FiltreSup.BackColor = System.Drawing.Color.Transparent;
            this.L_FiltreSup.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_FiltreSup.Location = new System.Drawing.Point(66, 457);
            this.L_FiltreSup.Name = "L_FiltreSup";
            this.L_FiltreSup.Size = new System.Drawing.Size(183, 30);
            this.L_FiltreSup.TabIndex = 11;
            this.L_FiltreSup.Text = "Choix de l\'année";
            this.L_FiltreSup.Visible = false;
            this.L_FiltreSup.Click += new System.EventHandler(this.L_FiltreSup_Click);
            // 
            // C_FiltreSup
            // 
            this.C_FiltreSup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.C_FiltreSup.FormattingEnabled = true;
            this.C_FiltreSup.Items.AddRange(new object[] {
            "Emission",
            "Production",
            "Consommation"});
            this.C_FiltreSup.Location = new System.Drawing.Point(69, 496);
            this.C_FiltreSup.Name = "C_FiltreSup";
            this.C_FiltreSup.Size = new System.Drawing.Size(133, 29);
            this.C_FiltreSup.TabIndex = 15;
            this.C_FiltreSup.Text = "Emission";
            this.C_FiltreSup.Visible = false;
            // 
            // B_Regression
            // 
            this.B_Regression.BackgroundImage = global::EcoBreath.Properties.Resources.Regression;
            this.B_Regression.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Regression.Location = new System.Drawing.Point(107, 542);
            this.B_Regression.Name = "B_Regression";
            this.B_Regression.Size = new System.Drawing.Size(188, 50);
            this.B_Regression.TabIndex = 16;
            this.B_Regression.TabStop = false;
            this.B_Regression.Visible = false;
            this.B_Regression.Click += new System.EventHandler(this.B_Regression_Click);
            // 
            // L_PasDeDetails
            // 
            this.L_PasDeDetails.AutoSize = true;
            this.L_PasDeDetails.BackColor = System.Drawing.Color.Transparent;
            this.L_PasDeDetails.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_PasDeDetails.Location = new System.Drawing.Point(107, 303);
            this.L_PasDeDetails.Name = "L_PasDeDetails";
            this.L_PasDeDetails.Size = new System.Drawing.Size(198, 37);
            this.L_PasDeDetails.TabIndex = 17;
            this.L_PasDeDetails.Text = "Pas de détails";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EcoBreath.Properties.Resources.BackMap;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.L_PasDeDetails);
            this.Controls.Add(this.B_Regression);
            this.Controls.Add(this.B_ValiderAnnée);
            this.Controls.Add(this.C_FiltreSup);
            this.Controls.Add(this.L_FiltreSup);
            this.Controls.Add(this.B_ChangerFiltres);
            this.Controls.Add(this.N_Année);
            this.Controls.Add(this.P_Graph);
            this.Controls.Add(this.P_Details);
            this.Controls.Add(this.P_Map);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Form2";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.P_Map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_Details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_Graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_Année)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ValiderAnnée)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_ChangerFiltres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Regression)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public PictureBox P_Map;
        public PictureBox P_Details;
        public PictureBox P_Graph;
        public NumericUpDown N_Année;
        public PictureBox B_ValiderAnnée;
        public PictureBox B_ChangerFiltres;
        public Label L_FiltreSup;
        public ComboBox C_FiltreSup;
        public PictureBox B_Regression;
        public Label L_PasDeDetails;
    }
}