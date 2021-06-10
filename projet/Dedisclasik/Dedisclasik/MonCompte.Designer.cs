
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
            this.Prolonger = new System.Windows.Forms.Button();
            this.dateRetourAttendue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToutProlonger = new System.Windows.Forms.Button();
            this.deconnexionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nomUtilisateur = new System.Windows.Forms.Label();
            this.prenomUtilisateur = new System.Windows.Forms.Label();
            this.loginUtilisateur = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridEmprunt = new System.Windows.Forms.DataGridView();
            this.pagesAlbums = new System.Windows.Forms.DataGridView();
            this.par_titre = new System.Windows.Forms.Label();
            this.par_genre = new System.Windows.Forms.Label();
            this.par_editeur = new System.Windows.Forms.Label();
            this.rendre = new System.Windows.Forms.Button();
            this.emprunter = new System.Windows.Forms.Button();
            this.rechercheTitre = new System.Windows.Forms.TextBox();
            this.rechercheGenre = new System.Windows.Forms.TextBox();
            this.rechercheEditeur = new System.Windows.Forms.TextBox();
            this.discotheque = new System.Windows.Forms.Label();
            this.ongletsAbonné = new System.Windows.Forms.TabControl();
            this.discothèque = new System.Windows.Forms.TabPage();
            this.mon_compte = new System.Windows.Forms.TabPage();
            this.Prénom = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Label();
            this.Nom = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmprunt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagesAlbums)).BeginInit();
            this.ongletsAbonné.SuspendLayout();
            this.discothèque.SuspendLayout();
            this.mon_compte.SuspendLayout();
            this.SuspendLayout();
            // 
            // Prolonger
            // 
            this.Prolonger.Location = new System.Drawing.Point(642, 110);
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
            this.dateRetourAttendue.Location = new System.Drawing.Point(232, 115);
            this.dateRetourAttendue.Name = "dateRetourAttendue";
            this.dateRetourAttendue.Size = new System.Drawing.Size(53, 13);
            this.dateRetourAttendue.TabIndex = 2;
            this.dateRetourAttendue.Text = "00/00/00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date de retour attendue:";
            // 
            // ToutProlonger
            // 
            this.ToutProlonger.Location = new System.Drawing.Point(464, 110);
            this.ToutProlonger.Name = "ToutProlonger";
            this.ToutProlonger.Size = new System.Drawing.Size(120, 23);
            this.ToutProlonger.TabIndex = 4;
            this.ToutProlonger.Text = "Tout prologoner";
            this.ToutProlonger.UseVisualStyleBackColor = true;
            this.ToutProlonger.Click += new System.EventHandler(this.ToutProlonger_Click);
            // 
            // deconnexionButton
            // 
            this.deconnexionButton.Location = new System.Drawing.Point(756, 12);
            this.deconnexionButton.Name = "deconnexionButton";
            this.deconnexionButton.Size = new System.Drawing.Size(117, 31);
            this.deconnexionButton.TabIndex = 5;
            this.deconnexionButton.Text = "Déconnexion";
            this.deconnexionButton.UseVisualStyleBackColor = true;
            this.deconnexionButton.Click += new System.EventHandler(this.deconnexionButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mes albums empruntés :";
            // 
            // nomUtilisateur
            // 
            this.nomUtilisateur.AutoSize = true;
            this.nomUtilisateur.Location = new System.Drawing.Point(58, 21);
            this.nomUtilisateur.Name = "nomUtilisateur";
            this.nomUtilisateur.Size = new System.Drawing.Size(27, 13);
            this.nomUtilisateur.TabIndex = 8;
            this.nomUtilisateur.Text = "nom";
            // 
            // prenomUtilisateur
            // 
            this.prenomUtilisateur.AutoSize = true;
            this.prenomUtilisateur.Location = new System.Drawing.Point(215, 21);
            this.prenomUtilisateur.Name = "prenomUtilisateur";
            this.prenomUtilisateur.Size = new System.Drawing.Size(42, 13);
            this.prenomUtilisateur.TabIndex = 9;
            this.prenomUtilisateur.Text = "prenom";
            // 
            // loginUtilisateur
            // 
            this.loginUtilisateur.AutoSize = true;
            this.loginUtilisateur.Location = new System.Drawing.Point(58, 49);
            this.loginUtilisateur.Name = "loginUtilisateur";
            this.loginUtilisateur.Size = new System.Drawing.Size(29, 13);
            this.loginUtilisateur.TabIndex = 10;
            this.loginUtilisateur.Text = "login";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(376, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mon compte";
            // 
            // dataGridEmprunt
            // 
            this.dataGridEmprunt.AllowUserToAddRows = false;
            this.dataGridEmprunt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmprunt.Location = new System.Drawing.Point(16, 144);
            this.dataGridEmprunt.Name = "dataGridEmprunt";
            this.dataGridEmprunt.RowHeadersVisible = false;
            this.dataGridEmprunt.RowHeadersWidth = 51;
            this.dataGridEmprunt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEmprunt.Size = new System.Drawing.Size(857, 249);
            this.dataGridEmprunt.TabIndex = 12;
            this.dataGridEmprunt.SelectionChanged += new System.EventHandler(this.dataGridEmprunt_SelectionChanged);
            // 
            // pagesAlbums
            // 
            this.pagesAlbums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pagesAlbums.Location = new System.Drawing.Point(7, 139);
            this.pagesAlbums.MultiSelect = false;
            this.pagesAlbums.Name = "pagesAlbums";
            this.pagesAlbums.ReadOnly = true;
            this.pagesAlbums.RowHeadersWidth = 51;
            this.pagesAlbums.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pagesAlbums.Size = new System.Drawing.Size(875, 254);
            this.pagesAlbums.TabIndex = 13;
            // 
            // par_titre
            // 
            this.par_titre.AutoSize = true;
            this.par_titre.Location = new System.Drawing.Point(35, 80);
            this.par_titre.Name = "par_titre";
            this.par_titre.Size = new System.Drawing.Size(49, 13);
            this.par_titre.TabIndex = 14;
            this.par_titre.Text = "Par titre :";
            // 
            // par_genre
            // 
            this.par_genre.AutoSize = true;
            this.par_genre.Location = new System.Drawing.Point(284, 80);
            this.par_genre.Name = "par_genre";
            this.par_genre.Size = new System.Drawing.Size(59, 13);
            this.par_genre.TabIndex = 15;
            this.par_genre.Text = "Par genre :";
            // 
            // par_editeur
            // 
            this.par_editeur.AutoSize = true;
            this.par_editeur.Location = new System.Drawing.Point(528, 80);
            this.par_editeur.Name = "par_editeur";
            this.par_editeur.Size = new System.Drawing.Size(64, 13);
            this.par_editeur.TabIndex = 16;
            this.par_editeur.Text = "Par éditeur :";
            // 
            // rendre
            // 
            this.rendre.Location = new System.Drawing.Point(781, 110);
            this.rendre.Name = "rendre";
            this.rendre.Size = new System.Drawing.Size(75, 23);
            this.rendre.TabIndex = 17;
            this.rendre.Text = "Rendre";
            this.rendre.UseVisualStyleBackColor = true;
            this.rendre.Click += new System.EventHandler(this.rendre_Click);
            // 
            // emprunter
            // 
            this.emprunter.Location = new System.Drawing.Point(782, 74);
            this.emprunter.Margin = new System.Windows.Forms.Padding(2);
            this.emprunter.Name = "emprunter";
            this.emprunter.Size = new System.Drawing.Size(85, 24);
            this.emprunter.TabIndex = 18;
            this.emprunter.Text = "Emprunter";
            this.emprunter.UseVisualStyleBackColor = true;
            this.emprunter.Click += new System.EventHandler(this.emprunter_Click);
            // 
            // rechercheTitre
            // 
            this.rechercheTitre.Location = new System.Drawing.Point(38, 105);
            this.rechercheTitre.Margin = new System.Windows.Forms.Padding(2);
            this.rechercheTitre.Name = "rechercheTitre";
            this.rechercheTitre.Size = new System.Drawing.Size(190, 20);
            this.rechercheTitre.TabIndex = 19;
            this.rechercheTitre.TextChanged += new System.EventHandler(this.rechercheTitre_TextChanged);
            // 
            // rechercheGenre
            // 
            this.rechercheGenre.Location = new System.Drawing.Point(287, 105);
            this.rechercheGenre.Margin = new System.Windows.Forms.Padding(2);
            this.rechercheGenre.Name = "rechercheGenre";
            this.rechercheGenre.Size = new System.Drawing.Size(190, 20);
            this.rechercheGenre.TabIndex = 20;
            // 
            // rechercheEditeur
            // 
            this.rechercheEditeur.Location = new System.Drawing.Point(531, 105);
            this.rechercheEditeur.Margin = new System.Windows.Forms.Padding(2);
            this.rechercheEditeur.Name = "rechercheEditeur";
            this.rechercheEditeur.Size = new System.Drawing.Size(190, 20);
            this.rechercheEditeur.TabIndex = 21;
            // 
            // discotheque
            // 
            this.discotheque.AutoSize = true;
            this.discotheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discotheque.Location = new System.Drawing.Point(367, 28);
            this.discotheque.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.discotheque.Name = "discotheque";
            this.discotheque.Size = new System.Drawing.Size(144, 26);
            this.discotheque.TabIndex = 22;
            this.discotheque.Text = "Discothèque";
            // 
            // ongletsAbonné
            // 
            this.ongletsAbonné.Controls.Add(this.discothèque);
            this.ongletsAbonné.Controls.Add(this.mon_compte);
            this.ongletsAbonné.Location = new System.Drawing.Point(1, 4);
            this.ongletsAbonné.Name = "ongletsAbonné";
            this.ongletsAbonné.SelectedIndex = 0;
            this.ongletsAbonné.Size = new System.Drawing.Size(897, 427);
            this.ongletsAbonné.TabIndex = 23;
            this.ongletsAbonné.SelectedIndexChanged += new System.EventHandler(this.ongletsAbonné_SelectedIndexChanged);
            // 
            // discothèque
            // 
            this.discothèque.Controls.Add(this.button1);
            this.discothèque.Controls.Add(this.discotheque);
            this.discothèque.Controls.Add(this.emprunter);
            this.discothèque.Controls.Add(this.pagesAlbums);
            this.discothèque.Controls.Add(this.rechercheEditeur);
            this.discothèque.Controls.Add(this.par_editeur);
            this.discothèque.Controls.Add(this.rechercheGenre);
            this.discothèque.Controls.Add(this.par_genre);
            this.discothèque.Controls.Add(this.rechercheTitre);
            this.discothèque.Controls.Add(this.par_titre);
            this.discothèque.Location = new System.Drawing.Point(4, 22);
            this.discothèque.Name = "discothèque";
            this.discothèque.Padding = new System.Windows.Forms.Padding(3);
            this.discothèque.Size = new System.Drawing.Size(889, 401);
            this.discothèque.TabIndex = 0;
            this.discothèque.Text = "Discothèque";
            this.discothèque.UseVisualStyleBackColor = true;
            // 
            // mon_compte
            // 
            this.mon_compte.Controls.Add(this.Prénom);
            this.mon_compte.Controls.Add(this.Login);
            this.mon_compte.Controls.Add(this.Nom);
            this.mon_compte.Controls.Add(this.label6);
            this.mon_compte.Controls.Add(this.deconnexionButton);
            this.mon_compte.Controls.Add(this.rendre);
            this.mon_compte.Controls.Add(this.nomUtilisateur);
            this.mon_compte.Controls.Add(this.dataGridEmprunt);
            this.mon_compte.Controls.Add(this.Prolonger);
            this.mon_compte.Controls.Add(this.prenomUtilisateur);
            this.mon_compte.Controls.Add(this.label2);
            this.mon_compte.Controls.Add(this.ToutProlonger);
            this.mon_compte.Controls.Add(this.loginUtilisateur);
            this.mon_compte.Controls.Add(this.dateRetourAttendue);
            this.mon_compte.Controls.Add(this.label1);
            this.mon_compte.Location = new System.Drawing.Point(4, 22);
            this.mon_compte.Name = "mon_compte";
            this.mon_compte.Padding = new System.Windows.Forms.Padding(3);
            this.mon_compte.Size = new System.Drawing.Size(889, 401);
            this.mon_compte.TabIndex = 1;
            this.mon_compte.Text = "Mon compte";
            this.mon_compte.UseVisualStyleBackColor = true;
            // 
            // Prénom
            // 
            this.Prénom.AutoSize = true;
            this.Prénom.Location = new System.Drawing.Point(160, 21);
            this.Prénom.Name = "Prénom";
            this.Prénom.Size = new System.Drawing.Size(49, 13);
            this.Prénom.TabIndex = 20;
            this.Prénom.Text = "Prénom :";
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Location = new System.Drawing.Point(13, 49);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(39, 13);
            this.Login.TabIndex = 19;
            this.Login.Text = "Login :";
            // 
            // Nom
            // 
            this.Nom.AutoSize = true;
            this.Nom.Location = new System.Drawing.Point(17, 21);
            this.Nom.Name = "Nom";
            this.Nom.Size = new System.Drawing.Size(35, 13);
            this.Nom.TabIndex = 18;
            this.Nom.Text = "Nom :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(756, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 31);
            this.button1.TabIndex = 23;
            this.button1.Text = "Déconnexion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MonCompte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 431);
            this.Controls.Add(this.ongletsAbonné);
            this.Name = "MonCompte";
            this.Text = "InterfaceTemp";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmprunt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagesAlbums)).EndInit();
            this.ongletsAbonné.ResumeLayout(false);
            this.discothèque.ResumeLayout(false);
            this.discothèque.PerformLayout();
            this.mon_compte.ResumeLayout(false);
            this.mon_compte.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Prolonger;
        private System.Windows.Forms.Label dateRetourAttendue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ToutProlonger;
        private System.Windows.Forms.Button deconnexionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nomUtilisateur;
        private System.Windows.Forms.Label prenomUtilisateur;
        private System.Windows.Forms.Label loginUtilisateur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridEmprunt;
        private System.Windows.Forms.DataGridView pagesAlbums;
        private System.Windows.Forms.Label par_titre;
        private System.Windows.Forms.Label par_genre;
        private System.Windows.Forms.Label par_editeur;
        private System.Windows.Forms.Button rendre;
        private System.Windows.Forms.Button emprunter;
        private System.Windows.Forms.TextBox rechercheTitre;
        private System.Windows.Forms.TextBox rechercheGenre;
        private System.Windows.Forms.TextBox rechercheEditeur;
        private System.Windows.Forms.Label discotheque;
        private System.Windows.Forms.TabControl ongletsAbonné;
        private System.Windows.Forms.TabPage discothèque;
        private System.Windows.Forms.TabPage mon_compte;
        private System.Windows.Forms.Label Prénom;
        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.Label Nom;
        private System.Windows.Forms.Button button1;
    }
}