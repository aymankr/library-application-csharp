
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
            this.listInfos = new System.Windows.Forms.ListBox();
            this.albumsNonEmprunts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // empruntProlong
            // 
            this.empruntProlong.Location = new System.Drawing.Point(59, 93);
            this.empruntProlong.Name = "empruntProlong";
            this.empruntProlong.Size = new System.Drawing.Size(154, 33);
            this.empruntProlong.TabIndex = 0;
            this.empruntProlong.Text = "EMPRUNTS PROLONGES";
            this.empruntProlong.UseVisualStyleBackColor = true;
            this.empruntProlong.Click += new System.EventHandler(this.empruntProlong_Click);
            // 
            // purger
            // 
            this.purger.BackColor = System.Drawing.Color.LightCoral;
            this.purger.Location = new System.Drawing.Point(59, 276);
            this.purger.Name = "purger";
            this.purger.Size = new System.Drawing.Size(154, 51);
            this.purger.TabIndex = 1;
            this.purger.Text = "PURGER ABONNES N\'AYANT PAS EMPRUNTE DEPUIS UN AN";
            this.purger.UseVisualStyleBackColor = false;
            this.purger.Click += new System.EventHandler(this.purger_Click);
            // 
            // empruntRetard
            // 
            this.empruntRetard.Location = new System.Drawing.Point(59, 132);
            this.empruntRetard.Name = "empruntRetard";
            this.empruntRetard.Size = new System.Drawing.Size(154, 37);
            this.empruntRetard.TabIndex = 2;
            this.empruntRetard.Text = "EMPRUNTS EN RETARD DE 10J";
            this.empruntRetard.UseVisualStyleBackColor = true;
            this.empruntRetard.Click += new System.EventHandler(this.empruntRetard_Click);
            // 
            // empruntMeilleurs
            // 
            this.empruntMeilleurs.Location = new System.Drawing.Point(59, 175);
            this.empruntMeilleurs.Name = "empruntMeilleurs";
            this.empruntMeilleurs.Size = new System.Drawing.Size(154, 40);
            this.empruntMeilleurs.TabIndex = 3;
            this.empruntMeilleurs.Text = "10 ALBUMS LES PLUS EMPRUNTES DE L\'ANNEE";
            this.empruntMeilleurs.UseVisualStyleBackColor = true;
            this.empruntMeilleurs.Click += new System.EventHandler(this.empruntMeilleurs_Click);
            // 
            // listInfos
            // 
            this.listInfos.FormattingEnabled = true;
            this.listInfos.Location = new System.Drawing.Point(298, 55);
            this.listInfos.Name = "listInfos";
            this.listInfos.Size = new System.Drawing.Size(441, 316);
            this.listInfos.TabIndex = 4;
            // 
            // albumsNonEmprunts
            // 
            this.albumsNonEmprunts.Location = new System.Drawing.Point(59, 221);
            this.albumsNonEmprunts.Name = "albumsNonEmprunts";
            this.albumsNonEmprunts.Size = new System.Drawing.Size(154, 49);
            this.albumsNonEmprunts.TabIndex = 5;
            this.albumsNonEmprunts.Text = "ALBUMS NON EMPRUNTES DEPUIS UN AN";
            this.albumsNonEmprunts.UseVisualStyleBackColor = true;
            this.albumsNonEmprunts.Click += new System.EventHandler(this.albumsNonEmprunts_Click);
            // 
            // Administrateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.albumsNonEmprunts);
            this.Controls.Add(this.listInfos);
            this.Controls.Add(this.empruntMeilleurs);
            this.Controls.Add(this.empruntRetard);
            this.Controls.Add(this.purger);
            this.Controls.Add(this.empruntProlong);
            this.Name = "Administrateur";
            this.Text = "Administrateur";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button empruntProlong;
        private System.Windows.Forms.Button purger;
        private System.Windows.Forms.Button empruntRetard;
        private System.Windows.Forms.Button empruntMeilleurs;
        private System.Windows.Forms.ListBox listInfos;
        private System.Windows.Forms.Button albumsNonEmprunts;
    }
}