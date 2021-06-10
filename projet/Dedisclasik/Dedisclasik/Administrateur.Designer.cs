
namespace Dedisclasik
{
    partial class Administrateur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrateur));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.deconnect = new System.Windows.Forms.Button();
            this.sousTitre = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.empruntsProlongés = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.consulterLesAbonnésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recherche = new System.Windows.Forms.TextBox();
            this.labelRecherche = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(954, 486);
            this.dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "Gestion administrateur";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // deconnect
            // 
            this.deconnect.BackColor = System.Drawing.SystemColors.Control;
            this.deconnect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deconnect.FlatAppearance.BorderSize = 0;
            this.deconnect.Location = new System.Drawing.Point(856, 28);
            this.deconnect.Name = "deconnect";
            this.deconnect.Size = new System.Drawing.Size(109, 24);
            this.deconnect.TabIndex = 9;
            this.deconnect.Text = "Se déconnecter";
            this.deconnect.UseVisualStyleBackColor = false;
            this.deconnect.Click += new System.EventHandler(this.deconnect_Click);
            // 
            // sousTitre
            // 
            this.sousTitre.AutoSize = true;
            this.sousTitre.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sousTitre.Location = new System.Drawing.Point(12, 82);
            this.sousTitre.Name = "sousTitre";
            this.sousTitre.Size = new System.Drawing.Size(204, 19);
            this.sousTitre.TabIndex = 10;
            this.sousTitre.Text = "Veuillez sélectionner une option";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(977, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empruntsProlongés,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(142, 22);
            this.toolStripDropDownButton2.Text = "Consulter les emprunts";
            // 
            // empruntsProlongés
            // 
            this.empruntsProlongés.Name = "empruntsProlongés";
            this.empruntsProlongés.Size = new System.Drawing.Size(262, 22);
            this.empruntsProlongés.Text = "Emprunts prolongés";
            this.empruntsProlongés.Click += new System.EventHandler(this.empruntsProlongésToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(262, 22);
            this.toolStripMenuItem2.Text = "Emprunts en retard";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.empruntsEnRetardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(262, 22);
            this.toolStripMenuItem3.Text = "Top 10 meilleurs emprunts";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.top10MeilleursEmpruntsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(262, 22);
            this.toolStripMenuItem4.Text = "Albums non empruntés depuis 1 an";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.albumsNonEmpruntésToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consulterLesAbonnésToolStripMenuItem,
            this.purgerToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(136, 22);
            this.toolStripDropDownButton1.Text = "Consulter les abonnés";
            // 
            // consulterLesAbonnésToolStripMenuItem
            // 
            this.consulterLesAbonnésToolStripMenuItem.Name = "consulterLesAbonnésToolStripMenuItem";
            this.consulterLesAbonnésToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.consulterLesAbonnésToolStripMenuItem.Text = "Lister tous les abonnés";
            this.consulterLesAbonnésToolStripMenuItem.Click += new System.EventHandler(this.consulterLesAbonnésToolStripMenuItem_Click);
            // 
            // purgerToolStripMenuItem
            // 
            this.purgerToolStripMenuItem.BackColor = System.Drawing.Color.LightCoral;
            this.purgerToolStripMenuItem.Name = "purgerToolStripMenuItem";
            this.purgerToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.purgerToolStripMenuItem.Text = "Purger les abonnés expirés";
            this.purgerToolStripMenuItem.Click += new System.EventHandler(this.purgerToolStripMenuItem_Click);
            // 
            // recherche
            // 
            this.recherche.Location = new System.Drawing.Point(723, 83);
            this.recherche.Name = "recherche";
            this.recherche.Size = new System.Drawing.Size(242, 20);
            this.recherche.TabIndex = 17;
            this.recherche.TextChanged += new System.EventHandler(this.recherche_TextChanged);
            // 
            // labelRecherche
            // 
            this.labelRecherche.AutoSize = true;
            this.labelRecherche.Location = new System.Drawing.Point(720, 67);
            this.labelRecherche.Name = "labelRecherche";
            this.labelRecherche.Size = new System.Drawing.Size(66, 13);
            this.labelRecherche.TabIndex = 18;
            this.labelRecherche.Text = "Recherche :";
            // 
            // Administrateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 607);
            this.Controls.Add(this.labelRecherche);
            this.Controls.Add(this.recherche);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.sousTitre);
            this.Controls.Add(this.deconnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Administrateur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrateur";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deconnect;
        private System.Windows.Forms.Label sousTitre;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem empruntsProlongés;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem consulterLesAbonnésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purgerToolStripMenuItem;
        private System.Windows.Forms.TextBox recherche;
        private System.Windows.Forms.Label labelRecherche;
    }
}