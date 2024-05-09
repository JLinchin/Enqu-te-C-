namespace AppliQCM
{
    partial class FrmAccueil
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOuvrir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFermer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuValider = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFenetre = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHorizontale = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerticale = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAide = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuApropos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFichier,
            this.mnuFenetre,
            this.mnuAide});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFichier
            // 
            this.mnuFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOuvrir,
            this.mnuFermer,
            this.mnuSeparator,
            this.mnuValider,
            this.toolStripSeparator2,
            this.mnuQuitter});
            this.mnuFichier.Name = "mnuFichier";
            this.mnuFichier.Size = new System.Drawing.Size(54, 20);
            this.mnuFichier.Text = "Fichier";
            this.mnuFichier.Click += new System.EventHandler(this.mnuFichier_Click);
            // 
            // mnuOuvrir
            // 
            this.mnuOuvrir.Name = "mnuOuvrir";
            this.mnuOuvrir.Size = new System.Drawing.Size(111, 22);
            this.mnuOuvrir.Text = "Ouvrir";
            this.mnuOuvrir.Click += new System.EventHandler(this.mnuOuvrir_Click);
            // 
            // mnuFermer
            // 
            this.mnuFermer.Name = "mnuFermer";
            this.mnuFermer.Size = new System.Drawing.Size(111, 22);
            this.mnuFermer.Text = "Fermer";
            this.mnuFermer.Click += new System.EventHandler(this.mnuFermer_Click);
            // 
            // mnuSeparator
            // 
            this.mnuSeparator.Name = "mnuSeparator";
            this.mnuSeparator.Size = new System.Drawing.Size(108, 6);
            this.mnuSeparator.Visible = false;
            // 
            // mnuValider
            // 
            this.mnuValider.Name = "mnuValider";
            this.mnuValider.Size = new System.Drawing.Size(111, 22);
            this.mnuValider.Text = "Valider";
            this.mnuValider.Visible = false;
            this.mnuValider.Click += new System.EventHandler(this.mnuValider_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(108, 6);
            // 
            // mnuQuitter
            // 
            this.mnuQuitter.Name = "mnuQuitter";
            this.mnuQuitter.Size = new System.Drawing.Size(111, 22);
            this.mnuQuitter.Text = "Quitter";
            this.mnuQuitter.Click += new System.EventHandler(this.mnuQuitter_Click);
            // 
            // mnuFenetre
            // 
            this.mnuFenetre.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascade,
            this.mnuHorizontale,
            this.mnuVerticale});
            this.mnuFenetre.Name = "mnuFenetre";
            this.mnuFenetre.Size = new System.Drawing.Size(58, 20);
            this.mnuFenetre.Text = "Fenêtre";
            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(188, 22);
            this.mnuCascade.Text = "Cascade";
            this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
            // 
            // mnuHorizontale
            // 
            this.mnuHorizontale.Name = "mnuHorizontale";
            this.mnuHorizontale.Size = new System.Drawing.Size(188, 22);
            this.mnuHorizontale.Text = "Mosaïque horizontale";
            this.mnuHorizontale.Click += new System.EventHandler(this.mnuHorizontale_Click);
            // 
            // mnuVerticale
            // 
            this.mnuVerticale.Name = "mnuVerticale";
            this.mnuVerticale.Size = new System.Drawing.Size(188, 22);
            this.mnuVerticale.Text = "Mosaïque verticale";
            this.mnuVerticale.Click += new System.EventHandler(this.mnuVerticale_Click);
            // 
            // mnuAide
            // 
            this.mnuAide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuApropos});
            this.mnuAide.Name = "mnuAide";
            this.mnuAide.Size = new System.Drawing.Size(43, 20);
            this.mnuAide.Text = "Aide";
            // 
            // mnuApropos
            // 
            this.mnuApropos.Name = "mnuApropos";
            this.mnuApropos.Size = new System.Drawing.Size(131, 22);
            this.mnuApropos.Text = "A Propos...";
            // 
            // FrmAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmAccueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Enquêtes";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFichier;
        private System.Windows.Forms.ToolStripMenuItem mnuOuvrir;
        private System.Windows.Forms.ToolStripMenuItem mnuFermer;
        private System.Windows.Forms.ToolStripMenuItem mnuQuitter;
        private System.Windows.Forms.ToolStripMenuItem mnuFenetre;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuHorizontale;
        private System.Windows.Forms.ToolStripMenuItem mnuVerticale;
        private System.Windows.Forms.ToolStripMenuItem mnuAide;
        private System.Windows.Forms.ToolStripMenuItem mnuApropos;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator;
        private System.Windows.Forms.ToolStripMenuItem mnuValider;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

