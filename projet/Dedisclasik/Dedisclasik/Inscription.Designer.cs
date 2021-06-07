
namespace Dedisclasik
{
    partial class Inscription
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
            this.listPaysBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.loginAbo = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.listAbonnes = new System.Windows.Forms.ListBox();
            this.ajout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.prenom = new System.Windows.Forms.TextBox();
            this.mdp = new System.Windows.Forms.TextBox();
            this.nom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listPaysBox
            // 
            this.listPaysBox.FormattingEnabled = true;
            this.listPaysBox.Location = new System.Drawing.Point(101, 229);
            this.listPaysBox.Name = "listPaysBox";
            this.listPaysBox.Size = new System.Drawing.Size(121, 21);
            this.listPaysBox.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(218, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 48);
            this.button1.TabIndex = 27;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Pays :";
            // 
            // loginAbo
            // 
            this.loginAbo.AutoSize = true;
            this.loginAbo.Location = new System.Drawing.Point(39, 197);
            this.loginAbo.Name = "loginAbo";
            this.loginAbo.Size = new System.Drawing.Size(39, 13);
            this.loginAbo.TabIndex = 25;
            this.loginAbo.Text = "Login :";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(101, 194);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(100, 20);
            this.login.TabIndex = 24;
            // 
            // listAbonnes
            // 
            this.listAbonnes.FormattingEnabled = true;
            this.listAbonnes.Location = new System.Drawing.Point(336, 75);
            this.listAbonnes.Name = "listAbonnes";
            this.listAbonnes.Size = new System.Drawing.Size(452, 303);
            this.listAbonnes.TabIndex = 23;
            // 
            // ajout
            // 
            this.ajout.Location = new System.Drawing.Point(42, 316);
            this.ajout.Name = "ajout";
            this.ajout.Size = new System.Drawing.Size(128, 48);
            this.ajout.TabIndex = 22;
            this.ajout.Text = "OK";
            this.ajout.UseVisualStyleBackColor = true;
            this.ajout.Click += new System.EventHandler(this.ajout_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Mot de passe : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Prénom :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nom :";
            // 
            // prenom
            // 
            this.prenom.Location = new System.Drawing.Point(101, 109);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(100, 20);
            this.prenom.TabIndex = 18;
            // 
            // mdp
            // 
            this.mdp.Location = new System.Drawing.Point(101, 150);
            this.mdp.Name = "mdp";
            this.mdp.Size = new System.Drawing.Size(100, 20);
            this.mdp.TabIndex = 17;
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(101, 72);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(100, 20);
            this.nom.TabIndex = 16;
            // 
            // Inscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listPaysBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loginAbo);
            this.Controls.Add(this.login);
            this.Controls.Add(this.listAbonnes);
            this.Controls.Add(this.ajout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prenom);
            this.Controls.Add(this.mdp);
            this.Controls.Add(this.nom);
            this.Name = "Inscription";
            this.Text = "Inscription";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox listPaysBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label loginAbo;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.ListBox listAbonnes;
        private System.Windows.Forms.Button ajout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox prenom;
        private System.Windows.Forms.TextBox mdp;
        private System.Windows.Forms.TextBox nom;
    }
}