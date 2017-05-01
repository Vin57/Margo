namespace Marguerite
{
    partial class fmMarguerite
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMarguerite));
            this.toolStripButtonChoisirTheme = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAnnulerTheme = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxThemes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.arbreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traduireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motDePasseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripButtonChoisirTheme
            // 
            this.toolStripButtonChoisirTheme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonChoisirTheme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonChoisirTheme.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonChoisirTheme.Image")));
            this.toolStripButtonChoisirTheme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChoisirTheme.Name = "toolStripButtonChoisirTheme";
            this.toolStripButtonChoisirTheme.Size = new System.Drawing.Size(89, 22);
            this.toolStripButtonChoisirTheme.Text = "Choisir theme";
            this.toolStripButtonChoisirTheme.Click += new System.EventHandler(this.toolStripButtonChoisirTheme_Click);
            // 
            // toolStripButtonAnnulerTheme
            // 
            this.toolStripButtonAnnulerTheme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAnnulerTheme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonAnnulerTheme.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAnnulerTheme.Image")));
            this.toolStripButtonAnnulerTheme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnnulerTheme.Name = "toolStripButtonAnnulerTheme";
            this.toolStripButtonAnnulerTheme.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonAnnulerTheme.Text = "Annuler thème";
            this.toolStripButtonAnnulerTheme.Click += new System.EventHandler(this.toolStripButtonAnnulerTheme_Click);
            // 
            // toolStripComboBoxThemes
            // 
            this.toolStripComboBoxThemes.Name = "toolStripComboBoxThemes";
            this.toolStripComboBoxThemes.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxThemes.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxThemes_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonChoisirTheme,
            this.toolStripButtonAnnulerTheme,
            this.toolStripComboBoxThemes,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1015, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arbreToolStripMenuItem,
            this.traduireToolStripMenuItem,
            this.motDePasseToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 22);
            this.toolStripDropDownButton1.Text = "Autres jeux";
            // 
            // arbreToolStripMenuItem
            // 
            this.arbreToolStripMenuItem.Name = "arbreToolStripMenuItem";
            this.arbreToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.arbreToolStripMenuItem.Text = "Compter";
            this.arbreToolStripMenuItem.Click += new System.EventHandler(this.arbreToolStripMenuItem_Click);
            // 
            // traduireToolStripMenuItem
            // 
            this.traduireToolStripMenuItem.Name = "traduireToolStripMenuItem";
            this.traduireToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.traduireToolStripMenuItem.Text = "ShiFuMi";
            this.traduireToolStripMenuItem.Click += new System.EventHandler(this.traduireToolStripMenuItem_Click);
            // 
            // motDePasseToolStripMenuItem
            // 
            this.motDePasseToolStripMenuItem.Name = "motDePasseToolStripMenuItem";
            this.motDePasseToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.motDePasseToolStripMenuItem.Text = "Mot de passe";
            this.motDePasseToolStripMenuItem.Click += new System.EventHandler(this.motDePasseToolStripMenuItem_Click);
            
            // 
            // fmMarguerite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1015, 703);
            this.Controls.Add(this.toolStrip1);
            this.MaximumSize = new System.Drawing.Size(1031, 742);
            this.MinimumSize = new System.Drawing.Size(1031, 726);
            this.Name = "fmMarguerite";
            this.Text = "Marguerite";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.fmMarguerite_Paint_1);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fmMarguerite_KeyPress);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButtonChoisirTheme;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnnulerTheme;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxThemes;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem arbreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traduireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motDePasseToolStripMenuItem;
    }
}

