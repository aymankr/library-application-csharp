
namespace ProjetDedisclasik
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
            this.label1 = new System.Windows.Forms.Label();
            this.listInfos = new System.Windows.Forms.ListBox();
            this.empruntsRetard = new System.Windows.Forms.Button();
            this.empruntsProlonges = new System.Windows.Forms.Button();
            this.purger = new System.Windows.Forms.Button();
            this.abonneNonEmprunts = new System.Windows.Forms.Button();
            this.meilleursEmprunts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administrateur";
            // 
            // listInfos
            // 
            this.listInfos.FormattingEnabled = true;
            this.listInfos.Location = new System.Drawing.Point(237, 42);
            this.listInfos.Name = "listInfos";
            this.listInfos.Size = new System.Drawing.Size(502, 316);
            this.listInfos.TabIndex = 6;
            // 
            // empruntsRetard
            // 
            this.empruntsRetard.Location = new System.Drawing.Point(26, 88);
            this.empruntsRetard.Name = "empruntsRetard";
            this.empruntsRetard.Size = new System.Drawing.Size(143, 40);
            this.empruntsRetard.TabIndex = 7;
            this.empruntsRetard.Text = "EMPRUNTS EN RETARD DE 10J";
            this.empruntsRetard.UseVisualStyleBackColor = true;
            this.empruntsRetard.Click += new System.EventHandler(this.empruntsRetard_Click);
            // 
            // empruntsProlonges
            // 
            this.empruntsProlonges.Location = new System.Drawing.Point(26, 42);
            this.empruntsProlonges.Name = "empruntsProlonges";
            this.empruntsProlonges.Size = new System.Drawing.Size(143, 40);
            this.empruntsProlonges.TabIndex = 9;
            this.empruntsProlonges.Text = "EMPRUNTS PROLONGÉS";
            this.empruntsProlonges.UseVisualStyleBackColor = true;
            this.empruntsProlonges.Click += new System.EventHandler(this.empruntsProlonges_Click);
            // 
            // purger
            // 
            this.purger.BackColor = System.Drawing.Color.LightCoral;
            this.purger.Location = new System.Drawing.Point(26, 258);
            this.purger.Name = "purger";
            this.purger.Size = new System.Drawing.Size(143, 40);
            this.purger.TabIndex = 10;
            this.purger.Text = "PURGER ABONNES EN RETARD DEPUIS UN AN";
            this.purger.UseVisualStyleBackColor = false;
            this.purger.Click += new System.EventHandler(this.purger_Click);
            // 
            // abonneNonEmprunts
            // 
            this.abonneNonEmprunts.Location = new System.Drawing.Point(26, 191);
            this.abonneNonEmprunts.Name = "abonneNonEmprunts";
            this.abonneNonEmprunts.Size = new System.Drawing.Size(143, 61);
            this.abonneNonEmprunts.TabIndex = 11;
            this.abonneNonEmprunts.Text = "ALBUMS N\'AYANT PAS EMPRUNTE DEPUIS PLUS D\'UN AN";
            this.abonneNonEmprunts.UseVisualStyleBackColor = true;
            this.abonneNonEmprunts.Click += new System.EventHandler(this.abonneNonEmprunts_Click);
            // 
            // meilleursEmprunts
            // 
            this.meilleursEmprunts.Location = new System.Drawing.Point(26, 134);
            this.meilleursEmprunts.Name = "meilleursEmprunts";
            this.meilleursEmprunts.Size = new System.Drawing.Size(143, 51);
            this.meilleursEmprunts.TabIndex = 8;
            this.meilleursEmprunts.Text = "10 ALBUMS LES PLUS EMPRUNTES L\'ANNEE";
            this.meilleursEmprunts.UseVisualStyleBackColor = true;
            this.meilleursEmprunts.Click += new System.EventHandler(this.meilleursEmprunts_Click);
            // 
            // Administrateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 404);
            this.Controls.Add(this.abonneNonEmprunts);
            this.Controls.Add(this.purger);
            this.Controls.Add(this.empruntsProlonges);
            this.Controls.Add(this.meilleursEmprunts);
            this.Controls.Add(this.empruntsRetard);
            this.Controls.Add(this.listInfos);
            this.Controls.Add(this.label1);
            this.Name = "Administrateur";
            this.Text = "Administrateur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listInfos;
        private System.Windows.Forms.Button empruntsRetard;
        private System.Windows.Forms.Button empruntsProlonges;
        private System.Windows.Forms.Button purger;
        private System.Windows.Forms.Button abonneNonEmprunts;
        private System.Windows.Forms.Button meilleursEmprunts;
    }
}