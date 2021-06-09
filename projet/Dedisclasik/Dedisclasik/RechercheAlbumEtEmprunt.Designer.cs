
namespace Dedisclasik
{
    partial class RechercheAlbumEtEmprunt
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
            this.label1 = new System.Windows.Forms.Label();
            this.recherche = new System.Windows.Forms.TextBox();
            this.emprunter = new System.Windows.Forms.Button();
            this.MonCompte = new System.Windows.Forms.Button();
            this.pagesAlbums = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pagesAlbums)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "recherche";
            // 
            // recherche
            // 
            this.recherche.Location = new System.Drawing.Point(24, 99);
            this.recherche.Name = "recherche";
            this.recherche.Size = new System.Drawing.Size(114, 20);
            this.recherche.TabIndex = 2;
            this.recherche.TextChanged += new System.EventHandler(this.recherche_TextChanged);
            // 
            // emprunter
            // 
            this.emprunter.Location = new System.Drawing.Point(24, 394);
            this.emprunter.Name = "emprunter";
            this.emprunter.Size = new System.Drawing.Size(86, 23);
            this.emprunter.TabIndex = 3;
            this.emprunter.Text = "emprunter";
            this.emprunter.UseVisualStyleBackColor = true;
            this.emprunter.Click += new System.EventHandler(this.emprunter_Click);
            // 
            // MonCompte
            // 
            this.MonCompte.Location = new System.Drawing.Point(24, 28);
            this.MonCompte.Name = "MonCompte";
            this.MonCompte.Size = new System.Drawing.Size(85, 26);
            this.MonCompte.TabIndex = 4;
            this.MonCompte.Text = "mon compte";
            this.MonCompte.UseVisualStyleBackColor = true;
            this.MonCompte.Click += new System.EventHandler(this.MonCompte_Click);
            // 
            // pagesAlbums
            // 
            this.pagesAlbums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pagesAlbums.Location = new System.Drawing.Point(12, 125);
            this.pagesAlbums.MultiSelect = false;
            this.pagesAlbums.Name = "pagesAlbums";
            this.pagesAlbums.ReadOnly = true;
            this.pagesAlbums.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pagesAlbums.Size = new System.Drawing.Size(776, 253);
            this.pagesAlbums.TabIndex = 5;
            // 
            // RechercheAlbumEtEmprunt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pagesAlbums);
            this.Controls.Add(this.MonCompte);
            this.Controls.Add(this.emprunter);
            this.Controls.Add(this.recherche);
            this.Controls.Add(this.label1);
            this.Name = "RechercheAlbumEtEmprunt";
            this.Text = "RechercheAlbumEtEmprunt";
            ((System.ComponentModel.ISupportInitialize)(this.pagesAlbums)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox recherche;
        private System.Windows.Forms.Button emprunter;
        private System.Windows.Forms.Button MonCompte;
        private System.Windows.Forms.DataGridView pagesAlbums;
    }
}