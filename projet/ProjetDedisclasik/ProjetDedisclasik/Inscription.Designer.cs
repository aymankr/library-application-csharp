
namespace ProjetDedisclasik
{
    partial class Inscription
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
            this.nom = new System.Windows.Forms.TextBox();
            this.mdp = new System.Windows.Forms.TextBox();
            this.prenom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ajout = new System.Windows.Forms.Button();
            this.listAbonnes = new System.Windows.Forms.ListBox();
            this.login = new System.Windows.Forms.TextBox();
            this.loginAbo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pays = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(101, 59);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(100, 20);
            this.nom.TabIndex = 0;
            // 
            // mdp
            // 
            this.mdp.Location = new System.Drawing.Point(101, 137);
            this.mdp.Name = "mdp";
            this.mdp.Size = new System.Drawing.Size(100, 20);
            this.mdp.TabIndex = 1;
            // 
            // prenom
            // 
            this.prenom.Location = new System.Drawing.Point(101, 96);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(100, 20);
            this.prenom.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prénom :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mot de passe : ";
            // 
            // ajout
            // 
            this.ajout.Location = new System.Drawing.Point(42, 303);
            this.ajout.Name = "ajout";
            this.ajout.Size = new System.Drawing.Size(128, 48);
            this.ajout.TabIndex = 6;
            this.ajout.Text = "OK";
            this.ajout.UseVisualStyleBackColor = true;
            this.ajout.Click += new System.EventHandler(this.ajout_Click);
            // 
            // listAbonnes
            // 
            this.listAbonnes.FormattingEnabled = true;
            this.listAbonnes.Location = new System.Drawing.Point(336, 62);
            this.listAbonnes.Name = "listAbonnes";
            this.listAbonnes.Size = new System.Drawing.Size(452, 303);
            this.listAbonnes.TabIndex = 7;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(101, 181);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(100, 20);
            this.login.TabIndex = 8;
            // 
            // loginAbo
            // 
            this.loginAbo.AutoSize = true;
            this.loginAbo.Location = new System.Drawing.Point(39, 184);
            this.loginAbo.Name = "loginAbo";
            this.loginAbo.Size = new System.Drawing.Size(39, 13);
            this.loginAbo.TabIndex = 9;
            this.loginAbo.Text = "Login :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pays :";
            // 
            // pays
            // 
            this.pays.Location = new System.Drawing.Point(101, 243);
            this.pays.Name = "pays";
            this.pays.Size = new System.Drawing.Size(100, 20);
            this.pays.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(218, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 48);
            this.button1.TabIndex = 14;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Inscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pays);
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
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.TextBox mdp;
        private System.Windows.Forms.TextBox prenom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ajout;
        private System.Windows.Forms.ListBox listAbonnes;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label loginAbo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pays;
        private System.Windows.Forms.Button button1;
    }
}

