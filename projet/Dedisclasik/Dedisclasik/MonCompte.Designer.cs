
namespace Dedisclasik
{
    partial class MonCompte
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
            this.albumEmprunt = new System.Windows.Forms.ListBox();
            this.Prolonger = new System.Windows.Forms.Button();
            this.dateRetourAttendue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToutProlonger = new System.Windows.Forms.Button();
            this.deconnexionButton = new System.Windows.Forms.Button();
            this.retourButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nomUtilisateur = new System.Windows.Forms.Label();
            this.prenomUtilisateur = new System.Windows.Forms.Label();
            this.loginUtilisateur = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // albumEmprunt
            // 
            this.albumEmprunt.FormattingEnabled = true;
            this.albumEmprunt.Location = new System.Drawing.Point(23, 231);
            this.albumEmprunt.Name = "albumEmprunt";
            this.albumEmprunt.Size = new System.Drawing.Size(752, 186);
            this.albumEmprunt.TabIndex = 0;
            this.albumEmprunt.SelectedIndexChanged += new System.EventHandler(this.albumEmprunt_SelectedIndexChanged);
            // 
            // Prolonger
            // 
            this.Prolonger.Location = new System.Drawing.Point(700, 161);
            this.Prolonger.Name = "Prolonger";
            this.Prolonger.Size = new System.Drawing.Size(75, 23);
            this.Prolonger.TabIndex = 1;
            this.Prolonger.Text = "Prolonger";
            this.Prolonger.UseVisualStyleBackColor = true;
            this.Prolonger.Click += new System.EventHandler(this.Prolonger_Click);
            // 
            // dateRetourAttendue
            // 
            this.dateRetourAttendue.AutoSize = true;
            this.dateRetourAttendue.Location = new System.Drawing.Point(149, 193);
            this.dateRetourAttendue.Name = "dateRetourAttendue";
            this.dateRetourAttendue.Size = new System.Drawing.Size(53, 13);
            this.dateRetourAttendue.TabIndex = 2;
            this.dateRetourAttendue.Text = "00/00/00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date de retour attendue:";
            // 
            // ToutProlonger
            // 
            this.ToutProlonger.Location = new System.Drawing.Point(547, 161);
            this.ToutProlonger.Name = "ToutProlonger";
            this.ToutProlonger.Size = new System.Drawing.Size(120, 23);
            this.ToutProlonger.TabIndex = 4;
            this.ToutProlonger.Text = "Tout prologoner";
            this.ToutProlonger.UseVisualStyleBackColor = true;
            this.ToutProlonger.Click += new System.EventHandler(this.ToutProlonger_Click);
            // 
            // deconnexionButton
            // 
            this.deconnexionButton.Location = new System.Drawing.Point(671, 12);
            this.deconnexionButton.Name = "deconnexionButton";
            this.deconnexionButton.Size = new System.Drawing.Size(117, 31);
            this.deconnexionButton.TabIndex = 5;
            this.deconnexionButton.Text = "Deconnexion";
            this.deconnexionButton.UseVisualStyleBackColor = true;
            this.deconnexionButton.Click += new System.EventHandler(this.deconnexionButton_Click);
            // 
            // retourButton
            // 
            this.retourButton.Location = new System.Drawing.Point(12, 12);
            this.retourButton.Name = "retourButton";
            this.retourButton.Size = new System.Drawing.Size(92, 24);
            this.retourButton.TabIndex = 6;
            this.retourButton.Text = "Retour";
            this.retourButton.UseVisualStyleBackColor = true;
            this.retourButton.Click += new System.EventHandler(this.retourButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mes albums empruntés :";
            // 
            // nomUtilisateur
            // 
            this.nomUtilisateur.AutoSize = true;
            this.nomUtilisateur.Location = new System.Drawing.Point(108, 62);
            this.nomUtilisateur.Name = "nomUtilisateur";
            this.nomUtilisateur.Size = new System.Drawing.Size(27, 13);
            this.nomUtilisateur.TabIndex = 8;
            this.nomUtilisateur.Text = "nom";
            // 
            // prenomUtilisateur
            // 
            this.prenomUtilisateur.AutoSize = true;
            this.prenomUtilisateur.Location = new System.Drawing.Point(190, 62);
            this.prenomUtilisateur.Name = "prenomUtilisateur";
            this.prenomUtilisateur.Size = new System.Drawing.Size(42, 13);
            this.prenomUtilisateur.TabIndex = 9;
            this.prenomUtilisateur.Text = "prenom";
            // 
            // loginUtilisateur
            // 
            this.loginUtilisateur.AutoSize = true;
            this.loginUtilisateur.Location = new System.Drawing.Point(108, 100);
            this.loginUtilisateur.Name = "loginUtilisateur";
            this.loginUtilisateur.Size = new System.Drawing.Size(29, 13);
            this.loginUtilisateur.TabIndex = 10;
            this.loginUtilisateur.Text = "login";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(341, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mon compte";
            // 
            // InterfaceTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loginUtilisateur);
            this.Controls.Add(this.prenomUtilisateur);
            this.Controls.Add(this.nomUtilisateur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.retourButton);
            this.Controls.Add(this.deconnexionButton);
            this.Controls.Add(this.ToutProlonger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateRetourAttendue);
            this.Controls.Add(this.Prolonger);
            this.Controls.Add(this.albumEmprunt);
            this.Name = "InterfaceTemp";
            this.Text = "InterfaceTemp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox albumEmprunt;
        private System.Windows.Forms.Button Prolonger;
        private System.Windows.Forms.Label dateRetourAttendue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ToutProlonger;
        private System.Windows.Forms.Button deconnexionButton;
        private System.Windows.Forms.Button retourButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nomUtilisateur;
        private System.Windows.Forms.Label prenomUtilisateur;
        private System.Windows.Forms.Label loginUtilisateur;
        private System.Windows.Forms.Label label6;
    }
}