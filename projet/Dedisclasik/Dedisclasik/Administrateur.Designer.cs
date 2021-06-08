
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
            this.empruntProlong = new System.Windows.Forms.Button();
            this.purger = new System.Windows.Forms.Button();
            this.empruntRetard = new System.Windows.Forms.Button();
            this.empruntMeilleurs = new System.Windows.Forms.Button();
            this.albumsNonEmprunts = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.deconnect = new System.Windows.Forms.Button();
            this.sousTitre = new System.Windows.Forms.Label();
            this.listAbo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // empruntProlong
            // 
            this.empruntProlong.Location = new System.Drawing.Point(12, 546);
            this.empruntProlong.Name = "empruntProlong";
            this.empruntProlong.Size = new System.Drawing.Size(154, 49);
            this.empruntProlong.TabIndex = 0;
            this.empruntProlong.Text = "EMPRUNTS PROLONGÉS";
            this.empruntProlong.UseVisualStyleBackColor = true;
            this.empruntProlong.Click += new System.EventHandler(this.empruntProlong_Click);
            // 
            // purger
            // 
            this.purger.BackColor = System.Drawing.Color.LightCoral;
            this.purger.Location = new System.Drawing.Point(812, 546);
            this.purger.Name = "purger";
            this.purger.Size = new System.Drawing.Size(154, 49);
            this.purger.TabIndex = 1;
            this.purger.Text = "PURGER ABONNÉS";
            this.purger.UseVisualStyleBackColor = false;
            this.purger.Click += new System.EventHandler(this.purger_Click);
            // 
            // empruntRetard
            // 
            this.empruntRetard.Location = new System.Drawing.Point(172, 546);
            this.empruntRetard.Name = "empruntRetard";
            this.empruntRetard.Size = new System.Drawing.Size(154, 49);
            this.empruntRetard.TabIndex = 2;
            this.empruntRetard.Text = "EMPRUNTS EN RETARD";
            this.empruntRetard.UseVisualStyleBackColor = true;
            this.empruntRetard.Click += new System.EventHandler(this.empruntRetard_Click);
            // 
            // empruntMeilleurs
            // 
            this.empruntMeilleurs.Location = new System.Drawing.Point(332, 546);
            this.empruntMeilleurs.Name = "empruntMeilleurs";
            this.empruntMeilleurs.Size = new System.Drawing.Size(154, 49);
            this.empruntMeilleurs.TabIndex = 3;
            this.empruntMeilleurs.Text = "TOP 10 ALBUMS";
            this.empruntMeilleurs.UseVisualStyleBackColor = true;
            this.empruntMeilleurs.Click += new System.EventHandler(this.empruntMeilleurs_Click);
            // 
            // albumsNonEmprunts
            // 
            this.albumsNonEmprunts.Location = new System.Drawing.Point(492, 546);
            this.albumsNonEmprunts.Name = "albumsNonEmprunts";
            this.albumsNonEmprunts.Size = new System.Drawing.Size(154, 49);
            this.albumsNonEmprunts.TabIndex = 5;
            this.albumsNonEmprunts.Text = "ALBUMS NON EMPRUNTÉS";
            this.albumsNonEmprunts.UseVisualStyleBackColor = true;
            this.albumsNonEmprunts.Click += new System.EventHandler(this.albumsNonEmprunts_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(954, 449);
            this.dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
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
            this.deconnect.Location = new System.Drawing.Point(856, 12);
            this.deconnect.Name = "deconnect";
            this.deconnect.Size = new System.Drawing.Size(109, 34);
            this.deconnect.TabIndex = 9;
            this.deconnect.Text = "Se déconnecter";
            this.deconnect.UseVisualStyleBackColor = false;
            this.deconnect.Click += new System.EventHandler(this.deconnect_Click);
            // 
            // sousTitre
            // 
            this.sousTitre.AutoSize = true;
            this.sousTitre.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sousTitre.Location = new System.Drawing.Point(12, 58);
            this.sousTitre.Name = "sousTitre";
            this.sousTitre.Size = new System.Drawing.Size(204, 19);
            this.sousTitre.TabIndex = 10;
            this.sousTitre.Text = "Veuillez sélectionner une option";
            // 
            // listAbo
            // 
            this.listAbo.Location = new System.Drawing.Point(652, 546);
            this.listAbo.Name = "listAbo";
            this.listAbo.Size = new System.Drawing.Size(154, 49);
            this.listAbo.TabIndex = 11;
            this.listAbo.Text = "LISTE ABONNÉS";
            this.listAbo.UseVisualStyleBackColor = true;
            this.listAbo.Click += new System.EventHandler(this.listAbo_Click);
            // 
            // Administrateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 607);
            this.Controls.Add(this.listAbo);
            this.Controls.Add(this.sousTitre);
            this.Controls.Add(this.deconnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.albumsNonEmprunts);
            this.Controls.Add(this.empruntMeilleurs);
            this.Controls.Add(this.empruntRetard);
            this.Controls.Add(this.purger);
            this.Controls.Add(this.empruntProlong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Administrateur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrateur";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button empruntProlong;
        private System.Windows.Forms.Button purger;
        private System.Windows.Forms.Button empruntRetard;
        private System.Windows.Forms.Button empruntMeilleurs;
        private System.Windows.Forms.Button albumsNonEmprunts;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deconnect;
        private System.Windows.Forms.Label sousTitre;
        private System.Windows.Forms.Button listAbo;
    }
}